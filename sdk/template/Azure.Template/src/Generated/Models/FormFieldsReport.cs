// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Report for a custom model training field. </summary>
    public partial class FormFieldsReport
    {
        /// <summary> Training field name. </summary>
        public string FieldName { get; set; }
        /// <summary> Estimated extraction accuracy for this field. </summary>
        public float Accuracy { get; set; }
    }
}
