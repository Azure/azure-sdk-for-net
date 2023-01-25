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
        public void CanAccessIntProperty()
        {
            dynamic jsonData = JsonData.Parse(@"
                {
                  ""Foo"" : 1
                }");

            JsonDataElement value = jsonData.Foo;

            Assert.AreEqual(1, value);
        }
    }
}
