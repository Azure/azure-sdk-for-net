// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Template.Models
{
    /// <summary> Information about the extracted cell in a table. </summary>
    public partial class DataTableCell
    {
        /// <summary> Row index of the cell. </summary>
        public int RowIndex { get; set; }
        /// <summary> Column index of the cell. </summary>
        public int ColumnIndex { get; set; }
        /// <summary> Number of rows spanned by this cell. </summary>
        public int? RowSpan { get; set; }
        /// <summary> Number of columns spanned by this cell. </summary>
        public int? ColumnSpan { get; set; }
        /// <summary> Text content of the cell. </summary>
        public string Text { get; set; }
        /// <summary> Quadrangle bounding box, with coordinates specified relative to the top-left of the original image. The eight numbers represent the four points, clockwise from the top-left corner relative to the text orientation. For image, the (x, y) coordinates are measured in pixels. For PDF, the (x, y) coordinates are measured in inches. </summary>
        public ICollection<float> BoundingBox { get; set; } = new List<float>();
        /// <summary> Confidence value. </summary>
        public float Confidence { get; set; }
        /// <summary> When includeTextDetails is set to true, a list of references to the text elements constituting this table cell. </summary>
        public ICollection<string> Elements { get; set; }
        /// <summary> Is the current cell a header cell?. </summary>
        public bool? IsHeader { get; set; }
        /// <summary> Is the current cell a footer cell?. </summary>
        public bool? IsFooter { get; set; }
    }
}
