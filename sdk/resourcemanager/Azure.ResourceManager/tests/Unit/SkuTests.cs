using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class SkuTests
    {
        private static readonly ModelReaderWriterOptions _wireOptions = new("W");

        [TestCase(true, "name", "name")]
        [TestCase(true, "Name", "name")]
        [TestCase(true, null, null)]
        [TestCase(false, "name", null)]
        [TestCase(false, null, "name")]
        [TestCase(true, "${?/>._`", "${?/>._`")]
        [TestCase(false, "${?/>._`", "")]
        public void EqualsToName(bool expected, string name1, string name2)
        {
            ArmSku sku1 = new ArmSku(name1, null, null, null, null);
            ArmSku sku2 = new ArmSku(name2, null, null, null, null);
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
            ArmSku sku1 = new ArmSku(name1, null, null, family1, null);
            ArmSku sku2 = new ArmSku(name2, null, null, family2, null);
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
            ArmSku sku1 = new ArmSku(name1, null, null, family1, null);
            ArmSku sku2 = new ArmSku(name2, null, null, family2, null);
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
            ArmSku sku1 = new ArmSku(null, null, null, family1, null);
            ArmSku sku2 = new ArmSku(null, null, null, family2, null);
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
            ArmSku sku1 = new ArmSku(null, null, size1, null, null);
            ArmSku sku2 = new ArmSku(null, null, size2, null, null);
            Assert.AreEqual(expected, sku1.Equals(sku2), "Skus did not match expected equals");
            Assert.AreEqual(expected, sku1.GetHashCode() == sku2.GetHashCode(), $"Hashcodes comparison was expect {expected} but was {!expected}, ({sku1.GetHashCode()}, {sku2.GetHashCode()})");
        }

        [TestCase(true, ArmSkuTier.Basic, ArmSkuTier.Basic)]
        [TestCase(true, null, null)]
        [TestCase(false, ArmSkuTier.Basic, null)]
        [TestCase(false, null, ArmSkuTier.Basic)]
        public void EqualsToTier(bool expected, ArmSkuTier tier1, ArmSkuTier tier2)
        {
            ArmSku sku1 = new ArmSku(null, tier1, null, null, null);
            ArmSku sku2 = new ArmSku(null, tier2, null, null, null);
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
            ArmSku sku1 = capacity1 == null ? new ArmSku(null, null, null, null, null) : new ArmSku(null, null, null, null, capacity1);
            ArmSku sku2 = capacity2 == null ? new ArmSku(null, null, null, null, null) : new ArmSku(null, null, null, null, capacity2);
            Assert.AreEqual(expected, sku1.Equals(sku2), "Skus did not match expected equals");
            Assert.AreEqual(expected, sku1.GetHashCode() == sku2.GetHashCode(), $"Hashcodes comparison was expect {expected} but was {!expected}, ({sku1.GetHashCode()}, {sku2.GetHashCode()})");
        }

        [Test]
        public void EqualsToNullSku()
        {
            ArmSku sku1 = new ArmSku(null, null, null, null, null);
            ArmSku sku2 = null;
            Assert.IsFalse(sku1.Equals(sku2));
        }

        [Test]
        public void EqualsToObject()
        {
            ArmSku sku1 = new ArmSku(null, null, null, null, null);
            object sku2 = new ArmSku("SkuName", null, null, null, null);
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
            ArmSku sku1 = new ArmSku(null, null, null, null, null);
            ArmSku sku2 = sku1;
            Assert.IsTrue(sku1.Equals(sku2));
        }

        [Test]
        public void SerializationTest()
        {
            const string expected = "{\"name\":\"NameForSku\",\"tier\":\"Basic\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\",\"capacity\":123456789}";
            ArmSku sku = new("NameForSku", ArmSkuTier.Basic, "SizeForSku", "FamilyForSku", 123456789);
            var binary = ModelReaderWriter.Write(sku, _wireOptions);
            Assert.AreEqual(expected, binary.ToString());
        }

        [Test]
        public void InvalidSerializationTest()
        {
            const string expected = "{\"name\":null}";
            ArmSku sku = new(null, null, null, null, null);
            var binary = ModelReaderWriter.Write(sku, _wireOptions);
            Assert.AreEqual(expected, binary.ToString());
        }

        [Test]
        public void DeserializationTest()
        {
            const string json = "{\"name\":\"NameForSku\",\"tier\":\"Basic\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\",\"capacity\":123456789}";
            using var jsonDocument = JsonDocument.Parse(json);
            JsonElement element = jsonDocument.RootElement;
            ArmSku sku = ArmSku.DeserializeArmSku(element);
            Assert.AreEqual("NameForSku", sku.Name);
            Assert.AreEqual(123456789, sku.Capacity);
        }

        [Test]
        public void InvalidDeserializationTest()
        {
            const string json = "{\"name\":\"NameForSku\",\"notTier\":\"Basic\",\"size\":\"SizeForSku\",\"family\":\"FamilyForSku\"}";
            using var jsonDocument = JsonDocument.Parse(json);
            JsonElement element = jsonDocument.RootElement;
            ArmSku sku = ArmSku.DeserializeArmSku(element);
            Assert.IsNull(sku.Tier);
            Assert.IsNull(sku.Capacity);
        }
    }
}
