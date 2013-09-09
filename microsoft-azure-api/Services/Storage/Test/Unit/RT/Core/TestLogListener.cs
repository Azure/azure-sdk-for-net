// -----------------------------------------------------------------------------------------
// <copyright file="TestLogListener.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;

namespace Microsoft.WindowsAzure.Storage.Core
{
    public partial class TestLogListener : EventListener
    {
        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            Debug.WriteLine(eventData.Payload[0]);
            TestLogListener.ProcessMessage(TestLogListener.MapLogLevel(eventData.Level), eventData.Payload[0].ToString());
        }

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            base.OnEventSourceCreated(eventSource);

            if (eventSource.Name.Equals(Constants.LogSourceName))
            {
                this.EnableEvents(eventSource, EventLevel.Verbose);
            }
        }

        private static LogLevel MapLogLevel(EventLevel level)
        {
            switch (level)
            {
                case EventLevel.Error:
                    return LogLevel.Error;

                case EventLevel.Warning:
                    return LogLevel.Warning;

                case EventLevel.Informational:
                    return LogLevel.Informational;

                case EventLevel.Verbose:
                    return LogLevel.Verbose;

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
