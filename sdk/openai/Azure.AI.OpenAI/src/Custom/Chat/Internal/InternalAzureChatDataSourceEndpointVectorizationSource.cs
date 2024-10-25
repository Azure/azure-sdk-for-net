// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias OpenAI;
using OpenAI::System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[Experimental("AOAI001")]
[CodeGenModel("AzureChatDataSourceEndpointVectorizationSource")]
internal partial class InternalAzureChatDataSourceEndpointVectorizationSource
{
    internal DataSourceAuthentication Authentication { get; set; }
}
