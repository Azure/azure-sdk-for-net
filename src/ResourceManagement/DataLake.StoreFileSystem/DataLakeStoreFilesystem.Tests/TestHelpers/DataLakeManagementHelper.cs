using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Management.DataLake.Store.Models;
//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Hyak.Common;
using Microsoft.Azure.Management.DataLake.StoreFileSystem;
using Microsoft.Azure.Management.DataLake.StoreFileSystem.Models;
using Xunit;

namespace DataLakeFileSystem.Tests
{
    public class DataLakeFileSystemManagementHelper
    {
        internal const string folderToCreate = "SDKTestFolder01";
        internal const string folderToMove = "SDKTestMoveFolder01";
        internal const string fileToCreate = "SDKTestFile01.txt";
        internal const string fileToCreateWithContents = "SDKTestFile02.txt";
        internal const string fileToCopy = "SDKTestCopyFile01.txt";
        internal const string fileToConcatTo = "SDKTestConcatFile01.txt";
        internal const string fileToMove = "SDKTestMoveFile01.txt";

        internal const string fileContentsToAdd = "These are some random test contents 1234!@";
        internal const string fileContentsToAppend = "More test contents, that were appended!";

        internal readonly ResourceManagementClient resourceManagementClient;
        internal readonly DataLakeStoreManagementClient dataLakeManagementClient;
        internal readonly DataLakeStoreFileSystemManagementClient dataLakeFileSystemClient;
        internal readonly TestBase testBase;

        public DataLakeFileSystemManagementHelper(TestBase testBase)
        {
            this.testBase = testBase;
            resourceManagementClient = this.testBase.GetResourceManagementClient();
            dataLakeManagementClient = this.testBase.GetDataLakeStoreManagementClient();
            dataLakeFileSystemClient = this.testBase.GetDataLakeStoreFileSystemManagementClient();
        }

        public void TryRegisterSubscriptionForResource(string providerName = "Microsoft.DataLake")
        {
            var reg = resourceManagementClient.Providers.Register(providerName);
            ThrowIfTrue(reg == null, "resourceManagementClient.Providers.Register returned null.");
            ThrowIfTrue(reg.StatusCode != HttpStatusCode.OK, string.Format("resourceManagementClient.Providers.Register returned with status code {0}", reg.StatusCode));

            var resultAfterRegister = resourceManagementClient.Providers.Get(providerName);
            ThrowIfTrue(resultAfterRegister == null, "resourceManagementClient.Providers.Get returned null.");
            ThrowIfTrue(string.IsNullOrEmpty(resultAfterRegister.Provider.Id), "Provider.Id is null or empty.");
            ThrowIfTrue(!providerName.Equals(resultAfterRegister.Provider.Namespace), string.Format("Provider name is not equal to {0}.", providerName));
            ThrowIfTrue(ProviderRegistrationState.Registered != resultAfterRegister.Provider.RegistrationState &&
                ProviderRegistrationState.Registering != resultAfterRegister.Provider.RegistrationState,
                string.Format("Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'", resultAfterRegister.Provider.RegistrationState));
            ThrowIfTrue(resultAfterRegister.Provider.ResourceTypes == null || resultAfterRegister.Provider.ResourceTypes.Count == 0, "Provider.ResourceTypes is empty.");
            ThrowIfTrue(resultAfterRegister.Provider.ResourceTypes[0].Locations == null || resultAfterRegister.Provider.ResourceTypes[0].Locations.Count == 0, "Provider.ResourceTypes[0].Locations is empty.");
        }

        public void TryCreateResourceGroup(string resourceGroupName, string location)
        {
            ResourceGroupCreateOrUpdateResult result = resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = location });
            var newlyCreatedGroup = resourceManagementClient.ResourceGroups.Get(resourceGroupName);
            ThrowIfTrue(newlyCreatedGroup == null, "resourceManagementClient.ResourceGroups.Get returned null.");
            ThrowIfTrue(!resourceGroupName.Equals(newlyCreatedGroup.ResourceGroup.Name), string.Format("resourceGroupName is not equal to {0}", resourceGroupName));
        }

        public string TryCreateDataLakeAccount(string resourceGroupName, string location, string accountName)
        {
            var accountCreateResponse = dataLakeManagementClient.DataLakeStoreAccount.Create(resourceGroupName, new DataLakeStoreAccountCreateOrUpdateParameters { DataLakeStoreAccount = new DataLakeStoreAccount { Location = location, Name = accountName } });
            var accountGetResponse = dataLakeManagementClient.DataLakeStoreAccount.Get(resourceGroupName, accountName);
            
            // wait for provisioning state to be Succeeded
            // we will wait a maximum of 15 minutes for this to happen and then report failures
            int timeToWaitInMinutes = 15;
            int minutesWaited = 0;
            while (accountGetResponse.DataLakeStoreAccount.Properties.ProvisioningState != DataLakeStoreAccountStatus.Succeeded && accountGetResponse.DataLakeStoreAccount.Properties.ProvisioningState != DataLakeStoreAccountStatus.Failed && minutesWaited <= timeToWaitInMinutes)
            {
                TestUtilities.Wait(60000); // Wait for one minute and then go again.
                minutesWaited++;
                accountGetResponse = dataLakeManagementClient.DataLakeStoreAccount.Get(resourceGroupName, accountName);
            }

            // Confirm that the account creation did succeed
            ThrowIfTrue(accountGetResponse.DataLakeStoreAccount.Properties.ProvisioningState != DataLakeStoreAccountStatus.Succeeded, "Account failed to be provisioned into the success state after " + timeToWaitInMinutes + " minutes.");

            return accountGetResponse.DataLakeStoreAccount.Properties.Endpoint;
        }

        internal void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            { 
                throw new Exception(message);
            }
        }

        #region helpers
        internal string CreateFolder(string caboAccountName, bool randomName = false)
        {
            // Create a folder
            var random = new Random();
            var folderPath = randomName
                ? string.Format("{0}{1}", folderToCreate, random.Next(1, 10000).ToString("D4"))
                : folderToCreate;

            var response = dataLakeFileSystemClient.FileSystem.Mkdirs(folderPath, caboAccountName, null);
            Assert.True(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created);
            Assert.True(response.OperationResult);

            return folderPath;
        }

        internal string CreateFile(string caboAccountName, bool withContents, bool randomName = false, string folderName = folderToCreate)
        {
            string filePath;
            var random = new Random();
            if (!withContents)
            {
                filePath = string.Format("{0}/{1}{2}", folderName, fileToCreate, randomName ? random.Next(1, 10000).ToString("D4") : string.Empty);

                // Create an empty file
                var beginCreateFileResponse = dataLakeFileSystemClient.FileSystem.BeginCreate(filePath, caboAccountName, null);
                Assert.Equal(HttpStatusCode.TemporaryRedirect, beginCreateFileResponse.StatusCode);
                Assert.True(!string.IsNullOrEmpty(beginCreateFileResponse.Location));

                var createFileResponse = dataLakeFileSystemClient.FileSystem.Create(beginCreateFileResponse.Location, new MemoryStream());
                Assert.True(createFileResponse.StatusCode == HttpStatusCode.OK || createFileResponse.StatusCode == HttpStatusCode.Created);
                Assert.True(!string.IsNullOrEmpty(createFileResponse.Location));
            }
            else
            {
                filePath = string.Format("{0}/{1}{2}", folderName, fileToCreateWithContents, randomName ? random.Next(1, 10000).ToString("D4") : string.Empty);
                // create a file with content
                var beginCreateFileResponse = dataLakeFileSystemClient.FileSystem.BeginCreate(filePath, caboAccountName, null);
                Assert.Equal(HttpStatusCode.TemporaryRedirect, beginCreateFileResponse.StatusCode);
                Assert.True(!string.IsNullOrEmpty(beginCreateFileResponse.Location));

                var createFileResponse = dataLakeFileSystemClient.FileSystem.Create(beginCreateFileResponse.Location, new MemoryStream(Encoding.UTF8.GetBytes(fileContentsToAdd)));
                Assert.True(createFileResponse.StatusCode == HttpStatusCode.OK || createFileResponse.StatusCode == HttpStatusCode.Created);
                Assert.True(!string.IsNullOrEmpty(createFileResponse.Location));
            }

            return filePath;
        }

        internal FileStatusResponse GetAndCompareFileOrFolder(string caboAccountName, string fileOrFolderPath, FileType expectedType, long expectedLength)
        {
            var getResponse = dataLakeFileSystemClient.FileSystem.GetFileStatus(fileOrFolderPath, caboAccountName);
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
            Assert.Equal(expectedLength, getResponse.FileStatus.Length);
            Assert.Equal(expectedType, getResponse.FileStatus.Type);

            return getResponse;
        }

        internal void CompareFileContents(string caboAccountName, string filePath, string expectedContents)
        {
            // download a file and ensure they are equal
            var beginOpenResponse = dataLakeFileSystemClient.FileSystem.BeginOpen(filePath, caboAccountName, null);
            Assert.Equal(HttpStatusCode.TemporaryRedirect, beginOpenResponse.StatusCode);
            Assert.True(!string.IsNullOrEmpty(beginOpenResponse.Location));

            var openResponse = dataLakeFileSystemClient.FileSystem.Open(beginOpenResponse.Location);
            string toCompare = Encoding.UTF8.GetString(openResponse.FileContents);
            Assert.Equal(expectedContents, toCompare);
        }

        internal void DeleteFolder(string caboAccountName, string folderPath, bool recursive, bool failureExpected)
        {
            if (failureExpected)
            {
                // try to delete a folder that doesn't exist or should fail
                try
                {
                    var deleteFolderResponse = dataLakeFileSystemClient.FileSystem.Delete(folderPath, caboAccountName, recursive);
                    Assert.Equal(HttpStatusCode.OK, deleteFolderResponse.StatusCode);
                    Assert.True(!deleteFolderResponse.OperationResult);
                }
                catch (Exception e)
                {
                    Assert.Equal(typeof(CloudException), e.GetType());
                }
            }
            else
            {
                // Delete a folder
                var deleteFolderResponse = dataLakeFileSystemClient.FileSystem.Delete(folderPath, caboAccountName, recursive);
                Assert.Equal(HttpStatusCode.OK, deleteFolderResponse.StatusCode);
                Assert.True(deleteFolderResponse.OperationResult);
            }
        }

        internal void DeleteFile(string caboAccountName, string filePath, bool failureExpected)
        {
            if (failureExpected)
            {
                // try to delete a file that doesn't exist
                try
                {
                    var deleteFileResponse = dataLakeFileSystemClient.FileSystem.Delete(filePath, caboAccountName, false);
                    Assert.Equal(HttpStatusCode.OK, deleteFileResponse.StatusCode);
                    Assert.True(!deleteFileResponse.OperationResult);
                }
                catch (Exception e)
                {
                    Assert.Equal(typeof(CloudException), e.GetType());
                }
            }
            else
            {
                // Delete a file
                var deleteFileResponse = dataLakeFileSystemClient.FileSystem.Delete(filePath, caboAccountName, false);
                Assert.Equal(HttpStatusCode.OK, deleteFileResponse.StatusCode);
                Assert.True(deleteFileResponse.OperationResult);
            }
        }
        #endregion
    }
}
