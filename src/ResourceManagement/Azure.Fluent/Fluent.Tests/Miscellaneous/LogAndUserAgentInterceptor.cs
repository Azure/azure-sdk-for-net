// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace Fluent.Tests.Miscellaneous
{
    public class LogAndUserAgentInterceptor : IServiceClientTracingInterceptor
    {
        public bool FoundUserAgentInLog { get; private set; }
        public void Configuration(string source, string name, string value)
        {
        }

        public void EnterMethod(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
        }

        public void ExitMethod(string invocationId, object returnValue)
        {
        }

        public void Information(string message)
        {
            if (message != null)
            {
                if (message.ToLower().Contains("User-Agent :".ToLower()))
                {
                    if (message.ToLower().Contains("azure-fluent-test/1.0.0-prelease".ToLower()))
                    {
                        this.FoundUserAgentInLog = true;
                    }
                }
            }
        }

        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
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
