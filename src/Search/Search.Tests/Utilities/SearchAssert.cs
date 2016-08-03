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
            CloudException error = Assert.Throws<CloudException>(action);
            Assert.Equal(expectedStatusCode, error.Response.StatusCode);

            if (expectedMessage != null)
            {
                Assert.Contains(expectedMessage, error.Body.Message);
            }

            return error;
        }
    }
}
