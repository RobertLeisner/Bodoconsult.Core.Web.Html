using System.Diagnostics;
using Bodoconsult.Core.Web.Html.Test.Helpers;
using NUnit.Framework;

namespace Bodoconsult.Core.Web.Html.Test
{
    [TestFixture]
    public class UnitTestTableFormatter
    {



        [Test]
        public void TestFormatAsCsv()
        {

            var dt = TestHelper.GetDataTable("LineChart.xml");
            var erg = TableFormatter.FormatAsCsv(dt, true);

            Debug.Print(erg);

            Assert.IsTrue(erg.Contains("\r\n"));
            Assert.IsTrue(erg.Contains(";"));
        }


        [Test]
        public void TestFormatAsHtml()
        {

            var dt = TestHelper.GetDataTable("LineChart.xml");
            var erg = TableFormatter.FormatAsHtml(dt, true);

            Debug.Print(erg);

            Assert.IsTrue(erg.Contains("<table>"));
            Assert.IsTrue(erg.Contains("</table>"));
        }

    }
}
