namespace Analizador_Léxico
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEntrada = new System.Windows.Forms.Label();
            this.lblSubcadenaEvaluar = new System.Windows.Forms.Label();
            this.txtSubcadena = new System.Windows.Forms.TextBox();
            this.txtcadenatokens = new System.Windows.Forms.TextBox();
            this.lblcadenatokens = new System.Windows.Forms.Label();
            this.txtnumrenglon = new System.Windows.Forms.TextBox();
            this.lblnumrenglon = new System.Windows.Forms.Label();
            this.txttoken = new System.Windows.Forms.TextBox();
            this.lbltoken = new System.Windows.Forms.Label();
            this.rtxtcodigointermedio = new System.Windows.Forms.RichTextBox();
            this.btnleertodo = new System.Windows.Forms.Button();
            this.rtxtentrada = new System.Windows.Forms.RichTextBox();
            this.lblcodigointermedio = new System.Windows.Forms.Label();
            this.dgvIDE = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvConstatesNumericas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvConstantesExpo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCaracterxCarter = new System.Windows.Forms.Button();
            this.txtCaracter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEstadoActual = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEstadoAnt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbServidores = new System.Windows.Forms.ComboBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnConectar = new System.Windows.Forms.Button();
            this.lblServidor = new System.Windows.Forms.Label();
            this.rtxtSalida = new System.Windows.Forms.RichTextBox();
            this.btnGramatica = new System.Windows.Forms.Button();
            this.btnborrar = new System.Windows.Forms.Button();
            this.rchtxtSementica = new System.Windows.Forms.RichTextBox();
            this.btnIden = new System.Windows.Forms.Button();
            this.rtxtIDEN = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIDE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstatesNumericas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstantesExpo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEntrada
            // 
            this.lblEntrada.AutoSize = true;
            this.lblEntrada.Location = new System.Drawing.Point(12, 25);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(44, 13);
            this.lblEntrada.TabIndex = 0;
            this.lblEntrada.Text = "Entrada";
            // 
            // lblSubcadenaEvaluar
            // 
            this.lblSubcadenaEvaluar.AutoSize = true;
            this.lblSubcadenaEvaluar.Location = new System.Drawing.Point(9, 131);
            this.lblSubcadenaEvaluar.Name = "lblSubcadenaEvaluar";
            this.lblSubcadenaEvaluar.Size = new System.Drawing.Size(109, 13);
            this.lblSubcadenaEvaluar.TabIndex = 2;
            this.lblSubcadenaEvaluar.Text = "Subcadena a evaluar";
            // 
            // txtSubcadena
            // 
            this.txtSubcadena.Location = new System.Drawing.Point(11, 147);
            this.txtSubcadena.Name = "txtSubcadena";
            this.txtSubcadena.Size = new System.Drawing.Size(207, 20);
            this.txtSubcadena.TabIndex = 3;
            // 
            // txtcadenatokens
            // 
            this.txtcadenatokens.Location = new System.Drawing.Point(11, 186);
            this.txtcadenatokens.Name = "txtcadenatokens";
            this.txtcadenatokens.Size = new System.Drawing.Size(207, 20);
            this.txtcadenatokens.TabIndex = 5;
            // 
            // lblcadenatokens
            // 
            this.lblcadenatokens.AutoSize = true;
            this.lblcadenatokens.Location = new System.Drawing.Point(9, 170);
            this.lblcadenatokens.Name = "lblcadenatokens";
            this.lblcadenatokens.Size = new System.Drawing.Size(83, 13);
            this.lblcadenatokens.TabIndex = 4;
            this.lblcadenatokens.Text = "Cadena Tokens";
            // 
            // txtnumrenglon
            // 
            this.txtnumrenglon.Location = new System.Drawing.Point(44, 343);
            this.txtnumrenglon.Name = "txtnumrenglon";
            this.txtnumrenglon.Size = new System.Drawing.Size(138, 20);
            this.txtnumrenglon.TabIndex = 7;
            // 
            // lblnumrenglon
            // 
            this.lblnumrenglon.AutoSize = true;
            this.lblnumrenglon.Location = new System.Drawing.Point(8, 327);
            this.lblnumrenglon.Name = "lblnumrenglon";
            this.lblnumrenglon.Size = new System.Drawing.Size(67, 13);
            this.lblnumrenglon.TabIndex = 6;
            this.lblnumrenglon.Text = "# de renglon";
            // 
            // txttoken
            // 
            this.txttoken.Location = new System.Drawing.Point(44, 382);
            this.txttoken.Name = "txttoken";
            this.txttoken.Size = new System.Drawing.Size(138, 20);
            this.txttoken.TabIndex = 9;
            // 
            // lbltoken
            // 
            this.lbltoken.AutoSize = true;
            this.lbltoken.Location = new System.Drawing.Point(8, 366);
            this.lbltoken.Name = "lbltoken";
            this.lbltoken.Size = new System.Drawing.Size(38, 13);
            this.lbltoken.TabIndex = 8;
            this.lbltoken.Text = "Token";
            // 
            // rtxtcodigointermedio
            // 
            this.rtxtcodigointermedio.Location = new System.Drawing.Point(343, 91);
            this.rtxtcodigointermedio.Name = "rtxtcodigointermedio";
            this.rtxtcodigointermedio.Size = new System.Drawing.Size(173, 185);
            this.rtxtcodigointermedio.TabIndex = 10;
            this.rtxtcodigointermedio.Text = "";
            // 
            // btnleertodo
            // 
            this.btnleertodo.Location = new System.Drawing.Point(240, 97);
            this.btnleertodo.Name = "btnleertodo";
            this.btnleertodo.Size = new System.Drawing.Size(88, 20);
            this.btnleertodo.TabIndex = 12;
            this.btnleertodo.Text = "Leer Todo";
            this.btnleertodo.UseVisualStyleBackColor = true;
            this.btnleertodo.Click += new System.EventHandler(this.btnleertodo_Click);
            // 
            // rtxtentrada
            // 
            this.rtxtentrada.Location = new System.Drawing.Point(13, 51);
            this.rtxtentrada.Name = "rtxtentrada";
            this.rtxtentrada.Size = new System.Drawing.Size(207, 66);
            this.rtxtentrada.TabIndex = 13;
            this.rtxtentrada.Text = "";
            // 
            // lblcodigointermedio
            // 
            this.lblcodigointermedio.AutoSize = true;
            this.lblcodigointermedio.Location = new System.Drawing.Point(377, 72);
            this.lblcodigointermedio.Name = "lblcodigointermedio";
            this.lblcodigointermedio.Size = new System.Drawing.Size(92, 13);
            this.lblcodigointermedio.TabIndex = 14;
            this.lblcodigointermedio.Text = "Codigo Intermedio";
            // 
            // dgvIDE
            // 
            this.dgvIDE.AllowUserToAddRows = false;
            this.dgvIDE.AllowUserToDeleteRows = false;
            this.dgvIDE.AllowUserToResizeColumns = false;
            this.dgvIDE.AllowUserToResizeRows = false;
            this.dgvIDE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIDE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvIDE.Location = new System.Drawing.Point(284, 327);
            this.dgvIDE.Name = "dgvIDE";
            this.dgvIDE.RowHeadersVisible = false;
            this.dgvIDE.Size = new System.Drawing.Size(200, 163);
            this.dgvIDE.TabIndex = 15;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "No.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Nombre";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Tipo";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Cont.";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // dgvConstatesNumericas
            // 
            this.dgvConstatesNumericas.AllowUserToAddRows = false;
            this.dgvConstatesNumericas.AllowUserToDeleteRows = false;
            this.dgvConstatesNumericas.AllowUserToResizeColumns = false;
            this.dgvConstatesNumericas.AllowUserToResizeRows = false;
            this.dgvConstatesNumericas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConstatesNumericas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column5});
            this.dgvConstatesNumericas.Location = new System.Drawing.Point(509, 327);
            this.dgvConstatesNumericas.Name = "dgvConstatesNumericas";
            this.dgvConstatesNumericas.RowHeadersVisible = false;
            this.dgvConstatesNumericas.Size = new System.Drawing.Size(200, 163);
            this.dgvConstatesNumericas.TabIndex = 17;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "No.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Contenido";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(506, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Constantes Numericas";
            // 
            // dgvConstantesExpo
            // 
            this.dgvConstantesExpo.AllowUserToAddRows = false;
            this.dgvConstantesExpo.AllowUserToDeleteRows = false;
            this.dgvConstantesExpo.AllowUserToResizeColumns = false;
            this.dgvConstantesExpo.AllowUserToResizeRows = false;
            this.dgvConstantesExpo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConstantesExpo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn8,
            this.Column6});
            this.dgvConstantesExpo.Location = new System.Drawing.Point(731, 327);
            this.dgvConstantesExpo.Name = "dgvConstantesExpo";
            this.dgvConstantesExpo.RowHeadersVisible = false;
            this.dgvConstantesExpo.Size = new System.Drawing.Size(200, 163);
            this.dgvConstantesExpo.TabIndex = 19;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "No.";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.HeaderText = "Contenido";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "Exponente";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(728, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Constantes Exponenciales";
            // 
            // btnCaracterxCarter
            // 
            this.btnCaracterxCarter.Location = new System.Drawing.Point(240, 131);
            this.btnCaracterxCarter.Name = "btnCaracterxCarter";
            this.btnCaracterxCarter.Size = new System.Drawing.Size(88, 37);
            this.btnCaracterxCarter.TabIndex = 21;
            this.btnCaracterxCarter.Text = "Caracter por Caracter";
            this.btnCaracterxCarter.UseVisualStyleBackColor = true;
            this.btnCaracterxCarter.Click += new System.EventHandler(this.btnCaracterXCaracter_Click);
            // 
            // txtCaracter
            // 
            this.txtCaracter.Location = new System.Drawing.Point(12, 298);
            this.txtCaracter.Name = "txtCaracter";
            this.txtCaracter.Size = new System.Drawing.Size(77, 20);
            this.txtCaracter.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Caracter Actual";
            // 
            // txtEstadoActual
            // 
            this.txtEstadoActual.Location = new System.Drawing.Point(139, 252);
            this.txtEstadoActual.Name = "txtEstadoActual";
            this.txtEstadoActual.Size = new System.Drawing.Size(65, 20);
            this.txtEstadoActual.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(136, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Estado Actual";
            // 
            // txtEstadoAnt
            // 
            this.txtEstadoAnt.Location = new System.Drawing.Point(11, 252);
            this.txtEstadoAnt.Name = "txtEstadoAnt";
            this.txtEstadoAnt.Size = new System.Drawing.Size(76, 20);
            this.txtEstadoAnt.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Estado Anterior";
            // 
            // cmbServidores
            // 
            this.cmbServidores.FormattingEnabled = true;
            this.cmbServidores.Location = new System.Drawing.Point(62, 22);
            this.cmbServidores.Name = "cmbServidores";
            this.cmbServidores.Size = new System.Drawing.Size(138, 21);
            this.cmbServidores.TabIndex = 28;
            this.cmbServidores.Text = "Servidores";
            this.cmbServidores.Visible = false;
            this.cmbServidores.SelectedIndexChanged += new System.EventHandler(this.cmbServidores_SelectedIndexChanged);
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(293, 25);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(152, 20);
            this.txtServer.TabIndex = 29;
            this.txtServer.Text = "SQLEXPRESS";
            this.txtServer.TextChanged += new System.EventHandler(this.txtServer_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(237, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Instancia";
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(293, 51);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 31;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.Location = new System.Drawing.Point(297, 1);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(17, 13);
            this.lblServidor.TabIndex = 32;
            this.lblServidor.Text = "\"\"";
            // 
            // rtxtSalida
            // 
            this.rtxtSalida.Location = new System.Drawing.Point(549, 91);
            this.rtxtSalida.Name = "rtxtSalida";
            this.rtxtSalida.Size = new System.Drawing.Size(182, 185);
            this.rtxtSalida.TabIndex = 34;
            this.rtxtSalida.Text = "";
            // 
            // btnGramatica
            // 
            this.btnGramatica.Location = new System.Drawing.Point(600, 62);
            this.btnGramatica.Name = "btnGramatica";
            this.btnGramatica.Size = new System.Drawing.Size(75, 27);
            this.btnGramatica.TabIndex = 35;
            this.btnGramatica.Text = "Gramatica";
            this.btnGramatica.UseVisualStyleBackColor = true;
            this.btnGramatica.Click += new System.EventHandler(this.btnGramatica_Click);
            // 
            // btnborrar
            // 
            this.btnborrar.Location = new System.Drawing.Point(240, 186);
            this.btnborrar.Name = "btnborrar";
            this.btnborrar.Size = new System.Drawing.Size(87, 29);
            this.btnborrar.TabIndex = 38;
            this.btnborrar.Text = "Borrar esto >>>";
            this.btnborrar.UseVisualStyleBackColor = true;
            this.btnborrar.Click += new System.EventHandler(this.btnborrar_Click);
            // 
            // rchtxtSementica
            // 
            this.rchtxtSementica.Location = new System.Drawing.Point(766, 91);
            this.rchtxtSementica.Name = "rchtxtSementica";
            this.rchtxtSementica.Size = new System.Drawing.Size(182, 185);
            this.rchtxtSementica.TabIndex = 39;
            this.rchtxtSementica.Text = "";
            // 
            // btnIden
            // 
            this.btnIden.Location = new System.Drawing.Point(1044, 49);
            this.btnIden.Name = "btnIden";
            this.btnIden.Size = new System.Drawing.Size(64, 23);
            this.btnIden.TabIndex = 36;
            this.btnIden.Text = "IDEN";
            this.btnIden.UseVisualStyleBackColor = true;
            this.btnIden.Click += new System.EventHandler(this.btnIden_Click);
            // 
            // rtxtIDEN
            // 
            this.rtxtIDEN.Location = new System.Drawing.Point(993, 91);
            this.rtxtIDEN.Name = "rtxtIDEN";
            this.rtxtIDEN.Size = new System.Drawing.Size(171, 185);
            this.rtxtIDEN.TabIndex = 37;
            this.rtxtIDEN.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(239, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "Postfijo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 511);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rchtxtSementica);
            this.Controls.Add(this.btnborrar);
            this.Controls.Add(this.rtxtIDEN);
            this.Controls.Add(this.btnIden);
            this.Controls.Add(this.btnGramatica);
            this.Controls.Add(this.rtxtSalida);
            this.Controls.Add(this.lblServidor);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.cmbServidores);
            this.Controls.Add(this.txtEstadoAnt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEstadoActual);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCaracter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCaracterxCarter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvConstantesExpo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvConstatesNumericas);
            this.Controls.Add(this.dgvIDE);
            this.Controls.Add(this.lblcodigointermedio);
            this.Controls.Add(this.rtxtentrada);
            this.Controls.Add(this.btnleertodo);
            this.Controls.Add(this.rtxtcodigointermedio);
            this.Controls.Add(this.txttoken);
            this.Controls.Add(this.lbltoken);
            this.Controls.Add(this.txtnumrenglon);
            this.Controls.Add(this.lblnumrenglon);
            this.Controls.Add(this.txtcadenatokens);
            this.Controls.Add(this.lblcadenatokens);
            this.Controls.Add(this.txtSubcadena);
            this.Controls.Add(this.lblSubcadenaEvaluar);
            this.Controls.Add(this.lblEntrada);
            this.Name = "Form1";
            this.Text = "Analizador Léxico";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIDE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstatesNumericas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstantesExpo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEntrada;
        private System.Windows.Forms.Label lblSubcadenaEvaluar;
        private System.Windows.Forms.TextBox txtSubcadena;
        private System.Windows.Forms.TextBox txtcadenatokens;
        private System.Windows.Forms.Label lblcadenatokens;
        private System.Windows.Forms.TextBox txtnumrenglon;
        private System.Windows.Forms.Label lblnumrenglon;
        private System.Windows.Forms.TextBox txttoken;
        private System.Windows.Forms.Label lbltoken;
        private System.Windows.Forms.RichTextBox rtxtcodigointermedio;
        private System.Windows.Forms.Button btnleertodo;
        private System.Windows.Forms.RichTextBox rtxtentrada;
        private System.Windows.Forms.Label lblcodigointermedio;
       
        private System.Windows.Forms.Label label1;
        
        private System.Windows.Forms.Label lblChar;
        private System.Windows.Forms.DataGridView dgvIDE;
        
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridView dgvConstatesNumericas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvConstantesExpo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button btnCaracterxCarter;
        private System.Windows.Forms.TextBox txtCaracter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEstadoActual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEstadoAnt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbServidores;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.RichTextBox rtxtSalida;
        private System.Windows.Forms.Button btnGramatica;
        private System.Windows.Forms.Button btnborrar;
        private System.Windows.Forms.RichTextBox rchtxtSementica;
        private System.Windows.Forms.Button btnIden;
        private System.Windows.Forms.RichTextBox rtxtIDEN;
        private System.Windows.Forms.Button button1;
    }
}

