// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
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
            if (config.Transport == null) config.Transport = mockTransport;

            var httpClient = CreateTestHttpClient(config);
            var request = new HttpRequestMessage(method, targetUrl) { Content = content };
            var response = await httpClient.SendAsync(request);

            return (response, capturedRequest);
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
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(expectedUrl, request.Uri.ToString());
            Assert.IsTrue(request.Headers.TryGetValue("Host", out var hostHeader));
            Assert.AreEqual(DefaultSniName, hostHeader);
        }

        [Test]
        public async Task SendAsync_PreservesQueryParameters()
        {
            // Arrange & Act
            var targetUrl = "https://login.microsoftonline.com/oauth2/token?api-version=2.0&scope=test";
            var (response, request) = await SendRequestAndCapture(targetUrl);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(request.Uri.Query.Contains("api-version=2.0"), $"Expected query to contain api-version=2.0 but got: {request.Uri.Query}");
            Assert.IsTrue(request.Uri.Query.Contains("scope=test"));
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
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(capturedRequest.Headers.TryGetValue("Authorization", out var authHeader));
            Assert.AreEqual("Bearer test-token", authHeader);
            Assert.IsTrue(capturedRequest.Headers.TryGetValue("X-Custom-Header", out var customHeader));
            Assert.AreEqual("custom-value", customHeader);
        }

        [Test]
        public async Task SendAsync_CopiesRequestContentAndHandlesResponses()
        {
            // Test both request content copying and response handling
            var requestContent = new StringContent("{\"grant_type\":\"client_credentials\"}", Encoding.UTF8, "application/json");
            // Test with success response
            var (response, request) = await SendRequestAndCapture(content: requestContent, method: HttpMethod.Post);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(request.Content);
            Assert.IsTrue(request.Content.TryComputeLength(out var length) && length > 0);

            // Test with error response
            var mockTransport = CreateMockTransport("{\"error\":\"unauthorized\"}", 401);
            var httpClient = CreateTestHttpClient(CreateTestConfig(transport: mockTransport));
            var errorResponse = await httpClient.GetAsync("https://login.microsoftonline.com/token");
            Assert.AreEqual(HttpStatusCode.Unauthorized, errorResponse.StatusCode);
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
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(response.Headers.Contains("X-Custom-Response"));
            Assert.IsTrue(response.Content.Headers.Contains("Content-Type"));
        }

        [Test]
        public async Task SendAsync_DoesNotReloadWhenNoCaFileOrEmptyFile()
        {
            var requestCount = 0;
            var mockTransport = CreateMockTransport(requestValidator: _ => requestCount++);

            // Test 1: No CA file
            var httpClient1 = CreateTestHttpClient(CreateTestConfig(transport: mockTransport));
            await httpClient1.GetAsync("https://login.microsoftonline.com/token");
            await httpClient1.GetAsync("https://login.microsoftonline.com/token");
            Assert.AreEqual(2, requestCount, "Should not reload when no CA file");

            // Test 2: Empty CA file
            requestCount = 0;
            var caFilePath = _tempFiles.GetTempFilePath();
            File.WriteAllText(caFilePath, "");
            var httpClient2 = CreateTestHttpClient(CreateTestConfig(caFilePath: caFilePath, transport: mockTransport));
            await httpClient2.GetAsync("https://login.microsoftonline.com/token");
            await httpClient2.GetAsync("https://login.microsoftonline.com/token");
            Assert.AreEqual(2, requestCount, "Should not reload when CA file is empty");
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
                    Thread.Sleep(10); // Allow file system to flush
                }
            });

            var httpClient = CreateTestHttpClient(CreateTestConfig(caFilePath: caFilePath, transport: mockTransport));

            // Act - Make requests before and after CA change
            var response1 = await httpClient.GetAsync("https://login.microsoftonline.com/token");
            var response2 = await httpClient.GetAsync("https://login.microsoftonline.com/token");
            var response3 = await httpClient.GetAsync("https://login.microsoftonline.com/token");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response1.StatusCode);
            Assert.AreEqual(HttpStatusCode.OK, response2.StatusCode);
            Assert.AreEqual(HttpStatusCode.OK, response3.StatusCode);
            Assert.AreEqual(3, requestCount);
        }

        [Test]
        public async Task SendAsync_ConcurrentRequestsDuringCaFileReloadAllSucceed()
        {
            // Arrange
            var caFilePath = _tempFiles.GetTempFilePath();
            File.WriteAllText(caFilePath, GetTestCertificatePem());

            var requestCounter = 0;
            var mockTransport = new MockTransport(req =>
            {
                var currentRequest = Interlocked.Increment(ref requestCounter);
                // Trigger reload on second request
                if (currentRequest == 2)
                {
                    File.WriteAllText(caFilePath, GetDifferentTestCertificatePem());
                    Thread.Sleep(10);
                }

                Thread.Sleep(50); // Simulate processing time
                var response = new MockResponse(200);
                response.SetContent($"{{\"request\":{currentRequest}}}");
                return response;
            });

            var httpClient = CreateTestHttpClient(CreateTestConfig(caFilePath: caFilePath, transport: mockTransport));

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
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                var content = await response.Content.ReadAsStringAsync();
                Assert.IsTrue(content.Contains("request"), "Response should contain request counter");
            }
        }

        [Test]
        public async Task SendAsync_HandlesFailedCaFileRead()
        {
            // Arrange
            var caFilePath = _tempFiles.GetTempFilePath();
            File.WriteAllText(caFilePath, GetTestCertificatePem());

            var mockTransport = CreateMockTransport();
            var httpClient = CreateTestHttpClient(CreateTestConfig(caFilePath: caFilePath, transport: mockTransport));

            // Act - Make first request successfully, then delete file and make another request
            var response1 = await httpClient.GetAsync("https://login.microsoftonline.com/token");
            File.Delete(caFilePath);
            var response2 = await httpClient.GetAsync("https://login.microsoftonline.com/token");

            // Assert - Both requests should succeed (second uses cached handler when file is missing)
            Assert.AreEqual(HttpStatusCode.OK, response1.StatusCode);
            Assert.AreEqual(HttpStatusCode.OK, response2.StatusCode);
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
            Assert.AreEqual(HttpStatusCode.OK, response1.StatusCode);
            Assert.AreEqual(HttpStatusCode.OK, response2.StatusCode);

            // Verify the handler has certificate validation configured (proving CA data was used)
            var innerHandler = handler.InnerHandler as HttpClientHandler;
            Assert.IsNotNull(innerHandler?.ServerCertificateCustomValidationCallback,
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
                Assert.IsNotNull(handler);
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
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
#if NET5_0_OR_GREATER
        public void CertificateValidation_LoadsAndValidatesCertificateCorrectly()
        {
            // Verify certificate can be loaded from PEM data
            var validCaPem = GetTestCertificatePem();
            var cert = System.Security.Cryptography.X509Certificates.X509Certificate2.CreateFromPem(validCaPem);
            Assert.IsNotNull(cert, "CA certificate should be loadable from PEM data");

            // Verify handler creation with CA data configures certificate validation
            Assert.DoesNotThrow(() =>
            {
                var handler = new KubernetesProxyHttpHandler(CreateTestConfig(caData: validCaPem));
                Assert.IsNotNull(handler);
            }, "Handler should be created successfully with valid CA data");
        }
#else
        public void CertificateValidation_LoadsAndValidatesCertificateCorrectly()
        {
            Assert.Ignore("X509Certificate2.CreateFromPem is not available on .NET Framework");
        }
#endif

        [Test]
        public async Task SendAsync_WithNoCaData_DoesNotConfigureCertificateValidation()
        {
            // Test that handler works without CA data (uses default certificate validation)
            var (response, _) = await SendRequestAndCapture(config: CreateTestConfig(caData: null));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
#if NET5_0_OR_GREATER
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
            Assert.IsNotNull(innerHandlerWithCa?.ServerCertificateCustomValidationCallback,
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
            Assert.IsNull(innerHandlerNoCa?.ServerCertificateCustomValidationCallback,
                "Should NOT configure callback when no CA data provided");

            // Test callback behavior - verify it configures chain policy and handles edge cases
            if (innerHandlerWithCa?.ServerCertificateCustomValidationCallback != null)
            {
                var testCert = System.Security.Cryptography.X509Certificates.X509Certificate2.CreateFromPem(validCaPem);
                var callback = innerHandlerWithCa.ServerCertificateCustomValidationCallback;

                // Test normal case
                using (var chain = new X509Chain())
                {
                    Assert.DoesNotThrow(() => callback(null, testCert, chain, System.Net.Security.SslPolicyErrors.None));
                    Assert.IsTrue(chain.ChainPolicy.ExtraStore.Count > 0, "CA should be added to ExtraStore");
                    Assert.AreEqual(X509RevocationMode.NoCheck, chain.ChainPolicy.RevocationMode);
                    Assert.AreEqual(X509VerificationFlags.AllowUnknownCertificateAuthority, chain.ChainPolicy.VerificationFlags);
                }

                // Test null certificate case
                using (var chain = new X509Chain())
                {
                    var result = callback(null, null, chain, System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors);
                    Assert.IsFalse(result, "Should return false for null certificate");
                }
            }
        }
#else
        public void CertificateValidationCallback_ConfiguresCorrectly()
        {
            Assert.Ignore("X509Certificate2.CreateFromPem is not available on .NET Framework");
        }
#endif
    }
}
