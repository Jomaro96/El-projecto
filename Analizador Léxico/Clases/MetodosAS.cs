using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Analizador_Léxico.Clases
{
    class MetodosAS
    {
        public static void CrearMatriz()
        {

            //Obtener Matriz
            using (SqlConnection con = ConexionMatriz.ObtenerConexion(MetodosAL.Servidor))
            {
                SqlCommand comm = new SqlCommand("SELECT * FROM PRODUCCIONES order by DATALENGTH(Valor) ASC", con);
                SqlDataReader red = comm.ExecuteReader();
                Matriz.Load(red);
            }

        }
        public static DataTable Matriz = new DataTable();
        public static string ObtenerConversion(string Combinacion)
        {
            string resultado = Combinacion;
            string where = "Valor = '" + Combinacion + "'";
            DataRow[] conversion = Matriz.Select(where);
            if (conversion.Length != 0) resultado = conversion[0]["PRODUCCION"].ToString();
            return resultado;

        }
        public static string NormalizarCadena(string subcadena, int tempo)
        {

            string[] d = subcadena.Split(' ');
            string strCambio = subcadena;
            if (tempo == 1)
            {
                if (d[0] != "IDEN")
                {
                    switch (d[0].Substring(0, 2))
                    {
                        case "ID":
                            strCambio = "ID";
                            break;
                        case "CN":
                            strCambio = "CNE";
                            break;
                    }
                }
                /*if (d[0].Substring(0, 2) == "ID" && d[0] != "IDEN") { strCambio = "ID"; }
                else if ((d[0] + "  ").Substring(0, 3) == "CNE") { strCambio = "CNE"; }
                else if ((d[0] + " ").Substring(0, 3) == "CNR") { strCambio = "CNR"; }
                else if ((d[0] + " ").Substring(0, 4) == "CNEE") { strCambio = "CNEE"; }
                else if ((d[0] + " ").Substring(0, 4) == "CNRE") { strCambio = "CNRE"; }*/
            }
            return strCambio;


        }
        public static bool DisminuirTemp(string[] Combinaciones, int temp)
        {
            string strCambio = "";
            foreach (string str in Combinaciones)
            {
                strCambio = NormalizarCadena(str, temp);
                string where = "VALOR = '" + strCambio + "'";
                DataRow[] conversion = Matriz.Select(where);
                if (conversion.Length != 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static List<string> AnalizadorSintactico(List<string> LineasTokens)
        {
            string salida = "";
            string validas = "";
            List<string> salidas = new List<string>();
            int linea = 1;
            string strCambio;
            string strActual;
            int begins = 0;
            int ends = 0;
            int temp;
            CrearMatriz();// ve a este metodo para crear un data tablecon la matriz de tu semantica
            //this is a  better bottom up lmao
            try
            {
                foreach (string cadena in LineasTokens)
                {
                    strActual = cadena;
                    strActual = strActual.Substring(0, strActual.Length - 2);
                    salida += cadena ;
                    temp = strActual.Split(' ').Length;

                    while (temp > 0)
                    {
        
                        string[] strSubcadenas = MetodosASe.CrearCombinaciones(temp, strActual); //Crea combinaciones dependiendo del temporal
                        if (DisminuirTemp(strSubcadenas, temp)) { temp--; }//Si no hay nada que cambiar lo disminuye
                        else
                        {
                            //Pero si si hay comienza a ver que es lo que tiene que reemplzar
                            foreach (string str in strSubcadenas)
                            {
                                strCambio = NormalizarCadena(str, temp);
                                strActual = strActual.Replace(str, ObtenerConversion(strCambio)); //Lo remplaza
                            }
                            salida += strActual + "\n";
                            temp = strActual.Split(' ').Length;
                        }
                        if (strActual == "S")
                        {
                            validas += "Línea " + linea.ToString() + ":S" + "\n";
                            temp = 0;
                            linea++;
                        }
                    }
                    if (strActual != "S") {
                        validas += "Línea " + linea.ToString() + ":ERROR" + "\n"; /*MessageBox.Show("Semantica incorrecta en la línea: " + linea);*/ linea++; }
                }
              
                salidas.Add(salida);//Esto es para regresar los errores
             
                return salidas;

            }
            catch (Exception ex) { MessageBox.Show("Error: Error de semantica en la linea: " + linea + " Los tipos de dato no concuerdan" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return salidas; }
        }
    }
    
}
