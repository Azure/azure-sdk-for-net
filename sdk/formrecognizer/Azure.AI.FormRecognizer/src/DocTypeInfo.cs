// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("DocTypeInfo")]
    public partial class DocTypeInfo
    {
        /// <summary> Description of the document semantic schema. </summary>
        public IReadOnlyDictionary<string, DocumentFieldSchema> FieldSchema { get; }

        /// <summary> Custom model build mode. </summary>
        internal DocumentBuildMode? BuildMode { get; }
    }
}
