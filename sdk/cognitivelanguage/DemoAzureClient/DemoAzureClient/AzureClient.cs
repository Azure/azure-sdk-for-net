// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using System.ClientModel.Primitives;

namespace DemoAzureClient;

public class AzureClient
{
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;

    public AzureClient(Uri endpoint, AzureKeyCredential credential, AzureClientOptions options = default)
    {
        _endpoint = endpoint;

        // Create ClientPipeline from policies in default Azure.Core pipeline

        // 1. ReadClientRequestIdPolicy.Shared
        // 2. Per call policies passed as parameters to HttpPipelineBuilder.Build
        // 3. Per call policies from ClientOptions
        // 4. ClientRequestIdPolicy.Shared
        // 5. TelemetryPolicy
        // 6. RetryPolicy
        // 7. RedirectPolicy
        // 8. Per try policies passed as parameters to HttpPipelineBuilder.Build
        // 9. Per try policies from ClientOptions
        // 10. LoggingPolicy
        // 11. ResponseBodyPolicy
        // 12. RequestActivityPolicy
        // 13. Before transport policies from ClientOptions
        // 14. TransportPolicy

        // Could we walk an HttpPipeline instance and adapt the policies one at a time?
    }
}
