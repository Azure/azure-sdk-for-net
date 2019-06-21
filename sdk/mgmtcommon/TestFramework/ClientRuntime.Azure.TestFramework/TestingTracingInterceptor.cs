// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    public class TestingTracingInterceptor
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
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(request.ToString());
            if (request.Content != null)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("Body:");
                stringBuilder.AppendLine("{");
                stringBuilder.AppendLine(request.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult());
                stringBuilder.AppendLine("}");
            }
            Write("{0} - {1}", invocationId, stringBuilder.ToString());
        }

        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(response.ToString());
            if (response.Content != null)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("Body:");
                stringBuilder.AppendLine("{");
                stringBuilder.AppendLine(response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult());
                stringBuilder.AppendLine("}");
            }
            Write("{0} - {1}", invocationId, stringBuilder.ToString());
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
