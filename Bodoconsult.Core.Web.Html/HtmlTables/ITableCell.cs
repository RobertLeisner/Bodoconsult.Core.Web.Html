using System.Collections.Generic;

namespace Bodoconsult.Core.Web.Html.HtmlTables
{
    public interface ITableCell
    {
        IDictionary<string, string> Attributes { get; set; }

        string Text { get; set; }

        string RenderIt();
    }
}