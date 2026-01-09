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
            Assert.Multiple(() =>
            {
                Assert.That(actual.ClassifierId, Is.EqualTo(expected.ClassifierId));
                Assert.That(actual.Description, Is.EqualTo(expected.Description));
                Assert.That(actual.ServiceVersion, Is.EqualTo(expected.ServiceVersion));
                Assert.That(actual.CreatedOn, Is.EqualTo(expected.CreatedOn));
                Assert.That(actual.ExpiresOn, Is.EqualTo(expected.ExpiresOn));
            });

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

            Assert.Multiple(() =>
            {
                Assert.That(actual.Type, Is.EqualTo(expected.Type));
                Assert.That(actual.Description, Is.EqualTo(expected.Description));
                Assert.That(actual.Example, Is.EqualTo(expected.Example));
            });

            AreEqual(expected.Items, actual.Items);
            AreEquivalent(expected.Properties, actual.Properties);
        }

        public static void AreEqual(DocumentModelDetails expected, DocumentModelDetails actual)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actual.ModelId, Is.EqualTo(expected.ModelId));
                Assert.That(actual.Description, Is.EqualTo(expected.Description));
                Assert.That(actual.ServiceVersion, Is.EqualTo(expected.ServiceVersion));
                Assert.That(actual.CreatedOn, Is.EqualTo(expected.CreatedOn));
                Assert.That(actual.ExpiresOn, Is.EqualTo(expected.ExpiresOn));
            });

            Assert.That(actual.Tags, Is.EquivalentTo(expected.Tags));

            AreEquivalent(expected.DocumentTypes, actual.DocumentTypes);
        }

        public static void AreEqual(DocumentTypeDetails expected, DocumentTypeDetails actual)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actual.Description, Is.EqualTo(expected.Description));
                Assert.That(actual.BuildMode, Is.EqualTo(expected.BuildMode));
            });

            Assert.That(actual.FieldConfidence, Is.EquivalentTo(expected.FieldConfidence));

            AreEquivalent(expected.FieldSchema, actual.FieldSchema);
        }

        public static void AreEquivalent(IReadOnlyDictionary<string, ClassifierDocumentTypeDetails> expected, IReadOnlyDictionary<string, ClassifierDocumentTypeDetails> actual)
        {
            Assert.That(actual, Has.Count.EqualTo(expected.Count));

            foreach (string key in expected.Keys)
            {
                ClassifierDocumentTypeDetails docType1 = expected[key];
                ClassifierDocumentTypeDetails docType2 = actual[key];

                Assert.That(docType2.TrainingDataSource.Kind, Is.EqualTo(docType1.TrainingDataSource.Kind));

                if (docType1.TrainingDataSource.Kind == DocumentContentSourceKind.Blob)
                {
                    var source1 = docType1.TrainingDataSource as BlobContentSource;
                    var source2 = docType2.TrainingDataSource as BlobContentSource;

                    // The URI returned by the service does not include query parameters, so we're
                    // making sure they're not included in our comparison.
                    string uri1 = source1.ContainerUri.GetLeftPart(UriPartial.Path);
                    string uri2 = source2.ContainerUri.GetLeftPart(UriPartial.Path);

                    Assert.Multiple(() =>
                    {
                        Assert.That(uri2, Is.EqualTo(uri1));
                        Assert.That(source2.Prefix, Is.EqualTo(source1.Prefix));
                    });
                }
                else if (docType1.TrainingDataSource.Kind == DocumentContentSourceKind.BlobFileList)
                {
                    var source1 = docType1.TrainingDataSource as BlobFileListContentSource;
                    var source2 = docType2.TrainingDataSource as BlobFileListContentSource;

                    // The URI returned by the service does not include query parameters, so we're
                    // making sure they're not included in our comparison.
                    string uri1 = source1.ContainerUri.GetLeftPart(UriPartial.Path);
                    string uri2 = source2.ContainerUri.GetLeftPart(UriPartial.Path);

                    Assert.Multiple(() =>
                    {
                        Assert.That(uri2, Is.EqualTo(uri1));
                        Assert.That(source2.FileList, Is.EqualTo(source1.FileList));
                    });
                }
            }
        }

        public static void AreEquivalent(IReadOnlyDictionary<string, DocumentFieldSchema> expected, IReadOnlyDictionary<string, DocumentFieldSchema> actual)
        {
            Assert.That(actual, Has.Count.EqualTo(expected.Count));

            foreach (string key in expected.Keys)
            {
                DocumentFieldSchema fieldSchema1 = expected[key];
                DocumentFieldSchema fieldSchema2 = actual[key];

                AreEqual(fieldSchema1, fieldSchema2);
            }
        }

        public static void AreEquivalent(IReadOnlyDictionary<string, DocumentTypeDetails> expected, IReadOnlyDictionary<string, DocumentTypeDetails> actual)
        {
            Assert.That(actual, Has.Count.EqualTo(expected.Count));

            foreach (string key in expected.Keys)
            {
                DocumentTypeDetails docType1 = expected[key];
                DocumentTypeDetails docType2 = actual[key];

                AreEqual(docType1, docType2);
            }
        }
    }
}
