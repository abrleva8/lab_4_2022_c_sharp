using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4 {
    public class Account {
        public Account(int number, string name, string surname, string country,
            decimal money, string currency) {
            Number = number;
            Name = name;
            Surname = surname;
            Country = country;
            Money = money;
            Currency = currency;
        }

        public int Number { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public Decimal Money { get; set; }
        public string Currency { get; set; }
    }
}
