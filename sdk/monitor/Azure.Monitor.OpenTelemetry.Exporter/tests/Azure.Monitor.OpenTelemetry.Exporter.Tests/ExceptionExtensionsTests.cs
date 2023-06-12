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
            Assert.Equal("One or more errors occurred.", test.Message);
            Assert.Equal("System.AggregateException: One or more errors occurred. ---> System.Exception: hello world 1\r\n   --- End of inner exception stack trace ---\r\n---> (Inner Exception #0) System.Exception: hello world 1<---\r\n\r\n---> (Inner Exception #1) System.Exception: hello world 2)<---\r\n", test.ToString());
#else
            Assert.Equal("One or more errors occurred. (hello world 1) (hello world 2))", test.Message);
            Assert.Equal("System.AggregateException: One or more errors occurred. (hello world 1) (hello world 2))\r\n ---> System.Exception: hello world 1\r\n   --- End of inner exception stack trace ---\r\n ---> (Inner Exception #1) System.Exception: hello world 2)<---\r\n", test.ToString());
#endif
        }

        [Fact]
        public void VerifyFlattenException_HandlesNestedAggregate()
        {
            var aggregateException = new AggregateException(new AggregateException(new Exception("hello world 1"), new Exception("hello world 2"), new Exception("hello world 3")));

            var test = aggregateException.FlattenException();

            Assert.NotSame(test, aggregateException);

#if NETFRAMEWORK
            Assert.Equal("One or more errors occurred.", test.Message);
            Assert.Equal("System.AggregateException: One or more errors occurred. ---> System.Exception: hello world 1\r\n   --- End of inner exception stack trace ---\r\n---> (Inner Exception #0) System.Exception: hello world 1<---\r\n\r\n---> (Inner Exception #1) System.Exception: hello world 2<---\r\n\r\n---> (Inner Exception #2) System.Exception: hello world 3<---\r\n", test.ToString());
#else
            Assert.Equal("One or more errors occurred. (hello world 1) (hello world 2) (hello world 3)", test.Message);
            Assert.Equal("System.AggregateException: One or more errors occurred. (hello world 1) (hello world 2) (hello world 3)\r\n ---> System.Exception: hello world 1\r\n   --- End of inner exception stack trace ---\r\n ---> (Inner Exception #1) System.Exception: hello world 2<---\r\n\r\n ---> (Inner Exception #2) System.Exception: hello world 3<---\r\n", test.ToString());
#endif
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
