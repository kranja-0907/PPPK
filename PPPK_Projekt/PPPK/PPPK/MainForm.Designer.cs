
namespace PPPK
{
    partial class MainForm
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
            this.BtnSelectView = new System.Windows.Forms.Button();
            this.BtnXmlView = new System.Windows.Forms.Button();
            this.BtnSelectTable = new System.Windows.Forms.Button();
            this.BtnXmlTable = new System.Windows.Forms.Button();
            this.TbProcedure = new System.Windows.Forms.TextBox();
            this.LbParams = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LbProcedures = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.LbViewColumns = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LbViews = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LbTableColums = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LbTables = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CbDatabases = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuerries = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnSelectView
            // 
            this.BtnSelectView.Location = new System.Drawing.Point(896, 275);
            this.BtnSelectView.Name = "BtnSelectView";
            this.BtnSelectView.Size = new System.Drawing.Size(67, 23);
            this.BtnSelectView.TabIndex = 43;
            this.BtnSelectView.Text = "Select";
            this.BtnSelectView.UseVisualStyleBackColor = true;
            this.BtnSelectView.Click += new System.EventHandler(this.BtnSelectClick);
            // 
            // BtnXmlView
            // 
            this.BtnXmlView.Location = new System.Drawing.Point(896, 233);
            this.BtnXmlView.Name = "BtnXmlView";
            this.BtnXmlView.Size = new System.Drawing.Size(67, 23);
            this.BtnXmlView.TabIndex = 42;
            this.BtnXmlView.Text = "XML";
            this.BtnXmlView.UseVisualStyleBackColor = true;
            this.BtnXmlView.Click += new System.EventHandler(this.BtnXmlClick);
            // 
            // BtnSelectTable
            // 
            this.BtnSelectTable.Location = new System.Drawing.Point(361, 275);
            this.BtnSelectTable.Name = "BtnSelectTable";
            this.BtnSelectTable.Size = new System.Drawing.Size(67, 23);
            this.BtnSelectTable.TabIndex = 41;
            this.BtnSelectTable.Text = "Select";
            this.BtnSelectTable.UseVisualStyleBackColor = true;
            this.BtnSelectTable.Click += new System.EventHandler(this.BtnSelectClick);
            // 
            // BtnXmlTable
            // 
            this.BtnXmlTable.Location = new System.Drawing.Point(361, 233);
            this.BtnXmlTable.Name = "BtnXmlTable";
            this.BtnXmlTable.Size = new System.Drawing.Size(67, 23);
            this.BtnXmlTable.TabIndex = 40;
            this.BtnXmlTable.Text = "XML";
            this.BtnXmlTable.UseVisualStyleBackColor = true;
            this.BtnXmlTable.Click += new System.EventHandler(this.BtnXmlClick);
            // 
            // TbProcedure
            // 
            this.TbProcedure.Location = new System.Drawing.Point(434, 369);
            this.TbProcedure.Multiline = true;
            this.TbProcedure.Name = "TbProcedure";
            this.TbProcedure.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbProcedure.Size = new System.Drawing.Size(455, 238);
            this.TbProcedure.TabIndex = 39;
            // 
            // LbParams
            // 
            this.LbParams.FormattingEnabled = true;
            this.LbParams.Location = new System.Drawing.Point(969, 369);
            this.LbParams.Name = "LbParams";
            this.LbParams.Size = new System.Drawing.Size(185, 238);
            this.LbParams.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(909, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Params";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(374, 369);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Definition";
            // 
            // LbProcedures
            // 
            this.LbProcedures.FormattingEnabled = true;
            this.LbProcedures.Location = new System.Drawing.Point(169, 369);
            this.LbProcedures.Name = "LbProcedures";
            this.LbProcedures.Size = new System.Drawing.Size(185, 238);
            this.LbProcedures.TabIndex = 35;
            this.LbProcedures.SelectedIndexChanged += new System.EventHandler(this.LbProcedures_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(90, 369);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Procedures";
            // 
            // LbViewColumns
            // 
            this.LbViewColumns.FormattingEnabled = true;
            this.LbViewColumns.Location = new System.Drawing.Point(969, 76);
            this.LbViewColumns.Name = "LbViewColumns";
            this.LbViewColumns.Size = new System.Drawing.Size(185, 238);
            this.LbViewColumns.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(909, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Columns";
            // 
            // LbViews
            // 
            this.LbViews.FormattingEnabled = true;
            this.LbViews.Location = new System.Drawing.Point(704, 76);
            this.LbViews.Name = "LbViews";
            this.LbViews.Size = new System.Drawing.Size(185, 238);
            this.LbViews.TabIndex = 31;
            this.LbViews.SelectedIndexChanged += new System.EventHandler(this.LbViews_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(644, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Views";
            // 
            // LbTableColums
            // 
            this.LbTableColums.FormattingEnabled = true;
            this.LbTableColums.Location = new System.Drawing.Point(434, 76);
            this.LbTableColums.Name = "LbTableColums";
            this.LbTableColums.Size = new System.Drawing.Size(185, 238);
            this.LbTableColums.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Columns";
            // 
            // LbTables
            // 
            this.LbTables.FormattingEnabled = true;
            this.LbTables.Location = new System.Drawing.Point(169, 76);
            this.LbTables.Name = "LbTables";
            this.LbTables.Size = new System.Drawing.Size(185, 238);
            this.LbTables.TabIndex = 27;
            this.LbTables.SelectedIndexChanged += new System.EventHandler(this.LbTables_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Tables";
            // 
            // CbDatabases
            // 
            this.CbDatabases.FormattingEnabled = true;
            this.CbDatabases.Location = new System.Drawing.Point(169, 26);
            this.CbDatabases.Name = "CbDatabases";
            this.CbDatabases.Size = new System.Drawing.Size(199, 21);
            this.CbDatabases.TabIndex = 25;
            this.CbDatabases.SelectedIndexChanged += new System.EventHandler(this.CbDatabases_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Databases";
            // 
            // btnQuerries
            // 
            this.btnQuerries.Location = new System.Drawing.Point(377, 11);
            this.btnQuerries.Name = "btnQuerries";
            this.btnQuerries.Size = new System.Drawing.Size(174, 49);
            this.btnQuerries.TabIndex = 44;
            this.btnQuerries.Text = "Write querries";
            this.btnQuerries.UseVisualStyleBackColor = true;
            this.btnQuerries.Click += new System.EventHandler(this.btnQuerries_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1362, 661);
            this.Controls.Add(this.btnQuerries);
            this.Controls.Add(this.BtnSelectView);
            this.Controls.Add(this.BtnXmlView);
            this.Controls.Add(this.BtnSelectTable);
            this.Controls.Add(this.BtnXmlTable);
            this.Controls.Add(this.TbProcedure);
            this.Controls.Add(this.LbParams);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LbProcedures);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.LbViewColumns);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LbViews);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LbTableColums);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LbTables);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CbDatabases);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSelectView;
        private System.Windows.Forms.Button BtnXmlView;
        private System.Windows.Forms.Button BtnSelectTable;
        private System.Windows.Forms.Button BtnXmlTable;
        private System.Windows.Forms.TextBox TbProcedure;
        private System.Windows.Forms.ListBox LbParams;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox LbProcedures;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox LbViewColumns;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox LbViews;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox LbTableColums;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox LbTables;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbDatabases;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuerries;
    }
}