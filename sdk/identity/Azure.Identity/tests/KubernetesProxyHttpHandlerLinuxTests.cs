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
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    /// <summary>
    /// Linux-specific tests for KubernetesProxyHttpHandler to verify the X509Chain fix
    /// for OpenSSL. These tests use real HTTPS connections to trigger the SSL validation
    /// callback where the original bug manifested as a NullReferenceException in
    /// OpenSslX509ChainProcessor.FindFirstChain when reusing the passed-in chain object.
    /// </summary>
    [RunOnlyOnPlatforms(Linux = true)]
    public class KubernetesProxyHttpHandlerLinuxTests
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

        /// <summary>
        /// Verifies that HTTPS requests with a custom CA certificate succeed on Linux.
        /// This is the primary regression test for the X509Chain fix.
        /// Bug: Reusing the passed-in X509Chain and calling Build() caused NullReferenceException
        /// in OpenSslX509ChainProcessor.FindFirstChain on Linux with OpenSSL.
        /// Fix: Create a new X509Chain instance in the validation callback.
        /// </summary>
        [Test]
        public async Task SendAsync_WithCustomCa_SucceedsOnLinux()
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
        public async Task SendAsync_WithInlineCaData_SucceedsOnLinux()
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
        public async Task SendAsync_WithCustomCa_ConcurrentRequestsSucceedOnLinux()
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
        public void X509Chain_NewInstance_BuildSucceedsOnLinux()
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
            private readonly X509Certificate2 _certificate;
            private TcpListener _listener;
            private CancellationTokenSource _cts;
            private Task _serverTask;
            private bool _disposed;

            public SimpleHttpsServer(X509Certificate2 certificate)
            {
                _certificate = certificate ?? throw new ArgumentNullException(nameof(certificate));
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
                            _certificate,
                            clientCertificateRequired: false,
                            enabledSslProtocols: SslProtocols.Tls12 | SslProtocols.Tls13,
                            checkCertificateRevocation: false);

                        // Read HTTP request headers (simplified - we just need to consume the request)
                        var buffer = new byte[4096];
                        _ = await sslStream.ReadAsync(buffer.AsMemory(), cancellationToken);

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
