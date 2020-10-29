# What does the library

Bodoconsult.Core.Web.Html 

# How to use the library

The source code contain NUnit test classes, the following source code is extracted from. The samples below show the most helpful use cases for the library.

## Create a simple HTML table

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

## Create an advanced HTML table

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

## Create a HTML table from a System.Data.DataTable

            var dt = TestHelper.GetDataTable("LineChart.xml");
            var erg = TableFormatter.FormatAsHtml(dt, true);

# About us

Bodoconsult (<http://www.bodoconsult.de>) is a Munich based software company from Germany.

Robert Leisner is senior software developer at Bodoconsult. See his profile on <http://www.bodoconsult.de/Curriculum_vitae_Robert_Leisner.pdf>.

