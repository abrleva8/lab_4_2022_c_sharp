using System;
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
            Account account = new Account(number, name, surname, country, money, currency);
            bool isExists = DataBaseWorker.IsExists(number);

            if (isExists) {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Do you want to edit the row?",
                    "Exit", buttons);
                if (result == DialogResult.Yes) {
                    DataBaseWorker.Edit(account);
                    MessageBox.Show("The row was edited!", "Edit", MessageBoxButtons.OK);
                }
            } else {
                DataBaseWorker.Add(account);
                MessageBox.Show("The row was added!", "Add", MessageBoxButtons.OK);
            }

            this.Close();
            
        }
    }
}
