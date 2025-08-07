// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace System.ClientModel.Tests.Options
{
    internal class ClientLoggingOptionsTests
    {
        [Test]
        public void NonCollectionPropertiesDefaultToNull()
        {
            ClientLoggingOptions options = new();
            Assert.AreEqual(null, options.EnableLogging);
            Assert.AreEqual(null, options.EnableMessageLogging);
            Assert.AreEqual(null, options.EnableMessageContentLogging);
            Assert.AreEqual(null, options.MessageContentSizeLimit);
            Assert.AreEqual(null, options.LoggerFactory);
        }

        [Test]
        public void CollectionPropertiesDefaultsAreSet()
        {
            string[] expectedDefaultAllowedHeaderNames = [
            "traceparent",
            "Accept",
            "Cache-Control",
            "Connection",
            "Content-Length",
            "Content-Type",
            "Date",
            "ETag",
            "Expires",
            "If-Match",
            "If-Modified-Since",
            "If-None-Match",
            "If-Unmodified-Since",
            "Last-Modified",
            "Pragma",
            "Retry-After",
            "Server",
            "Transfer-Encoding",
            "User-Agent",
            "WWW-Authenticate" ];
            string[] expectedDefaultAllowedQueryParameters = ["api-version"];

            ClientLoggingOptions options = new();
            CollectionAssert.AreEquivalent(expectedDefaultAllowedHeaderNames, options.AllowedHeaderNames);
            CollectionAssert.AreEquivalent(expectedDefaultAllowedQueryParameters, options.AllowedQueryParameters);
        }

        [Test]
        public void CanModifyOptions()
        {
            ClientLoggingOptions options = new();

            options.MessageContentSizeLimit = 5;
            options.LoggerFactory = NullLoggerFactory.Instance;
            options.EnableLogging = false;
            options.EnableMessageLogging = false;
            options.EnableMessageContentLogging = false;
            options.AllowedHeaderNames.Add("Hello");
            options.AllowedQueryParameters.Add("Hello");

            Assert.AreEqual(5, options.MessageContentSizeLimit);
            Assert.AreEqual(NullLoggerFactory.Instance, options.LoggerFactory);
            Assert.AreEqual(false, options.EnableLogging);
            Assert.AreEqual(false, options.EnableMessageLogging);
            Assert.AreEqual(false, options.EnableMessageContentLogging);
            CollectionAssert.Contains(options.AllowedHeaderNames, "Hello");
            CollectionAssert.Contains(options.AllowedQueryParameters, "Hello");
        }

        [Test]
        public void DefaultOptionsFreeze()
        {
            ClientLoggingOptions options = new();

            options.Freeze();

            Assert.Throws<InvalidOperationException>(() => options.AllowedHeaderNames.Add("ShouldNotAdd"));
            Assert.Throws<InvalidOperationException>(() => options.AllowedQueryParameters.Add("ShouldNotAdd"));
            Assert.Throws<InvalidOperationException>(() => options.EnableLogging = true);
            Assert.Throws<InvalidOperationException>(() => options.EnableMessageLogging = true);
            Assert.Throws<InvalidOperationException>(() => options.EnableMessageContentLogging = true);
            Assert.Throws<InvalidOperationException>(() => options.MessageContentSizeLimit = 5);
            Assert.Throws<InvalidOperationException>(() => options.LoggerFactory = new NullLoggerFactory());
        }

        [Test]
        public void CustomizedOptionsFreeze()
        {
            ClientLoggingOptions options = new();
            options.MessageContentSizeLimit = 5;
            options.LoggerFactory = NullLoggerFactory.Instance;
            options.EnableLogging = false;
            options.EnableMessageLogging = false;
            options.EnableMessageContentLogging = false;
            options.AllowedHeaderNames.Add("Hello");
            options.AllowedQueryParameters.Add("Hello");

            options.Freeze();

            Assert.Throws<InvalidOperationException>(() => options.AllowedHeaderNames.Add("ShouldNotAdd"));
            Assert.Throws<InvalidOperationException>(() => options.AllowedQueryParameters.Add("ShouldNotAdd"));
            Assert.Throws<InvalidOperationException>(() => options.EnableLogging = true);
            Assert.Throws<InvalidOperationException>(() => options.EnableMessageLogging = true);
            Assert.Throws<InvalidOperationException>(() => options.EnableMessageContentLogging = true);
            Assert.Throws<InvalidOperationException>(() => options.MessageContentSizeLimit = 10);
            Assert.Throws<InvalidOperationException>(() => options.LoggerFactory = new NullLoggerFactory());
        }
    }
}
