// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Data.SchemaRegistry.Tests
{
    public class SchemaRegistrySchemaTests
    {
        private const string SchemaContent = "{\"type\" : \"record\",\"namespace\" : \"TestSchema\",\"name\" : \"Employee\",\"fields\" : [{ \"name\" : \"Name\" , \"type\" : \"string\" },{ \"name\" : \"Age\", \"type\" : \"int\" }]}";

        [Test]
        public void CanCreateFromModelFactory()
        {
            var schema = SchemaRegistryModelFactory.SchemaRegistrySchema(
                SchemaRegistryModelFactory.SchemaProperties(SchemaFormat.Avro, "schemaId", "groupName", "name"),
                SchemaContent);
            Assert.That(schema.Properties.Format, Is.EqualTo(SchemaFormat.Avro));
            Assert.That(schema.Properties.Id, Is.EqualTo("schemaId"));
            Assert.That(schema.Properties.GroupName, Is.EqualTo("groupName"));
            Assert.That(schema.Properties.Name, Is.EqualTo("name"));
            Assert.That(schema.Definition, Is.EqualTo(SchemaContent));
        }
    }
}
