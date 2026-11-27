// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET6_0_OR_GREATER
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;
namespace Azure.Core.Tests.Identity
{
    /// <summary>
    /// Tests for KubernetesProxyHttpHandler using real HTTPS connections, including
    /// CA rotation and the X509Chain validation callback on Linux/OpenSSL.
    /// </summary>
    public class KubernetesProxyHttpHandlerTlsTests
    {
        private TestTempFileHandler _tempFiles;
        private static X509Certificate2 s_caCertificate;
        private static X509Certificate2 s_serverCertificate;
        private SimpleHttpsServer _httpsServer;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // Generate certificates once for all tests
            (s_caCertificate, s_serverCertificate) = GenerateTestCertificates();
        }

        [OneTimeTearDown]
        public void OneTimeCleanup()
        {
            // Dispose certificates after all tests complete
            s_serverCertificate?.Dispose();
            s_caCertificate?.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            _tempFiles = new TestTempFileHandler();
        }

        [TearDown]
        public void Cleanup()
        {
            _tempFiles?.CleanupTempFiles();
            _httpsServer?.Dispose();
            _httpsServer = null;
        }

        [TestCase(1)]
        [TestCase(5)]
        public async Task SendAsync_ReloadsCaAfterRealRequests(int concurrentRequests)
        {
            var (newCa, newServerCertificate) = GenerateTestCertificates();
            using (newCa)
            using (newServerCertificate)
            {
                _httpsServer = new SimpleHttpsServer(s_serverCertificate);
                int port = await _httpsServer.StartAsync();
                string caFilePath = WriteCaToPemFile(s_caCertificate);
                using var client = new HttpClient(new KubernetesProxyHttpHandler(new KubernetesProxyConfig
                {
                    ProxyUrl = new Uri($"https://localhost:{port}"),
                    SniName = "localhost",
                    CaFilePath = caFilePath
                }))
                {
                    Timeout = TimeSpan.FromSeconds(10)
                };

                using (HttpResponseMessage response = await client.GetAsync("https://login.microsoftonline.com/token"))
                {
                    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                }

                File.WriteAllText(caFilePath, ExportCertificateToPem(newCa));

                // Reject the retired CA on both the reload request and subsequent requests.
                for (int i = 0; i < 2; i++)
                {
                    Assert.ThrowsAsync<HttpRequestException>(async () =>
                    {
                        using HttpResponseMessage response = await client.GetAsync("https://login.microsoftonline.com/token");
                    });
                }

                _httpsServer.SetCertificate(newServerCertificate);
                var requests = new Task<HttpResponseMessage>[concurrentRequests];
                for (int i = 0; i < requests.Length; i++)
                {
                    requests[i] = client.GetAsync("https://login.microsoftonline.com/token");
                }

                foreach (HttpResponseMessage response in await Task.WhenAll(requests))
                {
                    using (response)
                    {
                        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                    }
                }

                // Rotate again while requests race to select the next transport.
                File.WriteAllText(caFilePath, ExportCertificateToPem(s_caCertificate));
                _httpsServer.SetCertificate(s_serverCertificate);
                for (int i = 0; i < requests.Length; i++)
                {
                    requests[i] = client.GetAsync("https://login.microsoftonline.com/token");
                }

                foreach (HttpResponseMessage response in await Task.WhenAll(requests))
                {
                    using (response)
                    {
                        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                    }
                }
            }
        }

        [Test]
        public async Task SendAsync_CaReloadLetsInFlightRequestComplete()
        {
            var (newCa, newServerCertificate) = GenerateTestCertificates();
            using (newCa)
            using (newServerCertificate)
            using (var newServer = new SimpleHttpsServer(newServerCertificate))
            {
                var releaseResponse = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                _httpsServer = new SimpleHttpsServer(s_serverCertificate, releaseResponse.Task);
                int oldPort = await _httpsServer.StartAsync();
                int newPort = await newServer.StartAsync();
                string caFilePath = WriteCaToPemFile(s_caCertificate);
                var config = new KubernetesProxyConfig
                {
                    ProxyUrl = new Uri($"https://localhost:{oldPort}"),
                    SniName = "localhost",
                    CaFilePath = caFilePath
                };
                using var handler = new KubernetesProxyHttpHandler(config);
                using var client = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(10) };
                var originalHandler = handler.InnerHandler;
                Task<HttpResponseMessage> inFlightRequest = client.GetAsync("https://login.microsoftonline.com/token");
                try
                {
                    await _httpsServer.RequestReceived.WaitAsync(TimeSpan.FromSeconds(10));
                    File.WriteAllText(caFilePath, ExportCertificateToPem(newCa));
                    config.ProxyUrl = new Uri($"https://localhost:{newPort}");
                    using HttpResponseMessage response = await client.GetAsync("https://login.microsoftonline.com/token");
                    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                    Assert.IsFalse(inFlightRequest.IsCompleted, "The old request should still be waiting for its response.");
                    Assert.AreNotSame(originalHandler, handler.InnerHandler);
                }
                finally
                {
                    releaseResponse.TrySetResult(true);
                }

                using HttpResponseMessage oldResponse = await inFlightRequest;
                Assert.AreEqual(HttpStatusCode.OK, oldResponse.StatusCode);
                using var retiredInvoker = new HttpMessageInvoker(originalHandler, disposeHandler: false);
                using var request = new HttpRequestMessage(HttpMethod.Get, config.ProxyUrl);
                Assert.ThrowsAsync<ObjectDisposedException>(async () =>
                {
                    using HttpResponseMessage response = await retiredInvoker.SendAsync(request, CancellationToken.None);
                });
            }
        }

        /// <summary>
        /// Verifies that HTTPS requests with a custom CA certificate succeed.
        /// This is the primary regression test for the X509Chain fix.
        /// Bug: Reusing the passed-in X509Chain and calling Build() caused NullReferenceException
        /// in OpenSslX509ChainProcessor.FindFirstChain on Linux with OpenSSL.
        /// Fix: Create a new X509Chain instance in the validation callback.
        /// </summary>
        [Test]
        public async Task SendAsync_WithCustomCa_Succeeds()
        {
            // Arrange
            _httpsServer = new SimpleHttpsServer(s_serverCertificate);
            int serverPort = await _httpsServer.StartAsync();
            string caFilePath = WriteCaToPemFile(s_caCertificate);

            var config = new KubernetesProxyConfig
            {
                ProxyUrl = new Uri($"https://localhost:{serverPort}"),
                SniName = "localhost",
                CaFilePath = caFilePath
            };

            // HttpClient takes ownership of the handler and disposes it when the client is disposed
            var handler = new KubernetesProxyHttpHandler(config);
            using var httpClient = new HttpClient(handler);
            httpClient.Timeout = TimeSpan.FromSeconds(10);

            // Act & Assert
            using HttpResponseMessage response = await httpClient.GetAsync("https://login.microsoftonline.com/test");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Request should succeed with custom CA");
        }

        /// <summary>
        /// Verifies that inline CA data (CaData property) works correctly on Linux.
        /// </summary>
        [Test]
        public async Task SendAsync_WithInlineCaData_Succeeds()
        {
            // Arrange
            _httpsServer = new SimpleHttpsServer(s_serverCertificate);
            int serverPort = await _httpsServer.StartAsync();
            string caPem = ExportCertificateToPem(s_caCertificate);

            var config = new KubernetesProxyConfig
            {
                ProxyUrl = new Uri($"https://localhost:{serverPort}"),
                SniName = "localhost",
                CaData = caPem
            };

            // HttpClient takes ownership of the handler and disposes it when the client is disposed
            var handler = new KubernetesProxyHttpHandler(config);
            using var httpClient = new HttpClient(handler);
            httpClient.Timeout = TimeSpan.FromSeconds(10);

            // Act & Assert
            using HttpResponseMessage response = await httpClient.GetAsync("https://login.microsoftonline.com/test");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Request with inline CA data should succeed");
        }

        /// <summary>
        /// Verifies that multiple concurrent SSL connections work correctly on Linux.
        /// Ensures the fix handles concurrent chain validation properly without race conditions.
        /// </summary>
        [Test]
        public async Task SendAsync_WithCustomCa_ConcurrentRequestsSucceed()
        {
            // Arrange
            _httpsServer = new SimpleHttpsServer(s_serverCertificate);
            int serverPort = await _httpsServer.StartAsync();
            string caFilePath = WriteCaToPemFile(s_caCertificate);

            var config = new KubernetesProxyConfig
            {
                ProxyUrl = new Uri($"https://localhost:{serverPort}"),
                SniName = "localhost",
                CaFilePath = caFilePath
            };

            // HttpClient takes ownership of the handler and disposes it when the client is disposed
            var handler = new KubernetesProxyHttpHandler(config);
            using var httpClient = new HttpClient(handler);
            httpClient.Timeout = TimeSpan.FromSeconds(10);

            // Act - Fire 5 concurrent requests
            const int concurrentRequests = 5;
            var tasks = new Task<HttpResponseMessage>[concurrentRequests];
            for (int i = 0; i < concurrentRequests; i++)
            {
                tasks[i] = httpClient.GetAsync($"https://login.microsoftonline.com/test{i}");
            }

            HttpResponseMessage[] responses = await Task.WhenAll(tasks);

            // Assert
            Assert.AreEqual(concurrentRequests, responses.Length, "Should receive all responses");
            foreach (var response in responses)
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Each concurrent request should succeed");
                response.Dispose();
            }
        }

        /// <summary>
        /// Verifies the fixed pattern: creating a new X509Chain instance builds successfully.
        /// This tests the pattern used in the fix directly without network calls.
        /// </summary>
        [Test]
        public void X509Chain_NewInstance_BuildSucceeds()
        {
            // Act - Using a NEW X509Chain instance (the fix pattern)
            using var chain = new X509Chain();
            chain.ChainPolicy.ExtraStore.Add(s_caCertificate);
            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;

            bool buildResult = chain.Build(s_serverCertificate);

            // Assert
            Assert.IsTrue(buildResult, $"Chain build should succeed. Status: {FormatChainStatus(chain)}");
            Assert.Greater(chain.ChainElements.Count, 0, "Chain should have elements after successful build");
        }

        /// <summary>
        /// Documents the problematic behavior that the fix addresses.
        /// Calling Build() twice on the same X509Chain can fail or behave unexpectedly on Linux/OpenSSL.
        /// This test demonstrates why we must create a new chain instance for each validation.
        /// </summary>
        [Test]
        [RunOnlyOnPlatforms(Linux = true)]
        [Explicit("Diagnostic-only test. Behavior varies across runtime/OpenSSL versions and is documented via test output.")]
        public void X509Chain_ReusedInstance_MayFailOnLinux()
        {
            // Arrange - First build
            using var chain = new X509Chain();
            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;

            bool firstBuild = chain.Build(s_serverCertificate);
            TestContext.WriteLine($"First Build result: {firstBuild}, Status: {FormatChainStatus(chain)}");

            // Act - Attempt to reuse the chain (the problematic pattern)
            chain.ChainPolicy.ExtraStore.Add(s_caCertificate);
            chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;

            bool secondBuild = false;
            Exception secondBuildException = null;
            try
            {
                secondBuild = chain.Build(s_serverCertificate);
            }
            catch (Exception ex)
            {
                secondBuildException = ex;
            }

            // Assert - Document behavior (may vary by .NET/OpenSSL version)
            TestContext.WriteLine($"Second Build result: {secondBuild}");
            if (secondBuildException != null)
            {
                TestContext.WriteLine($"Second Build exception: {secondBuildException.GetType().Name} - {secondBuildException.Message}");
            }

            // This test documents the behavior - the key takeaway is:
            // "Don't reuse X509Chain instances for custom validation"
            Assert.Pass("Test documents X509Chain reuse behavior - see output for details");
        }

        #region Helper Methods

        private string WriteCaToPemFile(X509Certificate2 caCert)
        {
            string caPem = ExportCertificateToPem(caCert);
            string caFilePath = _tempFiles.GetTempFilePath();
            File.WriteAllText(caFilePath, caPem);
            return caFilePath;
        }

        private static (X509Certificate2 Ca, X509Certificate2 Server) GenerateTestCertificates()
        {
            // Capture dates once to avoid timing race conditions between CA and server cert creation
            var notBefore = DateTimeOffset.UtcNow.AddDays(-1);
            var notAfter = DateTimeOffset.UtcNow.AddDays(365);

            // Generate CA certificate
            using var caKey = RSA.Create(2048);
            var caRequest = new CertificateRequest(
                new X500DistinguishedName("CN=Test CA"),
                caKey,
                HashAlgorithmName.SHA256,
                RSASignaturePadding.Pkcs1);

            caRequest.CertificateExtensions.Add(
                new X509BasicConstraintsExtension(true, false, 0, true));
            caRequest.CertificateExtensions.Add(
                new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.CrlSign, true));

            var caCert = caRequest.CreateSelfSigned(notBefore, notAfter);

            // Generate server certificate signed by CA
            using var serverKey = RSA.Create(2048);
            var serverRequest = new CertificateRequest(
                new X500DistinguishedName("CN=localhost"),
                serverKey,
                HashAlgorithmName.SHA256,
                RSASignaturePadding.Pkcs1);

            serverRequest.CertificateExtensions.Add(
                new X509BasicConstraintsExtension(false, false, 0, false));
            serverRequest.CertificateExtensions.Add(
                new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.KeyEncipherment, true));
            // macOS TLS policy requires an explicit server-authentication EKU.
            serverRequest.CertificateExtensions.Add(
                new X509EnhancedKeyUsageExtension(
                    new OidCollection { new Oid("1.3.6.1.5.5.7.3.1") }, false));

            // Add Subject Alternative Name for localhost
            var sanBuilder = new SubjectAlternativeNameBuilder();
            sanBuilder.AddDnsName("localhost");
            sanBuilder.AddIpAddress(IPAddress.Loopback);
            serverRequest.CertificateExtensions.Add(sanBuilder.Build());

            var serverCertPublic = serverRequest.Create(
                caCert,
                notBefore,
                notAfter,
                Guid.NewGuid().ToByteArray());

            // Combine with private key for server use
            var serverCertWithKey = serverCertPublic.CopyWithPrivateKey(serverKey);

            // Export and re-import to get usable certificates
            var caCertBytes = caCert.Export(X509ContentType.Pfx);
            var serverCertBytes = serverCertWithKey.Export(X509ContentType.Pfx);

#pragma warning disable SYSLIB0057 // X509Certificate2 constructors are obsolete
            return (
                new X509Certificate2(caCertBytes),
                new X509Certificate2(serverCertBytes)
            );
#pragma warning restore SYSLIB0057
        }

        private static string ExportCertificateToPem(X509Certificate2 cert)
        {
            var sb = new StringBuilder();
            sb.AppendLine("-----BEGIN CERTIFICATE-----");
            sb.AppendLine(Convert.ToBase64String(cert.RawData, Base64FormattingOptions.InsertLineBreaks));
            sb.AppendLine("-----END CERTIFICATE-----");
            return sb.ToString();
        }

        private static string FormatChainStatus(X509Chain chain)
        {
            if (chain.ChainStatus.Length == 0)
            {
                return "OK";
            }

            var statuses = new string[chain.ChainStatus.Length];
            for (int i = 0; i < chain.ChainStatus.Length; i++)
            {
                statuses[i] = $"{chain.ChainStatus[i].Status}: {chain.ChainStatus[i].StatusInformation}";
            }
            return string.Join("; ", statuses);
        }

        #endregion

        #region SimpleHttpsServer

        /// <summary>
        /// Minimal HTTPS server for testing SSL certificate validation.
        /// Responds with a simple JSON payload to any request.
        /// </summary>
        private sealed class SimpleHttpsServer : IDisposable
        {
            private X509Certificate2 _certificate;
            private readonly Task _responseGate;
            private readonly TaskCompletionSource<bool> _requestReceived =
                new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            private TcpListener _listener;
            private CancellationTokenSource _cts;
            private Task _serverTask;
            private bool _disposed;

            public Task RequestReceived => _requestReceived.Task;

            public SimpleHttpsServer(X509Certificate2 certificate, Task responseGate = null)
            {
                _certificate = certificate ?? throw new ArgumentNullException(nameof(certificate));
                _responseGate = responseGate;
            }

            public void SetCertificate(X509Certificate2 certificate)
            {
                Volatile.Write(ref _certificate, certificate);
            }

            public async Task<int> StartAsync()
            {
                _listener = new TcpListener(IPAddress.Loopback, 0);
                _listener.Start();
                int port = ((IPEndPoint)_listener.LocalEndpoint).Port;

                _cts = new CancellationTokenSource();
                _serverTask = AcceptConnectionsAsync(_cts.Token);

                return port;
            }

            private async Task AcceptConnectionsAsync(CancellationToken cancellationToken)
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        TcpClient client = await _listener.AcceptTcpClientAsync(cancellationToken);
                        // Handle each client connection without awaiting to allow concurrent connections
                        _ = HandleClientAsync(client, cancellationToken);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch (ObjectDisposedException)
                    {
                        break;
                    }
                    catch (SocketException)
                    {
                        // Listener was stopped
                        break;
                    }
                }
            }

            private async Task HandleClientAsync(TcpClient client, CancellationToken cancellationToken)
            {
                try
                {
                    using (client)
                    using (var sslStream = new SslStream(client.GetStream(), false))
                    {
                        await sslStream.AuthenticateAsServerAsync(
                            Volatile.Read(ref _certificate),
                            clientCertificateRequired: false,
                            enabledSslProtocols: SslProtocols.Tls12 | SslProtocols.Tls13,
                            checkCertificateRevocation: false);

                        // Read HTTP request headers (simplified - we just need to consume the request)
                        var buffer = new byte[4096];
                        _ = await sslStream.ReadAsync(buffer.AsMemory(), cancellationToken);
                        _requestReceived.TrySetResult(true);
                        if (_responseGate != null)
                        {
                            await _responseGate.WaitAsync(cancellationToken);
                        }

                        // Send HTTP response
                        const string jsonBody = "{\"status\":\"ok\"}";
                        int contentLength = Encoding.UTF8.GetByteCount(jsonBody);
                        string response = $"HTTP/1.1 200 OK\r\n" +
                                         $"Content-Type: application/json\r\n" +
                                         $"Content-Length: {contentLength}\r\n" +
                                         $"Connection: close\r\n" +
                                         $"\r\n" +
                                         jsonBody;

                        byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                        await sslStream.WriteAsync(responseBytes.AsMemory(), cancellationToken);
                        await sslStream.FlushAsync(cancellationToken);
                    }
                }
                catch (AuthenticationException)
                {
                    // SSL handshake failed - expected if client rejects our certificate
                }
                catch (IOException)
                {
                    // Client disconnected
                }
                catch (OperationCanceledException)
                {
                    // Server shutting down
                }
            }

            public void Dispose()
            {
                if (_disposed)
                {
                    return;
                }
                _disposed = true;

                try
                {
                    _cts?.Cancel();
                }
                catch (ObjectDisposedException)
                {
                    // Already disposed
                }

                _listener?.Stop();

                try
                {
                    _serverTask?.Wait(TimeSpan.FromSeconds(2));
                }
                catch (AggregateException)
                {
                    // Task was cancelled, expected
                }

                _cts?.Dispose();
            }
        }

        #endregion
    }
}
#endif
