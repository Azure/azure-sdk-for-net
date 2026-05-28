// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Data.SchemaRegistry.Tests
{
    public class SchemaPropertiesTest
    {
        [Test]
        public void CanCreateFromCtor()
        {
            var properties = new SchemaProperties(SchemaFormat.Avro, "schemaId", "groupName", "name", 1);
            Assert.AreEqual(SchemaFormat.Avro, properties.Format);
            Assert.AreEqual("schemaId", properties.Id);
            Assert.AreEqual("groupName", properties.GroupName);
            Assert.AreEqual("name", properties.Name);
        }

        [Test]
        public void CanCreateFromFactory()
        {
            var properties = SchemaRegistryModelFactory.SchemaProperties(SchemaFormat.Avro, "schemaId");
            Assert.AreEqual(SchemaFormat.Avro, properties.Format);
            Assert.AreEqual("schemaId", properties.Id);
        }

        [Test]
        public void CanCreateFromFactoryCurrent()
        {
            var properties = SchemaRegistryModelFactory.SchemaProperties(SchemaFormat.Avro, "schemaId", "groupName", "name", 1);
            Assert.AreEqual(SchemaFormat.Avro, properties.Format);
            Assert.AreEqual("schemaId", properties.Id);
            Assert.AreEqual("groupName", properties.GroupName);
            Assert.AreEqual("name", properties.Name);
            Assert.AreEqual(1, properties.Version);
        }
    }
}
