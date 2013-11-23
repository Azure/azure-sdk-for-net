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
using System.Diagnostics.Tracing;
using System.Net.Http;

namespace Microsoft.WindowsAzure.Common.Tracing.Etw
{
    [EventSource(Name = "Microsoft-WindowsAzure")]
    internal sealed class CloudTracingEventSource : EventSource
    {
        static public CloudTracingEventSource Log = new CloudTracingEventSource();

        private CloudTracingEventSource() { }

        [Event(1, Level = EventLevel.Informational)]
        public void Information(string Message)
        {
            WriteEvent(1, Message);
        }

        [Event(2, Level = EventLevel.Informational)]
        public void Configuration(string Source, string Name, string Value)
        {
            WriteEvent(2, Source, Name, Value);
        }

        public void Enter(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {

        }

        public void SendRequest(string invocationId, HttpRequestMessage request)
        {

        }

        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {

        }

        public void Error(string invocationId, Exception ex)
        {

        }

        public void Exit(string invocationId, object returnValue)
        {

        }
    }
}
