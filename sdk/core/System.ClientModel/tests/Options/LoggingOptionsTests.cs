﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace System.ClientModel.Tests.Options
{
    public class LoggingOptionsTests
    {
        public LoggingOptionsTests()
        {
        }

        [Test]
        public void DefaultOptionsAreSet()
        {
            LoggingOptions options = new();
            Assert.AreEqual(4 * 1024, options.LoggedContentSizeLimit);
            Assert.AreEqual(21, options.AllowedHeaderNames.Count);
            Assert.AreEqual(1, options.AllowedQueryParameters.Count);
            Assert.AreEqual(false, options.IsLoggingContentEnabled);
            Assert.IsInstanceOf(typeof(NullLoggerFactory), options.LoggerFactory);
        }

        [Test]
        public void OptionsFreeze()
        {
            LoggingOptions options = new()
            {
            };

            options.Freeze();

            Assert.Throws<NotSupportedException>(() => options.AllowedHeaderNames.Add("ShouldNotAdd"));
            Assert.Throws<NotSupportedException>(() => options.AllowedQueryParameters.Add("ShouldNotAdd"));
            Assert.Throws<InvalidOperationException>(() => options.LoggedContentSizeLimit = 5);
            Assert.Throws<InvalidOperationException>(() => options.IsLoggingContentEnabled = true);
            Assert.Throws<InvalidOperationException>(() => options.LoggerFactory = new NullLoggerFactory());
        }
    }
}
