// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.DocumentIntelligence.Tests
{
    internal static class DocumentAssert
    {
        public static void AreEqual(AnalyzeBatchResult expected, AnalyzeBatchResult actual)
        {
            if (expected == null)
            {
                Assert.That(actual, Is.Null);
                return;
            }

            Assert.That(actual, Is.Not.Null);

            Assert.That(actual.SucceededCount, Is.EqualTo(expected.SucceededCount));
            Assert.That(actual.FailedCount, Is.EqualTo(expected.FailedCount));
            Assert.That(actual.SkippedCount, Is.EqualTo(expected.SkippedCount));

            AreEquivalent(expected.Details, actual.Details);
        }

        public static void AreEqual(AnalyzeBatchResultDetails expected, AnalyzeBatchResultDetails actual)
        {
            Assert.That(actual.SourceUri.AbsoluteUri, Is.EqualTo(expected.SourceUri.AbsoluteUri));
            Assert.That(actual.ResultUri.AbsoluteUri, Is.EqualTo(expected.ResultUri.AbsoluteUri));
            Assert.That(actual.Status, Is.EqualTo(expected.Status));

            AreEqual(expected.Error, actual.Error);
        }

        public static void AreEqual(BlobContentSource expected, BlobContentSource actual)
        {
            if (expected == null)
            {
                Assert.That(actual, Is.Null);
                return;
            }

            Assert.That(actual, Is.Not.Null);

            // The URI returned by the service does not include query parameters, so we're
            // making sure they're not included in our comparison.
            string expectedContainerUrl = expected.ContainerUri.GetLeftPart(UriPartial.Path);
            string containerUrl = actual.ContainerUri.GetLeftPart(UriPartial.Path);

            Assert.That(containerUrl, Is.EqualTo(expectedContainerUrl));
            Assert.That(actual.Prefix, Is.EqualTo(expected.Prefix));
        }

        public static void AreEqual(BlobFileListContentSource expected, BlobFileListContentSource actual)
        {
            if (expected == null)
            {
                Assert.That(actual, Is.Null);
                return;
            }

            Assert.That(actual, Is.Not.Null);

            // The URI returned by the service does not include query parameters, so we're
            // making sure they're not included in our comparison.
            string expectedContainerUrl = expected.ContainerUri.GetLeftPart(UriPartial.Path);
            string containerUrl = actual.ContainerUri.GetLeftPart(UriPartial.Path);

            Assert.That(containerUrl, Is.EqualTo(expectedContainerUrl));
            Assert.That(actual.FileList, Is.EqualTo(expected.FileList));
        }

        public static void AreEqual(DocumentClassifierDetails expected, DocumentClassifierDetails actual)
        {
            Assert.AreEqual(expected.ClassifierId, actual.ClassifierId);
            Assert.AreEqual(expected.BaseClassifierId, actual.BaseClassifierId);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.ApiVersion, actual.ApiVersion);
            Assert.AreEqual(expected.CreatedOn, actual.CreatedOn);
            Assert.AreEqual(expected.ExpiresOn, actual.ExpiresOn);

            AreEquivalent(expected.DocumentTypes, actual.DocumentTypes);
        }

        public static void AreEqual(DocumentFieldSchema expected, DocumentFieldSchema actual)
        {
            if (expected == null)
            {
                Assert.That(actual, Is.Null);
                return;
            }

            Assert.That(actual, Is.Not.Null);

            Assert.That(actual.FieldType, Is.EqualTo(expected.FieldType));
            Assert.That(actual.Description, Is.EqualTo(expected.Description));
            Assert.That(actual.Example, Is.EqualTo(expected.Example));

            AreEqual(expected.Items, actual.Items);
            AreEquivalent(expected.Properties, actual.Properties);
        }

        public static void AreEqual(DocumentIntelligenceError expected, DocumentIntelligenceError actual)
        {
            if (expected == null)
            {
                Assert.That(actual, Is.Null);
                return;
            }

            Assert.That(actual, Is.Not.Null);

            Assert.That(actual.Code, Is.EqualTo(expected.Code));
            Assert.That(actual.Message, Is.EqualTo(expected.Message));
            Assert.That(actual.Target, Is.EqualTo(expected.Target));

            AreEquivalent(expected.Details, actual.Details);
            AreEqual(expected.InnerError, actual.InnerError);
        }

        public static void AreEqual(DocumentIntelligenceInnerError expected, DocumentIntelligenceInnerError actual)
        {
            if (expected == null)
            {
                Assert.That(actual, Is.Null);
                return;
            }

            Assert.That(actual, Is.Not.Null);

            Assert.That(actual.Code, Is.EqualTo(expected.Code));
            Assert.That(actual.Message, Is.EqualTo(expected.Message));

            AreEqual(expected.InnerError, actual.InnerError);
        }

        public static void AreEqual(DocumentModelDetails expected, DocumentModelDetails actual)
        {
            Assert.That(actual.ModelId, Is.EqualTo(expected.ModelId));
            Assert.That(actual.Description, Is.EqualTo(expected.Description));
            Assert.That(actual.ApiVersion, Is.EqualTo(expected.ApiVersion));
            Assert.That(actual.CreatedOn, Is.EqualTo(expected.CreatedOn));
            Assert.That(actual.ExpiresOn, Is.EqualTo(expected.ExpiresOn));
            Assert.That(actual.Tags, Is.EquivalentTo(expected.Tags));

            AreEqual(expected.BlobSource, actual.BlobSource);
            AreEqual(expected.BlobFileListSource, actual.BlobFileListSource);

            AreEquivalent(expected.DocumentTypes, actual.DocumentTypes);
        }

        public static void AreEqual(DocumentTypeDetails expected, DocumentTypeDetails actual)
        {
            Assert.That(actual.Description, Is.EqualTo(expected.Description));
            Assert.That(actual.BuildMode, Is.EqualTo(expected.BuildMode));
            Assert.That(actual.FieldConfidence, Is.EquivalentTo(expected.FieldConfidence));

            AreEquivalent(expected.FieldSchema, actual.FieldSchema);
        }

        public static void AreEquivalent(IReadOnlyList<AnalyzeBatchResultDetails> expected, IReadOnlyList<AnalyzeBatchResultDetails> actual)
        {
            Assert.That(actual.Count, Is.EqualTo(expected.Count));

            for (int i = 0; i < actual.Count; i++)
            {
                AreEqual(expected[i], actual[i]);
            }
        }

        public static void AreEquivalent(IReadOnlyList<DocumentIntelligenceError> expected, IReadOnlyList<DocumentIntelligenceError> actual)
        {
            Assert.That(actual.Count, Is.EqualTo(expected.Count));

            for (int i = 0; i < actual.Count; i++)
            {
                AreEqual(expected[i], actual[i]);
            }
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

                AreEqual(docType.BlobSource, expectedDocType.BlobSource);
                AreEqual(docType.BlobFileListSource, expectedDocType.BlobFileListSource);
            }
        }

        public static void AreEquivalent(IDictionary<string, DocumentFieldSchema> expected, IDictionary<string, DocumentFieldSchema> actual)
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
