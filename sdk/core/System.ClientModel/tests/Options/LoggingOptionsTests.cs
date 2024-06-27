// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Identity.Client;
using NUnit.Framework;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

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
            Assert.AreEqual(null, options.CorrelationIdHeaderName);
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
            Assert.Throws<InvalidOperationException>(() => options.CorrelationIdHeaderName = "ShouldNotSet");
            Assert.Throws<InvalidOperationException>(() => options.LoggerFactory = new NullLoggerFactory());
        }
    }
}
