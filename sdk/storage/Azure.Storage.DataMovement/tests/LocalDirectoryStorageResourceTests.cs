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
        [TestCase("C:\\Users\\user1\\Documents\file.txt")]
        [TestCase("C:\\Users\\user1\\Documents\file")]
        [TestCase("C:\\Users\\user1\\Documents\file\\")]
        [TestCase("user1\\Documents\file\\")]
        public void Ctor_string(string path)
        {
            // Arrange
            LocalDirectoryStorageResourceContainer storageResource = new LocalDirectoryStorageResourceContainer(path);

            // Assert
            Assert.AreEqual(path, storageResource.Path);
            Assert.AreEqual(ProduceUriType.NoUri, storageResource.CanProduceUri);
        }

        [Test]
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
            await foreach (StorageResource resource in containerResource.GetStorageResourcesAsync())
            {
                resultPaths.Add(resource.Path);
            }

            // Assert
            Assert.IsNotEmpty(resultPaths);
            Assert.AreEqual(paths.Count, resultPaths.Count);
            Assert.IsTrue(paths.All(path => resultPaths.Contains(path)));
        }
    }
}
