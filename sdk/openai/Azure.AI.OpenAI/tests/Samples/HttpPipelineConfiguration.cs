// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples;

public partial class HttpPipelineConfiguration
{
    #region Snippet:ImplementACustomHttpPipelinePolicy
    public class SimpleQueryStringPolicy : HttpPipelinePolicy
    {
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            message?.Request?.Uri?.AppendQuery("myParameterName", "valueForMyParameter");
            ProcessNext(message, pipeline);
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            message?.Request?.Uri?.AppendQuery("myParameterName", "valueForMyParameter");
            return ProcessNextAsync(message, pipeline);
        }
    }
    #endregion

    [Test]
    [Ignore("Only verifying that the sample builds")]
    public void UseACustomizedPipeline()
    {
        string myApiKey = string.Empty;

        #region Snippet:ConfigureClientsWithCustomHttpPipelinePolicy
        OpenAIClientOptions clientOptions = new();
        clientOptions.AddPolicy(
            policy: new SimpleQueryStringPolicy(),
            position: HttpPipelinePosition.PerRetry);

        OpenAIClient client = new(
            endpoint: new Uri("https://myresource.openai.azure.com"),
            keyCredential: new AzureKeyCredential(myApiKey),
            clientOptions);
        #endregion
    }
}
