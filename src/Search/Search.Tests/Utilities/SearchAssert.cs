// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Net;
    using Rest.Azure;
    using Xunit;

    internal static class SearchAssert
    {
        public static CloudException ThrowsCloudException(Action action, HttpStatusCode expectedStatusCode, string expectedMessage = null)
        {
            return ThrowsCloudException(action, e => Assert.Equal(expectedStatusCode, e.Response.StatusCode), expectedMessage);
        }

        public static CloudException ThrowsCloudException(Action action, Func<CloudException, bool> checkException, string expectedMessage = null)
        {
            return ThrowsCloudException(action, e => Assert.True(checkException(e)));
        }

        private static CloudException ThrowsCloudException(Action action, Action<CloudException> assertException, string expectedMessage = null)
        {
            CloudException e = Assert.Throws<CloudException>(action);

            assertException(e);

            if (expectedMessage != null)
            {
                Assert.Contains(expectedMessage, e.Body.Message);
            }

            return e;
        }
    }
}
