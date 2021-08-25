using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    class PlanTests
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
            Plan plan1 = new Plan(name1, null, null, null, null);
            Plan plan2 = new Plan(name2, null, null, null, null);
            Assert.AreEqual(expected, plan1.CompareTo(plan2));
        }

        [TestCase(0, "product", "product")]
        [TestCase(0, "Product", "product")]
        [TestCase(0, null, null)]
        [TestCase(1, "product", null)]
        [TestCase(-1, null, "product")]
        [TestCase(0, "${?/>._`", "${?/>._`")]
        [TestCase(1, "${?/>._`", "")]
        public void CompareToProduct(int expected, string product1, string product2)
        {
            Plan plan1 = new Plan(null, null, product1, null, null);
            Plan plan2 = new Plan(null, null, product2, null, null);
            Assert.AreEqual(expected, plan1.CompareTo(plan2));
        }

        [TestCase(0, "promotionCode", "promotionCode")]
        [TestCase(0, "PromotionCode", "promotionCode")]
        [TestCase(0, null, null)]
        [TestCase(1, "promotionCode", null)]
        [TestCase(-1, null, "promotionCode")]
        [TestCase(0, "${?/>._`", "${?/>._`")]
        [TestCase(1, "${?/>._`", "")]
        public void CompareToPromotionCode(int expected, string promotionCode1, string promotionCode2)
        {
            Plan plan1 = new Plan(null, null, null, promotionCode1, null);
            Plan plan2 = new Plan(null, null, null, promotionCode2, null);
            Assert.AreEqual(expected, plan1.CompareTo(plan2));
        }

        [TestCase(0, "publisher", "publisher")]
        [TestCase(0, "Publisher", "publisher")]
        [TestCase(0, null, null)]
        [TestCase(1, "publisher", null)]
        [TestCase(-1, null, "publisher")]
        [TestCase(0, "${?/>._`", "${?/>._`")]
        [TestCase(1, "${?/>._`", "")]
        public void CompareToPublisher(int expected, string publisher1, string publisher2)
        {
            Plan plan1 = new Plan(null, publisher1, null, null, null);
            Plan plan2 = new Plan(null, publisher2, null, null, null);
            Assert.AreEqual(expected, plan1.CompareTo(plan2));
        }

        [TestCase(0, "version", "version")]
        [TestCase(0, "Version", "version")]
        [TestCase(0, null, null)]
        [TestCase(1, "version", null)]
        [TestCase(-1, null, "version")]
        [TestCase(0, "${?/>._`", "${?/>._`")]
        [TestCase(1, "${?/>._`", "")]
        public void CompareToVersion(int expected, string version1, string version2)
        {
            Plan plan1 = new Plan(null, null, null, null, version1);
            Plan plan2 = new Plan(null, null, null, null, version2);
            Assert.AreEqual(expected, plan1.CompareTo(plan2));
        }

        [Test]
        public void CompareToNullPlan()
        {
            Plan plan1 = new Plan(null, null, null, null, null);
            Plan plan2 = null;
            Assert.AreEqual(1, plan1.CompareTo(plan2));
        }

        [Test]
        public void CompareToSamePlans()
        {
            Plan plan1 = new Plan(null, null, null, null, null);
            Plan plan2 = plan1;
            Assert.AreEqual(0, plan1.CompareTo(plan2));
        }

        [TestCase(1, "Nameb", "namea", "versiona", "Versionb")]
        [TestCase(1, "Nameb", "namea", "versiona", "versiona")]
        [TestCase(-1, "namea", "Nameb", "Versionb", "versiona")]
        public void CompareToMore(int expected, string name1, string name2, string version1, string version2)
        {
            Plan plan1 = new Plan(name1, null, null, null, version1);
            Plan plan2 = new Plan(name2, null, null, null, version2);
            Assert.AreEqual(expected, plan1.CompareTo(plan2));
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
            Plan plan1 = new Plan(name1, null, null, null, null);
            Plan plan2 = new Plan(name2, null, null, null, null);
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
            Plan plan1 = new Plan(null, null, product1, null, null);
            Plan plan2 = new Plan(null, null, product2, null, null);
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
            Plan plan1 = new Plan(null, null, null, promotionCode1, null);
            Plan plan2 = new Plan(null, null, null, promotionCode2, null);
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
            Plan plan1 = new Plan(null, publisher1, null, null, null);
            Plan plan2 = new Plan(null, publisher2, null, null, null);
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
            Plan plan1 = new Plan(null, null, null, null, version1);
            Plan plan2 = new Plan(null, null, null, null, version2);
            Assert.AreEqual(expected, plan1.Equals(plan2), "Plans did not match expected equality");
            Assert.AreEqual(expected, plan1.GetHashCode() == plan2.GetHashCode(), $"Hashcodes comparison was expect {expected} but was {!expected}, ({plan1.GetHashCode()}, {plan2.GetHashCode()})");
        }

        [Test]
        public void EqualsToNullPlan()
        {
            Plan plan1 = new Plan(null, null, null, null, null);
            Plan plan2 = null;
            Assert.IsFalse(plan1.Equals(plan2));
        }

        [Test]
        public void EqualsToObject()
        {
            Plan plan1 = new Plan(null, null, null, null, null);
            object stringPlan = "random";
            Assert.IsFalse(plan1.Equals(stringPlan));

            object nullObject = null;
            Assert.IsFalse(plan1.Equals(nullObject));

            object samePlan = plan1;
            Assert.IsTrue(plan1.Equals(samePlan));

            object plan2 = new Plan("Plan2", null, null, null, null);
            Assert.IsFalse(plan1.Equals(plan2));
        }

        [Test]
        public void EqualsToSamePlans()
        {
            Plan plan1 = new Plan(null, null, null, null, null);
            Plan plan2 = plan1;
            Assert.IsTrue(plan1.Equals(plan2));
        }

        [Test]
        public void SerializationTest()
        {
            string expected = "{\"properties\":{\"name\":\"NameForPlan\",\"publisher\":\"PublisherForPlan\",\"product\":\"ProductForPlan\",\"promotionCode\":\"PromotionCodeForPlan\",\"version\":\"VersionForPlan\"}}";
            Plan plan = new("NameForPlan", "PublisherForPlan", "ProductForPlan", "PromotionCodeForPlan", "VersionForPlan");
            var json = JsonHelper.SerializePropertiesToString(plan);
            Assert.IsTrue(expected.Equals(json));
        }

        [Test]
        public void InvalidSerializationTest()
        {
            Plan plan = new(null, null, null, null, null);
            var json = JsonHelper.SerializePropertiesToString(plan);
            Assert.AreEqual("{\"properties\":{\"name\":null,\"publisher\":null,\"product\":null}}", json);
        }

        [Test]
        public void DeserializationTest()
        {
            string json = "{\"name\":\"NameForPlan\",\"publisher\":\"PublisherForPlan\",\"product\":\"ProductForPlan\",\"promotionCode\":\"PromotionCodeForPlan\",\"version\":\"VersionForPlan\"}";
            JsonElement element = JsonDocument.Parse(json).RootElement;
            Plan plan = Plan.DeserializePlan(element);
            Assert.IsTrue(plan.Name.Equals("NameForPlan"));
            Assert.IsTrue(plan.PromotionCode.Equals("PromotionCodeForPlan"));
        }

        [Test]
        public void InvalidDeserializationTest()
        {
            string json = "{\"name\":\"NameForPlan\",\"notPublisher\":\"PublisherForPlan\",\"product\":\"ProductForPlan\",\"version\":\"VersionForPlan\"}";
            JsonElement element = JsonDocument.Parse(json).RootElement;
            Plan plan = Plan.DeserializePlan(element);
            Assert.IsTrue(plan.Publisher == null);
            Assert.IsTrue(plan.PromotionCode == null);
        }

        [Test]
        public void LessThanNull()
        {
            Plan plan = new Plan("PlanName", null, null, "PlanPromoCode", null);
            Assert.IsTrue(null < plan);
            Assert.IsFalse(plan < null);
        }

        [Test]
        public void LessThanOrEqualNull()
        {
            Plan plan = new Plan("PlanName", null, null, "PlanPromoCode", null);
            Assert.IsTrue(null <= plan);
            Assert.IsFalse(plan <= null);
        }

        [Test]
        public void GreaterThanNull()
        {
            Plan plan = new Plan("PlanName", null, null, "PlanPromoCode", null);
            Assert.IsFalse(null > plan);
            Assert.IsTrue(plan > null);
        }

        [Test]
        public void GreaterThanOrEqualNull()
        {
            Plan plan = new Plan("PlanName", null, null, "PlanPromoCode", null);
            Assert.IsFalse(null >= plan);
            Assert.IsTrue(plan >= null);
        }

        [TestCase(false, "Nameb", "namea", "familya", "Familyb")]
        [TestCase(false, "Nameb", "namea", "familya", "familya")]
        [TestCase(false, "namea", "namea", "familya", "familya")]
        [TestCase(true, "namea", "Nameb", "Familyb", "familya")]
        public void LessThanOperator(bool expected, string name1, string name2, string promo1, string promo2)
        {
            Plan plan1 = new Plan(name1, null, null, promo1, null);
            Plan plan2 = new Plan(name2, null, null, promo2, null);
            Assert.AreEqual(expected, plan1 < plan2);
        }

        [TestCase(false, "Nameb", "namea", "familya", "Familyb")]
        [TestCase(false, "Nameb", "namea", "familya", "familya")]
        [TestCase(true, "namea", "namea", "familya", "familya")]
        [TestCase(true, "namea", "Nameb", "Familyb", "familya")]
        public void LessThanOrEqualOperator(bool expected, string name1, string name2, string promo1, string promo2)
        {
            Plan plan1 = new Plan(name1, null, null, promo1, null);
            Plan plan2 = new Plan(name2, null, null, promo2, null);
            Assert.AreEqual(expected, plan1 <= plan2);
        }

        [TestCase(true, "Nameb", "namea", "familya", "Familyb")]
        [TestCase(true, "Nameb", "namea", "familya", "familya")]
        [TestCase(false, "namea", "namea", "familya", "familya")]
        [TestCase(false, "namea", "Nameb", "Familyb", "familya")]
        public void GreaterThanOperator(bool expected, string name1, string name2, string promo1, string promo2)
        {
            Plan plan1 = new Plan(name1, null, null, promo1, null);
            Plan plan2 = new Plan(name2, null, null, promo2, null);
            Assert.AreEqual(expected, plan1 > plan2);
        }

        [TestCase(true, "Nameb", "namea", "familya", "Familyb")]
        [TestCase(true, "Nameb", "namea", "familya", "familya")]
        [TestCase(true, "namea", "namea", "familya", "familya")]
        [TestCase(false, "namea", "Nameb", "Familyb", "familya")]
        public void GreaterThanOrEqualOperator(bool expected, string name1, string name2, string promo1, string promo2)
        {
            Plan plan1 = new Plan(name1, null, null, promo1, null);
            Plan plan2 = new Plan(name2, null, null, promo2, null);
            Assert.AreEqual(expected, plan1 >= plan2);
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
            Plan plan1 = new Plan(name1, null, null, promo1, null);
            Plan plan2 = new Plan(name2, null, null, promo2, null);
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
            Plan plan1 = new Plan(name1, null, null, promo1, null);
            Plan plan2 = new Plan(name2, null, null, promo2, null);
            Assert.AreEqual(expected, plan1 != plan2);
        }

        [Test]
        public void EqualOperatorNull()
        {
            Plan plan1 = new Plan("PlanName", null, null, "PlanPromo", null);
            Assert.IsFalse(plan1 == null);
            Assert.IsFalse(null == plan1);
        }
    }
}
