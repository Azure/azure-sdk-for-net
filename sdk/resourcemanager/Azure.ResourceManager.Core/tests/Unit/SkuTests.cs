﻿using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    class SkuTests
    {
        [TestCase(0, "name", "name")]
        [TestCase(0, "Name", "name")]
        [TestCase(0, null, null)]
        [TestCase(1, "name", null)]
        [TestCase(-1, null, "name")]
        [TestCase(0, "${?/>._`", "${?/>._`")]
        [TestCase(1, "${?/>._`", "")]
        public void CompareToName(int expected, string name1, string name2)
        {
            Sku sku1 = new Sku(name1, null, null, null, null);
            Sku sku2 = new Sku(name2, null, null, null, null);
            Assert.AreEqual(expected, sku1.CompareTo(sku2));
        }

        [TestCase(0, "family", "family")]
        [TestCase(0, "Family", "family")]
        [TestCase(0, null, null)]
        [TestCase(1, "family", null)]
        [TestCase(-1, null, "family")]
        [TestCase(0, "${?/>._`", "${?/>._`")]
        [TestCase(1, "${?/>._`", "")]
        public void CompareToFamily(int expected, string family1, string family2)
        {
            Sku sku1 = new Sku(null, null, null, family1, null);
            Sku sku2 = new Sku(null, null, null, family2, null);
            Assert.AreEqual(expected, sku1.CompareTo(sku2));
        }

        [TestCase(0, "model", "model")]
        [TestCase(0, "Model", "model")]
        [TestCase(0, null, null)]
        [TestCase(1, "model", null)]
        [TestCase(-1, null, "model")]
        [TestCase(0, "${?/>._`", "${?/>._`")]
        [TestCase(1, "${?/>._`", "")]
        public void CompareToModel(int expected, string model1, string model2)
        {
            Sku sku1 = new Sku(null, null, null, null, model1);
            Sku sku2 = new Sku(null, null, null, null, model2);
            Assert.AreEqual(expected, sku1.CompareTo(sku2));
        }

        [TestCase(0, "size", "size")]
        [TestCase(0, "Size", "size")]
        [TestCase(0, null, null)]
        [TestCase(1, "size", null)]
        [TestCase(-1, null, "size")]
        [TestCase(0, "${?/>._`", "${?/>._`")]
        [TestCase(1, "${?/>._`", "")]
        public void CompareToSize(int expected, string size1, string size2)
        {
            Sku sku1 = new Sku(null, null, size1, null, null);
            Sku sku2 = new Sku(null, null, size2, null, null);
            Assert.AreEqual(expected, sku1.CompareTo(sku2));
        }

        [TestCase(0, "tier", "tier")]
        [TestCase(0, "Tier", "tier")]
        [TestCase(0, null, null)]
        [TestCase(1, "tier", null)]
        [TestCase(-1, null, "tier")]
        [TestCase(0, "${?/>._`", "${?/>._`")]
        [TestCase(1, "${?/>._`", "")]
        public void CompareToTier(int expected, string tier1, string tier2)
        {
            Sku sku1 = new Sku(null, tier1, null, null, null);
            Sku sku2 = new Sku(null, tier2, null, null, null);
            Assert.AreEqual(expected, sku1.CompareTo(sku2));
        }

        [TestCase(0, 1, 1)]
        [TestCase(1, 1, -1)]
        [TestCase(0, null, null)]
        [TestCase(1, -1, null)]
        [TestCase(-1, null, 1)]
        public void CompareToCapacity(int expected, long? capacity1, long? capacity2)
        {
            Sku sku1 = capacity1 == null ? new Sku(null, null, null, null, null) : new Sku(null, null, null, null, null, capacity1);
            Sku sku2 = capacity2 == null ? new Sku(null, null, null, null, null) : new Sku(null, null, null, null, null, capacity2);
            Assert.AreEqual(expected, sku1.CompareTo(sku2));
        }

        [Test]
        public void CompareToNullSku()
        {
            Sku sku1 = new Sku(null, null, null, null, null);
            Sku sku2 = null;
            Assert.AreEqual(1, sku1.CompareTo(sku2));
        }

        [Test]
        public void CompareToSameSkus()
        {
            Sku sku1 = new Sku(null, null, null, null, null);
            Sku sku2 = sku1;
            Assert.AreEqual(0, sku1.CompareTo(sku2));
        }

        [TestCase(1, "Nameb", "namea", "familya", "Familyb")]
        [TestCase(1, "Nameb", "namea", "familya", "familya")]
        [TestCase(-1, "namea", "Nameb", "Familyb", "familya")]
        public void CompareToMore(int expected, string name1, string name2, string family1, string family2)
        {
            Sku sku1 = new Sku(name1, null, null, family1, null);
            Sku sku2 = new Sku(name2, null, null, family2, null);
            Assert.AreEqual(expected, sku1.CompareTo(sku2));
        }

        [TestCase(true, "name", "name")]
        [TestCase(true, "Name", "name")]
        [TestCase(true, null, null)]
        [TestCase(false, "name", null)]
        [TestCase(false, null, "name")]
        [TestCase(true, "${?/>._`", "${?/>._`")]
        [TestCase(false, "${?/>._`", "")]
        public void EqualsToName(bool expected, string name1, string name2)
        {
            Sku sku1 = new Sku(name1, null, null, null, null);
            Sku sku2 = new Sku(name2, null, null, null, null);
            if (expected)
            {
                Assert.IsTrue(sku1.Equals(sku2));
            }
            else
            {
                Assert.IsFalse(sku1.Equals(sku2));
            }
        }

        [TestCase(true, "family", "family")]
        [TestCase(true, "Family", "family")]
        [TestCase(true, null, null)]
        [TestCase(false, "family", null)]
        [TestCase(false, null, "family")]
        [TestCase(true, "${?/>._`", "${?/>._`")]
        [TestCase(false, "${?/>._`", "")]
        public void EqualsToFamily(bool expected, string family1, string family2)
        {
            Sku sku1 = new Sku(null, null, null, family1, null);
            Sku sku2 = new Sku(null, null, null, family2, null);
            if (expected)
            {
                Assert.IsTrue(sku1.Equals(sku2));
            }
            else
            {
                Assert.IsFalse(sku1.Equals(sku2));
            }
        }

        [TestCase(true, "size", "size")]
        [TestCase(true, "Size", "size")]
        [TestCase(true, null, null)]
        [TestCase(false, "size", null)]
        [TestCase(false, null, "size")]
        [TestCase(true, "${?/>._`", "${?/>._`")]
        [TestCase(false, "${?/>._`", "")]
        public void EqualsToSize(bool expected, string size1, string size2)
        {
            Sku sku1 = new Sku(null, null, size1, null, null);
            Sku sku2 = new Sku(null, null, size2, null, null);
            if (expected)
            {
                Assert.IsTrue(sku1.Equals(sku2));
            }
            else
            {
                Assert.IsFalse(sku1.Equals(sku2));
            }
        }

        [TestCase(true, "tier", "tier")]
        [TestCase(true, "Tier", "tier")]
        [TestCase(true, null, null)]
        [TestCase(false, "tier", null)]
        [TestCase(false, null, "tier")]
        [TestCase(true, "${?/>._`", "${?/>._`")]
        [TestCase(false, "${?/>._`", "")]
        public void EqualsToTier(bool expected, string tier1, string tier2)
        {
            Sku sku1 = new Sku(null, tier1, null, null, null, null);
            Sku sku2 = new Sku(null, tier2, null, null, null, null);
            if (expected)
            {
                Assert.IsTrue(sku1.Equals(sku2));
            }
            else
            {
                Assert.IsFalse(sku1.Equals(sku2));
            }
        }

        [TestCase(true, "model", "model")]
        [TestCase(true, "Model", "model")]
        [TestCase(true, null, null)]
        [TestCase(false, "model", null)]
        [TestCase(false, null, "model")]
        [TestCase(true, "${?/>._`", "${?/>._`")]
        [TestCase(false, "${?/>._`", "")]
        public void EqualsToModel(bool expected, string model1, string model2)
        {
            Sku sku1 = new Sku(null, null, null, null, model1, null);
            Sku sku2 = new Sku(null, null, null, null, model2, null);
            if (expected)
            {
                Assert.IsTrue(sku1.Equals(sku2));
            }
            else
            {
                Assert.IsFalse(sku1.Equals(sku2));
            }
        }

        [TestCase(true, 1, 1)]
        [TestCase(false, 1, 0)]
        [TestCase(true, null, null)]
        [TestCase(false, 1, null)]
        [TestCase(false, null, 1)]
        public void EqualsToCapacity(bool expected, long? capacity1, long? capacity2)
        {
            Sku sku1 = capacity1 == null ? new Sku(null, null, null, null, null) : new Sku(null, null, null, null, null, capacity1);
            Sku sku2 = capacity2 == null ? new Sku(null, null, null, null, null) : new Sku(null, null, null, null, null, capacity2);
            if (expected)
            {
                Assert.IsTrue(sku1.Equals(sku2));
            }
            else
            {
                Assert.IsFalse(sku1.Equals(sku2));
            }
        }

        [Test]
        public void EqualsToNullSku()
        {
            Sku sku1 = new Sku(null, null, null, null, null);
            Sku sku2 = null;
            Assert.IsFalse(sku1.Equals(sku2));
        }

        [Test]
        public void EqualsToObject()
        {
            Sku sku1 = new Sku(null, null, null, null, null);
            object sku2 = "random";
            Assert.IsFalse(sku1.Equals(sku2));
        }

        [Test]
        public void EqualsToSameSkus()
        {
            Sku sku1 = new Sku(null, null, null, null, null);
            Sku sku2 = sku1;
            Assert.IsTrue(sku1.Equals(sku2));
        }

        [Test]
        public void SerializationTest()
        {
            string expected = "{\"properties\":{\"name\":\"NameForSku\",\"tier\":\"TierForSku\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\",\"model\":\"ModelForSku\",\"capacity\":123456789}}";
            Sku sku = new("NameForSku", "TierForSku", "SizeForSku", "FamilyForSku", "ModelForSku", 123456789);
            var json = JsonHelper.SerializePropertiesToString(sku);
            Assert.AreEqual(expected, json);
        }

        [Test]
        public void InvalidSerializationTest()
        {
            Sku sku = new(null, null, null, null, null);
            var json = JsonHelper.SerializePropertiesToString(sku);
            Assert.IsTrue(json.Equals("{\"properties\":{}}"));
        }

        [Test]
        public void DeserializationTest()
        {
            string json = "{\"name\":\"NameForSku\",\"tier\":\"TierForSku\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\",\"capacity\":123456789}";
            JsonElement element = JsonDocument.Parse(json).RootElement;
            Sku sku = Sku.DeserializeSku(element);
            Assert.IsTrue(sku.Name.Equals("NameForSku"));
            Assert.IsTrue(sku.Capacity == 123456789);
        }

        [Test]
        public void InvalidDeserializationTest()
        {
            string json = "{\"name\":\"NameForSku\",\"notTier\":\"TierForSku\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\"}";
            JsonElement element = JsonDocument.Parse(json).RootElement;
            Sku sku = Sku.DeserializeSku(element);
            Assert.IsTrue(sku.Tier == null);
            Assert.IsTrue(sku.Capacity == null);
        }
    }
}
