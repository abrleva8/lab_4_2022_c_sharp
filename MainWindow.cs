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
            GreetingWorker();
        }

        private void GreetingWorker() {
            bool isAgain = FileWorker.ReadStartMessageFile("check_box_info.txt"); ;

            AboutForm aboutForm = new AboutForm(isAgain);
            if (aboutForm.IsAgain) {
                aboutForm.ShowDialog();
            }
        }

        public void InitializeConnection() {
            SQLiteConnection sqLiteConnection = new SQLiteConnection("data source=bank.db");

            string query = "select* from accounts";
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
            
            int cellRowIndex = dataGridView_dataBase.CurrentCell.RowIndex;
            int key = Int32.Parse(dataGridView_dataBase.Rows[cellRowIndex].Cells[0].Value.ToString());

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show($"Do you want to delete the row with number {key}?",
                "Delete", buttons);
            if (result == DialogResult.Yes) {
                SQLiteConnection sqLiteConnection = new SQLiteConnection("data source=bank.db");
                sqLiteConnection.Open();

                string query = $"delete from accounts where number={key}";
                SQLiteCommand cmd = new SQLiteCommand(query, sqLiteConnection);
                cmd.ExecuteNonQuery();
                sqLiteConnection.Close();
                InitializeConnection();
                if (dataGridView_dataBase.RowCount == 0) {
                    buttonDelete.Enabled = false;
                    buttonEdit.Enabled = false;
                }
            }
        }

        private void dataGridView_dataBase_CellClick(object sender, DataGridViewCellEventArgs e) {
            buttonDelete.Enabled = true;
            buttonEdit.Enabled = true;
        }

        private void dataGridView_dataBase_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            if (dataGridView_dataBase.Rows.Count > 0) {
                dataGridView_dataBase.Rows[0].Selected = false;
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e) {
            int cellRowIndex = dataGridView_dataBase.CurrentCell.RowIndex;
            int number = Int32.Parse(dataGridView_dataBase.Rows[cellRowIndex].Cells[0].Value.ToString());
            string name = dataGridView_dataBase.Rows[cellRowIndex].Cells[1].Value.ToString();
            string surname = dataGridView_dataBase.Rows[cellRowIndex].Cells[2].Value.ToString();
            string country = dataGridView_dataBase.Rows[cellRowIndex].Cells[3].Value.ToString();
            decimal money = Decimal.Parse(dataGridView_dataBase.Rows[cellRowIndex].Cells[4].Value.ToString());
            string currency = dataGridView_dataBase.Rows[cellRowIndex].Cells[5].Value.ToString();
            Account account = new Account(number, name, surname, country, money, currency);
            EditWindow editWindow = new EditWindow(account);
            editWindow.ShowDialog();
            InitializeConnection();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutForm aboutForm = new AboutForm(true);
            aboutForm.ShowDialog();
        }
    }
}
