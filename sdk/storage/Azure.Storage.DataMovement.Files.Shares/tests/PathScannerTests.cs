// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Moq;
using NUnit.Framework;
using static System.Net.WebRequestMethods;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    internal class PathScannerTests
    {
        [TestCase("")]
        [TestCase("somedir")]
        public async Task PathScannerFindsAllRecursive(string baseDirName)
        {
            const string shareName = "myshare";
            List<(string Path, bool IsDirectory)> paths = new()
            {
                (Path: "foo/file1-1", IsDirectory: false),
                (Path: "foo/file1-2", IsDirectory: false),
                (Path: "bar/fizz/file2-1", IsDirectory: false),
                (Path: "bar/buzz/emptydir", IsDirectory: true),
            };
            List<string> expectedFilePaths = new List<string>()
            {
                baseDirName + "/" + "foo/file1-1",
                baseDirName + "/" + "foo/file1-2",
                baseDirName + "/" + "bar/fizz/file2-1",
            }.Select(s => s.Trim('/')).ToList();
            List<string> expectedDirectoryPaths = new List<string>()
            {
                baseDirName + "/" + "foo",
                baseDirName + "/" + "bar",
                baseDirName + "/" + "bar/fizz",
                baseDirName + "/" + "bar/buzz",
                baseDirName + "/" + "bar/buzz/emptydir",
            }.Select(s => s.Trim('/')).ToList();

            Uri dirUri = new UriBuilder()
            {
                Scheme = "https",
                Host = "myaccount.file.core.windows.net",
                Path = (shareName + "/" + baseDirName).Trim('/')
            }.Uri;
            Mock<ShareDirectoryClient> directoryClient = new Mock<ShareDirectoryClient>()
                .WithUri(dirUri)
                .WithDirectoryStructure(paths.AsTree());

            List<ShareFileClient> files = new();
            List<ShareDirectoryClient> directories = new();
            await foreach ((ShareDirectoryClient dir, ShareFileClient file)
                in new PathScanner().ScanAsync(directoryClient.Object, default))
            {
                if (file != default) files.Add(file);
                if (dir != default) directories.Add(dir);
            }

            Assert.That(files.Select(f => f.Path), Is.EquivalentTo(expectedFilePaths));
            Assert.That(directories.Select(f => f.Path), Is.EquivalentTo(expectedDirectoryPaths));
        }

        [TestCase("")]
        [TestCase("somedir")]
        public async Task PathScannerFilesRecursive(string baseDirName)
        {
            const string shareName = "myshare";
            List<(string Path, bool IsDirectory)> paths = new()
            {
                (Path: "foo/file1-1", IsDirectory: false),
                (Path: "foo/file1-2", IsDirectory: false),
                (Path: "bar/fizz/file2-1", IsDirectory: false),
                (Path: "bar/buzz/emptydir", IsDirectory: true),
            };
            List<string> expectedFilePaths = new List<string>()
            {
                baseDirName + "/" + "foo/file1-1",
                baseDirName + "/" + "foo/file1-2",
                baseDirName + "/" + "bar/fizz/file2-1",
            }.Select(s => s.Trim('/')).ToList();

            Uri dirUri = new UriBuilder()
            {
                Scheme = "https",
                Host = "myaccount.file.core.windows.net",
                Path = (shareName + "/" + baseDirName).Trim('/')
            }.Uri;
            Mock<ShareDirectoryClient> directoryClient = new Mock<ShareDirectoryClient>()
                .WithUri(dirUri)
                .WithDirectoryStructure(paths.AsTree());

            List<ShareFileClient> files = new();
            await foreach (ShareFileClient file in new PathScanner().ScanFilesAsync(directoryClient.Object, default))
            {
                files.Add(file);
            }

            Assert.That(files.Select(f => f.Path), Is.EquivalentTo(expectedFilePaths));
        }
    }
}
