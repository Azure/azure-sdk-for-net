// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net;
using System.Net.Http;
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

        [TearDown]
        public void Cleanup()
        {
            _tempFiles.CleanupTempFiles();
        }

        private static KubernetesProxyConfig CreateTestConfig(
            string proxyUrl,
            string sniName = null,
            string caFilePath = null,
            string caData = null,
            HttpPipelineTransport transport = null)
        {
            // Use reflection to create and configure the internal class
            var configType = typeof(KubernetesProxyConfig);
            var config = (KubernetesProxyConfig)Activator.CreateInstance(
                configType,
                nonPublic: true);

            // Set ProxyUrl
            var proxyUrlProperty = configType.GetProperty("ProxyUrl");
            proxyUrlProperty.SetValue(config, new Uri(proxyUrl));

            // Set SniName if provided
            if (sniName != null)
            {
                var sniNameProperty = configType.GetProperty("SniName");
                sniNameProperty.SetValue(config, sniName);
            }

            // Set CaFilePath if provided
            if (caFilePath != null)
            {
                var caFilePathProperty = configType.GetProperty("CaFilePath");
                caFilePathProperty.SetValue(config, caFilePath);
            }

            // Set CaData if provided
            if (caData != null)
            {
                var caDataProperty = configType.GetProperty("CaData");
                caDataProperty.SetValue(config, caData);
            }

            // Set Transport if provided
            if (transport != null)
            {
                var transportProperty = configType.GetProperty("Transport");
                transportProperty.SetValue(config, transport);
            }

            return config;
        }

        [Test]
        public void Constructor_ThrowsOnNullConfig()
        {
            Assert.Throws<ArgumentNullException>(() => new KubernetesProxyHttpHandler(null));
        }

        [Test]
        public async Task SendAsync_RewritesUrlToProxyUrl()
        {
            // Arrange
            var proxyUrl = "https://proxy.example.com:8443/token-proxy";
            var sniName = "proxy.sni.example.com";

            var mockTransport = new MockTransport(req =>
            {
                var response = new MockResponse(200);
                response.SetContent("{\"token\":\"test-token\"}");
                return response;
            });

            var proxyConfig = CreateTestConfig(proxyUrl, sniName, transport: mockTransport);

            var proxyHandler = new KubernetesProxyHttpHandler(proxyConfig);
            var httpClient = new HttpClient(proxyHandler);

            // Act
            var response = await httpClient.GetAsync("https://login.microsoftonline.com/tenant/oauth2/v2.0/token");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var request = mockTransport.SingleRequest;
            Assert.AreEqual("https://proxy.example.com:8443/token-proxy/tenant/oauth2/v2.0/token", request.Uri.ToString());
            Assert.IsTrue(request.Headers.TryGetValue("Host", out var hostHeader));
            Assert.AreEqual(sniName, hostHeader);
        }

        [Test]
        public async Task SendAsync_RewritesUrlWithRootProxyPath()
        {
            // Arrange
            var proxyUrl = "https://proxy.example.com:8443/";
            var sniName = "proxy.sni.example.com";

            var mockTransport = new MockTransport(req =>
            {
                var response = new MockResponse(200);
                response.SetContent("{\"token\":\"test-token\"}");
                return response;
            });

            var proxyConfig = CreateTestConfig(proxyUrl, sniName, transport: mockTransport);

            var proxyHandler = new KubernetesProxyHttpHandler(proxyConfig);
            var httpClient = new HttpClient(proxyHandler);

            // Act
            var response = await httpClient.GetAsync("https://login.microsoftonline.com/tenant/oauth2/v2.0/token");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var request = mockTransport.SingleRequest;
            Assert.AreEqual("https://proxy.example.com:8443/tenant/oauth2/v2.0/token", request.Uri.ToString());
        }

        [Test]
        public async Task SendAsync_PreservesQueryParameters()
        {
            // Arrange
            var proxyUrl = "https://proxy.example.com:8443";
            var sniName = "proxy.sni.example.com";

            var mockTransport = new MockTransport(req =>
            {
                var response = new MockResponse(200);
                response.SetContent("{}");
                return response;
            });

            var proxyConfig = CreateTestConfig(proxyUrl, sniName, caData: GetTestCertificatePem(), transport: mockTransport);

            var proxyHandler = new KubernetesProxyHttpHandler(proxyConfig);
            var httpClient = new HttpClient(proxyHandler);

            // Act
            var response = await httpClient.GetAsync("https://login.microsoftonline.com/oauth2/token?api-version=2.0&scope=test");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var request = mockTransport.SingleRequest;
            Assert.IsTrue(request.Uri.Query.Contains("api-version=2.0"), $"Expected query to contain api-version=2.0 but got: {request.Uri.Query}");
            Assert.IsTrue(request.Uri.Query.Contains("scope=test"));
        }

        [Test]
        public async Task SendAsync_CopiesRequestHeaders()
        {
            // Arrange
            var mockTransport = new MockTransport(req =>
            {
                var response = new MockResponse(200);
                response.SetContent("{}");
                return response;
            });

            var proxyConfig = CreateTestConfig("https://proxy.example.com", "proxy.sni.example.com", transport: mockTransport);

            var proxyHandler = new KubernetesProxyHttpHandler(proxyConfig);
            var httpClient = new HttpClient(proxyHandler);

            var request = new HttpRequestMessage(HttpMethod.Get, "https://login.microsoftonline.com/token");
            request.Headers.Add("Authorization", "Bearer test-token");
            request.Headers.Add("X-Custom-Header", "custom-value");

            // Act
            var response = await httpClient.SendAsync(request);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var capturedRequest = mockTransport.SingleRequest;
            Assert.IsTrue(capturedRequest.Headers.TryGetValue("Authorization", out var authHeader));
            Assert.AreEqual("Bearer test-token", authHeader);
            Assert.IsTrue(capturedRequest.Headers.TryGetValue("X-Custom-Header", out var customHeader));
            Assert.AreEqual("custom-value", customHeader);
        }

        [Test]
        public async Task SendAsync_CopiesRequestContent()
        {
            // Arrange
            var mockTransport = new MockTransport(req =>
            {
                var response = new MockResponse(200);
                response.SetContent("{}");
                return response;
            });

            var proxyConfig = CreateTestConfig("https://proxy.example.com", "proxy.sni.example.com", transport: mockTransport);

            var proxyHandler = new KubernetesProxyHttpHandler(proxyConfig);
            var httpClient = new HttpClient(proxyHandler);

            var requestContent = "{\"grant_type\":\"client_credentials\"}";
            var request = new HttpRequestMessage(HttpMethod.Post, "https://login.microsoftonline.com/token")
            {
                Content = new StringContent(requestContent, Encoding.UTF8, "application/json")
            };

            // Act
            var response = await httpClient.SendAsync(request);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var capturedRequest = mockTransport.SingleRequest;
            Assert.IsNotNull(capturedRequest.Content);

            var contentStream = capturedRequest.Content.TryComputeLength(out var length);
            Assert.IsTrue(length > 0);
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

            var proxyConfig = CreateTestConfig("https://proxy.example.com", "proxy.sni.example.com", transport: mockTransport);

            var proxyHandler = new KubernetesProxyHttpHandler(proxyConfig);
            var httpClient = new HttpClient(proxyHandler);

            // Act
            var response = await httpClient.GetAsync("https://login.microsoftonline.com/token");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(response.Headers.Contains("X-Custom-Response"));
            Assert.IsTrue(response.Content.Headers.Contains("Content-Type"));
        }

        [Test]
        public async Task SendAsync_HandlesNon200Responses()
        {
            // Arrange
            var mockTransport = new MockTransport(req =>
            {
                var response = new MockResponse(401);
                response.SetContent("{\"error\":\"unauthorized\"}");
                return response;
            });

            var proxyConfig = CreateTestConfig("https://proxy.example.com", "proxy.sni.example.com", transport: mockTransport);

            var proxyHandler = new KubernetesProxyHttpHandler(proxyConfig);
            var httpClient = new HttpClient(proxyHandler);

            // Act
            var response = await httpClient.GetAsync("https://login.microsoftonline.com/token");

            // Assert
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Test]
        public async Task SendAsync_DoesNotReloadHandlerWhenNoCaFile()
        {
            // Arrange
            var requestCount = 0;
            var mockTransport = new MockTransport(req =>
            {
                requestCount++;
                var response = new MockResponse(200);
                response.SetContent($"{{\"request\":{requestCount}}}");
                return response;
            });

            var proxyConfig = CreateTestConfig("https://proxy.example.com", "proxy.sni.example.com", transport: mockTransport);

            var proxyHandler = new KubernetesProxyHttpHandler(proxyConfig);
            var httpClient = new HttpClient(proxyHandler);

            // Act - Make multiple requests
            await httpClient.GetAsync("https://login.microsoftonline.com/token");
            await httpClient.GetAsync("https://login.microsoftonline.com/token");
            await httpClient.GetAsync("https://login.microsoftonline.com/token");

            // Assert
            Assert.AreEqual(3, requestCount);
        }

        [Test]
        public async Task SendAsync_DoesNotReloadHandlerWhenCaFileIsEmpty()
        {
            // Arrange
            var caFilePath = _tempFiles.GetTempFilePath();
            File.WriteAllText(caFilePath, ""); // Empty file

            var requestCount = 0;
            var mockTransport = new MockTransport(req =>
            {
                requestCount++;
                var response = new MockResponse(200);
                response.SetContent($"{{\"request\":{requestCount}}}");
                return response;
            });

            var proxyConfig = CreateTestConfig("https://proxy.example.com", "proxy.sni.example.com", caFilePath, transport: mockTransport);

            var proxyHandler = new KubernetesProxyHttpHandler(proxyConfig);
            var httpClient = new HttpClient(proxyHandler);

            // Act - Make multiple requests
            await httpClient.GetAsync("https://login.microsoftonline.com/token");
            await httpClient.GetAsync("https://login.microsoftonline.com/token");

            // Assert
            Assert.AreEqual(2, requestCount);
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

            var mockTransport = new MockTransport(req =>
            {
                requestCount++;

                // On the second request, change the CA file to trigger reload
                if (requestCount == 2)
                {
                    File.WriteAllText(caFilePath, cert2);
                    // Give a moment for file system to flush
                    Thread.Sleep(10);
                }

                var response = new MockResponse(200);
                response.SetContent($"{{\"request\":{requestCount}}}");
                return response;
            });

            var proxyConfig = CreateTestConfig("https://proxy.example.com", "proxy.sni.example.com", caFilePath, transport: mockTransport);

            var proxyHandler = new KubernetesProxyHttpHandler(proxyConfig);
            var httpClient = new HttpClient(proxyHandler);

            // Act - Make requests before and after CA change
            var response1 = await httpClient.GetAsync("https://login.microsoftonline.com/token1");
            var response2 = await httpClient.GetAsync("https://login.microsoftonline.com/token2");
            var response3 = await httpClient.GetAsync("https://login.microsoftonline.com/token3");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response1.StatusCode);
            Assert.AreEqual(HttpStatusCode.OK, response2.StatusCode);
            Assert.AreEqual(HttpStatusCode.OK, response3.StatusCode);
            Assert.AreEqual(3, requestCount);
        }

        [Test]
        public async Task SendAsync_InProgressRequestsNotInterruptedDuringHandlerReload()
        {
            // Arrange
            var caFilePath = _tempFiles.GetTempFilePath();
            var cert1 = GetTestCertificatePem();
            var cert2 = GetDifferentTestCertificatePem();

            File.WriteAllText(caFilePath, cert1);

            var firstRequestStarted = new ManualResetEventSlim(false);
            var allowReload = new ManualResetEventSlim(false);
            var firstRequestCompleted = false;

            var mockTransport = new MockTransport(req =>
            {
                // Signal that the first request has started
                firstRequestStarted.Set();

                // Wait for signal to proceed (simulating a slow request)
                allowReload.Wait();

                var response = new MockResponse(200);
                response.SetContent("{\"token\":\"success\"}");
                return response;
            });

            var proxyConfig = CreateTestConfig("https://proxy.example.com", "proxy.sni.example.com", caFilePath, transport: mockTransport);

            var proxyHandler = new KubernetesProxyHttpHandler(proxyConfig);
            var httpClient = new HttpClient(proxyHandler);

            // Act - Start first request in background
            var firstRequestTask = Task.Run(async () =>
            {
                var response = await httpClient.GetAsync("https://login.microsoftonline.com/token");
                firstRequestCompleted = true;
                return response;
            });

            // Wait for first request to start
            firstRequestStarted.Wait(TimeSpan.FromSeconds(5));

            // Change CA file while first request is in progress
            File.WriteAllText(caFilePath, cert2);
            Thread.Sleep(10); // Give file system time to flush

            // Start second request that will trigger reload check
            var secondRequestTask = Task.Run(async () =>
            {
                return await httpClient.GetAsync("https://login.microsoftonline.com/token");
            });

            // Give second request time to detect CA change and trigger reload
            await Task.Delay(100);

            // Now allow both requests to complete
            allowReload.Set();

            var firstResponse = await firstRequestTask;
            var secondResponse = await secondRequestTask;

            // Assert - Both requests should complete successfully
            Assert.IsTrue(firstRequestCompleted, "First request should complete successfully");
            Assert.AreEqual(HttpStatusCode.OK, firstResponse.StatusCode);
            Assert.AreEqual(HttpStatusCode.OK, secondResponse.StatusCode);

            var content1 = await firstResponse.Content.ReadAsStringAsync();
            var content2 = await secondResponse.Content.ReadAsStringAsync();
            Assert.IsTrue(content1.Contains("success"));
            Assert.IsTrue(content2.Contains("success"));
        }

        [Test]
        public async Task SendAsync_MultipleRequestsDuringReloadAllSucceed()
        {
            // Arrange
            var caFilePath = _tempFiles.GetTempFilePath();
            var cert1 = GetTestCertificatePem();
            var cert2 = GetDifferentTestCertificatePem();

            File.WriteAllText(caFilePath, cert1);

            var requestCounter = 0;
            var reloadTriggered = false;

            var mockTransport = new MockTransport(req =>
            {
                var currentRequest = Interlocked.Increment(ref requestCounter);

                // Trigger reload on second request
                if (currentRequest == 2 && !reloadTriggered)
                {
                    reloadTriggered = true;
                    File.WriteAllText(caFilePath, cert2);
                    Thread.Sleep(10);
                }

                // Simulate some processing time
                Thread.Sleep(50);

                var response = new MockResponse(200);
                response.SetContent($"{{\"request\":{currentRequest}}}");
                return response;
            });

            var proxyConfig = CreateTestConfig("https://proxy.example.com", "proxy.sni.example.com", caFilePath, transport: mockTransport);

            var proxyHandler = new KubernetesProxyHttpHandler(proxyConfig);
            var httpClient = new HttpClient(proxyHandler);

            // Act - Start multiple concurrent requests
            var tasks = new Task<HttpResponseMessage>[5];
            for (int i = 0; i < 5; i++)
            {
                tasks[i] = httpClient.GetAsync($"https://login.microsoftonline.com/token{i}");
            }

            var responses = await Task.WhenAll(tasks);

            // Assert - All requests should succeed
            foreach (var response in responses)
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                var content = await response.Content.ReadAsStringAsync();
                Assert.IsTrue(content.Contains("request"));
            }
        }

        [Test]
        public async Task SendAsync_HandlesFailedCaFileRead()
        {
            // Arrange
            var caFilePath = _tempFiles.GetTempFilePath();
            // Create the file initially but don't write anything
            File.WriteAllText(caFilePath, GetTestCertificatePem());

            var mockTransport = new MockTransport(req =>
            {
                var response = new MockResponse(200);
                response.SetContent("{}");
                return response;
            });

            var proxyConfig = CreateTestConfig("https://proxy.example.com", "proxy.sni.example.com", caFilePath, transport: mockTransport);

            var proxyHandler = new KubernetesProxyHttpHandler(proxyConfig);
            var httpClient = new HttpClient(proxyHandler);

            // Make first request successfully
            var response1 = await httpClient.GetAsync("https://login.microsoftonline.com/token");
            Assert.AreEqual(HttpStatusCode.OK, response1.StatusCode);

            // Delete the CA file to simulate read failure
            File.Delete(caFilePath);

            // Act - Make another request (should not reload since file is missing)
            var response2 = await httpClient.GetAsync("https://login.microsoftonline.com/token");

            // Assert - Request should still succeed using old handler
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
        public async Task SendAsync_WorksWithCaData()
        {
            // Arrange
            var mockTransport = new MockTransport(req =>
            {
                var response = new MockResponse(200);
                response.SetContent("{}");
                return response;
            });

            var proxyConfig = CreateTestConfig("https://proxy.example.com", "proxy.sni.example.com", caData: GetTestCertificatePem(), transport: mockTransport);

            var proxyHandler = new KubernetesProxyHttpHandler(proxyConfig);
            var httpClient = new HttpClient(proxyHandler);

            // Act
            var response = await httpClient.GetAsync("https://login.microsoftonline.com/token");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task SendAsync_DoesNotReloadWhenUsingCaData()
        {
            // Arrange - CaData is inline, so no file watching needed
            var requestCount = 0;
            var mockTransport = new MockTransport(req =>
            {
                requestCount++;
                var response = new MockResponse(200);
                response.SetContent($"{{\"request\":{requestCount}}}");
                return response;
            });

            var proxyConfig = CreateTestConfig("https://proxy.example.com", "proxy.sni.example.com", caData: GetTestCertificatePem(), transport: mockTransport);

            var proxyHandler = new KubernetesProxyHttpHandler(proxyConfig);
            var httpClient = new HttpClient(proxyHandler);

            // Act - Make multiple requests
            await httpClient.GetAsync("https://login.microsoftonline.com/token");
            await httpClient.GetAsync("https://login.microsoftonline.com/token");
            await httpClient.GetAsync("https://login.microsoftonline.com/token");

            // Assert
            Assert.AreEqual(3, requestCount);
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
    }
}
