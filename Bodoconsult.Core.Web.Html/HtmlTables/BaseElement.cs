using System.Collections.Generic;

namespace Bodoconsult.Core.Web.Html.HtmlTables
{
    public class BaseElement<T> : IElement<T>
    {

        public BaseElement(T parent)
        {
            Attributes = new Dictionary<string, string>();
            Parent = parent;
        }

        public T Parent { get; private set; }


        public IDictionary<string, string> Attributes { get; set; }

        /// <summary>
        /// Render element into an html string
        /// </summary>
        /// <returns>html string</returns>
        public virtual string RenderIt()
        {
            return "";
        }


        internal string RenderAttributes(Table parent, string tag)
        {
            var erg = "";
            var style = parent.Stylesheet;
            if (style != null)
            {
                
                switch (tag)
                {
                    case "table":
                        return " class=\"" + style.GetStyle("cssClassTable")+"\"";
                    case "tr-header":
                        return " class=\"" + style.GetStyle("cssClassTrHeader") + "\"";
                    case "th":
                        return " class=\"" + style.GetStyle("cssClassTh") + "\"";
                    case "th-center":
                        return " class=\"" + style.GetStyle("cssClassThCenter") + "\"";
                    case "th-right":
                        return " class=\"" + style.GetStyle("cssClassThRight") + "\"";
                    case "tr-body":
                        return " class=\"" + style.GetStyle("cssClassTrBody") + "\"";
                    case "td":
                        return " class=\"" + style.GetStyle("cssClassTd") + "\"";
                    case "td-center":
                        return " class=\"" + style.GetStyle("cssClassTdCenter") + "\"";
                    case "td-right":
                        return " class=\"" + style.GetStyle("cssClassTdRight") + "\"";
                }

                return erg;
            }

            
            foreach (var ra in Attributes)
            {
                erg += " " + ra.Key + "=\"" + ra.Value + "\"";
            }

            return erg;
        }
    }
}