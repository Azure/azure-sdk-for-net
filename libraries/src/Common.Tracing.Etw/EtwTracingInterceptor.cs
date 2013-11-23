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
using System.Net.Http;

namespace Microsoft.WindowsAzure.Common.Tracing.Etw
{
    public class EtwTracingInterceptor : ICloudTracingInterceptor
    {
        public void Information(string message)
        {
            throw new NotImplementedException();
        }

        public void Configuration(string source, string name, string value)
        {
            throw new NotImplementedException();
        }

        public void Enter(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        public void SendRequest(string invocationId, HttpRequestMessage request)
        {
            throw new NotImplementedException();
        }

        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            throw new NotImplementedException();
        }

        public void Error(string invocationId, Exception ex)
        {
            throw new NotImplementedException();
        }

        public void Exit(string invocationId, object returnValue)
        {
            throw new NotImplementedException();
        }
    }
}
