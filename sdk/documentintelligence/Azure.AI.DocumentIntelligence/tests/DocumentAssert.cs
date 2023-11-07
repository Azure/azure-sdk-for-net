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
    }
}
