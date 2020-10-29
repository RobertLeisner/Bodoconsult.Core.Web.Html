namespace Bodoconsult.Core.Web.Html.HtmlTables
{
    public class TableCell : BaseElement<TableRow>, ITableCell
    {

        public TableCell(TableRow parent): base(parent)
        {
            parent.Cells.Add(this);
        }

        public string Text { get; set; }

        public override string RenderIt()
        {

            var content = Text;
            var erg = string.Format("\t\t\t<td{0}>\r\n\t\t\t\t{1}\r\n\t\t\t</td>\r\n", RenderAttributes(Parent.Parent, "td"), content);
            return erg;
        }


    }
}
