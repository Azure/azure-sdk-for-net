// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RequestOptionsTests
    {
        [Test]
        public void CanSetErrorOptions()
        {
            RequestOptions options = new RequestOptions { ErrorOptions = ErrorOptions.NoThrow };

            Assert.IsTrue(options.ErrorOptions == ErrorOptions.NoThrow);
        }
    }
}
