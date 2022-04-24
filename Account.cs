using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4 {
    internal class Account {
        public Account(int number, string name, string surname, string country,
            decimal money, string currency) {
            Number = number;
            Name = name;
            Surname = surname;
            Country = country;
            Money = money;
            Currency = currency;
        }

        private int Number { get; set; }
        private string Name { get; set; }
        private string Surname { get; set; }
        private string Country { get; set; }
        private Decimal Money { get; set; }
        private string Currency { get; set; }
    }
}
