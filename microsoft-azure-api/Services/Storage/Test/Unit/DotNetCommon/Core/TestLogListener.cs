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

namespace Microsoft.WindowsAzure.Storage.Core
{
    public partial class TestLogListener : TraceListener
    {
        private LogLevel currentLevel;

        public override void Write(string message)
        {
            string[] splittedMessage = message.Split(' ', ':');
            if (splittedMessage[0].Equals(Constants.LogSourceName))
            {
                TraceEventType level;
                if (!Enum.TryParse(splittedMessage[1], out level))
                {
                    throw new InvalidOperationException();
                }

                this.currentLevel = TestLogListener.MapLogLevel(level);
            }
        }

        public override void WriteLine(string message)
        {
            if (this.currentLevel != LogLevel.Off)
            {
                TestLogListener.ProcessMessage(this.currentLevel, message);
                this.currentLevel = LogLevel.Off;
            }
        }

        private static LogLevel MapLogLevel(TraceEventType level)
        {
            switch (level)
            {
                case TraceEventType.Error:
                    return LogLevel.Error;

                case TraceEventType.Warning:
                    return LogLevel.Warning;

                case TraceEventType.Information:
                    return LogLevel.Informational;

                case TraceEventType.Verbose:
                    return LogLevel.Verbose;

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
