// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using Microsoft.Rest.TransientFaultHandling;
using Xunit;

namespace Microsoft.Rest.ClientRuntime.Tests.TransientFaultHandling
{
    /// <summary>
    ///     Implements general test cases for http error detections.
    /// </summary>
    public class DefaultHttpErrorDetectionStrategyTests
    {
        [Theory]
        [InlineData(HttpStatusCode.InternalServerError)]
        [InlineData(HttpStatusCode.RequestTimeout)]
        [InlineData(HttpStatusCode.BadGateway)]
        public void ResponseCodeIsConsideredTransient(HttpStatusCode code)
        {
            var strategy = new HttpStatusCodeErrorDetectionStrategy();
            Assert.True(strategy.IsTransient(new HttpRequestWithStatusException {StatusCode = code}));
        }

        [Theory]
        [InlineData(HttpStatusCode.NotImplemented)]
        [InlineData(HttpStatusCode.HttpVersionNotSupported)]
        public void ResponseCodeIsNotConsideredTransient(HttpStatusCode code)
        {
            var strategy = new HttpStatusCodeErrorDetectionStrategy();
            Assert.False(strategy.IsTransient(new HttpRequestWithStatusException {StatusCode = code}));
        }

        [Fact]
        public void BadExceptionIsNotConsideredTransient()
        {
            var strategy = new HttpStatusCodeErrorDetectionStrategy();
            Assert.False(strategy.IsTransient(new InvalidOperationException()));
        }
    }
}
