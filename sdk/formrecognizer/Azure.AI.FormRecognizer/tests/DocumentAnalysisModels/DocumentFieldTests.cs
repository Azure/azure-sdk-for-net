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
        public void InstantiateDocumentFieldWithAddressAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.Address);

            Assert.AreEqual(DocumentFieldType.Address, field.ExpectedFieldType);
            Assert.AreEqual(DocumentFieldType.Unknown, field.FieldType);
            Assert.Throws<InvalidOperationException>(() => field.Value.AsAddress());
        }

        [Test]
        public void InstantiateDocumentFieldWithBooleanAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.Boolean);

            Assert.AreEqual(DocumentFieldType.Boolean, field.ExpectedFieldType);
            Assert.AreEqual(DocumentFieldType.Unknown, field.FieldType);
            Assert.Throws<InvalidOperationException>(() => field.Value.AsBoolean());
        }

        [Test]
        public void InstantiateDocumentFieldWithCountryRegionAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.CountryRegion);

            Assert.AreEqual(DocumentFieldType.CountryRegion, field.ExpectedFieldType);
            Assert.AreEqual(DocumentFieldType.Unknown, field.FieldType);
            Assert.Throws<InvalidOperationException>(() => field.Value.AsCountryRegion());
        }

        [Test]
        public void InstantiateDocumentFieldWithInt64AndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.Int64);

            Assert.AreEqual(DocumentFieldType.Int64, field.ExpectedFieldType);
            Assert.AreEqual(DocumentFieldType.Unknown, field.FieldType);
            Assert.Throws<InvalidOperationException>(() => field.Value.AsInt64());
        }

        [Test]
        public void InstantiateDocumentFieldWithDoubleAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.Double);

            Assert.AreEqual(DocumentFieldType.Double, field.ExpectedFieldType);
            Assert.AreEqual(DocumentFieldType.Unknown, field.FieldType);
            Assert.Throws<InvalidOperationException>(() => field.Value.AsDouble());
        }

        [Test]
        public void InstantiateDocumentFieldWithDateAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.Date);

            Assert.AreEqual(DocumentFieldType.Date, field.ExpectedFieldType);
            Assert.AreEqual(DocumentFieldType.Unknown, field.FieldType);
            Assert.Throws<InvalidOperationException>(() => field.Value.AsDate());
        }

        [Test]
        public void InstantiateDocumentFieldWithPhoneNumberAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.PhoneNumber);

            Assert.AreEqual(DocumentFieldType.PhoneNumber, field.ExpectedFieldType);
            Assert.AreEqual(DocumentFieldType.Unknown, field.FieldType);
            Assert.Throws<InvalidOperationException>(() => field.Value.AsPhoneNumber());
        }

        [Test]
        public void InstantiateDocumentFieldWithTimeAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.Time);

            Assert.AreEqual(DocumentFieldType.Time, field.ExpectedFieldType);
            Assert.AreEqual(DocumentFieldType.Unknown, field.FieldType);
            Assert.Throws<InvalidOperationException>(() => field.Value.AsTime());
        }

        [Test]
        public void InstantiateDocumentFieldWithSelectionMarkAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.SelectionMark);

            Assert.AreEqual(DocumentFieldType.SelectionMark, field.ExpectedFieldType);
            Assert.AreEqual(DocumentFieldType.Unknown, field.FieldType);
            Assert.Throws<InvalidOperationException>(() => field.Value.AsSelectionMarkState());
        }

        [Test]
        public void InstantiateDocumentFieldWithSignatureTypeAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.Signature);

            Assert.AreEqual(DocumentFieldType.Signature, field.ExpectedFieldType);
            Assert.AreEqual(DocumentFieldType.Unknown, field.FieldType);
            Assert.Throws<InvalidOperationException>(() => field.Value.AsSignatureType());
        }
    }
}
