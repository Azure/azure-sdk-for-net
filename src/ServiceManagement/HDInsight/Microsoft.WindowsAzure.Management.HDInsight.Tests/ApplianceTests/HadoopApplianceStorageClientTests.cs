// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ApplianceTests
{
    using System;
    using System.IO;
    using System.Linq;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.HadoopStorageClientLayer;
    using Microsoft.HadoopAppliance.Client;
    using Microsoft.HadoopAppliance.Client.HadoopStorageClientLayer;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [TestClass]
    public class HadoopApplianceStorageClientTests : ApplianceTestsBase
    {
        private const string defaultFilePath = "/applianceTests";
        private const string testFileName = "testfile.txt";
        private IStorageClientCredential credential;

        [ClassInitialize]
        public static void TestRunSetup(TestContext context)
        {
            ApplianceTestsBase.TestRunSetup();
        }

        [ClassCleanup]
        public static void ClassCleanup1()
        {
            ApplianceTestsBase.TestRunCleanup();
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            var client = CreateClient();
            client.CreateDirectory(defaultFilePath);
            WriteStringData("This is a test data", string.Format("{0}/{1}", defaultFilePath, testFileName), client);
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            var client = CreateClient();
            client.DeleteAsync(defaultFilePath, true);
            base.TestCleanup();
        }

        public HadoopApplianceStorageClientTests()
        {
            credential = new StorageClientBasicAuthCredential()
            {
                Server = new Uri("https://testserver"),
                UserName = "Administrator",
                // [SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
                Password = "Passw0rd1"
            };
        }

        [TestMethod]
        public void GetDirectoryStatusTest()
        {
            string folderName = "newFolder";
            var client = CreateClient();
            client.CreateDirectory(string.Format("{0}/{1}", defaultFilePath, folderName));
            DirectoryListing list = client.GetDirectoryStatusAsync(defaultFilePath).Result;
            Assert.AreEqual(1, list.Entries.Count(e=>e.EntryType==DirectoryEntryType.DIRECTORY), "Unexpected number of directories found in directory listing.");
            Assert.AreEqual(1, list.Entries.Count(e => e.EntryType == DirectoryEntryType.FILE), "Unexpected number of files found in directory listing.");
            Assert.AreEqual(folderName, list.Entries.Single(e => e.EntryType == DirectoryEntryType.DIRECTORY).PathSuffix, "Directory listing should contain folder name.");
            Assert.AreEqual(testFileName, list.Entries.Single(e => e.EntryType == DirectoryEntryType.FILE).PathSuffix, "Directory listing should contain file name.");
        }

        [TestMethod]
        public void GetFileStatusTest()
        {
            var client = CreateClient();
            DirectoryEntry result = client.GetFileStatusAsync(string.Format("{0}/{1}", defaultFilePath, testFileName)).Result;
            Assert.AreEqual(testFileName, result.PathSuffix, "File status does not contain file name.");
            Assert.AreEqual(DirectoryEntryType.FILE, result.EntryType, "The returned type for the file is not expected.");
        }

        [TestMethod]
        public void ExistsTest()
        {
            var client = CreateClient();
            bool result = client.ExistsAsync(defaultFilePath).Result;
            Assert.IsTrue(result, "Given directory path should exist in the file system.");
            result = client.ExistsAsync(string.Format("{0}/{1}", defaultFilePath, "_dummy")).Result;
            Assert.IsFalse(result, "Given path should not exist in the file system.");
            result = client.ExistsAsync(string.Format("{0}/{1}", defaultFilePath, testFileName)).Result;
            Assert.IsTrue(result, "Given file path should exist in the file system.");
        }

        [TestMethod]
        public void CreateDirectoryTest()
        {
            var client = CreateClient();
            string testDirPath = string.Format("{0}/{1}", defaultFilePath, "newDirectory");
            bool dirExists = client.Exists(testDirPath);
            Assert.IsFalse(dirExists, "Test directory unexpectedly exists.");
            client.CreateDirectoryAsync(testDirPath);
            dirExists = client.Exists(testDirPath);
            Assert.IsTrue(dirExists, "Test directory should exist.");
        }

        [TestMethod]
        public void ReadWriteAppendTest()
        {
            string filePath = string.Format("{0}/{1}", defaultFilePath, "file.txt");
            string data = "Test data to be written. ";
            string appendData = "Test data to be appended.";
            var client = CreateClient();
            WriteStringData(data, filePath, client);
            bool fileExist = client.Exists(filePath);
            Assert.IsTrue(fileExist, "File should exist in the file system.");

            string actualData;
            using (Stream stream = client.ReadAsync(filePath, null, null, null).Result)
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    actualData = reader.ReadToEnd();
                }
            }
            Assert.AreEqual(data, actualData, "Data read from the file does not match expected data.");

            using (MemoryStream stream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(appendData);
                    writer.Flush();
                    stream.Seek(0, SeekOrigin.Begin);
                    client.AppendAsync(stream, filePath).Wait();
                }
            }

            using (Stream stream = client.ReadAsync(filePath, null, null, null).Result)
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    actualData = reader.ReadToEnd();
                }
            }
            Assert.AreEqual(data + appendData, actualData, "Data read from the file does not match expected data.");
        }

        [TestMethod]
        public void DeleteTest()
        {
            string data = "Test data.";
            string folderPath = string.Format("{0}/{1}", defaultFilePath, "subdir");
            string filePath1 = string.Format("{0}/{1}", folderPath, "file1.txt");
            string filePath2 = string.Format("{0}/{1}", folderPath, "file2.txt");
            var client = CreateClient();
            client.CreateDirectory(folderPath);
            WriteStringData(data, filePath1, client);
            WriteStringData(data, filePath2, client);
            bool pathExists = client.Exists(filePath1);
            Assert.IsTrue(pathExists, "Path to the first file should exist.");
            
            bool result = client.DeleteAsync(filePath1, false).Result;
            Assert.IsTrue(result, "Delete operation returned unexpected result.");
            pathExists = client.Exists(filePath1);
            Assert.IsFalse(pathExists, "Path to the first file should not exist.");
            pathExists = client.Exists(filePath2);
            Assert.IsTrue(pathExists, "Path to the second file should exist.");
            pathExists = client.Exists(folderPath);
            Assert.IsTrue(pathExists, "Path to the folder should exist.");

            result = client.DeleteAsync(folderPath, true).Result;
            Assert.IsTrue(result, "Delete operation returned unexpected result.");
            pathExists = client.Exists(filePath1);
            Assert.IsFalse(pathExists, "Path to the first file should not exist.");
            pathExists = client.Exists(filePath2);
            Assert.IsFalse(pathExists, "Path to the second file should not exist.");
            pathExists = client.Exists(folderPath);
            Assert.IsFalse(pathExists, "Path to the folder should not exist.");
        }

        [TestMethod]
        public void RenameTest()
        {
            string data = "Test data.";
            string folderPath = string.Format("{0}/{1}", defaultFilePath, "subdir");
            string filePath = string.Format("{0}/{1}", folderPath, "file.txt");
            string newFolderPath = string.Format("{0}/{1}", defaultFilePath, "newsubdir");
            string newFilePath = string.Format("{0}/{1}", newFolderPath, "newfile.txt");

            var client = CreateClient();
            client.CreateDirectory(folderPath);
            WriteStringData(data, filePath, client);
            bool pathExists = client.Exists(filePath);
            Assert.IsTrue(pathExists, "Path to the file should exist.");

            bool result = client.RenameAsync(filePath, newFilePath).Result;
            Assert.IsTrue(result, "Rename operation returned unexpected result.");

            pathExists = client.Exists(filePath);
            Assert.IsFalse(pathExists, "Old path to the file should not exist.");
            pathExists = client.Exists(folderPath);
            Assert.IsTrue(pathExists, "Old folder path should exist.");
            pathExists = client.Exists(newFilePath);
            Assert.IsTrue(pathExists, "New path to the file should exist.");
            pathExists = client.Exists(newFolderPath);
            Assert.IsTrue(pathExists, "New folder path should exist.");

            string actualData;
            using (Stream stream = client.ReadAsync(newFilePath, null, null, null).Result)
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    actualData = reader.ReadToEnd();
                }
            }
            Assert.AreEqual(data, actualData, "Data read from the file does not match expected data.");
        }

        [TestMethod]
        public void GetContentSummaryTest()
        {
            string data = "Test data.";
            var client = (IHadoopApplianceStorageClient)CreateClient();
            WriteStringData(data, string.Format("{0}/{1}", defaultFilePath, "subdir1/file1.txt"), client);
            WriteStringData(data, string.Format("{0}/{1}", defaultFilePath, "subdir1/file2.txt"), client);
            WriteStringData(data, string.Format("{0}/{1}", defaultFilePath, "subdir1/subdir2/file1.txt"), client);
            ContentSummary summary = client.GetContentSummaryAsync(string.Format("{0}/{1}", defaultFilePath, "subdir1")).Result;
            Assert.AreEqual(2, summary.DirectoryCount, "Directory count is not expected.");
            Assert.AreEqual(2, summary.FileCount, "File count is not expected");
        }

        [TestMethod]
        public void SetReplicationFactorTest()
        {
            var client = (IHadoopApplianceStorageClient)CreateClient();
            string filePath = string.Format("{0}/{1}", defaultFilePath, testFileName);
            DirectoryEntry entry = client.GetFileStatus(filePath);
            short replicationFactor = (short)(entry.Replication + 1);
            bool result = client.SetReplicationFactorAsync(filePath, replicationFactor).Result;
            Assert.IsTrue(result, "Result of SetReplicationFactor operation is not as expected.");
            entry = client.GetFileStatus(filePath);
            Assert.AreEqual(replicationFactor, entry.Replication, "Replication factor is not correctly set.");
        }

        [TestMethod]
        public void SetPermissionTest()
        {
            string filePath = string.Format("{0}/{1}", defaultFilePath, testFileName);
            string targetPermission = "777";
            var client = (IHadoopApplianceStorageClient)CreateClient();
            bool result = client.SetPermissionsAsync(filePath, targetPermission).Result;
            Assert.IsTrue(result, "Result of SetPermission operation is not as expected.");
            DirectoryEntry entry = client.GetFileStatus(filePath);
            Assert.AreEqual(targetPermission, entry.Permission, "Permission is not properly set.");
        }

        [TestMethod]
        public void SetOwnerTest()
        {
            string filePath = string.Format("{0}/{1}", defaultFilePath, testFileName);
            string newOwner = "HadoopUser";
            string newGroup = "HadoopUserGroup";
            var client = (IHadoopApplianceStorageClient)CreateClient();
            bool result = client.SetOwnerAsync(filePath, newOwner, null).Result;
            Assert.IsTrue(result, "Result of SetOwner operation is not as expected.");
            DirectoryEntry entry = client.GetFileStatus(filePath);
            Assert.AreEqual(newOwner, entry.Owner, "Owner is not properly set.");
            result = client.SetOwnerAsync(filePath, null, newGroup).Result;
            Assert.IsTrue(result, "Result of SetOwner operation is not as expected.");
            entry = client.GetFileStatus(filePath);
            Assert.AreEqual(newGroup, entry.Group, "Group is not properly set.");
        }

        private IHadoopStorageClient CreateClient()
        {
            return ServiceLocator.Instance.Locate<IHadoopStorageClientFactory>().Create(credential);
        }

        private void WriteStringData(string data, string filePath, IHadoopStorageClient client)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(data);
                    writer.Flush();
                    stream.Seek(0, SeekOrigin.Begin);
                    client.Write(stream, filePath, false);
                }
            }
        }
    }
}
