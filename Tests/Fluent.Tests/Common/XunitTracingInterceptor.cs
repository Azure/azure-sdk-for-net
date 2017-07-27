// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using Microsoft.Rest;
using Xunit.Abstractions;

namespace Fluent.Tests.Common
{
    /// <summary>
    /// This class allows to output http requests and responses to console for tests. To use, add following code as test class constructor:
    ///
    /// public TestClass(ITestOutputHelper output)
    /// {
    ///     TestHelper.TestLogger = output;
    ///     ServiceClientTracing.IsEnabled = true;
    ///     ServiceClientTracing.AddTracingInterceptor(new XunitTracingInterceptor(output));
    /// }
    /// </summary>
    public class XunitTracingInterceptor : IServiceClientTracingInterceptor
    {
        private ITestOutputHelper _logger;

        public XunitTracingInterceptor(ITestOutputHelper output)
        {
            _logger = output;
        }

        public void Configuration(string source, string name, string value)
        {
        }

        public void EnterMethod(string invocationId, object instance, string method, IDictionary<string, object> parameters)
        {
        }

        public void ExitMethod(string invocationId, object returnValue)
        {
        }

        public void Information(string message)
        {
            _logger.WriteLine("INFO: " + message);
        }

        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
        {
            string requestAsString = (response == null ? string.Empty : response.AsFormattedString());
            _logger.WriteLine(string.Format(CultureInfo.InvariantCulture,
                "invocationId: {0}\r\nresponse: {1}", invocationId, requestAsString));
        }

        public void SendRequest(string invocationId, HttpRequestMessage request)
        {
            string requestAsString = (request == null ? string.Empty : request.AsFormattedString());
            _logger.WriteLine(string.Format(CultureInfo.InvariantCulture,
                "invocationId: {0}\r\nrequest: {1}", invocationId, requestAsString));
        }

        public void TraceError(string invocationId, Exception exception)
        {
            _logger.WriteLine("ERROR: invocationId: " + invocationId, exception);
        }
    }

}
