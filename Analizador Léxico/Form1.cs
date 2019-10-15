using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Analizador_Léxico.Clases;
using System.Diagnostics;
using System.Data.Sql;

namespace Analizador_Léxico
{
    public partial class Form1 : Form
    {
        JerarquiaConversor eval;
        public Form1()
        {
            InitializeComponent();
            SqlConnection conexion = new SqlConnection("server=localhost\\SQLEXPRESS; database=LENGUAJE2 ; integrated security = true");
            conexion.Open();
            SqlDataAdapter data = new SqlDataAdapter("SELECT PRODUCCION,VALOR FROM PRODUCCIONES WHERE NUMTOKENS IS NOT NULL", conexion);
            data.Fill(DT);
            
            for(int i = 0; i <= DT.Rows.Count - 1; i++)
            {
                int x = DT.Rows[i][1].ToString().Length;
                if (DT.Rows[i][1].ToString().Substring(x - 1,1) == " ")
                {
                    DT.Rows[i][1] = DT.Rows[i][1].ToString().Substring(0, x - 1);
                }
            }

            SqlDataAdapter data2 = new SqlDataAdapter("SELECT PRODUCCION,VALOR FROM PRODUCCIONES WHERE NUMTOKENS IS NULL", conexion);
            data2.Fill(DT2);

            for (int i = 0; i <= DT2.Rows.Count - 1; i++)
            {
                int x = DT2.Rows[i][1].ToString().Length;
                if (DT2.Rows[i][1].ToString().Substring(x - 1, 1) == " ")
                {
                    DT2.Rows[i][1] = DT2.Rows[i][1].ToString().Substring(0, x - 1);
                }
            }
        }
        DataTable DT = new DataTable();
        DataTable DT2 = new DataTable();

        private void btnleertodo_Click(object sender, EventArgs e)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            try {
                Depurar();
                //Analizador Lexico
                List<string> TokensEntrada = MetodosAL.AnalizadorLexico(rtxtentrada.Text);
                foreach (string s in TokensEntrada) rtxtcodigointermedio.Text += s;


                //Analizador Sintactico
                //string strTokens = TrasformarAIden(rtxtcodigointermedio.Text);
                //rtxtIDEN.Text = strTokens;
                //AnalizadorSintactico();
                List<string> LineasSintactico = MetodosAS.AnalizadorSintactico(TokensEntrada);
                foreach(string cx in LineasSintactico)rtxtSalida.Text = cx;


                //Analizar Semantico
                
                List<string> SemanticaIntermedia = MetodosASe.PrimeraPasada(TokensEntrada);
                foreach (string linea in SemanticaIntermedia) rchtxtSementica.Text += linea ;
                 MostrarIdentificadoresConstantes();
              List<string> LineasSemanticas = MetodosASe.SegundaPasada(SemanticaIntermedia);
                foreach (string linea in LineasSemanticas) rchtxtSementica.Text += linea;


                linea = 1;
                st.Stop();
                MessageBox.Show(st.Elapsed.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + linea + ".\nVerifique el uso apropiado del léxico.", "Error de analizador léxico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                linea = 1;
            }
        }

        private void Depurar()
        {
            MetodosAL.Identificadores.Clear();
            MetodosAL.ConstantesNumericasEnteras.Clear();
            MetodosAL.ConstantesNumericasReales.Clear();
            MetodosAL.ConstantesNumericasExponenciales.Clear();
            MetodosAL.ConstantesNumericasExpReales.Clear();
        }

        private void MostrarIdentificadoresConstantes()
        {
            dgvIDE.Rows.Clear();
            dgvConstatesNumericas.Rows.Clear();
            dgvConstantesExpo.Rows.Clear();
            foreach (Identificador IDE in MetodosAL.Identificadores)
                dgvIDE.Rows.Add("ID" + IDE.Index, IDE.Nombre, IDE.Tipo, "");
            foreach (NumericoEntero Num in MetodosAL.ConstantesNumericasEnteras)
                dgvConstatesNumericas.Rows.Add("CNE" + Num.Index, Num.Contenido);
            foreach (NumericoReal Real in MetodosAL.ConstantesNumericasReales)
                dgvConstatesNumericas.Rows.Add("CNR" + Real.Index, Real.Contenido);
            foreach (NumericoExponencial expo in MetodosAL.ConstantesNumericasExponenciales)
                dgvConstantesExpo.Rows.Add("CNEE" + expo.Index, expo.Contenido, expo.Exponencial);
            foreach (NumericoExpReal exporeal in MetodosAL.ConstantesNumericasExpReales)
                dgvConstantesExpo.Rows.Add("CNRE" + exporeal.Index, exporeal.Contenido, exporeal.Exponencial);
        }
        static int indx = 0;
        static int palabra = 0;
        static int intEstadoActual = 0;
        static int linea = 1;
        static List<char> caracteres = new List<char>();
        private void btnCaracterXCaracter_Click(object sender, EventArgs e)
        {
            try
            {
                string strEntrada = rtxtentrada.Text;
                if (indx == 0)
                {
                    Depurar();
                    rtxtcodigointermedio.Text = "";
                }
                strEntrada = strEntrada.Replace('\n', ' ');
                string[] strPalabras = strEntrada.Split(' ');
                strEntrada = rtxtentrada.Text;
                List<string> tokens = new List<string>();
                txtSubcadena.Text = strPalabras[palabra];//Mostrar la subcadena actual
                string palabraActual = strPalabras[palabra];
                bool bandera = false;
                if (strEntrada.Length > indx)
                {
                    char c = strEntrada[indx];
                    caracteres.Add(c);
                    if (c != '\n')
                    {
                        txtEstadoAnt.Text = intEstadoActual.ToString();
                        txtCaracter.Text = c.ToString();
                        txtnumrenglon.Text = linea.ToString();
                        intEstadoActual = MetodosAL.NuevoEstado(c, intEstadoActual, ref bandera);
                        if (bandera)
                        {
                            string tokn = MetodosAL.ObtenerToken(intEstadoActual, caracteres);
                            tokens.Add(tokn);
                            txttoken.Text = tokn;
                            foreach (string tkn in tokens) txtcadenatokens.Text += tkn + " "; //Muestro la cadena de tokens
                            intEstadoActual = 0;
                            palabra++; //Avanzo a la siguiente palabra
                            bandera = false;
                            caracteres.Clear();
                        }
                        txtEstadoActual.Text = intEstadoActual.ToString();
                    }
                    else
                    {
                        linea++;
                        CambiarEstado(' ', ref bandera, ref tokens);
                        palabra++;
                    }
                    indx++;
                }
                else
                {
                    CambiarEstado(' ', ref bandera, ref tokens);
                    indx = 0;
                    palabra = 0;
                    linea = 1;
                }
                MostrarIdentificadoresConstantes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + linea + ".\nVerifique el uso apropiado del léxico, y el caracter actual.", "Error de analizador léxico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void CambiarEstado(char c, ref bool bandera, ref List<string> tokens)
        {
            txtEstadoAnt.Text = intEstadoActual.ToString();
            intEstadoActual = MetodosAL.NuevoEstado(' ', intEstadoActual, ref bandera);
            txtEstadoActual.Text = intEstadoActual.ToString();
            string tokn = MetodosAL.ObtenerToken(intEstadoActual, caracteres);
            tokens.Add(tokn);
            txttoken.Text = tokn;
            foreach (string tkn in tokens) txtcadenatokens.Text += tkn + " "; //Muestro la cadena de tokens
            rtxtcodigointermedio.Text += txtcadenatokens.Text + "\n";
            txtcadenatokens.Text = "";
            caracteres.Clear();
            intEstadoActual = 0;
        }

        int intContadorPalabras = 0;
        int intCantidadPalabras = 0;
        int intLinea = 1;
        string[] strPalabras;

        private void Form1_Load(object sender, EventArgs e)
        {
            EstablecerConexion();
        }

        public void EstablecerConexion()
        {

            MessageBox.Show("Capture una instancia para la conexion", "Analizador lexico", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnCaracterxCarter.Enabled = false;
            btnleertodo.Enabled = false;
            lblServidor.Text = "Servidor: " + System.Environment.MachineName;

            txtServer.Focus();
        }

        public void CargarConexiones()
        {
            try
            {

                SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
                DataTable instancias = instance.GetDataSources();
                for (int i = 0; i < instancias.Rows.Count; i++)
                {

                    cmbServidores.Items.Add(instancias.Rows[i][1].ToString());
                }
            }
            catch
            {
                MessageBox.Show("Verifique el servicio SQL Browser \nEn SQL Server Configuration Manager", "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbServidores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMatriz.ProbarConexion(cmbServidores.SelectedItem.ToString()))
                {
                    MessageBox.Show("Conectado al servidor");
                    btnCaracterxCarter.Enabled = true;
                    btnleertodo.Enabled = true;
                    MetodosAL.Servidor = cmbServidores.SelectedItem.ToString();
                }
                else
                {
                    MessageBox.Show("Conexion fallida", "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnCaracterxCarter.Enabled = false;
                    btnleertodo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConexionMatriz.ProbarConexion(txtServer.Text))
                {
                    MessageBox.Show("Conectado al servidor");
                    btnCaracterxCarter.Enabled = true;
                    btnleertodo.Enabled = true;
                    MetodosAL.Servidor = txtServer.Text;

                }
                else
                {
                    MessageBox.Show("Conexion fallida", "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnCaracterxCarter.Enabled = false;
                    btnleertodo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string TrasformarAIden(string Tokens)
        {
            rtxtSalida.Text = "";
            string identificador = "";
            identificador = Tokens;
            identificador = identificador.Replace("ID", "~");
            string[] Contador = identificador.Split('~');
            for (int i = Contador.Length; i >= 0; i--)
            {
                identificador = identificador.Replace("~" + i, "IDEN");
            }

            identificador = identificador.Replace("CNE", "~");
            Contador = identificador.Split('~');
            for (int i = Contador.Length; i >= 0; i--)
            {
                identificador = identificador.Replace("~" + i, "CONU");
            }

            identificador = identificador.Replace("CNR", "~");
            Contador = identificador.Split('~');
            for (int i = Contador.Length; i >= 0; i--)
            {
                identificador = identificador.Replace("~" + i, "CONU");
            }

            rtxtIDEN.Text = identificador;
            identificador = "";
            for (int i = 0; i <= rtxtIDEN.Lines.Length - 2; i++)
            {
                identificador += rtxtIDEN.Lines[i].Substring(0, rtxtIDEN.Lines[i].Length - 1) + '\n';
            }
            return (identificador);
        }

        private void btnIden_Click(object sender, EventArgs e)
        {
            Stopwatch st2 = new Stopwatch();
            st2.Start();
            rtxtSalida.Text = "";
            string identificador = "";
            identificador = rtxtcodigointermedio.Text;
            identificador = identificador.Replace("ID", "~");
            string[] Contador = identificador.Split('~');
            for (int i = Contador.Length; i >= 0; i--)
            {
                identificador = identificador.Replace("~" + i, "IDEN");
            }

            identificador = identificador.Replace("CNE", "~");
            Contador = identificador.Split('~');
            for (int i = Contador.Length; i >= 0; i--)
            {
                identificador = identificador.Replace("~" + i, "CONU");
            }

            identificador = identificador.Replace("CNR", "~");
            Contador = identificador.Split('~');
            for (int i = Contador.Length; i >= 0; i--)
            {
                identificador = identificador.Replace("~" + i, "CONU");
            }

            rtxtIDEN.Text = identificador;
            identificador = "";
            for (int i = 0; i <= rtxtIDEN.Lines.Length - 2; i++)
            {
                identificador += rtxtIDEN.Lines[i].Substring(0, rtxtIDEN.Lines[i].Length - 1) + '\n';
            }
            rtxtIDEN.Text = identificador;
            st2.Stop();
            MessageBox.Show(st2.Elapsed.ToString() + " ms");
        }
        public void AnalizadorSintactico()
        {
            string auxLinea = "";
            string[] ATxt = new string[rtxtIDEN.Lines.Length];
            for (int i = 0; i <= rtxtIDEN.Lines.Length - 2; i++)
            {
                ATxt[i] = rtxtIDEN.Lines[i];
            }
            rtxtIDEN.Text = "";
            for (int i = 0; i <= ATxt.Length - 2; i++)
            {
                bool entro = false;
                auxLinea = ATxt[i];
                rtxtIDEN.Text += ATxt[i] + '\n';
                string[] Atokens = auxLinea.Split(' ');
                for (int j = 0; j <= Atokens.Length - 1; j++)
                {
                    string ext = Existe(Atokens[j]);
                    if (ext != "NoExiste")
                    {
                        ATxt[i] = ATxt[i].Replace(Atokens[j], ext);
                        Atokens = ATxt[i].Split(' ');
                        rtxtIDEN.Text += ATxt[i] + '\n';
                        j = -1;
                        entro = true;
                    }
                    else if (j <= Atokens.Length - 2 && entro == false)
                    {
                        ext = Existe(Atokens[j] + " " + Atokens[j + 1]);
                        if (ext != "NoExiste")
                        {
                            ATxt[i] = ATxt[i].Replace(Atokens[j] + " " + Atokens[j + 1], ext);
                            Atokens = ATxt[i].Split(' ');
                            j = -1;
                            entro = true;
                            rtxtIDEN.Text += ATxt[i] + '\n';
                        }
                    }
                    if (j <= Atokens.Length - 3 && entro == false)
                    {
                        ext = Existe(Atokens[j] + " " + Atokens[j + 1] + " " + Atokens[j + 2]);
                        if (ext != "NoExiste")
                        {
                            ATxt[i] = ATxt[i].Replace(Atokens[j] + " " + Atokens[j + 1] + " " + Atokens[j + 2], ext);
                            Atokens = ATxt[i].Split(' ');
                            j = -1;
                            rtxtIDEN.Text += ATxt[i] + '\n';
                        }
                    }
                    entro = false;
                }
                if (ExisteFinal(ATxt[i]))
                {
                    rtxtIDEN.Text += "S\n";
                    ATxt[i] = "S";
                }
                else
                {
                    rtxtIDEN.Text += "ERROR\n";
                    ATxt[i] = "ERROR";
                }
            }

            foreach (string sr in ATxt)
            {
                rtxtSalida.Text += sr + "\n";
            }
        }
        private void btnGramatica_Click(object sender, EventArgs e)
        {
            Stopwatch st3 = new Stopwatch();
            st3.Start();
            string auxLinea = "";
            string[] ATxt = new string[rtxtIDEN.Lines.Length];
            for (int i = 0; i <= rtxtIDEN.Lines.Length - 2; i++)
            {
                ATxt[i] = rtxtIDEN.Lines[i];
            }
            rtxtIDEN.Text = "";
            for (int i = 0; i <= ATxt.Length - 2; i++)
            {
                bool entro = false;
                auxLinea = ATxt[i];
                rtxtIDEN.Text += ATxt[i] + '\n';
                string[] Atokens = auxLinea.Split(' ');
                for (int j = 0; j <= Atokens.Length - 1; j++)
                {
                    string ext = Existe(Atokens[j]);
                    if (ext != "NoExiste")
                    {
                        ATxt[i] = ATxt[i].Replace(Atokens[j], ext);
                        Atokens = ATxt[i].Split(' ');
                        rtxtIDEN.Text += ATxt[i] + '\n';
                        j = -1;
                        entro = true;
                    }
                    else if(j <= Atokens.Length - 2 && entro == false)
                    {
                        ext = Existe(Atokens[j] + " " + Atokens[j + 1]);
                        if (ext != "NoExiste")
                        {
                            ATxt[i] = ATxt[i].Replace(Atokens[j] + " " + Atokens[j + 1], ext);
                            Atokens = ATxt[i].Split(' ');
                            j = -1;
                            entro = true;
                            rtxtIDEN.Text += ATxt[i] + '\n';
                        }
                    }
                    if (j <= Atokens.Length - 3 && entro == false)
                    {
                        ext = Existe(Atokens[j] + " " + Atokens[j + 1] + " " + Atokens[j + 2]);
                        if (ext != "NoExiste")
                        {
                            ATxt[i] = ATxt[i].Replace(Atokens[j] + " " + Atokens[j + 1] + " " + Atokens[j + 2], ext);
                            Atokens = ATxt[i].Split(' ');
                            j = -1;
                            rtxtIDEN.Text += ATxt[i] + '\n';
                        }
                    }
                    entro = false;
                }
                if(ExisteFinal(ATxt[i]))
                {
                    rtxtIDEN.Text += "S\n";
                    ATxt[i] = "S";
                }
                else
                {
                    rtxtIDEN.Text += "ERROR\n";
                    ATxt[i] = "ERROR";
                }
            }

            foreach(string sr in ATxt)
            {
                rtxtSalida.Text += sr + "\n";
            }
            st3.Stop();
            MessageBox.Show(st3.Elapsed.ToString() + " ms ");
            

        }
        public string Existe(string s)
        {
            for(int i = 0; i <= DT.Rows.Count - 1;  i++)
            {
                if(DT.Rows[i][1].ToString() == s)
                {
                    return DT.Rows[i][0].ToString();
                }
            }
            return "NoExiste";
        }

        public bool ExisteFinal(string s)
        {
            for (int i = 0; i <= DT2.Rows.Count - 1; i++)
            {
                if (DT2.Rows[i][1].ToString() == s)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            rtxtcodigointermedio.Text = "";
            rtxtIDEN.Text = "";
            rtxtSalida.Text = "";
            rchtxtSementica.Text = "";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            eval = new JerarquiaConversor();
            if (rtxtentrada.Text != " ")
            {
                string aux = rtxtentrada.Text;
                MessageBox.Show(aux);
                MessageBox.Show(eval.convertir_pos(aux).ToString());
            }
        }
    }
}
