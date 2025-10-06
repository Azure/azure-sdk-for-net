// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Messaging.ServiceBus.Administration;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Management
{
    [TestFixture]
    public class RequestResponseTests
    {
        private readonly HttpRequestAndResponse _requestResponse;
        public RequestResponseTests()
        {
            var options = new ServiceBusAdministrationClientOptions();
            var pipeline = HttpPipelineBuilder.Build(options);
            _requestResponse = new HttpRequestAndResponse(pipeline, new ClientDiagnostics(options), null, "fakeNamespace", ServiceBusAdministrationClientOptions.ServiceVersion.V2017_04, -1, true);
        }

        [Test]
        public void ThrowsUnauthorizedOn401()
        {
            try
            {
                MockResponse response = new MockResponse((int)HttpStatusCode.Unauthorized);
                _requestResponse.ThrowIfRequestFailed(new MockRequest(), response);
            }
            catch (UnauthorizedAccessException ex)
            {
                var inner = (RequestFailedException)ex.InnerException;
                Assert.AreEqual((int)HttpStatusCode.Unauthorized, inner.Status);
                return;
            }
            Assert.Fail($"Expected exception not thrown");
        }

        [Test]
        public void ThrowsMessagingEntityNotFoundOn404()
        {
            try
            {
                MockResponse response = new MockResponse((int)HttpStatusCode.NotFound);
                _requestResponse.ThrowIfRequestFailed(new MockRequest(), response);
            }
            catch (ServiceBusException ex)
            {
                Assert.AreEqual(ServiceBusFailureReason.MessagingEntityNotFound, ex.Reason);
                var inner = (RequestFailedException)ex.InnerException;
                Assert.AreEqual((int)HttpStatusCode.NotFound, inner.Status);
                return;
            }
            Assert.Fail("No exception!");
        }

        [Test]
        public void ThrowsMessagingEntityAlreadyExistsOnCreateConflict()
        {
            try
            {
                MockResponse response = new MockResponse((int)HttpStatusCode.Conflict);
                _requestResponse.ThrowIfRequestFailed(new MockRequest() { Method = RequestMethod.Put }, response);
            }
            catch (ServiceBusException ex)
            {
                Assert.AreEqual(ServiceBusFailureReason.MessagingEntityAlreadyExists, ex.Reason);
                Assert.IsFalse(ex.IsTransient);
                var inner = (RequestFailedException)ex.InnerException;
                Assert.AreEqual((int)HttpStatusCode.Conflict, inner.Status);
                return;
            }
            Assert.Fail("No exception!");
        }

        [Test]
        public void ThrowsGeneralErrorOnUpdateConflict()
        {
            try
            {
                MockResponse response = new MockResponse((int)HttpStatusCode.Conflict);
                var request = new MockRequest() { Method = RequestMethod.Put };
                request.Headers.Add("If-Match", "*");
                _requestResponse.ThrowIfRequestFailed(request, response);
            }
            catch (ServiceBusException ex)
            {
                Assert.AreEqual(ServiceBusFailureReason.GeneralError, ex.Reason);
                Assert.IsTrue(ex.IsTransient);
                var inner = (RequestFailedException)ex.InnerException;
                Assert.AreEqual((int)HttpStatusCode.Conflict, inner.Status);
                return;
            }
            Assert.Fail("No exception!");
        }

        [Test]
        public void ThrowsGeneralErrorOnDeleteConflict()
        {
            try
            {
                MockResponse response = new MockResponse((int)HttpStatusCode.Conflict);
                var request = new MockRequest() { Method = RequestMethod.Delete };
                _requestResponse.ThrowIfRequestFailed(request, response);
            }
            catch (ServiceBusException ex)
            {
                Assert.AreEqual(ServiceBusFailureReason.GeneralError, ex.Reason);
                Assert.IsTrue(ex.IsTransient);
                var inner = (RequestFailedException)ex.InnerException;
                Assert.AreEqual((int)HttpStatusCode.Conflict, inner.Status);
                return;
            }
            Assert.Fail("No exception!");
        }

        [Test]
        public void ThrowsServiceBusyOnServiceUnavailable()
        {
            try
            {
                MockResponse response = new MockResponse((int)HttpStatusCode.ServiceUnavailable);
                var request = new MockRequest() { Method = RequestMethod.Delete };
                _requestResponse.ThrowIfRequestFailed(request, response);
            }
            catch (ServiceBusException ex)
            {
                Assert.AreEqual(ServiceBusFailureReason.ServiceBusy, ex.Reason);
                Assert.IsTrue(ex.IsTransient);
                var inner = (RequestFailedException)ex.InnerException;
                Assert.AreEqual((int)HttpStatusCode.ServiceUnavailable, inner.Status);
                return;
            }
            Assert.Fail("No exception!");
        }

        [Test]
        public void ThrowsArgumentExceptionOnBadRequest()
        {
            try
            {
                MockResponse response = new MockResponse((int)HttpStatusCode.BadRequest);
                var request = new MockRequest() { Method = RequestMethod.Put };
                _requestResponse.ThrowIfRequestFailed(request, response);
            }
            catch (ArgumentException ex)
            {
                var inner = (RequestFailedException)ex.InnerException;
                Assert.AreEqual((int)HttpStatusCode.BadRequest, inner.Status);
                return;
            }
            Assert.Fail("No exception!");
        }

        [Test]
        public void ThrowsInvalidOperationOnForbiddenSubcode()
        {
            try
            {
                MockResponse response = new MockResponse(
                    (int)HttpStatusCode.Forbidden,
                    AdministrationClientConstants.ForbiddenInvalidOperationSubCode);
                var request = new MockRequest() { Method = RequestMethod.Put };
                _requestResponse.ThrowIfRequestFailed(request, response);
            }
            catch (InvalidOperationException ex)
            {
                var inner = (RequestFailedException)ex.InnerException;
                Assert.AreEqual((int)HttpStatusCode.Forbidden, inner.Status);
                return;
            }
            Assert.Fail("No exception!");
        }

        [Test]
        public void ThrowsQuotaExceededOnForbiddenStatus()
        {
            try
            {
                MockResponse response = new MockResponse(
                    (int)HttpStatusCode.Forbidden);
                var request = new MockRequest() { Method = RequestMethod.Delete };
                _requestResponse.ThrowIfRequestFailed(request, response);
            }
            catch (ServiceBusException ex)
            {
                Assert.AreEqual(ServiceBusFailureReason.QuotaExceeded, ex.Reason);
                Assert.IsFalse(ex.IsTransient);
                var inner = (RequestFailedException)ex.InnerException;
                Assert.AreEqual((int)HttpStatusCode.Forbidden, inner.Status);
                return;
            }
            Assert.Fail("No exception!");
        }

        [Test]
        public void ThrowsGeneralFailureOnOtherError()
        {
            try
            {
                MockResponse response = new MockResponse(
                    429);
                var request = new MockRequest() { Method = RequestMethod.Put };
                _requestResponse.ThrowIfRequestFailed(request, response);
            }
            catch (ServiceBusException ex)
            {
                Assert.AreEqual(ServiceBusFailureReason.GeneralError, ex.Reason);
                Assert.IsTrue(ex.IsTransient);
                var inner = (RequestFailedException)ex.InnerException;
                Assert.AreEqual(429, inner.Status);
                return;
            }
            Assert.Fail("No exception!");
        }

        [Test]
        [TestCase(1)]
        [TestCase(80)]
        [TestCase(8989)]
        [TestCase(6335)]
        public void CustomPortIsPreserved(int port)
        {
            var options = new ServiceBusAdministrationClientOptions();
            var pipeline = HttpPipelineBuilder.Build(options);
            var requestResponse = new HttpRequestAndResponse(pipeline, new ClientDiagnostics(options), null, "fakeNamespace", ServiceBusAdministrationClientOptions.ServiceVersion.V2017_04, port, true);

            Assert.AreEqual(port, requestResponse.BuildDefaultUri("dummy").Port);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-200)]
        public void DefaultPortIsPreserved(int port)
        {
            var options = new ServiceBusAdministrationClientOptions();
            var pipeline = HttpPipelineBuilder.Build(options);
            var requestResponse = new HttpRequestAndResponse(pipeline, new ClientDiagnostics(options), null, "fakeNamespace", ServiceBusAdministrationClientOptions.ServiceVersion.V2017_04, port, true);

            var defaultPort = new UriBuilder("https://www.examplke.com").Uri.Port;
            Assert.AreEqual(defaultPort, requestResponse.BuildDefaultUri("dummy").Port);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void UseTlsIsHonored(bool useTls)
        {
            var options = new ServiceBusAdministrationClientOptions();
            var pipeline = HttpPipelineBuilder.Build(options);
            var requestResponse = new HttpRequestAndResponse(pipeline, new ClientDiagnostics(options), null, "fakeNamespace", ServiceBusAdministrationClientOptions.ServiceVersion.V2017_04, -1, useTls);

            var expectedScheme = useTls ? "https" : "http";
            Assert.AreEqual(expectedScheme, requestResponse.BuildDefaultUri("dummy").Scheme);
        }
    }
}
