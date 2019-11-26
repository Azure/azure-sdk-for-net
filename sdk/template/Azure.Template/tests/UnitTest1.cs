// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Data;
using System;
using NUnit.Framework;

namespace Microsoft.Azure.Template.Tests
{
    public class UnitTest1
    {
        [Test]
        public void Test1()
        {
            var c = new Class1();

            Assert.NotNull(c);
        }
    }
}
