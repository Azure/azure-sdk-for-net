// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    public class ShareDirectoryStartTransferCopyTests : StartTransferDirectoryCopyTestBase<
        ShareServiceClient,
        ShareClient,
        ShareClientOptions,
        ShareServiceClient,
        ShareClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        protected override async Task CreateObjectInSource(
            ShareClient containerClient,
            string objectName = null,
            long? size = null)
        {
            objectName ??= GetNewObjectName();
            ShareFileClient fileClient = containerClient.GetRootDirectoryClient().GetFileClient(objectName);
            size ??= 0;
            await fileClient.CreateAsync(size.Value);

            // Upload random content if the size is non-zero
            if ()
        }

        protected override async Task CreateObjectInSource(
            ShareClient containerClient,
            string objectName = null,
            Stream content = null)
        {
            objectName ??= GetNewObjectName();
            ShareFileClient fileClient = containerClient.GetRootDirectoryClient().GetFileClient(objectName);
            if (content != null)
            {
                await fileClient.UploadAsync(content);
            }
            using Stream originalStream = await CreateLimitedMemoryStream(size);
        }

        protected override Task<IDisposingContainer<ShareClient>> GetDestinationDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
        {
            throw new NotImplementedException();
        }

        protected override StorageResourceContainer GetDestinationStorageResourceContainer(ShareClient containerClient, string prefix)
        {
            throw new NotImplementedException();
        }

        protected override Task<IDisposingContainer<ShareClient>> GetSourceDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
        {
            throw new NotImplementedException();
        }

        protected override StorageResourceContainer GetSourceStorageResourceContainer(ShareClient containerClient, string prefix = null)
        {
            throw new NotImplementedException();
        }

        protected override async Task VerifyResults(
            ShareClient sourceContainer,
            ShareClient destinationContainer,
            string sourcePrefix = default,
            string destiantionPrefix = default)
        {
            // List all files in source blob folder path
            List<string> sourceNames = new List<string>();

            // Get source directory client and list the paths
            ShareDirectoryClient sourceDirectory = string.IsNullOrEmpty(sourcePrefix) ?
                sourceContainer.GetRootDirectoryClient() :
                sourceContainer.GetDirectoryClient(sourcePrefix);
            await foreach (Page<ShareFileItem> page in sourceDirectory.GetFilesAndDirectoriesAsync().AsPages())
            {
                sourceNames.AddRange(page.Values.Select((ShareFileItem item) => item.Name));
            }

            // List all files in the destination blob folder path
            List<string> destinationNames = new List<string>();

            ShareDirectoryClient destinationDirectory = string.IsNullOrEmpty(destiantionPrefix) ?
                destinationContainer.GetRootDirectoryClient() :
                destinationContainer.GetDirectoryClient(sourcePrefix);
            await foreach (Page<ShareFileItem> page in destinationDirectory.GetFilesAndDirectoriesAsync().AsPages())
            {
                destinationNames.AddRange(page.Values.Select((ShareFileItem item) => item.Name));
            }
            Assert.AreEqual(sourceNames.Count, destinationNames.Count);
            sourceNames.Sort();
            destinationNames.Sort();
            for (int i = 0; i < sourceNames.Count; i++)
            {
                // Verify file name to match the
                // (prefix folder path) + (the blob name without the blob folder prefix)
                // TODO: verify if files returns the entire path, and if we really need to be parsing the prefix
                string sourceNonPrefixed = sourceNames[i].Substring(sourcePrefix.Length + 1);
                Assert.AreEqual(
                    sourceNonPrefixed,
                    destinationNames[i].Substring(destiantionPrefix.Length + 1));

                // Verify Download
                string sourceFileName = Path.Combine(sourcePrefix, sourceNonPrefixed);
                using Stream sourceStream = await sourceDirectory.GetFileClient(sourceNames[i]).OpenReadAsync();
                using Stream destinationStream = await destinationDirectory.GetFileClient(destinationNames[i]).OpenReadAsync();
                Assert.AreEqual(sourceStream, destinationStream);
            }
        }
    }
}
