// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Pipeline;
using Azure.Core;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Developer.LoadTesting
{
    public partial class LoadTestRunClient
    {
        internal LoadTestRunClient(string endpoint, TokenCredential credential) : this(endpoint, credential, new AzureLoadTestingClientOptions())
        {
        }

        internal LoadTestRunClient(string endpoint, TokenCredential credential, AzureLoadTestingClientOptions options)
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

        /// <summary>
        /// UploadTestFile.
        /// </summary>
        public TestRunOperation beginTestRun(WaitUntil waitUntil, string testRunId, RequestContent content, string oldTestRunId, string fileType = null, RequestContext context = null)
        {
            CreateOrUpdateTestRun(testRunId, content, oldTestRunId, context);
            TestRunOperation operation = new(testRunId, this);
            if (waitUntil == WaitUntil.Completed)
            {
                operation.WaitForCompletion();
            }
            return operation;
        }
    }
}
