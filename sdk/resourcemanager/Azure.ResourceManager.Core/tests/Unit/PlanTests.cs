using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
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
            if (expected)
            {
                Assert.IsTrue(plan1.Equals(plan2));
            }
            else
            {
                Assert.IsFalse(plan1.Equals(plan2));
            }
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
            if (expected)
            {
                Assert.IsTrue(plan1.Equals(plan2));
            }
            else
            {
                Assert.IsFalse(plan1.Equals(plan2));
            }
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
            if (expected)
            {
                Assert.IsTrue(plan1.Equals(plan2));
            }
            else
            {
                Assert.IsFalse(plan1.Equals(plan2));
            }
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
            if (expected)
            {
                Assert.IsTrue(plan1.Equals(plan2));
            }
            else
            {
                Assert.IsFalse(plan1.Equals(plan2));
            }
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
            if (expected)
            {
                Assert.IsTrue(plan1.Equals(plan2));
            }
            else
            {
                Assert.IsFalse(plan1.Equals(plan2));
            }
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
            object plan2 = "random";
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
            var stream = new MemoryStream();
            Utf8JsonWriter writer = new(stream, new JsonWriterOptions());
            writer.WriteStartObject();
            writer.WritePropertyName("properties");
            writer.WriteObjectValue(plan);
            writer.WriteEndObject();
            writer.Flush();
            string json = Encoding.UTF8.GetString(stream.ToArray());
            Assert.IsTrue(expected.Equals(json));
        }

        [Test]
        public void InvalidSerializationTest()
        {
            Plan plan = new(null, null, null, null, null);
            var stream = new MemoryStream();
            Utf8JsonWriter writer = new(stream, new JsonWriterOptions());
            writer.WriteStartObject();
            writer.WritePropertyName("properties");
            writer.WriteObjectValue(plan);
            writer.WriteEndObject();
            writer.Flush();
            string json = Encoding.UTF8.GetString(stream.ToArray());
            Assert.IsTrue(json.Equals("{\"properties\":{}}"));
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
    }
}
