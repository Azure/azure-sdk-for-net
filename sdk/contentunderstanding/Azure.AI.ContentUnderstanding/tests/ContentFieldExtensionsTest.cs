// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Unit tests for <see cref="ContentField.Value"/> extension property,
    /// which returns typed values via a switch expression over all field subtypes.
    /// </summary>
    [TestFixture]
    public class ContentFieldExtensionsTest
    {
        #region StringField

        [Test]
        public void Value_StringField_ReturnsValueString()
        {
            var field = ContentUnderstandingModelFactory.ContentStringField(value: "Hello");
            Assert.AreEqual("Hello", field.Value);
        }

        [Test]
        public void Value_StringField_NullValue_ReturnsNull()
        {
            var field = ContentUnderstandingModelFactory.ContentStringField(value: null);
            Assert.IsNull(field.Value);
        }

        #endregion

        #region NumberField

        [Test]
        public void Value_NumberField_ReturnsValueNumber()
        {
            var field = ContentUnderstandingModelFactory.ContentNumberField(value: 42.5);
            Assert.AreEqual(42.5, field.Value);
        }

        [Test]
        public void Value_NumberField_NullValue_ReturnsNull()
        {
            var field = ContentUnderstandingModelFactory.ContentNumberField(value: null);
            Assert.IsNull(field.Value);
        }

        #endregion

        #region IntegerField

        [Test]
        public void Value_IntegerField_ReturnsValueInteger()
        {
            var field = ContentUnderstandingModelFactory.ContentIntegerField(value: 123L);
            Assert.AreEqual(123L, field.Value);
        }

        [Test]
        public void Value_IntegerField_NullValue_ReturnsNull()
        {
            var field = ContentUnderstandingModelFactory.ContentIntegerField(value: null);
            Assert.IsNull(field.Value);
        }

        [Test]
        public void Value_IntegerField_NegativeValue_ReturnsValue()
        {
            var field = ContentUnderstandingModelFactory.ContentIntegerField(value: -99L);
            Assert.AreEqual(-99L, field.Value);
        }

        [Test]
        public void Value_IntegerField_Zero_ReturnsZero()
        {
            var field = ContentUnderstandingModelFactory.ContentIntegerField(value: 0L);
            Assert.AreEqual(0L, field.Value);
        }

        #endregion

        #region DateField

        [Test]
        public void Value_DateField_ReturnsValueDate()
        {
            var date = new DateTimeOffset(2024, 6, 15, 0, 0, 0, TimeSpan.Zero);
            var field = ContentUnderstandingModelFactory.ContentDateTimeOffsetField(value: date);
            Assert.AreEqual(date, field.Value);
        }

        [Test]
        public void Value_DateField_NullValue_ReturnsNull()
        {
            var field = ContentUnderstandingModelFactory.ContentDateTimeOffsetField(value: null);
            Assert.IsNull(field.Value);
        }

        [Test]
        public void Value_DateField_MinValue_ReturnsMinValue()
        {
            var date = DateTimeOffset.MinValue;
            var field = ContentUnderstandingModelFactory.ContentDateTimeOffsetField(value: date);
            Assert.AreEqual(date, field.Value);
        }

        #endregion

        #region TimeField

        [Test]
        public void Value_TimeField_ReturnsValueTime()
        {
            var time = new TimeSpan(14, 30, 0);
            var field = ContentUnderstandingModelFactory.ContentTimeField(value: time);
            Assert.AreEqual(time, field.Value);
        }

        [Test]
        public void Value_TimeField_NullValue_ReturnsNull()
        {
            var field = ContentUnderstandingModelFactory.ContentTimeField(value: null);
            Assert.IsNull(field.Value);
        }

        [Test]
        public void Value_TimeField_Midnight_ReturnsZero()
        {
            var time = TimeSpan.Zero;
            var field = ContentUnderstandingModelFactory.ContentTimeField(value: time);
            Assert.AreEqual(TimeSpan.Zero, field.Value);
        }

        #endregion

        #region BooleanField

        [Test]
        public void Value_BooleanField_True_ReturnsTrue()
        {
            var field = ContentUnderstandingModelFactory.ContentBooleanField(value: true);
            Assert.AreEqual(true, field.Value);
        }

        [Test]
        public void Value_BooleanField_False_ReturnsFalse()
        {
            var field = ContentUnderstandingModelFactory.ContentBooleanField(value: false);
            Assert.AreEqual(false, field.Value);
        }

        [Test]
        public void Value_BooleanField_NullValue_ReturnsNull()
        {
            var field = ContentUnderstandingModelFactory.ContentBooleanField(value: null);
            Assert.IsNull(field.Value);
        }

        #endregion

        #region ObjectField

        [Test]
        public void Value_ObjectField_ReturnsValueObject()
        {
            var innerFields = new Dictionary<string, ContentField>
            {
                ["Name"] = ContentUnderstandingModelFactory.ContentStringField(value: "Test")
            };
            var field = ContentUnderstandingModelFactory.ContentObjectField(value: innerFields);
            var result = field.Value as IDictionary<string, ContentField>;
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result!.Count);
            Assert.IsTrue(result.ContainsKey("Name"));
        }

        #endregion

        #region ArrayField

        [Test]
        public void Value_ArrayField_ReturnsValueArray()
        {
            var items = new List<ContentField>
            {
                ContentUnderstandingModelFactory.ContentStringField(value: "Item1"),
                ContentUnderstandingModelFactory.ContentStringField(value: "Item2")
            };
            var field = ContentUnderstandingModelFactory.ContentArrayField(value: items);
            var result = field.Value as IList<ContentField>;
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result!.Count);
        }

        #endregion

        #region JsonField

        [Test]
        public void Value_JsonField_ReturnsValueJson()
        {
            var json = BinaryData.FromString("{\"key\": \"value\"}");
            var field = ContentUnderstandingModelFactory.ContentJsonField(value: json);
            Assert.IsNotNull(field.Value);
            Assert.AreSame(json, field.Value);
        }

        [Test]
        public void Value_JsonField_NullValue_ReturnsNull()
        {
            var field = ContentUnderstandingModelFactory.ContentJsonField(value: null);
            Assert.IsNull(field.Value);
        }

        [Test]
        public void Value_JsonField_EmptyObject_ReturnsValue()
        {
            var json = BinaryData.FromString("{}");
            var field = ContentUnderstandingModelFactory.ContentJsonField(value: json);
            Assert.IsNotNull(field.Value);
        }

        [Test]
        public void Value_JsonField_ArrayJson_ReturnsValue()
        {
            var json = BinaryData.FromString("[1, 2, 3]");
            var field = ContentUnderstandingModelFactory.ContentJsonField(value: json);
            Assert.IsNotNull(field.Value);
        }

        #endregion

        #region UnknownContentField (default branch)

        [Test]
        public void Value_UnknownContentField_ReturnsNull()
        {
            // ContentUnderstandingModelFactory.ContentField creates an UnknownContentField
            // which hits the default/_ branch in the switch expression
            var field = ContentUnderstandingModelFactory.ContentField(type: "unknownType");
            Assert.IsNull(field.Value);
        }

        #endregion

        #region Confidence property verification

        [Test]
        public void Value_FieldWithConfidence_ValueAccessDoesNotAffectConfidence()
        {
            var field = ContentUnderstandingModelFactory.ContentIntegerField(value: 42L, confidence: 0.95f);
            _ = field.Value;
            Assert.AreEqual(0.95f, field.Confidence);
        }

        #endregion
    }
}
