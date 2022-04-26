using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_4 {
    public partial class EditWindow : Form {

        public EditWindow() {
            InitializeComponent();
        }

        public EditWindow(Account account) {
            InitializeComponent();
            this.numericUpDownNumber.Value = account.Number;
            this.textBoxName.Text = account.Name;
            this.textBoxSurname.Text = account.Surname;
            this.comboBoxCountry.Text = account.Country;
            this.numericUpDownMoney.Value = account.Money;
            this.comboBoxCurrency.Text = account.Currency;
        }

        private void button_OK_Click(object sender, EventArgs e) {
            int number = (int) this.numericUpDownNumber.Value;
            string name = this.textBoxName.Text;
            string surname = this.textBoxSurname.Text;
            string country = this.comboBoxCountry.Text;
            decimal money = this.numericUpDownMoney.Value;
            string currency = this.comboBoxCurrency.Text;
            //Account account = new Account(number, name, surname, country, money, currency);

            SQLiteConnection sqLiteConnection = new SQLiteConnection("data source=bank.db");
            sqLiteConnection.Open();
            string query = $"SELECT number FROM accounts WHERE number = {number}";


            SQLiteCommand cmd = new SQLiteCommand(query, sqLiteConnection);
            DataTable dataTable = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0) {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Do you want to edit the row?",
                    "Exit", buttons);
                if (result == DialogResult.Yes) {
                    string addAccount = $"update accounts set number={number}, name = '{name}', surname = '{surname}'," +
                                        $"country = '{country}', money = {money}, currency = '{currency}' where number = {number}";
                    SQLiteCommand sqLiteCommand = new SQLiteCommand(addAccount, sqLiteConnection);
                    sqLiteCommand.ExecuteNonQuery();
                    MessageBox.Show("The row was edited!", "Edit", MessageBoxButtons.OK);
                }
            } else {
                string addAccount = "insert into accounts (number,name,surname,country,money,currency)" +
                                    $"values ({number}, '{name}', '{surname}', '{country}', {money}, '{currency}');";
                SQLiteCommand sqLiteCommand = new SQLiteCommand(addAccount, sqLiteConnection);
                sqLiteCommand.ExecuteNonQuery();
                MessageBox.Show("The row was added!", "Add", MessageBoxButtons.OK);
            }

            sqLiteConnection.Close();
            this.Close();
            
        }
    }
}
