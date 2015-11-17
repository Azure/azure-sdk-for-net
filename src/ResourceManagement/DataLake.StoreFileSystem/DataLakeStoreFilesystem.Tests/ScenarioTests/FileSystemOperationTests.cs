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
        #region internal constants

        internal const string folderToCreate = "SDKTestFolder01";
        internal const string folderToMove = "SDKTestMoveFolder01";
        internal const string fileToCreate = "SDKTestFile01.txt";
        internal const string fileToCreateWithContents = "SDKTestFile02.txt";
        internal const string fileToCopy = "SDKTestCopyFile01.txt";
        internal const string fileToConcatTo = "SDKTestConcatFile01.txt";
        internal const string fileToMove = "SDKTestMoveFile01.txt";

        internal const string fileContentsToAdd = "These are some random test contents 1234!@";
        internal const string fileContentsToAppend = "More test contents, that were appended!";

        #endregion
        private CommonTestFixture commonData;

        public void SetFixture(CommonTestFixture data)
        {
            commonData = data;
            
        }

        #region SDK Tests

        [Fact]
        public void DataLakeStoreFileSystemFolderCreate()
        {
            try
            {
                UndoContext.Current.Start();
                using (commonData.DataLakeStoreFileSystemClient = commonData.GetDataLakeStoreFileSystemManagementClient())
                {
                    var folderPath = CreateFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, true);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, folderPath,
                        FileType.Directory, 0);
                }
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
                UndoContext.Current.Start();
                using (commonData.DataLakeStoreFileSystemClient = commonData.GetDataLakeStoreFileSystemManagementClient())
                {
                    var folderPath = CreateFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, true);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, folderPath,
                        FileType.Directory, 0);

                    var filePath = CreateFile(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, false, true, folderPath);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File, 0);

                    // List all the contents in the folder
                    var listFolderResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.ListFileStatus(folderPath,
                        commonData.DataLakeStoreFileSystemAccountName, null);
                    Assert.Equal(HttpStatusCode.OK, listFolderResponse.StatusCode);

                    // We know that this directory is brand new, so the contents should only be the one file.
                    Assert.Equal(1, listFolderResponse.FileStatuses.FileStatus.Count);
                    Assert.Equal(FileType.File, listFolderResponse.FileStatuses.FileStatus[0].Type);
                }
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
                UndoContext.Current.Start();
                using (
                    commonData.DataLakeStoreFileSystemClient = commonData.GetDataLakeStoreFileSystemManagementClient())
                {
                    var filePath = CreateFile(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, false, true);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File, 0);
                }
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
                UndoContext.Current.Start();
                using (
                    commonData.DataLakeStoreFileSystemClient = commonData.GetDataLakeStoreFileSystemManagementClient())
                {
                    var filePath = CreateFile(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, false, true,
                        useDirectCreate: true);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File, 0);
                }
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
                UndoContext.Current.Start();
                using (
                    commonData.DataLakeStoreFileSystemClient = commonData.GetDataLakeStoreFileSystemManagementClient())
                {
                    var filePath = CreateFile(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, true, true);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File,
                        fileContentsToAdd.Length);
                    CompareFileContents(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath,
                        fileContentsToAdd);
                }
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
                UndoContext.Current.Start();
                using (
                    commonData.DataLakeStoreFileSystemClient = commonData.GetDataLakeStoreFileSystemManagementClient())
                {
                    var filePath = CreateFile(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, true, true,
                        useDirectCreate: true);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File,
                        fileContentsToAdd.Length);
                    CompareFileContents(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath,
                        fileContentsToAdd, true);
                }
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
                UndoContext.Current.Start();
                using (
                    commonData.DataLakeStoreFileSystemClient = commonData.GetDataLakeStoreFileSystemManagementClient())
                {
                    var filePath = CreateFile(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, false, true);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File, 0);

                    // Append to the file that we created
                    var beginAppendResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.BeginAppend(filePath,
                        commonData.DataLakeStoreFileSystemAccountName, null);
                    Assert.Equal(HttpStatusCode.TemporaryRedirect, beginAppendResponse.StatusCode);
                    Assert.True(!string.IsNullOrEmpty(beginAppendResponse.Location));

                    var appendResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.Append(beginAppendResponse.Location,
                        new MemoryStream(Encoding.UTF8.GetBytes(fileContentsToAppend)));
                    Assert.Equal(HttpStatusCode.OK, appendResponse.StatusCode);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File,
                        fileContentsToAppend.Length);
                }
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
                UndoContext.Current.Start();
                using (
                    commonData.DataLakeStoreFileSystemClient = commonData.GetDataLakeStoreFileSystemManagementClient())
                {
                    var filePath = CreateFile(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, false, true);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File, 0);

                    // Append to the file that we created
                    var appendResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.DirectAppend(filePath,
                        commonData.DataLakeStoreFileSystemAccountName,
                        new MemoryStream(Encoding.UTF8.GetBytes(fileContentsToAppend)), null);
                    Assert.Equal(HttpStatusCode.OK, appendResponse.StatusCode);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File,
                        fileContentsToAppend.Length);
                }
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
                UndoContext.Current.Start();
                using (
                    commonData.DataLakeStoreFileSystemClient = commonData.GetDataLakeStoreFileSystemManagementClient())
                {
                    var filePath1 = CreateFile(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, true, true);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath1, FileType.File,
                        fileContentsToAdd.Length);

                    var filePath2 = CreateFile(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, true, true);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath2, FileType.File,
                        fileContentsToAdd.Length);

                    var targetFolder = CreateFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, true);

                    var concatResponse =
                        commonData.DataLakeStoreFileSystemClient.FileSystem.Concat(
                            string.Format("{0}/{1}", targetFolder, fileToConcatTo),
                            commonData.DataLakeStoreFileSystemAccountName,
                            string.Format("{0},{1}", filePath1, filePath2));
                    Assert.Equal(HttpStatusCode.OK, concatResponse.StatusCode);

                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName,
                        string.Format("{0}/{1}", targetFolder, fileToConcatTo),
                        FileType.File,
                        fileContentsToAdd.Length*2);

                    // Attempt to get the files that were concatted together, which should fail and throw
                    Assert.Throws(typeof (CloudException),
                        () =>
                            commonData.DataLakeStoreFileSystemClient.FileSystem.GetFileStatus(filePath1,
                                commonData.DataLakeStoreFileSystemAccountName));
                    Assert.Throws(typeof (CloudException),
                        () =>
                            commonData.DataLakeStoreFileSystemClient.FileSystem.GetFileStatus(filePath2,
                                commonData.DataLakeStoreFileSystemAccountName));
                }
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
                UndoContext.Current.Start();
                using (
                    commonData.DataLakeStoreFileSystemClient = commonData.GetDataLakeStoreFileSystemManagementClient())
                {
                    var filePath1 = CreateFile(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, true, true);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath1, FileType.File,
                        fileContentsToAdd.Length);

                    var filePath2 = CreateFile(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, true, true);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath2, FileType.File,
                        fileContentsToAdd.Length);

                    var targetFolder = CreateFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, true);

                    var concatResponse =
                        commonData.DataLakeStoreFileSystemClient.FileSystem.MsConcat(
                            string.Format("{0}/{1}", targetFolder, fileToConcatTo),
                            commonData.DataLakeStoreFileSystemAccountName,
                            new MemoryStream(
                                Encoding.UTF8.GetBytes(string.Format("sources={0},{1}", filePath1, filePath2))), null);
                    Assert.Equal(HttpStatusCode.OK, concatResponse.StatusCode);

                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName,
                        string.Format("{0}/{1}", targetFolder, fileToConcatTo),
                        FileType.File,
                        fileContentsToAdd.Length*2);

                    // Attempt to get the files that were concatted together, which should fail and throw
                    Assert.Throws(typeof (CloudException),
                        () =>
                            commonData.DataLakeStoreFileSystemClient.FileSystem.GetFileStatus(filePath1,
                                commonData.DataLakeStoreFileSystemAccountName));
                    Assert.Throws(typeof (CloudException),
                        () =>
                            commonData.DataLakeStoreFileSystemClient.FileSystem.GetFileStatus(filePath2,
                                commonData.DataLakeStoreFileSystemAccountName));
                }
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
                UndoContext.Current.Start();
                using (
                    commonData.DataLakeStoreFileSystemClient = commonData.GetDataLakeStoreFileSystemManagementClient())
                {
                    var concatFolderPath = string.Format("{0}/{1}", folderToCreate,
                        "msconcatFolder");
                    var filePath1 = CreateFile(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, true, true,
                        concatFolderPath);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath1, FileType.File,
                        fileContentsToAdd.Length);

                    var filePath2 = CreateFile(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, true, true,
                        concatFolderPath);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath2, FileType.File,
                        fileContentsToAdd.Length);

                    var targetFolder = CreateFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, true);

                    var concatResponse =
                        commonData.DataLakeStoreFileSystemClient.FileSystem.MsConcat(
                            string.Format("{0}/{1}", targetFolder, fileToConcatTo),
                            commonData.DataLakeStoreFileSystemAccountName,
                            new MemoryStream(
                                Encoding.UTF8.GetBytes(string.Format("sources={0},{1}", filePath1, filePath2))), true);
                    Assert.Equal(HttpStatusCode.OK, concatResponse.StatusCode);

                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName,
                        string.Format("{0}/{1}", targetFolder, fileToConcatTo),
                        FileType.File,
                        fileContentsToAdd.Length*2);

                    // Attempt to get the files that were concatted together, which should fail and throw
                    Assert.Throws(typeof (CloudException),
                        () =>
                            commonData.DataLakeStoreFileSystemClient.FileSystem.GetFileStatus(filePath1,
                                commonData.DataLakeStoreFileSystemAccountName));
                    Assert.Throws(typeof (CloudException),
                        () =>
                            commonData.DataLakeStoreFileSystemClient.FileSystem.GetFileStatus(filePath2,
                                commonData.DataLakeStoreFileSystemAccountName));

                    // Attempt to get the folder that was created for concat, which should fail and be deleted.
                    Assert.Throws(typeof (CloudException),
                        () =>
                            commonData.DataLakeStoreFileSystemClient.FileSystem.GetFileStatus(concatFolderPath,
                                commonData.DataLakeStoreFileSystemAccountName));
                }
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
                UndoContext.Current.Start();
                using (
                    commonData.DataLakeStoreFileSystemClient = commonData.GetDataLakeStoreFileSystemManagementClient())
                {
                    var filePath = CreateFile(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, true, true);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File,
                        fileContentsToAdd.Length);

                    var targetFolder1 = CreateFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, true);
                    var targetFolder2 = TestUtilities.GenerateName(folderToMove);

                    // Move file first
                    var moveFileResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.Rename(filePath,
                        commonData.DataLakeStoreFileSystemAccountName,
                        string.Format("{0}/{1}", targetFolder1, fileToMove));
                    Assert.Equal(HttpStatusCode.OK, moveFileResponse.StatusCode);
                    Assert.True(moveFileResponse.OperationResult);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName,
                        string.Format("{0}/{1}", targetFolder1, fileToMove),
                        FileType.File,
                        fileContentsToAdd.Length);

                    // Ensure the old file is gone
                    Assert.Throws(typeof (CloudException),
                        () =>
                            commonData.DataLakeStoreFileSystemClient.FileSystem.GetFileStatus(filePath,
                                commonData.DataLakeStoreFileSystemAccountName));

                    // Now move folder completely.
                    var moveFolderResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.Rename(targetFolder1,
                        commonData.DataLakeStoreFileSystemAccountName, targetFolder2);
                    Assert.Equal(HttpStatusCode.OK, moveFolderResponse.StatusCode);
                    Assert.True(moveFolderResponse.OperationResult);

                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, targetFolder2,
                        FileType.Directory, 0);

                    // ensure all the contents of the folder moved
                    // List all the contents in the folder
                    var listFolderResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.ListFileStatus(targetFolder2,
                        commonData.DataLakeStoreFileSystemAccountName, null);
                    Assert.Equal(HttpStatusCode.OK, listFolderResponse.StatusCode);

                    // We know that this directory is brand new, so the contents should only be the one file.
                    Assert.Equal(1, listFolderResponse.FileStatuses.FileStatus.Count);
                    Assert.Equal(FileType.File, listFolderResponse.FileStatuses.FileStatus[0].Type);

                    Assert.Throws(typeof (CloudException),
                        () =>
                            commonData.DataLakeStoreFileSystemClient.FileSystem.GetFileStatus(targetFolder1,
                                commonData.DataLakeStoreFileSystemAccountName));
                }
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
                
                UndoContext.Current.Start();
                using (
                    commonData.DataLakeStoreFileSystemClient = commonData.GetDataLakeStoreFileSystemManagementClient())
                {
                    var folderPath = CreateFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, true);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, folderPath,
                        FileType.Directory, 0);
                    DeleteFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, folderPath, true, false);
                    //WORK AROUND: Bug 4717659 makes it so even empty folders have contents.

                    // delete again expecting failure.
                    DeleteFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, folderPath, false, true);

                    // delete a folder with contents
                    var filePath = CreateFile(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, true, true, folderPath);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File,
                        fileContentsToAdd.Length);

                    // should fail if recurse is not set
                    DeleteFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, folderPath, false, true);

                    // Now actually delete
                    DeleteFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, folderPath, true, false);

                    // delete again expecting failure.
                    DeleteFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, folderPath, true, true);
                }
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
                UndoContext.Current.Start();
                using (
                    commonData.DataLakeStoreFileSystemClient = commonData.GetDataLakeStoreFileSystemManagementClient())
                {
                    var filePath = CreateFile(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, true, true);
                    GetAndCompareFileOrFolder(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath, FileType.File,
                        fileContentsToAdd.Length);
                    DeleteFile(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath, false);

                    // try to delete it again, which should fail
                    DeleteFile(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, filePath, true);
                }
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
                UndoContext.Current.Start();
                using (
                    commonData.DataLakeStoreFileSystemClient = commonData.GetDataLakeStoreFileSystemManagementClient())
                {
                    var currentAcl = commonData.DataLakeStoreFileSystemClient.FileSystem.GetAclStatus("/",
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
                    var setAclResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.SetAcl("/",
                        commonData.DataLakeStoreFileSystemAccountName,
                        string.Join(",", aclToReplaceWith));

                    Assert.True(setAclResponse.StatusCode == HttpStatusCode.OK);
                    var newAcl = commonData.DataLakeStoreFileSystemClient.FileSystem.GetAclStatus("/",
                        commonData.DataLakeStoreFileSystemAccountName);
                    // verify the ACL actually changed

                    // Check the access first and assert that it returns OK (note: this is currently only for the user making the request, so it is not testing "other")
                    var accessCheckResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.CheckAccess("/",
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
                    var setAclEntryResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.ModifyAclEntries("/",
                        commonData.DataLakeStoreFileSystemAccountName, originalOther);
                    Assert.True(setAclEntryResponse.StatusCode == HttpStatusCode.OK);

                    // Now confirm that it equals the original ACL
                    var finalEntries = commonData.DataLakeStoreFileSystemClient.FileSystem.GetAclStatus("/",
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
                UndoContext.Current.Start();
                using (
                    commonData.DataLakeStoreFileSystemClient = commonData.GetDataLakeStoreFileSystemManagementClient())
                {
                    var filePath = CreateFile(commonData.DataLakeStoreFileSystemClient, commonData.DataLakeStoreFileSystemAccountName, true, true);
                    var originalFileStatus =
                        commonData.DataLakeStoreFileSystemClient.FileSystem.GetFileStatus(filePath,
                            commonData.DataLakeStoreFileSystemAccountName)
                            .FileStatus;
                    // Set replication on file
                    var replicationResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.SetReplication(filePath,
                        commonData.DataLakeStoreFileSystemAccountName, 3);
                    Assert.True(replicationResponse.StatusCode == HttpStatusCode.OK &&
                                replicationResponse.OperationResult);

                    /*
                 * This API is available but all values put into it are ignored. Commenting this out until this API is fully functional.
                Assert.Equal(3,
                    dataLakeFileSystemClient.FileSystem.GetFileStatus(filePath, commonData.DataLakeStoreFileSystemAccountName)
                        .FileStatus.Replication);
                */

                    // set the time on the file
                    // We use a static date for now since we aren't interested in whether the value is set properly, only that the method returns a 200.
                    var timeToSet = new DateTime(2015, 10, 26, 14, 30, 0).Ticks;
                    var timeResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.SetTimes(filePath,
                        commonData.DataLakeStoreFileSystemAccountName, timeToSet, timeToSet);
                    Assert.True(timeResponse.StatusCode == HttpStatusCode.OK);

                    var fileStatusAfterTime =
                        commonData.DataLakeStoreFileSystemClient.FileSystem.GetFileStatus(filePath,
                            commonData.DataLakeStoreFileSystemAccountName)
                            .FileStatus;

                    /*
                 * This API is available but all values put into it are ignored. Commenting this out until this API is fully functional.
                Assert.True(
                    fileStatusAfterTime.ModificationTime == timeToSet && fileStatusAfterTime.AccessTime == timeToSet);
                */

                    // Symlink creation is explicitly not supported.
                    var symLinkName = TestUtilities.GenerateName("testPath/symlinktest1");
                    Assert.Throws<CloudException>(() => commonData.DataLakeStoreFileSystemClient.FileSystem.CreateSymLink(filePath,
                        commonData.DataLakeStoreFileSystemAccountName, symLinkName, true));

                    // Once symlinks are available, remove the throws test and uncomment out this code.
                    // Assert.True(createSymLinkResponse.StatusCode == HttpStatusCode.OK);
                    // Assert.DoesNotThrow(() => dataLakeFileSystemClient.FileSystem.GetFileStatus(symLinkName, commonData.DataLakeStoreFileSystemAccountName));
                }

            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void DataLakeStoreFileSystemGetAcl()
        {
            try
            {
                UndoContext.Current.Start();
                using (commonData.DataLakeStoreFileSystemClient = commonData.GetDataLakeStoreFileSystemManagementClient())
                {
                    var aclGetResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.GetAclStatus("/",
                        commonData.DataLakeStoreFileSystemAccountName);

                    Assert.Equal(HttpStatusCode.OK, aclGetResponse.StatusCode);
                    Assert.NotNull(aclGetResponse.AclStatus);
                    Assert.NotEmpty(aclGetResponse.AclStatus.Entries);
                    Assert.True(!string.IsNullOrEmpty(aclGetResponse.AclStatus.Owner));
                    Assert.True(!string.IsNullOrEmpty(aclGetResponse.AclStatus.Group));
                }
            }
            finally
            {
                TestUtilities.EndTest();
            }

        }

        [Fact]
        public void DataLakeStoreFileSystemSetAcl()
        {
            try
            {
                UndoContext.Current.Start();
                using (commonData.DataLakeStoreFileSystemClient = commonData.GetDataLakeStoreFileSystemManagementClient())
                {
                    var aclGetResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.GetAclStatus("/",
                        commonData.DataLakeStoreFileSystemAccountName);

                    Assert.Equal(HttpStatusCode.OK, aclGetResponse.StatusCode);
                    Assert.NotNull(aclGetResponse.AclStatus);
                    Assert.NotEmpty(aclGetResponse.AclStatus.Entries);

                    var currentCount = aclGetResponse.AclStatus.Entries.Count;
                    // add an entry to the ACL Entries
                    var newAcls = string.Join(",", aclGetResponse.AclStatus.Entries);
                    newAcls += string.Format(",user:{0}:rwx", commonData.AclUserId);

                    var aclSetResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.SetAcl("/",
                        commonData.DataLakeStoreFileSystemAccountName, newAcls);

                    Assert.Equal(HttpStatusCode.OK, aclSetResponse.StatusCode);
                    
                    // retrieve the ACL again and confirm the new entry is present
                    aclGetResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.GetAclStatus("/",
                        commonData.DataLakeStoreFileSystemAccountName);

                    Assert.Equal(HttpStatusCode.OK, aclGetResponse.StatusCode);
                    Assert.NotNull(aclGetResponse.AclStatus);
                    Assert.NotEmpty(aclGetResponse.AclStatus.Entries);
                    Assert.Equal(currentCount + 1, aclGetResponse.AclStatus.Entries.Count);
                    Assert.True(aclGetResponse.AclStatus.Entries.Any(entry => entry.Contains(commonData.AclUserId)));
                }
            }
            finally
            {
                TestUtilities.EndTest();
            }

        }

        [Fact]
        public void DataLakeStoreFileSystemSetDeleteAclEntry()
        {
            try
            {
                UndoContext.Current.Start();
                using (commonData.DataLakeStoreFileSystemClient = commonData.GetDataLakeStoreFileSystemManagementClient())
                {
                    var aclGetResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.GetAclStatus("/",
                        commonData.DataLakeStoreFileSystemAccountName);

                    Assert.Equal(HttpStatusCode.OK, aclGetResponse.StatusCode);
                    Assert.NotNull(aclGetResponse.AclStatus);
                    Assert.NotEmpty(aclGetResponse.AclStatus.Entries);

                    var currentCount = aclGetResponse.AclStatus.Entries.Count;
                    // add an entry to the ACL Entries
                    var newAce = string.Format("user:{0}:rwx", commonData.AclUserId);

                    var aclSetResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.ModifyAclEntries("/",
                        commonData.DataLakeStoreFileSystemAccountName, newAce);

                    Assert.Equal(HttpStatusCode.OK, aclSetResponse.StatusCode);

                    // retrieve the ACL again and confirm the new entry is present
                    aclGetResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.GetAclStatus("/",
                        commonData.DataLakeStoreFileSystemAccountName);

                    Assert.Equal(HttpStatusCode.OK, aclGetResponse.StatusCode);
                    Assert.NotNull(aclGetResponse.AclStatus);
                    Assert.NotEmpty(aclGetResponse.AclStatus.Entries);
                    Assert.Equal(currentCount + 1, aclGetResponse.AclStatus.Entries.Count);
                    Assert.True(aclGetResponse.AclStatus.Entries.Any(entry => entry.Contains(commonData.AclUserId)));

                    // now remove the entry
                    var aceToRemove = string.Format(",user:{0}", commonData.AclUserId);
                    var aclRemoveResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.RemoveAclEntries("/",
                        commonData.DataLakeStoreFileSystemAccountName, aceToRemove);

                    Assert.Equal(HttpStatusCode.OK, aclRemoveResponse.StatusCode);

                    // retrieve the ACL again and confirm the new entry is present
                    aclGetResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.GetAclStatus("/",
                        commonData.DataLakeStoreFileSystemAccountName);

                    Assert.Equal(HttpStatusCode.OK, aclGetResponse.StatusCode);
                    Assert.NotNull(aclGetResponse.AclStatus);
                    Assert.NotEmpty(aclGetResponse.AclStatus.Entries);
                    Assert.Equal(currentCount, aclGetResponse.AclStatus.Entries.Count);
                    Assert.False(aclGetResponse.AclStatus.Entries.Any(entry => entry.Contains(commonData.AclUserId)));
                }
            }
            finally
            {
                TestUtilities.EndTest();
            }

        }

        #endregion

        #region helpers
        internal string CreateFolder(DataLakeStoreFileSystemManagementClient dataLakeStoreFileSystemClient, string caboAccountName, bool randomName = false)
        {
            // Create a folder
            var folderPath = randomName
                ? TestUtilities.GenerateName(folderToCreate)
                : folderToCreate;

            var response = commonData.DataLakeStoreFileSystemClient.FileSystem.Mkdirs(folderPath, caboAccountName, null);
            Assert.True(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created);
            Assert.True(response.OperationResult);

            return folderPath;
        }

        internal string CreateFile(DataLakeStoreFileSystemManagementClient dataLakeStoreFileSystemClient, string caboAccountName, bool withContents, bool randomName = false, string folderName = folderToCreate, bool useDirectCreate = false)
        {
            var filePath = randomName ? TestUtilities.GenerateName(string.Format("{0}/{1}", folderName, fileToCreate)) : string.Format("{0}/{1}", folderName, fileToCreate);

            if (useDirectCreate)
            {
                if (!withContents)
                {
                    var createFileResponse =
                        commonData.DataLakeStoreFileSystemClient.FileSystem.DirectCreate(
                            filePath,
                            caboAccountName,
                            new MemoryStream(),
                            null);

                    Assert.True(createFileResponse.StatusCode == HttpStatusCode.OK ||
                                createFileResponse.StatusCode == HttpStatusCode.Created);
                }
                else
                {
                    var createFileResponse =
                        commonData.DataLakeStoreFileSystemClient.FileSystem.DirectCreate(
                            filePath,
                            caboAccountName,
                            new MemoryStream(Encoding.UTF8.GetBytes(fileContentsToAdd)),
                            null);

                    Assert.True(createFileResponse.StatusCode == HttpStatusCode.OK ||
                                createFileResponse.StatusCode == HttpStatusCode.Created);
                }

                return filePath;
            }

            var beginCreateFileResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.BeginCreate(filePath,
                caboAccountName, null);
            Assert.Equal(HttpStatusCode.TemporaryRedirect, beginCreateFileResponse.StatusCode);
            Assert.True(!string.IsNullOrEmpty(beginCreateFileResponse.Location));

            if (!withContents)
            {
                var createFileResponse =
                    commonData.DataLakeStoreFileSystemClient.FileSystem.Create(beginCreateFileResponse.Location,
                        new MemoryStream());
                Assert.True(createFileResponse.StatusCode == HttpStatusCode.OK ||
                            createFileResponse.StatusCode == HttpStatusCode.Created);
            }
            else
            {
                var createFileResponse =
                    commonData.DataLakeStoreFileSystemClient.FileSystem.Create(beginCreateFileResponse.Location,
                        new MemoryStream(Encoding.UTF8.GetBytes(fileContentsToAdd)));
                Assert.True(createFileResponse.StatusCode == HttpStatusCode.OK ||
                            createFileResponse.StatusCode == HttpStatusCode.Created);
            }
            return filePath;
        }

        internal FileStatusResponse GetAndCompareFileOrFolder(DataLakeStoreFileSystemManagementClient dataLakeStoreFileSystemClient, string caboAccountName, string fileOrFolderPath, FileType expectedType, long expectedLength)
        {
            var getResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.GetFileStatus(fileOrFolderPath, caboAccountName);
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
            Assert.Equal(expectedLength, getResponse.FileStatus.Length);
            Assert.Equal(expectedType, getResponse.FileStatus.Type);

            return getResponse;
        }

        internal void CompareFileContents(DataLakeStoreFileSystemManagementClient dataLakeStoreFileSystemClient, string caboAccountName, string filePath, string expectedContents, bool useDirectOpen = false)
        {
            // download a file and ensure they are equal
            FileOpenResponse openResponse;
            if (useDirectOpen)
            {
                openResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.DirectOpen(filePath, caboAccountName, null);
                Assert.Equal(HttpStatusCode.OK, openResponse.StatusCode);
            }
            else
            {
                var beginOpenResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.BeginOpen(filePath, caboAccountName, null);
                Assert.Equal(HttpStatusCode.TemporaryRedirect, beginOpenResponse.StatusCode);
                Assert.True(!string.IsNullOrEmpty(beginOpenResponse.Location));

                openResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.Open(beginOpenResponse.Location);
                Assert.Equal(HttpStatusCode.OK, openResponse.StatusCode);

            }

            string toCompare = Encoding.UTF8.GetString(openResponse.FileContents);
            Assert.Equal(expectedContents, toCompare);
        }

        internal void DeleteFolder(DataLakeStoreFileSystemManagementClient dataLakeStoreFileSystemClient, string caboAccountName, string folderPath, bool recursive, bool failureExpected)
        {
            if (failureExpected)
            {
                // try to delete a folder that doesn't exist or should fail
                try
                {
                    var deleteFolderResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.Delete(folderPath, caboAccountName, recursive);
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
                var deleteFolderResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.Delete(folderPath, caboAccountName, recursive);
                Assert.Equal(HttpStatusCode.OK, deleteFolderResponse.StatusCode);
                Assert.True(deleteFolderResponse.OperationResult);
            }
        }

        internal void DeleteFile(DataLakeStoreFileSystemManagementClient dataLakeStoreFileSystemClient, string caboAccountName, string filePath, bool failureExpected)
        {
            if (failureExpected)
            {
                // try to delete a file that doesn't exist
                try
                {
                    var deleteFileResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.Delete(filePath, caboAccountName, false);
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
                var deleteFileResponse = commonData.DataLakeStoreFileSystemClient.FileSystem.Delete(filePath, caboAccountName, false);
                Assert.Equal(HttpStatusCode.OK, deleteFileResponse.StatusCode);
                Assert.True(deleteFileResponse.OperationResult);
            }
        }
        #endregion
    }
}
