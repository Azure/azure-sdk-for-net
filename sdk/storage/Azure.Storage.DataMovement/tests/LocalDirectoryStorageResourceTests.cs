// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class LocalDirectoryStorageResourceTests : DataMovementTestBase
    {
        public LocalDirectoryStorageResourceTests(bool async)
           : base(async, null /* TestMode.Record /* to re-record */)
        { }

        private string[] fileNames => new[]
        {
            "C:\\Users\\user1\\Documents\\directory",
            "C:\\Users\\user1\\Documents\\directory1\\",
            "/user1/Documents/directory",
        };

        [Test]
        public void Ctor_string()
        {
            foreach (string path in fileNames)
            {
                // Arrange
                LocalDirectoryStorageResourceContainer storageResource = new LocalDirectoryStorageResourceContainer(path);

                // Assert
                Assert.AreEqual(path, storageResource.Uri.LocalPath);
                Assert.AreEqual(Uri.UriSchemeFile, storageResource.Uri.Scheme);
            }
        }

        [Test]
        public void Ctor_Error()
        {
            Assert.Catch<ArgumentException>( () =>
                new LocalDirectoryStorageResourceContainer(""));

            Assert.Catch<ArgumentException>(() =>
                new LocalDirectoryStorageResourceContainer("   "));

            Assert.Catch<ArgumentException>(() =>
                new LocalDirectoryStorageResourceContainer(path: default));

            Assert.Catch<ArgumentException>(() =>
                new LocalDirectoryStorageResourceContainer(uri: default));
        }

        [Test]
        public async Task GetStorageResourcesAsync()
        {
            // Arrange
            List<string> paths = new List<string>();
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            string folderPath = test.DirectoryPath;

            for (int i = 0; i < 3; i++)
            {
                paths.Add(await CreateRandomFileAsync(folderPath));
            }
            LocalDirectoryStorageResourceContainer containerResource = new LocalDirectoryStorageResourceContainer(folderPath);

            // Act
            List<string> resultPaths = new List<string>();
            await foreach (StorageResource resource in containerResource.GetStorageResourcesAsync())
            {
                resultPaths.Add(resource.Uri.LocalPath);
            }

            // Assert
            Assert.IsNotEmpty(resultPaths);
            Assert.AreEqual(paths.Count, resultPaths.Count);
            Assert.IsTrue(paths.All(path => resultPaths.Contains(path)));
        }

        [Test]
        public async Task GetChildStorageResourceAsync()
        {
            List<string> paths = new List<string>();
            List<string> fileNames = new List<string>();
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            string folderPath = test.DirectoryPath;

            for (int i = 0; i < 3; i++)
            {
                string fileName = await CreateRandomFileAsync(folderPath);
                paths.Add(fileName);
                fileNames.Add(fileName.Substring(folderPath.Length + 1));
            }

            StorageResourceContainer containerResource = new LocalDirectoryStorageResourceContainer(folderPath);
            foreach (string fileName in fileNames)
            {
                StorageResourceItem resource = containerResource.GetStorageResourceReference(fileName);
                // Assert
                await resource.GetPropertiesAsync().ConfigureAwait(false);
            }
        }

        [Test]
        public async Task GetChildStorageResourceAsync_SubDir()
        {
            List<string> paths = new List<string>();
            List<string> fileNames = new List<string>();
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            string folderPath = test.DirectoryPath;

            for (int i = 0; i < 3; i++)
            {
                string fileName = await CreateRandomFileAsync(folderPath);
                paths.Add(fileName);
                fileNames.Add(fileName.Substring(folderPath.Length + 1));
            }
            string subdirName = "bar";
            string subdir = CreateRandomDirectory(folderPath, subdirName);
            for (int i = 0; i < 3; i++)
            {
                string fileName = await CreateRandomFileAsync(subdir);
                paths.Add(fileName);
                fileNames.Add(fileName.Substring(folderPath.Length + 1));
            }

            StorageResourceContainer containerResource = new LocalDirectoryStorageResourceContainer(folderPath);
            foreach (string fileName in fileNames)
            {
                StorageResourceItem resource = containerResource.GetStorageResourceReference(fileName);
                // Assert
                await resource.GetPropertiesAsync().ConfigureAwait(false);
            }
        }

        [Test]
        public void GetChildStorageResourceContainer()
        {
            using DisposingLocalDirectory test = DisposingLocalDirectory.GetTestDirectory();
            string folderPath = test.DirectoryPath;

            StorageResourceContainer container = new LocalDirectoryStorageResourceContainer(folderPath);

            string childPath = "childPath";
            StorageResourceContainer childContainer = container.GetChildStorageResourceContainer(childPath);

            string fullPath = Path.Combine(folderPath, childPath);
            Assert.AreEqual(childContainer.Uri, new Uri(fullPath));
        }
    }
}
