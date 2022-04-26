using System;
using System.IO;
using System.Windows.Forms;

namespace lab_4 {
    public class FileWorker {
        public static void ChangeStartMessageFile(bool IsAgain, string filename) {
            if (IsAgain) {
                using (StreamWriter file = new StreamWriter(filename, false)) {
                    file.WriteLine(1);
                }
            } else {
                using (StreamWriter file = new StreamWriter(filename, false)) {
                    file.WriteLine(0);
                }
            }
        }


        public static bool ReadStartMessageFile(string filename) {
            if (!File.Exists(filename)) {
                using (FileStream fs = File.Create(filename)) {
                    fs.WriteByte((byte)'0');
                }
            }
            int number = 0;
            using (StreamReader file = new StreamReader(filename)) {
                try {
                    number = int.Parse(file.ReadLine() ?? string.Empty);
                } catch (FormatException) {
                    return false;
                }
            }

            return number == 1;
        }


        public static void WriteDataGridToTxt(DataGridView dataGridView ,string filename, char sep=',') {
            using (var streamWriter = new StreamWriter(filename)) {

                foreach (DataGridViewColumn column in dataGridView.Columns) {
                    streamWriter.Write(column.HeaderText + sep);
                }
                streamWriter.WriteLine();

                foreach (DataGridViewRow row in dataGridView.Rows) {
                    foreach (DataGridViewCell cell in row.Cells) {
                        streamWriter.Write(cell.Value.ToString() + sep);
                    }
                    streamWriter.WriteLine();
                }
            }
        }
    }
}