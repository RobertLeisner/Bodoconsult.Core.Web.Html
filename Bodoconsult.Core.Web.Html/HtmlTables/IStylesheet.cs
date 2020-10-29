//using System.Collections.Generic;

namespace Bodoconsult.Core.Web.Html.HtmlTables
{
    public interface IStylesheet
    {
        //IDictionary<string, string> Attributes { get; set; }

        string GetStyle(string styleName);

        void CssClassTable(string value);

        void CssClassTh(string value);

        void CssClassThCenter(string value);

        void CssClassThRight(string value);

        void CssClassTd(string value);

        void CssClassTdCenter(string value);

        void CssClassTdRight(string value);

    }
}
