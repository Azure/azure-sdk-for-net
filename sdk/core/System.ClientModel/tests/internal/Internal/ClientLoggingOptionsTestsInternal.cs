// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal
{
    internal class ClientLoggingOptionsTestsInternal
    {
        private static HashSet<string> s_expectedDefaultAllowedHeaderNames { get; } = [
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
        private static HashSet<string> s_expectedDefaultAllowedQueryParameters { get; } = ["api-version"];

        [Test]
        public void ValidOptionsAreConsideredValid()
        {
            List<ClientLoggingOptions> validLoggingOptions = [
                new ClientLoggingOptions(),
                new ClientLoggingOptions { EnableLogging = true },
                new ClientLoggingOptions { EnableLogging = false },
                new ClientLoggingOptions { EnableMessageLogging = true },
                new ClientLoggingOptions { EnableMessageLogging = false },
                new ClientLoggingOptions { EnableMessageContentLogging = true },
                new ClientLoggingOptions { EnableMessageContentLogging = false },
                new ClientLoggingOptions { EnableLogging = true, EnableMessageLogging = true },
                new ClientLoggingOptions { EnableLogging = true, EnableMessageLogging = false },
                new ClientLoggingOptions { EnableLogging = false, EnableMessageLogging = false },
                new ClientLoggingOptions { EnableLogging = false, EnableMessageContentLogging = false },
                new ClientLoggingOptions { EnableLogging = true, EnableMessageContentLogging = true },
                new ClientLoggingOptions { EnableLogging = true, EnableMessageContentLogging = false },
                new ClientLoggingOptions { EnableLogging = true, EnableMessageLogging = true, EnableMessageContentLogging = true },
                new ClientLoggingOptions { EnableLogging = true, EnableMessageLogging = true, EnableMessageContentLogging = false },
                new ClientLoggingOptions { EnableLogging = true, EnableMessageLogging = false, EnableMessageContentLogging = false },
                new ClientLoggingOptions { EnableLogging = false, EnableMessageLogging = false, EnableMessageContentLogging = false },
                ];

            foreach (ClientLoggingOptions options in validLoggingOptions)
            {
                Assert.DoesNotThrow(() => options.ValidateOptions());
                options.LoggerFactory = NullLoggerFactory.Instance;
                options.MessageContentSizeLimit = 15;
                Assert.DoesNotThrow(() => options.ValidateOptions());
            }
        }

        [Test]
        public void InValidOptionsAreConsideredInValid()
        {
            List<ClientLoggingOptions> validLoggingOptions = [
                new ClientLoggingOptions { EnableLogging = false, EnableMessageLogging = true },
                new ClientLoggingOptions { EnableLogging = false, EnableMessageContentLogging = true },
                new ClientLoggingOptions { EnableMessageLogging = false, EnableMessageContentLogging = true },
                new ClientLoggingOptions { EnableLogging = false, EnableMessageLogging = true, EnableMessageContentLogging = true },
                new ClientLoggingOptions { EnableLogging = false, EnableMessageLogging = true, EnableMessageContentLogging = false },
                new ClientLoggingOptions { EnableLogging = false, EnableMessageLogging = false, EnableMessageContentLogging = true },
                new ClientLoggingOptions { EnableLogging = true, EnableMessageLogging = false, EnableMessageContentLogging = true },
                ];

            foreach (var options in validLoggingOptions)
            {
                Assert.Throws<InvalidOperationException>(() => options.ValidateOptions());
                options.LoggerFactory = NullLoggerFactory.Instance;
                options.MessageContentSizeLimit = 15;
                Assert.Throws<InvalidOperationException>(() => options.ValidateOptions());
            }
        }

        [Test]
        public void CanGetDefaultSanitizer()
        {
            ClientLoggingOptions options = new();
            PipelineMessageSanitizer sanitizer = options.GetPipelineMessageSanitizer();

            Assert.AreEqual(s_expectedDefaultAllowedQueryParameters, sanitizer._allowedQueryParameters);
            Assert.AreEqual(s_expectedDefaultAllowedHeaderNames, sanitizer._allowedHeaders);
        }

        [Test]
        public void CanGetCustomizedSanitizer()
        {
            ClientLoggingOptions options = new();
            options.AllowedHeaderNames.Add("Custom-Header");
            options.AllowedQueryParameters.Add("custom-query");
            PipelineMessageSanitizer sanitizer = options.GetPipelineMessageSanitizer();

            HashSet<string> customAllowedHeaders = new(s_expectedDefaultAllowedHeaderNames)
            {
                "Custom-Header"
            };

            HashSet<string> customQueryParameters = new(s_expectedDefaultAllowedQueryParameters)
            {
                "custom-query"
            };

            Assert.AreEqual(customQueryParameters, sanitizer._allowedQueryParameters);
            Assert.AreEqual(customAllowedHeaders, sanitizer._allowedHeaders);
        }
    }
}
