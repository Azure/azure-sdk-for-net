// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Analyze operation result. </summary>
    public partial class AnalyzeResult
    {
        /// <summary> Version of schema used for this result. </summary>
        public string Version { get; set; }
        /// <summary> Text extracted from the input. </summary>
        public ICollection<ReadResult> ReadResults { get; set; } = new System.Collections.Generic.List<Azure.AI.FormRecognizer.Models.ReadResult>();
        /// <summary> Page-level information extracted from the input. </summary>
        public ICollection<PageResult> PageResults { get; set; }
        /// <summary> Document-level information extracted from the input. </summary>
        public ICollection<DocumentResult> DocumentResults { get; set; }
        /// <summary> List of errors reported during the analyze operation. </summary>
        public ICollection<ErrorInformation> Errors { get; set; }
    }
}
