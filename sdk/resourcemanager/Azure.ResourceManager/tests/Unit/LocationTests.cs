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
        [TestCase("WestUS4", "WestUS4", null)]
        [TestCase("West US 2", "westus2", "West US 2")]
        [TestCase("WEst Us 2", "westus2", "West US 2")]
        [TestCase("West Us 3", "westus3", "West Us 3")]
        [TestCase("West-Us 2", "west-us2", "West-Us 2")]
        [TestCase(" West Us 2", "westus2", "West US 2")]
        [TestCase(" ", "", " ")]
        [TestCase("", "", null)]
        [TestCase("Us West", "uswest", "Us West")]
        [TestCase("A B C 5", "abc5", "A B C 5")]
        public void ConvertFromDisplayName(string input, string expectedName, string expectedDisplayName)
        {
            Location loc = input;
            Assert.AreEqual(expectedName, loc.Name);
            Assert.AreEqual(expectedDisplayName, loc.DisplayName);
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
            Location loc1 = left;
            Location loc2 = right;
            Assert.AreEqual(expected, loc1.Equals(loc2));
            if(right != null)
                Assert.AreEqual(expected, loc1.GetHashCode() == loc2.GetHashCode(), $"Hashcodes comparison was expect {expected} but was {!expected}, ({loc1.GetHashCode()}, {loc2.GetHashCode()})");
        }

        [Test]
        public void NullNameInCtor()
        {
            Assert.Throws<ArgumentNullException>(() => { new Location(null, null); });
            Assert.DoesNotThrow(() => { new Location("test", null); });
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
            Location location = left;
            Assert.AreEqual(expected, location.Equals(right));
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
                //Assert.Throws<ArgumentNullException>(()=> { Location location = name; });
            }
            else
            {
                Location location = name;
                string strLocation = location;
                Assert.AreEqual(expectedName, strLocation);
                Assert.AreEqual(expectedDisplayName, location.DisplayName);
            }
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
