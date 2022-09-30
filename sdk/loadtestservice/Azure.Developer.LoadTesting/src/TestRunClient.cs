// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Pipeline;
using Azure.Core;

namespace Azure.Developer.LoadTesting
{
    public partial class TestRunClient
    {
        internal TestRunClient(string endpoint, TokenCredential credential) : this(endpoint, credential, new AzureLoadTestingClientOptions())
        {
        }

        internal TestRunClient(string endpoint, TokenCredential credential, AzureLoadTestingClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new AzureLoadTestingClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }
    }
}
