// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ClientRuntime.FullDesktop.Tests
{
    using ClientRuntime.Tests.Common.Fakes;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Xunit;

    public class FullFxServiceClientTests
    {
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

//#if FullNetFx
//            Assert.Equal(5, fakeClient.HttpClient.DefaultRequestHeaders.UserAgent.Count);
//# elif !FullNetFx
//            Assert.Equal(3, fakeClient.HttpClient.DefaultRequestHeaders.UserAgent.Count);
//#endif

            fakeClient.SetUserAgent(testProductName, testProductVersion);

//#if FullNetFx
            Assert.Equal(5, fakeClient.HttpClient.DefaultRequestHeaders.UserAgent.Count);
//# elif !FullNetFx
//            Assert.Equal(3, fakeClient.HttpClient.DefaultRequestHeaders.UserAgent.Count);
//#endif
        }
    }
}
