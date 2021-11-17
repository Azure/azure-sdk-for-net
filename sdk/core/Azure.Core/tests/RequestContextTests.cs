// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RequestContextTests
    {
        private readonly Uri _url = new Uri("https://example.azuretemplateservice.com");

        [Test]
        public void CanCastFromErrorOptions()
        {
            RequestContext context = ErrorOptions.Default;

            Assert.IsTrue(context.ErrorOptions == ErrorOptions.Default);
        }

        [Test]
        public void CanSetErrorOptions()
        {
            RequestContext context = new RequestContext { ErrorOptions = ErrorOptions.NoThrow };

            Assert.IsTrue(context.ErrorOptions == ErrorOptions.NoThrow);
        }
    }
}
