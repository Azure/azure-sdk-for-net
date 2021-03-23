// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Azure.AI.TextAnalytics.Models;
using Azure.Core;
using Microsoft.Extensions.Azure;

namespace Azure.AI.TextAnalytics
{
    [CodeGenModel("DocumentHealthcareEntities")]
    internal partial class DocumentHealthcareEntitiesInternal
    {
        /// <summary> Unique, non-empty document identifier. </summary>
        public string Id { get; }
        /// <summary> Healthcare entities. </summary>
        public IReadOnlyList<HealthcareEntityInternal> Entities { get; }
        /// <summary> Healthcare entity relations. </summary>
        public IReadOnlyList<HealthcareRelationInternal> Relations { get; }
        /// <summary> Warnings encountered while processing document. </summary>
        public IReadOnlyList<TextAnalyticsWarningInternal> Warnings { get; }
        /// <summary> if showStats=true was specified in the request this field will contain information about the document payload. </summary>
        public TextDocumentStatistics? Statistics { get; }
    }
}
