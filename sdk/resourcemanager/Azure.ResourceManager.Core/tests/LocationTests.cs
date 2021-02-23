using NUnit.Framework;
using System;

namespace Azure.ResourceManager.Core.Tests
{
    public class LocationTests
    {
        [TestCase("westus", "westus", "west-us", "West US")]
        [TestCase("west-us", "westus", "west-us", "West US")]
        [TestCase("West US", "westus", "west-us", "West US")]
        [TestCase("privatecloud", "privatecloud", "privatecloud", "privatecloud")]
        [TestCase("private-cloud", "privatecloud", "private-cloud", "Private Cloud")]
        [TestCase("Private Cloud", "privatecloud", "private-cloud", "Private Cloud")]
        [TestCase("@$!()*&", "@$!()*&", "@$!()*&", "@$!()*&")]
        [TestCase("W3$t U$ 2", "W3$t U$ 2", "W3$t U$ 2", "W3$t U$ 2")]
        [TestCase("", "", "", "")]
        [TestCase(" ", " ", " ", " ")]
        [TestCase(null, null, null, null)]
        public void CanCreateLocation(string name, string expectedName, string expectedCanonincalName, string expectedDisplayName)
        {
            LocationData location = name;
            if (name == null)
            {
                Assert.IsNull(location);
            }
            else
            {
                Assert.AreEqual(expectedName, location.Name);
                Assert.AreEqual(expectedCanonincalName, location.CanonicalName);
                Assert.AreEqual(expectedDisplayName, location.DisplayName);
            }
        }

        [TestCase("USNorth")]
        [TestCase("Us West 12")]
        [TestCase("Us West 1a")]
        [TestCase(" Us West 1")]
        [TestCase("Us West 1 ")]
        [TestCase("*Us West")]
        [TestCase("Us *West")]
        [TestCase("Us West *")]
        [TestCase("")]
        public void NameTypeIsName(string location)
        {
            LocationData loc = location;
            Assert.IsTrue(loc.Name == loc.DisplayName && loc.Name == loc.CanonicalName);
        }

        [TestCase("us-west")]
        [TestCase("us-west-west")]
        [TestCase("us-west-2")]
        [TestCase("us-west-west-2")]
        [TestCase("a-b-c-5")]
        public void NameTypeIsCanonical(string location)
        {
            LocationData loc = location;
            Assert.IsTrue(loc.CanonicalName == location && loc.Name != location && loc.DisplayName != location);
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
            LocationData loc = location;
            Assert.IsTrue(loc.DisplayName == location && loc.Name != location && loc.CanonicalName != location);
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
        [TestCase(false, "West US", null)]
        public void EqualsToObject(bool expected, string left, string right)
        {
            LocationData loc1 = left;
            LocationData loc2 = right;
            Assert.AreEqual(expected, loc1.Equals(loc2));

            if (expected)
            {
                Assert.AreEqual(0, loc1.CompareTo(loc2));
            }
            else
            {
                Assert.AreNotEqual(0, loc1.CompareTo(loc2));
            }
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
        [TestCase(false, "West Us", null)]
        public void EqualsToString(bool expected, string left, string right)
        {
            LocationData location = left;
            Assert.AreEqual(expected, location.Equals(right));

            if (expected)
            {
                Assert.AreEqual(0, location.CompareTo(right));
            }
            else
            {
                Assert.AreNotEqual(0, location.CompareTo(right));
            }
        }

        [TestCase("", "")]
        [TestCase("West US", "West US")]
        [TestCase("west-us", "West US")]
        [TestCase("westus2", "West US 2")]
        [TestCase("private-cloud", "Private Cloud")]
        public void CanParseToString(string name, string expected)
        {
            LocationData location1 = name;
            Assert.AreEqual(expected, location1.ToString());
        }

        [TestCase("West US", "West US", 0)]
        [TestCase("West US", "west-us", 0)]
        [TestCase("West US", "westus", 0)]
        [TestCase("Central Europe", "Central Europe", 0)]
        [TestCase("Central Europe", "central-europe", 0)]
        [TestCase("Central Europe", "centraleurope", 0)]
        [TestCase("South US", "East US", 1)]
        [TestCase("South US", "east-us", 1)]
        [TestCase("South US", "West US", -1)]
        [TestCase("South US", "west-us", -1)]
        [TestCase("South US", null, 1)]
        public void CompareToObject(string left, string right, int expected)
        {
            LocationData location1 = left;
            LocationData location2 = right;
            Assert.AreEqual(expected, location1.CompareTo(location2));
            if (right != null)
            {
                Assert.AreEqual(expected * -1, location2.CompareTo(location1));
            }
        }

        [TestCase("West US", "West US", 0)]
        [TestCase("West US", "west-us", 0)]
        [TestCase("West US", "westus", 0)]
        [TestCase("Central Europe", "Central Europe", 0)]
        [TestCase("Central Europe", "central-europe", 0)]
        [TestCase("Central Europe", "centraleurope", 0)]
        [TestCase("South US", "East US", 1)]
        [TestCase("South US", "east-us", 1)]
        [TestCase("South US", "West US", -1)]
        [TestCase("South US", "west-us", -1)]
        [TestCase("South US", null, 1)]
        public void CompareToString(string left, string right, int expected)
        {
            LocationData location1 = left;
            Assert.AreEqual(expected, location1.CompareTo(right));
            if (right != null)
            {
                location1 = right;
                Assert.AreEqual(expected * -1, location1.CompareTo(left));
            }
        }

        [TestCase("West US", "West US")]
        [TestCase("west-us", "West US")]
        [TestCase("westus", "West US")]
        [TestCase("Private Cloud", "Private Cloud")]
        [TestCase("private-cloud", "Private Cloud")]
        [TestCase("privatecloud", "privatecloud")]
        [TestCase("1$S#@$%^", "1$S#@$%^")]
        [TestCase("", "")]
        [TestCase(" ", " ")]
        [TestCase(null, null)]
        public void CanCastLocationToString(string name, string expected)
        {
            LocationData location = name;
            string strLocation = location;
            Assert.AreEqual(expected, strLocation);
        }

        [TestCase ("West US", "West US")]
        [TestCase ("west-us", "West US")]
        [TestCase ("westus", "West US")]
        [TestCase ("Private Cloud", "Private Cloud")]
        [TestCase ("private-cloud", "Private Cloud")]
        [TestCase ("privatecloud", "privatecloud")]
        [TestCase ("1$S#@$%^", "1$S#@$%^")]
        [TestCase ("","")]
        [TestCase (" ", " ")]
        [TestCase (null,null)]
        public void CanCastStringToLocation(string name, string expected)
        {
            LocationData location1 = name;
            if (name == null)
                Assert.Throws<System.NullReferenceException>(()=> { string x = location1.DisplayName; });
            else
                Assert.AreEqual(expected, location1.DisplayName);  
        }

        [Test]
        public void CanAccessDefaultLocation()
        {
            Assert.IsNotNull(LocationData.Default);
            LocationData location = LocationData.Default;
            Assert.IsTrue(location.Equals(LocationData.Default));
        }
    }
}
