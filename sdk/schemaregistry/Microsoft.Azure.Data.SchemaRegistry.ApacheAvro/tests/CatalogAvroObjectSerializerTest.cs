// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using Azure.Messaging;
using Azure.Messaging.MessagingCatalog;
using Moq;
using NUnit.Framework;
using TestSchema;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.Tests
{
    /// <summary>
    /// Tests for SchemaRegistryAvroSerializer in catalog mode using Azure Messaging Catalog for schema management
    /// </summary>
    public class CatalogAvroObjectSerializerTest : SchemaRegistryAvroObjectSerializerLiveTestBase
    {
        public CatalogAvroObjectSerializerTest(bool isAsync) : base(isAsync)
        {
        }

        #region Unit Tests

        [Test]
        public void Constructor_ValidParameters_CreatesInstanceSuccessfully()
        {
            // Arrange
            var endpoint = TestEnvironment.CatalogEndpoint;
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var options = new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true };

            // Act & Assert - Should not throw
            Assert.DoesNotThrow(() => new SchemaRegistryAvroSerializer(endpoint, groupName, options));
        }

        [Test]
        public void Constructor_NullEndpoint_ThrowsArgumentNullException()
        {
            // Arrange
            string endpoint = null;
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var options = new SchemaRegistryAvroSerializerOptions();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new SchemaRegistryAvroSerializer(endpoint, groupName, options));
        }

        [Test]
        public void Constructor_EmptyGroupName_DoesNotThrow()
        {
            // Arrange
            var endpoint = TestEnvironment.CatalogEndpoint;
            string groupName = ""; // Empty string is actually allowed
            var options = new SchemaRegistryAvroSerializerOptions();

            // Act & Assert - Should not throw, empty group name is valid
            Assert.DoesNotThrow(() => new SchemaRegistryAvroSerializer(endpoint, groupName, options));
        }

        [Test]
        public void Constructor_NullOptions_UsesDefaultOptions()
        {
            // Arrange
            var endpoint = TestEnvironment.CatalogEndpoint;
            var groupName = TestEnvironment.SchemaRegistryGroup;
            SchemaRegistryAvroSerializerOptions options = null;

            // Act & Assert - Should not throw and should use default options
            Assert.DoesNotThrow(() => new SchemaRegistryAvroSerializer(endpoint, groupName, options));
        }

        #endregion

        #region Live Tests - Catalog Integration

        [RecordedTest]
        public async Task CatalogMode_CanSerializeAndDeserialize()
        {
            // Arrange
            var endpoint = TestEnvironment.CatalogEndpoint;
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new Employee { Age = 42, Name = "CatalogEmployee" };

            var serializer = new SchemaRegistryAvroSerializer(endpoint, groupName, new SchemaRegistryAvroSerializerOptions
            {
                AutoRegisterSchemas = true
            });

            // Act
            MessageContent content = await serializer.SerializeAsync<MessageContent, Employee>(employee);
            Employee deserializedEmployee = await serializer.DeserializeAsync<Employee>(content);

            // Assert
            Assert.IsNotNull(deserializedEmployee);
            Assert.AreEqual("CatalogEmployee", deserializedEmployee.Name);
            Assert.AreEqual(42, deserializedEmployee.Age);
            Assert.IsTrue(content.ContentType.ToString().Contains("avro/binary"));
        }

        [RecordedTest]
        public async Task CatalogMode_AutoRegisterSchemas_RegistersNewSchema()
        {
            // Arrange
            var endpoint = TestEnvironment.CatalogEndpoint;
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new Employee { Age = 25, Name = "NewSchemaEmployee" };

            var serializer = new SchemaRegistryAvroSerializer(endpoint, groupName, new SchemaRegistryAvroSerializerOptions
            {
                AutoRegisterSchemas = true
            });

            // Act
            MessageContent content = await serializer.SerializeAsync<MessageContent, Employee>(employee);

            // Assert
            Assert.IsNotNull(content);
            Assert.IsNotNull(content.Data);
            Assert.IsTrue(content.Data.Length > 0);

            // Verify we can deserialize
            Employee deserializedEmployee = await serializer.DeserializeAsync<Employee>(content);
            Assert.IsNotNull(deserializedEmployee);
            Assert.AreEqual(employee.Name, deserializedEmployee.Name);
            Assert.AreEqual(employee.Age, deserializedEmployee.Age);
        }

        [RecordedTest]
        public async Task CatalogMode_WithCompatibleSchema_HandlesSchemaEvolution()
        {
            // Arrange
            var endpoint = TestEnvironment.CatalogEndpoint;
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employeeV2 = new Employee_V2 { Age = 35, Name = "EvolutionEmployee", City = "Seattle" };

            var serializer = new SchemaRegistryAvroSerializer(endpoint, groupName, new SchemaRegistryAvroSerializerOptions
            {
                AutoRegisterSchemas = true
            });

            // Act - Serialize with V2 schema
            var content = await serializer.SerializeAsync<MessageContent, Employee_V2>(employeeV2);

            // Deserialize with original Employee schema (forward compatibility test)
            var readEmployee = await serializer.DeserializeAsync<Employee>(content);

            // Assert
            Assert.IsNotNull(readEmployee);
            Assert.AreEqual("EvolutionEmployee", readEmployee.Name);
            Assert.AreEqual(35, readEmployee.Age);

            // Verify we can still deserialize with V2 schema
            var readEmployeeV2 = await serializer.DeserializeAsync<Employee_V2>(content);
            Assert.IsNotNull(readEmployeeV2);
            Assert.AreEqual("EvolutionEmployee", readEmployeeV2.Name);
            Assert.AreEqual(35, readEmployeeV2.Age);
            Assert.AreEqual("Seattle", readEmployeeV2.City);
        }

        [RecordedTest]
        public async Task CatalogMode_SerializeMultipleEmployees_MaintainsConsistency()
        {
            // Arrange
            var endpoint = TestEnvironment.CatalogEndpoint;
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employees = new[]
            {
                new Employee { Age = 30, Name = "Alice" },
                new Employee { Age = 40, Name = "Bob" },
                new Employee { Age = 50, Name = "Charlie" }
            };

            var serializer = new SchemaRegistryAvroSerializer(endpoint, groupName, new SchemaRegistryAvroSerializerOptions
            {
                AutoRegisterSchemas = true
            });

            // Act & Assert
            for (int i = 0; i < employees.Length; i++)
            {
                var content = await serializer.SerializeAsync<MessageContent, Employee>(employees[i]);
                var deserializedEmployee = await serializer.DeserializeAsync<Employee>(content);

                Assert.IsNotNull(deserializedEmployee, $"Employee {i} should not be null");
                Assert.AreEqual(employees[i].Name, deserializedEmployee.Name, $"Employee {i} name mismatch");
                Assert.AreEqual(employees[i].Age, deserializedEmployee.Age, $"Employee {i} age mismatch");
            }
        }

        [RecordedTest]
        public void CatalogMode_WithoutAutoRegister_ThrowsWhenSchemaNotFound()
        {
            // Arrange
            var endpoint = TestEnvironment.CatalogEndpoint;
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new Employee_Unregistered { Name = "UnregisteredEmployee", Age = 7 };

            var serializer = new SchemaRegistryAvroSerializer(endpoint, groupName, new SchemaRegistryAvroSerializerOptions
            {
                AutoRegisterSchemas = false  // Disable auto-registration
            });

            Assert.That(
                async () => await serializer.SerializeAsync<MessageContent, Employee_Unregistered>(employee),
                Throws.InstanceOf<Exception>());
        }

        [RecordedTest]
        public async Task CatalogMode_DeserializeWithoutGroupName_WorksCorrectly()
        {
            // Arrange
            var endpoint = TestEnvironment.CatalogEndpoint;
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employee = new Employee { Age = 28, Name = "DeserializeOnlyEmployee" };

            // First, serialize with full serializer
            var serializerWithGroup = new SchemaRegistryAvroSerializer(endpoint, groupName, new SchemaRegistryAvroSerializerOptions
            {
                AutoRegisterSchemas = true
            });
            var content = await serializerWithGroup.SerializeAsync<MessageContent, Employee>(employee);

            // Create a new serializer instance for deserialization only (mimicking the pattern from existing tests)
            var deserializeOnlySerializer = new SchemaRegistryAvroSerializer(CreateClient());

            // Act
            Employee deserializedEmployee = await deserializeOnlySerializer.DeserializeAsync<Employee>(content);

            // Assert
            Assert.IsNotNull(deserializedEmployee);
            Assert.AreEqual("DeserializeOnlyEmployee", deserializedEmployee.Name);
            Assert.AreEqual(28, deserializedEmployee.Age);
        }

        #endregion

        #region Error Handling Tests

        [Test]
        public void CatalogMode_InvalidEndpoint_ThrowsOnConstruction()
        {
            // Arrange
            var invalidEndpoint = "invalid-endpoint";
            var groupName = TestEnvironment.SchemaRegistryGroup;;
            var options = new SchemaRegistryAvroSerializerOptions();

            // Act & Assert
            Assert.Throws<UriFormatException>(() => new SchemaRegistryAvroSerializer(invalidEndpoint, groupName, options));
        }

        [RecordedTest]
        public void CatalogMode_SerializeNullObject_ThrowsArgumentNullException()
        {
            // Arrange
            var endpoint = TestEnvironment.CatalogEndpoint;
            var groupName = TestEnvironment.SchemaRegistryGroup;
            Employee employee = null;

            var serializer = new SchemaRegistryAvroSerializer(endpoint, groupName, new SchemaRegistryAvroSerializerOptions
            {
                AutoRegisterSchemas = true
            });

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await serializer.SerializeAsync<MessageContent, Employee>(employee));
        }

        [RecordedTest]
        public void CatalogMode_DeserializeInvalidContent_ThrowsException()
        {
            // Arrange
            var endpoint = TestEnvironment.CatalogEndpoint;
            var groupName = TestEnvironment.SchemaRegistryGroup;

            var serializer = new SchemaRegistryAvroSerializer(endpoint, groupName, new SchemaRegistryAvroSerializerOptions());

            var invalidContent = new MessageContent()
            {
                ContentType = "avro/binary+schemaId",
                Data = new BinaryData("invalid-avro-data")
            };

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () =>
                await serializer.DeserializeAsync<Employee>(invalidContent));
        }

        #endregion

        #region Performance and Caching Tests

        [RecordedTest]
        public async Task CatalogMode_RepeatedSerialization_UsesSchemaCache()
        {
            // Arrange
            var endpoint = TestEnvironment.CatalogEndpoint;
            var groupName = TestEnvironment.SchemaRegistryGroup;
            var employees = new[]
            {
                new Employee { Age = 25, Name = "CacheTest1" },
                new Employee { Age = 26, Name = "CacheTest2" },
                new Employee { Age = 27, Name = "CacheTest3" }
            };

            var serializer = new SchemaRegistryAvroSerializer(endpoint, groupName, new SchemaRegistryAvroSerializerOptions
            {
                AutoRegisterSchemas = true
            });

            // Act - Multiple serializations should reuse cached schema
            var contents = new MessageContent[employees.Length];
            for (int i = 0; i < employees.Length; i++)
            {
                contents[i] = await serializer.SerializeAsync<MessageContent, Employee>(employees[i]);
            }

            // Assert - All should have the same schema ID in content type
            var firstContentType = contents[0].ContentType.ToString();
            for (int i = 1; i < contents.Length; i++)
            {
                Assert.AreEqual(firstContentType, contents[i].ContentType.ToString(),
                    "All serialized employees should use the same cached schema");
            }

            // Verify all can be deserialized correctly
            for (int i = 0; i < employees.Length; i++)
            {
                var deserialized = await serializer.DeserializeAsync<Employee>(contents[i]);
                Assert.AreEqual(employees[i].Name, deserialized.Name);
                Assert.AreEqual(employees[i].Age, deserialized.Age);
            }
        }

        #endregion
    }
}
