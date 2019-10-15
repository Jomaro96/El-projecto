﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_Léxico.Clases
{
    public class MetodosAL
    {

        private static string _strServidor;

        public static string Servidor
        {
            get { return _strServidor; }
            set { _strServidor = value; }
        }
        public MetodosAL(string server)
        {
            Servidor = server;
        }

        public static List<Identificador> Identificadores = new List<Identificador>();
        public static List<NumericoEntero> ConstantesNumericasEnteras = new List<NumericoEntero>();
        public static List<NumericoExponencial> ConstantesNumericasExponenciales = new List<NumericoExponencial>();
        public static List<NumericoReal> ConstantesNumericasReales = new List<NumericoReal>();
        public static List<NumericoExpReal> ConstantesNumericasExpReales = new List<NumericoExpReal>();

        public static List<string> AnalizadorLexico(string strEntrada)
        {

            int linea = 0;
            List<string> TokensLexico = new List<string>();
            string[] strLineas = strEntrada.Split('\n');
            foreach (string Linea in strLineas)
            {
                string strTokens = "";
                linea++;
                List<string> tokens = new List<string>();
                MetodosAL.ObtenerToken(Linea, ref tokens);
                if (Linea != "")
                {
                    foreach (string token in tokens) strTokens += token + " ";
                    strTokens += "\n";
                    TokensLexico.Add(strTokens);
                }
                
            }
            return (TokensLexico);
        }
       

        public static void ObtenerToken(string Palabra, ref List<string> tokens)
        {
            int intEstadoActual = 0;
            bool bandera = false;
            List<char> caracteres = new List<char>();
            foreach (char c in Palabra)
            {
                caracteres.Add(c);
                intEstadoActual = NuevoEstado(c, intEstadoActual, ref bandera);
                if (bandera)
                {
                    tokens.Add(ObtenerToken(intEstadoActual, caracteres));
                    intEstadoActual = 0;
                    bandera = false;
                    caracteres.Clear();
                }   
            }
            intEstadoActual = NuevoEstado(' ', intEstadoActual, ref bandera);
            tokens.Add(ObtenerToken(intEstadoActual, caracteres));
        }

        public static int NuevoEstado(char c, int intEstadoActual, ref bool bandera)
        {
            int Estado = 0;
            using (SqlConnection con = ConexionMatriz.ObtenerConexion(Servidor))
            {
                SqlCommand comando = new SqlCommand("EXEC NUEVOESTADO '" + c + "'," + intEstadoActual + "",con);                
                SqlDataReader estado = comando.ExecuteReader();
                if (estado.Read()) { if (!estado.IsDBNull(0)) Estado = estado.GetInt32(0); else throw new Exception("Se encontró un error en la línea "); }
                comando = new SqlCommand("SELECT TOKEN FROM TRANSICION WHERE ESTADO = " + Estado, con);
                estado = comando.ExecuteReader();
                if (estado.Read())  if (!estado.IsDBNull(0)) bandera = true;   
            }
            return Estado;
        }
        public static string ObtenerToken(int intEstadoActual)
        {
            string token = "";
            using (SqlConnection con = ConexionMatriz.ObtenerConexion(Servidor))
            {
                SqlCommand comando = new SqlCommand("select token from transicion where estado = " + intEstadoActual, con);
                SqlDataReader tok = comando.ExecuteReader();
                if (tok.Read())  if (!tok.IsDBNull(0)) token = tok.GetString(0).Trim(); 
            }
            return token;
        }
        public static string ObtenerToken(int intEstadoActual, List<char> Palabra)
        {
            string token = "";
            using (SqlConnection con = ConexionMatriz.ObtenerConexion(Servidor))
            {
                SqlCommand comando = new SqlCommand("select token from transicion where estado = " + intEstadoActual, con);
                SqlDataReader tok = comando.ExecuteReader();
                if (tok.Read())  if (!tok.IsDBNull(0)) token = tok.GetString(0).Trim(); 
            }
            IdentificarToken(Palabra, ref token, intEstadoActual);
            return token;
        }
        public static int CaracterPorCaracter(char c, int intEstadoActual)
        {
            int Estado = 0;
            
            using (SqlConnection con = ConexionMatriz.ObtenerConexion(Servidor))
            {
                SqlCommand comando = new SqlCommand("EXEC NUEVOESTADO '" + c + "'," + intEstadoActual + "", con);
                SqlDataReader estado = comando.ExecuteReader();
                if (estado.Read()) { if (!estado.IsDBNull(0)) Estado = estado.GetInt32(0); else throw new Exception(); }
                comando = new SqlCommand("SELECT TOKEN FROM TRANSICION WHERE ESTADO = " + Estado, con);
                estado = comando.ExecuteReader();
                if (estado.Read())  if (!estado.IsDBNull(0)) return Estado; 
            }
            return Estado;
        }
        private static void IdentificarToken(List<char> C, ref string token, int EstadoFinal)
        {
            string Palabra = "";
            foreach (char a in C)
                Palabra += a;
            switch (EstadoFinal)
            {
                case 201:
                    Identificador unIdentificador = new Identificador();
                    unIdentificador.Nombre = Palabra.Trim();
                    foreach (Identificador otroIdentificador in Identificadores){if(otroIdentificador.Equals(unIdentificador)){token += otroIdentificador.Index.ToString();return;}}
                    unIdentificador.Index = Identificadores.Count + 1;
                    token += unIdentificador.Index.ToString();
                    Identificadores.Add(unIdentificador);
                    break;
                case 212:
                    NumericoEntero unNumericoEntero = new NumericoEntero();
                    unNumericoEntero.Contenido = int.Parse(Palabra);
                    foreach(NumericoEntero otroNE in ConstantesNumericasEnteras) { if (otroNE.Equals(unNumericoEntero)) { token += otroNE.Index.ToString();return;}}
                    unNumericoEntero.Index = ConstantesNumericasEnteras.Count + 1;
                    token += unNumericoEntero.Index.ToString();
                    ConstantesNumericasEnteras.Add(unNumericoEntero);
                    break;
                case 211:
                    NumericoReal unNumericoReal = new NumericoReal();
                    unNumericoReal.Contenido = double.Parse(Palabra);
                    foreach (NumericoReal otroNR in ConstantesNumericasReales) { if (otroNR.Equals(unNumericoReal)) { token += otroNR.Index.ToString(); return; } }
                    unNumericoReal.Index = ConstantesNumericasReales.Count + 1;
                    token += unNumericoReal.Index.ToString();                  
                    ConstantesNumericasReales.Add(unNumericoReal);
                    break;
                case 216:
                    NumericoExponencial unNumericoExponencial = new NumericoExponencial();
                    string[] partesExponente = Palabra.Split('E');
                    unNumericoExponencial.Contenido = int.Parse(partesExponente[0]);
                    foreach (NumericoExponencial otroNEX in ConstantesNumericasExponenciales) { if (otroNEX.Equals(unNumericoExponencial)) { token += otroNEX.Index.ToString(); return; } }
                    unNumericoExponencial.Index = ConstantesNumericasExponenciales.Count + 1;
                    token += unNumericoExponencial.Index.ToString();
                    unNumericoExponencial.Exponencial = int.Parse(partesExponente[1]);
                    ConstantesNumericasExponenciales.Add(unNumericoExponencial);
                    break;
                case 210:
                    NumericoExpReal unNumericoExpReal = new NumericoExpReal();
                    string[] partesExponentereal = Palabra.Split('E');
                    unNumericoExpReal.Contenido = double.Parse(partesExponentereal[0]);
                    foreach (NumericoExpReal otroNER in ConstantesNumericasExpReales) { if (otroNER.Equals(unNumericoExpReal)) { token += otroNER.Index.ToString(); return; } }
                    unNumericoExpReal.Index = ConstantesNumericasExpReales.Count + 1;
                    token += unNumericoExpReal.Index.ToString();
                    unNumericoExpReal.Exponencial = int.Parse(partesExponentereal[1]);
                    ConstantesNumericasExpReales.Add(unNumericoExpReal);
                    break;
            }
        }
        
        
        
    }
}
