// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;
using static Azure.Security.KeyVault.KeyVaultTransport;

namespace Azure.Security.KeyVault.Tests
{
    public class AutomaticTransportTests
    {
        internal static X509Certificate2 Certificate(bool distinct = false)
        {
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, distinct ? "transport-test-other.pfx" : "transport-test.pfx");
            string password = distinct ? "password" : null;
#if NET9_0_OR_GREATER
            return X509CertificateLoader.LoadPkcs12FromFile(path, password);
#else
            return new X509Certificate2(path, password);
#endif
        }

        [Test]
        public void DefaultFactoryBindsCertificateUsingCorePlatformDefaultsWithoutSending()
        {
            using X509Certificate2 certificate = Certificate();
            using var transport = new DefaultCertificateTransport(certificate);
            var owner = Field<HttpPipeline>(transport, "_owner");
            HttpPipelineTransport native = Field<HttpPipelineTransport>(owner, "_transport", typeof(HttpPipeline));
            using Request original = new TestOptions().Transport.CreateRequest();
            using Request bound = transport.CreateRequest();
            Assert.That(bound.GetType(), Is.EqualTo(original.GetType()));
            if (native is HttpClientTransport)
            {
                object wrapper = Field<object>(native, "_clientWrapper");
                HttpClient client = Field<HttpClient>(wrapper, "_client");
                HttpMessageHandler handler = Field<HttpMessageHandler>(client, "_handler", typeof(HttpMessageInvoker));
#if NET8_0_OR_GREATER
                if (handler is SocketsHttpHandler sockets)
                {
                    Assert.That(sockets.SslOptions.ClientCertificates, Has.Count.EqualTo(1));
                    Assert.That(sockets.SslOptions.ClientCertificates[0], Is.SameAs(certificate));
                    Assert.That(sockets.AllowAutoRedirect, Is.False);
                }
                else
#endif
                {
                    Assert.That(((HttpClientHandler)handler).ClientCertificates, Has.Count.EqualTo(1));
                    Assert.That(((HttpClientHandler)handler).ClientCertificates[0], Is.SameAs(certificate));
                    Assert.That(((HttpClientHandler)handler).AllowAutoRedirect, Is.False);
                }
                transport.Dispose();
                Assert.Throws<ObjectDisposedException>(client.CancelPendingRequests);
            }
#if NETFRAMEWORK
            else
            {
                var configure = Field<Action<HttpWebRequest>>(native, "_configureRequest");
                var request = (HttpWebRequest)WebRequest.Create("https://localhost");
                configure(request);
                Assert.That(request.ClientCertificates, Has.Count.EqualTo(1));
                Assert.That(request.ClientCertificates[0], Is.SameAs(certificate));
                request.Abort();
            }
#endif
            Assert.That(certificate.HasPrivateKey, Is.True);
        }

        private static T Field<T>(object instance, string name, Type declaringType = null) =>
            (T)(declaringType ?? instance.GetType()).GetField(name, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(instance);

        [Test]
        public void PoolReusesOnlyIdenticalCertificateGenerationsAndOwnsItsCopy()
        {
            using X509Certificate2 certificate = Certificate();
            using X509Certificate2 equalCertificate = new(certificate);
            var created = new List<BindingTransport>();
            DateTimeOffset now = DateTimeOffset.UtcNow;
            using var pool = Pool(c => Add(created, c), () => now);
            using (CertificateTransportPool.Lease first = pool.Acquire(certificate, default))
            using (CertificateTransportPool.Lease same = pool.Acquire(certificate, default))
            using (CertificateTransportPool.Lease equal = pool.Acquire(equalCertificate, default))
            {
                Assert.That(same.Transport, Is.SameAs(first.Transport));
                Assert.That(equal.Transport, Is.Not.SameAs(first.Transport));
                Assert.That(created, Has.Count.EqualTo(2));
                Assert.That(created[0].Certificate, Is.Not.SameAs(certificate));
                Assert.That(created[0].Certificate.HasPrivateKey, Is.True);
                now += TimeSpan.FromHours(1);
                pool.Sweep();
                Assert.That(created.All(t => t.DisposeCount == 0), Is.True);
            }
            now += TimeSpan.FromMinutes(3);
            pool.Sweep();
            Assert.That(created.All(t => t.DisposeCount == 1), Is.True);
            Assert.That(certificate.HasPrivateKey, Is.True);
            Assert.That(equalCertificate.HasPrivateKey, Is.True);
        }

        [Test]
        public void CapacityIncludesActiveTransportsAndCreationFailuresDoNotConsumeSlots()
        {
            using X509Certificate2 first = Certificate();
            using X509Certificate2 second = new(first);
            int attempts = 0;
            using var pool = Pool(c =>
            {
                if (++attempts == 1)
                    throw new IOException("creation failed");
                return new BindingTransport(c);
            }, capacity: 1);
            Assert.Throws<IOException>(() => pool.Acquire(first, default));
            using (CertificateTransportPool.Lease lease = pool.Acquire(first, default))
            {
                Assert.Throws<InvalidOperationException>(() => pool.Acquire(second, default));
                Assert.That(attempts, Is.EqualTo(2));
                using var canceled = new CancellationTokenSource();
                canceled.Cancel();
                Assert.Throws<OperationCanceledException>(() => pool.Acquire(first, canceled.Token));
                Assert.That(((BindingTransport)lease.Transport).DisposeCount, Is.Zero);
            }
            using CertificateTransportPool.Lease next = pool.Acquire(second, default);
            Assert.That(attempts, Is.EqualTo(3));
        }

        [Test]
        public void TimerReapsIdleEntriesWithoutClientDisposal()
        {
            using X509Certificate2 certificate = Certificate();
            var transport = new BindingTransport(certificate);
            long ticks = DateTimeOffset.UtcNow.Ticks;
            using var pool = new CertificateTransportPool(1, TimeSpan.FromMinutes(2), TimeSpan.FromMilliseconds(10),
                _ => transport, () => new DateTimeOffset(Interlocked.Read(ref ticks), TimeSpan.Zero));
            pool.Acquire(certificate, default).Dispose();
            Interlocked.Add(ref ticks, TimeSpan.FromMinutes(3).Ticks);
            Assert.That(SpinWait.SpinUntil(() => Volatile.Read(ref transport.DisposeCount) == 1, TimeSpan.FromSeconds(5)), Is.True);
        }

        [Test]
        public async Task TimerCleansCompletedPopRequestsAndPipelineRemainsUsable([Values] bool async)
        {
            using X509Certificate2 certificate = Certificate();
            var transports = new List<BindingTransport>();
            long ticks = DateTimeOffset.UtcNow.Ticks;
            using var pool = new CertificateTransportPool(1, TimeSpan.FromMinutes(2), TimeSpan.FromMilliseconds(10),
                c => Add(transports, c), () => new DateTimeOffset(Interlocked.Read(ref ticks), TimeSpan.Zero));
            HttpPipeline pipeline = Pipeline(pool);
            Assert.That(pipeline, Is.Not.InstanceOf<IDisposable>());

            using HttpMessage first = Message(pipeline, certificate);
            await Send(pipeline, first, async);
            BindingTransport retired = transports.Single();
            Assert.That(retired.DisposeCount, Is.Zero);
            Interlocked.Add(ref ticks, TimeSpan.FromMinutes(3).Ticks);
            Assert.That(SpinWait.SpinUntil(() => Volatile.Read(ref retired.DisposeCount) == 1, TimeSpan.FromSeconds(5)), Is.True);
            Assert.That(new StreamReader(first.Response.ContentStream).ReadToEnd(), Is.EqualTo("body"));
            Assert.That(certificate.HasPrivateKey, Is.True);

            using HttpMessage second = Message(pipeline, certificate);
            await Send(pipeline, second, async);
            Assert.That(second.Response.Status, Is.EqualTo(200));
            Assert.That(transports, Has.Count.EqualTo(2));
            BindingTransport replacement = transports[1];
            Assert.That(replacement, Is.Not.SameAs(retired));
            Interlocked.Add(ref ticks, TimeSpan.FromMinutes(3).Ticks);
            Assert.That(SpinWait.SpinUntil(() => Volatile.Read(ref replacement.DisposeCount) == 1, TimeSpan.FromSeconds(5)), Is.True);
            Assert.That(retired.DisposeCount, Is.EqualTo(1));
            Assert.That(certificate.HasPrivateKey, Is.True);
        }

        [Test]
        public void TimerErrorsAreObservedWithoutLoggingExceptionContents()
        {
            using var observed = new ManualResetEventSlim();
            int fail = 1;
            string observedText = null;
            using var listener = new AzureEventSourceListener((data, text) =>
            {
                if (data.EventSource.Name.EndsWith("-Transport", StringComparison.Ordinal) && data.EventId == 1)
                {
                    observedText = text;
                    observed.Set();
                }
            }, EventLevel.Warning);
            using var pool = new CertificateTransportPool(1, TimeSpan.FromMinutes(2), TimeSpan.FromMilliseconds(10),
                _ => throw new AssertionException("Unexpected creation"),
                () => Volatile.Read(ref fail) == 1 ? throw new IOException("sensitive") : DateTimeOffset.UtcNow);
            try
            {
                Assert.That(observed.Wait(TimeSpan.FromSeconds(5)), Is.True);
                Assert.That(observedText, Does.Contain(nameof(IOException)).And.Not.Contain("sensitive"));
            }
            finally
            {
                Volatile.Write(ref fail, 0);
            }
        }

        [Test]
        [NonParallelizable]
        public async Task GlobalCustomDefaultIsNotMistakenForAnOwnedTransport()
        {
            HttpPipelineTransport original = ClientOptions.Default.Transport;
            var custom = new MockTransport(new MockResponse(200));
            try
            {
                ClientOptions.Default.Transport = custom;
                var options = new TestOptions();
                Assert.That(options.Transport, Is.SameAs(custom));
                options.Transport = KeyVaultTransport.Create(options.Transport);
                HttpPipeline pipeline = HttpPipelineBuilder.Build(options);
                using X509Certificate2 certificate = Certificate();
                using HttpMessage message = Message(pipeline, certificate);
                Assert.ThrowsAsync<NotSupportedException>(async () => await pipeline.SendAsync(message, default));
                Assert.That(custom.Requests, Is.Empty);
                using HttpMessage bearer = Message(pipeline, null, bound: false);
                await pipeline.SendAsync(bearer, default);
                Assert.That(custom.Requests, Has.Count.EqualTo(1));
            }
            finally
            {
                ClientOptions.Default.Transport = original;
            }
        }

        [Test]
        public void MissingCertificateAndPublicOnlyCertificateFailBeforeCreatingTransport()
        {
            using X509Certificate2 certificate = Certificate();
#if NET9_0_OR_GREATER
            using X509Certificate2 publicOnly = X509CertificateLoader.LoadCertificate(certificate.RawData);
#else
            using X509Certificate2 publicOnly = new(certificate.RawData);
#endif
            using var pool = Pool(_ => throw new AssertionException("Must not create"));
            Assert.Throws<InvalidOperationException>(() => pool.Acquire(null, default));
            Assert.Throws<InvalidOperationException>(() => pool.Acquire(publicOnly, default));
        }

        [Test]
        public async Task BufferedResponsesReleaseLeaseWithoutResponseDisposal([Values] bool async)
        {
            using X509Certificate2 certificate = Certificate();
            var transports = new List<BindingTransport>();
            DateTimeOffset now = DateTimeOffset.UtcNow;
            using var pool = Pool(c => Add(transports, c), () => now);
            HttpPipeline pipeline = Pipeline(pool);
            using HttpMessage message = Message(pipeline, certificate);
            await Send(pipeline, message, async);
            Assert.That(message.Response.ContentStream.CanSeek, Is.True);
            Assert.That(new StreamReader(message.Response.ContentStream).ReadToEnd(), Is.EqualTo("body"));
            now += TimeSpan.FromMinutes(3);
            pool.Sweep();
            Assert.That(transports.Single().DisposeCount, Is.EqualTo(1));
        }

        [Test]
        public async Task UnbufferedAndDetachedStreamsPinUntilEofOrDisposal([Values] bool async, [Values] bool detach, [Values] bool eof)
        {
            using X509Certificate2 certificate = Certificate();
            DateTimeOffset now = DateTimeOffset.UtcNow;
            BindingTransport transport = null;
            using var pool = Pool(c => transport = new BindingTransport(c), () => now);
            HttpPipeline pipeline = Pipeline(pool);
            using HttpMessage message = Message(pipeline, certificate);
            message.BufferResponse = false;
            await Send(pipeline, message, async);
            Stream stream = detach ? message.ExtractResponseContent() : message.Response.ContentStream;
            if (detach)
                message.Response.Dispose();
            now += TimeSpan.FromMinutes(3);
            pool.Sweep();
            Assert.That(transport.DisposeCount, Is.Zero);
            if (eof)
            {
                Assert.That(await new StreamReader(stream).ReadToEndAsync(), Is.EqualTo("body"));
            }
            else
            {
                stream.Dispose();
            }
            now += TimeSpan.FromMinutes(3);
            pool.Sweep();
            Assert.That(transport.DisposeCount, Is.EqualTo(1));
        }

        [Test]
        public async Task SendFailureAndCancellationReleaseLease([Values] bool async, [Values] bool cancel)
        {
            using X509Certificate2 certificate = Certificate();
            DateTimeOffset now = DateTimeOffset.UtcNow;
            BindingTransport transport = null;
            using var pool = Pool(c => transport = new BindingTransport(c, (_, token) =>
                throw (cancel ? new OperationCanceledException(token) : new IOException("send failed"))), () => now);
            HttpPipeline pipeline = Pipeline(pool);
            using HttpMessage message = Message(pipeline, certificate);
            try
            {
                await Send(pipeline, message, async);
                Assert.Fail("Expected a transport failure");
            }
            catch (Exception exception) when (exception is IOException || exception is OperationCanceledException)
            {
            }
            now += TimeSpan.FromMinutes(3);
            pool.Sweep();
            Assert.That(transport.DisposeCount, Is.EqualTo(1));
        }

        [Test]
        public async Task CanceledStreamReadReleasesLeaseButZeroLengthReadDoesNot()
        {
            using X509Certificate2 certificate = Certificate();
            DateTimeOffset now = DateTimeOffset.UtcNow;
            BindingTransport transport = null;
            using var pool = Pool(c => transport = new BindingTransport(c), () => now);
            HttpPipeline pipeline = Pipeline(pool);
            using HttpMessage message = Message(pipeline, certificate);
            message.BufferResponse = false;
            await pipeline.SendAsync(message, default);
            Stream stream = message.Response.ContentStream;
            var buffer = new byte[4];
            Assert.That(stream.Read(buffer, 0, 0), Is.Zero);
            now += TimeSpan.FromMinutes(3);
            pool.Sweep();
            Assert.That(transport.DisposeCount, Is.Zero);
            using var cancellation = new CancellationTokenSource();
            cancellation.Cancel();
            Assert.ThrowsAsync<TaskCanceledException>(async () =>
                Assert.That(await stream.ReadAsync(buffer, 0, buffer.Length, cancellation.Token), Is.Zero));
            now += TimeSpan.FromMinutes(3);
            pool.Sweep();
            Assert.That(transport.DisposeCount, Is.EqualTo(1));
        }

        [Test]
        public async Task ResendingUnbufferedMessageReleasesPreviousCertificateBeforeAcquire([Values] bool async, [Values] bool bearer)
        {
            using X509Certificate2 first = Certificate();
            using X509Certificate2 second = new(first);
            var created = new List<BindingTransport>();
            using var pool = Pool(c => Add(created, c), capacity: 1);
            using var bearerClient = new BindingTransport(first);
            var router = new KeyVaultTransport(bearerClient, pool, true);
            var options = new TestOptions { Transport = router };
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options);
            using HttpMessage message = Message(pipeline, first);
            message.BufferResponse = false;
            await Send(pipeline, message, async);
            string nextHeader = bearer ? "Bearer next" : "mtls_pop next";
            message.Request.Headers.SetValue("Authorization", nextHeader);
            message.SetProperty(typeof(RequestAuthentication), new RequestAuthentication(nextHeader, second));
            await Send(pipeline, message, async);
            Assert.That(created.Count, Is.EqualTo(bearer ? 1 : 2));
            if (!bearer)
                Assert.That(created[0].DisposeCount, Is.EqualTo(1));
        }

        [Test]
        public async Task InFlightSendAndConcurrentCertificateRotationStayIsolated()
        {
            using X509Certificate2 first = Certificate();
            using X509Certificate2 second = Certificate(distinct: true);
            Assert.That(second.Thumbprint, Is.Not.EqualTo(first.Thumbprint));
            var entered = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var release = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var transports = new List<BindingTransport>();
            DateTimeOffset now = DateTimeOffset.UtcNow;
            using var pool = Pool(c =>
            {
                int index = transports.Count;
                Assert.That(c.RawData, Is.EqualTo(index == 0 ? first.RawData : second.RawData));
                var transport = new BindingTransport(c, async (request, token) =>
                {
                    Assert.That(request.Headers.Authorization.Parameter, Is.EqualTo(index == 0 ? "first" : "second"));
                    if (index == 0)
                    {
                        entered.SetResult(true);
                        await release.Task;
                    }
                    return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("body") };
                });
                transports.Add(transport);
                return transport;
            }, () => now);
            HttpPipeline pipeline = Pipeline(pool);
            using HttpMessage firstMessage = Message(pipeline, first, "first");
            Task sending = pipeline.SendAsync(firstMessage, default).AsTask();
            await entered.Task;
            now += TimeSpan.FromHours(1);
            pool.Sweep();
            using HttpMessage secondMessage = Message(pipeline, second, "second");
            await pipeline.SendAsync(secondMessage, default);
            Assert.That(transports[0].DisposeCount, Is.Zero);
            release.SetResult(true);
            await sending;
            now += TimeSpan.FromMinutes(3);
            pool.Sweep();
            Assert.That(transports.All(t => t.DisposeCount == 1), Is.True);
        }

        [Test]
        public async Task CustomTransportBearerIsUnchangedAndBoundTokensFailClosed([Values] bool async)
        {
            using X509Certificate2 certificate = Certificate();
            var custom = new MockTransport(new MockResponse(200));
            var options = new TestOptions { Transport = new KeyVaultTransport(custom) };
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options);
            using HttpMessage bound = Message(pipeline, certificate);
            try
            {
                await Send(pipeline, bound, async);
                Assert.Fail("Expected unsupported custom transport");
            }
            catch (NotSupportedException) { }
            Assert.That(custom.Requests, Is.Empty);
            using HttpMessage bearer = Message(pipeline, certificate, bound: false);
            bearer.Request.Headers.SetValue("x-ms-tokenboundauth", "true");
            await Send(pipeline, bearer, async);
            Assert.That(custom.Requests, Has.Count.EqualTo(1));
            Assert.That(bearer.Request.Headers.Contains("x-ms-tokenboundauth"), Is.False);
            Assert.That(bearer.Request.Headers.TryGetValue("Authorization", out string authorization), Is.True);
            Assert.That(authorization, Is.EqualTo("Bearer token"));
            Assert.That(custom.TransportUpdates, Is.Empty);
        }

        [Test]
        public async Task CacheHitsAssociateTheSameTokenAndCertificateOnEveryRequest([Values] bool async)
        {
            using X509Certificate2 certificate = Certificate();
            int calls = 0;
            var credential = new DelegateCredential((context, token) =>
            {
                calls++;
                return new AccessToken("token", DateTimeOffset.UtcNow.AddHours(1), null, "mtls_pop", certificate);
            });
            var cache = new KeyVaultTokenCache(credential);
            var context = new TokenRequestContext(new[] { "scope" }, tenantId: "tenant", isCaeEnabled: true,
                isProofOfPossessionEnabled: true, requestUri: new Uri("https://vault.example/one"), requestMethod: "GET");
            RequestAuthentication first = await cache.GetAsync(context, async, default);
            RequestAuthentication second = await cache.GetAsync(context, async, default);
            Assert.That(calls, Is.EqualTo(1));
            Assert.That(first, Is.SameAs(second));
            Assert.That(second.Certificate, Is.SameAs(certificate));
            Assert.That(second.Header, Is.EqualTo("mtls_pop token"));
        }

        [Test]
        public async Task CacheContextIncludesCaeClaimsTenantScopesAndPopTarget([Values] bool async)
        {
            var seen = new List<TokenRequestContext>();
            var cache = new KeyVaultTokenCache(new DelegateCredential((context, token) =>
            {
                seen.Add(context);
                return new AccessToken("token", DateTimeOffset.UtcNow.AddHours(1));
            }));
            var contexts = new[]
            {
                Context(), Context(cae: false), Context(claims: "claims"), Context(tenant: "other"),
                Context(scope: "other"), Context(uri: "https://vault.example/two"), Context(method: "POST"), Context(nonce: "nonce"),
            };
            foreach (TokenRequestContext context in contexts)
            {
                await cache.GetAsync(context, async, default);
                await cache.GetAsync(context, async, default);
            }
            Assert.That(seen.Count, Is.EqualTo(contexts.Length));
            for (int i = 0; i < seen.Count; i++)
            {
                Assert.That(seen[i].ParentRequestId, Is.EqualTo("parent"));
                Assert.That(seen[i].ResourceRequestUri, Is.EqualTo(contexts[i].ResourceRequestUri));
                Assert.That(seen[i].IsCaeEnabled, Is.EqualTo(contexts[i].IsCaeEnabled));
                Assert.That(seen[i].ProofOfPossessionNonce, Is.EqualTo(contexts[i].ProofOfPossessionNonce));
            }
        }

        [Test]
        public async Task BackgroundRenewalPublishesTokenAndCertificateAtomically([Values] bool async)
        {
            using X509Certificate2 first = Certificate();
            using X509Certificate2 second = Certificate(distinct: true);
            DateTimeOffset now = DateTimeOffset.UtcNow;
            using var started = new ManualResetEventSlim();
            using var release = new ManualResetEventSlim();
            int calls = 0;
            var cache = new KeyVaultTokenCache(new DelegateCredential((context, token) =>
            {
                if (Interlocked.Increment(ref calls) == 1)
                {
                    return new AccessToken("first", now.AddHours(1), now.AddSeconds(1), "mtls_pop", first);
                }
                started.Set();
                release.Wait(token);
                return new AccessToken("second", now.AddHours(1), now.AddMinutes(30), "mtls_pop", second);
            }), () => now);
            RequestAuthentication initial = await cache.GetAsync(Context(), async, default);
            now += TimeSpan.FromSeconds(2);
            RequestAuthentication old = await cache.GetAsync(Context(), async, default);
            try
            {
                Assert.That(started.Wait(TimeSpan.FromSeconds(5)), Is.True);
                Assert.That(old, Is.SameAs(initial));
                Assert.That((await cache.GetAsync(Context(), async, default)).Certificate, Is.SameAs(first));
            }
            finally
            {
                release.Set();
            }
            RequestAuthentication current = old;
            for (int i = 0; i < 1000 && current == old; i++)
            {
                current = await cache.GetAsync(Context(), async, default);
                if (current == old)
                    await Task.Delay(1);
            }
            Assert.That(current.Header, Is.EqualTo("mtls_pop second"));
            Assert.That(current.Certificate, Is.SameAs(second));
            Assert.That(calls, Is.EqualTo(2));
        }

        [Test]
        public async Task SingleFlightCancellationDoesNotPoisonOtherRequests()
        {
            using var started = new ManualResetEventSlim();
            using var cancel = new CancellationTokenSource();
            int calls = 0;
            var cache = new KeyVaultTokenCache(new DelegateCredential((context, token) =>
            {
                if (Interlocked.Increment(ref calls) == 1)
                {
                    started.Set();
                    token.WaitHandle.WaitOne();
                    token.ThrowIfCancellationRequested();
                }
                return new AccessToken("recovered", DateTimeOffset.UtcNow.AddHours(1));
            }));
            Task<RequestAuthentication> leader = Task.Run(async () => await cache.GetAsync(Context(), true, cancel.Token));
            Assert.That(started.Wait(TimeSpan.FromSeconds(5)), Is.True);
            Task<RequestAuthentication> waiter = cache.GetAsync(Context(), true, default).AsTask();
            cancel.Cancel();
            Assert.ThrowsAsync<TaskCanceledException>(async () => await leader);
            Assert.That((await waiter).Header, Is.EqualTo("Bearer recovered"));
            Assert.That(calls, Is.EqualTo(2));
        }

        private static TokenRequestContext Context(bool cae = true, string claims = null, string tenant = "tenant",
            string scope = "scope", string uri = "https://vault.example/one", string method = "GET", string nonce = null) =>
            new(new[] { scope }, "parent", claims, tenant, cae, true, nonce, new Uri(uri), method);

        private static BindingTransport Add(List<BindingTransport> transports, X509Certificate2 certificate)
        {
            var transport = new BindingTransport(certificate);
            transports.Add(transport);
            return transport;
        }

        private static CertificateTransportPool Pool(Func<X509Certificate2, HttpPipelineTransport> factory,
            Func<DateTimeOffset> clock = null, int capacity = 2) =>
            new(capacity, TimeSpan.FromMinutes(2), Timeout.InfiniteTimeSpan, factory, clock ?? (() => DateTimeOffset.UtcNow));

        private static HttpPipeline Pipeline(CertificateTransportPool pool)
        {
            var options = new TestOptions { Transport = new KeyVaultTransport(HttpClientTransport.Shared, pool, true) };
            options.Retry.MaxRetries = 0;
            return HttpPipelineBuilder.Build(options);
        }

        private static HttpMessage Message(HttpPipeline pipeline, X509Certificate2 certificate, string token = "token", bool bound = true)
        {
            HttpMessage message = pipeline.CreateMessage();
            message.Request.Uri.Reset(new Uri("https://transport.vault.azure.net"));
            string header = (bound ? "mtls_pop " : "Bearer ") + token;
            message.Request.Headers.SetValue("Authorization", header);
            message.SetProperty(typeof(RequestAuthentication), new RequestAuthentication(header, certificate));
            return message;
        }

        private static async Task Send(HttpPipeline pipeline, HttpMessage message, bool async)
        {
            if (async)
                await pipeline.SendAsync(message, default);
            else
                pipeline.Send(message, default);
        }

        private sealed class TestOptions : ClientOptions { }

        private sealed class DelegateCredential : TokenCredential
        {
            private readonly Func<TokenRequestContext, CancellationToken, AccessToken> _getToken;
            internal DelegateCredential(Func<TokenRequestContext, CancellationToken, AccessToken> getToken) => _getToken = getToken;
            public override AccessToken GetToken(TokenRequestContext context, CancellationToken cancellationToken) => _getToken(context, cancellationToken);
            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext context, CancellationToken cancellationToken) => new(_getToken(context, cancellationToken));
        }

        private sealed class BindingTransport : HttpPipelineTransport, IDisposable
        {
            private readonly HttpClient _client;
            private readonly HttpClientTransport _transport;
            internal readonly X509Certificate2 Certificate;
            internal int DisposeCount;

            internal BindingTransport(X509Certificate2 certificate, Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> send = null)
            {
                Certificate = certificate;
                _client = new HttpClient(new Handler(certificate, send));
                _transport = new HttpClientTransport(_client);
            }

            public override Request CreateRequest() => _transport.CreateRequest();
            public override void Process(HttpMessage message) => _transport.Process(message);
            public override ValueTask ProcessAsync(HttpMessage message) => _transport.ProcessAsync(message);
            public void Dispose() { Interlocked.Increment(ref DisposeCount); _client.Dispose(); _transport.Dispose(); }

            private sealed class Handler : HttpMessageHandler
            {
                private readonly X509Certificate2 _certificate;
                private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _send;
                internal Handler(X509Certificate2 certificate, Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> send)
                {
                    _certificate = certificate;
                    _send = send;
                }

                protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
                {
                    Assert.That(_certificate.HasPrivateKey, Is.True);
                    return _send?.Invoke(request, cancellationToken) ?? Task.FromResult(
                        new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("body") });
                }
#if NET8_0_OR_GREATER
                protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken) =>
                    SendAsync(request, cancellationToken).GetAwaiter().GetResult();
#endif
            }
        }
    }
}
