// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace DataFactory.Tests.Utils
{
    public class ExampleTracingInterceptor : IServiceClientTracingInterceptor
    {
        private static readonly string[] uninterestingParameters = { "cancellationToken" };
        private static readonly string[] uninterestingHeaders = {
            "Authorization", "Cache-Control", "Pragma", "Server", "Strict-Transport-Security",
            "X-Powered-By", "x-ms-routing-request-id", "Transfer-Encoding", "Vary"
        };
        private readonly string subscriptionId;
        private readonly string apiVersion;
        public Dictionary<long, Example> InvocationIdToExample { get; private set; }

        public string CurrentExampleName { get; set; }

        public ExampleTracingInterceptor(string subscriptionId, string apiVersion)
        {
            // pass in subscriptionId and api-version because they're client properties
            this.subscriptionId = subscriptionId;
            this.apiVersion = apiVersion;
            this.InvocationIdToExample = new Dictionary<long, Example>();
        }

        public void EnterMethod(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
            long invocationIdNumber = long.Parse(invocationId); // it's actually a long that starts at 1 and goes up by 1
            Example example = new Example();
            if (CurrentExampleName != null)
            {
                example.Name = CurrentExampleName;
            }
            example.Parameters = new Dictionary<string, object>();
            example.Parameters.Add("subscriptionId", subscriptionId);
            foreach (string s in parameters.Keys)
            {
                if (!uninterestingParameters.Contains(s))
                {
                    DateTime? dateTimeParameter = parameters[s] as DateTime?;

                    if (dateTimeParameter.HasValue)
                    {
                        string parameterValue = dateTimeParameter.Value.ToString("o");
                        parameterValue = parameterValue.Replace(":", "%3A");
                        example.Parameters.Add(s, parameterValue);
                    }
                    else
                    {
                        example.Parameters.Add(s, parameters[s]);
                    }
                }
            }
            example.Parameters.Add("api-version", apiVersion);
            InvocationIdToExample[invocationIdNumber] = example;
        }

        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            long invocationIdNumber = long.Parse(invocationId);
            Example.Response r = new Example.Response(response, uninterestingHeaders);
            InvocationIdToExample[invocationIdNumber].Responses.Add(((int)response.StatusCode).ToString(), r);
        }

        // The remaining methods from IServiceClientTracingInterceptor below are not needed for this class
        public void Configuration(string source, string name, string value)
        {
        }

        public void ExitMethod(string invocationId, object returnValue)
        {
        }

        public void Information(string message)
        {
        }

        public void SendRequest(string invocationId, HttpRequestMessage request)
        {
        }

        public void TraceError(string invocationId, Exception exception)
        {
        }
    }
}
