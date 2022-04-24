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

        private void button_OK_Click(object sender, EventArgs e) {
            int number = (int) this.numericUpDownNumber.Value;
            string name = this.textBoxName.Text;
            string surname = this.textBoxSurname.Text;
            string country = this.comboBoxCountry.Text;
            decimal money = this.numericUpDownMoney.Value;
            string currency = this.comboBoxCurrency.Text;
            Account account = new Account(number, name, surname, country, money, currency);

            SQLiteConnection sqLiteConnection = new SQLiteConnection("data source=bank.db");
            sqLiteConnection.Open();
            string addAccount = "insert into accounts (number,name,surname,country,money,currency)" +
                                $"values ({number}, '{name}', '{surname}', '{country}', {money}, '{currency}');";

            SQLiteCommand sqLiteCommand = new SQLiteCommand(addAccount, sqLiteConnection);
            sqLiteCommand.ExecuteNonQuery();
            sqLiteConnection.Close();
            this.Close();
        }
    }
}
