// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.FormRecognizer.Models;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="FieldValue"/> struct.
    /// </summary>
    public class FieldValueTests
    {
        [Test]
        public void AsStringReturnsNullWhenFieldValueIsDefault()
        {
            FieldValue value = default;
            Assert.IsNull(value.AsString());
        }

        [Test]
        public void InstantiateFieldValueWithFloatAndNoValueNumberAndText()
        {
            var fieldValueInternal = new FieldValue_internal(
                FieldValueType.Float,
                valueString: default,
                valueDate: default,
                valueTime: default,
                valuePhoneNumber: default,
                valueNumber: default,
                valueInteger: default,
                valueArray: default,
                valueObject: default,
                valueSelectionMark: default,
                valueCountryRegion: default,
                text: "25.00%",
                boundingBox: default,
                confidence:  default,
                elements: default,
                page: default);

            var fieldValue = new FieldValue(fieldValueInternal, default);

            Assert.AreEqual(FieldValueType.Float, fieldValue.ValueType);
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsFloat());
        }

        [Test]
        public void InstantiateFieldValueWithInt64AndNoValueInteger()
        {
            var fieldValue = new FieldValue(FieldValueType.Int64);

            Assert.AreEqual(FieldValueType.Int64, fieldValue.ValueType);
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsInt64());
        }

        [Test]
        public void InstantiateFieldValueWithFloatAndNoValueNumber()
        {
            var fieldValue = new FieldValue(FieldValueType.Float);

            Assert.AreEqual(FieldValueType.Float, fieldValue.ValueType);
            // The service will always return a text property which our
            // AsFloat() method depends on in order to calculate the float.
            // This was introduced in 3.0 so sadly we need to maintain it.
            Assert.Throws<NullReferenceException>(() => fieldValue.AsFloat());
        }

        [Test]
        public void InstantiateFieldValueWithDateAndNoValueDate()
        {
            var fieldValue = new FieldValue(FieldValueType.Date);

            Assert.AreEqual(FieldValueType.Date, fieldValue.ValueType);
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDate());
        }

        [Test]
        public void InstantiateFieldValueWithTimeAndNoValueTime()
        {
            var fieldValue = new FieldValue(FieldValueType.Time);

            Assert.AreEqual(FieldValueType.Time, fieldValue.ValueType);
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsTime());
        }

        [Test]
        public void InstantiateFieldValueWithSelectionMarkAndNoValueSelectionMark()
        {
            var fieldValue = new FieldValue(FieldValueType.SelectionMark);

            Assert.AreEqual(FieldValueType.SelectionMark, fieldValue.ValueType);
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsSelectionMarkState());
        }
    }
}
