// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.Net.Http;
    using Xunit;

    public static class ValidationUtilities
    {
        public static void ValidateAuthorizationHeader(this HttpRequestMessage request)
        {
            Assert.Equal("Bearer", request.Headers.Authorization.Scheme);
            Assert.NotNull(request.Headers.Authorization.Parameter);
        }

        public static void ValidateMethod(this HttpRequestMessage request, HttpMethod method)
        {
            Assert.Equal(method, request.Method);
        }

        public static void ValidateAction(this HttpRequestMessage request, string action)
        {
            Assert.Equal(HttpMethod.Post, request.Method);
            var postfix = string.Format("/{0}", action);
            Assert.True(request.RequestUri.AbsolutePath.EndsWith(postfix), string.Format("URI should ends with {0}", postfix));
        }
    }
}
