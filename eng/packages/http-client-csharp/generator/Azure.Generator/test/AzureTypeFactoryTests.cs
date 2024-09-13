// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using NUnit.Framework;
using System;

namespace Azure.Generator.Tests
{
    public class AzureTypeFactoryTests
    {
        [SetUp]
        public void SetUp()
        {
            MockHelpers.LoadMockPlugin();
        }

        [Test]
        public void Uuid()
        {
            var input = InputFactory.Primitive.String("uuid", "Azure.Core.uuid");

            var actual = AzureClientPlugin.Instance.TypeFactory.CreateCSharpType(input);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual?.IsFrameworkType);
            Assert.AreEqual(typeof(Guid), actual?.FrameworkType);
        }

        [Test]
        public void AzureLocation()
        {
            var input = InputFactory.Primitive.String("azureLocation", "Azure.Core.azureLocation");

            var actual = AzureClientPlugin.Instance.TypeFactory.CreateCSharpType(input);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual?.IsFrameworkType);
            Assert.AreEqual(typeof(AzureLocation), actual?.FrameworkType);
        }
    }
}
