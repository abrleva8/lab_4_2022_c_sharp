using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace lab_4 {
    public partial class MainWindow : Form {
        public MainWindow() {
            InitializeComponent();
            InitializeConnection();
            GreetingWorker();
        }

        private static void GreetingWorker() {
            bool isAgain = FileWorker.ReadStartMessageFile("check_box_info.txt"); ;

            AboutForm aboutForm = new AboutForm(isAgain);
            if (aboutForm.IsAgain) {
                aboutForm.ShowDialog();
            }
        }

        public void InitializeConnection() {
            dataGridView_dataBase.DataSource = DataBaseWorker.GetAccountsTable();
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            EditWindow editWindow = new EditWindow();
            editWindow.ShowDialog();
            InitializeConnection();
        }

        private void buttonDelete_Click(object sender, EventArgs e) {
            
            int cellRowIndex = dataGridView_dataBase.CurrentCell.RowIndex;
            int key = int.Parse(dataGridView_dataBase.Rows[cellRowIndex].Cells[0].Value.ToString());

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show($"Do you want to delete the row with number {key}?",
                "Delete", buttons);
            if (result != DialogResult.Yes) return;
            DataBaseWorker.Delete(key);
            InitializeConnection();
            MessageBox.Show("The row was deleted!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dataGridView_dataBase.RowCount != 0) return;
            buttonDelete.Enabled = false;
            buttonEdit.Enabled = false;
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
            int number = int.Parse(dataGridView_dataBase.Rows[cellRowIndex].Cells[0].Value.ToString());
            string name = dataGridView_dataBase.Rows[cellRowIndex].Cells[1].Value.ToString();
            string surname = dataGridView_dataBase.Rows[cellRowIndex].Cells[2].Value.ToString();
            string country = dataGridView_dataBase.Rows[cellRowIndex].Cells[3].Value.ToString();
            decimal money = decimal.Parse(dataGridView_dataBase.Rows[cellRowIndex].Cells[4].Value.ToString());
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

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            const MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Are you sure do you want to exit?",
                "Exit", buttons);
            e.Cancel = result != DialogResult.Yes;
        }

        private void saveToTxtFileToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog() {
                InitialDirectory = @"D:\Documents\C#\lab_4\lab_4\lab_4\bin\Debug",
                Filter = @"Text files(*.txt) | *.txt | All files(*.*) | *.*"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                FileWorker.WriteDataGridToTxt(dataGridView_dataBase, saveFileDialog.FileName);
                MessageBox.Show("The file was saved!", "Saving!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                MessageBox.Show("The file was not saved!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
