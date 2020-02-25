// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Template.Models
{
    /// <summary> Recognized field value. </summary>
    public partial class FieldValue
    {
        /// <summary> Semantic data type of the field value. </summary>
        public FieldValueType Type { get; set; }
        /// <summary> String value. </summary>
        public string ValueString { get; set; }
        /// <summary> Date value. </summary>
        public string ValueDate { get; set; }
        /// <summary> Time value. </summary>
        public string ValueTime { get; set; }
        /// <summary> Phone number value. </summary>
        public string ValuePhoneNumber { get; set; }
        /// <summary> Floating point value. </summary>
        public float? ValueNumber { get; set; }
        /// <summary> Integer value. </summary>
        public int? ValueInteger { get; set; }
        /// <summary> Array of field values. </summary>
        public ICollection<FieldValue> ValueArray { get; set; }
        /// <summary> Dictionary of named field values. </summary>
        public IDictionary<string, FieldValue> ValueObject { get; set; }
        /// <summary> Text content of the extracted field. </summary>
        public string Text { get; set; }
        /// <summary> Quadrangle bounding box, with coordinates specified relative to the top-left of the original image. The eight numbers represent the four points, clockwise from the top-left corner relative to the text orientation. For image, the (x, y) coordinates are measured in pixels. For PDF, the (x, y) coordinates are measured in inches. </summary>
        public ICollection<float> BoundingBox { get; set; }
        /// <summary> Confidence value. </summary>
        public float? Confidence { get; set; }
        /// <summary> When includeTextDetails is set to true, a list of references to the text elements constituting this field. </summary>
        public ICollection<string> Elements { get; set; }
        /// <summary> The 1-based page number in the input document. </summary>
        public int? Page { get; set; }
    }
}
