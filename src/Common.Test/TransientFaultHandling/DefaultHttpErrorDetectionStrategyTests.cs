//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Net;
using Xunit;
using Xunit.Extensions;
using Hyak.Common.TransientFaultHandling;

namespace Microsoft.Azure.Common.Test.TransientFaultHandling
{
    /// <summary>
    /// Implements general test cases for http error detections.
    /// </summary>
    public class DefaultHttpErrorDetectionStrategyTests
    {
        [Theory]
        [InlineData(HttpStatusCode.InternalServerError)]
        [InlineData(HttpStatusCode.RequestTimeout)]
        [InlineData(HttpStatusCode.BadGateway)]
        public void ResponseCodeIsConsideredTransient(HttpStatusCode code)
        {
            var strategy = new DefaultHttpErrorDetectionStrategy();
            Assert.True(strategy.IsTransient(new HttpRequestExceptionWithStatus { StatusCode = code }));
        }

        [Theory]
        [InlineData(HttpStatusCode.NotImplemented)]
        [InlineData(HttpStatusCode.HttpVersionNotSupported)]
        public void ResponseCodeIsNotConsideredTransient(HttpStatusCode code)
        {
            var strategy = new DefaultHttpErrorDetectionStrategy();
            Assert.False(strategy.IsTransient(new HttpRequestExceptionWithStatus { StatusCode = code }));
        }

        [Fact]
        public void BadExceptionIsNotConsideredTransient()
        {
            var strategy = new DefaultHttpErrorDetectionStrategy();
            Assert.False(strategy.IsTransient(new InvalidOperationException()));
        }
    }
}
