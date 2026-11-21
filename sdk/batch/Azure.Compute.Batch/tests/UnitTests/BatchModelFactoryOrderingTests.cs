// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Azure.Compute.Batch.Tests.UnitTests
{
    public class BatchModelFactoryOrderingTests
    {
        [Test]
        public void NodePreservesPartiallyPositionalArguments()
        {
            BatchNode node = ComputeBatchModelFactory.BatchNode(
                "node", null, BatchNodeState.Idle, null, default, default, default,
                null, null, "affinity", "Standard_D2");

            Assert.AreEqual("affinity", node.AffinityId);
            Assert.AreEqual("Standard_D2", node.VmSize);
            Assert.IsNull(node.PublicIPAddress);
            Assert.IsNull(node.PublicIPv6Address);
        }

        [Test]
        public void PoolsPreservePartiallyPositionalArguments()
        {
            TimeSpan timeout = TimeSpan.FromMinutes(10);
            BatchPoolCreateOptions create = ComputeBatchModelFactory.BatchPoolCreateOptions("pool", "display", "Standard_D2", null, timeout, 3);
            BatchPool pool = ComputeBatchModelFactory.BatchPool("pool", "display", null, default, default, default, default, default, null, null, "Standard_D2", null, timeout);
            BatchPoolUpdateOptions update = ComputeBatchModelFactory.BatchPoolUpdateOptions("display", "Standard_D2", true, null, null, null, null, 4);

            Assert.AreEqual(timeout, create.ResizeTimeout);
            Assert.AreEqual(3, create.TargetDedicatedNodes);
            Assert.AreEqual(timeout, pool.ResizeTimeout);
            Assert.AreEqual(4, update.TaskSlotsPerNode);
            Assert.IsNull(create.VmSkuProfile);
            Assert.IsNull(pool.VmSkuProfile);
            Assert.IsNull(update.VmSkuProfile);
        }

        [Test]
        public void NewArgumentsPopulateNewProperties()
        {
            var profile = new VirtualMachineSkuProfile();
            Assert.AreSame(profile, ComputeBatchModelFactory.BatchPoolCreateOptions(vmSkuProfile: profile).VmSkuProfile);
            Assert.AreSame(profile, ComputeBatchModelFactory.BatchPool(vmSkuProfile: profile).VmSkuProfile);
            Assert.AreSame(profile, ComputeBatchModelFactory.BatchPoolUpdateOptions(vmSkuProfile: profile).VmSkuProfile);
            BatchNode node = ComputeBatchModelFactory.BatchNode(publicIPAddress: "192.0.2.1", publicIPv6Address: "2001:db8::1");
            Assert.AreEqual("192.0.2.1", node.PublicIPAddress);
            Assert.AreEqual("2001:db8::1", node.PublicIPv6Address);
        }

        [TestCase("BatchNode", 23, "publicIPAddress", "publicIPv6Address")]
        [TestCase("BatchPoolCreateOptions", 20, "vmSkuProfile", null)]
        [TestCase("BatchPool", 34, "vmSkuProfile", null)]
        [TestCase("BatchPoolUpdateOptions", 13, "vmSkuProfile", null)]
        public void AppendsNewArgumentsAndRetainsLegacySignature(string name, int oldCount, string firstNew, string secondNew)
        {
            MethodInfo[] methods = typeof(ComputeBatchModelFactory).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(method => method.Name == name).ToArray();
            MethodInfo current = methods.Single(method => method.GetParameters().Length > oldCount);
            MethodInfo legacy = methods.Single(method => method.GetParameters().Length == oldCount);
            ParameterInfo[] currentParameters = current.GetParameters();
            ParameterInfo[] legacyParameters = legacy.GetParameters();
            Assert.AreEqual(firstNew, currentParameters[oldCount].Name);
            if (secondNew != null)
            {
                Assert.AreEqual(secondNew, currentParameters[oldCount + 1].Name);
            }
            for (int i = 0; i < oldCount; i++)
            {
                Assert.AreEqual(legacyParameters[i].Name, currentParameters[i].Name);
                Assert.AreEqual(legacyParameters[i].ParameterType, currentParameters[i].ParameterType);
                Assert.IsTrue(currentParameters[i].IsOptional);
                Assert.IsFalse(legacyParameters[i].IsOptional);
            }

            object[] arguments = legacyParameters.Select(parameter =>
                parameter.ParameterType.IsValueType ? Activator.CreateInstance(parameter.ParameterType) : null).ToArray();
            Assert.IsNotNull(legacy.Invoke(null, arguments));
        }
    }
}
