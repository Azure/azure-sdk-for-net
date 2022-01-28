// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
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
