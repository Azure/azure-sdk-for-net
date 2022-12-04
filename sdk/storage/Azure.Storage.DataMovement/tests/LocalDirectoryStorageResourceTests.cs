// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class LocalDirectoryStorageResourceTests : StorageTestBase<StorageTestEnvironment>
    {
        public LocalDirectoryStorageResourceTests(bool async)
           : base(async, null /* TestMode.Record /* to re-record */)
        { }

        private string[] fileNames => new[]
        {
            "C:\\Users\\user1\\Documents\file.txt",
            "C:\\Users\\user1\\Documents\file",
            "C:\\Users\\user1\\Documents\file\\",
            "user1\\Documents\file\\",
        };

        private static string CreateRandomDirectory(string parentPath)
        {
            return Directory.CreateDirectory(Path.Combine(parentPath, Path.GetRandomFileName())).FullName;
        }

        private static string CreateRandomFile(string parentPath)
        {
            using (FileStream fs = File.Create(Path.Combine(parentPath, Path.GetRandomFileName())))
            {
                return fs.Name;
            }
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public void Ctor_string()
        {
            foreach (string path in fileNames)
            {
                // Arrange
                LocalDirectoryStorageResourceContainer storageResource = new LocalDirectoryStorageResourceContainer(path);

                // Assert
                Assert.AreEqual(path, storageResource.Path);
                Assert.AreEqual(ProduceUriType.NoUri, storageResource.CanProduceUri);
            }
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task GetStorageResourcesAsync()
        {
            // Arrange
            List<string> paths = new List<string>();
            string folderPath = CreateRandomDirectory(Path.GetTempPath());
            for (int i = 0; i < 3; i++)
            {
                paths.Add(CreateRandomFile(folderPath));
            }
            LocalDirectoryStorageResourceContainer containerResource = new LocalDirectoryStorageResourceContainer(folderPath);

            // Act
            List<string> resultPaths = new List<string>();
            await foreach (StorageResourceBase resource in containerResource.GetStorageResourcesAsync())
            {
                resultPaths.Add(resource.Path);
            }

            // Assert
            Assert.IsNotEmpty(resultPaths);
            Assert.AreEqual(paths.Count, resultPaths.Count);
            Assert.IsTrue(paths.All(path => resultPaths.Contains(path)));
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task GetChildStorageResourceAsync()
        {
            List<string> paths = new List<string>();
            List<string> fileNames = new List<string>();
            string folderPath = CreateRandomDirectory(Path.GetTempPath());
            for (int i = 0; i < 3; i++)
            {
                string fileName = CreateRandomFile(folderPath);
                paths.Add(fileName);
                fileNames.Add(fileName.Substring(folderPath.Length));
            }

            StorageResourceContainer containerResource = new LocalDirectoryStorageResourceContainer(folderPath);
            foreach (string fileName in fileNames)
            {
                StorageResource resource = containerResource.GetChildStorageResource(fileName);
                // Assert
                await resource.GetPropertiesAsync().ConfigureAwait(false);
            }
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/32858")]
        public async Task GetChildStorageResourceAsync_SubDir()
        {
            List<string> paths = new List<string>();
            List<string> fileNames = new List<string>();
            string folderPath = CreateRandomDirectory(Path.GetTempPath());
            for (int i = 0; i < 3; i++)
            {
                string fileName = CreateRandomFile(folderPath);
                paths.Add(fileName);
                fileNames.Add(fileName.Substring(folderPath.Length + 1));
            }
            string subdir = CreateRandomDirectory(folderPath);
            for (int i = 0; i < 3; i++)
            {
                string fileName = CreateRandomFile(subdir);
                paths.Add(fileName);
                fileNames.Add(fileName.Substring(folderPath.Length + 1));
            }

            StorageResourceContainer containerResource = new LocalDirectoryStorageResourceContainer(folderPath);
            foreach (string fileName in fileNames)
            {
                StorageResource resource = containerResource.GetChildStorageResource(fileName);
                // Assert
                await resource.GetPropertiesAsync().ConfigureAwait(false);
            }
        }
    }
}
