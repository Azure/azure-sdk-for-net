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

            Assert.Multiple(() =>
            {
                Assert.That(field.ExpectedFieldType, Is.EqualTo(DocumentFieldType.Address));
                Assert.That(field.FieldType, Is.EqualTo(DocumentFieldType.Unknown));
            });
            Assert.Throws<InvalidOperationException>(() => field.Value.AsAddress());
        }

        [Test]
        public void InstantiateDocumentFieldWithBooleanAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.Boolean);

            Assert.Multiple(() =>
            {
                Assert.That(field.ExpectedFieldType, Is.EqualTo(DocumentFieldType.Boolean));
                Assert.That(field.FieldType, Is.EqualTo(DocumentFieldType.Unknown));
            });
            Assert.Throws<InvalidOperationException>(() => field.Value.AsBoolean());
        }

        [Test]
        public void InstantiateDocumentFieldWithCountryRegionAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.CountryRegion);

            Assert.Multiple(() =>
            {
                Assert.That(field.ExpectedFieldType, Is.EqualTo(DocumentFieldType.CountryRegion));
                Assert.That(field.FieldType, Is.EqualTo(DocumentFieldType.Unknown));
            });
            Assert.Throws<InvalidOperationException>(() => field.Value.AsCountryRegion());
        }

        [Test]
        public void InstantiateDocumentFieldWithInt64AndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.Int64);

            Assert.Multiple(() =>
            {
                Assert.That(field.ExpectedFieldType, Is.EqualTo(DocumentFieldType.Int64));
                Assert.That(field.FieldType, Is.EqualTo(DocumentFieldType.Unknown));
            });
            Assert.Throws<InvalidOperationException>(() => field.Value.AsInt64());
        }

        [Test]
        public void InstantiateDocumentFieldWithDoubleAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.Double);

            Assert.Multiple(() =>
            {
                Assert.That(field.ExpectedFieldType, Is.EqualTo(DocumentFieldType.Double));
                Assert.That(field.FieldType, Is.EqualTo(DocumentFieldType.Unknown));
            });
            Assert.Throws<InvalidOperationException>(() => field.Value.AsDouble());
        }

        [Test]
        public void InstantiateDocumentFieldWithDateAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.Date);

            Assert.Multiple(() =>
            {
                Assert.That(field.ExpectedFieldType, Is.EqualTo(DocumentFieldType.Date));
                Assert.That(field.FieldType, Is.EqualTo(DocumentFieldType.Unknown));
            });
            Assert.Throws<InvalidOperationException>(() => field.Value.AsDate());
        }

        [Test]
        public void InstantiateDocumentFieldWithPhoneNumberAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.PhoneNumber);

            Assert.Multiple(() =>
            {
                Assert.That(field.ExpectedFieldType, Is.EqualTo(DocumentFieldType.PhoneNumber));
                Assert.That(field.FieldType, Is.EqualTo(DocumentFieldType.Unknown));
            });
            Assert.Throws<InvalidOperationException>(() => field.Value.AsPhoneNumber());
        }

        [Test]
        public void InstantiateDocumentFieldWithTimeAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.Time);

            Assert.Multiple(() =>
            {
                Assert.That(field.ExpectedFieldType, Is.EqualTo(DocumentFieldType.Time));
                Assert.That(field.FieldType, Is.EqualTo(DocumentFieldType.Unknown));
            });
            Assert.Throws<InvalidOperationException>(() => field.Value.AsTime());
        }

        [Test]
        public void InstantiateDocumentFieldWithSelectionMarkAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.SelectionMark);

            Assert.Multiple(() =>
            {
                Assert.That(field.ExpectedFieldType, Is.EqualTo(DocumentFieldType.SelectionMark));
                Assert.That(field.FieldType, Is.EqualTo(DocumentFieldType.Unknown));
            });
            Assert.Throws<InvalidOperationException>(() => field.Value.AsSelectionMarkState());
        }

        [Test]
        public void InstantiateDocumentFieldWithSignatureTypeAndNoValue()
        {
            var field = new DocumentField(DocumentFieldType.Signature);

            Assert.Multiple(() =>
            {
                Assert.That(field.ExpectedFieldType, Is.EqualTo(DocumentFieldType.Signature));
                Assert.That(field.FieldType, Is.EqualTo(DocumentFieldType.Unknown));
            });
            Assert.Throws<InvalidOperationException>(() => field.Value.AsSignatureType());
        }
    }
}
