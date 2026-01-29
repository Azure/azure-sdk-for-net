// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement.Tests
{
    public partial class TransferValidator
    {
        public class LocalFileResourceEnumerationItem : IResourceEnumerationItem
        {
            private readonly string _localFilePath;

            public string RelativePath { get; }

            public LocalFileResourceEnumerationItem(string localFilePath, string relativePath)
            {
                _localFilePath = localFilePath;
                RelativePath = relativePath;
            }

            public Task<Stream> OpenReadAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(File.OpenRead(_localFilePath) as Stream);
            }
        }

        public static ListFilesAsync GetLocalFileLister(string directoryPath)
        {
            directoryPath = directoryPath.TrimEnd(Path.DirectorySeparatorChar);
            Task<List<IResourceEnumerationItem>> ListFiles(CancellationToken cancellationToken)
            {
                List<IResourceEnumerationItem> result = new();
                Queue<string> directories = new();
                directories.Enqueue(directoryPath);
                while (directories.Count > 0)
                {
                    string workingDir = directories.Dequeue();
                    foreach (string dirPath in Directory.GetDirectories(workingDir))
                    {
                        directories.Enqueue(dirPath);
                    }
                    foreach (string filePath in Directory.GetFiles(workingDir))
                    {
                        result.Add(new LocalFileResourceEnumerationItem(filePath, filePath.Substring(directoryPath.Length + 1)));
                    }
                }
                return Task.FromResult(result);
            }
            return ListFiles;
        }

        public static ListFilesAsync GetLocalFileListerSingle(string filePath, string relativePath)
        {
            Task<List<IResourceEnumerationItem>> ListFiles(CancellationToken cancellationToken)
            {
                return Task.FromResult(new List<IResourceEnumerationItem>()
                {
                    new LocalFileResourceEnumerationItem(filePath, relativePath)
                });
            }
            return ListFiles;
        }
    }
}
