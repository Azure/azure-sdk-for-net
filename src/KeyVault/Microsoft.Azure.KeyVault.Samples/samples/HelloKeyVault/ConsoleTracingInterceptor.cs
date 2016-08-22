// 
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Rest;

namespace Sample.Microsoft.HelloKeyVault
{
    internal class ConsoleTracingInterceptor : IServiceClientTracingInterceptor
    {
        private void Write(string message, params object[] arguments)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (arguments == null || arguments.Length == 0)
            {
                Console.WriteLine(message);                
            }
            else
            {
                Console.WriteLine(message, arguments);                
            }
            Console.ResetColor();
        }
        public void Information(string message)
        {
            Write(message);
        }

        public void Configuration(string source, string name, string value)
        {
        }

        public void EnterMethod(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
            Write("{0} - [{1}]: Entered method {2} with arguments: {3}", invocationId, instance, method, parameters.AsFormattedString());
        }

        public void SendRequest(string invocationId, HttpRequestMessage request)
        {
            Write("{0} - {1}", invocationId, request.AsFormattedString());
        }

        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            Write("{0} - {1}", invocationId, response.AsFormattedString());
        }

        public void TraceError(string invocationId, Exception ex)
        {
            Write("{0} - Error: {1}", invocationId, ex);
        }

        public void ExitMethod(string invocationId, object result)
        {
            Write("{0} - Exited method with result: {1}", invocationId, result);
        }
    }
}
