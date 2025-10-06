using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class PlanTests
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
            ArmPlan plan1 = new ArmPlan(name1, null, null, null, null);
            ArmPlan plan2 = new ArmPlan(name2, null, null, null, null);
            Assert.AreEqual(expected, plan1.Equals(plan2), "Plans did not match expected equality");
            Assert.AreEqual(expected, plan1.GetHashCode() == plan2.GetHashCode(), $"Hashcodes comparison was expect {expected} but was {!expected}, ({plan1.GetHashCode()}, {plan2.GetHashCode()})");
        }

        [TestCase(true, "product", "product")]
        [TestCase(true, "Product", "product")]
        [TestCase(true, null, null)]
        [TestCase(false, "product", null)]
        [TestCase(false, null, "product")]
        [TestCase(true, "${?/>._`", "${?/>._`")]
        [TestCase(false, "${?/>._`", "")]
        public void EqualsToProduct(bool expected, string product1, string product2)
        {
            ArmPlan plan1 = new ArmPlan(null, null, product1, null, null);
            ArmPlan plan2 = new ArmPlan(null, null, product2, null, null);
            Assert.AreEqual(expected, plan1.Equals(plan2), "Plans did not match expected equality");
            Assert.AreEqual(expected, plan1.GetHashCode() == plan2.GetHashCode(), $"Hashcodes comparison was expect {expected} but was {!expected}, ({plan1.GetHashCode()}, {plan2.GetHashCode()})");
        }

        [TestCase(true, "promotionCode", "promotionCode")]
        [TestCase(true, "PromotionCode", "promotionCode")]
        [TestCase(true, null, null)]
        [TestCase(false, "promotionCode", null)]
        [TestCase(false, null, "promotionCode")]
        [TestCase(true, "${?/>._`", "${?/>._`")]
        [TestCase(false, "${?/>._`", "")]
        public void EqualsToPromotionCode(bool expected, string promotionCode1, string promotionCode2)
        {
            ArmPlan plan1 = new ArmPlan(null, null, null, promotionCode1, null);
            ArmPlan plan2 = new ArmPlan(null, null, null, promotionCode2, null);
            Assert.AreEqual(expected, plan1.Equals(plan2), "Plans did not match expected equality");
            Assert.AreEqual(expected, plan1.GetHashCode() == plan2.GetHashCode(), $"Hashcodes comparison was expect {expected} but was {!expected}, ({plan1.GetHashCode()}, {plan2.GetHashCode()})");
        }

        [TestCase(true, "publisher", "publisher")]
        [TestCase(true, "Publisher", "publisher")]
        [TestCase(true, null, null)]
        [TestCase(false, "publisher", null)]
        [TestCase(false, null, "publisher")]
        [TestCase(true, "${?/>._`", "${?/>._`")]
        [TestCase(false, "${?/>._`", "")]
        public void EqualsToPublisher(bool expected, string publisher1, string publisher2)
        {
            ArmPlan plan1 = new ArmPlan(null, publisher1, null, null, null);
            ArmPlan plan2 = new ArmPlan(null, publisher2, null, null, null);
            Assert.AreEqual(expected, plan1.Equals(plan2), "Plans did not match expected equality");
            Assert.AreEqual(expected, plan1.GetHashCode() == plan2.GetHashCode(), $"Hashcodes comparison was expect {expected} but was {!expected}, ({plan1.GetHashCode()}, {plan2.GetHashCode()})");
        }

        [TestCase(true, "version", "version")]
        [TestCase(true, "Version", "version")]
        [TestCase(true, null, null)]
        [TestCase(false, "version", null)]
        [TestCase(false, null, "version")]
        [TestCase(true, "${?/>._`", "${?/>._`")]
        [TestCase(false, "${?/>._`", "")]
        public void EqualsToVersion(bool expected, string version1, string version2)
        {
            ArmPlan plan1 = new ArmPlan(null, null, null, null, version1);
            ArmPlan plan2 = new ArmPlan(null, null, null, null, version2);
            Assert.AreEqual(expected, plan1.Equals(plan2), "Plans did not match expected equality");
            Assert.AreEqual(expected, plan1.GetHashCode() == plan2.GetHashCode(), $"Hashcodes comparison was expect {expected} but was {!expected}, ({plan1.GetHashCode()}, {plan2.GetHashCode()})");
        }

        [Test]
        public void EqualsToNullPlan()
        {
            ArmPlan plan1 = new ArmPlan(null, null, null, null, null);
            ArmPlan plan2 = null;
            Assert.IsFalse(plan1.Equals(plan2));
        }

        [Test]
        public void EqualsToObject()
        {
            ArmPlan plan1 = new ArmPlan(null, null, null, null, null);
            object stringPlan = "random";
            Assert.IsFalse(plan1.Equals(stringPlan));

            object nullObject = null;
            Assert.IsFalse(plan1.Equals(nullObject));

            object samePlan = plan1;
            Assert.IsTrue(plan1.Equals(samePlan));

            object plan2 = new ArmPlan("Plan2", null, null, null, null);
            Assert.IsFalse(plan1.Equals(plan2));
        }

        [Test]
        public void EqualsToSamePlans()
        {
            ArmPlan plan1 = new ArmPlan(null, null, null, null, null);
            ArmPlan plan2 = plan1;
            Assert.IsTrue(plan1.Equals(plan2));
        }

        [Test]
        public void SerializationTest()
        {
            const string expected = "{\"name\":\"NameForPlan\",\"publisher\":\"PublisherForPlan\",\"product\":\"ProductForPlan\",\"promotionCode\":\"PromotionCodeForPlan\",\"version\":\"VersionForPlan\"}";
            ArmPlan plan = new("NameForPlan", "PublisherForPlan", "ProductForPlan", "PromotionCodeForPlan", "VersionForPlan");
            var binary = ModelReaderWriter.Write(plan, _wireOptions);
            Assert.AreEqual(expected, binary.ToString());
        }

        [Test]
        public void InvalidSerializationTest()
        {
            const string expected = "{\"name\":null,\"publisher\":null,\"product\":null}";
            ArmPlan plan = new(null, null, null, null, null);
            var binary = ModelReaderWriter.Write(plan, _wireOptions);
            Assert.AreEqual(expected, binary.ToString());
        }

        [Test]
        public void DeserializationTest()
        {
            const string json = "{\"name\":\"NameForPlan\",\"publisher\":\"PublisherForPlan\",\"product\":\"ProductForPlan\",\"promotionCode\":\"PromotionCodeForPlan\",\"version\":\"VersionForPlan\"}";
            using var jsonDocument = JsonDocument.Parse(json);
            JsonElement element = jsonDocument.RootElement;
            ArmPlan plan = ArmPlan.DeserializeArmPlan(element);
            Assert.IsTrue(plan.Name.Equals("NameForPlan"));
            Assert.IsTrue(plan.PromotionCode.Equals("PromotionCodeForPlan"));
        }

        [Test]
        public void InvalidDeserializationTest()
        {
            const string json = "{\"name\":\"NameForPlan\",\"notPublisher\":\"PublisherForPlan\",\"product\":\"ProductForPlan\",\"version\":\"VersionForPlan\"}";
            using var jsonDocument = JsonDocument.Parse(json);
            JsonElement element = jsonDocument.RootElement;
            ArmPlan plan = ArmPlan.DeserializeArmPlan(element);
            Assert.IsTrue(plan.Publisher == null);
            Assert.IsTrue(plan.PromotionCode == null);
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
        public void EqualsToOperator(bool expected, string name1, string name2, string promo1, string promo2)
        {
            ArmPlan plan1 = new ArmPlan(name1, null, null, promo1, null);
            ArmPlan plan2 = new ArmPlan(name2, null, null, promo2, null);
            Assert.AreEqual(expected, plan1 == plan2);
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
        public void NotEqualsToOperator(bool expected, string name1, string name2, string promo1, string promo2)
        {
            ArmPlan plan1 = new ArmPlan(name1, null, null, promo1, null);
            ArmPlan plan2 = new ArmPlan(name2, null, null, promo2, null);
            Assert.AreEqual(expected, plan1 != plan2);
        }

        [Test]
        public void EqualOperatorNull()
        {
            ArmPlan plan1 = new ArmPlan("PlanName", null, null, "PlanPromo", null);
            Assert.IsFalse(plan1 == null);
            Assert.IsFalse(null == plan1);
        }
    }
}
