//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Common.Internals;

namespace Microsoft.WindowsAzure.Testing
{
    public class TestingTracingInterceptor : ICloudTracingInterceptor
    {
        private void Write(string message, params object[] arguments)
        {
            if (arguments == null || arguments.Length == 0)
            {
                Console.Write(message);
            }
            else
            {
                Console.Write(message, arguments);
            }
            Console.WriteLine();
        }

        public void Information(string message)
        {
        }

        public void Configuration(string source, string name, string value)
        {
        }

        public void Enter(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
        }

        public void SendRequest(string invocationId, HttpRequestMessage request)
        {
            Write(invocationId + " - " + request.AsString());
        }

        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            Write(invocationId + " - " + response.AsString());
        }

        public void Error(string invocationId, Exception ex)
        {
        }

        public void Exit(string invocationId, object result)
        {
        }
    }
}
