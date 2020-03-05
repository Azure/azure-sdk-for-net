// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> A set of extracted fields corresponding to the input document. </summary>
    internal partial class DocumentResult_internal
    {
        /// <summary> Document type. </summary>
        public string DocType { get; set; }
        /// <summary> First and last page number where the document is found. </summary>
        public ICollection<int> PageRange { get; set; } = new List<int>();
        /// <summary> Dictionary of named field values. </summary>
        public IDictionary<string, FieldValue_internal> Fields { get; set; } = new System.Collections.Generic.Dictionary<string, Azure.AI.FormRecognizer.Models.FieldValue_internal>();
    }
}
