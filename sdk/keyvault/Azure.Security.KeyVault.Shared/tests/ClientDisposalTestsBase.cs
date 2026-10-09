// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Tests
{
    public abstract class ClientDisposalTestsBase<TClient, TOptions>
        where TClient : class, IDisposable
        where TOptions : ClientOptions
    {
        protected static readonly Uri VaultUri = new("https://disposal.vault.azure.net");

        protected abstract TClient CreateClient(TokenCredential credential, TOptions options = null);

        protected abstract TOptions CreateOptions();

        protected abstract HttpPipeline GetPipeline(TClient client);

        [Test]
        public void DisposeReleasesOwnedTransportOnce([Values] bool explicitOptions, [Values] bool concurrent)
        {
            using DisposableCredential credential = new();
            using TClient client = CreateClient(credential, explicitOptions ? CreateOptions() : null);
            DefaultTransportLifetime lifetime = new(GetPipeline(client));
            lifetime.AssertAlive();

            DisposeRepeatedly(client, concurrent);

            lifetime.AssertDisposedOnce();
            Assert.That(credential.DisposeCount, Is.Zero);
        }

        [Test]
        public void DisposeDoesNotDisposeCallerTransportOrCredential()
        {
            using DisposableMockTransport transport = new();
            using DisposableCredential credential = new();
            TOptions options = CreateOptions();
            options.Transport = transport;
            using TClient first = CreateClient(credential, options);
            using TClient second = CreateClient(credential, options);
            Assert.That(GetTransport(GetPipeline(first)), Is.SameAs(transport));
            Assert.That(GetTransport(GetPipeline(second)), Is.SameAs(transport));
            Assert.That(ReadField<bool>(GetPipeline(first), "isTransportOwnedInternally"), Is.False);

            DisposeRepeatedly(first, concurrent: true);
            Assert.That(transport.DisposeCount, Is.Zero);
            Assert.That(credential.DisposeCount, Is.Zero);

            using Request request = GetPipeline(second).CreateRequest();
            request.Uri.Reset(VaultUri);
            using Response response = GetPipeline(second).SendRequest(request, CancellationToken.None);
            Assert.That(response.Status, Is.EqualTo(200));

            DisposeRepeatedly(second, concurrent: true);
            Assert.That(transport.DisposeCount, Is.Zero);
            Assert.That(credential.DisposeCount, Is.Zero);

            transport.Dispose();
            Assert.That(transport.DisposeCount, Is.EqualTo(1));
            Assert.That(Assert.Throws<ObjectDisposedException>(() => transport.CreateRequest()), Is.SameAs(transport.DisposedException));
        }

        [Test]
        public void DisposeDoesNotDisposeCallerHttpClient()
        {
            using HttpClient httpClient = new();
            using HttpClientTransport transport = new(httpClient);
            TOptions options = CreateOptions();
            options.Transport = transport;
            using TClient client = CreateClient(new MockCredential(), options);
            Assert.That(GetTransport(GetPipeline(client)), Is.SameAs(transport));

            DisposeRepeatedly(client, concurrent: true);

            Assert.DoesNotThrow(httpClient.CancelPendingRequests);
        }

        [Test]
        public void DisposeIsSafeForMockingConstructor()
        {
            TClient client = new Mock<TClient> { CallBase = true }.Object;
            Assert.DoesNotThrow(() => DisposeRepeatedly(client, concurrent: true));
        }

        protected static void DisposeRepeatedly(IDisposable client, bool concurrent = false)
        {
            if (concurrent)
            {
                Parallel.For(0, 16, _ => client.Dispose());
            }
            else
            {
                client.Dispose();
            }

            client.Dispose();
        }

        protected static T ReadField<T>(object instance, string name, Type declaringType = null)
        {
            FieldInfo field = (declaringType ?? instance.GetType()).GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.That(field, Is.Not.Null, $"Expected {name} on {instance.GetType()}.");
            return (T)field.GetValue(instance);
        }

        protected static HttpPipeline GetKeyVaultPipeline(object client) =>
            ReadField<HttpPipeline>(ReadField<object>(client, "_pipeline"), "_pipeline");

        protected static HttpPipelineTransport GetTransport(HttpPipeline pipeline) =>
            ReadField<HttpPipelineTransport>(pipeline, "_transport", typeof(HttpPipeline));

        protected sealed class DefaultTransportLifetime
        {
            private readonly HttpPipelineTransport _transport;
            private readonly object _clientWrapper;
            private readonly HttpClient _httpClient;

            public DefaultTransportLifetime(HttpPipeline pipeline)
            {
                Assert.That(pipeline, Is.InstanceOf<DisposableHttpPipeline>());
                Assert.That(ReadField<bool>(pipeline, "isTransportOwnedInternally"), Is.True);
                _transport = GetTransport(pipeline);
                if (_transport is HttpClientTransport)
                {
                    Assert.That(_transport, Is.Not.SameAs(HttpClientTransport.Shared));
                    _clientWrapper = ReadField<object>(_transport, "_clientWrapper");
                    _httpClient = ReadField<HttpClient>(_clientWrapper, "_client");
                }
                else
                {
#if NETFRAMEWORK
                    // This default transport has no disposable resources; do not change the process-wide transport switch.
                    Assert.That(_transport.GetType().FullName, Is.EqualTo("Azure.Core.Pipeline.HttpWebRequestTransport"));
                    Assert.That(_transport, Is.Not.InstanceOf<IDisposable>());
#else
                    Assert.Fail($"Unexpected default transport: {_transport.GetType()}.");
#endif
                }
            }

            public void AssertAlive()
            {
                if (_httpClient != null)
                {
                    Assert.DoesNotThrow(_httpClient.CancelPendingRequests);
                    Assert.That(ReadField<int>(_clientWrapper, "_refCount"), Is.EqualTo(1));
                }
                else
                {
                    using Request request = _transport.CreateRequest();
                    Assert.That(request, Is.Not.Null);
                }
            }

            public void AssertDisposedOnce()
            {
                if (_httpClient != null)
                {
                    Assert.Throws<ObjectDisposedException>(_httpClient.CancelPendingRequests);
                    // HttpClient.Dispose is idempotent, but an extra pipeline disposal incorrectly releases the wrapper again.
                    Assert.That(ReadField<int>(_clientWrapper, "_refCount"), Is.Zero);
                }
                else
                {
                    Assert.That(_transport, Is.Not.InstanceOf<IDisposable>());
                }
            }
        }

        protected sealed class ResponsePolicy : HttpPipelinePolicy
        {
            private readonly Func<Request, Response> _responseFactory;

            public ResponsePolicy(Func<Request, Response> responseFactory) => _responseFactory = responseFactory;

            public int RequestCount { get; private set; }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                RequestCount++;
                message.Response = _responseFactory(message.Request);
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                Process(message, pipeline);
                return default;
            }
        }

        protected sealed class DisposableMockTransport : MockTransport, IDisposable
        {
            private int _disposeCount;

            public DisposableMockTransport() : base(_ => new MockResponse(200))
            {
            }

            public int DisposeCount => _disposeCount;

            public ObjectDisposedException DisposedException { get; } = new(nameof(DisposableMockTransport));

            public override Request CreateRequest()
            {
                if (DisposeCount != 0)
                {
                    throw DisposedException;
                }

                return base.CreateRequest();
            }

            public void Dispose() => Interlocked.Increment(ref _disposeCount);
        }

        private sealed class DisposableCredential : MockCredential, IDisposable
        {
            private int _disposeCount;

            public int DisposeCount => _disposeCount;

            public void Dispose() => Interlocked.Increment(ref _disposeCount);
        }
    }
}
