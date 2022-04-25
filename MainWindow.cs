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
using System.Linq.Expressions;

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

        private void buttonDelete_Click(object sender, EventArgs e) {
            int index = dataGridView_dataBase.CurrentCell.RowIndex;
            int key = Int32.Parse(dataGridView_dataBase.Rows[index].Cells[0].Value.ToString());

            SQLiteConnection sqLiteConnection = new SQLiteConnection("data source=bank.db");
            sqLiteConnection.Open();

            string query = $"delete from accounts where number={key}";
            SQLiteCommand cmd = new SQLiteCommand(query, sqLiteConnection);
            cmd.ExecuteNonQuery();
            sqLiteConnection.Close();
            InitializeConnection();
        }

        private void dataGridView_dataBase_CellClick(object sender, DataGridViewCellEventArgs e) {
            buttonDelete.Enabled = true;
        }
    }
}
