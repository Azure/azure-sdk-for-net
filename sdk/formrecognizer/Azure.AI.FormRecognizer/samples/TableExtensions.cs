// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Samples
{
    internal static class TableExtensions
    {


        // TODO: Make this internal after testing.
        public static void WriteAscii(this ExtractedTable table, TextWriter writer, bool unicode = true, int cellWidth = 15)
        {
            var topLeft = unicode ? '┌' : '|';
            var topRight = unicode ? '┐' : '|';
            var topInner = unicode ? '┬' : '|';
            var bottomLeft = unicode ? '└' : '|';
            var bottomRight = unicode ? '┘' : '|';
            var bottomInner = unicode ? '┴' : '|';
            var innerLeft = unicode ? '├' : '|';
            var innerRight = unicode ? '┤' : '|';
            var innerCross = unicode ? '┼' : '|';
            var innerHeaderLeft = unicode ? '╞' : '|';
            var innerHeaderRight = unicode ? '╡' : '|';
            var innerHeaderCross = unicode ? '╪' : '|';
            var inner = unicode ? '│' : '|';
            var lineSeparator = unicode ? '─' : '-';
            var headerSeparator = unicode ? '═' : '=';
            var footerSeparator = '~';
            var index = table.IndexCells();

            // write table top border
            for (var colIndex = 0; colIndex < table.ColumnCount; colIndex += 1)
            {
                var firstCol = colIndex == 0;
                var line = new string(lineSeparator, cellWidth);
                var boundary = firstCol ? topLeft : topInner;
                writer.Write($"{boundary}{line}");
            }
            writer.WriteLine($"{topRight}");

            // write table
            for (var rowIndex = 0; rowIndex < table.RowCount; rowIndex += 1)
            {
                var headerColumnCount = new bool[table.ColumnCount];
                var footerColumnCount = new bool[table.ColumnCount];
                var lastRow = rowIndex == table.RowCount - 1;

                // write row
                for (var colIndex = 0; colIndex < table.ColumnCount; colIndex += 1)
                {
                    var firstCol = colIndex == 0;
                    var lastCol = colIndex == table.ColumnCount - 1;
                    if (index.TryGetValue(rowIndex, out IDictionary<int, ExtractedTableCell> row))
                    {
                        if (row.TryGetValue(colIndex, out ExtractedTableCell cell))
                        {
                            var colSpan = cell.ColumnSpan;
                            var maxWidth = cellWidth * colSpan; // TODO
                            if (maxWidth > cellWidth)
                            {
                                maxWidth += 1 * (colSpan - 1);
                            }
                            var text = cell.Text.Substring(0, Math.Min(cell.Text.Length, maxWidth));
                            writer.Write($"{inner}{{0, {maxWidth}}}", text);
                            for (var i = cell.ColumnIndex; i < cell.ColumnIndex + colSpan; i += 1)
                            {
                                headerColumnCount[i] = cell.IsHeader;
                                footerColumnCount[i] = cell.IsFooter;
                            }
                            colIndex += colSpan - 1;
                        }
                        else
                        {
                            writer.Write($"{inner}{{0, {cellWidth}}}", '-');
                        }
                    }
                }

                // write row bottom border
                writer.WriteLine(inner);
                for (var colIndex = 0; colIndex < table.ColumnCount; colIndex += 1)
                {
                    var firstCol = colIndex == 0;
                    var isHeader = headerColumnCount[colIndex];
                    var isFooter = footerColumnCount[colIndex];
                    var lineChar = isHeader ? headerSeparator : isFooter ? footerSeparator : lineSeparator;
                    var line = new string(lineChar, cellWidth);
                    char boundary;
                    if (lastRow)
                    {
                        if (firstCol)
                        {
                            boundary = bottomLeft;
                        }
                        else
                        {
                            boundary = bottomInner;
                        }
                    }
                    else if (firstCol)
                    {
                        boundary = isHeader ? innerHeaderLeft : innerLeft;
                    }
                    else
                    {
                        boundary = isHeader ? innerHeaderCross : innerCross;
                    }
                    writer.Write($"{boundary}{line}");
                }
                writer.WriteLine(lastRow ? bottomRight : headerColumnCount[table.ColumnCount - 1] ? innerHeaderRight : innerRight);
            }
        }

        private static Dictionary<int, IDictionary<int, ExtractedTableCell>> IndexCells(this ExtractedTable table)
        {
            var index = new Dictionary<int, IDictionary<int, ExtractedTableCell>>();
            foreach (var cell in table.Cells)
            {
                var RowCountpan = cell.RowSpan;
                var colSpan = cell.ColumnSpan;
                for (var rowIndex = cell.RowIndex; rowIndex < cell.RowIndex + RowCountpan; rowIndex += 1)
                {
                    if (!index.TryGetValue(rowIndex, out IDictionary<int, ExtractedTableCell> row))
                    {
                        index[rowIndex] = row = new Dictionary<int, ExtractedTableCell>();
                    }
                    for (var i = cell.ColumnIndex; i < cell.ColumnIndex + colSpan; i += 1)
                    {
                        row[i] = cell;
                    }
                }
            }
            return index;
        }
    }
}
