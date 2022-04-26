using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4 {
    class EditChecker {

        private bool IsNumber(int number) {
            return number > 0;
        }

        private bool IsName(string name) {
            return name.All(char.IsLetter);
        }

        private bool IsCountry(string country) {
            return country.Length > 0;
        }

        private bool IsCurrency(string currency) {
            return currency.Length > 0;
        }

        public bool IsGoodData(Account account) {
            return IsNumber(account.Number) && IsName(account.Name) && IsName(account.Surname)
                   && IsCountry(account.Country) && IsCurrency(account.Currency);
        }

        
    }
}
