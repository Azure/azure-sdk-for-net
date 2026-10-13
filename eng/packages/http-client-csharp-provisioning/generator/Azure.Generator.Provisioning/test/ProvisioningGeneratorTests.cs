// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Reflection;
using Azure.Generator.Provisioning.Tests.TestHelpers;
using NUnit.Framework;

namespace Azure.Generator.Provisioning.Tests
{
    internal class ProvisioningGeneratorTests
    {
        [Test]
        public void DoesNotUseManagementResourceClientVisitor()
        {
            var generator = ProvisioningMockHelpers.LoadMockPlugin();
            typeof(ProvisioningGenerator).GetMethod("Configure", BindingFlags.Instance | BindingFlags.NonPublic)!
                .Invoke(generator.Object, null);
            var visitorNames = generator.Object.Visitors.Select(visitor => visitor.GetType().Name).ToArray();

            Assert.That(visitorNames, Does.Not.Contain("ResourceVisitor"));
            Assert.That(visitorNames, Does.Not.Contain("InheritableSystemObjectModelVisitor"));
            Assert.That(visitorNames, Does.Contain("ResourceDataSuffixVisitor"));
        }
    }
}
