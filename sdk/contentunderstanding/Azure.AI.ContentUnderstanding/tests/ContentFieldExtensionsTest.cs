// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Unit tests for <see cref="ContentField"/> extension properties, specifically the Value property.
    /// Tests all field types to ensure proper value extraction.
    /// </summary>
    [TestFixture]
    public class ContentFieldExtensionsTest
    {
        #region StringField Tests

        [Test]
        public void Value_StringField_ReturnsValueString()
        {
            // Arrange
            const string expectedValue = "TestStringValue";
            var field = ContentUnderstandingModelFactory.StringField(valueString: expectedValue);

            // Act
            var result = field.Value;

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void Value_StringField_NullValue_ReturnsNull()
        {
            // Arrange
            var field = ContentUnderstandingModelFactory.StringField(valueString: null);

            // Act
            var result = field.Value;

            // Assert
            Assert.IsNull(result);
        }

        #endregion

        #region NumberField Tests

        [Test]
        public void Value_NumberField_ReturnsValueNumber()
        {
            // Arrange
            const double expectedValue = 42.5;
            var field = ContentUnderstandingModelFactory.NumberField(valueNumber: expectedValue);

            // Act
            var result = field.Value;

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void Value_NumberField_NullValue_ReturnsNull()
        {
            // Arrange
            var field = ContentUnderstandingModelFactory.NumberField(valueNumber: null);

            // Act
            var result = field.Value;

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Value_NumberField_ZeroValue_ReturnsZero()
        {
            // Arrange
            var field = ContentUnderstandingModelFactory.NumberField(valueNumber: 0.0);

            // Act
            var result = field.Value;

            // Assert
            Assert.AreEqual(0.0, result);
        }

        [Test]
        public void Value_NumberField_NegativeValue_ReturnsNegative()
        {
            // Arrange
            const double expectedValue = -123.456;
            var field = ContentUnderstandingModelFactory.NumberField(valueNumber: expectedValue);

            // Act
            var result = field.Value;

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        #endregion

        #region IntegerField Tests

        [Test]
        public void Value_IntegerField_ReturnsValueInteger()
        {
            // Arrange
            const long expectedValue = 12345;
            var field = ContentUnderstandingModelFactory.IntegerField(valueInteger: expectedValue);

            // Act
            var result = field.Value;

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void Value_IntegerField_NullValue_ReturnsNull()
        {
            // Arrange
            var field = ContentUnderstandingModelFactory.IntegerField(valueInteger: null);

            // Act
            var result = field.Value;

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Value_IntegerField_ZeroValue_ReturnsZero()
        {
            // Arrange
            var field = ContentUnderstandingModelFactory.IntegerField(valueInteger: 0);

            // Act
            var result = field.Value;

            // Assert
            Assert.AreEqual(0L, result);
        }

        [Test]
        public void Value_IntegerField_NegativeValue_ReturnsNegative()
        {
            // Arrange
            const long expectedValue = -9876543210;
            var field = ContentUnderstandingModelFactory.IntegerField(valueInteger: expectedValue);

            // Act
            var result = field.Value;

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void Value_IntegerField_MaxValue_ReturnsMaxValue()
        {
            // Arrange
            var field = ContentUnderstandingModelFactory.IntegerField(valueInteger: long.MaxValue);

            // Act
            var result = field.Value;

            // Assert
            Assert.AreEqual(long.MaxValue, result);
        }

        #endregion

        #region DateField Tests

        [Test]
        public void Value_DateField_ReturnsValueDate()
        {
            // Arrange
            var expectedValue = new DateTimeOffset(2024, 6, 15, 0, 0, 0, TimeSpan.Zero);
            var field = ContentUnderstandingModelFactory.DateField(valueDate: expectedValue);

            // Act
            var result = field.Value;

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void Value_DateField_NullValue_ReturnsNull()
        {
            // Arrange
            var field = ContentUnderstandingModelFactory.DateField(valueDate: null);

            // Act
            var result = field.Value;

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Value_DateField_WithTimeZone_ReturnsCorrectValue()
        {
            // Arrange
            var expectedValue = new DateTimeOffset(2024, 12, 31, 23, 59, 59, TimeSpan.FromHours(8));
            var field = ContentUnderstandingModelFactory.DateField(valueDate: expectedValue);

            // Act
            var result = field.Value;

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        #endregion

        #region TimeField Tests

        [Test]
        public void Value_TimeField_ReturnsValueTime()
        {
            // Arrange
            var expectedValue = new TimeSpan(14, 30, 45);
            var field = ContentUnderstandingModelFactory.TimeField(valueTime: expectedValue);

            // Act
            var result = field.Value;

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void Value_TimeField_NullValue_ReturnsNull()
        {
            // Arrange
            var field = ContentUnderstandingModelFactory.TimeField(valueTime: null);

            // Act
            var result = field.Value;

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Value_TimeField_Midnight_ReturnsZeroTimeSpan()
        {
            // Arrange
            var expectedValue = TimeSpan.Zero;
            var field = ContentUnderstandingModelFactory.TimeField(valueTime: expectedValue);

            // Act
            var result = field.Value;

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void Value_TimeField_MaxTime_ReturnsCorrectValue()
        {
            // Arrange
            var expectedValue = new TimeSpan(23, 59, 59);
            var field = ContentUnderstandingModelFactory.TimeField(valueTime: expectedValue);

            // Act
            var result = field.Value;

            // Assert
            Assert.AreEqual(expectedValue, result);
        }

        #endregion

        #region BooleanField Tests

        [Test]
        public void Value_BooleanField_True_ReturnsTrue()
        {
            // Arrange
            var field = ContentUnderstandingModelFactory.BooleanField(valueBoolean: true);

            // Act
            var result = field.Value;

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void Value_BooleanField_False_ReturnsFalse()
        {
            // Arrange
            var field = ContentUnderstandingModelFactory.BooleanField(valueBoolean: false);

            // Act
            var result = field.Value;

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void Value_BooleanField_NullValue_ReturnsNull()
        {
            // Arrange
            var field = ContentUnderstandingModelFactory.BooleanField(valueBoolean: null);

            // Act
            var result = field.Value;

            // Assert
            Assert.IsNull(result);
        }

        #endregion

        #region ObjectField Tests

        [Test]
        public void Value_ObjectField_ReturnsValueObject()
        {
            // Arrange
            var nestedFields = new Dictionary<string, ContentField>
            {
                ["NestedString"] = ContentUnderstandingModelFactory.StringField(valueString: "NestedValue"),
                ["NestedNumber"] = ContentUnderstandingModelFactory.NumberField(valueNumber: 100.0)
            };
            var field = ContentUnderstandingModelFactory.ObjectField(valueObject: nestedFields);

            // Act
            var result = field.Value;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IDictionary<string, ContentField>>(result);
            var dict = (IDictionary<string, ContentField>)result!;
            Assert.AreEqual(2, dict.Count);
            Assert.IsTrue(dict.ContainsKey("NestedString"));
            Assert.IsTrue(dict.ContainsKey("NestedNumber"));
        }

        [Test]
        public void Value_ObjectField_NullValue_ReturnsEmptyDictionary()
        {
            // Arrange
            // Note: When valueObject is null, the ModelFactory returns an empty dictionary
            var field = ContentUnderstandingModelFactory.ObjectField(valueObject: null);

            // Act
            var result = field.Value;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IDictionary<string, ContentField>>(result);
            var dict = (IDictionary<string, ContentField>)result!;
            Assert.AreEqual(0, dict.Count);
        }

        [Test]
        public void Value_ObjectField_EmptyDictionary_ReturnsEmptyDictionary()
        {
            // Arrange
            var emptyFields = new Dictionary<string, ContentField>();
            var field = ContentUnderstandingModelFactory.ObjectField(valueObject: emptyFields);

            // Act
            var result = field.Value;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IDictionary<string, ContentField>>(result);
            var dict = (IDictionary<string, ContentField>)result!;
            Assert.AreEqual(0, dict.Count);
        }

        #endregion

        #region ArrayField Tests

        [Test]
        public void Value_ArrayField_ReturnsValueArray()
        {
            // Arrange
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.StringField(valueString: "Item1"),
                ContentUnderstandingModelFactory.StringField(valueString: "Item2"),
                ContentUnderstandingModelFactory.NumberField(valueNumber: 42.0)
            };
            var field = ContentUnderstandingModelFactory.ArrayField(valueArray: items);

            // Act
            var result = field.Value;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IList<ContentField>>(result);
            var list = (IList<ContentField>)result!;
            Assert.AreEqual(3, list.Count);
        }

        [Test]
        public void Value_ArrayField_NullValue_ReturnsEmptyList()
        {
            // Arrange
            // Note: When valueArray is null, the ModelFactory returns an empty list
            var field = ContentUnderstandingModelFactory.ArrayField(valueArray: null);

            // Act
            var result = field.Value;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IList<ContentField>>(result);
            var list = (IList<ContentField>)result!;
            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void Value_ArrayField_EmptyList_ReturnsEmptyList()
        {
            // Arrange
            var emptyList = new List<ContentField>();
            var field = ContentUnderstandingModelFactory.ArrayField(valueArray: emptyList);

            // Act
            var result = field.Value;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IList<ContentField>>(result);
            var list = (IList<ContentField>)result!;
            Assert.AreEqual(0, list.Count);
        }

        #endregion

        #region JsonField Tests

        [Test]
        public void Value_JsonField_ReturnsValueJson()
        {
            // Arrange
            const string expectedJson = "{\"key\": \"value\", \"number\": 123}";
            var field = ContentUnderstandingModelFactory.JsonField(valueJson: BinaryData.FromString(expectedJson));

            // Act
            var result = field.Value;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BinaryData>(result);
            var binaryData = (BinaryData)result!;
            Assert.AreEqual(expectedJson, binaryData.ToString());
        }

        [Test]
        public void Value_JsonField_NullValue_ReturnsNull()
        {
            // Arrange
            var field = ContentUnderstandingModelFactory.JsonField(valueJson: null);

            // Act
            var result = field.Value;

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Value_JsonField_EmptyJson_ReturnsEmptyBinaryData()
        {
            // Arrange
            var emptyJson = BinaryData.FromString("{}");
            var field = ContentUnderstandingModelFactory.JsonField(valueJson: emptyJson);

            // Act
            var result = field.Value;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BinaryData>(result);
            var binaryData = (BinaryData)result!;
            Assert.AreEqual("{}", binaryData.ToString());
        }

        [Test]
        public void Value_JsonField_ArrayJson_ReturnsCorrectValue()
        {
            // Arrange
            const string arrayJson = "[1, 2, 3, \"four\"]";
            var field = ContentUnderstandingModelFactory.JsonField(valueJson: BinaryData.FromString(arrayJson));

            // Act
            var result = field.Value;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BinaryData>(result);
            var binaryData = (BinaryData)result!;
            Assert.AreEqual(arrayJson, binaryData.ToString());
        }

        #endregion

        #region Integration Tests

        [Test]
        public void Value_NestedObjectWithMixedFieldTypes_WorksCorrectly()
        {
            // Arrange - Create a complex nested structure like a real invoice might have
            var lineItemFields = new Dictionary<string, ContentField>
            {
                ["Description"] = ContentUnderstandingModelFactory.StringField(valueString: "Consulting Service"),
                ["Quantity"] = ContentUnderstandingModelFactory.IntegerField(valueInteger: 10),
                ["UnitPrice"] = ContentUnderstandingModelFactory.NumberField(valueNumber: 150.00),
                ["Date"] = ContentUnderstandingModelFactory.DateField(valueDate: new DateTimeOffset(2024, 6, 15, 0, 0, 0, TimeSpan.Zero))
            };
            var lineItem = ContentUnderstandingModelFactory.ObjectField(valueObject: lineItemFields);

            var lineItems = new List<ContentField> { lineItem };
            var arrayField = ContentUnderstandingModelFactory.ArrayField(valueArray: lineItems);

            // Act
            var arrayValue = arrayField.Value as IList<ContentField>;
            var firstItem = arrayValue?[0] as ObjectField;
            var firstItemDict = firstItem?.Value as IDictionary<string, ContentField>;

            // Assert
            Assert.IsNotNull(arrayValue);
            Assert.AreEqual(1, arrayValue!.Count);
            Assert.IsNotNull(firstItemDict);
            Assert.AreEqual("Consulting Service", ((StringField)firstItemDict!["Description"]).Value);
            Assert.AreEqual(10L, ((IntegerField)firstItemDict["Quantity"]).Value);
            Assert.AreEqual(150.00, ((NumberField)firstItemDict["UnitPrice"]).Value);
        }

        [Test]
        public void Value_AllFieldTypesInDictionary_CanBeRetrieved()
        {
            // Arrange - Dictionary with all supported field types
            var fields = new Dictionary<string, ContentField>
            {
                ["StringField"] = ContentUnderstandingModelFactory.StringField(valueString: "test"),
                ["NumberField"] = ContentUnderstandingModelFactory.NumberField(valueNumber: 3.14),
                ["IntegerField"] = ContentUnderstandingModelFactory.IntegerField(valueInteger: 42),
                ["DateField"] = ContentUnderstandingModelFactory.DateField(valueDate: DateTimeOffset.Now),
                ["TimeField"] = ContentUnderstandingModelFactory.TimeField(valueTime: TimeSpan.FromHours(12)),
                ["BooleanField"] = ContentUnderstandingModelFactory.BooleanField(valueBoolean: true),
                ["ObjectField"] = ContentUnderstandingModelFactory.ObjectField(valueObject: new Dictionary<string, ContentField>()),
                ["ArrayField"] = ContentUnderstandingModelFactory.ArrayField(valueArray: new List<ContentField>()),
                ["JsonField"] = ContentUnderstandingModelFactory.JsonField(valueJson: BinaryData.FromString("{}"))
            };

            // Act & Assert - Verify each field type returns the correct value type
            Assert.IsInstanceOf<string>(fields["StringField"].Value);
            Assert.IsInstanceOf<double>(fields["NumberField"].Value);
            Assert.IsInstanceOf<long>(fields["IntegerField"].Value);
            Assert.IsInstanceOf<DateTimeOffset>(fields["DateField"].Value);
            Assert.IsInstanceOf<TimeSpan>(fields["TimeField"].Value);
            Assert.IsInstanceOf<bool>(fields["BooleanField"].Value);
            Assert.IsInstanceOf<IDictionary<string, ContentField>>(fields["ObjectField"].Value);
            Assert.IsInstanceOf<IList<ContentField>>(fields["ArrayField"].Value);
            Assert.IsInstanceOf<BinaryData>(fields["JsonField"].Value);
        }

        #endregion

        #region UnknownContentField Tests

        [Test]
        public void Value_UnknownContentField_ReturnsNull()
        {
            // Arrange - Create UnknownContentField by deserializing JSON with unknown type
            string json = """
            {
                "type": "unknownType",
                "confidence": 0.95
            }
            """;
            var element = System.Text.Json.JsonDocument.Parse(json).RootElement;
            var field = ContentField.DeserializeContentField(element, new System.ClientModel.Primitives.ModelReaderWriterOptions("W"));

            // Act
            var result = field.Value;

            // Assert
            Assert.IsNull(result);
            Assert.IsInstanceOf<UnknownContentField>(field);
        }

        #endregion
    }
}
