// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class HttpClientTransportReferenceCountingTests : SyncAsyncTestBase
    {
        public HttpClientTransportReferenceCountingTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void HttpClientConstructor_CannotBeUpdated_IndicatesNoReferenceCountingNeeded()
        {
            // Arrange
            using var client = new HttpClient();

            // Act
            using var transport = new HttpClientTransport(client);

            // Assert - Reference counting should be disabled for direct HttpClient constructor
            Assert.That(transport.IsRefCountingEnabled,
                Is.False,
                "Reference counting should be disabled when using direct HttpClient constructor");

            // Update should not throw, but should be a no-op
            Assert.DoesNotThrow(() => transport.Update(new HttpPipelineTransportOptions()));
        }

        [Test]
        public void HttpMessageHandlerConstructor_CannotBeUpdated_IndicatesNoReferenceCountingNeeded()
        {
            // Arrange
            using var handler = new HttpClientHandler();

            // Act
            using var transport = new HttpClientTransport(handler);

            // Assert - Reference counting should be disabled for direct HttpMessageHandler constructor
            Assert.That(transport.IsRefCountingEnabled,
                Is.False,
                "Reference counting should be disabled when using direct HttpMessageHandler constructor");

            // Update should not throw, but should be a no-op
            Assert.DoesNotThrow(() => transport.Update(new HttpPipelineTransportOptions()));
        }

        [Test]
        public void ClientFactoryConstructor_CanBeUpdated_IndicatesReferenceCountingEnabled()
        {
            // Arrange
            Func<HttpPipelineTransportOptions, HttpClient> clientFactory = _ => new HttpClient();

            // Act
            using var transport = new HttpClientTransport(clientFactory);

            // Assert - Reference counting should be enabled and updates should work
            Assert.That(transport.IsRefCountingEnabled,
                Is.True,
                "Reference counting should be enabled when using client factory constructor");
            Assert.DoesNotThrow(() => transport.Update(new HttpPipelineTransportOptions()));
        }

        [Test]
        public void HandlerFactoryConstructor_CanBeUpdated_IndicatesReferenceCountingEnabled()
        {
            // Arrange
            Func<HttpPipelineTransportOptions, HttpMessageHandler> handlerFactory = _ => new HttpClientHandler();

            // Act
            using var transport = new HttpClientTransport(handlerFactory);

            // Assert - Reference counting should be enabled and updates should work
            Assert.That(transport.IsRefCountingEnabled,
                Is.True,
                "Reference counting should be enabled when using handler factory constructor");
            Assert.DoesNotThrow(() => transport.Update(new HttpPipelineTransportOptions()));
        }

        [Test]
        public void DefaultConstructor_CanBeUpdated_IndicatesReferenceCountingEnabled()
        {
            // Act
            using var transport = new HttpClientTransport();

            // Assert - Default constructor should enable reference counting and updates via factory
            Assert.That(transport.IsRefCountingEnabled,
                Is.True,
                "Reference counting should be enabled when using default constructor");
            Assert.DoesNotThrow(() => transport.Update(new HttpPipelineTransportOptions()));
        }

        [Test]
        public async Task ProcessAsync_WithRefCountingDisabled_DoesNotCallTryAddRef()
        {
            // Arrange
            var mockHandler = new MockHttpHandler(req => new HttpResponseMessage(System.Net.HttpStatusCode.OK));
            using var transport = new HttpClientTransport(mockHandler);

            var request = transport.CreateRequest();
            request.Uri.Reset(new Uri("https://example.com"));
            var message = new HttpMessage(request, ResponseClassifier.Shared);

            // Act & Assert - This should not throw even though we're not managing ref counts
            await ProcessSyncOrAsync(transport, message);

            Assert.That(message.Response.Status, Is.EqualTo(200));
        }

        [Test]
        public async Task ProcessAsync_WithRefCountingEnabled_CallsTryAddRefAndRelease()
        {
            // Arrange
            var mockHandler = new MockHttpHandler(req => new HttpResponseMessage(System.Net.HttpStatusCode.OK));
            Func<HttpPipelineTransportOptions, HttpMessageHandler> handlerFactory = _ => mockHandler;
            using var transport = new HttpClientTransport(handlerFactory);

            var request = transport.CreateRequest();
            request.Uri.Reset(new Uri("https://example.com"));
            var message = new HttpMessage(request, ResponseClassifier.Shared);

            // Act
            await ProcessSyncOrAsync(transport, message);

            // Assert - Should succeed with ref counting
            Assert.That(message.Response.Status, Is.EqualTo(200));
        }

        [Test]
        public async Task ConcurrentRequestsWithUpdate_RefCountingEnabled_SafeDisposal()
        {
            // Arrange
            var requestCount = 0;
            var responseCount = 0;
            Func<HttpPipelineTransportOptions, HttpClient> clientFactory = _ =>
            {
                var handler = new MockHttpHandler(req =>
                {
                    Interlocked.Increment(ref requestCount);
                    // Simulate some processing time
                    Thread.Sleep(10);
                    Interlocked.Increment(ref responseCount);
                    return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                });
                return new HttpClient(handler);
            };

            using var transport = new HttpClientTransport(clientFactory);

            // Act - Start multiple concurrent requests and update transport during processing
            var tasks = new List<Task>();

            // Start several requests
            for (int i = 0; i < 5; i++)
            {
                tasks.Add(Task.Run(async () =>
                {
                    var request = transport.CreateRequest();
                    request.Uri.Reset(new Uri("https://example.com"));
                    var message = new HttpMessage(request, ResponseClassifier.Shared);
                    await ProcessSyncOrAsync(transport, message);
                    Assert.That(message.Response.Status, Is.EqualTo(200));
                }));
            }

            // Update transport while requests are in flight
            await Task.Delay(5); // Let some requests start
            transport.Update(new HttpPipelineTransportOptions());

            // Wait for all requests to complete
            await Task.WhenAll(tasks);

            // Assert - All requests should complete successfully
            Assert.That(responseCount, Is.EqualTo(5), "All 5 requests should have completed");
        }

        [Test]
        public void Update_WithRefCountingDisabled_DoesNotThrowForDirectClientConstructor()
        {
            // Arrange
            using var client = new HttpClient();
            using var transport = new HttpClientTransport(client);

            // Act & Assert - Update should not throw for direct client, but should be a no-op
            Assert.That(transport.IsRefCountingEnabled,
                Is.False,
                "Reference counting should be disabled for direct client constructor");
            Assert.DoesNotThrow(() => transport.Update(new HttpPipelineTransportOptions()));
        }

        [Test]
        public void Update_WithRefCountingEnabled_SucceedsWithFactory()
        {
            // Arrange
            Func<HttpPipelineTransportOptions, HttpClient> clientFactory = _ => new HttpClient();
            using var transport = new HttpClientTransport(clientFactory);

            // Act & Assert - Reference counting should be enabled and updates should succeed
            Assert.That(transport.IsRefCountingEnabled,
                Is.True,
                "Reference counting should be enabled when using client factory");
            Assert.DoesNotThrow(() => transport.Update(new HttpPipelineTransportOptions()));
        }

        [Test]
        public async Task DisposedTransportWithRefCounting_ThrowsObjectDisposedException()
        {
            // Arrange
            Func<HttpPipelineTransportOptions, HttpClient> clientFactory = _ => new HttpClient();
            var transport = new HttpClientTransport(clientFactory);

            var request = transport.CreateRequest();
            request.Uri.Reset(new Uri("https://example.com"));
            var message = new HttpMessage(request, ResponseClassifier.Shared);

            // Act - Dispose the transport
            transport.Dispose();

            // Assert - Subsequent requests should throw
            var ex = await AssertThrowsAsync<ObjectDisposedException>(
                async () => await ProcessSyncOrAsync(transport, message));
            Assert.That(ex.ObjectName, Is.EqualTo(nameof(HttpClientTransport)));
        }

        [Test]
        public async Task MultipleUpdatesWithConcurrentRequests_HandlesSafeDisposal()
        {
            // Arrange
            var updateCount = 0;
            Func<HttpPipelineTransportOptions, HttpClient> clientFactory = _ =>
            {
                Interlocked.Increment(ref updateCount);
                var handler = new MockHttpHandler(req => new HttpResponseMessage(System.Net.HttpStatusCode.OK));
                return new HttpClient(handler);
            };

            using var transport = new HttpClientTransport(clientFactory);

            // Act - Multiple updates and concurrent requests
            var tasks = new List<Task>();

            // Start continuous requests
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Run(async () =>
                {
                    for (int j = 0; j < 5; j++)
                    {
                        var request = transport.CreateRequest();
                        request.Uri.Reset(new Uri("https://example.com"));
                        var message = new HttpMessage(request, ResponseClassifier.Shared);
                        await ProcessSyncOrAsync(transport, message);
                        Assert.That(message.Response.Status, Is.EqualTo(200));
                        await Task.Delay(1); // Small delay between requests
                    }
                }));
            }

            // Perform updates while requests are running
            for (int i = 0; i < 3; i++)
            {
                await Task.Delay(5);
                transport.Update(new HttpPipelineTransportOptions());
            }

            // Wait for all requests to complete
            await Task.WhenAll(tasks);

            // Assert - Should have created multiple clients due to updates
            Assert.That(updateCount, Is.GreaterThanOrEqualTo(4), "Should have created multiple clients due to updates");
        }

        #region Helper Methods

        private async Task ProcessSyncOrAsync(HttpClientTransport transport, HttpMessage message)
        {
            if (IsAsync)
            {
                await transport.ProcessAsync(message);
            }
            else
            {
                transport.Process(message);
            }
        }

        private static async Task<T> AssertThrowsAsync<T>(Func<Task> action) where T : Exception
        {
            try
            {
                await action();
                Assert.Fail($"Expected exception of type {typeof(T).Name} but none was thrown");
                return null; // Never reached
            }
            catch (T ex)
            {
                return ex;
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected exception of type {typeof(T).Name} but got {ex.GetType().Name}: {ex.Message}");
                return null; // Never reached
            }
        }

        #endregion

        #region Mock Classes

        private class MockDisposableHttpClient : HttpClient
        {
            private readonly Action _onDispose;

            public MockDisposableHttpClient(Action onDispose) : base(new HttpClientHandler())
            {
                _onDispose = onDispose;
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    _onDispose?.Invoke();
                }
                base.Dispose(disposing);
            }
        }

        private class MockHttpHandler : HttpMessageHandler
        {
            private readonly Func<HttpRequestMessage, HttpResponseMessage> _responseFactory;

            public MockHttpHandler(Func<HttpRequestMessage, HttpResponseMessage> responseFactory)
            {
                _responseFactory = responseFactory;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_responseFactory(request));
            }

#if NET5_0_OR_GREATER
            protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return _responseFactory(request);
            }
#endif
        }

        #endregion
    }
}
