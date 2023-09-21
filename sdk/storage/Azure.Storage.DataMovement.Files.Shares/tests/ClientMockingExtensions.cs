// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Moq;
using Azure.Storage.Tests;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    internal static class ClientMockingExtensions
    {
        public static Mock<ShareFileClient> WithUri(
            this Mock<ShareFileClient> mock,
            Uri uri)
        {
            mock.Setup(m => m.Uri).Returns(uri);
            ShareUriBuilder builder = new(uri);
            mock.Setup(m => m.AccountName).Returns(builder.AccountName);
            mock.Setup(m => m.ShareName).Returns(builder.ShareName);
            mock.Setup(m => m.Path).Returns(builder.DirectoryOrFilePath);
            mock.Setup(m => m.Name).Returns(builder.DirectoryOrFilePath.Split('/').Last());
            return mock;
        }

        public static Mock<ShareDirectoryClient> WithUri(
            this Mock<ShareDirectoryClient> mock,
            Uri uri)
        {
            mock.Setup(m => m.Uri).Returns(uri);
            ShareUriBuilder builder = new(uri);
            mock.Setup(m => m.AccountName).Returns(builder.AccountName);
            mock.Setup(m => m.ShareName).Returns(builder.ShareName);
            mock.Setup(m => m.Path).Returns(builder.DirectoryOrFilePath);
            mock.Setup(m => m.Name).Returns(builder.DirectoryOrFilePath.Split('/').Last());
            return mock;
        }

        /// <summary>
        /// </summary>
        /// <param name="mock"></param>
        /// <param name="fileStructure">
        /// Tree of strings signifying file structure to mock.
        /// When provided, calls to <see cref="ShareDirectoryClient.GetSubdirectoryClient(string)"/>
        /// and <see cref="ShareDirectoryClient.GetFileClient(string)"/> will only work according to
        /// the tree. Otherwise, all invocations will work.
        /// </param>
        public static Mock<ShareDirectoryClient> WithDirectoryStructure(
            this Mock<ShareDirectoryClient> mock,
            Tree<(string Name, bool IsDirectory)> directoryStructure = default)
        {
            mock.Setup(m => m.GetFileClient(It.IsAny<string>()))
                .Returns<string>(name =>
                {
                    _ = directoryStructure.FirstOrDefault(d => !d.Value.IsDirectory && d.Value.Name == name)
                        ?? throw new FileNotFoundException("File not in test directory structure.");
                    UriBuilder uriBuilder = new UriBuilder(mock.Object.Uri);
                    uriBuilder.Path = Path.Combine(uriBuilder.Path, name);
                    Mock<ShareFileClient> file = new();
                    return file.WithUri(uriBuilder.Uri).Object;
                });
            mock.Setup(m => m.GetSubdirectoryClient(It.IsAny<string>()))
                .Returns<string>(name =>
                {
                   var subDirStructure = directoryStructure.FirstOrDefault(d => d.Value.IsDirectory && d.Value.Name == name)
                        ?? throw new DirectoryNotFoundException("Directory not in test directory structure.");
                    UriBuilder uriBuilder = new UriBuilder(mock.Object.Uri);
                    uriBuilder.Path = Path.Combine(uriBuilder.Path, name);
                    Mock<ShareDirectoryClient> directory = new();
                    return directory.WithUri(uriBuilder.Uri).WithDirectoryStructure(subDirStructure).Object;
                });
            mock.Setup(m => m.GetFilesAndDirectoriesAsync(
                    It.IsAny<ShareDirectoryGetFilesAndDirectoriesOptions>(),
                    It.IsAny<CancellationToken>())
                ).Returns<ShareDirectoryGetFilesAndDirectoriesOptions, CancellationToken>(
                    (options, cancellationToken) => directoryStructure
                        .Select(elem => FilesModelFactory.ShareFileItem(
                            isDirectory: elem.Value.IsDirectory, name: elem.Value.Name))
                        .AsAsyncPageable()
                );

            return mock;
        }

        public static Tree<(string Name, bool IsDirectory)> AsTree(this IEnumerable<(string Path, bool IsDirectory)> files, string rootDirName = "")
        {
            Tree<(string Name, bool IsDirectory)> tree = new()
            {
                Value = (rootDirName, true)
            };
            foreach ((string path, bool isDirectory) in files)
            {
                Tree<(string Name, bool IsDirectory)> curr = tree;
                string[] pathSegments = path.Split('/');
                foreach (string pathSegment in pathSegments.Take(pathSegments.Length - 1))
                {
                    Tree<(string Name, bool IsDirectory)> next = curr.FirstOrDefault(
                        t => t.Value.Name == pathSegment && t.Value.IsDirectory == true)
                        ?? new() { Value = (Name: pathSegment, IsDirectory: true) };
                    curr.Add(next);
                    curr = next;
                }
                curr.Add(new() { Value = (Name: pathSegments.Last(), IsDirectory: isDirectory) });
            }
            return tree;
        }
    }
}
