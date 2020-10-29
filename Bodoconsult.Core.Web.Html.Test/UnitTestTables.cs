using System.Diagnostics;
using Bodoconsult.Core.Web.Html.HtmlTables;
using NUnit.Framework;

namespace Bodoconsult.Core.Web.Html.Test
{
    [TestFixture]
    public class UnitTestTables
    {
        [Test]
        public void TestSimpleTable()
        {
            // Arrange
            var table = new Table();

            // Header
            var headerrow = new TableRow(table);
            ITableCell cell = new TableHeaderCell(headerrow) { Text = "Header1" };
            cell = new TableHeaderCell(headerrow) { Text = "Header2" };


            // Content
            var contentrow = new TableRow(table);
            cell = new TableCell(contentrow) { Text = "Content1" };
            cell = new TableCell(contentrow) { Text = "Content2" };

            // Act
            var s = table.RenderIt();

            // Assert
            Debug.Print(s);

            Assert.IsFalse(string.IsNullOrEmpty(s));


            if (string.IsNullOrEmpty(s)) return;

            StringAssert.Contains("<table", s );
            StringAssert.Contains("</table>", s);
            StringAssert.Contains("<tr", s);
            StringAssert.Contains("</tr>", s);
            StringAssert.Contains("<thead>", s );
            StringAssert.Contains("</thead>", s);
            StringAssert.Contains("<tbody>", s );
            StringAssert.Contains("</tbody>", s);
            StringAssert.Contains("<th", s);
            StringAssert.Contains("</th>", s );
            StringAssert.Contains("<td", s);
            StringAssert.Contains("</td>", s);
        }

        [Test]
        public void TestAdvancedTable()
        {
            // Arrange
            var table = new Table();
            table.Attributes.Add("class","cssTableClass");

            // Header
            var headerrow = new TableRow(table);
            headerrow.Attributes.Add("class","cssHeaderRowClass" );
            ITableCell cell = new TableHeaderCell(headerrow) { Text = "Header1" };
            cell.Attributes.Add("class", "cssHeaderCellClass" );
            cell = new TableHeaderCell(headerrow) { Text = "Header2" };

            // Content
            var contentrow = new TableRow(table);
            cell = new TableCell(contentrow) { Text = "Content1" };
            cell.Attributes.Add("class", "cssContentCellClass" );
            cell = new TableCell(contentrow) { Text = "Content2" };


            // Act
            var s = table.RenderIt();

            // Assert
            Debug.Print(s);

            Assert.IsFalse(string.IsNullOrEmpty(s));


            if (string.IsNullOrEmpty(s)) return;

            StringAssert.Contains("<table", s);
            StringAssert.Contains("</table>", s);
            StringAssert.Contains("<tr", s);
            StringAssert.Contains("</tr>", s);
            StringAssert.Contains("<thead>", s);
            StringAssert.Contains("</thead>", s);
            StringAssert.Contains("<tbody>", s);
            StringAssert.Contains("</tbody>", s);
            StringAssert.Contains("<th", s);
            StringAssert.Contains("</th>", s);
            StringAssert.Contains("<td", s);
            StringAssert.Contains("</td>", s);
            StringAssert.Contains("class=\"cssTableClass\"", s);
            StringAssert.Contains("class=\"cssHeaderRowClass\"", s);
            StringAssert.Contains("class=\"cssHeaderCellClass\"", s);
            StringAssert.Contains("class=\"cssContentCellClass\"", s);
        }


        [Test]
        public void TestAdvancedTableWithStylesheet()
        {
            var styleSheet = new Stylesheet();
            styleSheet.CssClassTable("cssTableClass");
            styleSheet.CssClassTrHeader("cssHeaderRowClass");
            styleSheet.CssClassTh("cssHeaderCellClass");
            styleSheet.CssClassTrBody("cssBodyRowClass");
            styleSheet.CssClassTd("cssContentCellClass");


            // Arrange
            var table = new Table {Stylesheet = styleSheet};

            // Header
            var headerrow = new TableRow(table);
            ITableCell cell = new TableHeaderCell(headerrow) { Text = "Header1" };
            cell = new TableHeaderCell(headerrow) { Text = "Header2" };

            // Content
            var contentrow = new TableRow(table);
            cell = new TableCell(contentrow) { Text = "Content1" };
            cell = new TableCell(contentrow) { Text = "Content2" };


            // Act
            var s = table.RenderIt();

            // Assert
            Debug.Print(s);

            Assert.IsFalse(string.IsNullOrEmpty(s));


            if (string.IsNullOrEmpty(s)) return;

            StringAssert.Contains("<table", s);
            StringAssert.Contains("</table>", s);
            StringAssert.Contains("<tr", s);
            StringAssert.Contains("</tr>", s);
            StringAssert.Contains("<thead>", s);
            StringAssert.Contains("</thead>", s);
            StringAssert.Contains("<tbody>", s);
            StringAssert.Contains("</tbody>", s);
            StringAssert.Contains("<th", s);
            StringAssert.Contains("</th>", s);
            StringAssert.Contains("<td", s);
            StringAssert.Contains("</td>", s);
            StringAssert.Contains("class=\"cssTableClass\"", s);
            StringAssert.Contains("class=\"cssHeaderRowClass\"", s);
            StringAssert.Contains("class=\"cssHeaderCellClass\"", s);
            StringAssert.Contains("class=\"cssContentCellClass\"", s);
        }


        //[Test]
        //public void TestSimpleTableWithHtmlAttributes()
        //{
        //    // Arrange
        //    var table = new Table();
        //    table.Attributes.Add("class", "test-table-class");
        //    table.Attributes.Add("class", "test-table-id");

        //    // Header
        //    var headerrow = new TableRow();
        //    ITableCell cell = new TableHeaderCell { Text = "Header1" };
        //    headerrow.Cells.Add(cell);
        //    cell = new TableHeaderCell { Text = "Header2" };
        //    headerrow.Cells.Add(cell);
        //    table.Rows.Add(headerrow);

        //    // Content
        //    var contentrow = new TableRow();
        //    cell = new TableCell { Text = "Content1" };
        //    contentrow.Cells.Add(cell);
        //    cell = new TableCell { Text = "Content2" };
        //    contentrow.Cells.Add(cell);
        //    table.Rows.Add(contentrow);

        //    // Act
        //    var s = table.RenderIt();

        //    // Assert
        //    Debug.Print(s);

        //    Assert.IsFalse(string.IsNullOrEmpty(s));


        //    if (string.IsNullOrEmpty(s)) return;

        //    StringAssert.Contains(s, "<table");
        //    StringAssert.Contains(s, "</table>");
        //    StringAssert.Contains(s, "<tr");
        //    StringAssert.Contains(s, "</tr>");
        //    StringAssert.Contains(s, "<thead>");
        //    StringAssert.Contains(s, "</thead>");
        //    StringAssert.Contains(s, "<tbody>");
        //    StringAssert.Contains(s, "</tbody>");
        //    StringAssert.Contains(s, "<th");
        //    StringAssert.Contains(s, "</th>");
        //    StringAssert.Contains(s, "<td");
        //    StringAssert.Contains(s, "</td>");
        //}
    }
}
