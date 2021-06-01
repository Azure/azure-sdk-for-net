// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Common.DataMovement;
using NUnit.Framework;
using System.Reflection;

namespace Azure.Storage.Tests
{
    public class FilesystemScannerTests
    {
        [Test]
        public void ScanFolderContainingMixedPermissions()
        {
            // Arrange
            string testPath = "C:\\Test";

            // Act
            IEnumerable<string> files = FilesystemScanner.ScanLocation(testPath);

            // Assert
            CollectionAssert.Contains(files, "C:\\Test\\child01.txt");
            CollectionAssert.Contains(files, "C:\\Test\\subfolder02\\subchild02.txt");
            CollectionAssert.DoesNotContain(files, "C:\\Test\\child02.txt"); // No permissions
            CollectionAssert.DoesNotContain(files, "C:\\Test\\subfolder01\\subchild01.txt"); // No permissions
        }

        [Test]
        public void ScanFolderWithoutReadPermissions()
        {
            // Arrange
            string testPath = "C:\\Test3";

            // Act
            IEnumerable<string> files = FilesystemScanner.ScanLocation(testPath);
            bool dirExists = Directory.Exists(testPath);

            // Assert
            Assert.IsTrue(dirExists);
            CollectionAssert.IsEmpty(files);
        }

        [Test]
        public void ScanNonexistantFolder()
        {
            // Arrange
            string testPath = "C:\\Test4";

            // Act
            IEnumerable<string> files = FilesystemScanner.ScanLocation(testPath);
            bool dirExists = Directory.Exists(testPath);

            // Assert
            Assert.IsFalse(dirExists);
            CollectionAssert.IsEmpty(files);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ScanSingleFilePath(bool testExists)
        {
            // Arrange
            string testPath = testExists ? "C:\\file.txt" : "C:\\fakefile.txt";

            // Act
            IEnumerable<string> files = FilesystemScanner.ScanLocation(testPath);
            bool fileExists = File.Exists(testPath);

            // Assert
            if (testExists)
            {
                Assert.IsTrue(fileExists);
                CollectionAssert.IsNotEmpty(files);
            }
            else
            {
                Assert.IsFalse(fileExists);
                CollectionAssert.IsEmpty(files);
            }
        }

        [Test]
        public void MultiplePaths()
        {
            // Arrange
            string[] testPaths = { "C:\\Test", "C:\\file.txt" };

            // Act
            IEnumerable<string> files = FilesystemScanner.ScanLocations(testPaths);

            // Assert
            CollectionAssert.Contains(files, "C:\\Test\\child01.txt");
            CollectionAssert.Contains(files, "C:\\Test\\subfolder02\\subchild02.txt");
            CollectionAssert.DoesNotContain(files, "C:\\Test\\child02.txt"); // No permissions
            CollectionAssert.DoesNotContain(files, "C:\\Test\\subfolder01\\subchild01.txt"); // No permissions
            CollectionAssert.Contains(files, "C:\\file.txt");
        }
    }
}
