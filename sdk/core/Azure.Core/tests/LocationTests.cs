// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [Parallelizable]
    public class LocationTests
    {
        [TestCase("WestUS2", "westus2", "West US 2")]
        [TestCase("WestUS4", "WestUS4", null)]
        [TestCase("West US 2", "westus2", "West US 2")]
        [TestCase("WEst Us 2", "westus2", "West US 2")]
        [TestCase("West Us 3", "westus3", "West US 3")]
        [TestCase("West-Us 2", "west-us2", "West-Us 2")]
        [TestCase(" West Us 2", "westus2", "West US 2")]
        [TestCase(" ", "", " ")]
        [TestCase("", "", null)]
        [TestCase("Us West", "uswest", "Us West")]
        [TestCase("A B C 5", "abc5", "A B C 5")]
        public void ConvertFromDisplayName(string input, string expectedName, string expectedDisplayName)
        {
            AzureLocation loc = input;
            Assert.That(loc.Name, Is.EqualTo(expectedName));
            Assert.That(loc.DisplayName, Is.EqualTo(expectedDisplayName));
        }

        [TestCase("northcentralus", "northcentralus", "North Central US")]
        [TestCase("westus2", "westus2", "West US 2")]
        [TestCase("uswest1a", "uswest1a", null)]
        [TestCase("uswest1", "uswest1", null)]
        [TestCase("westus", "westus", "West US")]
        [TestCase("westus ", "westus", "West US")]
        [TestCase("Westus", "westus", "West US")]
        [TestCase("XWestus", "XWestus", null)]
        [TestCase("*uswest", "*uswest", null)]
        [TestCase("us*west", "us*west", null)]
        [TestCase("uswest*", "uswest*", null)]
        [TestCase("", "", null)]
        public void NameTypeIsName(string location, string expectedName, string expectedDisplayName)
        {
            AzureLocation loc = location;
            Assert.That(loc.Name, Is.EqualTo(expectedName));
            Assert.That(loc.DisplayName, Is.EqualTo(expectedDisplayName));
        }

        [TestCase("us-west")]
        [TestCase("us-west-west")]
        [TestCase("us-west-2")]
        [TestCase("us-west-west-2")]
        [TestCase("a-b-c-5")]
        public void NameTypeIsCanonical(string location)
        {
            AzureLocation loc = location;
            Assert.That(loc.Name, Is.EqualTo(location));
            Assert.That(loc.DisplayName, Is.Null);
        }

        [TestCase(true, "West Us", "West Us")]
        [TestCase(true, "West Us", "WestUs")]
        [TestCase(true, "!#()@(#@", "!#()@(#@")]
        [TestCase(true, "W3$t U$", "W3$t U$")]
        [TestCase(true, "1234567890", "1234567890")]
        [TestCase(false, "West Us", "WestUs2")]
        [TestCase(false, "West US", "")]
        [TestCase(false, "West US", "!#()@(#@")]
        [TestCase(false, "West US", "W3$t U$")]
        public void EqualsToLocation(bool expected, string left, string right)
        {
            AzureLocation loc1 = left;
            AzureLocation loc2 = right;
            Assert.That(loc1.Equals(loc2), Is.EqualTo(expected));
            if (right != null)
                Assert.That(loc1.GetHashCode() == loc2.GetHashCode(), Is.EqualTo(expected), $"Hashcodes comparison was expect {expected} but was {!expected}, ({loc1.GetHashCode()}, {loc2.GetHashCode()})");
        }

        [Test]
        public void NullNameInCtor()
        {
            Assert.Throws<ArgumentNullException>(() => { new AzureLocation(null, null); });
            Assert.DoesNotThrow(() => { new AzureLocation("test", null); });
        }

        [Test]
        public void EqualsToObject()
        {
            AzureLocation loc = AzureLocation.WestUS2;

            object intLoc = 5;
            Assert.That(loc.Equals(intLoc), Is.False);

            object nullLoc = null;
            Assert.That(loc.Equals(nullLoc), Is.False);

            object sameLoc = loc;
            Assert.That(loc, Is.EqualTo(sameLoc));

            object loc2 = AzureLocation.EastUS2;
            Assert.That(loc.Equals(loc2), Is.False);
        }

        [TestCase(true, "West Us", "West Us")]
        [TestCase(true, "West Us", "WestUs")]
        [TestCase(true, "!#()@(#@", "!#()@(#@")]
        [TestCase(true, "W3$t U$", "W3$t U$")]
        [TestCase(true, "1234567890", "1234567890")]
        [TestCase(false, "West Us", "WestUs2")]
        [TestCase(false, "West Us", "")]
        [TestCase(false, "West Us", "!#()@(#@")]
        [TestCase(false, "West Us", "W3$t U$")]
        public void EqualsToString(bool expected, string left, string right)
        {
            AzureLocation location = left;
            Assert.That(location.Equals(right), Is.EqualTo(expected));
        }

        [TestCase("West US", "westus", "West US")]
        [TestCase("west-us", "west-us", null)]
        [TestCase("westus", "westus", "West US")]
        [TestCase("Private Cloud", "privatecloud", "Private Cloud")]
        [TestCase("Private-cloud", "Private-cloud", null)]
        [TestCase("privatecloud", "privatecloud", null)]
        [TestCase("1$S#@$%^", "1$S#@$%^", null)]
        [TestCase("", "", null)]
        [TestCase(" ", "", " ")]
        [TestCase(null, null, null)]
        public void CanCastLocationToString(string name, string expectedName, string expectedDisplayName)
        {
            if (name == null)
            {
                Assert.Throws<ArgumentNullException>(() => { AzureLocation location = name; });
            }
            else
            {
                AzureLocation location = name;
                string strLocation = location;
                Assert.That(strLocation, Is.EqualTo(expectedName));
                Assert.That(location.DisplayName, Is.EqualTo(expectedDisplayName));
            }
        }

        [TestCase(false, "WESTUS2", "EASTUS2")]
        [TestCase(false, "EASTUS2", "WESTUS2")]
        [TestCase(true, "WESTUS2", "WESTUS2")]
        public void EqualOperator(bool expected, string string1, string string2)
        {
            AzureLocation loc1 = string1;
            AzureLocation loc2 = string2;
            Assert.That(loc1 == loc2, Is.EqualTo(expected));
        }

        [TestCase(true, "WESTUS2", "EASTUS2")]
        [TestCase(true, "EASTUS2", "WESTUS2")]
        [TestCase(false, "WESTUS2", "WESTUS2")]
        public void NotEqualOperator(bool expected, string string1, string string2)
        {
            AzureLocation loc1 = string1;
            AzureLocation loc2 = string2;
            Assert.That(loc1 != loc2, Is.EqualTo(expected));
        }
    }
}
