using System;
using System.Data;

namespace lab_4 {
    public static class AssertDataTable {

        public static void AreEqual(DataTable expected, DataTable actual) {
            if (expected == null && actual == null) return;
            if (expected != null && actual != null) {
                if (expected.Columns.Count == actual.Columns.Count) {
                    for (int i = 0; i < expected.Columns.Count; i++) {
                        if (expected.Columns[i].DataType != actual.Columns[i].DataType) {
                            throw new Exception($"The type of of columns is not the same in both tables!" +
                                                $"Expected:{expected.Columns[i].DataType} Actual:{actual.Columns[i].DataType} for index {i}");
                        }
                    }
                    for (int i = 0; i < expected.Columns.Count; i++) {
                        if (expected.Columns[i].ColumnName != actual.Columns[i].ColumnName) {
                            throw new Exception($"Column names do not match! Expected:{expected.Columns[i].ColumnName} Actual:{actual.Columns[i].ColumnName} for index {i}");
                        }
                    }
                } else {
                    throw new Exception("Tables do not have the same number of columns");
                }

                if (expected.Rows.Count != actual.Rows.Count)
                    throw new Exception(
                        $"Rows count is not equal! Expected{expected.Rows.Count} Actual {actual.Rows.Count}");
                {
                    for (int i = 0; i < expected.Columns.Count; i++) {
                        for (int j = 0; j < expected.Rows.Count; j++) {
                            if (!expected.Rows[j][i].Equals(actual.Rows[j][i])) {
                                throw new Exception($"Cells are not equal! In Row {j} and Column {i}" +
                                                    $"Expected {expected.Rows[j][i]} Actual {actual.Rows[j][i]}");
                            }
                        }
                    }
                    return;
                }

            }

            if (expected == null) {
                throw new Exception("Expected table is null! But Actual table is not.");
            }

            if (actual == null) {
                throw new Exception("Actual table is null! But expected table is not.");
            }
        }
    }
}
