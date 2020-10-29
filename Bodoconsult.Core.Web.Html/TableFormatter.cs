using System;
using System.Data;
using System.Globalization;
using Bodoconsult.Core.Web.Html.HtmlTables;

namespace Bodoconsult.Core.Web.Html
{
    public static class TableFormatter
    {

        static TableFormatter()
        {
            Culture = new CultureInfo("en-us");
        }


        public static CultureInfo Culture { get; set; }


        public static string FormatAsCsv(DataTable dataTable, bool header)
        {
            var erg = "";

            if (header)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    erg += column.ColumnName + ";";
                }

                //if (erg.EndsWith(";")) erg = erg.Substring(0, erg.Length - 1);

                erg += "\r\n";
            }



            foreach (DataRow row in dataTable.Rows)
            {

                var rowdata = "";

                foreach (DataColumn column in dataTable.Columns)
                {
                    rowdata += FormattedValue(column.DataType.Name.ToLower(), row[column.ColumnName].ToString()) + ";";
                }

                //if (rowdata.EndsWith(";")) rowdata = rowdata.Substring(0, rowdata.Length - 1);

                erg += rowdata + "\r\n";
            }


            return erg;
        }

        public static string FormatAsHtml(DataTable dataTable, bool header, Stylesheet style)
        {
            var table= new Table();

            if (style != null)
            {
                table.Stylesheet = style;
            }


            if (header)
            {

                var headerRow = new TableRow(table);

                foreach (DataColumn column in dataTable.Columns)
                {
                    // ReSharper disable once ObjectCreationAsStatement
                    new TableHeaderCell(headerRow) { Text = column.ColumnName };
                }
            }



            foreach (DataRow row in dataTable.Rows)
            {
                var tableRow = new TableRow(table);

                foreach (DataColumn column in dataTable.Columns)
                {
                    // ReSharper disable once ObjectCreationAsStatement
                    new TableCell(tableRow) { Text = row[column.ColumnName].ToString() };
                }
            }


            return table.RenderIt();
        }


        public static string FormatAsHtml(DataTable dataTable, bool header)
        {
            return FormatAsHtml(dataTable, header, null);
        }

        private static string FormattedValue(string type, string value)
        {

            switch (type)
            {
                case "double":
                case "real":
                case "float":
                case "decimal":
                    double number1;
                    double.TryParse(value, NumberStyles.Any, Culture, out number1);
                    return string.Format(Culture, "{0:0.000000000000}", number1);
                case "tinyint":
                case "smallint":
                case "int":
                case "int16":
                case "int32":
                case "int64":
                case "bigint":
                    long number2;
                    long.TryParse(value, NumberStyles.Any, Culture, out number2);
                    return string.Format(Culture, "{0}", number2);
                    break;
                case "smalldatetime":
                case "datetime":
                    DateTime date;
                    DateTime.TryParse(value, Culture, DateTimeStyles.AssumeUniversal, out date);
                    return string.Format(Culture, "{0:f}", date);
                default:
                    return value;
            }
        }
    }
}
