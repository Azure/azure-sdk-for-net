// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

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
            Assert.That(leftResource == right, Is.EqualTo(expected));
        }

        [TestCase(true, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(true, "Microsoft.Network1/Virtualnetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(false, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets2")]
        public void EqualsOpStringToResourceType(bool expected, string left, string right)
        {
            ResourceType rightResource = right;
            Assert.That(left == rightResource, Is.EqualTo(expected));
        }

        [TestCase(true, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(true, "Microsoft.Network1/Virtualnetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(false, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets2")]
        public void EqualsOpResourceTypeToResourceType(bool expected, string left, string right)
        {
            ResourceType leftResource = left;
            ResourceType rightResource = right;
            Assert.That(leftResource == rightResource, Is.EqualTo(expected));
            Assert.That(leftResource.GetHashCode() == rightResource.GetHashCode(), Is.EqualTo(expected));
        }

        [TestCase(false, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(false, "Microsoft.Network1/Virtualnetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(true, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets2")]
        public void NotEqualsOpResourceTypeToString(bool expected, string left, string right)
        {
            ResourceType leftResource = left;
            Assert.That(leftResource != right, Is.EqualTo(expected));
        }

        [TestCase(false, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(false, "Microsoft.Network1/Virtualnetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(true, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets2")]
        public void NotEqualsOpStringToResourceType(bool expected, string left, string right)
        {
            ResourceType rightResource = right;
            Assert.That(left != rightResource, Is.EqualTo(expected));
        }

        [TestCase(false, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(false, "Microsoft.Network1/Virtualnetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase(true, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets2")]
        public void NotEqualsOpResourceTypeToResourceType(bool expected, string left, string right)
        {
            ResourceType leftResource = left;
            ResourceType rightResource = right;
            Assert.That(leftResource != rightResource, Is.EqualTo(expected));
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
            Assert.That(rt.Equals(rightObject), Is.EqualTo(expected));
            Assert.That(rt.GetHashCode() == rightRt.GetHashCode(), Is.EqualTo(expected));

            object sameRt = rt;
            Assert.That(rt, Is.EqualTo(sameRt));

            object intRt = 5;
            Assert.That(rt.Equals(intRt), Is.False);
        }

        [Test]
        public void EqualsWithObjectResourceTypeNull()
        {
            ResourceType rt = "Microsoft.Network1/VirtualNetworks2/subnets1";
            object rightObject = null;
            Assert.That(rt.Equals(rightObject), Is.False);

            object sameRt = rt;
            Assert.That(rt, Is.EqualTo(sameRt));

            object intRt = 5;
            Assert.That(rt.Equals(intRt), Is.False);
        }

        [TestCase(false, "Microsoft.Network1/VirtualNetworks2/subnets1", null)]
        [TestCase(true, "Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        public void EqualsWithObjectString(bool expected, string left, string right)
        {
            ResourceType rt = left;
            object rightObject = right;
            Assert.That(rt.Equals(rightObject), Is.EqualTo(expected));
        }

        [TestCase("Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase("Microsoft.Network1/Virtualnetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        public void CompareToEqualsWithResourceType(string left, string right)
        {
            ResourceType rt = left;
            ResourceType rightRt = right;
            Assert.That(rt.CompareTo(rightRt), Is.EqualTo(0));
        }

        [TestCase("Microsoft.Network1/VirtualNetworks2", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase("Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2/subnets2")]
        [TestCase("Microsoft.ClassicStorage/storageAccounts", "Microsoft.Network/VirtualNetworks2/subnets1")]
        public void CompareToLessThanWithResourceType(string left, string right)
        {
            ResourceType rt = left;
            ResourceType rightRt = right;
            Assert.That(rt.CompareTo(rightRt), Is.LessThan(0));
        }

        [TestCase("Microsoft.Network1/VirtualNetworks2/subnets1", "Microsoft.Network1/VirtualNetworks2")]
        [TestCase("Microsoft.Network1/VirtualNetworks2/subnets2", "Microsoft.Network1/VirtualNetworks2/subnets1")]
        [TestCase("Microsoft.Network/VirtualNetworks2/subnets1", "Microsoft.ClassicStorage/storageAccounts")]
        public void CompareToGreaterThanWithResourceType(string left, string right)
        {
            ResourceType rt = left;
            ResourceType rightRt = right;
            Assert.That(rt.CompareTo(rightRt), Is.GreaterThan(0));
        }

        [TestCase]
        public void CompareToWithDefaultResourceType()
        {
            ResourceType rt = "Microsoft.Network1/VirtualNetworks2/subnets1";
            ResourceType defaultRt = default;
            ResourceType defaultRt2 = default;
            Assert.That(defaultRt.CompareTo(defaultRt2), Is.EqualTo(0));
            Assert.That(defaultRt.CompareTo(rt), Is.LessThan(0)); // default < non-default ResourceType
            Assert.That(rt.CompareTo(defaultRt), Is.GreaterThan(0)); // non-default ResourceType > default
        }

        [TestCase("Microsoft.classicStorage/storageAccounts")]
        [TestCase("Microsoft.ClassicStorage/diffaccount")]
        [TestCase("Microsoft.ClassicStorage/storageAccounts")]
        [TestCase("Foo.Bar/puppies")]
        public void ImplicitToString(string expected)
        {
            ResourceType type = expected;
            string actual = type;

            Assert.That(actual, Is.EqualTo(expected));
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
            Assert.That(rt.Namespace, Is.EqualTo(expectedNamespace));
            Assert.That(rt.Type, Is.EqualTo(expectedType));
            Assert.That(rt.GetLastType(), Is.EqualTo(expectedLast));
        }
    }
}
