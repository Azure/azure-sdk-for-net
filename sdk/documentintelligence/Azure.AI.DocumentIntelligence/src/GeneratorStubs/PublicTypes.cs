// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.AI.DocumentIntelligence
{
    public partial class AnalyzeBatchOperationDetails
    {
        /// <summary> Analyze batch operation result ID. </summary>
        public string ResultId { get; }
    }

    public partial class AnalyzeResult
    {
        internal StringIndexType StringIndexType { get; }
    }

    public readonly partial struct BoundingRegion { }

    public readonly partial struct DocumentSpan { }
}

namespace Microsoft.Extensions.Azure
{
    [CodeGenModel("AIDocumentIntelligenceClientBuilderExtensions")]
    public partial class DocumentIntelligenceClientBuilderExtensions { }
}

#pragma warning restore SA1402 // File may only contain a single type
