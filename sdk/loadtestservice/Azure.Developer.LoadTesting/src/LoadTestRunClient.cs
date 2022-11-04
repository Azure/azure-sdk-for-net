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
        /// Function to check if test run is completed
        /// </summary>
        /// <param name="testRunId">unique identifier for the test run</param>
        /// <param name="refreshTime">time in miliseconds to wait before checking the status of the JMX file (default = 10*1000 ms = 10 sec)</param>
        /// <param name="timeOut">time in miliseconds to wait before time out (default = 600*1000ms = 600 sec)</param>
        /// <returns>TestRunStatus enum with appropirate status flag</returns>
        public virtual TestRunStatus CheckTestRunCompleted(string testRunId, int refreshTime = 10 * 1000, int timeOut = 60 * 1000)
        {
            DateTime startTime = DateTime.Now;
            string status;

            while (true)
            {
                Response response = GetTestRun(testRunId);

                JsonNode jsonDocument = JsonNode.Parse(response.Content.ToString());
                status = (jsonDocument!["status"]).ToString();

                if (status.Equals("COMPLETED"))
                {
                    return TestRunStatus.Done;
                }

                if (status.Equals("FAILED"))
                {
                    return TestRunStatus.Failed;
                }

                if (status.Equals("CANCELLED"))
                {
                    return TestRunStatus.Cancelled;
                }

                DateTime timer = DateTime.Now;
                int nextHitTime = (int)(timer - startTime).TotalSeconds + refreshTime;

                if (nextHitTime > timeOut)
                {
                    return TestRunStatus.CheckTimeout;
                }

                Thread.Sleep(refreshTime * 1000);
            }
        }

        /// <summary>
        /// Function to check if test run is completed
        /// </summary>
        /// <param name="testRunId">unique identifier for the test run</param>
        /// <param name="refreshTime">time in miliseconds to wait before checking the status of the JMX file (default = 10*1000 ms = 10 sec)</param>
        /// <param name="timeOut">time in miliseconds to wait before time out (default = 600*1000ms = 600 sec)</param>
        /// <returns>TestRunStatus enum with appropirate status flag</returns>
        public virtual async Task<TestRunStatus> CheckTestRunCompletedAsync(string testRunId, int refreshTime = 10 * 1000, int timeOut = 60 * 1000)
        {
            DateTime startTime = DateTime.Now;
            string status;

            while (true)
            {
                Response response = await GetTestRunAsync(testRunId).ConfigureAwait(false);

                JsonNode jsonDocument = JsonNode.Parse(response.Content.ToString());
                status = (jsonDocument!["status"]).ToString();

                if (status.Equals("COMPLETED"))
                {
                    return TestRunStatus.Done;
                }

                if (status.Equals("FAILED"))
                {
                    return TestRunStatus.Failed;
                }

                if (status.Equals("CANCELLED"))
                {
                    return TestRunStatus.Cancelled;
                }

                DateTime timer = DateTime.Now;
                int nextHitTime = (int)(timer - startTime).TotalSeconds + refreshTime;

                if (nextHitTime > timeOut)
                {
                    return TestRunStatus.CheckTimeout;
                }

                await Task.Delay(refreshTime * 1000).ConfigureAwait(false);
            }
        }
    }
}
