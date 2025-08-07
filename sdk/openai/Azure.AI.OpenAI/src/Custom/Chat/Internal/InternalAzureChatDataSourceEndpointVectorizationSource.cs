// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[Experimental("AOAI001")]
[CodeGenType("AzureChatDataSourceEndpointVectorizationSource")]
internal partial class InternalAzureChatDataSourceEndpointVectorizationSource
{
    internal DataSourceAuthentication Authentication { get; set; }
}
