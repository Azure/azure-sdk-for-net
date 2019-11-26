// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ClientRuntime.FullDesktop.Tests
{
    using ClientRuntime.Tests.Common.Fakes;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Xunit;
    public class FullFxUserAgentTests
    {
        [Fact]
        public void VerifyDifferentUserAgentStrings()
        {
            Dictionary<string, string> spChars = new Dictionary<string, string>() {
                { "p1", @"Linux4.4.0-93-generic11614.04.1-UbuntuSMPMonAug1416:07:05UTC2017" },
                { "p2", @"Linux4.4.0-93-generic;11614" },
                { "p3", @"Linux4.4.0-93-generic=11614" },
                { "p4", @"©Linux4" },
                { "p5", @"Linux4    generic" },
                { "p6", @"Linux4 "+
                            "generic" },
                { "p7", @"Linux4\r\ngeneric" },
                { "p8", @"Linux4\rgeneric" },
                { "p9", @"Linux4\ngeneric" },
                { "p10", @"Linux4\generic" },
                {"p11", @"Darwin17.7.0DarwinKernelVersion17.7.0ThuJun21225314PDT2018rootxnu-4570.71.21/RELEASE_X86_64" }
            };

            FakeServiceClient fakeClient = new FakeServiceClient(new FakeHttpHandler());
            foreach (KeyValuePair<string, string> kv in spChars)
            {
                fakeClient.SetUserAgent(kv.Key, kv.Value);
            }

            // If we get an exception, meaning user agent string is not compatible.
        }

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

            string concatProdName = string.Concat(sampleProd, spChars);
            string cleanedProdName = string.Concat(sampleProd, ".");

            FakeServiceClient fakeClient = new FakeServiceClient(new FakeHttpHandler());
            fakeClient.SetUserAgent(concatProdName);
            HttpHeaderValueCollection<ProductInfoHeaderValue> userAgentValueCollection = fakeClient.HttpClient.DefaultRequestHeaders.UserAgent;
            Assert.Equal(5, userAgentValueCollection.Count);

            var retrievedProdInfo = userAgentValueCollection.Where<ProductInfoHeaderValue>((p) => p.Product.Name.Equals(cleanedProdName)).FirstOrDefault<ProductInfoHeaderValue>();
            Assert.Equal(retrievedProdInfo?.Product?.Name, cleanedProdName);

            fakeClient.SetUserAgent(newSampleProd, sampleVersion);
            HttpHeaderValueCollection<ProductInfoHeaderValue> userAgentVersion = fakeClient.HttpClient.DefaultRequestHeaders.UserAgent;
            var retrievedVersion = userAgentVersion.Where<ProductInfoHeaderValue>((p) => p.Product.Name.Equals(newSampleProd)).FirstOrDefault<ProductInfoHeaderValue>();
            Assert.Equal(retrievedVersion?.Product?.Version, "1.0.");
        }

        [Fact]
        public void AddDuplicateUserAgentInfo()
        {
            // FullNetFx -- Default (3) + 1 (TestClient) + 1 added below = 5
            string defaultProductName = "FxVersion";
            string testProductName = "TestProduct";
            string testProductVersion = "1.0.0.0";

            FakeServiceClient fakeClient = new FakeServiceClient(new FakeHttpHandler());
            fakeClient.SetUserAgent(testProductName, testProductVersion);

            Assert.Equal(5, fakeClient.HttpClient.DefaultRequestHeaders.UserAgent.Count);
            fakeClient.SetUserAgent(testProductName, testProductVersion);
            Assert.Equal(5, fakeClient.HttpClient.DefaultRequestHeaders.UserAgent.Count);
        }
    }
}
