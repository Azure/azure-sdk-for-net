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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Hyak.Common;
using Microsoft.Azure.Management.DataLake.StoreFileSystem;
using Microsoft.Azure.Management.DataLake.StoreFileSystem.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace DataLakeFileSystem.Tests
{
    public class FileSystemOperationTests : TestBase, IUseFixture<CommonTestFixture>
    {
        private CommonTestFixture commonData;
        private DataLakeStoreFileSystemManagementClient dataLakeFileSystemClient;
        private DataLakeFileSystemManagementHelper helper;

        #region SDK Tests

        [Fact]
        public void DataLakeFileSystemFolderCreate()
        {
            try
            {
                TestUtilities.StartTest();
                var folderPath = helper.CreateFolder(commonData.DataLakeFileSystemAccountName, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeFileSystemAccountName, folderPath, FileType.Directory, 0);
            }
            finally
            {
                TestUtilities.EndTest();
            }
           
        }

        [Fact]
        public void DataLakeFileSystemListFolderContents()
        {
            try
            {
                TestUtilities.StartTest();
                var folderPath = helper.CreateFolder(commonData.DataLakeFileSystemAccountName, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeFileSystemAccountName, folderPath,
                    FileType.Directory, 0);

                var filePath = helper.CreateFile(commonData.DataLakeFileSystemAccountName, false, true, folderPath);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeFileSystemAccountName, filePath, FileType.File, 0);

                // List all the contents in the folder
                var listFolderResponse = dataLakeFileSystemClient.FileSystem.ListFileStatus(folderPath,
                    commonData.DataLakeFileSystemAccountName, null);
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
        public void DataLakeFileSystemEmptyFileCreate()
        {
            try
            {
                TestUtilities.StartTest();
                var filePath = helper.CreateFile(commonData.DataLakeFileSystemAccountName, false, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeFileSystemAccountName, filePath, FileType.File, 0);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeFileSystemFileCreateWithContents()
        {
            try
            {
                TestUtilities.StartTest();
                var filePath = helper.CreateFile(commonData.DataLakeFileSystemAccountName, true, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeFileSystemAccountName, filePath, FileType.File,
                    DataLakeFileSystemManagementHelper.fileContentsToAdd.Length);
                helper.CompareFileContents(commonData.DataLakeFileSystemAccountName, filePath,
                    DataLakeFileSystemManagementHelper.fileContentsToAdd);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeFileSystemAppendToFile()
        {
            try
            {
                TestUtilities.StartTest();
                var filePath = helper.CreateFile(commonData.DataLakeFileSystemAccountName, false, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeFileSystemAccountName, filePath, FileType.File, 0);

                // Append to the file that we created
                var beginAppendResponse = dataLakeFileSystemClient.FileSystem.BeginAppend(filePath,
                    commonData.DataLakeFileSystemAccountName, null);
                Assert.Equal(HttpStatusCode.TemporaryRedirect, beginAppendResponse.StatusCode);
                Assert.True(!string.IsNullOrEmpty(beginAppendResponse.Location));

                var appendResponse = dataLakeFileSystemClient.FileSystem.Append(beginAppendResponse.Location,
                    new MemoryStream(Encoding.UTF8.GetBytes(DataLakeFileSystemManagementHelper.fileContentsToAppend)));
                Assert.Equal(HttpStatusCode.OK, appendResponse.StatusCode);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeFileSystemAccountName, filePath, FileType.File,
                    DataLakeFileSystemManagementHelper.fileContentsToAppend.Length);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeFileSystemConcatenateFiles()
        {
            try
            {
                TestUtilities.StartTest();
                var filePath1 = helper.CreateFile(commonData.DataLakeFileSystemAccountName, true, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeFileSystemAccountName, filePath1, FileType.File,
                    DataLakeFileSystemManagementHelper.fileContentsToAdd.Length);

                var filePath2 = helper.CreateFile(commonData.DataLakeFileSystemAccountName, true, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeFileSystemAccountName, filePath2, FileType.File,
                    DataLakeFileSystemManagementHelper.fileContentsToAdd.Length);

                var targetFolder = helper.CreateFolder(commonData.DataLakeFileSystemAccountName, true);

                var concatResponse =
                    dataLakeFileSystemClient.FileSystem.Concat(
                        string.Format("{0}/{1}", targetFolder, DataLakeFileSystemManagementHelper.fileToConcatTo),
                        commonData.DataLakeFileSystemAccountName, string.Format("{0},{1}", filePath1, filePath2));
                Assert.Equal(HttpStatusCode.OK, concatResponse.StatusCode);

                helper.GetAndCompareFileOrFolder(commonData.DataLakeFileSystemAccountName,
                    string.Format("{0}/{1}", targetFolder, DataLakeFileSystemManagementHelper.fileToConcatTo),
                    FileType.File,
                    DataLakeFileSystemManagementHelper.fileContentsToAdd.Length*2);

                // Attempt to get the files that were concatted together, which should fail and throw
                Assert.Throws(typeof (CloudException),
                    () =>
                        dataLakeFileSystemClient.FileSystem.GetFileStatus(filePath1,
                            commonData.DataLakeFileSystemAccountName));
                Assert.Throws(typeof (CloudException),
                    () =>
                        dataLakeFileSystemClient.FileSystem.GetFileStatus(filePath2,
                            commonData.DataLakeFileSystemAccountName));
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DateLakeFileSystemMoveFileAndFolder()
        {
            try
            {
                TestUtilities.StartTest();
                var filePath = helper.CreateFile(commonData.DataLakeFileSystemAccountName, true, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeFileSystemAccountName, filePath, FileType.File,
                    DataLakeFileSystemManagementHelper.fileContentsToAdd.Length);

                var targetFolder1 = helper.CreateFolder(commonData.DataLakeFileSystemAccountName, true);
                var targetFolder2 = string.Format("{0}{1}", DataLakeFileSystemManagementHelper.folderToMove,
                    new Random().Next(0, 10000).ToString("D4"));

                // Move file first
                var moveFileResponse = dataLakeFileSystemClient.FileSystem.Rename(filePath,
                    commonData.DataLakeFileSystemAccountName,
                    string.Format("{0}/{1}", targetFolder1, DataLakeFileSystemManagementHelper.fileToMove));
                Assert.Equal(HttpStatusCode.OK, moveFileResponse.StatusCode);
                Assert.True(moveFileResponse.OperationResult);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeFileSystemAccountName,
                    string.Format("{0}/{1}", targetFolder1, DataLakeFileSystemManagementHelper.fileToMove),
                    FileType.File,
                    DataLakeFileSystemManagementHelper.fileContentsToAdd.Length);

                // Ensure the old file is gone
                Assert.Throws(typeof (CloudException),
                    () =>
                        dataLakeFileSystemClient.FileSystem.GetFileStatus(filePath,
                            commonData.DataLakeFileSystemAccountName));

                // Now move folder completely.
                var moveFolderResponse = dataLakeFileSystemClient.FileSystem.Rename(targetFolder1,
                    commonData.DataLakeFileSystemAccountName, targetFolder2);
                Assert.Equal(HttpStatusCode.OK, moveFolderResponse.StatusCode);
                Assert.True(moveFolderResponse.OperationResult);

                helper.GetAndCompareFileOrFolder(commonData.DataLakeFileSystemAccountName, targetFolder2,
                    FileType.Directory, 0);

                // ensure all the contents of the folder moved
                // List all the contents in the folder
                var listFolderResponse = dataLakeFileSystemClient.FileSystem.ListFileStatus(targetFolder2,
                    commonData.DataLakeFileSystemAccountName, null);
                Assert.Equal(HttpStatusCode.OK, listFolderResponse.StatusCode);

                // We know that this directory is brand new, so the contents should only be the one file.
                Assert.Equal(1, listFolderResponse.FileStatuses.FileStatus.Count);
                Assert.Equal(FileType.File, listFolderResponse.FileStatuses.FileStatus[0].Type);

                Assert.Throws(typeof (CloudException),
                    () =>
                        dataLakeFileSystemClient.FileSystem.GetFileStatus(targetFolder1,
                            commonData.DataLakeFileSystemAccountName));
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeFileSystemDeleteFolder()
        {
            try
            {
                TestUtilities.StartTest();
                var folderPath = helper.CreateFolder(commonData.DataLakeFileSystemAccountName, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeFileSystemAccountName, folderPath,
                    FileType.Directory, 0);
                helper.DeleteFolder(commonData.DataLakeFileSystemAccountName, folderPath, true, false);
                //WORK AROUND: Bug 4717659 makes it so even empty folders have contents.

                // delete again expecting failure.
                helper.DeleteFolder(commonData.DataLakeFileSystemAccountName, folderPath, false, true);

                // delete a folder with contents
                var filePath = helper.CreateFile(commonData.DataLakeFileSystemAccountName, true, true, folderPath);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeFileSystemAccountName, filePath, FileType.File,
                    DataLakeFileSystemManagementHelper.fileContentsToAdd.Length);

                // should fail if recurse is not set
                helper.DeleteFolder(commonData.DataLakeFileSystemAccountName, folderPath, false, true);

                // Now actually delete
                helper.DeleteFolder(commonData.DataLakeFileSystemAccountName, folderPath, true, false);

                // delete again expecting failure.
                helper.DeleteFolder(commonData.DataLakeFileSystemAccountName, folderPath, true, true);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeFileSystemDeleteFile()
        {
            try
            {
                TestUtilities.StartTest();
                var filePath = helper.CreateFile(commonData.DataLakeFileSystemAccountName, true, true);
                helper.GetAndCompareFileOrFolder(commonData.DataLakeFileSystemAccountName, filePath, FileType.File,
                    DataLakeFileSystemManagementHelper.fileContentsToAdd.Length);
                helper.DeleteFile(commonData.DataLakeFileSystemAccountName, filePath, false);

                // try to delete it again, which should fail
                helper.DeleteFile(commonData.DataLakeFileSystemAccountName, filePath, true);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeFileSystemGetAndSetAcl()
        {
            try
            {
                TestUtilities.StartTest();
                var currentAcl = dataLakeFileSystemClient.FileSystem.GetAclStatus("/",
                    commonData.DataLakeFileSystemAccountName);

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
                var setAclResponse = dataLakeFileSystemClient.FileSystem.SetAcl("/", commonData.DataLakeFileSystemAccountName,
                    string.Join(",", aclToReplaceWith));

                Assert.True(setAclResponse.StatusCode == HttpStatusCode.OK);
                var newAcl = dataLakeFileSystemClient.FileSystem.GetAclStatus("/",
                    commonData.DataLakeFileSystemAccountName);
                // verify the ACL actually changed
                
                // Check the access first and assert that it returns OK (note: this is currently only for the user making the request, so it is not testing "other")
                var accessCheckResponse = dataLakeFileSystemClient.FileSystem.CheckAccess("/",
                    commonData.DataLakeFileSystemAccountName, "rwx");

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
                var setAclEntryResponse = dataLakeFileSystemClient.FileSystem.ModifyAclEntries("/",
                    commonData.DataLakeFileSystemAccountName, originalOther);
                Assert.True(setAclEntryResponse.StatusCode == HttpStatusCode.OK);

                // Now confirm that it equals the original ACL
                var finalEntries = dataLakeFileSystemClient.FileSystem.GetAclStatus("/",
                    commonData.DataLakeFileSystemAccountName)
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
        public void DataLakeFileSystemSetFileProperties()
        {
            // This test simply tests that all bool/empty return actions return successfully
            try
            {
                TestUtilities.StartTest();
                var filePath = helper.CreateFile(commonData.DataLakeFileSystemAccountName, true, true);
                var originalFileStatus =
                    dataLakeFileSystemClient.FileSystem.GetFileStatus(filePath, commonData.DataLakeFileSystemAccountName)
                        .FileStatus;
                // Set replication on file
                var replicationResponse = dataLakeFileSystemClient.FileSystem.SetReplication(filePath,
                    commonData.DataLakeFileSystemAccountName, 3);
                Assert.True(replicationResponse.StatusCode == HttpStatusCode.OK && replicationResponse.OperationResult);

                Assert.Equal(3,
                    dataLakeFileSystemClient.FileSystem.GetFileStatus(filePath, commonData.DataLakeFileSystemAccountName)
                        .FileStatus.Replication);
                
                // set the time on the file
                var timeToSet = DateTime.UtcNow.Ticks + 2;
                var timeResponse = dataLakeFileSystemClient.FileSystem.SetTimes(filePath,
                    commonData.DataLakeFileSystemAccountName, timeToSet, timeToSet);
                Assert.True(timeResponse.StatusCode == HttpStatusCode.OK);

                var fileStatusAfterTime =
                    dataLakeFileSystemClient.FileSystem.GetFileStatus(filePath, commonData.DataLakeFileSystemAccountName)
                        .FileStatus;

                Assert.True(
                    fileStatusAfterTime.ModificationTime == timeToSet && fileStatusAfterTime.AccessTime == timeToSet);
                
                var symLinkName = TestUtilities.GenerateName("testPath/symlinktest1");
                var createSymLinkResponse = dataLakeFileSystemClient.FileSystem.CreateSymLink(filePath,
                    commonData.DataLakeFileSystemAccountName, symLinkName, true);

                Assert.True(createSymLinkResponse.StatusCode == HttpStatusCode.OK);

                Assert.DoesNotThrow(() => dataLakeFileSystemClient.FileSystem.GetFileStatus(symLinkName, commonData.DataLakeFileSystemAccountName));
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        #endregion

        public void SetFixture(CommonTestFixture data)
        {
            commonData = data;
            dataLakeFileSystemClient = this.GetDataLakeStoreFileSystemManagementClient();
            helper = new DataLakeFileSystemManagementHelper(this);
        }
    }
}
