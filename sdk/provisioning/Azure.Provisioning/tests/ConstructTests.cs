// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Provisioning.ResourceManager;
using Azure.Provisioning.Storage;
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
            infra.AddCommonSqlDatabase();
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
            var rg1 = new ResourceGroup(infra, "rg1");

            var childScope = infra.AddCommonSqlDatabase();
            _ = new ResourceGroup(childScope, "rg2");

            var expected = recursive ? 12 : 4;
            var resources = infra.GetResources(recursive);

            Assert.AreEqual(expected, resources.Count());
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void GetParametersNoChildConstructs(bool recursive)
        {
            var infra = new TestInfrastructure();
            var rg1 = new ResourceGroup(infra, "rg1");

            rg1.AssignProperty(r => r.Location, new Parameter("location"));

            var parameters = infra.GetParameters(recursive);
            var expected = recursive ? 1 : 1;
            Assert.AreEqual(expected, parameters.Count());
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void GetParametersChildConstructs(bool recursive)
        {
            var infra = new TestInfrastructure();
            var rg1 = new ResourceGroup(infra, "rg1");
            rg1.AssignProperty(r => r.Location, new Parameter("location"));

            var childScope = infra.AddAppInsightsConstruct();
            var rg2 = new ResourceGroup(childScope, "rg2");
            rg2.AssignProperty(r => r.Location, new Parameter("location"));

            var expected = recursive ? 3 : 2;
            var parameters = infra.GetParameters(recursive);

            Assert.AreEqual(expected, parameters.Count());
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void GetOutputsNoChildConstructs(bool recursive)
        {
            var infra = new TestInfrastructure();
            var rg1 = new ResourceGroup(infra, "rg1");

            rg1.AddOutput("location", r => r.Location);

            var outputs = infra.GetOutputs(recursive);
            Assert.AreEqual(1, outputs.Count());
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void GetOutputsChildConstructs(bool recursive)
        {
            var infra = new TestInfrastructure();
            var rg1 = new ResourceGroup(infra, "rg1");
            rg1.AddOutput("location", r => r.Location);

            var childScope = infra.AddAppInsightsConstruct();
            var rg2 = new ResourceGroup(childScope, "rg2");
            rg2.AddOutput("location", r => r.Location);

            // appinsights construct has an output
            var expected = recursive ? 3 : 2;
            var outputs = infra.GetOutputs(recursive);

            Assert.AreEqual(expected, outputs.Count());
        }
    }
}
