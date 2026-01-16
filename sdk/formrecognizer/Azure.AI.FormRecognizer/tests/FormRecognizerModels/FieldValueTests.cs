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
            Assert.That(value.AsString(), Is.Null);
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

            Assert.That(fieldValue.ValueType, Is.EqualTo(FieldValueType.Float));
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsFloat());
        }

        [Test]
        public void InstantiateFieldValueWithInt64AndNoValueInteger()
        {
            var fieldValue = new FieldValue(FieldValueType.Int64);

            Assert.That(fieldValue.ValueType, Is.EqualTo(FieldValueType.Int64));
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsInt64());
        }

        [Test]
        public void InstantiateFieldValueWithFloatAndNoValueNumber()
        {
            var fieldValue = new FieldValue(FieldValueType.Float);

            Assert.That(fieldValue.ValueType, Is.EqualTo(FieldValueType.Float));
            // The service will always return a text property which our
            // AsFloat() method depends on in order to calculate the float.
            // This was introduced in 3.0 so sadly we need to maintain it.
            Assert.Throws<NullReferenceException>(() => fieldValue.AsFloat());
        }

        [Test]
        public void InstantiateFieldValueWithDateAndNoValueDate()
        {
            var fieldValue = new FieldValue(FieldValueType.Date);

            Assert.That(fieldValue.ValueType, Is.EqualTo(FieldValueType.Date));
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsDate());
        }

        [Test]
        public void InstantiateFieldValueWithTimeAndNoValueTime()
        {
            var fieldValue = new FieldValue(FieldValueType.Time);

            Assert.That(fieldValue.ValueType, Is.EqualTo(FieldValueType.Time));
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsTime());
        }

        [Test]
        public void InstantiateFieldValueWithSelectionMarkAndNoValueSelectionMark()
        {
            var fieldValue = new FieldValue(FieldValueType.SelectionMark);

            Assert.That(fieldValue.ValueType, Is.EqualTo(FieldValueType.SelectionMark));
            Assert.Throws<InvalidOperationException>(() => fieldValue.AsSelectionMarkState());
        }
    }
}
