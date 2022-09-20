// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.Tests
{
    using System.Net;
    using System.Net.Http;
    using System.Collections.Generic;
    using Xunit;
    using System.Linq;

    public class HttpRequestSanitizerTest
    {
        [Theory]
        [InlineData("authorization")]
        [InlineData("Authorization")]
        [InlineData("AUTHORIZATION")]
        public void SanitizeAuthorizationHeader(string headerName)
        {
            var request = CreateRequestWrapper(headerName, "test");

            Assert.True(request.Headers.TryGetValue(HttpRequestHeader.Authorization.ToString(), out IEnumerable<string> sanitizedValues));
            Assert.Single(sanitizedValues);
            Assert.NotEqual("test", sanitizedValues.First());
            Assert.Equal("REDACTED", sanitizedValues.First());
        }

        [Theory]
        [InlineData("custom")]
        [InlineData("foo")]
        [InlineData("x-ms-secret")]
        public void SanitizeCustomHeader(string headerName)
        {
            var request = CreateRequestWrapper(headerName, "test");

            Assert.True(request.Headers.TryGetValue(headerName, out IEnumerable<string> sanitizedValues));
            Assert.Single(sanitizedValues);
            Assert.NotEqual("test", sanitizedValues.First());
            Assert.Equal("REDACTED", sanitizedValues.First());
        }

        [Theory]
        [InlineData("Accept", "application/json")]
        [InlineData("User-Agent", "azure-sdk")]
        [InlineData("Pragma", "foo")]
        public void KeepAllowedHeaders(string headerName, string headerValue)
        {
            var request = CreateRequestWrapper(headerName, headerValue);

            Assert.True(request.Headers.TryGetValue(headerName, out IEnumerable<string> sanitizedValues));
            Assert.Single(sanitizedValues);
            Assert.Equal(headerValue, sanitizedValues.First());
        }

        [Theory]
        [InlineData("accept", "Accept", "application/json")]
        [InlineData("user-agent", "User-Agent", "azure-sdk")]
        [InlineData("pragma", "Pragma", "foo")]
        public void AllowedHeaderNamesAreCaseInsensitive(string headerName, string standardName, string headerValue)
        {
            var request = CreateRequestWrapper(headerName, headerValue);

            Assert.True(request.Headers.TryGetValue(standardName, out IEnumerable<string> sanitizedValues));
            Assert.Single(sanitizedValues);
            Assert.Equal(headerValue, sanitizedValues.First());
        }

        [Fact]
        public void OnlySanitizeNotAllowedHeader()
        {
            var request = CreateRequestWrapper("Authorization", "test");
            request.Headers.Add("Pragma", new string[] { "foo" });
            request.Headers.Add("User-Agent", new string[] { "azure-sdk" });

            Assert.True(request.Headers.TryGetValue(HttpRequestHeader.Authorization.ToString(), out IEnumerable<string> sanitizedValues));
            Assert.Single(sanitizedValues);
            Assert.NotEqual("test", sanitizedValues.First());
            Assert.Equal("REDACTED", sanitizedValues.First());

            Assert.True(request.Headers.TryGetValue("Pragma", out sanitizedValues));
            Assert.Single(sanitizedValues);
            Assert.Equal("foo", sanitizedValues.First());

            Assert.True(request.Headers.TryGetValue("User-Agent", out sanitizedValues));
            Assert.Single(sanitizedValues);
            Assert.Equal("azure-sdk", sanitizedValues.First());
        }

        private HttpRequestMessageWrapper CreateRequestWrapper(string headerName, string headerValue)
        {
            var request = new HttpRequestMessage();
            request.Headers.Add(headerName, headerValue);
            return new HttpRequestMessageWrapper(request, "");
        }
    }
}