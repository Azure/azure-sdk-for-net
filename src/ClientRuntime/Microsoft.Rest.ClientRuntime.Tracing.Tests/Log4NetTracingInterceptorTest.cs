// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.Rest.Tracing.Log4Net;
using Xunit;

namespace Microsoft.Rest.ClientRuntime.Tracing.Tests
{
    public class Log4NetTracingInterceptorTest
    {
        private const string logFileName = "log-file.txt";

        [Fact]
        public void LogsConfiguration()
        {
            Log4NetTracingInterceptor logger = new Log4NetTracingInterceptor("Microsoft.Rest.ClientRuntime.Tracing.Tests.dll.config");
            string expected = "DEBUG - Configuration: source=sourceName, name=Name, value=Value\r\n";
            logger.Configuration("sourceName", "Name", "Value");
            Assert.Equal(expected, File.ReadAllText(logFileName));
        }

        [Fact]
        public void LogsInformation()
        {
            Log4NetTracingInterceptor logger = new Log4NetTracingInterceptor("Microsoft.Rest.ClientRuntime.Tracing.Tests.dll.config");
            string infoMessage = "This is expected message";
            string expected = string.Format("INFO - {0}\r\n", infoMessage);
            logger.Information(infoMessage);
            Assert.Equal(expected, File.ReadAllText(logFileName));
        }

        [Fact]
        public void LogsEnter()
        {
            Log4NetTracingInterceptor logger = new Log4NetTracingInterceptor("Microsoft.Rest.ClientRuntime.Tracing.Tests.dll.config");
            string invocationId = "1234";
            object instance = "I'm an object";
            string method = "getData";
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            string parametersLog = "{}";
            string expected =
                string.Format("DEBUG - invocationId: {0}\r\ninstance: {1}\r\nmethod: {2}\r\nparameters: {3}\r\n",
                    invocationId, instance, method, parametersLog);
            logger.EnterMethod(invocationId, instance, method, parameters);
            Assert.Equal(expected, File.ReadAllText(logFileName));
        }

        [Fact]
        public void LogsRequest()
        {
            Log4NetTracingInterceptor logger = new Log4NetTracingInterceptor("Microsoft.Rest.ClientRuntime.Tracing.Tests.dll.config");
            string invocationId = "12345";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://azuresdk.com");
            string expected = string.Format("DEBUG - invocationId: {0}\r\nrequest: {1}\r\n", invocationId,
                request.AsFormattedString());
            logger.SendRequest(invocationId, request);
            string actual = File.ReadAllText(logFileName);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LogsResponse()
        {
            Log4NetTracingInterceptor logger = new Log4NetTracingInterceptor("Microsoft.Rest.ClientRuntime.Tracing.Tests.dll.config");
            string invocationId = "12345";
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Accepted);
            string expected = string.Format("DEBUG - invocationId: {0}\r\nresponse: {1}\r\n", invocationId,
                response.AsFormattedString());
            logger.ReceiveResponse(invocationId, response);
            string actual = File.ReadAllText(logFileName);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LogsError()
        {
            Log4NetTracingInterceptor logger = new Log4NetTracingInterceptor("Microsoft.Rest.ClientRuntime.Tracing.Tests.dll.config");
            string invocationId = "12345";
            var exception = new HttpOperationException("I'm a cloud exception!");
            string expected = string.Format("ERROR - invocationId: {0}\r\n{1}\r\n", invocationId, exception.ToString());
            logger.TraceError(invocationId, exception);
            string actual = File.ReadAllText(logFileName);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LogsExit()
        {
            Log4NetTracingInterceptor logger = new Log4NetTracingInterceptor("Microsoft.Rest.ClientRuntime.Tracing.Tests.dll.config");
            string invocationId = "12345";
            string returnValue = "bye bye!";
            string expected = string.Format("DEBUG - Exit with invocation id {0}, the return value is {1}\r\n",
                invocationId, returnValue);
            logger.ExitMethod(invocationId, returnValue);
            string actual = File.ReadAllText(logFileName);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LogsNullConfiguration()
        {
            Log4NetTracingInterceptor logger = new Log4NetTracingInterceptor("Microsoft.Rest.ClientRuntime.Tracing.Tests.dll.config");
            string expected = "DEBUG - Configuration: source=, name=, value=\r\n";
            logger.Configuration(null, null, null);
            Assert.Equal(expected, File.ReadAllText(logFileName));
        }

        [Fact]
        public void LogsNullInformation()
        {
            Log4NetTracingInterceptor logger = new Log4NetTracingInterceptor("Microsoft.Rest.ClientRuntime.Tracing.Tests.dll.config");
            string infoMessage = null;
            string expected = string.Format("INFO - {0}\r\n", infoMessage);
            logger.Information(infoMessage);
            Assert.Equal(expected, File.ReadAllText(logFileName));
        }

        [Fact]
        public void LogsNullEnter()
        {
            Log4NetTracingInterceptor logger = new Log4NetTracingInterceptor("Microsoft.Rest.ClientRuntime.Tracing.Tests.dll.config");
            string invocationId = null;
            object instance = null;
            string method = null;
            IDictionary<string, object> parameters = null;
            string parametersLog = "{}";
            string expected =
                string.Format("DEBUG - invocationId: {0}\r\ninstance: {1}\r\nmethod: {2}\r\nparameters: {3}\r\n",
                    invocationId, instance, method, parametersLog);
            logger.EnterMethod(invocationId, instance, method, parameters);
            Assert.Equal(expected, File.ReadAllText(logFileName));
        }

        [Fact]
        public void LogsNullRequest()
        {
            Log4NetTracingInterceptor logger = new Log4NetTracingInterceptor("Microsoft.Rest.ClientRuntime.Tracing.Tests.dll.config");
            string invocationId = null;
            HttpRequestMessage request = null;
            string expected = "DEBUG - invocationId: \r\nrequest: \r\n";
            logger.SendRequest(invocationId, request);
            Assert.Equal(expected, File.ReadAllText(logFileName));
        }

        [Fact]
        public void LogsNullResponse()
        {
            Log4NetTracingInterceptor logger = new Log4NetTracingInterceptor("Microsoft.Rest.ClientRuntime.Tracing.Tests.dll.config");
            string invocationId = null;
            HttpResponseMessage response = null;
            string expected = "DEBUG - invocationId: \r\nresponse: \r\n";
            logger.ReceiveResponse(invocationId, response);
            Assert.Equal(expected, File.ReadAllText(logFileName));
        }

        [Fact]
        public void LogsNullError()
        {
            Log4NetTracingInterceptor logger = new Log4NetTracingInterceptor("Microsoft.Rest.ClientRuntime.Tracing.Tests.dll.config");
            string invocationId = null;
            string expected = string.Format("ERROR - invocationId: \r\n", invocationId, null);
            logger.TraceError(invocationId, null);
            string actual = File.ReadAllText(logFileName);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LogsNullExit()
        {
            Log4NetTracingInterceptor logger = new Log4NetTracingInterceptor("Microsoft.Rest.ClientRuntime.Tracing.Tests.dll.config");
            string invocationId = null;
            string returnValue = null;
            string expected = string.Format("DEBUG - Exit with invocation id {0}, the return value is {1}\r\n",
                invocationId, returnValue);
            logger.ExitMethod(invocationId, returnValue);
            string actual = File.ReadAllText(logFileName);
            Assert.Equal(expected, actual);
        }
    }
}