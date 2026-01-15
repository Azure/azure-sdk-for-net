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
            Assert.That(properties.Format, Is.EqualTo(SchemaFormat.Avro));
            Assert.That(properties.Id, Is.EqualTo("schemaId"));
            Assert.That(properties.GroupName, Is.EqualTo("groupName"));
            Assert.That(properties.Name, Is.EqualTo("name"));
        }

        [Test]
        public void CanCreateFromFactory()
        {
            var properties = SchemaRegistryModelFactory.SchemaProperties(SchemaFormat.Avro, "schemaId");
            Assert.That(properties.Format, Is.EqualTo(SchemaFormat.Avro));
            Assert.That(properties.Id, Is.EqualTo("schemaId"));
        }

        [Test]
        public void CanCreateFromFactoryCurrent()
        {
            var properties = SchemaRegistryModelFactory.SchemaProperties(SchemaFormat.Avro, "schemaId", "groupName", "name", 1);
            Assert.That(properties.Format, Is.EqualTo(SchemaFormat.Avro));
            Assert.That(properties.Id, Is.EqualTo("schemaId"));
            Assert.That(properties.GroupName, Is.EqualTo("groupName"));
            Assert.That(properties.Name, Is.EqualTo("name"));
            Assert.That(properties.Version, Is.EqualTo(1));
        }
    }
}
