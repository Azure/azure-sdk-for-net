// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            CultureInfo? stackTraceCulture = null;
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

        [Fact]
        public void VerifyFlattenException_HandlesAggregate()
        {
            var aggregateException = new AggregateException(new Exception("hello world 1"), new Exception("hello world 2)"));

            var test = aggregateException.FlattenException();

            Assert.NotSame(test, aggregateException);

#if NETFRAMEWORK
            string expectedMessage = "One or more errors occurred.";
            string expectedToString = "System.AggregateException: One or more errors occurred. ---> System.Exception: hello world 1"
                + Environment.NewLine + "   --- End of inner exception stack trace ---"
                + Environment.NewLine + "---> (Inner Exception #0) System.Exception: hello world 1<---"
                + Environment.NewLine
                + Environment.NewLine + "---> (Inner Exception #1) System.Exception: hello world 2)<---"
                + Environment.NewLine;
#else
            string expectedMessage = "One or more errors occurred. (hello world 1) (hello world 2))";
            string expectedToString = "System.AggregateException: One or more errors occurred. (hello world 1) (hello world 2))"
                + Environment.NewLine + " ---> System.Exception: hello world 1"
                + Environment.NewLine + "   --- End of inner exception stack trace ---"
                + Environment.NewLine + " ---> (Inner Exception #1) System.Exception: hello world 2)<---"
                + Environment.NewLine;
#endif

            Assert.Equal(expectedMessage, test.Message);
            Assert.Equal(expectedToString, test.ToString());
        }

        [Fact]
        public void VerifyFlattenException_HandlesNestedAggregate()
        {
            var aggregateException = new AggregateException(new AggregateException(new Exception("hello world 1"), new Exception("hello world 2"), new Exception("hello world 3")));

            var test = aggregateException.FlattenException();

            Assert.NotSame(test, aggregateException);

#if NETFRAMEWORK
            string expectedMessage = "One or more errors occurred.";
            string expectedToString = "System.AggregateException: One or more errors occurred. ---> System.Exception: hello world 1"
                + Environment.NewLine + "   --- End of inner exception stack trace ---"
                + Environment.NewLine + "---> (Inner Exception #0) System.Exception: hello world 1<---"
                + Environment.NewLine
                + Environment.NewLine + "---> (Inner Exception #1) System.Exception: hello world 2<---"
                + Environment.NewLine
                + Environment.NewLine + "---> (Inner Exception #2) System.Exception: hello world 3<---"
                + Environment.NewLine;
#else
            string expectedMessage = "One or more errors occurred. (hello world 1) (hello world 2) (hello world 3)";
            string expectedToString = "System.AggregateException: One or more errors occurred. (hello world 1) (hello world 2) (hello world 3)"
                + Environment.NewLine + " ---> System.Exception: hello world 1"
                + Environment.NewLine + "   --- End of inner exception stack trace ---"
                + Environment.NewLine + " ---> (Inner Exception #1) System.Exception: hello world 2<---"
                + Environment.NewLine
                + Environment.NewLine + " ---> (Inner Exception #2) System.Exception: hello world 3<---"
                + Environment.NewLine;
#endif

            Assert.Equal(expectedMessage, test.Message);
            Assert.Equal(expectedToString, test.ToString());
        }

        [Fact]
        public void VerifyFlattenException_HandlesNormalException()
        {
            var ex = new Exception("hello world");

            var test = ex.FlattenException();

            Assert.Same(ex, test);
        }
    }
}
