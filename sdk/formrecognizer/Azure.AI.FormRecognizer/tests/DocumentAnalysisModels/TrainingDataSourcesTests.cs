// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="ClassifierDocumentTypeDetails"/> and its supported
    /// training data sources.
    /// </summary>
    internal class TrainingDataSourcesTests
    {
        [Test]
        public void ClassifierDocumentTypeDetailsConstructorValidatesArguments()
        {
            Assert.Throws<ArgumentNullException>(() => new ClassifierDocumentTypeDetails(trainingDataSource: null));
        }

        [Test]
        public void AzureBlobContentSourceConstructorValidatesArguments()
        {
            Assert.Throws<ArgumentNullException>(() => new BlobContentSource(containerUri: null));
        }

        [Test]
        public void AzureBlobFileListSourceConstructorValidatesArguments()
        {
            var containerUri = new Uri("http://notreal.azure.com/");

            Assert.Throws<ArgumentNullException>(() => new BlobFileListContentSource(containerUri: null, "fileList"));
            Assert.Throws<ArgumentNullException>(() => new BlobFileListContentSource(containerUri, fileList: null));
        }
    }
}
