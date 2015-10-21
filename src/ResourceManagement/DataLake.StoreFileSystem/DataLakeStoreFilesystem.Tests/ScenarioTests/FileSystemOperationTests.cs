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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Hyak.Common;
using Microsoft.Azure.Management.DataLake.StoreFileSystem;
using Microsoft.Azure.Management.DataLake.StoreFileSystem.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace DataLakeStoreFileSystem.Tests
{
    public class FileSystemOperationTests : TestBase, IUseFixture<CommonTestFixture>
    {
        private CommonTestFixture commonData;
        private DataLakeStoreFileSystemManagementClient dataLakeStoreFileSystemClient;
        private DataLakeStoreFileSystemManagementHelper helper;

        #region SDK Tests

        [Fact]
        public void DataLakeStoreFileSystemFolderCreate()
        {
            try
            {
                TestUtilities.StartTest();
                var folderPath = helper.CreateFolder(commonData.DataLakeStoreFileSystemAccountName, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, folderPath, FileType.Directory, 0);
            }
            finally
            {
                TestUtilities.EndTest();
            }
           
        }

        [Fact]
        public void DataLakeStoreFileSystemListFolderContents()
        {
            try
            {
                TestUtilities.StartTest();
                var folderPath = helper.CreateFolder(commonData.DataLakeStoreFileSystemAccountName, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, folderPath,
                    FileType.Directory, 0);

                var filePath = helper.CreateFile(commonData.DataLakeStoreFileSystemAccountName, false, true, folderPath);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File, 0);

                // List all the contents in the folder
                var listFolderResponse = dataLakeStoreFileSystemClient.FileSystem.ListFileStatus(folderPath,
                    commonData.DataLakeStoreFileSystemAccountName, null);
                Assert.Equal(HttpStatusCode.OK, listFolderResponse.StatusCode);

                // We know that this directory is brand new, so the contents should only be the one file.
                Assert.Equal(1, listFolderResponse.FileStatuses.FileStatus.Count);
                Assert.Equal(FileType.File, listFolderResponse.FileStatuses.FileStatus[0].Type);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeStoreFileSystemEmptyFileCreate()
        {
            try
            {
                TestUtilities.StartTest();
                var filePath = helper.CreateFile(commonData.DataLakeStoreFileSystemAccountName, false, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File, 0);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeStoreFileSystemEmptyFileDirectCreate()
        {
            try
            {
                TestUtilities.StartTest();
                var filePath = helper.CreateFile(commonData.DataLakeStoreFileSystemAccountName, false, true, useDirectCreate: true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File, 0);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeStoreFileSystemFileCreateWithContents()
        {
            try
            {
                TestUtilities.StartTest();
                var filePath = helper.CreateFile(commonData.DataLakeStoreFileSystemAccountName, true, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File,
                    DataLakeStoreFileSystemManagementHelper.fileContentsToAdd.Length);
                helper.CompareFileContents(commonData.DataLakeStoreFileSystemAccountName, filePath,
                    DataLakeStoreFileSystemManagementHelper.fileContentsToAdd);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeStoreFileSystemFileDirectCreateWithContents()
        {
            try
            {
                TestUtilities.StartTest();
                var filePath = helper.CreateFile(commonData.DataLakeStoreFileSystemAccountName, true, true, useDirectCreate: true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File,
                    DataLakeStoreFileSystemManagementHelper.fileContentsToAdd.Length);
                helper.CompareFileContents(commonData.DataLakeStoreFileSystemAccountName, filePath,
                    DataLakeStoreFileSystemManagementHelper.fileContentsToAdd, true);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeStoreFileSystemAppendToFile()
        {
            try
            {
                TestUtilities.StartTest();
                var filePath = helper.CreateFile(commonData.DataLakeStoreFileSystemAccountName, false, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File, 0);

                // Append to the file that we created
                var beginAppendResponse = dataLakeStoreFileSystemClient.FileSystem.BeginAppend(filePath,
                    commonData.DataLakeStoreFileSystemAccountName, null);
                Assert.Equal(HttpStatusCode.TemporaryRedirect, beginAppendResponse.StatusCode);
                Assert.True(!string.IsNullOrEmpty(beginAppendResponse.Location));

                var appendResponse = dataLakeStoreFileSystemClient.FileSystem.Append(beginAppendResponse.Location,
                    new MemoryStream(Encoding.UTF8.GetBytes(DataLakeStoreFileSystemManagementHelper.fileContentsToAppend)));
                Assert.Equal(HttpStatusCode.OK, appendResponse.StatusCode);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File,
                    DataLakeStoreFileSystemManagementHelper.fileContentsToAppend.Length);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeStoreFileSystemDirectAppendToFile()
        {
            try
            {
                TestUtilities.StartTest();
                var filePath = helper.CreateFile(commonData.DataLakeStoreFileSystemAccountName, false, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File, 0);

                // Append to the file that we created
                var appendResponse = dataLakeStoreFileSystemClient.FileSystem.DirectAppend(filePath,
                    commonData.DataLakeStoreFileSystemAccountName, new MemoryStream(Encoding.UTF8.GetBytes(DataLakeStoreFileSystemManagementHelper.fileContentsToAppend)), null);
                Assert.Equal(HttpStatusCode.OK, appendResponse.StatusCode);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File,
                    DataLakeStoreFileSystemManagementHelper.fileContentsToAppend.Length);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeStoreFileSystemConcatenateFiles()
        {
            try
            {
                TestUtilities.StartTest();
                var filePath1 = helper.CreateFile(commonData.DataLakeStoreFileSystemAccountName, true, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, filePath1, FileType.File,
                    DataLakeStoreFileSystemManagementHelper.fileContentsToAdd.Length);

                var filePath2 = helper.CreateFile(commonData.DataLakeStoreFileSystemAccountName, true, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, filePath2, FileType.File,
                    DataLakeStoreFileSystemManagementHelper.fileContentsToAdd.Length);

                var targetFolder = helper.CreateFolder(commonData.DataLakeStoreFileSystemAccountName, true);

                var concatResponse =
                    dataLakeStoreFileSystemClient.FileSystem.Concat(
                        string.Format("{0}/{1}", targetFolder, DataLakeStoreFileSystemManagementHelper.fileToConcatTo),
                        commonData.DataLakeStoreFileSystemAccountName, string.Format("{0},{1}", filePath1, filePath2));
                Assert.Equal(HttpStatusCode.OK, concatResponse.StatusCode);

                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName,
                    string.Format("{0}/{1}", targetFolder, DataLakeStoreFileSystemManagementHelper.fileToConcatTo),
                    FileType.File,
                    DataLakeStoreFileSystemManagementHelper.fileContentsToAdd.Length*2);

                // Attempt to get the files that were concatted together, which should fail and throw
                Assert.Throws(typeof (CloudException),
                    () =>
                        dataLakeStoreFileSystemClient.FileSystem.GetFileStatus(filePath1,
                            commonData.DataLakeStoreFileSystemAccountName));
                Assert.Throws(typeof (CloudException),
                    () =>
                        dataLakeStoreFileSystemClient.FileSystem.GetFileStatus(filePath2,
                            commonData.DataLakeStoreFileSystemAccountName));
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeStoreFileSystemMsConcatenateFiles()
        {
            try
            {
                TestUtilities.StartTest();
                var filePath1 = helper.CreateFile(commonData.DataLakeStoreFileSystemAccountName, true, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, filePath1, FileType.File,
                    DataLakeStoreFileSystemManagementHelper.fileContentsToAdd.Length);

                var filePath2 = helper.CreateFile(commonData.DataLakeStoreFileSystemAccountName, true, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, filePath2, FileType.File,
                    DataLakeStoreFileSystemManagementHelper.fileContentsToAdd.Length);

                var targetFolder = helper.CreateFolder(commonData.DataLakeStoreFileSystemAccountName, true);

                var concatResponse =
                    dataLakeStoreFileSystemClient.FileSystem.MsConcat(
                        string.Format("{0}/{1}", targetFolder, DataLakeStoreFileSystemManagementHelper.fileToConcatTo),
                        commonData.DataLakeStoreFileSystemAccountName, new MemoryStream(Encoding.UTF8.GetBytes(string.Format("sources={0},{1}", filePath1, filePath2))), null);
                Assert.Equal(HttpStatusCode.OK, concatResponse.StatusCode);

                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName,
                    string.Format("{0}/{1}", targetFolder, DataLakeStoreFileSystemManagementHelper.fileToConcatTo),
                    FileType.File,
                    DataLakeStoreFileSystemManagementHelper.fileContentsToAdd.Length * 2);

                // Attempt to get the files that were concatted together, which should fail and throw
                Assert.Throws(typeof(CloudException),
                    () =>
                        dataLakeStoreFileSystemClient.FileSystem.GetFileStatus(filePath1,
                            commonData.DataLakeStoreFileSystemAccountName));
                Assert.Throws(typeof(CloudException),
                    () =>
                        dataLakeStoreFileSystemClient.FileSystem.GetFileStatus(filePath2,
                            commonData.DataLakeStoreFileSystemAccountName));
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeStoreFileSystemMsConcatDeleteDir()
        {
            try
            {
                TestUtilities.StartTest();
                var concatFolderPath = string.Format("{0}/{1}", DataLakeStoreFileSystemManagementHelper.folderToCreate,
                    "msconcatFolder");
                var filePath1 = helper.CreateFile(commonData.DataLakeStoreFileSystemAccountName, true, true, concatFolderPath);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, filePath1, FileType.File,
                    DataLakeStoreFileSystemManagementHelper.fileContentsToAdd.Length);

                var filePath2 = helper.CreateFile(commonData.DataLakeStoreFileSystemAccountName, true, true, concatFolderPath);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, filePath2, FileType.File,
                    DataLakeStoreFileSystemManagementHelper.fileContentsToAdd.Length);

                var targetFolder = helper.CreateFolder(commonData.DataLakeStoreFileSystemAccountName, true);

                var concatResponse =
                    dataLakeStoreFileSystemClient.FileSystem.MsConcat(
                        string.Format("{0}/{1}", targetFolder, DataLakeStoreFileSystemManagementHelper.fileToConcatTo),
                        commonData.DataLakeStoreFileSystemAccountName, new MemoryStream(Encoding.UTF8.GetBytes(string.Format("sources={0},{1}", filePath1, filePath2))), true);
                Assert.Equal(HttpStatusCode.OK, concatResponse.StatusCode);

                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName,
                    string.Format("{0}/{1}", targetFolder, DataLakeStoreFileSystemManagementHelper.fileToConcatTo),
                    FileType.File,
                    DataLakeStoreFileSystemManagementHelper.fileContentsToAdd.Length * 2);

                // Attempt to get the files that were concatted together, which should fail and throw
                Assert.Throws(typeof(CloudException),
                    () =>
                        dataLakeStoreFileSystemClient.FileSystem.GetFileStatus(filePath1,
                            commonData.DataLakeStoreFileSystemAccountName));
                Assert.Throws(typeof(CloudException),
                    () =>
                        dataLakeStoreFileSystemClient.FileSystem.GetFileStatus(filePath2,
                            commonData.DataLakeStoreFileSystemAccountName));
                
                // Attempt to get the folder that was created for concat, which should fail and be deleted.
                Assert.Throws(typeof(CloudException),
                    () =>
                        dataLakeStoreFileSystemClient.FileSystem.GetFileStatus(concatFolderPath,
                            commonData.DataLakeStoreFileSystemAccountName));
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeStoreFileSystemMoveFileAndFolder()
        {
            try
            {
                TestUtilities.StartTest();
                var filePath = helper.CreateFile(commonData.DataLakeStoreFileSystemAccountName, true, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File,
                    DataLakeStoreFileSystemManagementHelper.fileContentsToAdd.Length);

                var targetFolder1 = helper.CreateFolder(commonData.DataLakeStoreFileSystemAccountName, true);
                var targetFolder2 = TestUtilities.GenerateName(DataLakeStoreFileSystemManagementHelper.folderToMove);

                // Move file first
                var moveFileResponse = dataLakeStoreFileSystemClient.FileSystem.Rename(filePath,
                    commonData.DataLakeStoreFileSystemAccountName,
                    string.Format("{0}/{1}", targetFolder1, DataLakeStoreFileSystemManagementHelper.fileToMove));
                Assert.Equal(HttpStatusCode.OK, moveFileResponse.StatusCode);
                Assert.True(moveFileResponse.OperationResult);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName,
                    string.Format("{0}/{1}", targetFolder1, DataLakeStoreFileSystemManagementHelper.fileToMove),
                    FileType.File,
                    DataLakeStoreFileSystemManagementHelper.fileContentsToAdd.Length);

                // Ensure the old file is gone
                Assert.Throws(typeof (CloudException),
                    () =>
                        dataLakeStoreFileSystemClient.FileSystem.GetFileStatus(filePath,
                            commonData.DataLakeStoreFileSystemAccountName));

                // Now move folder completely.
                var moveFolderResponse = dataLakeStoreFileSystemClient.FileSystem.Rename(targetFolder1,
                    commonData.DataLakeStoreFileSystemAccountName, targetFolder2);
                Assert.Equal(HttpStatusCode.OK, moveFolderResponse.StatusCode);
                Assert.True(moveFolderResponse.OperationResult);

                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, targetFolder2,
                    FileType.Directory, 0);

                // ensure all the contents of the folder moved
                // List all the contents in the folder
                var listFolderResponse = dataLakeStoreFileSystemClient.FileSystem.ListFileStatus(targetFolder2,
                    commonData.DataLakeStoreFileSystemAccountName, null);
                Assert.Equal(HttpStatusCode.OK, listFolderResponse.StatusCode);

                // We know that this directory is brand new, so the contents should only be the one file.
                Assert.Equal(1, listFolderResponse.FileStatuses.FileStatus.Count);
                Assert.Equal(FileType.File, listFolderResponse.FileStatuses.FileStatus[0].Type);

                Assert.Throws(typeof (CloudException),
                    () =>
                        dataLakeStoreFileSystemClient.FileSystem.GetFileStatus(targetFolder1,
                            commonData.DataLakeStoreFileSystemAccountName));
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeStoreFileSystemDeleteFolder()
        {
            try
            {
                TestUtilities.StartTest();
                var folderPath = helper.CreateFolder(commonData.DataLakeStoreFileSystemAccountName, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, folderPath,
                    FileType.Directory, 0);
                helper.DeleteFolder(commonData.DataLakeStoreFileSystemAccountName, folderPath, true, false);
                //WORK AROUND: Bug 4717659 makes it so even empty folders have contents.

                // delete again expecting failure.
                helper.DeleteFolder(commonData.DataLakeStoreFileSystemAccountName, folderPath, false, true);

                // delete a folder with contents
                var filePath = helper.CreateFile(commonData.DataLakeStoreFileSystemAccountName, true, true, folderPath);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File,
                    DataLakeStoreFileSystemManagementHelper.fileContentsToAdd.Length);

                // should fail if recurse is not set
                helper.DeleteFolder(commonData.DataLakeStoreFileSystemAccountName, folderPath, false, true);

                // Now actually delete
                helper.DeleteFolder(commonData.DataLakeStoreFileSystemAccountName, folderPath, true, false);

                // delete again expecting failure.
                helper.DeleteFolder(commonData.DataLakeStoreFileSystemAccountName, folderPath, true, true);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeStoreFileSystemDeleteFile()
        {
            try
            {
                TestUtilities.StartTest();
                var filePath = helper.CreateFile(commonData.DataLakeStoreFileSystemAccountName, true, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File,
                    DataLakeStoreFileSystemManagementHelper.fileContentsToAdd.Length);
                helper.DeleteFile(commonData.DataLakeStoreFileSystemAccountName, filePath, false);

                // try to delete it again, which should fail
                helper.DeleteFile(commonData.DataLakeStoreFileSystemAccountName, filePath, true);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeStoreFileSystemGetAndSetAcl()
        {
            try
            {
                TestUtilities.StartTest();
                var currentAcl = dataLakeStoreFileSystemClient.FileSystem.GetAclStatus("/",
                    commonData.DataLakeStoreFileSystemAccountName);

                Assert.True(currentAcl.StatusCode == HttpStatusCode.OK);

                var aclToReplaceWith = new List<string>(currentAcl.AclStatus.Entries);
                var originalOther = string.Empty;
                var toReplace = "other::rwx";
                for (var i = 0; i < aclToReplaceWith.Count; i++)
                {
                    if (aclToReplaceWith[i].StartsWith("other"))
                    {
                        originalOther = aclToReplaceWith[i];
                        aclToReplaceWith[i] = toReplace;
                        break;
                    }
                }

                Assert.False(string.IsNullOrEmpty(originalOther));

                // Set the other acl to RWX
                var setAclResponse = dataLakeStoreFileSystemClient.FileSystem.SetAcl("/", commonData.DataLakeStoreFileSystemAccountName,
                    string.Join(",", aclToReplaceWith));

                Assert.True(setAclResponse.StatusCode == HttpStatusCode.OK);
                var newAcl = dataLakeStoreFileSystemClient.FileSystem.GetAclStatus("/",
                    commonData.DataLakeStoreFileSystemAccountName);
                // verify the ACL actually changed
                
                // Check the access first and assert that it returns OK (note: this is currently only for the user making the request, so it is not testing "other")
                var accessCheckResponse = dataLakeStoreFileSystemClient.FileSystem.CheckAccess("/",
                    commonData.DataLakeStoreFileSystemAccountName, "rwx");

                Assert.True(accessCheckResponse.StatusCode == HttpStatusCode.OK);

                var foundIt = false;
                foreach (var entry in newAcl.AclStatus.Entries.Where(entry => entry.StartsWith("other")))
                {
                    foundIt = true;
                    Assert.Equal(toReplace, entry);
                    break;
                }

                Assert.True(foundIt);

                // Set it back using specific entry
                var setAclEntryResponse = dataLakeStoreFileSystemClient.FileSystem.ModifyAclEntries("/",
                    commonData.DataLakeStoreFileSystemAccountName, originalOther);
                Assert.True(setAclEntryResponse.StatusCode == HttpStatusCode.OK);

                // Now confirm that it equals the original ACL
                var finalEntries = dataLakeStoreFileSystemClient.FileSystem.GetAclStatus("/",
                    commonData.DataLakeStoreFileSystemAccountName)
                    .AclStatus.Entries;
                foreach (var entry in finalEntries)
                {
                    Assert.True(
                        currentAcl.AclStatus.Entries.Any(
                            original => original.Equals(entry, StringComparison.InvariantCultureIgnoreCase)));
                }

                Assert.Equal(finalEntries.Count, currentAcl.AclStatus.Entries.Count);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeStoreFileSystemSetFileProperties()
        {
            // This test simply tests that all bool/empty return actions return successfully
            try
            {
                TestUtilities.StartTest();
                var filePath = helper.CreateFile(commonData.DataLakeStoreFileSystemAccountName, true, true);
                var originalFileStatus =
                    dataLakeStoreFileSystemClient.FileSystem.GetFileStatus(filePath, commonData.DataLakeStoreFileSystemAccountName)
                        .FileStatus;
                // Set replication on file
                var replicationResponse = dataLakeStoreFileSystemClient.FileSystem.SetReplication(filePath,
                    commonData.DataLakeStoreFileSystemAccountName, 3);
                Assert.True(replicationResponse.StatusCode == HttpStatusCode.OK && replicationResponse.OperationResult);

                /*
                 * This API is available but all values put into it are ignored. Commenting this out until this API is fully functional.
                Assert.Equal(3,
                    dataLakeFileSystemClient.FileSystem.GetFileStatus(filePath, commonData.DataLakeStoreFileSystemAccountName)
                        .FileStatus.Replication);
                */

                // set the time on the file
                var timeToSet = DateTime.UtcNow.Ticks + 2;
                var timeResponse = dataLakeStoreFileSystemClient.FileSystem.SetTimes(filePath,
                    commonData.DataLakeStoreFileSystemAccountName, timeToSet, timeToSet);
                Assert.True(timeResponse.StatusCode == HttpStatusCode.OK);

                var fileStatusAfterTime =
                    dataLakeStoreFileSystemClient.FileSystem.GetFileStatus(filePath, commonData.DataLakeStoreFileSystemAccountName)
                        .FileStatus;

                /*
                 * This API is available but all values put into it are ignored. Commenting this out until this API is fully functional.
                Assert.True(
                    fileStatusAfterTime.ModificationTime == timeToSet && fileStatusAfterTime.AccessTime == timeToSet);
                */

                // Symlink creation is explicitly not supported.
                var symLinkName = TestUtilities.GenerateName("testPath/symlinktest1");
                Assert.Throws<CloudException>(() => dataLakeStoreFileSystemClient.FileSystem.CreateSymLink(filePath,
                    commonData.DataLakeStoreFileSystemAccountName, symLinkName, true));

                // Once symlinks are available, remove the throws test and uncomment out this code.
                // Assert.True(createSymLinkResponse.StatusCode == HttpStatusCode.OK);
                // Assert.DoesNotThrow(() => dataLakeFileSystemClient.FileSystem.GetFileStatus(symLinkName, commonData.DataLakeStoreFileSystemAccountName));
                
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        #endregion

        public void SetFixture(CommonTestFixture data)
        {
            data.Instantiate(TestUtilities.GetCallingClass());
            commonData = data;
            dataLakeStoreFileSystemClient = this.GetDataLakeStoreFileSystemManagementClient();
            helper = new DataLakeStoreFileSystemManagementHelper(this);
        }
    }
}
