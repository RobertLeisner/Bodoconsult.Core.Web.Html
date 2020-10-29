using System.Collections.Generic;
using System.Linq;

namespace Bodoconsult.Core.Web.Html.HtmlTables
{
    public class Table : BaseElement<RootElement>
    {

        public Table(): base(null)
        {
            Rows = new List<TableRow>();
        }


        public IList<TableRow> Rows { get; set; }


        /// <summary>
        /// Stylesheet for formatting 
        /// </summary>
        public IStylesheet Stylesheet { get; set; }


        /// <summary>
        /// Render element into an html string
        /// </summary>
        /// <returns>html string</returns>
        public override string RenderIt()
        {
            var type = typeof(TableHeaderCell);

            var content = "";
            var content1 = Rows.Where(x => x.Cells.Any(y => y.GetType() == type)).Aggregate("", (current, cell) => current + cell.RenderIt());

            if (!string.IsNullOrEmpty(content1))
            {
                content += string.Format("\t<thead>\r\n{0}\t</thead>\r\n", content1);
            }

            content1 = Rows.Where(x => x.Cells.All(y => y.GetType() != type)).Aggregate("", (current, cell) => current + cell.RenderIt());

            if (!string.IsNullOrEmpty(content1))
            {
                content += string.Format("\t<tbody>\r\n{0}\t</tbody>\r\n", content1);
            }


            var erg = string.Format("\r\n<table{0}>\r\n{1}</table>\r\n", RenderAttributes(this, "table"), content);
            return erg;
        }

        ///// <summary>
        ///// Render element into an MvcHtmlString for RAZOR view
        ///// </summary>
        ///// <returns>html string as MvcHtmlString</returns>
        //public MvcHtmlString RenderItMvc()
        //{
        //    return new MvcHtmlString(RenderIt());
        //}
    }
}