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
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.WindowsAzure.Common.Internals;
using Xunit;
using Xunit.Extensions;

namespace Microsoft.WindowsAzure.Common.Tracing.Etw.Test
{
    public class UriHelperTest
    {
        [Theory]
        [InlineData("foo/bar", new[] { "foo/", "bar" })]
        [InlineData("foo/bar/", new[] { "foo/", "bar/" })]
        [InlineData("foo/bar", new[] { "foo/", "/bar" })]
        [InlineData("foobar", new[] { "foo", "bar" })]
        [InlineData("foobar", new[] { "foo", null, "bar", null, "" })]
        [InlineData("", new[] { "" })]
        [InlineData("foo/", new[] { "foo/" })]
        [InlineData("/foo/", new[] { "/foo/" })]
        [InlineData("/foo", new[] { "/foo" })]
        [InlineData("/foo/bar/baz", new [] { "/foo", "/bar/", "/baz" })]
        [InlineData("http://foo/bar?p", new[] { "http://", "/foo/bar", "?p" })]
        [InlineData(null, null)]
        public void VerifyConcatenate(string expected, string[] parts)
        {
            var result = UriHelper.Concatenate(parts);

            Assert.Equal(expected, result);
        }
    }
}
