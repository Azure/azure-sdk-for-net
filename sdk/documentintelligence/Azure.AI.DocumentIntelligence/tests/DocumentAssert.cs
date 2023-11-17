// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.DocumentIntelligence.Tests
{
    internal static class DocumentAssert
    {
        public static void AreEqual(AzureBlobContentSource expected, AzureBlobContentSource actual)
        {
            if (expected == null)
            {
                Assert.That(actual, Is.Null);
                return;
            }

            Assert.That(actual, Is.Not.Null);

            // The URI returned by the service does not include query parameters, so we're
            // making sure they're not included in our comparison.
            string expectedContainerUrl = expected.ContainerUrl.GetLeftPart(UriPartial.Path);
            string containerUrl = actual.ContainerUrl.GetLeftPart(UriPartial.Path);

            Assert.That(containerUrl, Is.EqualTo(expectedContainerUrl));
            Assert.That(actual.Prefix, Is.EqualTo(expected.Prefix));
        }

        public static void AreEqual(AzureBlobFileListContentSource expected, AzureBlobFileListContentSource actual)
        {
            if (expected == null)
            {
                Assert.That(actual, Is.Null);
                return;
            }

            Assert.That(actual, Is.Not.Null);

            // The URI returned by the service does not include query parameters, so we're
            // making sure they're not included in our comparison.
            string expectedContainerUrl = expected.ContainerUrl.GetLeftPart(UriPartial.Path);
            string containerUrl = actual.ContainerUrl.GetLeftPart(UriPartial.Path);

            Assert.That(containerUrl, Is.EqualTo(expectedContainerUrl));
            Assert.That(actual.FileList, Is.EqualTo(expected.FileList));
        }

        public static void AreEqual(DocumentClassifierDetails expected, DocumentClassifierDetails actual)
        {
            Assert.AreEqual(expected.ClassifierId, actual.ClassifierId);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.ApiVersion, actual.ApiVersion);
            Assert.AreEqual(expected.CreatedDateTime, actual.CreatedDateTime);
            Assert.AreEqual(expected.ExpirationDateTime, actual.ExpirationDateTime);

            AreEquivalent(expected.DocTypes, actual.DocTypes);
        }

        public static void AreEqual(DocumentFieldSchema expected, DocumentFieldSchema actual)
        {
            if (expected == null)
            {
                Assert.That(actual, Is.Null);
                return;
            }

            Assert.That(actual, Is.Not.Null);

            Assert.That(actual.Type, Is.EqualTo(expected.Type));
            Assert.That(actual.Description, Is.EqualTo(expected.Description));
            Assert.That(actual.Example, Is.EqualTo(expected.Example));

            AreEqual(expected.Items, actual.Items);
            AreEquivalent(expected.Properties, actual.Properties);
        }

        public static void AreEqual(DocumentModelDetails expected, DocumentModelDetails actual)
        {
            Assert.That(actual.ModelId, Is.EqualTo(expected.ModelId));
            Assert.That(actual.Description, Is.EqualTo(expected.Description));
            Assert.That(actual.ApiVersion, Is.EqualTo(expected.ApiVersion));
            Assert.That(actual.CreatedDateTime, Is.EqualTo(expected.CreatedDateTime));
            Assert.That(actual.ExpirationDateTime, Is.EqualTo(expected.ExpirationDateTime));
            Assert.That(actual.Tags, Is.EquivalentTo(expected.Tags));

            AreEqual(expected.AzureBlobSource, actual.AzureBlobSource);
            AreEqual(expected.AzureBlobFileListSource, actual.AzureBlobFileListSource);

            AreEquivalent(expected.DocTypes, actual.DocTypes);
        }

        public static void AreEqual(DocumentTypeDetails expected, DocumentTypeDetails actual)
        {
            Assert.That(actual.Description, Is.EqualTo(expected.Description));
            Assert.That(actual.BuildMode, Is.EqualTo(expected.BuildMode));
            Assert.That(actual.FieldConfidence, Is.EquivalentTo(expected.FieldConfidence));

            AreEquivalent(expected.FieldSchema, actual.FieldSchema);
        }

        public static void AreEquivalent(IReadOnlyDictionary<string, ClassifierDocumentTypeDetails> expected, IReadOnlyDictionary<string, ClassifierDocumentTypeDetails> actual)
        {
            Assert.That(actual.Count, Is.EqualTo(expected.Count));

            foreach (string key in expected.Keys)
            {
                ClassifierDocumentTypeDetails expectedDocType = expected[key];
                ClassifierDocumentTypeDetails docType = actual[key];

                if (docType.SourceKind != null && expectedDocType.SourceKind != null)
                {
                    Assert.That(docType.SourceKind, Is.EqualTo(expectedDocType.SourceKind));
                }

                AreEqual(docType.AzureBlobSource, expectedDocType.AzureBlobSource);
                AreEqual(docType.AzureBlobFileListSource, expectedDocType.AzureBlobFileListSource);
            }
        }

        public static void AreEquivalent(IReadOnlyDictionary<string, DocumentFieldSchema> expected, IReadOnlyDictionary<string, DocumentFieldSchema> actual)
        {
            Assert.That(actual.Count, Is.EqualTo(expected.Count));

            foreach (string key in expected.Keys)
            {
                DocumentFieldSchema expectedFieldSchema = expected[key];
                DocumentFieldSchema fieldSchema = actual[key];

                AreEqual(expectedFieldSchema, fieldSchema);
            }
        }

        public static void AreEquivalent(IReadOnlyDictionary<string, DocumentTypeDetails> expected, IReadOnlyDictionary<string, DocumentTypeDetails> actual)
        {
            Assert.That(actual.Count, Is.EqualTo(expected.Count));

            foreach (string key in expected.Keys)
            {
                DocumentTypeDetails expectedDocType = expected[key];
                DocumentTypeDetails docType = actual[key];

                AreEqual(expectedDocType, docType);
            }
        }
    }
}
