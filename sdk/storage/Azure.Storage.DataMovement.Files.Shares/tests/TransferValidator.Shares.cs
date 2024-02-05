// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.DataMovement.Tests
{
    public partial class TransferValidator
    {
        public class ShareFileResourceEnumerationItem : IResourceEnumerationItem
        {
            private readonly ShareFileClient _client;

            public string RelativePath { get; }

            public ShareFileResourceEnumerationItem(ShareFileClient client, string relativePath)
            {
                _client = client;
                RelativePath = relativePath;
            }

            public async Task<Stream> OpenReadAsync(CancellationToken cancellationToken)
            {
                return await _client.OpenReadAsync(cancellationToken: cancellationToken);
            }
        }

        public static ListFilesAsync GetShareFileLister(ShareDirectoryClient container)
        {
            async Task<List<IResourceEnumerationItem>> ListFilesRecursive(ShareDirectoryClient dir, CancellationToken cancellationToken)
            {
                List<IResourceEnumerationItem> result = new();
                await foreach (ShareFileItem fileItem in dir.GetFilesAndDirectoriesAsync(cancellationToken: cancellationToken))
                {
                    if (fileItem.IsDirectory)
                    {
                        result.AddRange(await ListFilesRecursive(dir.GetSubdirectoryClient(fileItem.Name), cancellationToken));
                    }
                    else
                    {
                        ShareFileClient fileClient = dir.GetFileClient(fileItem.Name);
                        result.Add(new ShareFileResourceEnumerationItem(
                            fileClient, fileClient.Path.Substring(container.Path.Length).Trim('/')));
                    }
                }
                return result;
            }
            return (cancellationToken) => ListFilesRecursive(container, cancellationToken);
        }

        public static ListFilesAsync GetShareFileListerSingle(ShareFileClient file, string relativePath)
        {
            Task<List<IResourceEnumerationItem>> ListFile(CancellationToken cancellationToken)
            {
                return Task.FromResult(new List<IResourceEnumerationItem>
                {
                    new ShareFileResourceEnumerationItem(file, relativePath)
                });
            }
            return ListFile;
        }
    }
}
