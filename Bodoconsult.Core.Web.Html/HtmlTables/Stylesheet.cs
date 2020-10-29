using System.Collections.Generic;

namespace Bodoconsult.Core.Web.Html.HtmlTables
{
    public class Stylesheet : IStylesheet
    {
        private readonly IDictionary<string, string> _attributes = new Dictionary<string, string>();


        public string GetStyle(string styleName)
        {
            return !_attributes.ContainsKey(styleName) ? null : _attributes[styleName];
        }

        public void CssClassTable(string value)
        {
            _attributes.Add("cssClassTable", value);
        }

        public void CssClassTrHeader(string value)
        {
            _attributes.Add("cssClassTrHeader", value);
        }


        public void CssClassTh(string value)
        {
            _attributes.Add("cssClassTh", value);
        }

        public void CssClassThCenter(string value)
        {
            _attributes.Add("cssClassThCenter", value);
        }

        public void CssClassThRight(string value)
        {
            _attributes.Add("cssClassThRight", value);
        }


        public void CssClassTrBody(string value)
        {
            _attributes.Add("cssClassTrBody", value);
        }

        public void CssClassTd(string value)
        {
            _attributes.Add("cssClassTd", value);
        }

        public void CssClassTdCenter(string value)
        {
            _attributes.Add("cssClassTdCenter", value);
        }

        public void CssClassTdRight(string value)
        {
            _attributes.Add("cssClassTdRight", value);
        }
    }




}