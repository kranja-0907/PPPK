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
    public partial class SelectResultsForm : Form
    {
        public SelectResultsForm(DataTable dataTable)
        {
            InitializeComponent();
            Text = dataTable.TableName;
            DgResults.DataSource = dataTable;
        }
    }
}
