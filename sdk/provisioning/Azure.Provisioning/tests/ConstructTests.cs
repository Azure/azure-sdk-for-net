// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Provisioning.ResourceManager;
using NUnit.Framework;

namespace Azure.Provisioning.Tests
{
    public class ConstructTests
    {
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void GetConstructsNoChildConstructs(bool recursive)
        {
            var infra = new TestInfrastructure();
            var constructs = infra.GetConstructs(recursive);

            // the only construct is the infrastructure itself which doesn't get included in GetConstructs
            Assert.AreEqual(0, constructs.Count());
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void GetConstructsChildConstructs(bool recursive)
        {
            var infra = new TestInfrastructure();
            infra.AddFrontEndWebSite();
            var constructs = infra.GetConstructs(recursive);

            Assert.AreEqual(1, constructs.Count());
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void GetConstructsGrandchildConstructs(bool recursive)
        {
            var infra = new TestInfrastructure();

            var childScope = new TestInfrastructure();
            childScope.AddConstruct(new TestInfrastructure());
            infra.AddConstruct(childScope);

            var constructs = infra.GetConstructs(recursive);

            var expected = recursive ? 2 : 1;
            Assert.AreEqual(expected, constructs.Count());
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void GetResourcesNoChildConstructs(bool recursive)
        {
            var infra = new TestInfrastructure();
            _ = new ResourceGroup(infra, "rg1");
            _ = new ResourceGroup(infra, "rg2");

            var resources = infra.GetResources(recursive);

            Assert.AreEqual(4, resources.Count());
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void GetResourcesChildConstructs(bool recursive)
        {
            var infra = new TestInfrastructure();
            _ = new ResourceGroup(infra, "rg1");

            var childScope = infra.AddFrontEndWebSite();
            _ = new ResourceGroup(childScope, "rg2");

            var expected = recursive ? 10 : 6;
            var resources = infra.GetResources(recursive);

            Assert.AreEqual(expected, resources.Count());
        }
    }
}
