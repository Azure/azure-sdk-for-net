// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    internal static class DocumentAssert
    {
        public static void AreEqual(DocumentClassifierDetails expected,  DocumentClassifierDetails actual)
        {
            Assert.AreEqual(expected.ClassifierId, actual.ClassifierId);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.ServiceVersion, actual.ServiceVersion);
            Assert.AreEqual(expected.CreatedOn, actual.CreatedOn);
            Assert.AreEqual(expected.ExpiresOn, actual.ExpiresOn);

            AreEquivalent(expected.DocumentTypes, actual.DocumentTypes);
        }

        public static void AreEqual(DocumentFieldSchema expected, DocumentFieldSchema actual)
        {
            if (expected == null)
            {
                Assert.Null(actual);
                return;
            }

            Assert.NotNull(actual);

            Assert.AreEqual(expected.Type, actual.Type);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.Example, actual.Example);

            AreEqual(expected.Items, actual.Items);
            AreEquivalent(expected.Properties, actual.Properties);
        }

        public static void AreEqual(DocumentModelDetails expected, DocumentModelDetails actual)
        {
            Assert.AreEqual(expected.ModelId, actual.ModelId);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.ServiceVersion, actual.ServiceVersion);
            Assert.AreEqual(expected.CreatedOn, actual.CreatedOn);
            Assert.AreEqual(expected.ExpiresOn, actual.ExpiresOn);

            CollectionAssert.AreEquivalent(expected.Tags, actual.Tags);

            AreEquivalent(expected.DocumentTypes, actual.DocumentTypes);
        }

        public static void AreEqual(DocumentTypeDetails expected, DocumentTypeDetails actual)
        {
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.BuildMode, actual.BuildMode);

            CollectionAssert.AreEquivalent(expected.FieldConfidence, actual.FieldConfidence);

            AreEquivalent(expected.FieldSchema, actual.FieldSchema);
        }

        public static void AreEquivalent(IReadOnlyDictionary<string, ClassifierDocumentTypeDetails> expected, IReadOnlyDictionary<string, ClassifierDocumentTypeDetails> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count);

            foreach (string key in expected.Keys)
            {
                ClassifierDocumentTypeDetails docType1 = expected[key];
                ClassifierDocumentTypeDetails docType2 = actual[key];

                Assert.AreEqual(docType1.TrainingDataSource.Kind, docType2.TrainingDataSource.Kind);

                if (docType1.TrainingDataSource.Kind == DocumentContentSourceKind.Blob)
                {
                    var source1 = docType1.TrainingDataSource as BlobContentSource;
                    var source2 = docType2.TrainingDataSource as BlobContentSource;

                    // The URI returned by the service does not include query parameters, so we're
                    // making sure they're not included in our comparison.
                    string uri1 = source1.ContainerUri.GetLeftPart(UriPartial.Path);
                    string uri2 = source2.ContainerUri.GetLeftPart(UriPartial.Path);

                    Assert.AreEqual(uri1, uri2);
                    Assert.AreEqual(source1.Prefix, source2.Prefix);
                }
                else if (docType1.TrainingDataSource.Kind == DocumentContentSourceKind.BlobFileList)
                {
                    var source1 = docType1.TrainingDataSource as BlobFileListContentSource;
                    var source2 = docType2.TrainingDataSource as BlobFileListContentSource;

                    // The URI returned by the service does not include query parameters, so we're
                    // making sure they're not included in our comparison.
                    string uri1 = source1.ContainerUri.GetLeftPart(UriPartial.Path);
                    string uri2 = source2.ContainerUri.GetLeftPart(UriPartial.Path);

                    Assert.AreEqual(uri1, uri2);
                    Assert.AreEqual(source1.FileList, source2.FileList);
                }
            }
        }

        public static void AreEquivalent(IReadOnlyDictionary<string, DocumentFieldSchema> expected, IReadOnlyDictionary<string, DocumentFieldSchema> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count);

            foreach (string key in expected.Keys)
            {
                DocumentFieldSchema fieldSchema1 = expected[key];
                DocumentFieldSchema fieldSchema2 = actual[key];

                AreEqual(fieldSchema1, fieldSchema2);
            }
        }

        public static void AreEquivalent(IReadOnlyDictionary<string, DocumentTypeDetails> expected, IReadOnlyDictionary<string, DocumentTypeDetails> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count);

            foreach (string key in expected.Keys)
            {
                DocumentTypeDetails docType1 = expected[key];
                DocumentTypeDetails docType2 = actual[key];

                AreEqual(docType1, docType2);
            }
        }
    }
}
