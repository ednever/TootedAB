namespace TootedAB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Toode_txt = new System.Windows.Forms.TextBox();
            this.Hind_lbl = new System.Windows.Forms.Label();
            this.Kogus_lbl = new System.Windows.Forms.Label();
            this.Toode_lbl = new System.Windows.Forms.Label();
            this.Kat_cbox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Toode_pbox = new System.Windows.Forms.PictureBox();
            this.Vali_btn = new System.Windows.Forms.Button();
            this.Lisa_btn = new System.Windows.Forms.Button();
            this.Uuenda_btn = new System.Windows.Forms.Button();
            this.Kustuta_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lisa_kat = new System.Windows.Forms.Button();
            this.Kogus_nud = new System.Windows.Forms.NumericUpDown();
            this.Hind_nud = new System.Windows.Forms.NumericUpDown();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Kustuta_kat_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Toode_pbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kogus_nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hind_nud)).BeginInit();
            this.SuspendLayout();
            // 
            // Toode_txt
            // 
            this.Toode_txt.Font = new System.Drawing.Font("Miriam Mono CLM", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Toode_txt.Location = new System.Drawing.Point(165, 12);
            this.Toode_txt.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Toode_txt.Name = "Toode_txt";
            this.Toode_txt.Size = new System.Drawing.Size(143, 30);
            this.Toode_txt.TabIndex = 0;
            // 
            // Hind_lbl
            // 
            this.Hind_lbl.AutoSize = true;
            this.Hind_lbl.Font = new System.Drawing.Font("Miriam Mono CLM", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Hind_lbl.Location = new System.Drawing.Point(99, 92);
            this.Hind_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Hind_lbl.Name = "Hind_lbl";
            this.Hind_lbl.Size = new System.Drawing.Size(54, 21);
            this.Hind_lbl.TabIndex = 5;
            this.Hind_lbl.Text = "Hind";
            // 
            // Kogus_lbl
            // 
            this.Kogus_lbl.AutoSize = true;
            this.Kogus_lbl.Font = new System.Drawing.Font("Miriam Mono CLM", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Kogus_lbl.Location = new System.Drawing.Point(88, 50);
            this.Kogus_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Kogus_lbl.Name = "Kogus_lbl";
            this.Kogus_lbl.Size = new System.Drawing.Size(65, 21);
            this.Kogus_lbl.TabIndex = 6;
            this.Kogus_lbl.Text = "Kogus";
            // 
            // Toode_lbl
            // 
            this.Toode_lbl.AutoSize = true;
            this.Toode_lbl.Font = new System.Drawing.Font("Miriam Mono CLM", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Toode_lbl.Location = new System.Drawing.Point(0, 15);
            this.Toode_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Toode_lbl.Name = "Toode_lbl";
            this.Toode_lbl.Size = new System.Drawing.Size(153, 21);
            this.Toode_lbl.TabIndex = 7;
            this.Toode_lbl.Text = "Toode nimetus";
            // 
            // Kat_cbox
            // 
            this.Kat_cbox.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Kat_cbox.FormattingEnabled = true;
            this.Kat_cbox.Location = new System.Drawing.Point(165, 130);
            this.Kat_cbox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Kat_cbox.Name = "Kat_cbox";
            this.Kat_cbox.Size = new System.Drawing.Size(143, 24);
            this.Kat_cbox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Miriam Mono CLM", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(33, 133);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Kategooria";
            // 
            // Toode_pbox
            // 
            this.Toode_pbox.Location = new System.Drawing.Point(320, 12);
            this.Toode_pbox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Toode_pbox.Name = "Toode_pbox";
            this.Toode_pbox.Size = new System.Drawing.Size(304, 220);
            this.Toode_pbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Toode_pbox.TabIndex = 10;
            this.Toode_pbox.TabStop = false;
            // 
            // Vali_btn
            // 
            this.Vali_btn.Font = new System.Drawing.Font("Miriam Mono CLM", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Vali_btn.Location = new System.Drawing.Point(320, 242);
            this.Vali_btn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Vali_btn.Name = "Vali_btn";
            this.Vali_btn.Size = new System.Drawing.Size(146, 50);
            this.Vali_btn.TabIndex = 11;
            this.Vali_btn.Text = "Vali fail";
            this.Vali_btn.UseVisualStyleBackColor = true;
            this.Vali_btn.Click += new System.EventHandler(this.Vali_btn_Click);
            // 
            // Lisa_btn
            // 
            this.Lisa_btn.Font = new System.Drawing.Font("Miriam Mono CLM", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Lisa_btn.Location = new System.Drawing.Point(162, 182);
            this.Lisa_btn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Lisa_btn.Name = "Lisa_btn";
            this.Lisa_btn.Size = new System.Drawing.Size(146, 50);
            this.Lisa_btn.TabIndex = 12;
            this.Lisa_btn.Text = "Lisa";
            this.Lisa_btn.UseVisualStyleBackColor = true;
            this.Lisa_btn.Click += new System.EventHandler(this.Lisa_btn_Click);
            // 
            // Uuenda_btn
            // 
            this.Uuenda_btn.Font = new System.Drawing.Font("Miriam Mono CLM", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Uuenda_btn.Location = new System.Drawing.Point(478, 242);
            this.Uuenda_btn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Uuenda_btn.Name = "Uuenda_btn";
            this.Uuenda_btn.Size = new System.Drawing.Size(146, 50);
            this.Uuenda_btn.TabIndex = 13;
            this.Uuenda_btn.Text = "Uuenda";
            this.Uuenda_btn.UseVisualStyleBackColor = true;
            this.Uuenda_btn.Click += new System.EventHandler(this.Uuenda_btn_Click);
            // 
            // Kustuta_btn
            // 
            this.Kustuta_btn.Font = new System.Drawing.Font("Miriam Mono CLM", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Kustuta_btn.Location = new System.Drawing.Point(162, 242);
            this.Kustuta_btn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Kustuta_btn.Name = "Kustuta_btn";
            this.Kustuta_btn.Size = new System.Drawing.Size(146, 50);
            this.Kustuta_btn.TabIndex = 14;
            this.Kustuta_btn.Text = "Kustuta";
            this.Kustuta_btn.UseVisualStyleBackColor = true;
            this.Kustuta_btn.Click += new System.EventHandler(this.Kustuta_btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 298);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(620, 185);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // lisa_kat
            // 
            this.lisa_kat.Font = new System.Drawing.Font("Miriam Mono CLM", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lisa_kat.Location = new System.Drawing.Point(4, 182);
            this.lisa_kat.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.lisa_kat.Name = "lisa_kat";
            this.lisa_kat.Size = new System.Drawing.Size(146, 50);
            this.lisa_kat.TabIndex = 16;
            this.lisa_kat.Text = "Lisa kategooria";
            this.lisa_kat.UseVisualStyleBackColor = true;
            this.lisa_kat.Click += new System.EventHandler(this.lisa_kat_Click);
            // 
            // Kogus_nud
            // 
            this.Kogus_nud.Font = new System.Drawing.Font("Miriam Mono CLM", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Kogus_nud.Location = new System.Drawing.Point(165, 50);
            this.Kogus_nud.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Kogus_nud.Name = "Kogus_nud";
            this.Kogus_nud.Size = new System.Drawing.Size(143, 30);
            this.Kogus_nud.TabIndex = 17;
            // 
            // Hind_nud
            // 
            this.Hind_nud.DecimalPlaces = 2;
            this.Hind_nud.Font = new System.Drawing.Font("Miriam Mono CLM", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Hind_nud.Location = new System.Drawing.Point(165, 90);
            this.Hind_nud.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Hind_nud.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Hind_nud.Name = "Hind_nud";
            this.Hind_nud.Size = new System.Drawing.Size(143, 30);
            this.Hind_nud.TabIndex = 18;
            // 
            // Kustuta_kat_btn
            // 
            this.Kustuta_kat_btn.Font = new System.Drawing.Font("Miriam Mono CLM", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Kustuta_kat_btn.Location = new System.Drawing.Point(4, 240);
            this.Kustuta_kat_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Kustuta_kat_btn.Name = "Kustuta_kat_btn";
            this.Kustuta_kat_btn.Size = new System.Drawing.Size(146, 50);
            this.Kustuta_kat_btn.TabIndex = 19;
            this.Kustuta_kat_btn.Text = "Kustuta kategooria";
            this.Kustuta_kat_btn.UseVisualStyleBackColor = true;
            this.Kustuta_kat_btn.Click += new System.EventHandler(this.Kustuta_kat_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 487);
            this.Controls.Add(this.Kustuta_kat_btn);
            this.Controls.Add(this.Hind_nud);
            this.Controls.Add(this.Kogus_nud);
            this.Controls.Add(this.lisa_kat);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Kustuta_btn);
            this.Controls.Add(this.Uuenda_btn);
            this.Controls.Add(this.Lisa_btn);
            this.Controls.Add(this.Vali_btn);
            this.Controls.Add(this.Toode_pbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Kat_cbox);
            this.Controls.Add(this.Toode_lbl);
            this.Controls.Add(this.Kogus_lbl);
            this.Controls.Add(this.Hind_lbl);
            this.Controls.Add(this.Toode_txt);
            this.Font = new System.Drawing.Font("Miriam Mono CLM", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form1";
            this.Text = "Tooded";
            ((System.ComponentModel.ISupportInitialize)(this.Toode_pbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kogus_nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hind_nud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Toode_txt;
        private System.Windows.Forms.Label Hind_lbl;
        private System.Windows.Forms.Label Kogus_lbl;
        private System.Windows.Forms.Label Toode_lbl;
        private System.Windows.Forms.ComboBox Kat_cbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Toode_pbox;
        private System.Windows.Forms.Button Vali_btn;
        private System.Windows.Forms.Button Lisa_btn;
        private System.Windows.Forms.Button Uuenda_btn;
        private System.Windows.Forms.Button Kustuta_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button lisa_kat;
        private System.Windows.Forms.NumericUpDown Kogus_nud;
        private System.Windows.Forms.NumericUpDown Hind_nud;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button Kustuta_kat_btn;
    }
}

