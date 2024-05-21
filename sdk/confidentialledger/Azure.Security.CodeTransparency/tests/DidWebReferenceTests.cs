// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Security.CodeTransparency.Receipt;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;
using Azure.Core.TestFramework;

namespace Azure.Security.CodeTransparency.Tests
{
    public class DidWebReferenceTests
    {
        private string _fileQualifierPrefix;

        private byte[] readFileBytes(string name) {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(_fileQualifierPrefix+name))
            using (MemoryStream mem = new())
            {
                if (stream == null)
                    throw new FileNotFoundException("Resource not found: " + _fileQualifierPrefix+name);
                stream.CopyTo(mem);
                return mem.ToArray();
            }
        }

        [SetUp]
        public void BaseSetUp() {
            var assembly = Assembly.GetExecutingAssembly();
            string mustExistFilename = "sbom.json";
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith(mustExistFilename));
            Assert.IsNotNull(resourceName);
            _fileQualifierPrefix = resourceName.Split(new String[]{mustExistFilename}, StringSplitOptions.None)[0];
        }

        [Test]
        public void DidDocUrl_Checks()
        {
            var didUrlTestCases = new List<DidUrlTestCase>
            {
                new() { Issuer = "did:web:example.com", ExpectedUrl = "https://example.com/.well-known/did.json", ErrorContains = "" },
                new() { Issuer = "did:web:example.com:foo", ExpectedUrl = "https://example.com/foo/did.json", ErrorContains = "" },
                new() { Issuer = "did:web:example.com:foo:bar:baz", ExpectedUrl = "https://example.com/foo/bar/baz/did.json", ErrorContains = "" },
                new() { Issuer = "did:web:example.com%3A8080", ExpectedUrl = "https://example.com:8080/.well-known/did.json", ErrorContains = "" },
                new() { Issuer = "did:web:example.com%3A8080:foo", ExpectedUrl = "https://example.com:8080/foo/did.json", ErrorContains = "" },
                new() { Issuer = "did:web:example.com%3A8080:foo:bar:baz", ExpectedUrl = "https://example.com:8080/foo/bar/baz/did.json", ErrorContains = "" },
                new() { Issuer = "did:web:example.com:8080:foo:bar:baz", ExpectedUrl = "https://example.com/8080/foo/bar/baz/did.json", ErrorContains = "" },
                new() { Issuer = "did:web:", ExpectedUrl = "", ErrorContains = "invalid did:web issuer" },
                new() { Issuer = "did:web: ", ExpectedUrl = "", ErrorContains = "invalid did:web issuer" },
                new() { Issuer = "did:core:65465464654", ExpectedUrl = "", ErrorContains = "invalid did:web issuer" },
                new() { Issuer = "", ExpectedUrl = "", ErrorContains = "invalid did:web issuer" },
                new() { Issuer = "::::", ExpectedUrl = "", ErrorContains = "invalid did:web issuer" },
            };
            foreach (DidUrlTestCase testCase in didUrlTestCases)
            {
                try
                {
                    Assert.True(DidWebReference.ParseDidDocUrl(testCase.Issuer!).ToString() == testCase.ExpectedUrl, $"Did web url resolve test failed for {{{testCase.Issuer!}}}");
                }
                catch (Exception ex)
                {
                    Assert.False(!ex.Message.Contains(testCase.ErrorContains!), "Verification failed." + ex.Message);
                }
             }
        }

        public class DidUrlTestCase
        {
            public string Issuer { get; set; }
            public string ExpectedUrl { get; set; }
            public string ErrorContains { get; set; }
        }

        /// <summary>
        /// Get service certificate failure test for missing cert chain in x5c did:web
        /// </summary>
        [Test]
        public void DefaultResolver_uses_api_endpoint()
        {
            var mockedDidResponse = new MockResponse(200);
            byte[] didBytes = readFileBytes("service.2023-02.did.json");
            mockedDidResponse.SetContent(didBytes);
            var mockTransport = new MockTransport(mockedDidResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport
            };

            var resolver = DidWebReference.defaultResolver(options);
            DidWebReference instance = new(new Uri("https://foobar.confidential-ledger.azure.com/some/path/did.json"), "didkeyid");
            var doc = resolver(instance);
            Assert.NotNull(doc);
            Assert.AreEqual("https://foobar.confidential-ledger.azure.com/.well-known/did.json?api-version=2024-01-11-preview", mockTransport.Requests[0].Uri.ToString());
        }

        [Test]
        public void GetCert_using_x5c_Test()
        {
            byte[] didBytes = readFileBytes("service.2023-02.did.json");
            var didWebDoc = DidDocument.DeserializeDidDocument(JsonDocument.Parse(didBytes).RootElement);
            string keyId = "didkeyid";
            X509Certificate2 cert = DidWebReference.ParseCert(didWebDoc, keyId);
            Assert.NotNull(cert);
        }

        /// <summary>
        /// Get service certificate failure test for no matching assertion method
        /// </summary>
        [Test]
        public void GetCert_NoAssertionMethod_Failure_Test()
        {
            var didBytes = readFileBytes("service.did.invalid.json");
            var didWebDoc = DidDocument.DeserializeDidDocument(JsonDocument.Parse(didBytes).RootElement);
            string keyId = "notexists";
            var ex = Assert.Throws<Exception>(() => DidWebReference.ParseCert(didWebDoc, keyId));
            Assert.That(ex.Message, Contains.Substring("No matching assertion method found for key id {#notexists}"));
        }

        /// <summary>
        /// Get service certificate failure test for missing cert chain in x5c did:web
        /// </summary>
        [Test]
        public void GetCert_MissingCertInDidWeb_Failure_Test()
        {
            var didBytes = readFileBytes("service.did.invalid.json");
            var didWebDoc = DidDocument.DeserializeDidDocument(JsonDocument.Parse(didBytes).RootElement);
            string keyId = "didkeyid";
            var ex = Assert.Throws<Exception>(() => DidWebReference.ParseCert(didWebDoc, keyId));
            Assert.That(ex.Message, Contains.Substring("Missing cert chain in x5c"));
        }
    }
}