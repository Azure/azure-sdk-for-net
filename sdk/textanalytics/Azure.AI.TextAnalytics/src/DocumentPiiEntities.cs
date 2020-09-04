// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("DocumentPiiEntities")]
    internal partial class DocumentPiiEntities {

        /// <summary> Redacted text in the document. </summary>
        public string RedactedText { get; }

        /// <summary> Recognized entities in the document. </summary>
        internal IReadOnlyList<PiiEntity> Entities { get; }

        /// <summary> Warnings encountered while processing document. </summary>
        internal IReadOnlyList<TextAnalyticsWarningInternal> Warnings { get; }

    }
}
