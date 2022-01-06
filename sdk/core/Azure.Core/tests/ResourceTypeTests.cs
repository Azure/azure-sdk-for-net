﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;

namespace Azure.Core.Tests
{
    [Parallelizable]
    public class ResourceTypeTests
    {
        [TestCase("")]
        [TestCase("\n")]
        [TestCase("\t")]
        [TestCase(" ")]
        [TestCase("\r")]
        public void InvalidConstructorParam(string input)
        {
            Assert.Throws<ArgumentException>(() => new ResourceType(input));
        }

        [TestCase]
        public void NullImplicitFromString()
        {
            string from = null;
            Assert.Throws<ArgumentNullException>(() => { ResourceType to = from; });
        }

        [TestCase(true, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(true, "Microsoft.Network1/Virtualnetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(false, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets2")]
        public void EqualsOpResourceTypeToString(bool expected, string left, string right)
        {
            ResourceType leftResource = left;
            Assert.AreEqual(expected, leftResource == right);
        }

        [TestCase(true, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(true, "Microsoft.Network1/Virtualnetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(false, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets2")]
        public void EqualsOpStringToResourceType(bool expected, string left, string right)
        {
            ResourceType rightResource = right;
            Assert.AreEqual(expected, left == rightResource);
        }

        [TestCase(true, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(true, "Microsoft.Network1/Virtualnetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(false, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets2")]
        public void EqualsOpResourceTypeToResourceType(bool expected, string left, string right)
        {
            ResourceType leftResource = left;
            ResourceType rightResource = right;
            Assert.AreEqual(expected, leftResource == rightResource);
            Assert.AreEqual(expected, leftResource.GetHashCode() == rightResource.GetHashCode());
        }

        [TestCase(false, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(false, "Microsoft.Network1/Virtualnetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(true, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets2")]
        public void NotEqualsOpResourceTypeToString(bool expected, string left, string right)
        {
            ResourceType leftResource = left;
            Assert.AreEqual(expected, leftResource != right);
        }

        [TestCase(false, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(false, "Microsoft.Network1/Virtualnetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(true, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets2")]
        public void NotEqualsOpStringToResourceType(bool expected, string left, string right)
        {
            ResourceType rightResource = right;
            Assert.AreEqual(expected, left != rightResource);
        }

        [TestCase(false, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(false, "Microsoft.Network1/Virtualnetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(true, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets2")]
        public void NotEqualsOpResourceTypeToResourceType(bool expected, string left, string right)
        {
            ResourceType leftResource = left;
            ResourceType rightResource = right;
            Assert.AreEqual(expected, leftResource != rightResource);
        }

        [TestCase]
        public void ParseArgumentException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { ResourceType rt = "/"; });
        }

        [TestCase(true, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(true, "Microsoft.Network1/Virtualnetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(false, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets2")]
        public void EqualsWithObjectResourceType(bool expected, string left, string right)
        {
            ResourceType rt = left;
            ResourceType rightRt = right;
            object rightObject = rightRt;
            Assert.AreEqual(expected, rt.Equals(rightObject));
            Assert.AreEqual(expected, rt.GetHashCode() == rightRt.GetHashCode());

            object sameRt = rt;
            Assert.IsTrue(rt.Equals(sameRt));

            object intRt = 5;
            Assert.IsFalse(rt.Equals(intRt));
        }

        [Test]
        public void EqualsWithObjectResourceTypeNull()
        {
            ResourceType rt = "Microsoft.Network1/VirtualNetworks2/subnets1";
            object rightObject = null;
            Assert.IsFalse(rt.Equals(rightObject));

            object sameRt = rt;
            Assert.IsTrue(rt.Equals(sameRt));

            object intRt = 5;
            Assert.IsFalse(rt.Equals(intRt));
        }

        [TestCase(false, "Microsoft.Network1/VirtualNetworks2/subnets1", null)]
        [TestCase(true, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        public void EqualsWithObjectString(bool expected, string left, string right)
        {
            ResourceType rt = left;
            object rightObject = right;
            Assert.AreEqual(expected, rt.Equals(rightObject));
        }

        [TestCase("Microsoft.classicStorage/storageAccounts")]
        [TestCase("Microsoft.ClassicStorage/diffaccount")]
        [TestCase("Microsoft.ClassicStorage/storageAccounts")]
        [TestCase("Foo.Bar/puppies")]
        public void ImplicitToString(string expected)
        {
            ResourceType type = expected;
            string actual = type;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Microsoft.Compute/virtualMachines/myVmName", "Microsoft.Compute", "virtualMachines/myVmName", "myVmName")]
        [TestCase("Microsoft.Compute/virtualMachines", "Microsoft.Compute", "virtualMachines", "virtualMachines")]
        [TestCase("Microsoft.Compute/virtualMachines/myVmName/fooType/fooName", "Microsoft.Compute", "virtualMachines/myVmName/fooType/fooName", "fooName")]
        [TestCase("Microsoft.Compute/virtualMachines/fooType", "Microsoft.Compute", "virtualMachines/fooType", "fooType")]
        [TestCase("Microsoft.Compute/virtualMachines/myVmName", "Microsoft.Compute", "virtualMachines/myVmName", "myVmName")]
        [TestCase("Microsoft.Network/virtualNetworks/testvnet/subnets/testsubnet", "Microsoft.Network", "virtualNetworks/testvnet/subnets/testsubnet", "testsubnet")]
        [TestCase("Microsoft.Compute/virtualMachines/myVmName/fooType/fooName", "Microsoft.Compute", "virtualMachines/myVmName/fooType/fooName", "fooName")]
        public void ValidateParse(string idOrType, string expectedNamespace, string expectedType, string expectedLast)
        {
            ResourceType rt = idOrType;
            Assert.AreEqual(expectedNamespace, rt.Namespace);
            Assert.AreEqual(expectedType, rt.Type);
            Assert.AreEqual(expectedLast, rt.GetLastType());
        }
    }
}
