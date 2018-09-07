// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.ClientRuntime.Tests.CustomClients;
using Microsoft.Rest.ClientRuntime.Tests.Fakes;
using Microsoft.Rest.TransientFaultHandling;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;

namespace Microsoft.Rest.ClientRuntime.Tests
{
    public class ServiceClientTests
    {
        [Fact]
        public void ClientAddHandlerToPipelineAddsHandler()
        {
            var fakeClient = new FakeServiceClient(new HttpClientHandler(), new BadResponseDelegatingHandler());
            var result2 = fakeClient.DoStuffSync();
            Assert.Equal(HttpStatusCode.InternalServerError, result2.StatusCode);
        }

        [Fact]
        public void ClientDefaultHeaderValuesTest()
        {
            var fakeClient = new FakeServiceClient(new HttpClientHandler(), new BadResponseDelegatingHandler());
            var arr = fakeClient.HttpClient.DefaultRequestHeaders.UserAgent.Where(pihv => String.IsNullOrWhiteSpace(pihv.Product.Version)).ToArray();
            Assert.Empty(arr);
        }

        [Fact]
        public void ClientEmptyProductHeaderValuesTest()
        {
            var fakeClient = new FakeServiceClient(new HttpClientHandler(), new BadResponseDelegatingHandler());
            fakeClient.SetUserAgent("MySpecialHeader", string.Empty);
            var arr = fakeClient.HttpClient.DefaultRequestHeaders.UserAgent.Where(pihv => (pihv.Product.Name == "MySpecialHeader")).ToArray();
            Assert.Empty(arr);
        }

        [Fact]
        public void ClientAddHandlersToPipelineAddSingleHandler()
        {
            var fakeClient = new FakeServiceClient(new HttpClientHandler(),
                new BadResponseDelegatingHandler()
                );

            var result2 = fakeClient.DoStuffSync();
            Assert.Equal(HttpStatusCode.InternalServerError, result2.StatusCode);
        }

        [Fact]
        public void ClientAddHandlersToPipelineAddMultipleHandler()
        {
            var fakeClient = new FakeServiceClient(new HttpClientHandler(),
                new AddHeaderResponseDelegatingHandler("foo", "bar"),
                new BadResponseDelegatingHandler()
                );

            var result2 = fakeClient.DoStuffSync();
            Assert.Equal(result2.Headers.GetValues("foo").FirstOrDefault(), "bar");
            Assert.Equal(HttpStatusCode.InternalServerError, result2.StatusCode);
        }

        [Fact]
        public void ClientAddHandlersToPipelineChainsEmptyHandler()
        {
            var handlerA = new AppenderDelegatingHandler("A");
            var handlerB = new AppenderDelegatingHandler("B");
            var handlerC = new AppenderDelegatingHandler("C");

            var fakeClient = new FakeServiceClient(new HttpClientHandler(),
                handlerA, handlerB, handlerC,
                new MirrorDelegatingHandler());

            var response = fakeClient.DoStuffSync("Text").Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.Equal("Text+A+B+C", response);
        }

        [Fact]
        public void ClientAddHandlersToPipelineChainsNestedHandler()
        {
            var handlerA = new AppenderDelegatingHandler("A");
            var handlerB = new AppenderDelegatingHandler("B");
            var handlerC = new AppenderDelegatingHandler("C");
            handlerA.InnerHandler = handlerB;
            handlerB.InnerHandler = handlerC;
            var handlerD = new AppenderDelegatingHandler("D");
            var handlerE = new AppenderDelegatingHandler("E");
            handlerD.InnerHandler = handlerE;
            handlerE.InnerHandler = new MirrorMessageHandler("F");

            var fakeClient = new FakeServiceClient(new HttpClientHandler(),
                handlerA, handlerD,
                new MirrorDelegatingHandler());

            var response = fakeClient.DoStuffSync("Text").Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.Equal("Text+A+B+C+D+E", response);
        }

        [Fact]
        public void ClientWithoutHandlerWorks()
        {
            var fakeClient = new FakeServiceClient(new HttpClientHandler(),
                new MirrorDelegatingHandler());

            var response = fakeClient.DoStuffSync("Text").Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.Equal("Text", response);
        }

        [Fact]
        public void RetryHandlerRetriesWith500Errors()
        {
            var fakeClient = new FakeServiceClient(new FakeHttpHandler());
            int attemptsFailed = 0;

            var retryPolicy = new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(2);
            fakeClient.SetRetryPolicy(retryPolicy);
            var retryHandler = fakeClient.HttpMessageHandlers.OfType<RetryDelegatingHandler>().FirstOrDefault();
            retryPolicy.Retrying += (sender, args) => { attemptsFailed++; };

            var result = fakeClient.DoStuffSync();
            Assert.Equal(HttpStatusCode.InternalServerError, result.StatusCode);
            Assert.Equal(2, attemptsFailed);
        }

        [Fact]
        public void RetryAfterHandleTest()
        {
            var http = new FakeHttpHandler();
            http.NumberOfTimesToFail = 2;
            http.StatusCodeToReturn = (HttpStatusCode) 429;
            http.TweakResponse = (response) => { response.Headers.Add("Retry-After", "10"); };

            var fakeClient = new FakeServiceClient(http, new RetryAfterDelegatingHandler());
            
            var result = fakeClient.DoStuffSync();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(2, http.NumberOfTimesFailedSoFar);
        }

        [Fact]
        public void FakeSvcClientWithHttpClient()
        {
            HttpClient hc = new HttpClient(new ContosoMessageHandler());
            var fakeClient = new FakeServiceClient(hc);
            HttpResponseMessage response = fakeClient.DoStuffSync();
            string responseContent = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.Equal("Contoso Rocks", responseContent);
        }

        [Fact]
        public void RetryHandlerRetriesWith500ErrorsAndSucceeds()
        {
            var fakeClient = new FakeServiceClient(new FakeHttpHandler() {NumberOfTimesToFail = 1});
            int attemptsFailed = 0;

            var retryPolicy = new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(2);
            fakeClient.SetRetryPolicy(retryPolicy);
            var retryHandler = fakeClient.HttpMessageHandlers.OfType<RetryDelegatingHandler>().FirstOrDefault();
            retryPolicy.Retrying += (sender, args) => { attemptsFailed++; };

            var result = fakeClient.DoStuffSync();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(1, attemptsFailed);
        }

        [Fact]
        public void RetryHandlerDoesntRetryFor400Errors()
        {
            var fakeClient = new FakeServiceClient(new FakeHttpHandler() {StatusCodeToReturn = HttpStatusCode.Conflict});
            int attemptsFailed = 0;

            var retryPolicy = new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(2);
            fakeClient.SetRetryPolicy(retryPolicy);
            var retryHandler = fakeClient.HttpMessageHandlers.OfType<RetryDelegatingHandler>().FirstOrDefault();
            retryPolicy.Retrying += (sender, args) => { attemptsFailed++; };

            var result = fakeClient.DoStuffSync();
            Assert.Equal(HttpStatusCode.Conflict, result.StatusCode);
            Assert.Equal(0, attemptsFailed);
        }

        [Fact]
        public void HeadersAndPayloadAreNotDisposed()
        {
            FakeServiceClient fakeClient = null;
            try
            {
                fakeClient = new FakeServiceClient(new HttpClientHandler(),
                     new MirrorDelegatingHandler());
                var response = fakeClient.DoStuffAndThrowSync("Text");
                Assert.True(false);
            }
            catch (HttpOperationException ex)
            {
                fakeClient.Dispose();
                fakeClient = null;
                GC.Collect();
                Assert.NotNull(ex.Request);
                Assert.NotNull(ex.Response);
                Assert.Equal("2013-11-01", ex.Request.Headers["x-ms-version"].First());
                Assert.Equal("Text", ex.Response.Content);
            }
        }

        [Fact]
        public void AddUserAgentInfoWithoutVersion()
        {
            string defaultProductName = "FxVersion";
            string testProductName = "TestProduct";
            Version defaultProductVer, testProductVer;
            
            FakeServiceClient fakeClient = new FakeServiceClient(new FakeHttpHandler());
            fakeClient.SetUserAgent(testProductName);
            HttpResponseMessage response = fakeClient.DoStuffSync();
            HttpHeaderValueCollection<ProductInfoHeaderValue> userAgentValueCollection = fakeClient.HttpClient.DefaultRequestHeaders.UserAgent;

            var defaultProduct = userAgentValueCollection.Where<ProductInfoHeaderValue>((p) => p.Product.Name.Equals(defaultProductName)).FirstOrDefault<ProductInfoHeaderValue>();
            var testProduct = userAgentValueCollection.Where<ProductInfoHeaderValue>((p) => p.Product.Name.Equals(testProductName)).FirstOrDefault<ProductInfoHeaderValue>();

            Version.TryParse(defaultProduct.Product.Version, out defaultProductVer);
            Version.TryParse(testProduct.Product.Version, out testProductVer);

            Assert.True(defaultProduct.Product.Name.Equals(defaultProductName));
            Assert.NotNull(defaultProductVer);

            Assert.True(testProduct.Product.Name.Equals(testProductName));
            Assert.NotNull(testProductVer);
        }

        [Fact]
        public void AddUserAgentInfoWithVersion()
        {
            string defaultProductName = "FxVersion";
            string testProductName = "TestProduct";
            string testProductVersion = "1.0.0.0";
            Version defaultProductVer, testProductVer;

            FakeServiceClient fakeClient = new FakeServiceClient(new FakeHttpHandler());
            fakeClient.SetUserAgent(testProductName, testProductVersion);
            HttpResponseMessage response = fakeClient.DoStuffSync();
            HttpHeaderValueCollection<ProductInfoHeaderValue> userAgentValueCollection = fakeClient.HttpClient.DefaultRequestHeaders.UserAgent;

            var defaultProduct = userAgentValueCollection.Where<ProductInfoHeaderValue>((p) => p.Product.Name.Equals(defaultProductName)).FirstOrDefault<ProductInfoHeaderValue>();
            var testProduct = userAgentValueCollection.Where<ProductInfoHeaderValue>((p) => p.Product.Name.Equals(testProductName)).FirstOrDefault<ProductInfoHeaderValue>();

            Version.TryParse(defaultProduct.Product.Version, out defaultProductVer);
            Version.TryParse(testProduct.Product.Version, out testProductVer);

            Assert.True(defaultProduct.Product.Name.Equals(defaultProductName));
            Assert.NotNull(defaultProductVer);

            Assert.True(testProduct.Product.Name.Equals(testProductName));
            Assert.True(testProduct.Product.Version.Equals(testProductVersion));
        }

        [Fact]
        public void AddDuplicateUserAgentInfo()
        {
            // FullNetFx -- Default (3) + 1 (TestClient) + 1 added below = 5
            // NetCore -- Default (1 as OS Name and version is not applicable in netCore) + 1 (TestClient) + 1 (below) = 3
            string defaultProductName = "FxVersion";
            string testProductName = "TestProduct";
            string testProductVersion = "1.0.0.0";

            FakeServiceClient fakeClient = new FakeServiceClient(new FakeHttpHandler());
            fakeClient.SetUserAgent(testProductName, testProductVersion);

#if FullNetFx
            Assert.Equal(5, fakeClient.HttpClient.DefaultRequestHeaders.UserAgent.Count);
# elif !FullNetFx
            Assert.Equal(3, fakeClient.HttpClient.DefaultRequestHeaders.UserAgent.Count);
#endif

            fakeClient.SetUserAgent(testProductName, testProductVersion);

#if FullNetFx
            Assert.Equal(5, fakeClient.HttpClient.DefaultRequestHeaders.UserAgent.Count);
# elif !FullNetFx
            Assert.Equal(3, fakeClient.HttpClient.DefaultRequestHeaders.UserAgent.Count);
#endif
        }

        [Fact]
        public void CheckIfHttpClientIsDisposed()
        {
            FakeServiceClient fakeClient = new FakeServiceClient(new FakeHttpHandler());
            fakeClient.DoStuffSync();

            fakeClient.Dispose();
            try
            {
                fakeClient.DoStuffSync();
            }
            catch(NullReferenceException nEx)
            {
                Assert.True(true);
            }
        }



#if FullNetFx
        [Fact]
        public void VerifyOsInfoInUserAgent()
        {
            string osInfoProductName = "OSName";

            FakeServiceClient fakeClient = new FakeServiceClient(new FakeHttpHandler());
            HttpResponseMessage response = fakeClient.DoStuffSync();
            HttpHeaderValueCollection<ProductInfoHeaderValue> userAgentValueCollection = fakeClient.HttpClient.DefaultRequestHeaders.UserAgent;

            var osProduct = userAgentValueCollection.Where<ProductInfoHeaderValue>((p) => p.Product.Name.Equals(osInfoProductName)).FirstOrDefault<ProductInfoHeaderValue>();

            Assert.NotEmpty(osProduct.Product.Name);
            Assert.NotEmpty(osProduct.Product.Version);
        }

        [Fact]
        public void AddingSpCharsInUserAgent()
        {
            string sampleProd = "SampleProdName";
            string newSampleProd = "NewSampleProdName";
            string spChars = "*()!@#$%^&";
            string sampleVersion = "1.*.0.*";

            FakeServiceClient fakeClient = new FakeServiceClient(new FakeHttpHandler());
            fakeClient.SetUserAgent(string.Concat(sampleProd, spChars));
            HttpHeaderValueCollection<ProductInfoHeaderValue> userAgentValueCollection = fakeClient.HttpClient.DefaultRequestHeaders.UserAgent;
            var retrievedProdInfo = userAgentValueCollection.Where<ProductInfoHeaderValue>((p) => p.Product.Name.Equals(sampleProd)).FirstOrDefault<ProductInfoHeaderValue>();
            Assert.Equal(retrievedProdInfo?.Product?.Name, sampleProd);

            fakeClient.SetUserAgent(newSampleProd, sampleVersion);
            HttpHeaderValueCollection<ProductInfoHeaderValue> userAgentVersion = fakeClient.HttpClient.DefaultRequestHeaders.UserAgent;
            var retrievedVersion = userAgentVersion.Where<ProductInfoHeaderValue>((p) => p.Product.Name.Equals(newSampleProd)).FirstOrDefault<ProductInfoHeaderValue>();
            Assert.Equal(retrievedVersion?.Product?.Version, sampleVersion);
        }

#endif
    }
}