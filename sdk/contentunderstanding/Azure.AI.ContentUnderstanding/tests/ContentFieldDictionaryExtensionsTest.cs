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
    /// Unit tests for <see cref="ContentFieldDictionaryExtensions.GetFieldOrDefault"/> extension method.
    /// </summary>
    [TestFixture]
    public class ContentFieldDictionaryExtensionsTest
    {
        [Test]
        public void GetFieldOrDefault_FieldExists_ReturnsField()
        {
            // Arrange
            var field = ContentUnderstandingModelFactory.StringField(valueString: "TestValue");
            var fields = new Dictionary<string, ContentField>
            {
                ["TestField"] = field
            };

            // Act
            var result = fields.GetFieldOrDefault("TestField");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreSame(field, result);
            Assert.IsInstanceOf<StringField>(result);
        }

        [Test]
        public void GetFieldOrDefault_FieldDoesNotExist_ReturnsNull()
        {
            // Arrange
            var fields = new Dictionary<string, ContentField>
            {
                ["ExistingField"] = ContentUnderstandingModelFactory.StringField(valueString: "Value")
            };

            // Act
            var result = fields.GetFieldOrDefault("NonExistentField");

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetFieldOrDefault_DictionaryIsNull_ReturnsNull()
        {
            // Arrange
            IDictionary<string, ContentField>? fields = null;

            // Act
            var result = fields.GetFieldOrDefault("TestField");

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetFieldOrDefault_EmptyDictionary_ReturnsNull()
        {
            // Arrange
            var fields = new Dictionary<string, ContentField>();

            // Act
            var result = fields.GetFieldOrDefault("TestField");

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetFieldOrDefault_FieldNameIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var fields = new Dictionary<string, ContentField>
            {
                ["TestField"] = ContentUnderstandingModelFactory.StringField()
            };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => fields.GetFieldOrDefault(null!));
        }

        [Test]
        public void GetFieldOrDefault_FieldNameIsEmpty_ThrowsArgumentException()
        {
            // Arrange
            var fields = new Dictionary<string, ContentField>
            {
                ["TestField"] = ContentUnderstandingModelFactory.StringField()
            };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => fields.GetFieldOrDefault(""));
            Assert.AreEqual("fieldName", exception!.ParamName);
        }

        [Test]
        public void GetFieldOrDefault_FieldNameIsWhitespace_ReturnsNullIfNotInDictionary()
        {
            // Arrange
            // Note: AssertNotNullOrEmpty only checks for null and empty string, not whitespace
            // So whitespace is technically valid (though not recommended)
            var fields = new Dictionary<string, ContentField>
            {
                ["TestField"] = ContentUnderstandingModelFactory.StringField()
            };

            // Act
            var result = fields.GetFieldOrDefault("   ");

            // Assert
            // Whitespace is treated as a valid field name, but it's not in the dictionary
            Assert.IsNull(result);
        }

        [Test]
        public void GetFieldOrDefault_MultipleFields_ReturnsCorrectField()
        {
            // Arrange
            var field1 = ContentUnderstandingModelFactory.StringField(valueString: "Value1");
            var field2 = ContentUnderstandingModelFactory.NumberField(valueNumber: 42.0);
            var field3 = ContentUnderstandingModelFactory.StringField(valueString: "Value3");

            var fields = new Dictionary<string, ContentField>
            {
                ["Field1"] = field1,
                ["Field2"] = field2,
                ["Field3"] = field3
            };

            // Act
            var result1 = fields.GetFieldOrDefault("Field1");
            var result2 = fields.GetFieldOrDefault("Field2");
            var result3 = fields.GetFieldOrDefault("Field3");

            // Assert
            Assert.AreSame(field1, result1);
            Assert.AreSame(field2, result2);
            Assert.AreSame(field3, result3);
        }

        [Test]
        public void GetFieldOrDefault_CaseSensitive_RespectsCase()
        {
            // Arrange
            var field = ContentUnderstandingModelFactory.StringField(valueString: "Value");
            var fields = new Dictionary<string, ContentField>
            {
                ["TestField"] = field
            };

            // Act
            var result1 = fields.GetFieldOrDefault("TestField");
            var result2 = fields.GetFieldOrDefault("testfield");
            var result3 = fields.GetFieldOrDefault("TESTFIELD");

            // Assert
            Assert.IsNotNull(result1);
            Assert.AreSame(field, result1);
            Assert.IsNull(result2); // Case doesn't match
            Assert.IsNull(result3); // Case doesn't match
        }

        [Test]
        public void GetFieldOrDefault_WorksWithNullConditionalOperator()
        {
            // Arrange
            IDictionary<string, ContentField>? fields = new Dictionary<string, ContentField>
            {
                ["TestField"] = ContentUnderstandingModelFactory.StringField(valueString: "Value")
            };

            // Act
            var result = fields?.GetFieldOrDefault("TestField");

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetFieldOrDefault_WorksWithNullConditionalOperator_WhenDictionaryIsNull()
        {
            // Arrange
            IDictionary<string, ContentField>? fields = null;

            // Act
            var result = fields?.GetFieldOrDefault("TestField");

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetFieldOrDefault_WorksWithObjectField_ValueObject()
        {
            // Arrange
            var nestedField = ContentUnderstandingModelFactory.StringField(valueString: "NestedValue");
            var valueObject = new Dictionary<string, ContentField>
            {
                ["NestedField"] = nestedField
            };
            var objectField = ContentUnderstandingModelFactory.ObjectField(valueObject: valueObject);
            var fields = new Dictionary<string, ContentField>
            {
                ["ObjectField"] = objectField
            };

            // Act
            var result = fields.GetFieldOrDefault("ObjectField");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ObjectField>(result);
            var objField = (ObjectField)result!;
            var nestedResult = objField.ValueObject?.GetFieldOrDefault("NestedField");
            Assert.IsNotNull(nestedResult);
            Assert.AreSame(nestedField, nestedResult);
        }

        [Test]
        public void GetFieldOrDefault_FieldNameWithValidCharacters_Works()
        {
            // Arrange
            // Note: Field names in the API typically follow PascalCase/camelCase conventions (e.g., "CustomerName", "TotalAmount").
            // The TypeSpec defines fields as Record<ContentField> (string keys) without explicit pattern validation.
            // However, since field names are JSON property names, they should follow JSON naming conventions.
            // This test verifies the method works with valid field name patterns.
            var field = ContentUnderstandingModelFactory.StringField(valueString: "Value");
            var fields = new Dictionary<string, ContentField>
            {
                ["CustomerName"] = field,           // PascalCase (typical pattern)
                ["totalAmount"] = field,            // camelCase (also valid)
                ["Field_With_Underscores"] = field  // Underscores are valid in JSON property names
            };

            // Act & Assert
            Assert.IsNotNull(fields.GetFieldOrDefault("CustomerName"));
            Assert.IsNotNull(fields.GetFieldOrDefault("totalAmount"));
            Assert.IsNotNull(fields.GetFieldOrDefault("Field_With_Underscores"));
        }
    }
}
