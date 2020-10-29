using System.Diagnostics;
using NUnit.Framework;

namespace Bodoconsult.Core.Web.Html.Test
{
    [TestFixture]
    public class UnitTestHtmlHelper
    {
        private const string Content = "Testinhalt eines Paragraphen";
        private const string Url = "http://www.test123.de/image,jpg";
        private const string Alt = "Alternative Text";
        private const string Css = "cssClassName";

        [Test]
        public void TestParagraphSimple()
        {

            var p1 = HtmlHelper.Paragraph(Content);

            Assert.IsFalse(string.IsNullOrEmpty(p1));
            Assert.IsTrue(p1.Contains("<p>"));

            Assert.IsTrue(p1.Contains("</p>"));
            Assert.IsFalse(p1.Contains("class=\""));

            Debug.Print("Simple paragraph:");
            Debug.Print(p1);
        }


        [Test]
        public void TestParagraphSimpleWithCss()
        {

            var p1 = HtmlHelper.Paragraph(Content, Css);

            Assert.IsFalse(string.IsNullOrEmpty(p1));
            Assert.IsTrue(p1.Contains("<p class=\""));

            Assert.IsTrue(p1.Contains("</p>"));
            Assert.IsTrue(p1.Contains("class=\""));

            Debug.Print("Simple paragraph with css:");
            Debug.Print(p1);
        }


        [Test]
        public void TestDivSimple()
        {

            var p1 = HtmlHelper.Div(Content);

            Assert.IsFalse(string.IsNullOrEmpty(p1));
            Assert.IsTrue(p1.Contains("<div>"));

            Assert.IsTrue(p1.Contains("</div>"));
            Assert.IsFalse(p1.Contains("class=\""));

            Debug.Print("Simple DIV:");
            Debug.Print(p1);
        }


        [Test]
        public void TestDivSimpleWithCss()
        {

            var p1 = HtmlHelper.Div(Content, Css);

            Assert.IsFalse(string.IsNullOrEmpty(p1));
            Assert.IsTrue(p1.Contains("<div class=\""));

            Assert.IsTrue(p1.Contains("</div>"));
            Assert.IsTrue(p1.Contains("class=\""));

            Debug.Print("Simple DIV with css:");
            Debug.Print(p1);
        }
    }



}
