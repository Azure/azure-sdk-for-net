// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.Expressions.DataFactory.Samples
{
    public class DataFactoryElementSamples
    {
        [Test]
        public void DataFactoryElementSample()
        {
            var blobDataSet = new BlobDataSet();
            #region Snippet:DataFactoryElementLiteral
            blobDataSet.FolderPath = "foo/bar";
            #endregion

            Assert.That(blobDataSet.FolderPath.ToString(), Is.EqualTo("foo/bar"));

            #region Snippet:DataFactoryElementFromExpression
            blobDataSet.FolderPath = DataFactoryElement<string>.FromExpression("foo/bar-@{pipeline().TriggerTime}");
            #endregion

            Assert.That(blobDataSet.FolderPath.ToString(), Is.EqualTo("foo/bar-@{pipeline().TriggerTime}"));

            #region Snippet:DataFactoryElementSecretString
            blobDataSet.FolderPath = DataFactoryElement<string>.FromSecretString("some/secret/path");
            #endregion

            Assert.That(blobDataSet.FolderPath.ToString(), Is.EqualTo("some/secret/path"));

            #region Snippet:DataFactoryElementKeyVaultSecretReference
            var store = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceKind.LinkedServiceReference,
                "referenceName");
            var keyVaultReference = new DataFactoryKeyVaultSecret(store, "secretName");
            blobDataSet.FolderPath = DataFactoryElement<string>.FromKeyVaultSecret(keyVaultReference);
            #endregion

            Assert.That(blobDataSet.FolderPath.ToString(), Is.EqualTo("secretName"));
        }

        private class BlobDataSet
        {
            public DataFactoryElement<string> FolderPath { get; set; }
        }
    }
}
