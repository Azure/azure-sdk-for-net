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
    public class RequestResponseTests
    {
        private readonly HttpRequestAndResponse _requestResponse;
        public RequestResponseTests()
        {
            var options = new ServiceBusAdministrationClientOptions();
            var pipeline = HttpPipelineBuilder.Build(options);
            _requestResponse = new HttpRequestAndResponse(pipeline, new ClientDiagnostics(options), null, "fakeNamespace", ServiceBusAdministrationClientOptions.ServiceVersion.V2017_04);
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
    }
}
