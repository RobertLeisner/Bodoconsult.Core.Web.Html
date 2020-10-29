using System.Collections.Generic;
using System.Linq;

namespace Bodoconsult.Core.Web.Html.HtmlTables
{
    public class TableRow : BaseElement<Table>
    {

        public TableRow(Table parent): base(parent)
        {
            parent.Rows.Add(this);
            Cells = new List<ITableCell>();
        }

        public IList<ITableCell> Cells { get; set; }

        /// <summary>
        /// Render element into an html string
        /// </summary>
        /// <returns>html string</returns>
        public override string RenderIt()
        {
            var what = (Cells.Any(x => x.GetType() == typeof(TableHeaderCell))) ? "tr-header" : "tr-body";
            var content = Cells.Aggregate("", (current, cell) => current + cell.RenderIt());
            var erg = string.Format("\t\t<tr{0}>\r\n{1}\t\t</tr>\r\n", RenderAttributes(Parent, what), content);
            return erg;
        }


    }
}