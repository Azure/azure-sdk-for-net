// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="DocumentField"/> class.
    /// </summary>
    public class DocumentFieldTests
    {
        [Test]
        public void InstantiateDocumentFieldWithInt64AndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.Int64);

            Assert.AreEqual(DocumentFieldType.Int64, field.ValueType);
            Assert.Throws<InvalidOperationException>(() => field.AsInt64());
        }

        [Test]
        public void InstantiateDocumentFieldWithDoubleAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.Double);

            Assert.AreEqual(DocumentFieldType.Double, field.ValueType);
            Assert.Throws<InvalidOperationException>(() => field.AsDouble());
        }

        [Test]
        public void InstantiateDocumentFieldWithDateAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.Date);

            Assert.AreEqual(DocumentFieldType.Date, field.ValueType);
            Assert.Throws<InvalidOperationException>(() => field.AsDate());
        }

        [Test]
        public void InstantiateDocumentFieldWithTimeAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.Time);

            Assert.AreEqual(DocumentFieldType.Time, field.ValueType);
            Assert.Throws<InvalidOperationException>(() => field.AsTime());
        }

        [Test]
        public void InstantiateDocumentFieldWithSelectionMarkAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.SelectionMark);

            Assert.AreEqual(DocumentFieldType.SelectionMark, field.ValueType);
            Assert.Throws<InvalidOperationException>(() => field.AsSelectionMarkState());
        }

        [Test]
        public void InstantiateDocumentFieldWithSignatureTypeAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.Signature);

            Assert.AreEqual(DocumentFieldType.Signature, field.ValueType);
            Assert.Throws<InvalidOperationException>(() => field.AsSignatureType());
        }
    }
}
