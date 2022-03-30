using PPPK.DAL;
using PPPK.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPPK
{
    public partial class QuerriesForm : Form
    {
        private const int flpHeight = 246;
        private const int formHeight = 692;
        private const int tabHeight = 278;
        public QuerriesForm()
        {
            InitializeComponent();
            Init();
        }
        private void Init() => LoadDatabases();

        private void LoadDatabases()
            => cbDatabase.DataSource = new List<Database>(RepositoryFactory.GetRepository().GetDatabases());
        private void QuerriesForm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
        }
        private void QuerriesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt == true && e.KeyCode == Keys.X)
            {
                btnExecute.PerformClick();
            } 
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                string querry = tbQuerrie.Text.Trim();
                DataSet data = RepositoryFactory.GetRepository().CreateDataSetSQL($"Use {cbDatabase.SelectedItem} {querry}");
                Height = formHeight;
                TabQuerrieResultMessage.Height = tabHeight;
                flpResults.Height = flpHeight;
                tbMessage.Text = " ";
                flpResults.Controls.Clear();

                if (data.Tables.Count > 0)
                {
                    foreach (DataTable table in data.Tables)
                    {
                        DataGrid dataGrid = new DataGrid();
                        dataGrid.DataSource = table;
                        dataGrid.Width = flpResults.Width;

                        flpResults.Height += 30;
                        Height += 30;
                        TabQuerrieResultMessage.Height += 30;

                        flpResults.Controls.Add(dataGrid);
                        tbMessage.Text += $"\t(Commands completed successfully) {Environment.NewLine} \t({table.Rows.Count}  rows affected)"
                                       + $" {Environment.NewLine} \tCompletion time: {DateTime.Now} {Environment.NewLine}";
                    }
                    
                }
                else
                {
                    TabQuerrieResultMessage.SelectedIndex = 1;
                    tbMessage.Text = $"\t(Commands completed successfully) {Environment.NewLine}\tCompletion time: {DateTime.Now}";
                }
            }
            catch (Exception)
            {
                TabQuerrieResultMessage.SelectedIndex = 1;
                tbMessage.ForeColor = Color.Red;
                tbMessage.Text = $"\t(Naredba nije ispravna) {Environment.NewLine}\tCompletion time: {DateTime.Now}";
            }
        }

        private void QuerriesForm_FormClosed(object sender, FormClosedEventArgs e)
            => Application.Exit();

        private void QuerriesForm_FormClosing(object sender, FormClosingEventArgs e)
            => Application.Exit();


    }
}
