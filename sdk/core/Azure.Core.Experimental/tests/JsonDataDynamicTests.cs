// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core.Dynamic;
using NUnit.Framework;

namespace Azure.Core.Experimental.Tests
{
    public class JsonDataDynamicTests
    {
        [Test]
        public void CanGetIntProperty()
        {
            dynamic jsonData = JsonData.Parse(@"
                {
                  ""Foo"" : 1
                }");

            int value = jsonData.Foo;

            Assert.AreEqual(1, value);
        }
    }
}
