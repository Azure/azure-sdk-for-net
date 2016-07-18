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
            string existingStorageNameFqdnUri = "wasb://" + containerName +"@" + existingStorageNameFqdn;
            string paramErrorMessage = "Input cannot be empty\r\nParameter name: ";

            // Test for optional storageContainer
            var testStorageInfoOptionalContainer = new AzureStorageInfo(existingStorageNameFqdn, existingStorageKey);
            Assert.Equal(testStorageInfoOptionalContainer.StorageContainer, "");

            var testStorageInfoContainer = new AzureStorageInfo(existingStorageNameFqdn, existingStorageKey, containerName);
            Assert.Equal(testStorageInfoContainer.StorageContainer, containerName);

            // Test storageAccountName is null
            testAndAssert(() =>
                                { return new AzureStorageInfo("", existingStorageKey, containerName); },
                                paramErrorMessage + "storageAccountName"
                         );

            // Test storageAccountKey is null
            testAndAssert(() =>
                                { return new AzureStorageInfo(existingStorageNameFqdn, "", containerName); },
                                paramErrorMessage + "storageAccountKey"
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
            testAndAssert(() =>
                                { return new AzureStorageInfo(existingStorageNameFqdnUri, existingStorageKey); },
                                "Please specify fully qualified storage endpoint without the scheme\r\nParameter name: " + "storageAccountName"
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
            string paramErrorMessage = "Input cannot be empty\r\nParameter name: ";

            // Test Datalake null/empty storageAccount name
            testAndAssert(() =>
                                { return new AzureDataLakeStoreInfo("", "/"); },
                                paramErrorMessage + "storageAccountName"
                         );

            // Test Datalake storageAccount shortname
            var datalakeShortName = new AzureDataLakeStoreInfo(existingDatalakeStorageShortName, "/");
            Assert.Equal(datalakeShortName.StorageAccountName, existingDatalakeStorageNameFqdn);

            // Test Datalake storageAccount FullyQualifiedName
            var datalakeFullName = new AzureDataLakeStoreInfo(existingDatalakeStorageNameFqdn, "/");
            Assert.Equal(datalakeFullName.StorageAccountName, existingDatalakeStorageNameFqdn);

            // Test Datalake storageAccount with url input
            testAndAssert(
                                () => { return new AzureDataLakeStoreInfo(existingDatalakeStorageNameFqdnUri, "/"); },
                                "Please specify fully qualified storage endpoint without the scheme\r\nParameter name: " + "storageAccountName"
                          );

            // Test Datalake null/empty storageRootPath
            testAndAssert(
                                () => { return new AzureDataLakeStoreInfo(existingDatalakeStorageShortName, ""); },
                                "Input cannot be empty\r\nParameter name: " + "storageRootPath"
                          );
        }

        private void testAndAssert(Func<StorageInfo> func, string msg)
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
    }
}
