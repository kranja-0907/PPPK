using PPPK.DAL;
using PPPK.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPPK
{
    public partial class MainForm : Form
    {
        private const string FileFilter = "XML files(*.xml)|*.xml|All files(*.*)|*.*";
        private const string FileName = "{0}.xml";
        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init() => LoadDatabases();

        private void LoadDatabases()
            => CbDatabases.DataSource = new List<Database>(RepositoryFactory.GetRepository().GetDatabases());

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
            => Application.Exit();

        private void CbDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear();
            LbTables.DataSource = (CbDatabases.SelectedItem as Database).Tables;
            LbViews.DataSource = (CbDatabases.SelectedItem as Database).Views;
            LbProcedures.DataSource = (CbDatabases.SelectedItem as Database).Procedures;
        }

        private void Clear()
        {
            LbTableColums.DataSource = null;
            LbViewColumns.DataSource = null;
            TbProcedure.Text = string.Empty;
            LbParams.DataSource = null;
        }

        private void LbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            LbTableColums.DataSource = (LbTables.SelectedItem as DBEntity).Columns;
        }

        private void LbViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            LbViewColumns.DataSource = (LbViews.SelectedItem as DBEntity).Columns;
        }

        private void LbProcedures_SelectedIndexChanged(object sender, EventArgs e)
        {
            TbProcedure.Text = (LbProcedures.SelectedItem as Procedure).Definition;
            LbParams.DataSource = (LbProcedures.SelectedItem as Procedure).Parameters;
        }

        private void BtnXmlClick(object sender, EventArgs e)
        {
            DBEntity entity = null;
            switch ((sender as Button).Name)
            {
                case nameof(BtnXmlTable):
                    entity = LbTables.SelectedItem as DBEntity;
                    break;
                case nameof(BtnXmlView):
                    entity = LbViews.SelectedItem as DBEntity;
                    break;
            }

            var dialog = new SaveFileDialog
            {
                FileName = string.Format(FileName, entity.Name),
                Filter = FileFilter
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DataSet ds = RepositoryFactory.GetRepository().CreateDataSet(entity);
                ds.WriteXml(dialog.FileName, XmlWriteMode.WriteSchema);
            }

        }

        private void BtnSelectClick(object sender, EventArgs e)
        {
            DBEntity entity = null;
            switch ((sender as Button).Name)
            {
                case nameof(BtnSelectTable):
                    entity = LbTables.SelectedItem as DBEntity;
                    break;
                case nameof(BtnSelectView):
                    entity = LbViews.SelectedItem as DBEntity;
                    break;
            }

            DataSet ds = RepositoryFactory.GetRepository().CreateDataSet(entity);
            new SelectResultsForm(ds.Tables[0]).ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
            => Application.Exit();

        private void btnQuerries_Click(object sender, EventArgs e)
        {
            new QuerriesForm().Show();
            Hide();
        }
    }
}
