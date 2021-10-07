// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Reflection;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
#if !NETFRAMEWORK
using Mono.Unix.Native;
#endif

namespace Azure.Storage.DataMovement.Tests
{
    public class PathScannerTests
    {
        private readonly string _temp = Path.GetTempPath();
        private readonly FileSystemAccessRule _winAcl;

        public PathScannerTests()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                string currentUser = WindowsIdentity.GetCurrent().Name;
                _winAcl = new FileSystemAccessRule(currentUser, FileSystemRights.ReadData, AccessControlType.Deny);
            }
        }

        [Test]
        public void ScanFolderContainingMixedPermissions()
        {
            // Arrange
            string folder = CreateRandomDirectory(_temp);
            string openChild = CreateRandomFile(folder);
            string lockedChild = CreateRandomFile(folder);

            string openSubfolder = CreateRandomDirectory(folder);
            string openSubchild = CreateRandomFile(openSubfolder);

            string lockedSubfolder = CreateRandomDirectory(folder);
            string lockedSubchild = CreateRandomFile(lockedSubfolder);

            AllowReadData(lockedChild, false, false);
            AllowReadData(lockedSubfolder, true, false);

            PathScannerFactory scannerFactory = new PathScannerFactory(folder);
            PathScanner scanner = scannerFactory.BuildPathScanner();

            // Act
            IEnumerable<FileSystemInfo> result = scanner.Scan(); // Conversion to list is necessary because results from Scan() disappear once read

            // Assert
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(result, folder, "Missing entry for the working folder.");
                CollectionAssert.Contains(result, openSubfolder, "Missing entry for the readable subfolder.");
                CollectionAssert.Contains(result, lockedSubfolder, "Missing entry for the unreadable subfolder.");
                CollectionAssert.Contains(result, openChild, "Missing entry for the readable child.");
                CollectionAssert.Contains(result, openSubchild, "Missing entry for the readable subchild.");
                CollectionAssert.Contains(result, lockedChild, "Missing entry for the unreadable child."); // No permissions on file, but that should be dealt with by caller
                CollectionAssert.DoesNotContain(result, lockedSubchild); // No permissions to enumerate folder, children not returned
            });

            // Cleanup
            AllowReadData(lockedChild, false, true);
            AllowReadData(lockedSubfolder, true, true);

            Directory.Delete(folder, true);
        }

        [Test]
        public void ScanFolderWithoutReadPermissions()
        {
            // Arrange
            string folder = CreateRandomDirectory(_temp);
            string child = CreateRandomFile(folder);

            AllowReadData(folder, true, false);

            PathScannerFactory scannerFactory = new PathScannerFactory(folder);
            PathScanner scanner = scannerFactory.BuildPathScanner();

            // Act
            IEnumerable<FileSystemInfo> result = scanner.Scan();

            // Act/Assert
            CollectionAssert.Contains(result, folder);

            // Cleanup
            AllowReadData(folder, true, true);

            Directory.Delete(folder, true);
        }

        [Test]
        public void ScanSingleFilePath()
        {
            // Arrange
            string file = CreateRandomFile(_temp);

            PathScannerFactory scannerFactory = new PathScannerFactory(file);
            PathScanner scanner = scannerFactory.BuildPathScanner();

            // Act
            IEnumerable<FileSystemInfo> result = scanner.Scan();

            // Assert
            CollectionAssert.Contains(result, file);

            // Cleanup
            File.Delete(file);
        }

        [Test]
        public void ScanUnreadableFilePath()
        {
            // Arrange
            string file = CreateRandomFile(_temp);

            AllowReadData(file, false, false);

            PathScannerFactory scannerFactory = new PathScannerFactory(file);
            PathScanner scanner = scannerFactory.BuildPathScanner();

            // Act
            IEnumerable<FileSystemInfo> result = scanner.Scan();

            // Assert
            CollectionAssert.Contains(result, file);

            // Cleanup
            AllowReadData(file, true, true);

            File.Delete(file);
        }

        [Test]
        public void ScanNonexistentItem()
        {
            // Arrange
            string file = Path.Combine(_temp, Path.GetRandomFileName());

            // Act/Assert
            Assert.IsFalse(File.Exists(file));
            Assert.Throws<ArgumentException>(() => {
                PathScannerFactory scannerFactory = new PathScannerFactory(file);
                PathScanner scanner = scannerFactory.BuildPathScanner();
            });
        }

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

        private void AllowReadData(string path, bool isDirectory, bool allowRead)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Dynamically will be set to correct type supplied by user
                dynamic fsInfo = isDirectory ? new DirectoryInfo(path) : new FileInfo(path);
                dynamic fsSec = FileSystemAclExtensions.GetAccessControl(fsInfo);

                fsSec.ModifyAccessRule(allowRead ? AccessControlModification.Remove : AccessControlModification.Add, _winAcl, out bool result);

                FileSystemAclExtensions.SetAccessControl(fsInfo, fsSec);
            }
#if !NETFRAMEWORK
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                FilePermissions permissions = (allowRead ?
                    (FilePermissions.S_IRWXU | FilePermissions.S_IRWXG | FilePermissions.S_IRWXO) :
                    (FilePermissions.S_IWUSR | FilePermissions.S_IWGRP | FilePermissions.S_IWOTH));

                Syscall.chmod(path, permissions);
            }
#endif
        }
    }
}
