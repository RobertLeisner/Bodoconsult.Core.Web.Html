using System;
using System.Data;
using System.IO;
using System.Text;

namespace Bodoconsult.Core.Web.Html
{
    public class DataTableExport
    {

        public string CssTable; // { get; set; }
        public string CssTableHeader; // { get; set; }
        public string CssTableRow; // { get; set; }
        public string CssTableCell; // { get; set; }
        public string CssAlternatingRows; // { get; set; }


        private const string TableElement = "<table{0}>{1}</table>";
        private const string ThElement = "<th{0}>{1}</th>";
        private const string TrElement = "<tr{0}>{1}</tr>";
        private const string TdElement = "<td{0}>{1}</td>";

        private int _start;

        private string[] _formats;

        private readonly StringBuilder _content = new StringBuilder();

        public DataTable Data; // { get; set; }


        public void CreateTable()
        {
            CreateFormats();

            CreateHeader();

            CreateBody();
        }

        private void CreateFormats()
        {
            _formats = new string[Data.Columns.Count];

            var i = 0;

            

            foreach (DataColumn col in Data.Columns)
            {

                if (col.ColumnName.ToLower() == "cssstyle")
                {
                    _start = 1;
                    continue;
                }

                var t = col.DataType;

                switch (t.Name.ToLower().Replace("system.", ""))
                {
                    case "byte":
                    case "int":
                    case "int16":
                    case "int32":
                    case "int64":
                        _formats[i] = "#,##0";
                        break;
                    case "single":
                    case "double":
                    case "float":
                    case "decimal":
                        _formats[i] = "#,##0.00";
                        break;
                    default:
                        _formats[i] = "";
                        break;
                }

                i++;

                
            }
        }

        private void CreateBody()
        {

            var count = Data.Columns.Count;
            var alternating = false;
            var altCssTable = "";

            foreach (DataRow row in Data.Rows)
            {

                var r = "";
                
                var cssRow =    (string.IsNullOrEmpty(CssTableRow)) ? "" : string.Format(" class=\"{0}\"", CssTableRow);

                var cssTableCell = (_start == 1 && !string.IsNullOrEmpty(row[0].ToString()))
                                       ? row[0].ToString()
                                       : CssTableCell;

                if (_start == 1 && !string.IsNullOrEmpty(row[0].ToString()) && cssTableCell != altCssTable)
                {
                    alternating = true;
                }

                var cssCell = "";
                
                
                for (var j = _start; j < count; j++)
                {

                    var value = row[j].ToString();


                    var t = Data.Columns[j].DataType.Name.ToLower().Replace("system.", "");

                    if (string.IsNullOrEmpty(value))
                    {
                        value = "&nbsp;";
                        t = "string";
                    }

                    switch (t)
                    {
                        case "datetime":
                            cssCell = (string.IsNullOrEmpty(CssTableCell)) ? "" : string.Format(" class=\"{0}_center{1}\"", cssTableCell, ((alternating && cssTableCell == CssTableCell) ? CssAlternatingRows : ""));
                            value = Convert.ToDateTime(value).ToString(@"dd.MM.yyyy");
                            break;
                        case "decimal":
                        case "double":
                        case "single":
                            //column.Format.Alignment = ParagraphAlignment.Right;
                            value = Convert.ToDouble(value).ToString("#,##0.00");
                            cssCell = (string.IsNullOrEmpty(cssCell)) ? "" : string.Format(" class=\"{0}_right{1}\"", cssTableCell, ((alternating && cssTableCell == CssTableCell) ? CssAlternatingRows : ""));
                            break;
                        case "int":
                        case "int16":
                        case "int32":
                        case "int64":
                            //column.Format.Alignment = ParagraphAlignment.Right;
                            value = Convert.ToInt32(value).ToString(@"#,##0");
                            cssCell = (string.IsNullOrEmpty(CssTableCell)) ? "" : string.Format(" class=\"{0}_right{1}\"", cssTableCell, ((alternating && cssTableCell == CssTableCell) ? CssAlternatingRows : ""));
                            break;
                        default:
                            cssCell = (string.IsNullOrEmpty(CssTableCell)) ? "" : string.Format(" class=\"{0}{1}\"", cssTableCell, ((alternating && cssTableCell==CssTableCell) ? CssAlternatingRows : ""));
                            break;
                    }


                    r += string.Format(TdElement, cssCell, value);

                    
                }

                _content.AppendFormat(TrElement, cssRow, r);
                alternating = !alternating;
                altCssTable = cssTableCell;
            }
        }


        private void CreateHeader()
        {
            var css = (string.IsNullOrEmpty(CssTableHeader)) ? "" : string.Format(" class=\"{0}\"", CssTableHeader);

            var s = new StringBuilder();

            foreach (DataColumn col in Data.Columns)
            {
                if (col.ColumnName.ToLower() == "cssstyle")
                {
                    continue;
                }

                s.AppendFormat(ThElement, css, col.ColumnName);

                
            }

            _content.AppendFormat(TrElement, CssTableRow, s);
        }


        public string Result
        {
            get
            {

                var css = (string.IsNullOrEmpty(CssTable)) ? "" : string.Format(" class=\"{0}\"", CssTable);

                var erg = string.Format(TableElement, css, _content);


                return erg;

            }


        }


        public void SaveAsFile(string fileName)
        {

            var sw = new StreamWriter(fileName, false, Encoding.GetEncoding("utf-8"));
            sw.Write(Result);
            sw.Close();



        }
    }
}
