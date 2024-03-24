// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Expressions.DataFactory.Tests
{
    public class DataFactorySecretStringTests
    {
        [Test]
        public void CanCreateFromString()
        {
           var maskedString = new DataFactorySecretString("foo");
           Assert.AreEqual("foo", maskedString.Value);
        }

        [Test]
        public void CanCreateFromStringImplicitCast()
        {
            DataFactorySecretString maskedString = "foo";
            Assert.AreEqual("foo", maskedString.Value);
        }
    }
}