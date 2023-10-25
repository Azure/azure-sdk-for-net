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

            Assert.AreEqual("foo/bar", blobDataSet.FolderPath.ToString());

            #region Snippet:DataFactoryElementFromExpression
            blobDataSet.FolderPath = DataFactoryElement<string>.FromExpression("foo/bar-@{pipeline().TriggerTime}");
            #endregion

            Assert.AreEqual("foo/bar-@{pipeline().TriggerTime}", blobDataSet.FolderPath.ToString());

            #region Snippet:DataFactoryElementSecretString
            blobDataSet.FolderPath = DataFactoryElement<string>.FromSecretString("some/secret/path");
            #endregion

            Assert.AreEqual("some/secret/path", blobDataSet.FolderPath.ToString());

            #region Snippet:DataFactoryElementKeyVaultSecretReference
            var store = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceType.LinkedServiceReference,
                "referenceName");
            var keyVaultReference = new DataFactoryKeyVaultSecretReference(store, "secretName");
            blobDataSet.FolderPath = DataFactoryElement<string>.FromKeyVaultSecretReference(keyVaultReference);
            #endregion

            Assert.AreEqual("secretName", blobDataSet.FolderPath.ToString());
        }

        private class BlobDataSet
        {
            public DataFactoryElement<string> FolderPath { get; set; }
        }
    }
}