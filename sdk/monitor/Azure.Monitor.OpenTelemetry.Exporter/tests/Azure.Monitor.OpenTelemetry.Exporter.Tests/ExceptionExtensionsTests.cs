// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using System;
using System.Globalization;
using System.Threading;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class ExceptionExtensionsTests
    {
        private CultureInfo originalUICulture = Thread.CurrentThread.CurrentUICulture;

        [Fact]
        public void ExtractsStackTraceWithInvariantCultureMatchesErrorsReportedByOSsWithDifferentLanguages()
        {
            CultureInfo stackTraceCulture = null;
            var exception = new StubException();
            exception.OnToString = () =>
            {
                stackTraceCulture = Thread.CurrentThread.CurrentUICulture;
                return string.Empty;
            };

            ExceptionExtensions.ToInvariantString(exception);

            Assert.Equal(CultureInfo.InvariantCulture, stackTraceCulture);
        }

        [Fact]
        public void RestoresOriginalUICultureToPreserveGlobalStateOfApplication()
        {
            ExceptionExtensions.ToInvariantString(new Exception());
            Assert.Equal(this.originalUICulture, Thread.CurrentThread.CurrentUICulture);
        }
    }
}
