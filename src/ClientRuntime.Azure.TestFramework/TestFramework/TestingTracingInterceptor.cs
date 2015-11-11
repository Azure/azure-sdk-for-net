// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.Rest;

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    public class TestingTracingInterceptor : IServiceClientTracingInterceptor
    {
        private void Write(string message, params object[] arguments)
        {
            if (arguments == null || arguments.Length == 0)
            {
                Console.WriteLine(message);
                Debug.WriteLine(message);
            }
            else
            {
                Console.WriteLine(message, arguments);
                Debug.WriteLine(message, arguments);
            }
        }

        public void Information(string message)
        {
            Write(message);
        }

        public void Configuration(string source, string name, string value)
        {
        }
        
        public void SendRequest(string invocationId, HttpRequestMessage request)
        {
            Write("{0} - {1}", invocationId, request.AsFormattedString());
        }

        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            Write("{0} - {1}", invocationId, response.AsFormattedString());
        }

        public void EnterMethod(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
            Write("{0} - [{1}]: Entered method {2} with arguments: {3}", invocationId, instance, method, parameters.AsFormattedString());
        }

        public void ExitMethod(string invocationId, object returnValue)
        {
            Write("{0} - Exited method with result: {1}", invocationId, returnValue);
        }

        public void TraceError(string invocationId, Exception exception)
        {
            Write("{0} - Error: {1}", invocationId, exception);
        }
    }
}
