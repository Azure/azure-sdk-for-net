// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        public class ShareResourceEnumerationItem : IResourceEnumerationItem
        {
            private readonly ShareFileClient _client;

            public string RelativePath { get; }

            public ShareResourceEnumerationItem(ShareFileClient client, string relativePath)
            {
                _client = client;
                RelativePath = relativePath;
            }

            public async Task<Stream> OpenReadAsync(CancellationToken cancellationToken)
            {
                return await _client.OpenReadAsync(cancellationToken: cancellationToken);
            }
        }

        public static ListFilesAsync GetShareFilesLister(ShareClient container, string prefix)
        {
            async Task<List<IResourceEnumerationItem>> ListFiles(CancellationToken cancellationToken)
            {
                List<IResourceEnumerationItem> result = new();
                ShareDirectoryClient directory = string.IsNullOrEmpty(prefix) ?
                    container.GetRootDirectoryClient() :
                    container.GetDirectoryClient(prefix);

                Queue<ShareDirectoryClient> toScan = new();
                toScan.Enqueue(directory);

                while (toScan.Count > 0)
                {
                    ShareDirectoryClient current = toScan.Dequeue();
                    await foreach (ShareFileItem item in current.GetFilesAndDirectoriesAsync(
                        cancellationToken: cancellationToken).ConfigureAwait(false))
                    {
                        if (item.IsDirectory)
                        {
                            ShareDirectoryClient subdir = current.GetSubdirectoryClient(item.Name);
                            toScan.Enqueue(subdir);
                        }
                        else
                        {
                            string relativePath = "";
                            if (string.IsNullOrEmpty(current.Path))
                            {
                                relativePath = item.Name;
                            }
                            else if (string.IsNullOrEmpty(prefix))
                            {
                                relativePath = string.Join("/", current.Path, item.Name);
                            }
                            else
                            {
                                relativePath =
                                    prefix != current.Name ?
                                    string.Join("/", current.Path.Substring(prefix.Length + 1), item.Name) :
                                    item.Name;
                            }
                            result.Add(new ShareResourceEnumerationItem(current.GetFileClient(item.Name), relativePath));
                        }
                    }
                }
                return result;
            }
            return ListFiles;
        }

        public static ListFilesAsync GetFileListerSingle(ShareFileClient file, string relativePath)
        {
            Task<List<IResourceEnumerationItem>> ListFiles(CancellationToken cancellationToken)
            {
                return Task.FromResult(new List<IResourceEnumerationItem>
                {
                    new ShareResourceEnumerationItem(file, relativePath)
                });
            }
            return ListFiles;
        }
    }
}
