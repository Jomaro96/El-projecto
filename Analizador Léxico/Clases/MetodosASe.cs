using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Analizador_Léxico.Clases
{
    class MetodosASe
    {
        public static string[] CrearCombinaciones(int temp, string linea)
        {
            string[] arreglo = linea.Split(' ');

            string[] NuevaLinea = new string[(arreglo.Length + 1) - temp];
            for (int j = 0; j < NuevaLinea.Length; j++)
            {
                string Elemento = "";
                for (int i = 0; i < temp; i++)
                {
                    if (temp != 1) Elemento += arreglo[j + i] + " ";
                    else Elemento += arreglo[j + i];
                }
                if (temp == 1) NuevaLinea[j] = Elemento;
                else NuevaLinea[j] = Elemento.Substring(0, Elemento.Length - 1);
            }
            return NuevaLinea;
        }

        public static string ObtenerArchivoTemporal(string Linea)
        {

            foreach (Identificador elemento in MetodosAL.Identificadores)
            {
                string id = "ID" + elemento.Index;
                if (Linea.Contains("PR20") && elemento.Tipo == null) { Linea = Linea.Replace(id, "VOID"); elemento.Tipo = "VOID"; }
                else Linea = Linea.Replace(id, elemento.Tipo);
            }
            foreach (NumericoEntero x in MetodosAL.ConstantesNumericasEnteras)
            {
                string id = "CNE" + x.Index;
                Linea = Linea.Replace(id, "ENTE");
            }
            foreach (NumericoExponencial x in MetodosAL.ConstantesNumericasExponenciales)
            {
                string id = "CNEE" + x.Index;
                Linea = Linea.Replace(id, "ENTE");
            }
            foreach (NumericoReal x in MetodosAL.ConstantesNumericasReales)
            {
                string id = "CNR" + x.Index;
                Linea = Linea.Replace(id, "REAL");
            }
            foreach (NumericoExpReal x in MetodosAL.ConstantesNumericasExpReales)
            {
                string id = "CNRE" + x.Index;
                Linea = Linea.Replace(id, "ENTE");
            }
            return Linea;
        }
        public static List<string> PrimeraPasada(List<string> LineasTokens)
        {
            List<string> LineasSemantica = new List<string>();
            string strActual = "";
            try
            {
                foreach (string cadena in LineasTokens)
                {
                    strActual = cadena;
                    strActual = strActual.Substring(0, strActual.Length - 2);
                    string[] combinacionesde2 = CrearCombinaciones(2, strActual); //Metodo que crea combinaciones de 2 dos para descubrir los TDD1 ID
                    foreach (string str in combinacionesde2)
                    {
                        string[] arreglo1 = str.Split(' ');

                        if (arreglo1[0].Substring(0, 3) == "TDD" && arreglo1[1].Substring(0, 2) == "ID")  //if para veificar si es un TDD1 IDX
                        {
                            string strIndex1 = arreglo1[1];
                            int index = int.Parse(strIndex1.Replace("ID", ""));
                            Identificador elemento = MetodosAL.Identificadores.Find(x => x.Index == index);
                            MetodosAL.Identificadores.Remove(elemento);
                            switch (arreglo1[0])
                            {
                                case "TDD1":
                                    elemento.Tipo = "ENTE"; //Cambialos por los que vayas a usar
                                    break;
                                case "TDD2":
                                    elemento.Tipo = "REAL";
                                    break;
                                case "TDD3":
                                    elemento.Tipo = "CADE";
                                    break;
                                case "TDD4":
                                    elemento.Tipo = "CHAR";
                                    break;
                                case "TDD5":
                                    elemento.Tipo = "BOOL";
                                    break;
                                default:
                                    throw new Exception("Tipo de dato erroneo");
                            }
                            MetodosAL.Identificadores.Add(elemento);
                        }
                    }
                }
                foreach (string d in LineasTokens)
                {
                    LineasSemantica.Add(ObtenerArchivoTemporal(d)); //Obtiene el archivo intermedio
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return LineasSemantica;
        }
        public static void CrearMatriz()
        {

            //Obtener Matriz
            using (SqlConnection con = ConexionMatriz.ObtenerConexion(MetodosAL.Servidor))
            {
                SqlCommand comm = new SqlCommand("SELECT * FROM ReglasSemanticas order by DATALENGTH(Combinacion) ASC", con);
                SqlDataReader red = comm.ExecuteReader();
                Matriz.Load(red);
            }

        }
        public static DataTable Matriz = new DataTable();
        public static string ObtenerConversion(string Combinacion)
        {
            string resultado = Combinacion;
            string where = "Combinacion = '" + Combinacion + "'";
            DataRow[] conversion = Matriz.Select(where);
            if (conversion.Length != 0) resultado = conversion[0]["Conversion"].ToString();
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
                string where = "Combinacion = '" + strCambio + "'";
                DataRow[] conversion = Matriz.Select(where);
                if (conversion.Length != 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static List<string> SegundaPasada(List<string> LineasSemantica)
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
                foreach (string cadena in LineasSemantica)
                {
                    strActual = cadena;
                    strActual = strActual.Substring(0, strActual.Length - 2);
                    salida += cadena ;
                    temp = strActual.Split(' ').Length;

                    while (temp > 0)
                    {
                        string[] strSubcadenas = CrearCombinaciones(temp, strActual); //Crea combinaciones dependiendo del temporal
                        if (DisminuirTemp(strSubcadenas, temp)) { temp--; }//Si no hay nada que cambiar lo disminuye
                        else
                        {
                            //Pero si si hay comienza a ver que es lo que tiene que reemplzar
                            foreach (string str in strSubcadenas)
                            {
                                strCambio = NormalizarCadena(str, temp);
                                strActual = strActual.Replace(str,ObtenerConversion(strCambio)); //Lo remplaza
                            }
                            salida += strActual + "\n";
                            temp = strActual.Split(' ').Length;
                        }
                        if (strActual == "S")
                        {
                            //Esto es tercera pasada, por cada palabra reservada compuesta se agrega uno
                            if (
                                (/*cadena.Contains("PR04") && cadena.Contains("PR20")) |
                                cadena.Contains("PR04") |
                                cadena.Contains("PR05") |
                                cadena.Contains("PR11") |
                                cadena.Contains("PR18") |
                                cadena.Contains("PR20")*/
                                cadena.Contains("PR23") |
                                cadena.Contains("PR11") |
                                cadena.Contains("PR16") |
                                cadena.Contains("PR25") )
                            ) begins++;
                            else
                            {
                                if (cadena.Contains("PR06")| cadena.Contains("PR07")| cadena.Contains("PR14")) ends++; // y como nosotro tenemos una sola palabra para cerrar pues sola detecta suma uno a otrocontador
                            }
                            validas += "Línea " + linea.ToString() + ":S" + "\n";
                            temp = 0;
                            linea++;
                        }
                    }
                    if (strActual != "S") { validas += "Línea " + linea.ToString() + ":ERROR" + "\n"; /*MessageBox.Show("Semantica incorrecta en la línea: " + linea)*/; linea++; }
                }
                if (begins - ends == 0) ; //MessageBox.Show("Bloque valido"); //Las resta si es cero es valido
                else MessageBox.Show("Bloque invalido"); //Si no es invalido 
                salidas.Add(salida);//Esto es para regresar los errores
         
                return salidas;

            }
            catch (Exception ex) {
               // MessageBox.Show("Error: Error de semantica en la linea: " + linea + " Los tipos de dato no concuerdan" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return salidas; }
        }
    }
}