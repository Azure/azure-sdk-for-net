// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.AI.DocumentIntelligence
{
    [CodeGenModel("AzureAIDocumentIntelligenceClientOptions")]
    public partial class DocumentIntelligenceClientOptions { }

    [CodeGenModel("AIDocumentIntelligenceModelFactory")]
    public partial class DocumentIntelligenceModelFactory { }
}

namespace Microsoft.Extensions.Azure
{
    [CodeGenModel("AIDocumentIntelligenceClientBuilderExtensions")]
    public partial class DocumentIntelligenceClientBuilderExtensions { }
}

#pragma warning restore SA1402 // File may only contain a single type
