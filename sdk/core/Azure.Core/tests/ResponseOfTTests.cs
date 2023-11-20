// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Moq;

namespace Azure.Core.Tests
{
    public class ResponseOfTTests
    {
        private class MyResponse : Azure.Response<int> {
            public override Response GetRawResponse() {
                throw new NotImplementedException();
            }
        }

        [Test]
        public void ValueIsAccessible()
        {
            var response = new MyResponse();

            Assert.DoesNotThrow(() => response.Value);
        }
    }
}
