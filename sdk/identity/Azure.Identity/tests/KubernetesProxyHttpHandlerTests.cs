// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class KubernetesProxyHttpHandlerTests
    {
        private TestTempFileHandler _tempFiles = new TestTempFileHandler();
        private const string DefaultProxyUrl = "https://proxy.example.com:8443/token-proxy";
        private const string DefaultSniName = "proxy.sni.example.com";
        private const string DefaultTargetUrl = "https://login.microsoftonline.com/tenant/oauth2/v2.0/token";

        [TearDown]
        public void Cleanup()
        {
            _tempFiles.CleanupTempFiles();
        }

        private static KubernetesProxyConfig CreateTestConfig(
            string proxyUrl = DefaultProxyUrl,
            string sniName = DefaultSniName,
            string caFilePath = null,
            string caData = null,
            HttpPipelineTransport transport = null)
        {
            return new KubernetesProxyConfig()
            {
                ProxyUrl = new Uri(proxyUrl),
                SniName = sniName,
                CaFilePath = caFilePath,
                CaData = caData,
                Transport = transport
            };
        }

        private static MockTransport CreateMockTransport(string responseContent = "{\"token\":\"test-token\"}", int statusCode = 200, Action<Request> requestValidator = null)
        {
            return new MockTransport(req =>
            {
                requestValidator?.Invoke(req);
                var response = new MockResponse(statusCode);
                response.SetContent(responseContent);
                return response;
            });
        }

        private HttpClient CreateTestHttpClient(KubernetesProxyConfig config = null)
        {
            config ??= CreateTestConfig();
            var handler = new KubernetesProxyHttpHandler(config);
            return new HttpClient(handler);
        }

        private async Task<(HttpResponseMessage Response, Request CapturedRequest)> SendRequestAndCapture(
            string targetUrl = DefaultTargetUrl,
            KubernetesProxyConfig config = null,
            HttpMethod method = null,
            HttpContent content = null)
        {
            method ??= HttpMethod.Get;
            Request capturedRequest = null;

            var mockTransport = CreateMockTransport(requestValidator: req => capturedRequest = req);
            config ??= CreateTestConfig(transport: mockTransport);
            if (config.Transport == null)
                config.Transport = mockTransport;

            var httpClient = CreateTestHttpClient(config);
            var request = new HttpRequestMessage(method, targetUrl) { Content = content };
            var response = await httpClient.SendAsync(request);

            return (response, capturedRequest);
        }

        private async Task<(KubernetesProxyHttpHandler Handler, HttpMessageHandler InitialInnerHandler)> CreateHandlerAndMakeRequests(
            KubernetesProxyConfig config,
            int requestCount = 2)
        {
            var handler = new KubernetesProxyHttpHandler(config);
            var httpClient = new HttpClient(handler);
            var initialInnerHandler = handler.InnerHandler;

            for (int i = 0; i < requestCount; i++)
            {
                await httpClient.GetAsync("https://login.microsoftonline.com/token");
            }

            return (handler, initialInnerHandler);
        }

        [Test]
        public void Constructor_ThrowsOnNullConfig()
        {
            Assert.Throws<ArgumentNullException>(() => new KubernetesProxyHttpHandler(null));
        }

        [Test]
        [TestCase("https://proxy.example.com:8443/token-proxy", "https://login.microsoftonline.com/tenant/oauth2/v2.0/token", "https://proxy.example.com:8443/token-proxy/tenant/oauth2/v2.0/token")]
        [TestCase("https://proxy.example.com:8443/", "https://login.microsoftonline.com/tenant/oauth2/v2.0/token", "https://proxy.example.com:8443/tenant/oauth2/v2.0/token")]
        [TestCase("https://proxy.example.com:8443", "https://login.microsoftonline.com/oauth2/token", "https://proxy.example.com:8443/oauth2/token")]
        public async Task SendAsync_RewritesUrlToProxyUrl(string proxyUrl, string targetUrl, string expectedUrl)
        {
            // Arrange & Act
            var (response, request) = await SendRequestAndCapture(targetUrl, CreateTestConfig(proxyUrl));

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(request.Uri.ToString(), Is.EqualTo(expectedUrl));
            Assert.That(request.Headers.TryGetValue("Host", out var hostHeader), Is.True);
            Assert.That(hostHeader, Is.EqualTo(DefaultSniName));
        }

        [Test]
        public async Task SendAsync_PreservesQueryParameters()
        {
            // Arrange & Act
            var targetUrl = "https://login.microsoftonline.com/oauth2/token?api-version=2.0&scope=test";
            var (response, request) = await SendRequestAndCapture(targetUrl);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(request.Uri.Query.Contains("api-version=2.0"), Is.True, $"Expected query to contain api-version=2.0 but got: {request.Uri.Query}");
            Assert.That(request.Uri.Query.Contains("scope=test"), Is.True);
        }

        [Test]
        public async Task SendAsync_CopiesRequestHeaders()
        {
            // Arrange
            Request capturedRequest = null;
            var mockTransport = CreateMockTransport(requestValidator: req => capturedRequest = req);
            var httpClient = CreateTestHttpClient(CreateTestConfig(transport: mockTransport));

            var request = new HttpRequestMessage(HttpMethod.Get, "https://login.microsoftonline.com/token");
            request.Headers.Add("Authorization", "Bearer test-token");
            request.Headers.Add("X-Custom-Header", "custom-value");

            // Act
            var response = await httpClient.SendAsync(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(capturedRequest.Headers.TryGetValue("Authorization", out var authHeader), Is.True);
            Assert.That(authHeader, Is.EqualTo("Bearer test-token"));
            Assert.That(capturedRequest.Headers.TryGetValue("X-Custom-Header", out var customHeader), Is.True);
            Assert.That(customHeader, Is.EqualTo("custom-value"));
        }

        [Test]
        public async Task SendAsync_CopiesRequestContentAndHandlesResponses()
        {
            // Test both request content copying and response handling
            var requestContent = new StringContent("{\"grant_type\":\"client_credentials\"}", Encoding.UTF8, "application/json");
            // Test with success response
            var (response, request) = await SendRequestAndCapture(content: requestContent, method: HttpMethod.Post);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(request.Content, Is.Not.Null);
            Assert.That(request.Content.TryComputeLength(out var length) && length > 0, Is.True);

            // Test with error response
            var mockTransport = CreateMockTransport("{\"error\":\"unauthorized\"}", 401);
            var httpClient = CreateTestHttpClient(CreateTestConfig(transport: mockTransport));
            var errorResponse = await httpClient.GetAsync("https://login.microsoftonline.com/token");
            Assert.That(errorResponse.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [Test]
        public async Task SendAsync_CopiesResponseHeaders()
        {
            // Arrange
            var mockTransport = new MockTransport(req =>
            {
                var response = new MockResponse(200);
                response.SetContent("{\"token\":\"test\"}");
                response.AddHeader(new HttpHeader("X-Custom-Response", "response-value"));
                response.AddHeader(new HttpHeader("Content-Type", "application/json"));
                return response;
            });

            var httpClient = CreateTestHttpClient(CreateTestConfig(transport: mockTransport));

            // Act
            var response = await httpClient.GetAsync("https://login.microsoftonline.com/token");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Headers.Contains("X-Custom-Response"), Is.True);
            Assert.That(response.Content.Headers.Contains("Content-Type"), Is.True);
        }

        [Test]
        public async Task SendAsync_DoesNotReloadWhenNoCaFile()
        {
            var mockTransport = CreateMockTransport();
            var config = CreateTestConfig(transport: mockTransport);

            var (handler, initialInnerHandler) = await CreateHandlerAndMakeRequests(config);

            Assert.That(handler.InnerHandler, Is.SameAs(initialInnerHandler), "Handler should NOT be reloaded when no CA file is configured");
        }

        [Test]
        public async Task SendAsync_DoesNotReloadWhenCaFileIsEmpty()
        {
            var caFilePath = _tempFiles.GetTempFilePath();
            File.WriteAllText(caFilePath, "");

            var mockTransport = CreateMockTransport();
            var config = CreateTestConfig(caFilePath: caFilePath, transport: mockTransport);

            var (handler, initialInnerHandler) = await CreateHandlerAndMakeRequests(config);

            Assert.That(handler.InnerHandler, Is.SameAs(initialInnerHandler), "Handler should NOT be reloaded when CA file is empty");
        }

        [Test]
        public async Task SendAsync_ReloadsHandlerWhenCaFileChanges()
        {
            // Arrange
            var caFilePath = _tempFiles.GetTempFilePath();
            var cert1 = GetTestCertificatePem();
            var cert2 = GetDifferentTestCertificatePem();
            File.WriteAllText(caFilePath, cert1);

            var requestCount = 0;
            var mockTransport = CreateMockTransport(requestValidator: req =>
            {
                requestCount++;
                // Change CA file on second request to trigger reload
                if (requestCount == 2)
                {
                    File.WriteAllText(caFilePath, cert2);
                    Task.Delay(10).GetAwaiter().GetResult(); // Allow file system to flush
                }
            });

            var config = CreateTestConfig(caFilePath: caFilePath, transport: mockTransport);
            var handler = new KubernetesProxyHttpHandler(config);
            var httpClient = new HttpClient(handler);

            // Get initial handler instance and certificate thumbprint
            var initialInnerHandler = handler.InnerHandler;
            var initialCallback = (initialInnerHandler as HttpClientHandler)?.ServerCertificateCustomValidationCallback;
            Assert.That(initialCallback, Is.Not.Null, "Initial handler should have certificate validation callback");

            var cert1Thumbprint = PemReader.LoadCertificate(cert1.AsSpan(), allowCertificateOnly: true).Thumbprint;
            var cert2Thumbprint = PemReader.LoadCertificate(cert2.AsSpan(), allowCertificateOnly: true).Thumbprint;
            Assert.That(cert2Thumbprint, Is.Not.EqualTo(cert1Thumbprint), "Test certificates should have different thumbprints");

            // Act - Make requests before and after CA change
            var response1 = await httpClient.GetAsync("https://login.microsoftonline.com/token");
            var response2 = await httpClient.GetAsync("https://login.microsoftonline.com/token");

            // Give the handler time to detect the file change and reload
            await Task.Delay(50);

            var response3 = await httpClient.GetAsync("https://login.microsoftonline.com/token");

            // Assert
            Assert.That(response1.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response2.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response3.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(requestCount, Is.EqualTo(3));

            // Verify handler was reloaded - the inner handler instance should be different
            var finalInnerHandler = handler.InnerHandler;
            Assert.That(finalInnerHandler, Is.Not.SameAs(initialInnerHandler),
                "Handler should be recreated after CA file change");

            // Verify the new handler has certificate validation configured
            var finalCallback = (finalInnerHandler as HttpClientHandler)?.ServerCertificateCustomValidationCallback;
            Assert.That(finalCallback, Is.Not.Null, "Reloaded handler should have certificate validation callback");
        }

        [Test]
        public async Task SendAsync_ConcurrentRequestsDuringCaFileReloadAllSucceed()
        {
            // Arrange
            var caFilePath = _tempFiles.GetTempFilePath();
            var cert1 = GetTestCertificatePem();
            var cert2 = GetDifferentTestCertificatePem();
            File.WriteAllText(caFilePath, cert1);

            var requestCounter = 0;
            var mockTransport = new MockTransport(req =>
            {
                var currentRequest = Interlocked.Increment(ref requestCounter);
                // Trigger reload on second request
                if (currentRequest == 2)
                {
                    File.WriteAllText(caFilePath, cert2);
                    Task.Delay(10).GetAwaiter().GetResult();
                }

                Task.Delay(50).GetAwaiter().GetResult(); // Simulate processing time
                var response = new MockResponse(200);
                response.SetContent($"{{\"request\":{currentRequest}}}");
                return response;
            });

            var config = CreateTestConfig(caFilePath: caFilePath, transport: mockTransport);
            var handler = new KubernetesProxyHttpHandler(config);
            var httpClient = new HttpClient(handler);

            var initialInnerHandler = handler.InnerHandler;

            // Act - Start multiple concurrent requests
            var tasks = new Task<HttpResponseMessage>[5];
            for (int i = 0; i < 5; i++)
            {
                tasks[i] = httpClient.GetAsync($"https://login.microsoftonline.com/token{i}");
            }
            var responses = await Task.WhenAll(tasks);

            // Assert - All requests should succeed despite CA file change
            foreach (var response in responses)
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                var content = await response.Content.ReadAsStringAsync();
                Assert.That(content.Contains("request"), Is.True, "Response should contain request counter");
            }

            // Verify handler was reloaded during concurrent requests
            var finalInnerHandler = handler.InnerHandler;
            Assert.That(finalInnerHandler, Is.Not.SameAs(initialInnerHandler),
                "Handler should be recreated after CA file change, even during concurrent requests");
        }

        [Test]
        public async Task SendAsync_HandlesFailedCaFileRead()
        {
            // Arrange
            var caFilePath = _tempFiles.GetTempFilePath();
            File.WriteAllText(caFilePath, GetTestCertificatePem());

            var mockTransport = CreateMockTransport();
            var config = CreateTestConfig(caFilePath: caFilePath, transport: mockTransport);
            var handler = new KubernetesProxyHttpHandler(config);
            var httpClient = new HttpClient(handler);

            // Act - Make first request successfully, then delete file and make another request
            var response1 = await httpClient.GetAsync("https://login.microsoftonline.com/token");
            var initialInnerHandler = handler.InnerHandler;

            File.Delete(caFilePath);
            var response2 = await httpClient.GetAsync("https://login.microsoftonline.com/token");

            // Assert - Both requests should succeed (second uses cached handler when file is missing)
            Assert.That(response1.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response2.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(handler.InnerHandler, Is.SameAs(initialInnerHandler),
                "Handler should NOT be reloaded when CA file read fails (uses cached handler)");
        }

        [Test]
        public void SendAsync_ThrowsOnNullRequestUri()
        {
            // Arrange
            var mockTransport = new MockTransport(req =>
            {
                return new MockResponse(200);
            });

            var proxyConfig = CreateTestConfig("https://proxy.example.com", "proxy.sni.example.com", transport: mockTransport);

            var proxyHandler = new KubernetesProxyHttpHandler(proxyConfig);
            var httpClient = new HttpClient(proxyHandler);

            var request = new HttpRequestMessage(HttpMethod.Get, (Uri)null);

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await httpClient.SendAsync(request));
        }

        [Test]
        public async Task SendAsync_WithInlineCaData_DoesNotAttemptFileMonitoring()
        {
            // This test verifies that when CA data is provided inline (not via file),
            // the handler doesn't attempt any file monitoring or reloading behavior

            var mockTransport = CreateMockTransport();

            // Test with inline CA data - should work without any file operations
            var configWithInlineCA = CreateTestConfig(
                caData: GetTestCertificatePem(),
                caFilePath: null, // No file path - using inline data only
                transport: mockTransport);

            var handler = new KubernetesProxyHttpHandler(configWithInlineCA);
            var httpClient = new HttpClient(handler);

            // Act - Multiple requests should all succeed without any file system interaction
            var response1 = await httpClient.GetAsync("https://login.microsoftonline.com/token");
            var response2 = await httpClient.GetAsync("https://login.microsoftonline.com/token");

            // Assert - All requests succeed
            Assert.That(response1.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response2.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            // Verify the handler has certificate validation configured (proving CA data was used)
            var innerHandler = handler.InnerHandler as HttpClientHandler;
            Assert.That(innerHandler?.ServerCertificateCustomValidationCallback,
                Is.Not.Null,
                "Handler should be configured with certificate validation when CA data is provided");

            // The key point: with inline CA data, there's no file to monitor, so no reloading logic applies
            // This test demonstrates the handler works correctly with inline CA data
        }

        private string GetTestCertificatePem()
        {
            // Read the actual test certificate from the Data directory
            var certPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pem");
            return File.ReadAllText(certPath);
        }

        private string GetDifferentTestCertificatePem()
        {
            // Read a different test certificate to trigger reload
            var certPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert2.pem");
            return File.ReadAllText(certPath);
        }

        [Test]
        public async Task ConfigureCustomCertificates_ValidatesCorrectly()
        {
            // Test valid CA PEM configuration
            var validCaPem = GetTestCertificatePem();
            Assert.DoesNotThrow(() =>
            {
                var handler = new KubernetesProxyHttpHandler(CreateTestConfig(caData: validCaPem));
                Assert.That(handler, Is.Not.Null);
            }, "Handler creation with valid CA PEM should succeed");

            // Test invalid CA PEM throws exception
            var invalidCaPem = "-----BEGIN CERTIFICATE-----\nINVALID CERTIFICATE DATA\n-----END CERTIFICATE-----";
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                new KubernetesProxyHttpHandler(CreateTestConfig(caData: invalidCaPem));
            });
            Assert.That(ex.Message, Contains.Substring("Failed to configure custom CA certificate"));

            // Test handler works with custom CA for requests (using mock transport)
            var (response, _) = await SendRequestAndCapture(config: CreateTestConfig(caData: validCaPem));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void CertificateValidation_LoadsAndValidatesCertificateCorrectly()
        {
            // Verify certificate can be loaded from PEM data
            var validCaPem = GetTestCertificatePem();
            var cert = PemReader.LoadCertificate(validCaPem.AsSpan(), allowCertificateOnly: true);
            Assert.That(cert, Is.Not.Null, "CA certificate should be loadable from PEM data");

            // Verify handler creation with CA data configures certificate validation
            Assert.DoesNotThrow(() =>
            {
                var handler = new KubernetesProxyHttpHandler(CreateTestConfig(caData: validCaPem));
                Assert.That(handler, Is.Not.Null);
            }, "Handler should be created successfully with valid CA data");
        }

        [Test]
        public async Task SendAsync_WithNoCaData_DoesNotConfigureCertificateValidation()
        {
            // Test that handler works without CA data (uses default certificate validation)
            var (response, _) = await SendRequestAndCapture(config: CreateTestConfig(caData: null));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void CertificateValidationCallback_ConfiguresCorrectly()
        {
            var validCaPem = GetTestCertificatePem();

            // Test with CA data - should configure callback
            var proxyConfig = new KubernetesProxyConfig()
            {
                ProxyUrl = new Uri(DefaultProxyUrl),
                SniName = DefaultSniName,
                CaData = validCaPem,
                Transport = null
            };
            var handlerWithCa = new KubernetesProxyHttpHandler(proxyConfig);
            var innerHandlerWithCa = handlerWithCa.InnerHandler as HttpClientHandler;
            Assert.That(innerHandlerWithCa?.ServerCertificateCustomValidationCallback,
                Is.Not.Null,
                "Should configure callback when CA data provided");

            // Test without CA data - should not configure callback
            var proxyConfigNoCa = new KubernetesProxyConfig()
            {
                ProxyUrl = new Uri(DefaultProxyUrl),
                SniName = DefaultSniName,
                CaData = null,
                Transport = null
            };
            var handlerNoCa = new KubernetesProxyHttpHandler(proxyConfigNoCa);
            var innerHandlerNoCa = handlerNoCa.InnerHandler as HttpClientHandler;
            Assert.That(innerHandlerNoCa?.ServerCertificateCustomValidationCallback,
                Is.Null,
                "Should NOT configure callback when no CA data provided");

            // Test callback behavior - verify it configures chain policy and handles edge cases
            if (innerHandlerWithCa?.ServerCertificateCustomValidationCallback != null)
            {
                var testCert = PemReader.LoadCertificate(validCaPem.AsSpan(), allowCertificateOnly: true);
                var callback = innerHandlerWithCa.ServerCertificateCustomValidationCallback;

                // Test normal case - no SSL errors
                using (var chain = new X509Chain())
                {
                    Assert.DoesNotThrow(() => callback(null, testCert, chain, System.Net.Security.SslPolicyErrors.None));
                    Assert.That(chain.ChainPolicy.ExtraStore.Count > 0, Is.True, "CA should be added to ExtraStore");
                    Assert.That(chain.ChainPolicy.RevocationMode, Is.EqualTo(X509RevocationMode.NoCheck));
                    Assert.That(chain.ChainPolicy.VerificationFlags, Is.EqualTo(X509VerificationFlags.AllowUnknownCertificateAuthority));
                }

                // Test null certificate case
                using (var chain = new X509Chain())
                {
                    var result = callback(null, null, chain, System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors);
                    Assert.That(result, Is.False, "Should return false for null certificate");
                }

                // Test that non-chain SSL errors are rejected immediately (before chain validation)
                // These errors cannot be fixed by custom CA validation
                using (var chain = new X509Chain())
                {
                    var result = callback(null, testCert, chain, System.Net.Security.SslPolicyErrors.RemoteCertificateNameMismatch);
                    Assert.That(result, Is.False, "Should reject RemoteCertificateNameMismatch");
                }

                using (var chain = new X509Chain())
                {
                    var result = callback(null, testCert, chain, System.Net.Security.SslPolicyErrors.RemoteCertificateNotAvailable);
                    Assert.That(result, Is.False, "Should reject RemoteCertificateNotAvailable");
                }
            }
        }

        [Test]
        public async Task SendAsync_LogsWhenCaFileIsEmptyOrMissing()
        {
            // Arrange
            var caFilePath = _tempFiles.GetTempFilePath();
            File.WriteAllText(caFilePath, GetTestCertificatePem());

            var mockTransport = CreateMockTransport();
            var config = CreateTestConfig(caFilePath: caFilePath, transport: mockTransport);
            var handler = new KubernetesProxyHttpHandler(config);
            var httpClient = new HttpClient(handler);

            // Act - First request succeeds
            await httpClient.GetAsync("https://login.microsoftonline.com/token");
            var initialInnerHandler = handler.InnerHandler;

            // Start listening after first request
            using var listener = new TestEventListener();
            listener.EnableEvents(AzureIdentityEventSource.Singleton, EventLevel.Informational);

            File.WriteAllText(caFilePath, ""); // Empty the file
            await httpClient.GetAsync("https://login.microsoftonline.com/token");

            // Assert - Should log that reload was skipped
            var loggedEvents = listener.EventData.Where(e => e.EventName == "KubernetesProxyCaCertificateReloadSkipped").ToList();
            Assert.That(loggedEvents, Is.Not.Empty, "Should log when CA file is empty");

            // Verify the reason parameter contains expected text
            if (loggedEvents.Any())
            {
                var reason = loggedEvents.First().GetProperty<string>("reason");
                Assert.That(reason, Contains.Substring("empty or missing"));
            }

            // Verify handler was NOT reloaded
            Assert.That(handler.InnerHandler, Is.SameAs(initialInnerHandler),
                "Handler should NOT be reloaded when CA file becomes empty");
        }

        [Test]
        public async Task SendAsync_LogsWhenCaFileReadFails()
        {
            // Arrange
            var caFilePath = _tempFiles.GetTempFilePath();
            File.WriteAllText(caFilePath, GetTestCertificatePem());

            var mockTransport = CreateMockTransport();
            var config = CreateTestConfig(caFilePath: caFilePath, transport: mockTransport);
            var handler = new KubernetesProxyHttpHandler(config);
            var httpClient = new HttpClient(handler);

            // Act - First request succeeds
            await httpClient.GetAsync("https://login.microsoftonline.com/token");
            var initialInnerHandler = handler.InnerHandler;

            // Start listening after first request
            using var listener = new TestEventListener();
            listener.EnableEvents(AzureIdentityEventSource.Singleton, EventLevel.Warning);

            File.Delete(caFilePath);
            await httpClient.GetAsync("https://login.microsoftonline.com/token");

            // Assert - Should log a warning about the read failure
            var loggedEvents = listener.EventData.Where(e => e.EventName == "KubernetesProxyCaCertificateReloadFailed").ToList();
            Assert.That(loggedEvents, Is.Not.Empty, "Should log when CA file read fails");

            // Verify the error parameter exists
            if (loggedEvents.Any())
            {
                var error = loggedEvents.First().GetProperty<string>("error");
                Assert.That(error, Is.Not.Null.And.Not.Empty);
            }

            // Verify handler was NOT reloaded
            Assert.That(handler.InnerHandler, Is.SameAs(initialInnerHandler),
                "Handler should NOT be reloaded when CA file read fails (uses cached handler)");
        }

        [Test]
        public async Task SendAsync_LogsWhenCaCertificateChanges()
        {
            // Arrange
            var caFilePath = _tempFiles.GetTempFilePath();
            var cert1 = GetTestCertificatePem();
            var cert2 = GetDifferentTestCertificatePem();
            File.WriteAllText(caFilePath, cert1);

            var requestCount = 0;
            var mockTransport = CreateMockTransport(requestValidator: req =>
            {
                requestCount++;
                if (requestCount == 2)
                {
                    File.WriteAllText(caFilePath, cert2);
                    Task.Delay(10).GetAwaiter().GetResult();
                }
            });

            var config = CreateTestConfig(caFilePath: caFilePath, transport: mockTransport);
            var handler = new KubernetesProxyHttpHandler(config);
            var httpClient = new HttpClient(handler);

            // Act - Make first two requests
            await httpClient.GetAsync("https://login.microsoftonline.com/token");
            await httpClient.GetAsync("https://login.microsoftonline.com/token");
            var initialInnerHandler = handler.InnerHandler;

            // Start listening before the third request that should detect the change
            using var listener = new TestEventListener();
            listener.EnableEvents(AzureIdentityEventSource.Singleton, EventLevel.Informational);

            // This request should detect the change and log
            await httpClient.GetAsync("https://login.microsoftonline.com/token");

            // Assert - Should log that the certificate changed
            var loggedEvents = listener.EventData.Where(e => e.EventName == "KubernetesProxyCaCertificateReloaded").ToList();
            Assert.That(loggedEvents, Is.Not.Empty, "Should log when CA certificate changes");

            // Verify handler WAS reloaded
            Assert.That(handler.InnerHandler, Is.Not.SameAs(initialInnerHandler),
                "Handler should be reloaded when CA certificate changes");
        }

        [Test]
        public async Task SendAsync_LogsDoNotAppearWhenCertificateUnchanged()
        {
            // Arrange
            var caFilePath = _tempFiles.GetTempFilePath();
            File.WriteAllText(caFilePath, GetTestCertificatePem());

            var mockTransport = CreateMockTransport();
            var httpClient = CreateTestHttpClient(CreateTestConfig(caFilePath: caFilePath, transport: mockTransport));

            // Act - Make first request
            await httpClient.GetAsync("https://login.microsoftonline.com/token");

            // Start listening after first request
            using var listener = new TestEventListener();
            listener.EnableEvents(AzureIdentityEventSource.Singleton, EventLevel.Informational);

            await httpClient.GetAsync("https://login.microsoftonline.com/token");
            await httpClient.GetAsync("https://login.microsoftonline.com/token");

            // Assert - Should not log anything about certificate reloading
            var reloadEvents = listener.EventData.Where(e =>
                e.EventName == "KubernetesProxyCaCertificateReloaded" ||
                e.EventName == "KubernetesProxyCaCertificateReloadSkipped" ||
                e.EventName == "KubernetesProxyCaCertificateReloadFailed").ToList();
            Assert.That(reloadEvents, Is.Empty, "Should not log when CA certificate is unchanged");
        }
    }
}
