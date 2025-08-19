// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Azure.Core;
using Azure.Identity;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using NUnit.Framework;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Threading;

namespace Azure.Storage.Blobs.Samples
{
    /// <summary>
    /// v12 snippets for Blob Storage migration samples.
    /// </summary>
    public class Sample03_Migrations : SampleTest
    {
        /// <summary>
        /// Authenticate with a token credential.
        /// </summary>
        [Test]
        public void AuthWithTokenCredential()
        {
            string serviceUri = this.StorageAccountBlobUri.ToString();

            #region Snippet:SampleSnippetsBlobMigration_TokenCredential
            BlobServiceClient client = new BlobServiceClient(new Uri(serviceUri), new DefaultAzureCredential());
            #endregion

            client.GetProperties();
            Assert.Pass();
        }

        /// <summary>
        /// Authenticate with a SAS.
        /// </summary>
        [Test]
        public void AuthWithSasCredential()
        {
            //setup blob
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-file");
            var container = new BlobContainerClient(ConnectionString, containerName);

            try
            {
                container.Create();
                BlobClient blobClient = container.GetBlobClient(blobName);
                blobClient.Upload(BinaryData.FromString("hello world"));

                // build SAS URI for sample
                Uri sasUri = blobClient.GenerateSasUri(BlobSasPermissions.All, DateTimeOffset.UtcNow.AddHours(1));

                #region Snippet:SampleSnippetsBlobMigration_SasUri
                BlobClient blob = new BlobClient(sasUri);
                #endregion

                var stream = new MemoryStream();
                blob.DownloadTo(stream);
                Assert.Greater(stream.Length, 0);
            }
            finally
            {
                container.Delete();
            }
        }

        /// <summary>
        /// Authenticate with a connection string.
        /// </summary>
        [Test]
        public void AuthWithConnectionString()
        {
            string connectionString = this.ConnectionString;

            #region Snippet:SampleSnippetsBlobMigration_ConnectionString
            BlobServiceClient service = new BlobServiceClient(connectionString);
            #endregion

            service.GetProperties();
            Assert.Pass();
        }

        /// <summary>
        /// Authenticate with a connection string.
        /// </summary>
        [Test]
        public async Task AuthWithConnectionStringDirectToBlob()
        {
            // setup blob
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-file");
            var container = new BlobContainerClient(ConnectionString, containerName);

            try
            {
                await container.CreateAsync();
                await container.GetBlobClient(blobName).UploadAsync(BinaryData.FromString("hello world"));

                string connectionString = this.ConnectionString;

                #region Snippet:SampleSnippetsBlobMigration_ConnectionStringDirectBlob
                BlobClient blob = new BlobClient(connectionString, containerName, blobName);
                #endregion

                var stream = new MemoryStream();
                blob.DownloadTo(stream);
                Assert.Greater(stream.Length, 0);
            }
            finally
            {
                await container.DeleteAsync();
            }
        }

        /// <summary>
        /// Authenticate with a shared key.
        /// </summary>
        [Test]
        public void AuthWithSharedKey()
        {
            string accountName = StorageAccountName;
            string accountKey = StorageAccountKey;
            string blobServiceUri = StorageAccountBlobUri.ToString();

            #region Snippet:SampleSnippetsBlobMigration_SharedKey
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(accountName, accountKey);
            BlobServiceClient service = new BlobServiceClient(new Uri(blobServiceUri), credential);
            #endregion

            service.GetProperties();
            Assert.Pass();
        }

        /// <summary>
        /// Authenticate with a shared key.
        /// </summary>
        [Test]
        public async Task CreateSharedAccessPolicy()
        {
            string connectionString = this.ConnectionString;
            string containerName = Randomize("sample-container");
            BlobContainerClient containerClient = new BlobContainerClient(connectionString, containerName);

            try
            {
                await containerClient.CreateIfNotExistsAsync();

                #region Snippet:SampleSnippetsBlobMigration_SharedAccessPolicy
                // Create one or more stored access policies.
                List<BlobSignedIdentifier> signedIdentifiers = new List<BlobSignedIdentifier>
                {
                    new BlobSignedIdentifier
                    {
                        Id = "mysignedidentifier",
                        AccessPolicy = new BlobAccessPolicy
                        {
                            StartsOn = DateTimeOffset.UtcNow.AddHours(-1),
                            ExpiresOn = DateTimeOffset.UtcNow.AddDays(1),
                            Permissions = "rw"
                        }
                    }
                };
                // Set the container's access policy.
                await containerClient.SetAccessPolicyAsync(permissions: signedIdentifiers);
                #endregion

                BlobContainerAccessPolicy containerAccessPolicy = containerClient.GetAccessPolicy();
                Assert.AreEqual(signedIdentifiers.First().Id, containerAccessPolicy.SignedIdentifiers.First().Id);
            }
            finally
            {
                await containerClient.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task CreateContainer()
        {
            string connectionString = this.ConnectionString;
            string containerName = Randomize("sample-container");

            // use extra variable so the snippet gets variable declarations but we still get the try/finally
            var containerClientTracker = new BlobServiceClient(connectionString).GetBlobContainerClient(containerName);

            try
            {
                #region Snippet:SampleSnippetsBlobMigration_CreateContainer
                BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                await containerClient.CreateAsync();
                #endregion

                // pass if success
                containerClient.GetProperties();
            }
            finally
            {
                await containerClientTracker.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task CreateContainerShortcut()
        {
            string connectionString = this.ConnectionString;
            string containerName = Randomize("sample-container");

            // use extra variable so the snippet gets variable declarations but we still get the try/finally
            var containerClientTracker = new BlobServiceClient(connectionString).GetBlobContainerClient(containerName);

            try
            {
            #region Snippet:SampleSnippetsBlobMigration_CreateContainerShortcut
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
            #endregion

            // pass if success
            containerClient.GetProperties();
            }
            finally
            {
                await containerClientTracker.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task UploadBlob()
        {
            string data = "hello world";

            BlobContainerClient containerClient = new BlobContainerClient(ConnectionString, Randomize("sample-container"));
            try
            {
                await containerClient.CreateAsync();
                string blobName = Randomize("sample-blob");

                string localFilePath = this.CreateTempPath();
                FileStream fs = File.OpenWrite(localFilePath);
                var bytes = Encoding.UTF8.GetBytes(data);
                await fs.WriteAsync(bytes, 0, bytes.Length);
                await fs.FlushAsync();
                fs.Close();

                #region Snippet:SampleSnippetsBlobMigration_UploadBlob
                BlobClient blobClient = containerClient.GetBlobClient(blobName);
                await blobClient.UploadAsync(localFilePath, overwrite: true);
                #endregion

                Stream downloadStream = (await blobClient.DownloadStreamingAsync()).Value.Content;
                string downloadedData = await new StreamReader(downloadStream).ReadToEndAsync();
                downloadStream.Close();

                Assert.AreEqual(data, downloadedData);
            }
            finally
            {
                await containerClient.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task UploadBlobFromStream()
        {
            string data = "hello world";

            BlobContainerClient containerClient = new BlobContainerClient(ConnectionString, Randomize("sample-container"));
            try
            {
                await containerClient.CreateAsync();
                string blobName = Randomize("sample-blob");

                string localFilePath = this.CreateTempPath();
                FileStream fs = File.OpenWrite(localFilePath);
                var bytes = Encoding.UTF8.GetBytes(data);
                await fs.WriteAsync(bytes, 0, bytes.Length);
                await fs.FlushAsync();
                fs.Close();

                #region Snippet:SampleSnippetsBlobMigration_UploadBlobFromStream
                BlobClient blobClient = containerClient.GetBlobClient(blobName);
                using Stream stream = File.OpenRead(localFilePath);
                await blobClient.UploadAsync(stream, overwrite: true);
                #endregion

                Stream downloadStream = (await blobClient.DownloadStreamingAsync()).Value.Content;
                string downloadedData = await new StreamReader(downloadStream).ReadToEndAsync();
                downloadStream.Close();

                Assert.AreEqual(data, downloadedData);
            }
            finally
            {
                await containerClient.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task UploadBlobText()
        {
            string data = "hello world";

            BlobContainerClient containerClient = new BlobContainerClient(ConnectionString, Randomize("sample-container"));
            try
            {
                await containerClient.CreateAsync();
                string blobName = Randomize("sample-blob");

                string localFilePath = this.CreateTempPath();
                FileStream fs = File.OpenWrite(localFilePath);
                var bytes = Encoding.UTF8.GetBytes(data);
                await fs.WriteAsync(bytes, 0, bytes.Length);
                await fs.FlushAsync();
                fs.Close();

                #region Snippet:SampleSnippetsBlobMigration_UploadBlobText
                BlobClient blobClient = containerClient.GetBlobClient(blobName);
                await blobClient.UploadAsync(BinaryData.FromString("hello world"), overwrite: true);
                #endregion

                BinaryData downloadedData = (await blobClient.DownloadContentAsync()).Value.Content;

                Assert.AreEqual(data, downloadedData.ToString());
            }
            finally
            {
                await containerClient.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task DownloadBlob()
        {
            string data = "hello world";

            //setup blob
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-file");
            var containerClient = new BlobContainerClient(ConnectionString, containerName);
            string downloadFilePath = this.CreateTempPath();

            try
            {
                containerClient.Create();
                containerClient.GetBlobClient(blobName).Upload(BinaryData.FromString(data));

                #region Snippet:SampleSnippetsBlobMigration_DownloadBlob
                BlobClient blobClient = containerClient.GetBlobClient(blobName);
                await blobClient.DownloadToAsync(downloadFilePath);
                #endregion

                FileStream fs = File.OpenRead(downloadFilePath);
                string downloadedData = await new StreamReader(fs).ReadToEndAsync();
                fs.Close();

                Assert.AreEqual(data, downloadedData);
            }
            finally
            {
                await containerClient.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task DownloadBlobToStream()
        {
            string data = "hello world";

            //setup blob
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-file");
            var containerClient = new BlobContainerClient(ConnectionString, containerName);
            string downloadFilePath = this.CreateTempPath();

            try
            {
                containerClient.Create();
                containerClient.GetBlobClient(blobName).Upload(BinaryData.FromString(data));

                #region Snippet:SampleSnippetsBlobMigration_DownloadBlobToStream
                BlobClient blobClient = containerClient.GetBlobClient(blobName);
                using (Stream target = File.OpenWrite(downloadFilePath))
                {
                    await blobClient.DownloadToAsync(target);
                }
                #endregion

                FileStream fs = File.OpenRead(downloadFilePath);
                string downloadedData = await new StreamReader(fs).ReadToEndAsync();
                fs.Close();

                Assert.AreEqual(data, downloadedData);
            }
            finally
            {
                await containerClient.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task DownloadBlobText()
        {
            string data = "hello world";

            //setup blob
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-file");
            var containerClient = new BlobContainerClient(ConnectionString, containerName);

            try
            {
                containerClient.Create();
                containerClient.GetBlobClient(blobName).Upload(BinaryData.FromString(data));

                #region Snippet:SampleSnippetsBlobMigration_DownloadBlobText
                BlobClient blobClient = containerClient.GetBlobClient(blobName);
                BlobDownloadResult downloadResult = await blobClient.DownloadContentAsync();
                string downloadedData = downloadResult.Content.ToString();
                #endregion

                Assert.AreEqual(data, downloadedData);
            }
            finally
            {
                await containerClient.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task ListBlobs()
        {
            string data = "hello world";
            string containerName = Randomize("sample-container");
            var containerClient = new BlobContainerClient(ConnectionString, containerName);

            try
            {
                containerClient.Create();
                HashSet<string> blobNames = new HashSet<string>();

                foreach (var _ in Enumerable.Range(0, 10))
                {
                    string blobName = Randomize("sample-blob");
                    containerClient.GetBlobClient(blobName).Upload(BinaryData.FromString(data));
                    blobNames.Add(blobName);
                }

                // tools to consume blob listing while looking good in the sample snippet
                HashSet<string> downloadedBlobNames = new HashSet<string>();
                void MyConsumeBlobItemFunc(BlobItem item)
                {
                    downloadedBlobNames.Add(item.Name);
                }

                #region Snippet:SampleSnippetsBlobMigration_ListBlobs
                IAsyncEnumerable<BlobItem> results = containerClient.GetBlobsAsync();
                await foreach (BlobItem item in results)
                {
                    MyConsumeBlobItemFunc(item);
                }
                #endregion

                Assert.IsTrue(blobNames.SetEquals(downloadedBlobNames));
            }
            finally
            {
                await containerClient.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task ListBlobsManual()
        {
            string data = "hello world";
            string containerName = Randomize("sample-container");
            var containerClient = new BlobContainerClient(ConnectionString, containerName);

            try
            {
                containerClient.Create();
                HashSet<string> blobNames = new HashSet<string>();

                foreach (var _ in Enumerable.Range(0, 10))
                {
                    string blobName = Randomize("sample-blob");
                    containerClient.GetBlobClient(blobName).Upload(BinaryData.FromString(data));
                    blobNames.Add(blobName);
                }

                // tools to consume blob listing while looking good in the sample snippet
                HashSet<string> downloadedBlobNames = new HashSet<string>();
                void MyConsumeBlobItemFunc(BlobItem item)
                {
                    downloadedBlobNames.Add(item.Name);
                }

                #region Snippet:SampleSnippetsBlobMigration_ListBlobsManual
                // set this to already existing continuation token to pick up where you previously left off
                string initialContinuationToken = null;
                AsyncPageable<BlobItem> results = containerClient.GetBlobsAsync();
                IAsyncEnumerable<Page<BlobItem>> pages =  results.AsPages(initialContinuationToken);

                // the foreach loop requests the next page of results every loop
                // you do not need to explicitly access the continuation token just to get the next page
                // to stop requesting new pages, break from the loop
                // you also have access to the contination token returned with each page if needed
                await foreach (Page<BlobItem> page in pages)
                {
                    // process page
                    foreach (BlobItem item in page.Values)
                    {
                        MyConsumeBlobItemFunc(item);
                    }

                    // access continuation token if desired
                    string continuationToken = page.ContinuationToken;
                }
                #endregion

                Assert.IsTrue(blobNames.SetEquals(downloadedBlobNames));
            }
            finally
            {
                await containerClient.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task ListBlobsHierarchy()
        {
            string data = "hello world";
            string virtualDirName = Randomize("sample-virtual-dir");
            string containerName = Randomize("sample-container");
            var containerClient = new BlobContainerClient(ConnectionString, containerName);

            try
            {
                containerClient.Create();

                foreach (var blobName in new List<string> { "foo.txt", "bar.txt", virtualDirName + "/fizz.txt", virtualDirName + "/buzz.txt" })
                {
                    containerClient.GetBlobClient(blobName).Upload(BinaryData.FromString(data));
                }
                var expectedBlobNamesResult = new HashSet<string> { "foo.txt", "bar.txt" };

                // tools to consume blob listing while looking good in the sample snippet
                HashSet<string> downloadedBlobNames = new HashSet<string>();
                HashSet<string> downloadedPrefixNames = new HashSet<string>();
                void MyConsumeBlobItemFunc(BlobHierarchyItem item)
                {
                    if (item.IsPrefix)
                    {
                        downloadedPrefixNames.Add(item.Prefix);
                    }
                    else
                    {
                        downloadedBlobNames.Add(item.Blob.Name);
                    }
                }

                // show in snippet where the prefix goes, but our test doesn't want a prefix for its data set
                string blobPrefix = null;
                string delimiter = "/";

                #region Snippet:SampleSnippetsBlobMigration_ListHierarchy

                GetBlobsByHierarchyOptions options = new GetBlobsByHierarchyOptions
                {
                    Prefix = blobPrefix,
                    Delimiter = delimiter
                };
                IAsyncEnumerable<BlobHierarchyItem> results = containerClient.GetBlobsByHierarchyAsync(options);
                await foreach (BlobHierarchyItem item in results)
                {
                    MyConsumeBlobItemFunc(item);
                }
                #endregion

                Assert.IsTrue(expectedBlobNamesResult.SetEquals(downloadedBlobNames));
                Assert.IsTrue(new HashSet<string> { virtualDirName + '/' }.SetEquals(downloadedPrefixNames));
            }
            finally
            {
                await containerClient.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task EditMetadata()
        {
            string data = "hello world";
            var initialMetadata = new Dictionary<string, string> { { "fizz", "buzz" } };

            string containerName = Randomize("sample-container");
            var containerClient = new BlobContainerClient(ConnectionString, containerName);

            try
            {
                containerClient.Create();
                BlobClient blobClient = containerClient.GetBlobClient(Randomize("sample-blob"));
                await blobClient.UploadAsync(BinaryData.FromString(data), new BlobUploadOptions { Metadata = initialMetadata });

                #region Snippet:SampleSnippetsBlobMigration_EditMetadata
                IDictionary<string, string> metadata = blobClient.GetProperties().Value.Metadata;
                metadata.Add("foo", "bar");
                blobClient.SetMetadata(metadata);
                #endregion

                var expectedMetadata = new Dictionary<string, string> { { "foo", "bar" }, { "fizz", "buzz" } };
                var actualMetadata = (await blobClient.GetPropertiesAsync()).Value.Metadata;
                Assert.AreEqual(expectedMetadata.Count, actualMetadata.Count);
                foreach (var expectedKvp in expectedMetadata)
                {
                    Assert.IsTrue(actualMetadata.TryGetValue(expectedKvp.Key, out var actualValue));
                    Assert.AreEqual(expectedKvp.Value, actualValue);
                }
            }
            finally
            {
                await containerClient.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task EditBlobWithMetadata()
        {
            string data = "hello world";
            var initialMetadata = new Dictionary<string, string> { { "fizz", "buzz" } };

            string containerName = Randomize("sample-container");
            var containerClient = new BlobContainerClient(ConnectionString, containerName);

            try
            {
                containerClient.Create();
                BlobClient blobClient = containerClient.GetBlobClient(Randomize("sample-blob"));
                await blobClient.UploadAsync(BinaryData.FromString(data), new BlobUploadOptions { Metadata = initialMetadata });

                #region Snippet:SampleSnippetsBlobMigration_EditBlobWithMetadata
                // download blob content and metadata
                BlobDownloadResult blobData = blobClient.DownloadContent();

                // modify blob content
                string modifiedBlobContent = blobData.Content + "FizzBuzz";

                // reupload modified blob content while preserving metadata
                // not adding metadata is a metadata clear
                blobClient.Upload(
                    BinaryData.FromString(modifiedBlobContent),
                    new BlobUploadOptions() { Metadata = blobData.Details.Metadata });
                #endregion

                var actualMetadata = (await blobClient.GetPropertiesAsync()).Value.Metadata;
                Assert.AreEqual(initialMetadata.Count, actualMetadata.Count);
                foreach (var expectedKvp in initialMetadata)
                {
                    Assert.IsTrue(actualMetadata.TryGetValue(expectedKvp.Key, out var actualValue));
                    Assert.AreEqual(expectedKvp.Value, actualValue);
                }
            }
            finally
            {
                await containerClient.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task SasBuilder()
        {
            string accountName = StorageAccountName;
            string accountKey = StorageAccountKey;
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-blob");
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(StorageAccountName, StorageAccountKey);

            // setup blob
            var container = new BlobContainerClient(ConnectionString, containerName);

            try
            {
                await container.CreateAsync();
                await container.GetBlobClient(blobName).UploadAsync(BinaryData.FromString("hello world"));

                #region Snippet:SampleSnippetsBlobMigration_SasBuilder
                // Create BlobSasBuilder and specify parameters
                BlobSasBuilder sasBuilder = new BlobSasBuilder(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddHours(1))
                {
                    // with no url in a client to read from, container and blob name must be provided if applicable
                    BlobContainerName = containerName,
                    BlobName = blobName
                };

                // Create full, self-authenticating URI to the resource
                BlobUriBuilder uriBuilder = new BlobUriBuilder(StorageAccountBlobUri)
                {
                    BlobContainerName = containerName,
                    BlobName = blobName,
                    Sas = sasBuilder.ToSasQueryParameters(sharedKeyCredential)
                };
                Uri sasUri = uriBuilder.ToUri();
                #endregion

                // successful download indicates pass
                await new BlobClient(sasUri).DownloadToAsync(new MemoryStream());
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task GenerateSas()
        {
            string accountName = StorageAccountName;
            string accountKey = StorageAccountKey;
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-blob");
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(StorageAccountName, StorageAccountKey);

            // setup blob
            var container = new BlobContainerClient(ConnectionString, containerName);
            BlobUriBuilder uriBuilder = new BlobUriBuilder(container.Uri) { BlobName = blobName };
            Uri blobUri = uriBuilder.ToUri();

            try
            {
                await container.CreateAsync();
                await container.GetBlobClient(blobName).UploadAsync(BinaryData.FromString("hello world"));

                #region Snippet:SampleSnippetsBlobMigration_GenerateSas
                // Create a BlobClient with a shared key credential
                BlobClient blobClient = new BlobClient(blobUri, sharedKeyCredential);

                Uri sasUri;
                // Ensure our client has the credentials required to generate a SAS
                if (blobClient.CanGenerateSasUri)
                {
                    // Create full, self-authenticating URI to the resource from the BlobClient
                    sasUri = blobClient.GenerateSasUri(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddHours(1));

                    // Use newly made as SAS URI to download the blob
                    await new BlobClient(sasUri).DownloadToAsync(new MemoryStream());
                }
                #endregion
                else
                {
                    Assert.Fail("Unable to create SAS URI");
                }
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task GenerateSas_Builder()
        {
            string accountName = StorageAccountName;
            string accountKey = StorageAccountKey;
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-blob");
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(StorageAccountName, StorageAccountKey);

            // setup blob
            var container = new BlobContainerClient(ConnectionString, containerName);
            BlobUriBuilder uriBuilder = new BlobUriBuilder(container.Uri) { BlobName = blobName };
            Uri blobUri = uriBuilder.ToUri();

            try
            {
                await container.CreateAsync();
                await container.GetBlobClient(blobName).UploadAsync(BinaryData.FromString("hello world"));

                // Create a BlobClient with a shared key credential
                BlobClient blobClient = new BlobClient(blobUri, sharedKeyCredential);
                // Create BlobSasBuilder and specify parameters
                #region Snippet:SampleSnippetsBlobMigration_GenerateSas_Builder
                BlobSasBuilder sasBuilder = new BlobSasBuilder(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddHours(1))
                {
                    // Since we are generating from the client, the client will have the container and blob name
                    // Specify any optional paremeters here
                    StartsOn = DateTimeOffset.UtcNow.AddHours(-1)
                };

                // Create full, self-authenticating URI to the resource from the BlobClient
                Uri sasUri = blobClient.GenerateSasUri(sasBuilder);
                #endregion

                // Use newly made as SAS URI to download the blob
                await new BlobClient(sasUri).DownloadToAsync(new MemoryStream());
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task SasBuilderIdentifier()
        {
            string accountName = StorageAccountName;
            string accountKey = StorageAccountKey;
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-blob");
            DateTimeOffset expiresOn = DateTimeOffset.UtcNow.AddDays(1);
            DateTimeOffset startsOn = DateTimeOffset.UtcNow.AddHours(-1);
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(StorageAccountName, StorageAccountKey);

            // setup blob
            var container = new BlobContainerClient(ConnectionString, containerName);

            try
            {
                await container.CreateAsync();
                BlobClient blobClient = container.GetBlobClient(blobName);
                await container.GetBlobClient(blobName).UploadAsync(BinaryData.FromString("hello world"));

                // Create one or more stored access policies.
                List<BlobSignedIdentifier> signedIdentifiers = new List<BlobSignedIdentifier>
                {
                    new BlobSignedIdentifier
                    {
                        Id = "mysignedidentifier",
                        AccessPolicy = new BlobAccessPolicy
                        {
                            StartsOn = startsOn,
                            ExpiresOn = expiresOn,
                            Permissions = "rw"
                        }
                    }
                };
                // Set the container's access policy.
                await container.SetAccessPolicyAsync(permissions: signedIdentifiers);

                #region Snippet:SampleSnippetsBlobMigration_SasBuilderIdentifier
                // Create BlobSasBuilder and specify parameters
                BlobSasBuilder sasBuilder = new BlobSasBuilder
                {
                    Identifier = "mysignedidentifier"
                };
                #endregion

                // Create full, self-authenticating URI to the resource
                Uri sasUri = blobClient.GenerateSasUri(sasBuilder);

                // successful download indicates pass
                await new BlobClient(sasUri).DownloadToAsync(new MemoryStream());
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task UserDelegationSasBuilder()
        {
            string accountName = StorageAccountName;
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-blob");
            BlobServiceClient client = new BlobServiceClient(ConnectionString);
            Response<UserDelegationKey> userDelegationKeyResponse = await client.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: DateTimeOffset.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // setup blob
            BlobContainerClient container = new BlobContainerClient(ConnectionString, containerName);

            try
            {
                await container.CreateAsync();
                await container.GetBlobClient(blobName).UploadAsync(BinaryData.FromString("hello world"));

                #region Snippet:SampleSnippetsBlobMigration_UserDelegationSasBuilder
                // Create BlobSasBuilder and specify parameters
                BlobSasBuilder sasBuilder = new BlobSasBuilder(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddHours(1))
                {
                    // with no url in a client to read from, container and blob name must be provided if applicable
                    BlobContainerName = containerName,
                    BlobName = blobName
                };

                // Create full, self-authenticating URI to the resource
                BlobUriBuilder uriBuilder = new BlobUriBuilder(StorageAccountBlobUri)
                {
                    BlobContainerName = containerName,
                    BlobName = blobName,
                    Sas = sasBuilder.ToSasQueryParameters(userDelegationKey, accountName)
                };
                Uri sasUri = uriBuilder.ToUri();
                #endregion

                // successful download indicates pass
                await new BlobClient(sasUri).DownloadToAsync(new MemoryStream());
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task GenerateUserDelegationSas()
        {
            string accountName = StorageAccountName;
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-blob");
            BlobServiceClient client = new BlobServiceClient(ConnectionString);
            Response<UserDelegationKey> userDelegationKeyResponse = await client.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: DateTimeOffset.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // setup blob
            BlobContainerClient container = new BlobContainerClient(ConnectionString, containerName);
            BlobUriBuilder uriBuilder = new BlobUriBuilder(container.Uri) { BlobName = blobName };
            Uri blobUri = uriBuilder.ToUri();

            try
            {
                await container.CreateAsync();
                await container.GetBlobClient(blobName).UploadAsync(BinaryData.FromString("hello world"));

                #region Snippet:SampleSnippetsBlobMigration_GenerateUserDelegationSas
                // Create a BlobClient
                BlobClient blobClient = new BlobClient(blobUri);

                // Create full, self-authenticating URI to the resource from the BlobClient
                Uri sasUri = blobClient.GenerateUserDelegationSasUri(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddHours(1), userDelegationKey);
                #endregion

                // Use newly made SAS URI to download the blob
                await new BlobClient(sasUri).DownloadToAsync(new MemoryStream());
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task GenerateUserDelegationSas_Builder()
        {
            string accountName = StorageAccountName;
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-blob");
            BlobServiceClient client = new BlobServiceClient(ConnectionString);
            Response<UserDelegationKey> userDelegationKeyResponse = await client.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: DateTimeOffset.UtcNow.AddHours(1));
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // setup blob
            BlobContainerClient container = new BlobContainerClient(ConnectionString, containerName);
            BlobUriBuilder uriBuilder = new BlobUriBuilder(container.Uri) { BlobName = blobName };
            Uri blobUri = uriBuilder.ToUri();

            try
            {
                await container.CreateAsync();
                await container.GetBlobClient(blobName).UploadAsync(BinaryData.FromString("hello world"));

                #region Snippet:SampleSnippetsBlobMigration_GenerateUserDelegationSas_Builder
                // Create a BlobClient
                BlobClient blobClient = new BlobClient(blobUri);
                // Create BlobSasBuilder and specify parameters
                BlobSasBuilder sasBuilder = new BlobSasBuilder(BlobSasPermissions.Read, DateTimeOffset.UtcNow.AddHours(1))
                {
                    // Since we are generating from the client, the client will have the container and blob name
                    // Specify any optional paremeters here
                    StartsOn = DateTimeOffset.UtcNow.AddHours(-1)
                };

                // Create full, self-authenticating URI to the resource from the BlobClient
                Uri sasUri = blobClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey);
                #endregion

                // Use newly made SAS URI to download the blob
                await new BlobClient(sasUri).DownloadToAsync(new MemoryStream());
            }
            finally
            {
                await container.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task BlobContentHash()
        {
            string data = "hello world";
            using Stream contentStream = new MemoryStream(Encoding.UTF8.GetBytes(data));

            // precalculate hash for sample
            byte[] precalculatedContentHash;
            using (var md5 = MD5.Create())
            {
                precalculatedContentHash = md5.ComputeHash(contentStream);
            }
            contentStream.Position = 0;

            // setup blob
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-file");
            var containerClient = new BlobContainerClient(ConnectionString, containerName);

            try
            {
                containerClient.Create();
                var blobClient = containerClient.GetBlobClient(blobName);

                #region Snippet:SampleSnippetsBlobMigration_BlobContentMD5
                // upload with blob content hash
                await blobClient.UploadAsync(
                    contentStream,
                    new BlobUploadOptions()
                    {
                        HttpHeaders = new BlobHttpHeaders()
                        {
                            ContentHash = precalculatedContentHash
                        }
                    });

                // download whole blob and validate against stored blob content hash
                Response<BlobDownloadStreamingResult> response = await blobClient.DownloadStreamingAsync();

                Stream downloadStream = response.Value.Content;
                byte[] blobContentMD5 = response.Value.Details.BlobContentHash ?? response.Value.Details.ContentHash;
                // validate stream against hash in your workflow
                #endregion

                byte[] downloadedBytes;
                using (var memStream = new MemoryStream())
                {
                    await downloadStream.CopyToAsync(memStream);
                    downloadedBytes = memStream.ToArray();
                }

                Assert.AreEqual(data, Encoding.UTF8.GetString(downloadedBytes));
                Assert.IsTrue(Enumerable.SequenceEqual(precalculatedContentHash, blobContentMD5));
            }
            finally
            {
                await containerClient.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task TransactionalMD5()
        {
            string data = "hello world";
            string blockId = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            List<string> blockList = new List<string> { blockId };
            using Stream blockContentStream = new MemoryStream(Encoding.UTF8.GetBytes(data));

            // precalculate hash for sample
            byte[] precalculatedBlockHash;
            using (var md5 = MD5.Create())
            {
                precalculatedBlockHash = md5.ComputeHash(blockContentStream);
            }
            blockContentStream.Position = 0;

            // setup blob
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-file");
            var containerClient = new BlobContainerClient(ConnectionString, containerName);

            try
            {
                containerClient.Create();
                var blockBlobClient = containerClient.GetBlockBlobClient(blobName);

                #region Snippet:SampleSnippetsBlobMigration_TransactionalMD5
                // upload a block with transactional hash calculated by user
                await blockBlobClient.StageBlockAsync(
                    blockId,
                    blockContentStream,
                    new BlockBlobStageBlockOptions
                    {
                        TransferValidation = new UploadTransferValidationOptions
                        {
                            ChecksumAlgorithm = StorageChecksumAlgorithm.MD5,
                            // a precalculated hash can be provided as follows,
                            // the sdk will calculate one for you otherwise
                            PrecalculatedChecksum = precalculatedBlockHash
                        }
                    });

                // upload more blocks as needed

                // commit block list
                await blockBlobClient.CommitBlockListAsync(blockList);

                // download any range of blob with transactional MD5 requested (maximum 4 MB for downloads)
                Response<BlobDownloadStreamingResult> response = await blockBlobClient.DownloadStreamingAsync(
                    new BlobDownloadOptions
                    {
                        // a range must be provided when requesting checksums; here we use transactional download max size
                        Range = new HttpRange(length: 4 * Constants.MB),
                        TransferValidation = new DownloadTransferValidationOptions
                        {
                            ChecksumAlgorithm = StorageChecksumAlgorithm.MD5,
                            // SDK will validate against checksum for you
                            // to disable this and check in your own workflow, uncomment the below
                            //Validate = false,
                        },
                    });

                Stream downloadStream = response.Value.Content;
                // uncomment below to retrieve checksum for validating in your own workflow
                //byte[] transactionalMD5 = response.Value.Details.ContentHash;
                #endregion

                byte[] downloadedBytes;
                using (var memStream = new MemoryStream())
                {
                    await downloadStream.CopyToAsync(memStream);
                    downloadedBytes = memStream.ToArray();
                }

                Assert.AreEqual(data, Encoding.UTF8.GetString(downloadedBytes));
            }
            finally
            {
                await containerClient.DeleteIfExistsAsync();
            }
        }

        [Test]
        public async Task RetryPolicy()
        {
            string connectionString = this.ConnectionString;

            string data = "hello world";

            //setup blob
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-file");
            var containerClient = new BlobContainerClient(ConnectionString, containerName);
            try
            {
                await containerClient.CreateIfNotExistsAsync();
                await containerClient.GetBlobClient(blobName).UploadAsync(BinaryData.FromString(data));

                #region Snippet:SampleSnippetsBlobMigration_RetryPolicy
                BlobClientOptions blobClientOptions = new BlobClientOptions();
                blobClientOptions.Retry.Mode = RetryMode.Exponential;
                blobClientOptions.Retry.Delay = TimeSpan.FromSeconds(10);
                blobClientOptions.Retry.MaxRetries = 6;
                BlobServiceClient service = new BlobServiceClient(connectionString, blobClientOptions);
                BlobClient blobClient = service.GetBlobContainerClient(containerName).GetBlobClient(blobName);
                Stream targetStream = new MemoryStream();
                await blobClient.DownloadToAsync(targetStream);
                #endregion
            }
            finally
            {
                await containerClient.DeleteIfExistsAsync();
            }

            Assert.Pass();
        }

        [Test]
        public async Task MaximumExecutionTime()
        {
            string connectionString = this.ConnectionString;

            string data = "hello world";

            //setup blob
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-file");
            var containerClient = new BlobContainerClient(ConnectionString, containerName);

            try
            {
                await containerClient.CreateIfNotExistsAsync();
                await containerClient.GetBlobClient(blobName).UploadAsync(BinaryData.FromString(data));

                #region Snippet:SampleSnippetsBlobMigration_MaximumExecutionTime
                BlobClient blobClient = containerClient.GetBlobClient(blobName);
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(30));
                Stream targetStream = new MemoryStream();
                await blobClient.DownloadToAsync(targetStream, cancellationTokenSource.Token);
                #endregion
            }
            finally
            {
                await containerClient.DeleteIfExistsAsync();
            }

            Assert.Pass();
        }
    }
}
