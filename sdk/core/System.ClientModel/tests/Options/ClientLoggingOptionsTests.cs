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

        [Test]
        public void IsReadOnlyIsFalseByDefault()
        {
            ClientLoggingOptions options = new();
            Assert.IsFalse(options.IsReadOnly);
        }

        [Test]
        public void IsReadOnlyIsTrueAfterFreeze()
        {
            ClientLoggingOptions options = new();
            options.Freeze();
            Assert.IsTrue(options.IsReadOnly);
        }

        [Test]
        public void CloneCreatesModifiableCopy()
        {
            ClientLoggingOptions original = new();
            original.MessageContentSizeLimit = 5;
            original.LoggerFactory = NullLoggerFactory.Instance;
            original.EnableLogging = false;
            original.EnableMessageLogging = false;
            original.EnableMessageContentLogging = false;
            original.AllowedHeaderNames.Add("CustomHeader");
            original.AllowedQueryParameters.Add("CustomQuery");
            original.Freeze();

            Assert.IsTrue(original.IsReadOnly);

            // Create a mutable copy from the frozen original
            ClientLoggingOptions copy = original.Clone();

            Assert.IsFalse(copy.IsReadOnly);
            Assert.AreEqual(original.MessageContentSizeLimit, copy.MessageContentSizeLimit);
            Assert.AreEqual(original.LoggerFactory, copy.LoggerFactory);
            Assert.AreEqual(original.EnableLogging, copy.EnableLogging);
            Assert.AreEqual(original.EnableMessageLogging, copy.EnableMessageLogging);
            Assert.AreEqual(original.EnableMessageContentLogging, copy.EnableMessageContentLogging);
            CollectionAssert.AreEquivalent(original.AllowedHeaderNames, copy.AllowedHeaderNames);
            CollectionAssert.AreEquivalent(original.AllowedQueryParameters, copy.AllowedQueryParameters);

            // The copy should be modifiable
            Assert.DoesNotThrow(() => copy.MessageContentSizeLimit = 10);
            Assert.DoesNotThrow(() => copy.EnableLogging = true);
            Assert.DoesNotThrow(() => copy.AllowedHeaderNames.Add("AnotherHeader"));

            // Changes to copy should not affect the original
            Assert.AreEqual(5, original.MessageContentSizeLimit);

            // Verify HasChanged is preserved so custom headers/params are used in the pipeline sanitizer
            copy.Freeze();
            CollectionAssert.Contains(copy.AllowedHeaderNames, "CustomHeader");
            CollectionAssert.Contains(copy.AllowedHeaderNames, "AnotherHeader");
            CollectionAssert.Contains(copy.AllowedQueryParameters, "CustomQuery");
            CollectionAssert.DoesNotContain(original.AllowedHeaderNames, "AnotherHeader");
        }

        [Test]
        public void CloneOfDefaultOptionsPreservesDefaultBehavior()
        {
            ClientLoggingOptions original = new();
            original.Freeze();

            ClientLoggingOptions copy = original.Clone();

            Assert.IsFalse(copy.IsReadOnly);
            Assert.IsNull(copy.EnableLogging);
            Assert.IsNull(copy.EnableMessageLogging);
            Assert.IsNull(copy.EnableMessageContentLogging);
            Assert.IsNull(copy.MessageContentSizeLimit);
            Assert.IsNull(copy.LoggerFactory);
        }
    }
}
