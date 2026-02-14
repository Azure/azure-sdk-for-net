// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Unit tests for <see cref="ArrayField"/> extension properties: Count and indexer.
    /// </summary>
    [TestFixture]
    public class ArrayFieldExtensionsTest
    {
        #region Count property

        [Test]
        public void Count_WithItems_ReturnsCorrectCount()
        {
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.StringField(valueString: "A"),
                ContentUnderstandingModelFactory.StringField(valueString: "B"),
                ContentUnderstandingModelFactory.StringField(valueString: "C")
            };
            var field = ContentUnderstandingModelFactory.ArrayField(valueArray: items);

            Assert.AreEqual(3, field.Count);
        }

        [Test]
        public void Count_EmptyArray_ReturnsZero()
        {
            var field = ContentUnderstandingModelFactory.ArrayField(valueArray: new List<ContentField>());
            Assert.AreEqual(0, field.Count);
        }

        [Test]
        public void Count_DefaultArray_ReturnsZero()
        {
            // Default valueArray (null param) should be coalesced to empty
            var field = ContentUnderstandingModelFactory.ArrayField();
            Assert.AreEqual(0, field.Count);
        }

        #endregion

        #region Indexer - happy path

        [Test]
        public void Indexer_ValidIndex_ReturnsCorrectItem()
        {
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.StringField(valueString: "First"),
                ContentUnderstandingModelFactory.NumberField(valueNumber: 42.0),
                ContentUnderstandingModelFactory.BooleanField(valueBoolean: true)
            };
            var field = ContentUnderstandingModelFactory.ArrayField(valueArray: items);

            Assert.IsInstanceOf<StringField>(field[0]);
            Assert.AreEqual("First", ((StringField)field[0]).ValueString);

            Assert.IsInstanceOf<NumberField>(field[1]);
            Assert.AreEqual(42.0, ((NumberField)field[1]).ValueNumber);

            Assert.IsInstanceOf<BooleanField>(field[2]);
            Assert.AreEqual(true, ((BooleanField)field[2]).ValueBoolean);
        }

        [Test]
        public void Indexer_LastItem_ReturnsCorrectItem()
        {
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.StringField(valueString: "A"),
                ContentUnderstandingModelFactory.StringField(valueString: "B"),
                ContentUnderstandingModelFactory.StringField(valueString: "Last")
            };
            var field = ContentUnderstandingModelFactory.ArrayField(valueArray: items);

            Assert.IsInstanceOf<StringField>(field[2]);
            Assert.AreEqual("Last", ((StringField)field[2]).ValueString);
        }

        #endregion

        #region Indexer - exception paths

        [Test]
        public void Indexer_NegativeIndex_ThrowsArgumentOutOfRangeException()
        {
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.StringField(valueString: "Item")
            };
            var field = ContentUnderstandingModelFactory.ArrayField(valueArray: items);

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _ = field[-1]);
            Assert.IsNotNull(ex);
            Assert.AreEqual("index", ex!.ParamName);
        }

        [Test]
        public void Indexer_IndexEqualToCount_ThrowsArgumentOutOfRangeException()
        {
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.StringField(valueString: "Only")
            };
            var field = ContentUnderstandingModelFactory.ArrayField(valueArray: items);

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _ = field[1]);
            Assert.IsNotNull(ex);
            Assert.AreEqual("index", ex!.ParamName);
        }

        [Test]
        public void Indexer_IndexGreaterThanCount_ThrowsArgumentOutOfRangeException()
        {
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.StringField(valueString: "A"),
                ContentUnderstandingModelFactory.StringField(valueString: "B")
            };
            var field = ContentUnderstandingModelFactory.ArrayField(valueArray: items);

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _ = field[10]);
            Assert.IsNotNull(ex);
            Assert.AreEqual("index", ex!.ParamName);
        }

        [Test]
        public void Indexer_EmptyArray_ThrowsArgumentOutOfRangeException()
        {
            var field = ContentUnderstandingModelFactory.ArrayField(valueArray: new List<ContentField>());

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _ = field[0]);
            Assert.IsNotNull(ex);
            Assert.AreEqual("index", ex!.ParamName);
            Assert.IsTrue(ex.Message.Contains("0 elements"), $"Expected message to contain '0 elements', but got: {ex.Message}");
        }

        #endregion

        #region Indexer with nested types

        [Test]
        public void Indexer_ArrayOfObjectFields_Works()
        {
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.ObjectField(valueObject: new Dictionary<string, ContentField>
                {
                    ["Name"] = ContentUnderstandingModelFactory.StringField(valueString: "Alice")
                }),
                ContentUnderstandingModelFactory.ObjectField(valueObject: new Dictionary<string, ContentField>
                {
                    ["Name"] = ContentUnderstandingModelFactory.StringField(valueString: "Bob")
                })
            };
            var field = ContentUnderstandingModelFactory.ArrayField(valueArray: items);

            Assert.AreEqual(2, field.Count);
            var firstItem = field[0] as ObjectField;
            Assert.IsNotNull(firstItem);
            Assert.AreEqual("Alice", ((StringField)firstItem!.ValueObject!["Name"]).ValueString);
        }

        #endregion
    }
}
