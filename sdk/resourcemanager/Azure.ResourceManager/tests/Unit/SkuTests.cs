using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    class SkuTests
    {
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
            Assert.AreEqual(expected, sku1.Equals(sku2), "Skus did not match expected equals");
            Assert.AreEqual(expected, sku1.GetHashCode() == sku2.GetHashCode(), $"Hashcodes comparison was expect {expected} but was {!expected}, ({sku1.GetHashCode()}, {sku2.GetHashCode()})");
        }

        [TestCase(true, "name", "name", "family", "family")]
        [TestCase(true, "Name", "name", "Family", "family")]
        [TestCase(false, "name", "name1", "family", "family")]
        [TestCase(false, "Name", "name", "Family", "family1")]
        [TestCase(true, null, null, null, null)]
        [TestCase(false, "name", null, "family", null)]
        [TestCase(false, null, "name", null, "family")]
        [TestCase(true, "${?/>._`", "${?/>._`", "${?/>._`", "${?/>._`")]
        [TestCase(false, "${?/>._`", "", "${?/>._`", "")]
        public void EqualsToOperator(bool expected, string name1, string name2, string family1, string family2)
        {
            Sku sku1 = new Sku(name1, null, null, family1, null);
            Sku sku2 = new Sku(name2, null, null, family2, null);
            Assert.AreEqual(expected, sku1 == sku2);
        }

        [TestCase(false, "name", "name", "family", "family")]
        [TestCase(false, "Name", "name", "Family", "family")]
        [TestCase(true, "name", "name1", "family", "family")]
        [TestCase(true, "Name", "name", "Family", "family1")]
        [TestCase(false, null, null, null, null)]
        [TestCase(true, "name", null, "family", null)]
        [TestCase(true, null, "name", null, "family")]
        [TestCase(false, "${?/>._`", "${?/>._`", "${?/>._`", "${?/>._`")]
        [TestCase(true, "${?/>._`", "", "${?/>._`", "")]
        public void NotEqualsToOperator(bool expected, string name1, string name2, string family1, string family2)
        {
            Sku sku1 = new Sku(name1, null, null, family1, null);
            Sku sku2 = new Sku(name2, null, null, family2, null);
            Assert.AreEqual(expected, sku1 != sku2);
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
            Assert.AreEqual(expected, sku1.Equals(sku2), "Skus did not match expected equals");
            Assert.AreEqual(expected, sku1.GetHashCode() == sku2.GetHashCode(), $"Hashcodes comparison was expect {expected} but was {!expected}, ({sku1.GetHashCode()}, {sku2.GetHashCode()})");
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
            Assert.AreEqual(expected, sku1.Equals(sku2), "Skus did not match expected equals");
            Assert.AreEqual(expected, sku1.GetHashCode() == sku2.GetHashCode(), $"Hashcodes comparison was expect {expected} but was {!expected}, ({sku1.GetHashCode()}, {sku2.GetHashCode()})");
        }

        [TestCase(true, SkuTier.Basic, SkuTier.Basic)]
        [TestCase(true, null, null)]
        [TestCase(false, SkuTier.Basic, null)]
        [TestCase(false, null, SkuTier.Basic)]
        public void EqualsToTier(bool expected, SkuTier tier1, SkuTier tier2)
        {
            Sku sku1 = new Sku(null, tier1, null, null, null);
            Sku sku2 = new Sku(null, tier2, null, null, null);
            Assert.AreEqual(expected, sku1.Equals(sku2), "Skus did not match expected equals");
            Assert.AreEqual(expected, sku1.GetHashCode() == sku2.GetHashCode(), $"Hashcodes comparison was expect {expected} but was {!expected}, ({sku1.GetHashCode()}, {sku2.GetHashCode()})");
        }

        [TestCase(true, 1, 1)]
        [TestCase(false, 1, 0)]
        [TestCase(true, null, null)]
        [TestCase(false, 1, null)]
        [TestCase(false, null, 1)]
        public void EqualsToCapacity(bool expected, int? capacity1, int? capacity2)
        {
            Sku sku1 = capacity1 == null ? new Sku(null, null, null, null, null) : new Sku(null, null, null, null, capacity1);
            Sku sku2 = capacity2 == null ? new Sku(null, null, null, null, null) : new Sku(null, null, null, null, capacity2);
            Assert.AreEqual(expected, sku1.Equals(sku2), "Skus did not match expected equals");
            Assert.AreEqual(expected, sku1.GetHashCode() == sku2.GetHashCode(), $"Hashcodes comparison was expect {expected} but was {!expected}, ({sku1.GetHashCode()}, {sku2.GetHashCode()})");
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
            object sku2 = new Sku("SkuName", null, null, null, null);
            object stringSku = "random";
            Assert.IsFalse(sku1.Equals(stringSku));

            object nullSku = null;
            Assert.IsFalse(sku1.Equals(nullSku));

            object sameSku = sku1;
            Assert.IsTrue(sku1.Equals(sameSku));

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
            string expected = "{\"properties\":{\"name\":\"NameForSku\",\"tier\":\"Basic\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\",\"capacity\":123456789}}";
            Sku sku = new("NameForSku", SkuTier.Basic, "SizeForSku", "FamilyForSku", 123456789);
            var json = JsonHelper.SerializePropertiesToString(sku);
            Assert.AreEqual(expected, json);
        }

        [Test]
        public void InvalidSerializationTest()
        {
            Sku sku = new(null, null, null, null, null);
            var json = JsonHelper.SerializePropertiesToString(sku);
            Assert.AreEqual("{\"properties\":{\"name\":null}}", json);
        }

        [Test]
        public void DeserializationTest()
        {
            string json = "{\"name\":\"NameForSku\",\"tier\":\"Basic\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\",\"capacity\":123456789}";
            JsonElement element = JsonDocument.Parse(json).RootElement;
            Sku sku = Sku.DeserializeSku(element);
            Assert.IsTrue(sku.Name.Equals("NameForSku"));
            Assert.IsTrue(sku.Capacity == 123456789);
        }

        [Test]
        public void InvalidDeserializationTest()
        {
            string json = "{\"name\":\"NameForSku\",\"notTier\":\"Basic\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\"}";
            JsonElement element = JsonDocument.Parse(json).RootElement;
            Sku sku = Sku.DeserializeSku(element);
            Assert.IsTrue(sku.Tier == null);
            Assert.IsTrue(sku.Capacity == null);
        }
    }
}
