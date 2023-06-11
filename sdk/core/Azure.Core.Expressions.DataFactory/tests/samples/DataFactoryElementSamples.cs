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

            #region Snippet:DataFactoryElementSecureString
            blobDataSet.FolderPath = DataFactoryElement<string>.FromMaskedString("some/secret/path");
            #endregion

            Assert.AreEqual("some/secret/path", blobDataSet.FolderPath.ToString());

            #region Snippet:DataFactoryElementKeyVaultSecretReference
            blobDataSet.FolderPath = DataFactoryElement<string>.FromKeyVaultSecretReference("@Microsoft.KeyVault(SecretUri=https://myvault.vault.azure.net/secrets/mysecret/)");
            #endregion

            Assert.AreEqual("@Microsoft.KeyVault(SecretUri=https://myvault.vault.azure.net/secrets/mysecret/)", blobDataSet.FolderPath.ToString());
        }

        private class BlobDataSet
        {
            public DataFactoryElement<string> FolderPath { get; set; }
        }
    }
}