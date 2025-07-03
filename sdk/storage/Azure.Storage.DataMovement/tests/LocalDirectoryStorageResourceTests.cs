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
        [TestCase("/test/path=true@&#%", "/test/path%3Dtrue%40%26%23%25")]
        [TestCase("/test/path%3Dtest%26", "/test/path%253Dtest%2526")]
        [TestCase("C:\\test\\path=true@&#%", "C:/test/path%3Dtrue%40%26%23%25")]
        [TestCase("C:\\test\\path%3Dtest%26", "C:/test/path%253Dtest%2526")]
        [TestCase("C:\\test\\folder with spaces", "C:/test/folder%20with%20spaces")]
        public void Ctor_String_Encoding(string path, string absolutePath)
        {
            LocalDirectoryStorageResourceContainer storageResource = new(path);
            Assert.That(storageResource.Uri.AbsolutePath, Is.EqualTo(absolutePath));
            // LocalPath should equal original path
            Assert.That(storageResource.Uri.LocalPath, Is.EqualTo(path));
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
        public async Task GetStorageResourceReference()
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
                StorageResourceItem resource = containerResource.GetStorageResourceReference(fileName, default);
                // Assert
                await resource.GetPropertiesAsync().ConfigureAwait(false);
            }
        }

        [Test]
        public async Task GetStorageResourceReference_SubDir()
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
                StorageResourceItem resource = containerResource.GetStorageResourceReference(fileName, default);
                // Assert
                await resource.GetPropertiesAsync().ConfigureAwait(false);
            }
        }

        [Test]
        public void GetStorageResourceReference_Encoding()
        {
            List<(string Start, string Append)> tests =
            [
                ("C:\\Users\\user1\\Documents\\directory", "path=true@&#%"),
                ("C:\\Users\\user1\\Documents\\directory", "path%3Dtest%26"),
                ("C:\\Users\\user1\\Documents\\directory", "with space"),
                ("C:\\Users\\user1\\Documents\\directory=true@%", "path=true@&#%"),
                ("C:\\Users\\user1\\Documents\\directory=true@%", "path%3Dtest%26"),
                ("C:\\Users\\user1\\Documents\\directory=true@%", "with space"),
                ("C:\\Users\\user1\\Documents\\directory%3Dtrue%26", "path=true@&#%"),
                ("C:\\Users\\user1\\Documents\\directory%3Dtrue%26", "path%3Dtest%26"),
                ("C:\\Users\\user1\\Documents\\directory%3Dtrue%26", "with space"),
                ("/home/user1/directory", "path=true@&#%"),
                ("/home/user1/directory", "path%3Dtest%26"),
                ("/home/user1/directory", "with space"),
            ];

            foreach ((string Start, string Append) test in tests)
            {
                StorageResourceContainer containerResource = new LocalDirectoryStorageResourceContainer(test.Start);
                StorageResourceItem resource = containerResource.GetStorageResourceReference(test.Append, default);

                char seperator = test.Start[0] == '/' ? '/' : '\\';
                string combined = test.Start + seperator + test.Append;
                Assert.That(resource.Uri.LocalPath, Is.EqualTo(combined));
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

        [Test]
        public void GetChildStorageResourceContainer_Encoding()
        {
            List<(string Start, string Append)> tests =
            [
                ("C:\\Users\\user1\\Documents\\directory", "path=true@&#%"),
                ("C:\\Users\\user1\\Documents\\directory", "path%3Dtest%26"),
                ("C:\\Users\\user1\\Documents\\directory", "with space"),
                ("C:\\Users\\user1\\Documents\\directory=true@%", "path=true@&#%"),
                ("C:\\Users\\user1\\Documents\\directory=true@%", "path%3Dtest%26"),
                ("C:\\Users\\user1\\Documents\\directory=true@%", "with space"),
                ("C:\\Users\\user1\\Documents\\directory%3Dtrue%26", "path=true@&#%"),
                ("C:\\Users\\user1\\Documents\\directory%3Dtrue%26", "path%3Dtest%26"),
                ("C:\\Users\\user1\\Documents\\directory%3Dtrue%26", "with space"),
                ("/home/user1/directory", "path=true@&#%"),
                ("/home/user1/directory", "path%3Dtest%26"),
                ("/home/user1/directory", "with space"),
            ];

            foreach ((string Start, string Append) test in tests)
            {
                StorageResourceContainer containerResource = new LocalDirectoryStorageResourceContainer(test.Start);
                StorageResourceContainer resource = containerResource.GetChildStorageResourceContainer(test.Append);

                char seperator = test.Start[0] == '/' ? '/' : '\\';
                string combined = test.Start + seperator + test.Append;
                Assert.That(resource.Uri.LocalPath, Is.EqualTo(combined));
            }
        }
    }
}
