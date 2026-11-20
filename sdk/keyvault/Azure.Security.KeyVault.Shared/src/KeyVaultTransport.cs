// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;

namespace Azure.Security.KeyVault
{
    // This router owns neither the client's transport nor the credential's certificate.
    // Only the bounded, assembly-local pool owns certificate handles and transports.
    internal sealed class KeyVaultTransport : HttpPipelineTransport
    {
        private static readonly HttpPipelineTransport s_defaultTransport = new DefaultOptions().Transport;
        private static readonly CertificateTransportPool s_pool = new(64, TimeSpan.FromMinutes(2), TimeSpan.FromSeconds(30),
            certificate => new DefaultCertificateTransport(certificate), () => DateTimeOffset.UtcNow);
        private readonly HttpPipelineTransport _transport;
        private readonly CertificateTransportPool _pool;
        private readonly bool _supportsBinding;

        internal KeyVaultTransport(HttpPipelineTransport transport)
            : this(transport, s_pool, ReferenceEquals(transport, s_defaultTransport))
        {
        }

        internal static HttpPipelineTransport Create(HttpPipelineTransport transport) =>
            transport is KeyVaultTransport ? transport : new KeyVaultTransport(transport);

        internal KeyVaultTransport(HttpPipelineTransport transport, CertificateTransportPool pool, bool supportsBinding)
        {
            _transport = transport;
            _pool = pool;
            _supportsBinding = supportsBinding;
        }

        public override Request CreateRequest() => _transport.CreateRequest();

        public override void Process(HttpMessage message) => ProcessInternalAsync(message, false).EnsureCompleted();

        public override ValueTask ProcessAsync(HttpMessage message) => ProcessInternalAsync(message, true);

        private async ValueTask ProcessInternalAsync(HttpMessage message, bool async)
        {
            // Challenges can resend an unbuffered message without passing RetryPolicy.
            // Retire its previous body before acquiring another certificate's slot.
            if (message.HasResponse)
            {
                message.Response.ContentStream?.Dispose();
            }
            message.TryGetProperty(typeof(RequestAuthentication), out object value);
            var authentication = value as RequestAuthentication;
            if (authentication == null || !authentication.IsBound)
            {
                if (message.Request.Headers.TryGetValue(HttpHeader.Names.Authorization, out string unassociatedHeader) &&
                    unassociatedHeader.StartsWith("mtls_pop ", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("A certificate-bound token must be associated with its binding certificate by the Key Vault authentication policy.");
                }
                message.Request.Headers.Remove("x-ms-tokenboundauth");
                if (async)
                {
                    await _transport.ProcessAsync(message).ConfigureAwait(false);
                }
                else
                {
                    _transport.Process(message);
                }
                return;
            }

            if (!_supportsBinding)
            {
                throw new NotSupportedException("Key Vault certificate-bound authentication requires the default transport. A caller-provided transport cannot be safely rebound per request.");
            }
            if (!message.Request.Headers.TryGetValue(HttpHeader.Names.Authorization, out string header) ||
                header != authentication.Header)
            {
                throw new InvalidOperationException("The certificate-bound Authorization header was changed after authentication.");
            }

            CertificateTransportPool.Lease lease = _pool.Acquire(authentication.Certificate, message.CancellationToken);
            try
            {
                if (async)
                {
                    await lease.Transport.ProcessAsync(message).ConfigureAwait(false);
                }
                else
                {
                    lease.Transport.Process(message);
                }
                Stream stream = message.Response.ContentStream;
                if (stream != null)
                {
                    // Always report non-seekable, so Core buffers even a transport-provided
                    // memory stream. EOF releases the lease without requiring Response.Dispose.
                    message.Response.ContentStream = new LeasedStream(stream, lease);
                    lease = null;
                }
            }
            finally
            {
                lease?.Dispose();
            }
        }

        internal sealed class RequestAuthentication
        {
            internal RequestAuthentication(string header, X509Certificate2 certificate)
            {
                Header = header;
                IsBound = header.StartsWith("mtls_pop ", StringComparison.OrdinalIgnoreCase);
                Certificate = IsBound ? certificate : null;
            }

            internal string Header { get; }
            internal bool IsBound { get; }
            internal X509Certificate2 Certificate { get; }
        }

        // The configuration constructor deliberately does not inherit ClientOptions.Default:
        // that may contain a caller-owned transport or policies. It asks Core to select the
        // platform's built-in transport, including HttpWebRequest on .NET Framework.
        private sealed class DefaultOptions : ClientOptions
        {
#pragma warning disable SCME0002
            internal DefaultOptions() : base(null, null)
#pragma warning restore SCME0002
            {
            }
        }

        internal sealed class DefaultCertificateTransport : HttpPipelineTransport, IDisposable
        {
            private readonly DisposableHttpPipeline _owner;
            private readonly TransportContinuation _continuation = new();

            internal DefaultCertificateTransport(X509Certificate2 certificate)
            {
                var options = new DefaultOptions();
                options.Diagnostics.IsLoggingEnabled = false;
                options.Diagnostics.IsTelemetryEnabled = false;
                options.Diagnostics.IsDistributedTracingEnabled = false;
                options.Retry.MaxRetries = 0;
                options.AddPolicy(_continuation, HttpPipelinePosition.BeforeTransport);
                var transportOptions = new HttpPipelineTransportOptions();
                transportOptions.ClientCertificates.Add(certificate);
                _owner = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), transportOptions, null);
                try
                {
                    // Capture the public BeforeTransport continuation without making a request.
                    // Real sends invoke only this continuation: customer policies, retries,
                    // tracing and buffering run exactly once in the outer client pipeline.
                    using HttpMessage initialization = _owner.CreateMessage();
                    initialization.Request.Uri.Reset(new Uri("https://localhost"));
                    _owner.Send(initialization, CancellationToken.None);
                }
                catch
                {
                    _owner.Dispose();
                    throw;
                }
            }

            public override Request CreateRequest() => _owner.CreateRequest();
            public override void Process(HttpMessage message) => _continuation.Send(message);
            public override ValueTask ProcessAsync(HttpMessage message) => _continuation.SendAsync(message);
            public void Dispose() => _owner.Dispose();

            private sealed class TransportContinuation : HttpPipelinePolicy
            {
                private ReadOnlyMemory<HttpPipelinePolicy> _next;

                public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
                {
                    // Own the continuation array rather than retaining memory borrowed
                    // from a pipeline invocation (which Core may choose to pool).
                    _next = pipeline.ToArray();
                    message.Response = new InitializationResponse();
                }

                public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
                {
                    Process(message, pipeline);
                    return default;
                }

                internal void Send(HttpMessage message) => ProcessNext(message, _next);
                internal ValueTask SendAsync(HttpMessage message) => ProcessNextAsync(message, _next);
            }

            private sealed class InitializationResponse : Response
            {
                public override int Status => 200;
                public override string ReasonPhrase => "OK";
                public override Stream ContentStream { get; set; }
                public override string ClientRequestId { get; set; }
                public override void Dispose() { }
                protected override bool ContainsHeader(string name) => false;
                protected override IEnumerable<HttpHeader> EnumerateHeaders() => Array.Empty<HttpHeader>();
                protected override bool TryGetHeader(string name, out string value) { value = null; return false; }
                protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values) { values = null; return false; }
            }
        }
        internal sealed class CertificateTransportPool : IDisposable
        {
            private readonly object _gate = new();
            private readonly Dictionary<CertificateKey, Entry> _entries = new();
            private readonly int _capacity;
            private readonly TimeSpan _idleTime;
            private readonly Func<X509Certificate2, HttpPipelineTransport> _factory;
            private readonly Func<DateTimeOffset> _clock;
            private readonly Timer _timer;
            private bool _disposed;

            internal CertificateTransportPool(int capacity, TimeSpan idleTime, TimeSpan sweepInterval,
                Func<X509Certificate2, HttpPipelineTransport> factory, Func<DateTimeOffset> clock)
            {
                _capacity = capacity;
                _idleTime = idleTime;
                _factory = factory;
                _clock = clock;
                // A process-wide timer must not root the creating request's ExecutionContext.
                if (ExecutionContext.IsFlowSuppressed())
                {
                    _timer = new Timer(Sweep, null, sweepInterval, sweepInterval);
                }
                else
                {
                    using (ExecutionContext.SuppressFlow())
                    {
                        _timer = new Timer(Sweep, null, sweepInterval, sweepInterval);
                    }
                }
            }

            internal Lease Acquire(X509Certificate2 certificate, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (certificate == null || !certificate.HasPrivateKey)
                {
                    throw new InvalidOperationException("A certificate-bound token requires a binding certificate with a private key.");
                }

                lock (_gate)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    if (_disposed)
                    {
                        throw new ObjectDisposedException(nameof(CertificateTransportPool));
                    }
                    var key = new CertificateKey(certificate);
                    if (!_entries.TryGetValue(key, out Entry entry))
                    {
                        SweepIdle();
                        if (_entries.Count == _capacity)
                        {
                            // Retire only an idle entry, never an active cohort. This keeps the
                            // total number of transports bounded, not just the dictionary size.
                            Entry idle = null;
                            foreach (Entry candidate in _entries.Values)
                            {
                                if (candidate.Leases == 0 && (idle == null || candidate.LastUsed < idle.LastUsed))
                                {
                                    idle = candidate;
                                }
                            }
                            if (idle == null)
                            {
                                throw new InvalidOperationException("The Key Vault certificate transport pool is busy. Complete or dispose outstanding response streams before retrying.");
                            }
                            Retire(idle);
                        }
                        cancellationToken.ThrowIfCancellationRequested();
                        var ownedCertificate = new X509Certificate2(certificate);
                        HttpPipelineTransport transport = null;
                        try
                        {
                            transport = _factory(ownedCertificate);
                            cancellationToken.ThrowIfCancellationRequested();
                            entry = new Entry(key, ownedCertificate, transport);
                            _entries.Add(key, entry);
                        }
                        catch
                        {
                            try
                            { (transport as IDisposable)?.Dispose(); }
                            finally { ownedCertificate.Dispose(); }
                            throw;
                        }
                    }
                    entry.Leases++;
                    return new Lease(this, entry);
                }
            }

            internal void Sweep()
            {
                lock (_gate)
                {
                    SweepIdle();
                }
            }

            private void Sweep(object state)
            {
                try
                {
                    Sweep();
                }
                catch (Exception exception)
                {
                    TransportEventSource.Singleton.CleanupFailed(exception.GetType().FullName);
                }
            }

            private void SweepIdle()
            {
                var idle = new List<Entry>();
                DateTimeOffset now = _clock();
                foreach (Entry entry in _entries.Values)
                {
                    if (entry.Leases == 0 && (_disposed || now - entry.LastUsed >= _idleTime))
                    {
                        idle.Add(entry);
                    }
                }
                foreach (Entry entry in idle)
                {
                    Retire(entry);
                }
            }

            private void Retire(Entry entry)
            {
                _entries.Remove(entry.Key);
                try
                {
                    (entry.Transport as IDisposable)?.Dispose();
                }
                finally
                {
                    entry.Certificate.Dispose();
                }
            }

            public void Dispose()
            {
                lock (_gate)
                {
                    _disposed = true;
                    _timer.Dispose();
                    SweepIdle();
                }
            }

            internal sealed class Lease : IDisposable
            {
                private CertificateTransportPool _pool;
                private readonly Entry _entry;

                internal Lease(CertificateTransportPool pool, Entry entry) { _pool = pool; _entry = entry; }
                internal HttpPipelineTransport Transport => _entry.Transport;

                public void Dispose()
                {
                    CertificateTransportPool pool = Interlocked.Exchange(ref _pool, null);
                    if (pool != null)
                    {
                        lock (pool._gate)
                        {
                            _entry.Leases--;
                            _entry.LastUsed = pool._clock();
                            if (_entry.Leases == 0 && pool._disposed)
                            {
                                pool.Retire(_entry);
                            }
                        }
                    }
                }
            }

            internal sealed class Entry
            {
                internal Entry(CertificateKey key, X509Certificate2 certificate, HttpPipelineTransport transport)
                {
                    Key = key;
                    Certificate = certificate;
                    Transport = transport;
                }

                internal CertificateKey Key { get; }
                internal X509Certificate2 Certificate { get; }
                internal HttpPipelineTransport Transport { get; }
                internal int Leases { get; set; }
                internal DateTimeOffset LastUsed { get; set; }
            }

            internal readonly struct CertificateKey : IEquatable<CertificateKey>
            {
                private readonly X509Certificate2 _certificate;
                private readonly IntPtr _handle;

                internal CertificateKey(X509Certificate2 certificate) { _certificate = certificate; _handle = certificate.Handle; }
                public bool Equals(CertificateKey other) => ReferenceEquals(_certificate, other._certificate) && _handle == other._handle;
                public override bool Equals(object obj) => obj is CertificateKey other && Equals(other);
                public override int GetHashCode() => RuntimeHelpers.GetHashCode(_certificate) ^ _handle.GetHashCode();
            }
        }

        internal sealed class LeasedStream : Stream
        {
            private readonly Stream _stream;
            private IDisposable _lease;

            internal LeasedStream(Stream stream, IDisposable lease) { _stream = stream; _lease = lease; }
            public override bool CanRead => _stream.CanRead;
            public override bool CanSeek => false;
            public override bool CanWrite => false;
            public override long Length => throw new NotSupportedException();
            public override long Position { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
            public override void Flush() => _stream.Flush();
            public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
            public override void SetLength(long value) => throw new NotSupportedException();
            public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

            public override int Read(byte[] buffer, int offset, int count)
            {
                try
                {
                    int read = _stream.Read(buffer, offset, count);
                    if (read == 0 && count != 0)
                        Release();
                    return read;
                }
                catch
                {
                    Dispose();
                    throw;
                }
            }

            public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                try
                {
                    int read = await _stream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
                    if (read == 0 && count != 0)
                        Release();
                    return read;
                }
                catch
                {
                    Dispose();
                    throw;
                }
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    try
                    { _stream.Dispose(); }
                    finally { Release(); }
                }
                base.Dispose(disposing);
            }

            private void Release() => Interlocked.Exchange(ref _lease, null)?.Dispose();
        }

        internal sealed class TransportEventSource : AzureEventSource
        {
            private TransportEventSource() : base(typeof(KeyVaultTransport).Assembly.GetName().Name.Replace('.', '-') + "-Transport") { }
            internal static TransportEventSource Singleton { get; } = new();

            [Event(1, Level = EventLevel.Warning, Message = "Key Vault automatic transport cleanup failed ({0}).")]
            public void CleanupFailed(string exceptionType) => WriteEvent(1, exceptionType);

            [Event(2, Level = EventLevel.Warning, Message = "Key Vault background token refresh failed ({0}).")]
            public void RefreshFailed(string exceptionType) => WriteEvent(2, exceptionType);
        }
    }
}
