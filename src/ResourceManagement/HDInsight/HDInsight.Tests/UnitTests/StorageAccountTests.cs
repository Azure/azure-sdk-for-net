using System;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using Xunit;

namespace HDInsight.Tests.UnitTests
{
    public class StorageAccountTests
    {
        [Fact]
        public void TestAzureStorageInfo()
        {
            string existingStorageName = "testblob";
            string existingStorageNameFqdn = "testblob.blob.core.windows.net";
            string mooncakeStorageNameFqdn = "testblob.blob.core.chinacloudapi.cn";
            string existingStorageKey = "testtest==";
            string containerName = "testcontainer";
            string existingStorageNameFqdnUri = string.Format("wasb://{0}@{1}", containerName, existingStorageNameFqdn);

            // Test for optional storageContainer
            var testStorageInfoOptionalContainer = new AzureStorageInfo(existingStorageNameFqdn, existingStorageKey);
            Assert.Equal(testStorageInfoOptionalContainer.StorageContainer, "");

            var testStorageInfoContainer = new AzureStorageInfo(existingStorageNameFqdn, existingStorageKey, containerName);
            Assert.Equal(testStorageInfoContainer.StorageContainer, containerName);

            // Test storageAccountName is null
            TestAndAssert(() =>
                                { return new AzureStorageInfo("", existingStorageKey, containerName); },
                                GetErrorMessage(Constants.ERROR_INPUT_CANNOT_BE_EMPTY, "storageAccountName")
                         );

            // Test storageAccountKey is null
            TestAndAssert(() =>
                                { return new AzureStorageInfo(existingStorageNameFqdn, "", containerName); },
                                GetErrorMessage(Constants.ERROR_INPUT_CANNOT_BE_EMPTY, "storageAccountKey")
                          );

            // Test non-fully-qualified storageAccountName
            var testStorageAccountShortName = new AzureStorageInfo(existingStorageName, existingStorageKey);
            Assert.Equal(testStorageAccountShortName.StorageAccountName, existingStorageNameFqdn);

            // Test fully-qualified storageAccountName
            var testStorageAccountFullyQualifiedName = new AzureStorageInfo(existingStorageNameFqdn, existingStorageKey);
            Assert.Equal(testStorageAccountFullyQualifiedName.StorageAccountName, existingStorageNameFqdn);

            // Test fully-qualified-mooncake storageAccountName
            var testStorageAccountMooncakeFullyQualifiedName = new AzureStorageInfo(mooncakeStorageNameFqdn, existingStorageKey);
            Assert.Equal(testStorageAccountMooncakeFullyQualifiedName.StorageAccountName, mooncakeStorageNameFqdn);

            // Test storageAccountName with url input
            TestAndAssert(() =>
                                { return new AzureStorageInfo(existingStorageNameFqdnUri, existingStorageKey); },
                                GetErrorMessage(Constants.ERROR_SCHEME_SPECIFIED_IN_STORAGE_FQDN, "storageAccountName")
                          );

            // Test for StorageAccountUri
            var testWasbStorageInfo = new AzureStorageInfo(existingStorageNameFqdn, existingStorageKey, containerName);
            Assert.Equal(existingStorageNameFqdnUri, testWasbStorageInfo.StorageAccountUri);
        }

        [Fact]
        public void TestDatalakeStorageInfo()
        {
            string existingDatalakeStorageShortName = "test";
            string existingDatalakeStorageNameFqdn = "test.azuredatalakestore.net";
            string existingDatalakeStorageNameFqdnUri = "adl://" + existingDatalakeStorageNameFqdn;

            // Test Datalake null/empty storageAccount name
            TestAndAssert(() =>
                                { return new AzureDataLakeStoreInfo("", "/"); },
                                GetErrorMessage(Constants.ERROR_INPUT_CANNOT_BE_EMPTY, "storageAccountName")
                         );

            // Test Datalake storageAccount shortname
            var datalakeShortName = new AzureDataLakeStoreInfo(existingDatalakeStorageShortName, "/");
            Assert.Equal(datalakeShortName.StorageAccountName, existingDatalakeStorageNameFqdn);

            // Test Datalake storageAccount FullyQualifiedName
            var datalakeFullName = new AzureDataLakeStoreInfo(existingDatalakeStorageNameFqdn, "/");
            Assert.Equal(datalakeFullName.StorageAccountName, existingDatalakeStorageNameFqdn);

            // Test Datalake storageAccount with url input
            TestAndAssert(
                                () => { return new AzureDataLakeStoreInfo(existingDatalakeStorageNameFqdnUri, "/"); },
                                GetErrorMessage(Constants.ERROR_SCHEME_SPECIFIED_IN_STORAGE_FQDN, "storageAccountName")
                          );

            // Test Datalake null/empty storageRootPath
            TestAndAssert(
                                () => { return new AzureDataLakeStoreInfo(existingDatalakeStorageShortName, ""); },
                                GetErrorMessage(Constants.ERROR_INPUT_CANNOT_BE_EMPTY, "storageRootPath")
                          );
        }

        private void TestAndAssert(Func<StorageInfo> func, string msg)
        {
            try
            {
                func();
            }
            catch (Exception e)
            {
                Assert.Equal(e.Message, msg);
                return;
            }

            Assert.True(false, "Should not come here");
        }

        private string GetErrorMessage(string errorCode, string parameterName)
        {
            return string.Format("{0}\r\nParameter name: {1}", errorCode, parameterName);
        }
    }
}
