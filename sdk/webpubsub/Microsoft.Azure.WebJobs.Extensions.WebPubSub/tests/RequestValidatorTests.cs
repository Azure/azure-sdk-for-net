// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class RequestValidatorTests
    {
        [TestCase]
        public void TestRequestValidator_WithoutAllowedHosts_SkipsValidation()
        {
            var validator = new RequestValidator(null);

            Assert.IsTrue(validator.IsValidHost(["abc"]));
            Assert.IsTrue(validator.IsValidSignature("abc", "sha256=anything", "connectionId"));
        }

        [Test]
        public void TestRequestValidator_DuplicateHosts_Throws()
        {
            var a1 = new WebPubSubServiceAccess(new Uri("https://abc"), new KeyCredential("k1"));
            var a2 = new WebPubSubServiceAccess(new Uri("http://abc"), new KeyCredential("k2"));

            Assert.Throws<ArgumentException>(() => new RequestValidator([a1, a2]));
        }

        [TestCase("POST", "abc")]
        [TestCase("GET", "abc")]
        [TestCase(null, "abc")]
        public void TestIsValidationRequest_NonOptions_ReturnsFalse(string method, string originHeader)
        {
            var result = RequestValidator.IsValidationRequest(method, new StringValues(originHeader), out var requestHosts);
            Assert.IsFalse(result);
            Assert.IsNull(requestHosts);
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestIsValidationRequest_MissingOrigin_ReturnsFalse(string originHeader)
        {
            var result = RequestValidator.IsValidationRequest("OPTIONS", new StringValues(originHeader), out var requestHosts);
            Assert.IsFalse(result);
        }

        [Test]
        public void TestIsValidationRequest_SplitsOrigins()
        {
            var result = RequestValidator.IsValidationRequest("OPTIONS", new StringValues("a,b"), out var requestHosts);
            Assert.IsTrue(result);
            Assert.IsNotNull(requestHosts);
            CollectionAssert.AreEqual(new[] { "a", "b" }, requestHosts);
        }

        [Test]
        public void TestIsValidationRequest_MultipleOriginHeaderValues_AreAggregated()
        {
            var result = RequestValidator.IsValidationRequest(
                "OPTIONS",
                new StringValues(["a,b", "c"]),
                out var requestHosts);

            Assert.IsTrue(result);
            Assert.IsNotNull(requestHosts);
            CollectionAssert.AreEqual(new[] { "a", "b", "c" }, requestHosts);
        }

        [Test]
        public void TestIsValidHost_AllowsWhenAnyMatch()
        {
            var access = new WebPubSubServiceAccess(new Uri("https://abc"), new KeyCredential("k"));
            var validator = new RequestValidator([access]);

            Assert.IsTrue(validator.IsValidHost(new[] { "zzz", "abc" }));
            Assert.IsFalse(validator.IsValidHost(new[] { "zzz" }));
        }

        [Test]
        public void TestIsValidSignature_WhenOriginMissing_ReturnsFalse()
        {
            var access = new WebPubSubServiceAccess(new Uri("https://abc"), new KeyCredential("k"));
            var validator = new RequestValidator([access]);

            Assert.IsFalse(validator.IsValidSignature(null, "sha256=anything", "connectionId"));
            Assert.IsFalse(validator.IsValidSignature("", "sha256=anything", "connectionId"));
        }

        [Test]
        public void TestIsValidSignature_WhenOriginNotAllowed_ReturnsFalse()
        {
            var access = new WebPubSubServiceAccess(new Uri("https://abc"), new KeyCredential("k"));
            var validator = new RequestValidator([access]);

            Assert.IsFalse(validator.IsValidSignature("zzz", "sha256=anything", "connectionId"));
        }

        [Test]
        public void TestIsValidSignature_WhenSignatureMissing_ReturnsFalse()
        {
            var accessKey = "test-access-key";
            var access = new WebPubSubServiceAccess(new Uri("https://abc"), new KeyCredential(accessKey));
            var validator = new RequestValidator([access]);

            Assert.IsFalse(validator.IsValidSignature("abc", null, "connectionId"));
            Assert.IsFalse(validator.IsValidSignature("abc", string.Empty, "connectionId"));
        }

        [Test]
        public void TestIsValidSignature_WhenMismatch_ReturnsFalse()
        {
            var accessKey = "test-access-key";
            var access = new WebPubSubServiceAccess(new Uri("https://abc"), new KeyCredential(accessKey));
            var validator = new RequestValidator([access]);

            Assert.IsFalse(validator.IsValidSignature("abc", "sha256=deadbeef", "connectionId"));
        }

        [Test]
        public void TestIsValidSignature_WhenMatch_ReturnsTrue()
        {
            var connectionId = "connectionId";
            var accessKey = "test-access-key";
            var access = new WebPubSubServiceAccess(new Uri("https://abc"), new KeyCredential(accessKey));
            var validator = new RequestValidator([access]);

            var signature = ComputeSignature(accessKey, connectionId);
            Assert.IsTrue(validator.IsValidSignature("abc", signature, connectionId));
        }

        [TestCase]
        public void TestRequestValidator_WithoutAccessKey_SkipsSignatureValidation()
        {
            var access = new WebPubSubServiceAccess(new System.Uri("http://abc"), new KeyCredential(null));
            var validator = new RequestValidator([access]);

            Assert.IsTrue(validator.IsValidSignature("abc", "", "connectionId"));
        }

        private static string ComputeSignature(string accessKey, string connectionId)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(accessKey));
            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(connectionId));
            return "sha256=" + BitConverter.ToString(hashBytes).Replace("-", "");
        }
    }
}
