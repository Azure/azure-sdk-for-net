// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Pipeline;
using System.ClientModel.Primitives;

namespace Azure.Core.Internal;

internal static class IntegrationExtensions
{
    public static ClientPipeline ToClientPipeline(this HttpPipeline azurePipeline)
    {
        ReadOnlyMemory<HttpPipelinePolicy> azurePolicies = azurePipeline._pipeline;
        foreach (HttpPipelinePolicy azurePolicy in azurePolicies.Span)
        {

        }
    }
}
