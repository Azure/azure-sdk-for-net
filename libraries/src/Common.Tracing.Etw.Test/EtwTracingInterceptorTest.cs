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

using Microsoft.Diagnostics.Tracing;
using Microsoft.Diagnostics.Tracing.Session;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace Microsoft.WindowsAzure.Common.Tracing.Etw.Test
{
    public class EtwTracingInterceptorTest : IDisposable
    {
        // Globally defined session is needed since we are running multiple traces
        private TraceEventSession eventSession;

        public EtwTracingInterceptorTest()
        {
            eventSession = new TraceEventSession(Guid.NewGuid().ToString());
            var eventSourceGuid = TraceEventProviders.GetEventSourceGuidFromName("Microsoft-WindowsAzure");
            eventSession.EnableProvider(eventSourceGuid);
        }

        [Theory]
        [InlineData("test")]
        [InlineData("")]
        [InlineData(null)]
        public void InformationLogsEventWithMessage(string message)
        {
            EtwTracingHelper("Information", new[] { "Message" },
                () =>
                {
                    EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                    etwTracer.Information(message);
                },
                (dict) =>
                {
                    message = message ?? string.Empty;

                    Assert.Equal(message, dict["Message"]);
                });
        }

        [Theory]
        [InlineData("test", "name", "value")]
        [InlineData("test", "name", "")]
        [InlineData(null, null, null)]
        public void ConfigurationLogsEventWithAllParameters(string source, string name, string value)
        {
            EtwTracingHelper("Configuration", new[] { "Source", "Name", "Value" },
                () =>
                {
                    EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                    etwTracer.Configuration(source, name, value);
                },
                (dict) =>
                {
                    source = source ?? string.Empty;
                    name = name ?? string.Empty;
                    value = value ?? string.Empty;

                    Assert.Equal(source, dict["Source"]);
                    Assert.Equal(name, dict["Name"]);
                    Assert.Equal(value, dict["Value"]);
                });
        }

        [Fact]
        public void EnterLogsEventWithNonNullParams()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["a"] = 1;
            parameters["b"] = "str";
            parameters["c"] = true;


            EtwTracingHelper("Enter", new[] { "InvocationId", "Instance", "Method", "Parameters" },
                () =>
                {
                    EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                    etwTracer.Enter("1", 23, "main", parameters);
                },
                (dict) =>
                {
                    Assert.Equal("1", dict["InvocationId"]);
                    Assert.Equal("23", dict["Instance"]);
                    Assert.Equal("main", dict["Method"]);
                    Assert.Equal("{a=1,b=str,c=True}", dict["Parameters"]);
                });
        }

        [Fact]
        public void EnterLogsEventWithNullParams()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["a"] = 1;
            parameters["b"] = "str";
            parameters["c"] = null;


            EtwTracingHelper("Enter", new[] { "InvocationId", "Instance", "Method", "Parameters" },
                () =>
                {
                    EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                    etwTracer.Enter("1", null, "main", parameters);
                },
                (dict) =>
                {
                    Assert.Equal("1", dict["InvocationId"]);
                    Assert.Equal("", dict["Instance"]);
                    Assert.Equal("main", dict["Method"]);
                    Assert.Equal("{a=1,b=str,c=}", dict["Parameters"]);
                });
        }

        [Fact]
        public void SendRequestLogsEventWithNonNullRequest()
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, "http://www.windowsazure.com/test");
            httpRequest.Headers.Add("x-ms-version", "2013-11-01");

            EtwTracingHelper("SendRequest", new[] { "InvocationId", "Request" },
                () =>
                {
                    EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                    etwTracer.SendRequest("1", httpRequest);
                },
                (dict) =>
                {
                    Assert.Equal("1", dict["InvocationId"]);
                    Assert.Contains("RequestUri: 'http://www.windowsazure.com/test'", dict["Request"]);
                    Assert.Contains("x-ms-version: 2013-11-01", dict["Request"]);
                });
        }

        [Fact]
        public void SendRequestLogsEventWithNullRequest()
        {
            EtwTracingHelper("SendRequest", new[] { "InvocationId", "Request" },
                () =>
                {
                    EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                    etwTracer.SendRequest(null, null);
                },
                (dict) =>
                {
                    Assert.Equal("", dict["InvocationId"]);
                    Assert.Equal("", dict["Request"]);
                });
        }

        [Fact]
        public void ReceiveResponseLogsEventWithNonNullRequest()
        {
            var httpRequest = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            httpRequest.Content = new StringContent("<body/>");

            EtwTracingHelper("ReceiveResponse", new[] { "InvocationId", "Response" },
                () =>
                {
                    EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                    etwTracer.ReceiveResponse("1", httpRequest);
                },
                (dict) =>
                {
                    Assert.Equal("1", dict["InvocationId"]);
                    Assert.Contains("<body/>", dict["Response"]);
                });
        }

        [Fact]
        public void ReceiveResponseLogsEventWithNullRequest()
        {
            EtwTracingHelper("ReceiveResponse", new[] { "InvocationId", "Response" },
                () =>
                {
                    EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                    etwTracer.ReceiveResponse(null, null);
                },
                (dict) =>
                {
                    Assert.Equal("", dict["InvocationId"]);
                    Assert.Equal("", dict["Response"]);
                });
        }

        [Fact]
        public void ExitLogsEventWithNonNullRequest()
        {
            EtwTracingHelper("Exit", new[] { "InvocationId", "ReturnValue" },
                () =>
                {
                    EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                    etwTracer.Exit("1", 5);
                },
                (dict) =>
                {
                    Assert.Equal("1", dict["InvocationId"]);
                    Assert.Equal("5", dict["ReturnValue"]);
                });
        }

        [Fact]
        public void ExitLogsEventWithNullRequest()
        {
            EtwTracingHelper("Exit", new[] { "InvocationId", "ReturnValue" },
                () =>
                {
                    EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                    etwTracer.Exit(null, null);
                },
                (dict) =>
                {
                    Assert.Equal("", dict["InvocationId"]);
                    Assert.Equal("", dict["ReturnValue"]);
                });
        }

        private void EtwTracingHelper(string eventName, string[] attributes, Action doAction, Action<Dictionary<string, string>> assertAction)
        {
            Dictionary<string, string> valuesFromEvent = new Dictionary<string, string>();
            Action<TraceEvent> eventDelegate = delegate(TraceEvent data)
            {
                if (data.EventName == eventName)
                {
                    foreach (var attributeName in attributes)
                    {
                        valuesFromEvent[attributeName] = data.PayloadByName(attributeName).ToString();
                    }
                    eventSession.Source.StopProcessing();
                }
            };

            eventSession.Source.Dynamic.All += eventDelegate;

            var task = Task.Run(() => eventSession.Source.Process());

            doAction();

            task.Wait();

            try
            {
                assertAction(valuesFromEvent);
            }
            finally
            {
                eventSession.Source.Dynamic.All -= eventDelegate;
            }
        }

        public void Dispose()
        {
            eventSession.Stop();
            eventSession.Dispose();
        }
    }
}
