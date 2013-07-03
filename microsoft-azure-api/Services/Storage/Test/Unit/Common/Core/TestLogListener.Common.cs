// -----------------------------------------------------------------------------------------
// <copyright file="TestLogListener.Common.cs" company="Microsoft">
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

using System;
using System.Collections.Generic;
using System.Threading;

namespace Microsoft.WindowsAzure.Storage.Core
{
    public partial class TestLogListener
    {
#if !WINDOWS_PHONE
        private const int LogEntryFieldCount = 2;

        private static IList<string> requestIDs = new List<string>();
        private static volatile int errorCount = 0;
        private static volatile int warningCount = 0;
        private static volatile int informationalCount = 0;
        private static volatile int verboseCount = 0;
        private static volatile bool isCollecting = false;

        internal static string LastRequestID
        {
            get
            {
                lock (TestLogListener.requestIDs)
                {
                    return TestLogListener.requestIDs[TestLogListener.requestIDs.Count - 1];
                }
            }
        }

        internal static int RequestCount
        {
            get
            {
                lock (TestLogListener.requestIDs)
                {
                    return TestLogListener.requestIDs.Count;
                }
            }
        }

        internal static int ErrorCount
        {
            get
            {
                return TestLogListener.errorCount;
            }
        }

        internal static int WarningCount
        {
            get
            {
                return TestLogListener.warningCount;
            }
        }

        internal static int InformationalCount
        {
            get
            {
                return TestLogListener.informationalCount;
            }
        }

        internal static int VerboseCount
        {
            get
            {
                return TestLogListener.verboseCount;
            }
        }

        internal static void Start()
        {
            TestLogListener.isCollecting = true;
        }

        internal static void Restart()
        {
            TestLogListener.Stop();

            lock (TestLogListener.requestIDs)
            {
                TestLogListener.requestIDs.Clear();
                TestLogListener.errorCount = 0;
                TestLogListener.warningCount = 0;
                TestLogListener.informationalCount = 0;
                TestLogListener.verboseCount = 0;
            }

            TestLogListener.Start();
        }

        internal static void Stop()
        {
            TestLogListener.isCollecting = false;
        }

        private static void ProcessMessage(LogLevel level, string message)
        {
            if (!TestLogListener.isCollecting)
            {
                return;
            }

            string[] line = message.Split(new char[] { ':' }, TestLogListener.LogEntryFieldCount);
            if (line.Length == TestLogListener.LogEntryFieldCount)
            {
                lock (TestLogListener.requestIDs)
                {
                    if (!TestLogListener.requestIDs.Contains(line[0]))
                    {
                        TestLogListener.requestIDs.Add(line[0]);
                    }

                    switch (level)
                    {
                        case LogLevel.Error:
                            TestLogListener.errorCount++;
                            break;

                        case LogLevel.Warning:
                            TestLogListener.warningCount++;
                            break;

                        case LogLevel.Informational:
                            TestLogListener.informationalCount++;
                            break;

                        case LogLevel.Verbose:
                            TestLogListener.verboseCount++;
                            break;

                        default:
                            throw new InvalidOperationException(message);
                    }
                }
            }
            else
            {
                throw new InvalidOperationException(message);
            }
        }        
#endif
    }
}
