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
        public async Task ThrowsUnauthorizedOn401()
        {
            try
            {
                MockResponse response = new MockResponse((int)HttpStatusCode.Unauthorized);
                await _requestResponse.ThrowIfRequestFailedAsync(new MockRequest(), response);
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
        public async Task ThrowsMessagingEntityNotFoundOn404()
        {
            try
            {
                MockResponse response = new MockResponse((int)HttpStatusCode.NotFound);
                await _requestResponse.ThrowIfRequestFailedAsync(new MockRequest(), response);
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
        public async Task ThrowsMessagingEntityAlreadyExistsOnCreateConflict()
        {
            try
            {
                MockResponse response = new MockResponse((int)HttpStatusCode.Conflict);
                await _requestResponse.ThrowIfRequestFailedAsync(new MockRequest() { Method = RequestMethod.Put }, response);
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
        public async Task ThrowsGeneralErrorOnUpdateConflict()
        {
            try
            {
                MockResponse response = new MockResponse((int)HttpStatusCode.Conflict);
                var request = new MockRequest() { Method = RequestMethod.Put };
                request.Headers.Add("If-Match", "*");
                await _requestResponse.ThrowIfRequestFailedAsync(request, response);
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
        public async Task ThrowsGeneralErrorOnDeleteConflict()
        {
            try
            {
                MockResponse response = new MockResponse((int)HttpStatusCode.Conflict);
                var request = new MockRequest() { Method = RequestMethod.Delete };
                await _requestResponse.ThrowIfRequestFailedAsync(request, response);
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
        public async Task ThrowsServiceBusyOnServiceUnavailable()
        {
            try
            {
                MockResponse response = new MockResponse((int)HttpStatusCode.ServiceUnavailable);
                var request = new MockRequest() { Method = RequestMethod.Delete };
                await _requestResponse.ThrowIfRequestFailedAsync(request, response);
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
        public async Task ThrowsArgumentExceptionOnBadRequest()
        {
            try
            {
                MockResponse response = new MockResponse((int)HttpStatusCode.BadRequest);
                var request = new MockRequest() { Method = RequestMethod.Put };
                await _requestResponse.ThrowIfRequestFailedAsync(request, response);
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
        public async Task ThrowsInvalidOperationOnForbiddenSubcode()
        {
            try
            {
                MockResponse response = new MockResponse(
                    (int)HttpStatusCode.Forbidden,
                    AdministrationClientConstants.ForbiddenInvalidOperationSubCode);
                var request = new MockRequest() { Method = RequestMethod.Put };
                await _requestResponse.ThrowIfRequestFailedAsync(request, response);
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
        public async Task ThrowsQuotaExceededOnForbiddenStatus()
        {
            try
            {
                MockResponse response = new MockResponse(
                    (int)HttpStatusCode.Forbidden);
                var request = new MockRequest() { Method = RequestMethod.Delete };
                await _requestResponse.ThrowIfRequestFailedAsync(request, response);
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
        public async Task ThrowsGeneralFailureOnOtherError()
        {
            try
            {
                MockResponse response = new MockResponse(
                    429);
                var request = new MockRequest() { Method = RequestMethod.Put };
                await _requestResponse.ThrowIfRequestFailedAsync(request, response);
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
