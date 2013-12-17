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

using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;

namespace Microsoft.WindowsAzure.Common.Tracing.Etw
{
    /// <summary>
    /// Class that inherits from EventSource and is used as a data model for ETW events.
    /// </summary>
    [EventSource(Name = "Microsoft-WindowsAzure")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Internal class used by ETW engine to generate data model.")]
    internal sealed class CloudTracingEventSource : EventSource
    {
        private static CloudTracingEventSource _log;

        public static CloudTracingEventSource Log
        {
            get
            {
                if (_log == null)
                {
                    _log = new CloudTracingEventSource();
                }
                return _log;
            }
        }

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

        [Event(3, Level = EventLevel.Informational)]
        public void Enter(string InvocationId, string Instance, string Method, string Parameters)
        {
            WriteEvent(3, InvocationId, Instance, Method, Parameters);
        }

        [Event(4, Level = EventLevel.Informational)]
        public void SendRequest(string InvocationId, string Request)
        {
            WriteEvent(4, InvocationId, Request);
        }

        [Event(5, Level = EventLevel.Informational)]
        public void ReceiveResponse(string InvocationId, string Response)
        {
            WriteEvent(5, InvocationId, Response);
        }

        [Event(6, Level = EventLevel.Error)]
        public void Error(string InvocationId, string Exception)
        {
            WriteEvent(6, InvocationId, Exception);
        }

        [Event(7, Level = EventLevel.Informational)]
        public void Exit(string InvocationId, string ReturnValue)
        {
            this.WriteEvent(7, InvocationId, ReturnValue);
        }
    }
}
