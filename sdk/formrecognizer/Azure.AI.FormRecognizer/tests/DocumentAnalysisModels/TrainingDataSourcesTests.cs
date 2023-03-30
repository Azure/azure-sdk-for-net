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
            Assert.Throws<ArgumentNullException>(() => new ClassifierDocumentTypeDetails(azureBlobSource: null));
            Assert.Throws<ArgumentNullException>(() => new ClassifierDocumentTypeDetails(azureBlobFileListSource: null));
        }

        [Test]
        public void AzureBlobContentSourceConstructorValidatesArguments()
        {
            Assert.Throws<ArgumentNullException>(() => new AzureBlobContentSource(containerUri: null));
        }

        [Test]
        public void AzureBlobFileListSourceConstructorValidatesArguments()
        {
            var containerUri = new Uri("http://notreal.azure.com/");

            Assert.Throws<ArgumentNullException>(() => new AzureBlobFileListSource(containerUri: null, "fileList"));
            Assert.Throws<ArgumentNullException>(() => new AzureBlobFileListSource(containerUri, fileList: null));
        }
    }
}
