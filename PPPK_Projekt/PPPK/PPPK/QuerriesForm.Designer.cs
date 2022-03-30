
namespace PPPK
{
    partial class QuerriesForm
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
            this.tbQuerrie = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.cbDatabase = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flpResults = new System.Windows.Forms.FlowLayoutPanel();
            this.TabQuerrieResultMessage = new System.Windows.Forms.TabControl();
            this.tabMessage = new System.Windows.Forms.TabPage();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.tabPage1.SuspendLayout();
            this.TabQuerrieResultMessage.SuspendLayout();
            this.tabMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbQuerrie
            // 
            this.tbQuerrie.Location = new System.Drawing.Point(13, 95);
            this.tbQuerrie.Multiline = true;
            this.tbQuerrie.Name = "tbQuerrie";
            this.tbQuerrie.Size = new System.Drawing.Size(755, 221);
            this.tbQuerrie.TabIndex = 1;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(649, 322);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(119, 45);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // cbDatabase
            // 
            this.cbDatabase.FormattingEnabled = true;
            this.cbDatabase.Location = new System.Drawing.Point(69, 55);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Size = new System.Drawing.Size(197, 21);
            this.cbDatabase.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Database";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flpResults);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(751, 252);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Results";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flpResults
            // 
            this.flpResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpResults.Location = new System.Drawing.Point(3, 3);
            this.flpResults.Name = "flpResults";
            this.flpResults.Size = new System.Drawing.Size(745, 246);
            this.flpResults.TabIndex = 0;
            // 
            // TabQuerrieResultMessage
            // 
            this.TabQuerrieResultMessage.Controls.Add(this.tabPage1);
            this.TabQuerrieResultMessage.Controls.Add(this.tabMessage);
            this.TabQuerrieResultMessage.Location = new System.Drawing.Point(13, 373);
            this.TabQuerrieResultMessage.Name = "TabQuerrieResultMessage";
            this.TabQuerrieResultMessage.SelectedIndex = 0;
            this.TabQuerrieResultMessage.Size = new System.Drawing.Size(759, 278);
            this.TabQuerrieResultMessage.TabIndex = 0;
            // 
            // tabMessage
            // 
            this.tabMessage.Controls.Add(this.tbMessage);
            this.tabMessage.Location = new System.Drawing.Point(4, 22);
            this.tabMessage.Name = "tabMessage";
            this.tabMessage.Padding = new System.Windows.Forms.Padding(3);
            this.tabMessage.Size = new System.Drawing.Size(751, 252);
            this.tabMessage.TabIndex = 3;
            this.tabMessage.Text = "Message";
            this.tabMessage.UseVisualStyleBackColor = true;
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(3, 0);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(742, 249);
            this.tbMessage.TabIndex = 0;
            // 
            // QuerriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 653);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDatabase);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.tbQuerrie);
            this.Controls.Add(this.TabQuerrieResultMessage);
            this.Name = "QuerriesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuerriesForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QuerriesForm_FormClosed);
            this.Load += new System.EventHandler(this.QuerriesForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QuerriesForm_KeyDown);
            this.tabPage1.ResumeLayout(false);
            this.TabQuerrieResultMessage.ResumeLayout(false);
            this.tabMessage.ResumeLayout(false);
            this.tabMessage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbQuerrie;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.ComboBox cbDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.FlowLayoutPanel flpResults;
        private System.Windows.Forms.TabControl TabQuerrieResultMessage;
        private System.Windows.Forms.TabPage tabMessage;
        private System.Windows.Forms.TextBox tbMessage;
    }
}