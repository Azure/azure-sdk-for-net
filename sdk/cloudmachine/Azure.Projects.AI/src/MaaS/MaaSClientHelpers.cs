// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using OpenAI;
using System;
using System.ClientModel.Primitives;

namespace Azure.AI.Models
{
    internal static class MaaSClientHelpers
    {
        private static readonly string[] _scopes = ["https://cognitiveservices.azure.com/.default"];

        internal static OpenAIClientOptions CreateOptions(Uri endpoint)
        {
            OpenAIClientOptions options = new OpenAIClientOptions();
            options.Endpoint = endpoint;
            return options;
        }

        internal static ClientPipeline CreatePipeline(TokenCredential credential, OpenAIClientOptions? options = default)
        {
            if (options == null)
            {
                options = new OpenAIClientOptions();
            }

            TokenCredentialAuthenticationPolicy auth = new(credential, _scopes);

            return ClientPipeline.Create(
                options,
                perCallPolicies: [],
                perTryPolicies: [auth],
                beforeTransportPolicies: []
            );
        }
    }
}
