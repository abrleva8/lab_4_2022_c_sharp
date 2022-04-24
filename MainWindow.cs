using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace lab_4 {
    public partial class MainWindow : Form {
        public MainWindow() {
            InitializeComponent();
            InitializeConnection();
        }

        public void InitializeConnection() {
            SQLiteConnection sqLiteConnection = new SQLiteConnection("data source=bank.db");

            string query = "SELECT* from accounts";
            SQLiteCommand cmd = new SQLiteCommand(query, sqLiteConnection);

            DataTable dataTable = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dataTable);

            dataGridView_dataBase.DataSource = dataTable;
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            EditWindow editWindow = new EditWindow();
            editWindow.ShowDialog();
            InitializeConnection();
        }
    }
}
