// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Diagnostics.Tracing;
using Microsoft.Diagnostics.Tracing.Session;
using Microsoft.Rest.Tracing.Etw;
using Xunit;

namespace Microsoft.Rest.ClientRuntime.Tracing.Tests
{
    internal class EtwTracingInterceptorTest : IDisposable
    {
        // Globally defined session is needed since we are running multiple traces
        private readonly TraceEventSession _eventSession;

        public EtwTracingInterceptorTest()
        {
            _eventSession = new TraceEventSession(Guid.NewGuid().ToString());
            var eventSourceGuid = TraceEventProviders.GetEventSourceGuidFromName("Microsoft-WindowsAzure");
            _eventSession.EnableProvider(eventSourceGuid);
        }

        public void Dispose()
        {
            _eventSession.Stop();
            _eventSession.Dispose();
        }

        [Theory]
        [InlineData("test")]
        [InlineData("")]
        [InlineData(null)]
        public void InformationLogsEventWithMessage(string message)
        {
            EtwTracingHelper("Information", new[] {"Message"},
                () =>
                {
                    EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                    etwTracer.Information(message);
                },
                dict =>
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
            EtwTracingHelper("Configuration", new[] {"Source", "Name", "Value"},
                () =>
                {
                    EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                    etwTracer.Configuration(source, name, value);
                },
                dict =>
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


            EtwTracingHelper("Enter", new[] {"InvocationId", "Instance", "Method", "Parameters"},
                () =>
                {
                    EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                    etwTracer.EnterMethod("1", 23, "main", parameters);
                },
                dict =>
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


            EtwTracingHelper("Enter", new[] {"InvocationId", "Instance", "Method", "Parameters"},
                () =>
                {
                    EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                    etwTracer.EnterMethod("1", null, "main", parameters);
                },
                dict =>
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

            EtwTracingHelper("SendRequest", new[] {"InvocationId", "Request"},
                () =>
                {
                    EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                    etwTracer.SendRequest("1", httpRequest);
                },
                dict =>
                {
                    Assert.Equal("1", dict["InvocationId"]);
                    Assert.Contains("RequestUri: 'http://www.windowsazure.com/test'", dict["Request"]);
                    Assert.Contains("x-ms-version: 2013-11-01", dict["Request"]);
                });
        }

        [Fact]
        public void SendRequestLogsEventWithNullRequest()
        {
            EtwTracingHelper("SendRequest", new[] {"InvocationId", "Request"},
                () =>
                {
                    EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                    etwTracer.SendRequest(null, null);
                },
                dict =>
                {
                    Assert.Equal("", dict["InvocationId"]);
                    Assert.Equal("", dict["Request"]);
                });
        }

        [Fact]
        public void ReceiveResponseLogsEventWithNonNullRequest()
        {
            using (var httpRequest = new HttpResponseMessage(System.Net.HttpStatusCode.OK))
            {
                httpRequest.Content = new StringContent("<body/>");

                EtwTracingHelper("ReceiveResponse", new[] {"InvocationId", "Response"},
                    () =>
                    {
                        EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                        if (httpRequest != null) etwTracer.ReceiveResponse("1", httpRequest);
                    },
                    dict =>
                    {
                        Assert.Equal("1", dict["InvocationId"]);
                        Assert.Contains("<body/>", dict["Response"]);
                    });
            }
        }

        [Fact]
        public void ReceiveResponseLogsEventWithNullRequest()
        {
            EtwTracingHelper("ReceiveResponse", new[] {"InvocationId", "Response"},
                () =>
                {
                    EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                    etwTracer.ReceiveResponse(null, null);
                },
                dict =>
                {
                    Assert.Equal("", dict["InvocationId"]);
                    Assert.Equal("", dict["Response"]);
                });
        }

        [Fact]
        public void ExitLogsEventWithNonNullRequest()
        {
            EtwTracingHelper("Exit", new[] {"InvocationId", "ReturnValue"},
                () =>
                {
                    EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                    etwTracer.ExitMethod("1", 5);
                },
                dict =>
                {
                    Assert.Equal("1", dict["InvocationId"]);
                    Assert.Equal("5", dict["ReturnValue"]);
                });
        }

        [Fact]
        public void ExitLogsEventWithNullRequest()
        {
            EtwTracingHelper("Exit", new[] {"InvocationId", "ReturnValue"},
                () =>
                {
                    EtwTracingInterceptor etwTracer = new EtwTracingInterceptor();
                    etwTracer.ExitMethod(null, null);
                },
                dict =>
                {
                    Assert.Equal("", dict["InvocationId"]);
                    Assert.Equal("", dict["ReturnValue"]);
                });
        }

        private void EtwTracingHelper(string eventName, string[] attributes, Action doAction,
            Action<Dictionary<string, string>> assertAction)
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
                    _eventSession.Source.StopProcessing();
                }
            };

            _eventSession.Source.Dynamic.All += eventDelegate;

#if NET45
            var task = Task.Run(() => _eventSession.Source.Process());
#else
            var task = TaskEx.Run(() => _eventSession.Source.Process());
#endif
            doAction();

            task.Wait();

            try
            {
                assertAction(valuesFromEvent);
            }
            finally
            {
                _eventSession.Source.Dynamic.All -= eventDelegate;
            }
        }
    }
}