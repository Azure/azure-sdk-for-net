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
            Assert.AreEqual(SchemaFormat.Avro, schema.Properties.Format);
            Assert.AreEqual("schemaId", schema.Properties.Id);
            Assert.AreEqual("groupName", schema.Properties.GroupName);
            Assert.AreEqual("name", schema.Properties.Name);
            Assert.AreEqual(SchemaContent, schema.Definition);
        }
    }
}
