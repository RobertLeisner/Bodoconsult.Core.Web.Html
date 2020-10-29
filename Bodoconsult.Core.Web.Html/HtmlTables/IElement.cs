using System.Collections.Generic;

namespace Bodoconsult.Core.Web.Html.HtmlTables
{
    public interface IElement<out T>
    {

        T Parent { get; }

        /// <summary>
        /// Html attributes for elements. Use it to add class, id, style or other 
        /// attributes to an html tag
        /// </summary>
        IDictionary<string, string> Attributes { get; set; }

        /// <summary>
        /// Render element into an html string
        /// </summary>
        /// <returns>html string</returns>
        string RenderIt();
    }
}