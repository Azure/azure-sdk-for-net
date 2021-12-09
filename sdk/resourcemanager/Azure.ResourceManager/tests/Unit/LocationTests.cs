using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using System;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class LocationTests
    {
        [TestCase("WestUS2", "westus2", "West US 2")]
        [TestCase("WestUS4", "westus4", "WestUS4")]
        [TestCase("West US 2", "westus2", "West US 2")]
        [TestCase("West Us 3", "westus3", "West Us 3")]
        [TestCase("West-Us 2", "west-us2", "West-Us 2")]
        [TestCase(" West Us 2", "westus2", "West US 2")]
        [TestCase(" ", "", " ")]
        [TestCase("", "", "")]
        public void ConvertFromDisplayName(string input, string expectedName, string expectedDisplayName)
        {
            Location loc = ArmResource.ConvertDisplayNameToLocation(input);
            Assert.AreEqual(expectedName, loc.Name);
            Assert.AreEqual(expectedDisplayName, loc.DisplayName);
        }

        [Test]
        public void ConvertFromDisplayNameNull()
        {
            Assert.Throws<ArgumentNullException>(() => ArmResource.ConvertDisplayNameToLocation(null));
        }

        [TestCase("West US", "West US", null)]
        [TestCase("west-us", "west-us", null)]
        [TestCase("westus", "westus", "West US")]
        [TestCase("Private Cloud", "Private Cloud", null)]
        [TestCase("private-cloud", "private-cloud", null)]
        [TestCase("privatecloud", "privatecloud", null)]
        [TestCase("1$S#@$%^", "1$S#@$%^", null)]
        [TestCase("", "", null)]
        [TestCase(" ", " ", null)]
        [TestCase(null, null, null)]
        public void CanConstructLocationFromString(string name, string expectedName, string expectedDisplayName)
        {
            Location location = name;
            if (name == null)
            {
                Assert.IsNull(location);
            }
            else
            {
                string strLocation = location;
                Assert.AreEqual(name, strLocation);
                Assert.AreEqual(expectedDisplayName, location.DisplayName);
            }
        }

        [TestCase("northcentralus", "northcentralus", "North Central US")]
        [TestCase("westus2", "westus2", "West US 2")]
        [TestCase("uswest1a", "uswest1a", null)]
        [TestCase("uswest1", "uswest1", null)]
        [TestCase("westus", "westus", "West US")]
        [TestCase("westus ", "westus ", null)]
        [TestCase("*uswest", "*uswest", null)]
        [TestCase("us*west", "us*west", null)]
        [TestCase("uswest*", "uswest*", null)]
        [TestCase("", "", null)]
        public void NameTypeIsName(string location, string expectedName, string expectedDisplayName)
        {
            Location loc = location;
            Assert.AreEqual(expectedName, loc.Name);
            Assert.AreEqual(expectedDisplayName, loc.DisplayName);
        }

        [TestCase("us-west")]
        [TestCase("us-west-west")]
        [TestCase("us-west-2")]
        [TestCase("us-west-west-2")]
        [TestCase("a-b-c-5")]
        public void NameTypeIsCanonical(string location)
        {
            Location loc = location;
            Assert.AreEqual(location, loc.Name);
            Assert.IsNull(loc.DisplayName);
        }

        [TestCase("Us West")]
        [TestCase("US West")]
        [TestCase("USa West")]
        [TestCase("West US")]
        [TestCase("West USa")]
        [TestCase("Us West West")]
        [TestCase("Us West 2")]
        [TestCase("Us West West 2")]
        [TestCase("A B C 5")]
        public void NameTypeIsDisplayName(string location)
        {
            Location loc = location;
            Assert.IsNull(loc.DisplayName);
            Assert.AreEqual(loc.Name, location);
        }

        [TestCase(true, "West Us", "West Us")]
        [TestCase(false, "West Us", "WestUs")]
        [TestCase(true, "!#()@(#@", "!#()@(#@")]
        [TestCase(true, "W3$t U$", "W3$t U$")]
        [TestCase(true, "1234567890", "1234567890")]
        [TestCase(false, "West Us", "WestUs2")]
        [TestCase(false, "West US", "")]
        [TestCase(false, "West US", "!#()@(#@")]
        [TestCase(false, "West US", "W3$t U$")]
        [TestCase(false, "West US", null)]
        public void EqualsToLocation(bool expected, string left, string right)
        {
            Location loc1 = left;
            Location loc2 = right;
            Assert.AreEqual(expected, loc1.Equals(loc2));
            Assert.AreEqual(expected, loc1.GetHashCode() == loc2?.GetHashCode(), $"Hashcodes comparison was expect {expected} but was {!expected}, ({loc1.GetHashCode()}, {loc2?.GetHashCode()})");
        }

        [Test]
        public void EqualsToObject()
        {
            Location loc = Location.WestUS2;

            object intLoc = 5;
            Assert.IsFalse(loc.Equals(intLoc));

            object nullLoc = null;
            Assert.IsFalse(loc.Equals(nullLoc));

            object sameLoc = loc;
            Assert.IsTrue(loc.Equals(sameLoc));

            object loc2 = Location.EastUS2;
            Assert.IsFalse(loc.Equals(loc2));
        }

        [TestCase(true, "West Us", "West Us")]
        [TestCase(false, "West Us", "WestUs")]
        [TestCase(true, "!#()@(#@", "!#()@(#@")]
        [TestCase(true, "W3$t U$", "W3$t U$")]
        [TestCase(true, "1234567890", "1234567890")]
        [TestCase(false, "West Us", "WestUs2")]
        [TestCase(false, "West Us", "")]
        [TestCase(false, "West Us", "!#()@(#@")]
        [TestCase(false, "West Us", "W3$t U$")]
        [TestCase(false, "West Us", null)]
        public void EqualsToString(bool expected, string left, string right)
        {
            Location location = left;
            Assert.AreEqual(expected, location.Equals(right));
        }

        [TestCase("", "")]
        [TestCase("West US", "West US")]
        [TestCase("west-us", "west-us")]
        [TestCase("westus2", "westus2")]
        [TestCase("private-cloud", "private-cloud")]
        public void CanParseToString(string name, string expected)
        {
            Location location1 = name;
            Assert.AreEqual(expected, location1.ToString());
        }

        [TestCase("West US", "West US", null)]
        [TestCase("west-us", "west-us", null)]
        [TestCase("westus", "westus", "West US")]
        [TestCase("Private Cloud", "Private Cloud", null)]
        [TestCase("private-cloud", "private-cloud", null)]
        [TestCase("privatecloud", "privatecloud", null)]
        [TestCase("1$S#@$%^", "1$S#@$%^", null)]
        [TestCase("", "", null)]
        [TestCase(" ", " ", null)]
        [TestCase(null, null, null)]
        public void CanCastLocationToString(string name, string expectedName, string expectedDisplayName)
        {
            Location location = name;
            if (name == null)
            {
                Assert.IsNull(location);
            }
            else
            {
                string strLocation = location;
                Assert.AreEqual(name, strLocation);
                Assert.AreEqual(expectedDisplayName, location.DisplayName);
            }
        }

        [Test]
        public void EqualOperatorNull()
        {
            Location loc = Location.WestUS2;
            Assert.IsFalse(loc == null);
            Assert.IsFalse(null == loc);
        }

        [TestCase(false, "WESTUS2", "EASTUS2")]
        [TestCase(false, "EASTUS2", "WESTUS2")]
        [TestCase(true, "WESTUS2", "WESTUS2")]
        public void EqualOperator(bool expected, string string1, string string2)
        {
            Location loc1 = string1;
            Location loc2 = string2;
            Assert.AreEqual(expected, loc1 == loc2);
        }

        [TestCase(true, "WESTUS2", "EASTUS2")]
        [TestCase(true, "EASTUS2", "WESTUS2")]
        [TestCase(false, "WESTUS2", "WESTUS2")]
        public void NotEqualOperator(bool expected, string string1, string string2)
        {
            Location loc1 = string1;
            Location loc2 = string2;
            Assert.AreEqual(expected, loc1 != loc2);
        }
    }
}
