namespace Bodoconsult.Core.Web.Html
{
    /// <summary>
    /// Provides helper functions for creation of HTML code
    /// </summary>
    public static class HtmlHelper
    {

        /// <summary>
        /// Create a HTML P tag
        /// </summary>
        /// <param name="text">Text for the paragraph</param>
        /// <param name="cssName">Name of a CSS class nam</param>
        /// <returns></returns>
        public static string Paragraph(string text, string cssName = null)
        {
            cssName = string.IsNullOrEmpty(cssName) ? "" : $" class=\"{cssName}\" ";

            return $"<p{cssName}>{text}</p>";
        }


        /// <summary>
        /// Create a HTML H1 tag
        /// </summary>
        /// <param name="text">Text for the paragraph</param>
        /// <param name="cssName">Name of a CSS class nam</param>
        /// <returns></returns>
        public static string H1(string text, string cssName = null)
        {
            cssName = string.IsNullOrEmpty(cssName) ? "" : $" class=\"{cssName}\" ";

            return $"<h1{cssName}>{text}</h1>";
        }

        /// <summary>
        /// Create a HTML H2 tag
        /// </summary>
        /// <param name="text">Text for the paragraph</param>
        /// <param name="cssName">Name of a CSS class nam</param>
        /// <returns></returns>
        public static string H2(string text, string cssName = null)
        {
            cssName = string.IsNullOrEmpty(cssName) ? "" : $" class=\"{cssName}\" ";

            return $"<h2{cssName}>{text}</h2>";
        }


        /// <summary>
        /// Create a HTML H3 tag
        /// </summary>
        /// <param name="text">Text for the paragraph</param>
        /// <param name="cssName">Name of a CSS class nam</param>
        /// <returns></returns>
        public static string H3(string text, string cssName = null)
        {
            cssName = string.IsNullOrEmpty(cssName) ? "" : $" class=\"{cssName}\" ";

            return $"<h3{cssName}>{text}</h3>";
        }

        /// <summary>
        /// Create a HTML IMG tag
        /// </summary>
        /// <param name="url">Image url</param>
        /// <param name="alt">Alternative text</param>
        /// <returns></returns>
        public static string Image(string url, string alt)
        {
            alt = string.IsNullOrEmpty(alt) ? "" : $" alt=\"{alt}\" ";
            return $"<img src=\"{url}\"{alt}>";
        }


        /// <summary>
        /// Create a HTML DIV tag
        /// </summary>
        /// <param name="text">Text for the paragraph</param>
        /// <param name="cssName">Name of a CSS class nam</param>
        /// <returns></returns>
        public static string Div(string text, string cssName = null)
        {
            cssName = string.IsNullOrEmpty(cssName) ? "" : $" class=\"{cssName}\" ";

            return $"<div{cssName}>{text}</div>";
        }


        /// <summary>
        /// Create a HTML A tag
        /// </summary>
        /// <param name="alternative">Alternative text</param>
        /// <param name="cssName">Name of a CSS class nam</param>
        /// <param name="url">Link address</param>
        /// <param name="title">Visible text for the link</param>
        /// <returns></returns>
        public static string A(string url, string title = null, string alternative=null, string cssName = null)
        {
            alternative= string.IsNullOrEmpty(alternative) ? string.IsNullOrEmpty(title) ?  "" : $" title=\"{title}\""  : $" title=\"{alternative}\"";
            title = string.IsNullOrEmpty(title) ? url : title;
            cssName = string.IsNullOrEmpty(cssName) ? "" : $" class=\"{cssName}\" ";

            return $"<a href=\"{url}\"{cssName}{alternative}>{title}</a>";
        }

    }
}
