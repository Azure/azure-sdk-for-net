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
using System.Threading.Tasks;
using Microsoft.Diagnostics.Tracing;
using Microsoft.Diagnostics.Tracing.Session;
using Microsoft.WindowsAzure.Common.Tracing.Etw;
using Xunit;
using Xunit.Extensions;
using Microsoft.WindowsAzure.Common.Tracing.Log4Net;
using System.IO;

namespace Microsoft.WindowsAzure.Common.Tracing.Test
{
    public class Log4NetTracingInterceptorTest
    {
        private const string logFileName = "log-file.txt";

        [Fact]
        public void LogsConfiguration()
        {
            Log4NetTracingInterceptor logger = new Log4NetTracingInterceptor("app.config");
            string expected = "DEBUG - Configuration: source=sourceName, name=Name, value=Value\r\n";

            logger.Configuration("sourceName", "Name", "Value");

            Assert.Equal(expected, File.ReadAllText(logFileName));
        }

        [Fact]
        public void LogsInformation()
        {
            Log4NetTracingInterceptor logger = new Log4NetTracingInterceptor("app.config");
            string infoMessage = "This is expected message";
            string expected = string.Format("INFO - {0}\r\n", infoMessage);

            logger.Information(infoMessage);

            Assert.Equal(expected, File.ReadAllText(logFileName));
        }

        [Fact]
        public void LogsEnter()
        {
            Log4NetTracingInterceptor logger = new Log4NetTracingInterceptor("app.config");
            string invocationId = "1234";
            object instance = "I'm an object";
            string method = "getData";
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            string parametersLog = "{}";
            string expected = string.Format("DEBUG - invocationId: {0}\r\ninstance: {1}\r\nmethod: {2}\r\nparameters: {3}\r\n",
                invocationId, instance, method, parametersLog);

            logger.Enter(invocationId, instance, method, parameters);

            Assert.Equal(expected, File.ReadAllText(logFileName));
        }
    }
}
