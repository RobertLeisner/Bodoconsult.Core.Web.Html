namespace Bodoconsult.Core.Web.Html.HtmlTables
{
    public class TableHeaderCell : BaseElement<TableRow>, ITableCell
    {

        public TableHeaderCell(TableRow parent): base(parent)
        {
            parent.Cells.Add(this);
        }

        public string Text { get; set; }

        public override string RenderIt()
        {
            var content = Text;
            var erg = string.Format("\t\t\t<th{0}>\r\n\t\t\t\t{1}\r\n\t\t\t</th>\r\n", RenderAttributes(Parent.Parent, "th"), content);
            return erg;
        }
    }
}