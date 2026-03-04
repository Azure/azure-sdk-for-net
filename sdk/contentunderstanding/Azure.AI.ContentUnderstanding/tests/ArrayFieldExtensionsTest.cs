// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Unit tests for <see cref="ContentArrayField"/> extension properties: Count and indexer.
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
                ContentUnderstandingModelFactory.ContentStringField(value: "A"),
                ContentUnderstandingModelFactory.ContentStringField(value: "B"),
                ContentUnderstandingModelFactory.ContentStringField(value: "C")
            };
            var field = ContentUnderstandingModelFactory.ContentArrayField(value: items);

            Assert.AreEqual(3, field.Count);
        }

        [Test]
        public void Count_EmptyArray_ReturnsZero()
        {
            var field = ContentUnderstandingModelFactory.ContentArrayField(value: new List<ContentField>());
            Assert.AreEqual(0, field.Count);
        }

        [Test]
        public void Count_DefaultArray_ReturnsZero()
        {
            // Default value (null param) should be coalesced to empty
            var field = ContentUnderstandingModelFactory.ContentArrayField();
            Assert.AreEqual(0, field.Count);
        }

        #endregion

        #region Indexer - happy path

        [Test]
        public void Indexer_ValidIndex_ReturnsCorrectItem()
        {
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.ContentStringField(value: "First"),
                ContentUnderstandingModelFactory.ContentNumberField(value: 42.0),
                ContentUnderstandingModelFactory.ContentBooleanField(value: true)
            };
            var field = ContentUnderstandingModelFactory.ContentArrayField(value: items);

            Assert.IsInstanceOf<ContentStringField>(field[0]);
            Assert.AreEqual("First", ((ContentStringField)field[0]).Value);

            Assert.IsInstanceOf<ContentNumberField>(field[1]);
            Assert.AreEqual(42.0, ((ContentNumberField)field[1]).Value);

            Assert.IsInstanceOf<ContentBooleanField>(field[2]);
            Assert.AreEqual(true, ((ContentBooleanField)field[2]).Value);
        }

        [Test]
        public void Indexer_LastItem_ReturnsCorrectItem()
        {
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.ContentStringField(value: "A"),
                ContentUnderstandingModelFactory.ContentStringField(value: "B"),
                ContentUnderstandingModelFactory.ContentStringField(value: "Last")
            };
            var field = ContentUnderstandingModelFactory.ContentArrayField(value: items);

            Assert.IsInstanceOf<ContentStringField>(field[2]);
            Assert.AreEqual("Last", ((ContentStringField)field[2]).Value);
        }

        #endregion

        #region Indexer - exception paths

        [Test]
        public void Indexer_NegativeIndex_ThrowsArgumentOutOfRangeException()
        {
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.ContentStringField(value: "Item")
            };
            var field = ContentUnderstandingModelFactory.ContentArrayField(value: items);

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _ = field[-1]);
            Assert.IsNotNull(ex);
            Assert.AreEqual("index", ex!.ParamName);
        }

        [Test]
        public void Indexer_IndexEqualToCount_ThrowsArgumentOutOfRangeException()
        {
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.ContentStringField(value: "Only")
            };
            var field = ContentUnderstandingModelFactory.ContentArrayField(value: items);

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _ = field[1]);
            Assert.IsNotNull(ex);
            Assert.AreEqual("index", ex!.ParamName);
        }

        [Test]
        public void Indexer_IndexGreaterThanCount_ThrowsArgumentOutOfRangeException()
        {
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.ContentStringField(value: "A"),
                ContentUnderstandingModelFactory.ContentStringField(value: "B")
            };
            var field = ContentUnderstandingModelFactory.ContentArrayField(value: items);

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _ = field[10]);
            Assert.IsNotNull(ex);
            Assert.AreEqual("index", ex!.ParamName);
        }

        [Test]
        public void Indexer_EmptyArray_ThrowsArgumentOutOfRangeException()
        {
            var field = ContentUnderstandingModelFactory.ContentArrayField(value: new List<ContentField>());

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
                ContentUnderstandingModelFactory.ContentObjectField(value: new Dictionary<string, ContentField>
                {
                    ["Name"] = ContentUnderstandingModelFactory.ContentStringField(value: "Alice")
                }),
                ContentUnderstandingModelFactory.ContentObjectField(value: new Dictionary<string, ContentField>
                {
                    ["Name"] = ContentUnderstandingModelFactory.ContentStringField(value: "Bob")
                })
            };
            var field = ContentUnderstandingModelFactory.ContentArrayField(value: items);

            Assert.AreEqual(2, field.Count);
            var firstItem = field[0] as ContentObjectField;
            Assert.IsNotNull(firstItem);
            Assert.AreEqual("Alice", ((ContentStringField)firstItem!.Value!["Name"]).Value);
        }

        #endregion
    }
}
