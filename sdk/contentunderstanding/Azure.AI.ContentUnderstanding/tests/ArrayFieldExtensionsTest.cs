// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Unit tests for <see cref="ArrayField"/> extension properties (Count and indexer).
    /// </summary>
    [TestFixture]
    public class ArrayFieldExtensionsTest
    {
        #region Count Property Tests

        [Test]
        public void Count_WithItems_ReturnsCorrectCount()
        {
            // Arrange
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.StringField(valueString: "Item1"),
                ContentUnderstandingModelFactory.StringField(valueString: "Item2"),
                ContentUnderstandingModelFactory.NumberField(valueNumber: 42.0)
            };
            var arrayField = ContentUnderstandingModelFactory.ArrayField(valueArray: items);

            // Act
            var count = arrayField.Count;

            // Assert
            Assert.AreEqual(3, count);
        }

        [Test]
        public void Count_EmptyArray_ReturnsZero()
        {
            // Arrange
            var arrayField = ContentUnderstandingModelFactory.ArrayField(valueArray: new List<ContentField>());

            // Act
            var count = arrayField.Count;

            // Assert
            Assert.AreEqual(0, count);
        }

        [Test]
        public void Count_NullValueArray_ReturnsZero()
        {
            // Arrange
            // When valueArray is null, ModelFactory still creates an empty list internally
            // But this tests the Count property's null-coalescing behavior
            var arrayField = ContentUnderstandingModelFactory.ArrayField(valueArray: null);

            // Act
            var count = arrayField.Count;

            // Assert
            Assert.AreEqual(0, count);
        }

        [Test]
        public void Count_SingleItem_ReturnsOne()
        {
            // Arrange
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.BooleanField(valueBoolean: true)
            };
            var arrayField = ContentUnderstandingModelFactory.ArrayField(valueArray: items);

            // Act
            var count = arrayField.Count;

            // Assert
            Assert.AreEqual(1, count);
        }

        #endregion

        #region Indexer Tests

        [Test]
        public void Indexer_ValidIndex_ReturnsCorrectItem()
        {
            // Arrange
            var item0 = ContentUnderstandingModelFactory.StringField(valueString: "First");
            var item1 = ContentUnderstandingModelFactory.NumberField(valueNumber: 100.0);
            var item2 = ContentUnderstandingModelFactory.BooleanField(valueBoolean: false);
            var items = new List<ContentField> { item0, item1, item2 };
            var arrayField = ContentUnderstandingModelFactory.ArrayField(valueArray: items);

            // Act & Assert
            Assert.AreSame(item0, arrayField[0]);
            Assert.AreSame(item1, arrayField[1]);
            Assert.AreSame(item2, arrayField[2]);
        }

        [Test]
        public void Indexer_FirstIndex_ReturnsFirstItem()
        {
            // Arrange
            var firstItem = ContentUnderstandingModelFactory.StringField(valueString: "FirstItem");
            var items = new List<ContentField>
            {
                firstItem,
                ContentUnderstandingModelFactory.StringField(valueString: "SecondItem")
            };
            var arrayField = ContentUnderstandingModelFactory.ArrayField(valueArray: items);

            // Act
            var result = arrayField[0];

            // Assert
            Assert.AreSame(firstItem, result);
            Assert.IsInstanceOf<StringField>(result);
            Assert.AreEqual("FirstItem", ((StringField)result).ValueString);
        }

        [Test]
        public void Indexer_LastIndex_ReturnsLastItem()
        {
            // Arrange
            var lastItem = ContentUnderstandingModelFactory.NumberField(valueNumber: 999.0);
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.StringField(valueString: "First"),
                ContentUnderstandingModelFactory.StringField(valueString: "Second"),
                lastItem
            };
            var arrayField = ContentUnderstandingModelFactory.ArrayField(valueArray: items);

            // Act
            var result = arrayField[2];

            // Assert
            Assert.AreSame(lastItem, result);
        }

        [Test]
        public void Indexer_NegativeIndex_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.StringField(valueString: "Item")
            };
            var arrayField = ContentUnderstandingModelFactory.ArrayField(valueArray: items);

            // Act & Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _ = arrayField[-1]);
            Assert.AreEqual("index", ex!.ParamName);
            StringAssert.Contains("-1", ex.Message);
            StringAssert.Contains("out of range", ex.Message);
        }

        [Test]
        public void Indexer_IndexEqualToCount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.StringField(valueString: "Item1"),
                ContentUnderstandingModelFactory.StringField(valueString: "Item2")
            };
            var arrayField = ContentUnderstandingModelFactory.ArrayField(valueArray: items);

            // Act & Assert - index 2 is out of range for 2-item array (valid: 0, 1)
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _ = arrayField[2]);
            Assert.AreEqual("index", ex!.ParamName);
            StringAssert.Contains("2", ex.Message);
            StringAssert.Contains("2 elements", ex.Message);
        }

        [Test]
        public void Indexer_IndexGreaterThanCount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.StringField(valueString: "OnlyItem")
            };
            var arrayField = ContentUnderstandingModelFactory.ArrayField(valueArray: items);

            // Act & Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _ = arrayField[10]);
            Assert.AreEqual("index", ex!.ParamName);
            StringAssert.Contains("10", ex.Message);
            StringAssert.Contains("1 elements", ex.Message);
        }

        [Test]
        public void Indexer_EmptyArray_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var arrayField = ContentUnderstandingModelFactory.ArrayField(valueArray: new List<ContentField>());

            // Act & Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _ = arrayField[0]);
            Assert.AreEqual("index", ex!.ParamName);
            StringAssert.Contains("0 elements", ex.Message);
        }

        [Test]
        public void Indexer_NullValueArray_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            // Note: Even when passing null, ModelFactory creates an empty list
            var arrayField = ContentUnderstandingModelFactory.ArrayField(valueArray: null);

            // Act & Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _ = arrayField[0]);
            Assert.AreEqual("index", ex!.ParamName);
        }

        #endregion

        #region Integration with ContentField.Value Tests

        [Test]
        public void ArrayField_CanAccessItemsViaValueProperty()
        {
            // Arrange
            var nestedObject = new Dictionary<string, ContentField>
            {
                ["Name"] = ContentUnderstandingModelFactory.StringField(valueString: "Product A"),
                ["Price"] = ContentUnderstandingModelFactory.NumberField(valueNumber: 29.99)
            };
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.ObjectField(valueObject: nestedObject)
            };
            var arrayField = ContentUnderstandingModelFactory.ArrayField(valueArray: items);

            // Act - Access via indexer
            var firstItem = arrayField[0];

            // Assert
            Assert.IsInstanceOf<ObjectField>(firstItem);
            var objectField = (ObjectField)firstItem;
            Assert.AreEqual(2, objectField.ValueObject!.Count);
            Assert.AreEqual("Product A", ((StringField)objectField.ValueObject["Name"]).ValueString);
        }

        [Test]
        public void ArrayField_IterateWithCountAndIndexer()
        {
            // Arrange
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.IntegerField(valueInteger: 1),
                ContentUnderstandingModelFactory.IntegerField(valueInteger: 2),
                ContentUnderstandingModelFactory.IntegerField(valueInteger: 3),
                ContentUnderstandingModelFactory.IntegerField(valueInteger: 4),
                ContentUnderstandingModelFactory.IntegerField(valueInteger: 5)
            };
            var arrayField = ContentUnderstandingModelFactory.ArrayField(valueArray: items);

            // Act
            long sum = 0;
            for (int i = 0; i < arrayField.Count; i++)
            {
                var intField = (IntegerField)arrayField[i];
                sum += intField.ValueInteger ?? 0;
            }

            // Assert
            Assert.AreEqual(15, sum); // 1+2+3+4+5 = 15
        }

        [Test]
        public void ArrayField_MixedFieldTypes_AccessViaIndexer()
        {
            // Arrange - Array with different field types (like invoice line items)
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.StringField(valueString: "Description"),
                ContentUnderstandingModelFactory.IntegerField(valueInteger: 5),
                ContentUnderstandingModelFactory.NumberField(valueNumber: 19.99),
                ContentUnderstandingModelFactory.BooleanField(valueBoolean: true),
                ContentUnderstandingModelFactory.DateField(valueDate: new DateTimeOffset(2024, 6, 15, 0, 0, 0, TimeSpan.Zero))
            };
            var arrayField = ContentUnderstandingModelFactory.ArrayField(valueArray: items);

            // Act & Assert
            Assert.AreEqual(5, arrayField.Count);
            Assert.IsInstanceOf<StringField>(arrayField[0]);
            Assert.IsInstanceOf<IntegerField>(arrayField[1]);
            Assert.IsInstanceOf<NumberField>(arrayField[2]);
            Assert.IsInstanceOf<BooleanField>(arrayField[3]);
            Assert.IsInstanceOf<DateField>(arrayField[4]);

            Assert.AreEqual("Description", ((StringField)arrayField[0]).ValueString);
            Assert.AreEqual(5L, ((IntegerField)arrayField[1]).ValueInteger);
            Assert.AreEqual(19.99, ((NumberField)arrayField[2]).ValueNumber);
            Assert.AreEqual(true, ((BooleanField)arrayField[3]).ValueBoolean);
        }

        #endregion
    }
}
