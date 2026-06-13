// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using Azure.AI.ContentUnderstanding;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Unit tests for <see cref="ContentObjectField"/> indexer.
    /// </summary>
    [TestFixture]
    public class ObjectFieldExtensionsTest
    {
        [Test]
        public void Indexer_FieldExists_ReturnsField()
        {
            // Arrange
            var field = ContentUnderstandingModelFactory.ContentStringField(value: "TestValue");
            var valueObject = new Dictionary<string, ContentField>
            {
                ["TestField"] = field
            };
            var objectField = ContentUnderstandingModelFactory.ContentObjectField(value: valueObject);

            // Act
            var result = objectField["TestField"];

            // Assert
            Assert.IsNotNull(result);
            Assert.AreSame(field, result);
            Assert.IsInstanceOf<ContentStringField>(result);
        }

        [Test]
        public void Indexer_FieldDoesNotExist_ThrowsKeyNotFoundException()
        {
            // Arrange
            var valueObject = new Dictionary<string, ContentField>
            {
                ["ExistingField"] = ContentUnderstandingModelFactory.ContentStringField(value: "Value")
            };
            var objectField = ContentUnderstandingModelFactory.ContentObjectField(value: valueObject);

            // Act & Assert
            var exception = Assert.Throws<KeyNotFoundException>(() => _ = objectField["NonExistentField"]);
            Assert.IsNotNull(exception);
            Assert.IsTrue(exception!.Message.Contains("NonExistentField"));
        }

        [Test]
        public void Indexer_FieldNameIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var valueObject = new Dictionary<string, ContentField>
            {
                ["TestField"] = ContentUnderstandingModelFactory.ContentStringField(value: null)
            };
            var objectField = ContentUnderstandingModelFactory.ContentObjectField(value: valueObject);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _ = objectField[null!]);
        }

        [Test]
        public void Indexer_FieldNameIsEmpty_ThrowsArgumentException()
        {
            // Arrange
            var valueObject = new Dictionary<string, ContentField>
            {
                ["TestField"] = ContentUnderstandingModelFactory.ContentStringField(value: null)
            };
            var objectField = ContentUnderstandingModelFactory.ContentObjectField(value: valueObject);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _ = objectField[""]);
            Assert.AreEqual("fieldName", exception!.ParamName);
        }

        [Test]
        public void Indexer_ValueObjectIsNull_ThrowsKeyNotFoundException()
        {
            // Arrange
            var objectField = ContentUnderstandingModelFactory.ContentObjectField(value: null);

            // Act & Assert
            var exception = Assert.Throws<KeyNotFoundException>(() => _ = objectField["AnyField"]);
            Assert.IsNotNull(exception);
            Assert.IsTrue(exception!.Message.Contains("AnyField"));
        }

        [Test]
        public void Indexer_EmptyValueObject_ThrowsKeyNotFoundException()
        {
            // Arrange
            var valueObject = new Dictionary<string, ContentField>();
            var objectField = ContentUnderstandingModelFactory.ContentObjectField(value: valueObject);

            // Act & Assert
            var exception = Assert.Throws<KeyNotFoundException>(() => _ = objectField["TestField"]);
            Assert.IsNotNull(exception);
            Assert.IsTrue(exception!.Message.Contains("TestField"));
        }

        [Test]
        public void Indexer_MultipleFields_ReturnsCorrectField()
        {
            // Arrange
            var field1 = ContentUnderstandingModelFactory.ContentStringField(value: "Value1");
            var field2 = ContentUnderstandingModelFactory.ContentNumberField(value: 42.0);
            var field3 = ContentUnderstandingModelFactory.ContentBooleanField(value: true);
            var valueObject = new Dictionary<string, ContentField>
            {
                ["Field1"] = field1,
                ["Field2"] = field2,
                ["Field3"] = field3
            };
            var objectField = ContentUnderstandingModelFactory.ContentObjectField(value: valueObject);

            // Act & Assert
            Assert.AreSame(field1, objectField["Field1"]);
            Assert.AreSame(field2, objectField["Field2"]);
            Assert.AreSame(field3, objectField["Field3"]);
        }

        [Test]
        public void Indexer_FieldNameIsCaseSensitive()
        {
            // Arrange
            var field = ContentUnderstandingModelFactory.ContentStringField(value: "Value");
            var valueObject = new Dictionary<string, ContentField>
            {
                ["TestField"] = field
            };
            var objectField = ContentUnderstandingModelFactory.ContentObjectField(value: valueObject);

            // Act & Assert
            Assert.AreSame(field, objectField["TestField"]);
            Assert.Throws<KeyNotFoundException>(() => _ = objectField["testfield"]);
            Assert.Throws<KeyNotFoundException>(() => _ = objectField["TESTFIELD"]);
        }

        [Test]
        public void Indexer_WorksWithNestedObjectFields()
        {
            // Arrange
            var nestedField = ContentUnderstandingModelFactory.ContentStringField(value: "NestedValue");
            var nestedValueObject = new Dictionary<string, ContentField>
            {
                ["NestedField"] = nestedField
            };
            var nestedObjectField = ContentUnderstandingModelFactory.ContentObjectField(value: nestedValueObject);
            var valueObject = new Dictionary<string, ContentField>
            {
                ["NestedObject"] = nestedObjectField
            };
            var objectField = ContentUnderstandingModelFactory.ContentObjectField(value: valueObject);

            // Act
            var retrievedNestedObject = objectField["NestedObject"];

            // Assert
            Assert.IsNotNull(retrievedNestedObject);
            Assert.IsInstanceOf<ContentObjectField>(retrievedNestedObject);
            var nestedObj = (ContentObjectField)retrievedNestedObject;
            Assert.AreSame(nestedField, nestedObj["NestedField"]);
        }

        [Test]
        public void Indexer_WorksWithDifferentFieldTypes()
        {
            // Arrange
            var stringField = ContentUnderstandingModelFactory.ContentStringField(value: "StringValue");
            var numberField = ContentUnderstandingModelFactory.ContentNumberField(value: 123.45);
            var booleanField = ContentUnderstandingModelFactory.ContentBooleanField(value: true);
            var dateField = ContentUnderstandingModelFactory.ContentDateTimeOffsetField(value: DateTimeOffset.Now);
            var timeField = ContentUnderstandingModelFactory.ContentTimeField(value: TimeSpan.FromHours(14));
            var valueObject = new Dictionary<string, ContentField>
            {
                ["StringField"] = stringField,
                ["NumberField"] = numberField,
                ["BooleanField"] = booleanField,
                ["DateTimeOffsetField"] = dateField,
                ["TimeField"] = timeField
            };
            var objectField = ContentUnderstandingModelFactory.ContentObjectField(value: valueObject);

            // Act & Assert
            Assert.IsInstanceOf<ContentStringField>(objectField["StringField"]);
            Assert.IsInstanceOf<ContentNumberField>(objectField["NumberField"]);
            Assert.IsInstanceOf<ContentBooleanField>(objectField["BooleanField"]);
            Assert.IsInstanceOf<ContentDateTimeOffsetField>(objectField["DateTimeOffsetField"]);
            Assert.IsInstanceOf<ContentTimeField>(objectField["TimeField"]);
        }

        [Test]
        public void Indexer_FieldNameWithValidCharacters_Works()
        {
            // Arrange
            // Note: Field names in the API typically follow PascalCase/camelCase conventions (e.g., "CustomerName", "TotalAmount").
            // The TypeSpec defines fields as Record<ContentField> (string keys) without explicit pattern validation.
            // However, since field names are JSON property names, they should follow JSON naming conventions.
            var field = ContentUnderstandingModelFactory.ContentStringField(value: "Value");
            var valueObject = new Dictionary<string, ContentField>
            {
                ["CustomerName"] = field,           // PascalCase (typical pattern)
                ["totalAmount"] = field,            // camelCase (also valid)
                ["Field_With_Underscores"] = field  // Underscores are valid in JSON property names
            };
            var objectField = ContentUnderstandingModelFactory.ContentObjectField(value: valueObject);

            // Act & Assert
            Assert.IsNotNull(objectField["CustomerName"]);
            Assert.IsNotNull(objectField["totalAmount"]);
            Assert.IsNotNull(objectField["Field_With_Underscores"]);
        }

        [Test]
        public void Indexer_CanBeUsedInTryCatchPattern()
        {
            // Arrange
            var field = ContentUnderstandingModelFactory.ContentStringField(value: "Value");
            var valueObject = new Dictionary<string, ContentField>
            {
                ["Amount"] = field
            };
            var objectField = ContentUnderstandingModelFactory.ContentObjectField(value: valueObject);

            // Act
            string? amount = null;
            try
            {
                // Amount is known to exist
                amount = objectField["Amount"].Value?.ToString();
            }
            catch (KeyNotFoundException)
            {
                // Handle the issue as needed
                amount = null;
            }

            // Assert
            Assert.IsNotNull(amount);
            Assert.AreEqual("Value", amount);
        }

        [Test]
        public void Indexer_ThrowsKeyNotFoundException_WhenFieldDoesNotExist()
        {
            // Arrange
            var valueObject = new Dictionary<string, ContentField>
            {
                ["ExistingField"] = ContentUnderstandingModelFactory.ContentStringField(value: "Value")
            };
            var objectField = ContentUnderstandingModelFactory.ContentObjectField(value: valueObject);

            // Act & Assert
            try
            {
                _ = objectField["NonExistentField"];
                Assert.Fail("Expected KeyNotFoundException to be thrown");
            }
            catch (KeyNotFoundException ex)
            {
                Assert.IsNotNull(ex);
                Assert.IsTrue(ex!.Message.Contains("NonExistentField"));
            }
        }
    }
}
