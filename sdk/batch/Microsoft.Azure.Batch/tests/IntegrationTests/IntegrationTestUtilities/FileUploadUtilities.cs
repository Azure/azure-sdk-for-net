// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.FileStaging;
using Microsoft.Azure.Batch.Integration.Tests.IntegrationTestUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BatchClientIntegrationTests.IntegrationTestUtilities
{
    // File staging classes - these implementations are to allow tests to take advantage of
    // file staging rather than having to manage resource files in the tests.  Some error checks
    // are removed compared to real implementations.  The production implementations are in
    // a separate DLL/NuGet package and are tested via that DLL's tests.

    /// <summary>
    /// Holds storage account information.
    /// </summary>
    public class StagingStorageAccount
    {
        /// <summary>
        /// Specifies the storage account to be used.
        /// </summary>
        public string StorageAccount
        {
            get;
            internal set;
        }

        /// <summary>
        /// Specifies the storage account key to be used.
        /// </summary>
        public string StorageAccountKey
        {
            get;
            internal set;
        }

        /// <summary>
        /// The serviced endpoint for blob storage.
        /// </summary>
        public string BlobEndpoint
        {
            get;
            internal set;
        }

        // Constructed here to give immediate validation/failure experience.
        internal Uri BlobUri
        {
            get;
            set;
        }

        private StagingStorageAccount()
        {
        }

        /// <summary>
        /// Initializes a new instance of the StagingStorageAccount class using the specified credentials and service endpoint.
        /// </summary>
        /// <param name="storageAccount">A string specifying the storage account to be used.</param>
        /// <param name="storageAccountKey">A string specifying the storage account key to be used.</param>
        /// <param name="blobEndpoint">A string specifying the primary Blob service endpoint.</param>
        public StagingStorageAccount(string storageAccount, string storageAccountKey, string blobEndpoint)
        {
            StorageAccount = storageAccount;
            StorageAccountKey = storageAccountKey;

            if (string.IsNullOrWhiteSpace(StorageAccount))
            {
                throw new ArgumentOutOfRangeException("storageAccount");
            }

            if (string.IsNullOrWhiteSpace(StorageAccountKey))
            {
                throw new ArgumentOutOfRangeException("storageAccountKey");
            }

            if (string.IsNullOrWhiteSpace(blobEndpoint))
            {
                throw new ArgumentOutOfRangeException("blobEndpoint");
            }

            // Constructed here to give immediate validation/failure experience.
            BlobUri = new Uri(blobEndpoint);
        }
    }

    /// <summary>
    /// Provides for file staging of a local file to blob storage.
    /// </summary>
    public sealed class FileToStage : IFileStagingProvider
    {
        /// <summary>
        /// The name of the local file to stage to blob storage
        /// </summary>
        public string LocalFileToStage
        {
            get;
            internal set;
        }

        /// <summary>
        /// The target filename, on the compute node, to which the blob contents will be downloaded.
        /// </summary>
        public string NodeFileName
        {
            get;
            internal set;
        }

        /// <summary>
        /// The instances of ResourcesFile for the staged local file.
        /// For this implementation, successful file staging of this object will
        /// result in a collection with only one entry.
        /// </summary>
        public IEnumerable<ResourceFile> StagedFiles
        {
            get;
            internal set;
        }

        /// <summary>
        /// The exception, if any, caught while attempting to stage this file.
        /// </summary>
        public Exception Exception
        {
            get;
            internal set;
        }

        #region constructors

        private FileToStage()
        {
        }

        /// <summary>
        /// Specifies that a local file should be staged to blob storage.
        /// The specified account will be charged for storage costs.
        /// </summary>
        /// <param name="localFileToStage">The name of the local file.</param>
        /// <param name="storageCredentials">The storage credentials to be used when creating the default container.</param>
        /// <param name="nodeFileName">Optional name to be given to the file on the compute node.  If this parameter is null or missing
        /// the name on the compute node will be set to the value of localFileToStage stripped of all path information.</param>
        public FileToStage(string localFileToStage, StagingStorageAccount storageCredentials, string nodeFileName = null)
        {
            LocalFileToStage = localFileToStage;
            StagingStorageAccount = storageCredentials;

            if (string.IsNullOrWhiteSpace(LocalFileToStage))
            {
                throw new ArgumentOutOfRangeException("localFileToStage");
            }

            // map null to base name of local file
            if (string.IsNullOrWhiteSpace(nodeFileName))
            {
                NodeFileName = Path.GetFileName(LocalFileToStage);
            }
            else
            {
                NodeFileName = nodeFileName;
            }
        }

        #endregion // constructors

        #region // IFileStagingProvider

        /// <summary>
        /// See <see cref="IFileStagingProvider.StageFilesAsync"/>.
        /// </summary>
        /// <param name="filesToStage">The instances of IFileStagingProvider to stage.</param>
        /// <param name="fileStagingArtifact">IFileStagingProvider specific staging artifacts including error/progress.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        public async Task StageFilesAsync(List<IFileStagingProvider> filesToStage, IFileStagingArtifact fileStagingArtifact)
        {
            Task taskForStaticStaging = FileToStage.StageFilesInternalAsync(filesToStage, fileStagingArtifact);

            await taskForStaticStaging.ConfigureAwait(continueOnCapturedContext: false);

            return;
        }

        /// <summary>
        /// See <see cref="IFileStagingProvider.CreateStagingArtifact"/>.
        /// </summary>
        /// <returns>An instance of IFileStagingArtifact with default values.</returns>
        public IFileStagingArtifact CreateStagingArtifact()
        {
            return new SequentialFileStagingArtifact() as IFileStagingArtifact;
        }

        /// <summary>
        /// See <see cref="IFileStagingProvider.Validate"/>.
        /// </summary>
        public void Validate()
        {
            if (!File.Exists(LocalFileToStage))
            {
                throw new FileNotFoundException($"The following local file cannot be staged because it cannot be found: {LocalFileToStage}");
            }
        }

        #endregion // IFileStagingProvier

        #region internal/private

        // the staging code needs to get the secrets
        internal StagingStorageAccount StagingStorageAccount { get; set; }

        /// <summary>
        /// combine container and blob into an URL.
        /// </summary>
        /// <param name="container">container url</param>
        /// <param name="blob">blob url</param>
        /// <returns>full url</returns>
        private static string ConstructBlobSource(string container, string blob)
        {
            int index = container.IndexOf("?");

            if (index != -1)
            {
                //SAS
                string containerAbsoluteUrl = container.Substring(0, index);
                return containerAbsoluteUrl + "/" + blob + container.Substring(index);
            }
            else
            {
                return container + "/" + blob;
            }
        }

        /// <summary>
        /// Create a container if doesn't exist, setting permission with policy, and return assosciated SAS signature
        /// </summary>
        /// <param name="account">Storage account</param>
        /// <param name="Key">Storage account key</param>
        /// <param name="blobUri">Blob endpoint URI</param>
        /// <param name="containerName">Name of the container to be created</param>
        /// <param name="policy">Name for the policy</param>
        /// <param name="start">Start time of the policy</param>
        /// <param name="end">Expire time of the policy</param>
        /// <param name="permissions">Blob access permissions</param>
        /// <returns>the SAS for the container, in full URI format.</returns>.
        private static async Task<string> CreateContainerWithPolicySASIfNotExistAsync(string account, string key, Uri blobUri, string containerName, string policy, DateTime start, DateTime end, string permissions)
        {
            // 1. form the credentail and initial client
            StagingStorageAccount stagingCredentials = new StagingStorageAccount(account, key, blobUri.ToString());
            StorageSharedKeyCredential shardKeyCredentials = new StorageSharedKeyCredential(account, key);
            BlobContainerClient containerClient = BlobUtilities.GetBlobContainerClient(containerName, stagingCredentials);
            // 2. create container if it doesn't exist
            containerClient.CreateIfNotExists();

            // 3. validate policy, create/overwrite if doesn't match
            BlobSignedIdentifier identifier = new BlobSignedIdentifier
            {
                Id = policy,
                AccessPolicy = new BlobAccessPolicy
                {
                    Permissions = permissions,
                    StartsOn = start,
                    ExpiresOn = end,

                },
            };

            var accessPolicy = (await containerClient.GetAccessPolicyAsync()).Value;
            bool policyFound = accessPolicy.SignedIdentifiers.Any(i => i == identifier);

            if (policyFound == false)
            {
                await containerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer, permissions: new List<BlobSignedIdentifier> { identifier });
            }

            BlobSasBuilder sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                StartsOn = start,
                ExpiresOn = end,
            };

            sasBuilder.SetPermissions(permissions);
            BlobUriBuilder builder = new BlobUriBuilder(containerClient.Uri) { Sas = sasBuilder.ToSasQueryParameters(shardKeyCredentials) };
            string fullSas = builder.ToString();
            return fullSas;
        }

        private static async Task CreateDefaultBlobContainerAndSASIfNeededReturnAsync(List<IFileStagingProvider> filesToStage, SequentialFileStagingArtifact seqArtifact)
        {
            if ((null != filesToStage) && (filesToStage.Count > 0))
            {
                // construct the name of the new blob container.
                seqArtifact.BlobContainerCreated = FileStagingLinkedSources.ConstructDefaultName(seqArtifact.NamingFragment).ToLowerInvariant();

                // get any instance for the storage credentials
                FileToStage anyRealInstance = FindAtLeastOne(filesToStage);

                if (null != anyRealInstance)
                {
                    StagingStorageAccount creds = anyRealInstance.StagingStorageAccount;
                    string policyName = Microsoft.Azure.Batch.Constants.DefaultConveniencePrefix + Microsoft.Azure.Batch.FileStaging.Constants.DefaultContainerPolicyFragment;
                    DateTime startTime = DateTime.UtcNow;
                    DateTime expiredAtTime = startTime + new TimeSpan(24 /* hrs*/, 0, 0);

                    seqArtifact.DefaultContainerSAS = await CreateContainerWithPolicySASIfNotExistAsync(
                                                            creds.StorageAccount,
                                                            creds.StorageAccountKey,
                                                            creds.BlobUri,
                                                            seqArtifact.BlobContainerCreated,
                                                            policyName,
                                                            startTime,
                                                            expiredAtTime,
                                                            "r");

                    return;  // done
                }
            }
        }

        /// <summary>
        /// Since this is the SequentialFileStagingProvider, all files are supposed to be of this type.
        /// Find any one and return the implementation instance.
        /// </summary>
        /// <param name="filesToStage"></param>
        /// <returns>Null means there was not even one.</returns>
        private static FileToStage FindAtLeastOne(List<IFileStagingProvider> filesToStage)
        {
            if (null != filesToStage && filesToStage.Count > 0)
            {
                foreach (IFileStagingProvider curProvider in filesToStage)
                {
                    if (curProvider is FileToStage thisIsReal)
                    {
                        return thisIsReal;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Starts an asynchronous call to stage the given files.
        /// </summary>
        private static async Task StageFilesInternalAsync(List<IFileStagingProvider> filesToStage, IFileStagingArtifact fileStagingArtifact)
        {
            if (null == filesToStage)
            {
                throw new ArgumentNullException("filesToStage");
            }

            if (null == fileStagingArtifact)
            {
                throw new ArgumentNullException("filesStagingArtifact");
            }

            SequentialFileStagingArtifact seqArtifact = (SequentialFileStagingArtifact)fileStagingArtifact;

            // is there any work to do?
            if (null == FindAtLeastOne(filesToStage))
            {
                return;  // now work to do.  none of the files belong to this provider
            }

            // is there any work to do
            if ((null == filesToStage) || (filesToStage.Count <= 0))
            {
                return;  // we are done
            }

            // create a Run task to create the blob containers if needed
            Task createContainerTask = Task.Run(async () => { await CreateDefaultBlobContainerAndSASIfNeededReturnAsync(filesToStage, seqArtifact); });

            // wait for container to be created
            await createContainerTask.ConfigureAwait(continueOnCapturedContext: false);

            // begin staging the files
            Task stageTask = StageFilesAsync(filesToStage, seqArtifact);

            // wait for files to be staged
            await stageTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Stages all files in the queue
        /// </summary>
        private async static Task StageFilesAsync(List<IFileStagingProvider> filesToStage, SequentialFileStagingArtifact seqArtifacts)
        {
            foreach (IFileStagingProvider currentFile in filesToStage)
            {
                // for "retry" and/or "double calls" we ignore files that have already been staged
                if (null == currentFile.StagedFiles)
                {
                    if (currentFile is FileToStage fts)
                    {
                        Task stageTask = StageOneFileAsync(fts, seqArtifacts);

                        await stageTask.ConfigureAwait(continueOnCapturedContext: false);
                    }
                }
            }
        }

        /// <summary>
        /// Stage a single file.
        /// </summary>
        private async static Task StageOneFileAsync(FileToStage stageThisFile, SequentialFileStagingArtifact seqArtifacts)
        {
            StagingStorageAccount storecreds = stageThisFile.StagingStorageAccount;
            string containerName = seqArtifacts.BlobContainerCreated;

            // TODO: this flattens all files to the top of the compute node/task relative file directory. solve the hiearchy problem (virt dirs?)
            string blobName = Path.GetFileName(stageThisFile.LocalFileToStage);

            BlobContainerClient blobContainerClient = BlobUtilities.GetBlobContainerClient(containerName, storecreds);
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);

            bool doesBlobExist = await blobClient.ExistsAsync().ConfigureAwait(false);
            bool mustUploadBlob = true;  // we do not re-upload blobs if they have already been uploaded

            if (doesBlobExist) // if the blob exists, compare
            {
                FileInfo fi = new FileInfo(stageThisFile.LocalFileToStage);

                var properties = await blobClient.GetPropertiesAsync().ConfigureAwait(false);
                var length = properties.Value.ContentLength;
                // since we don't have a hash of the contents... we check length
                if (length == fi.Length)
                {
                    mustUploadBlob = false;
                }
            }

            if (mustUploadBlob)
            {
                await blobClient.UploadAsync(stageThisFile.LocalFileToStage).ConfigureAwait(false);
            }

            // get the SAS for the blob
            string blobSAS = ConstructBlobSource(seqArtifacts.DefaultContainerSAS, blobName);
            string nodeFileName = stageThisFile.NodeFileName;

            // create a new ResourceFile and populate it.  This file is now staged!
            stageThisFile.StagedFiles = new ResourceFile[] { ResourceFile.FromUrl(blobSAS, nodeFileName) };
        }

        #endregion internal/private
    }

    /// <summary>
    /// The file staging artifact payload for this file staging provider
    /// </summary>
    public sealed class SequentialFileStagingArtifact : IFileStagingArtifact
    {
        /// <summary>
        /// The name of any blob container created.
        ///
        /// A blob container is created if there is at least one file
        /// to be uploaded that does not have an explicit container specified.
        /// </summary>
        public string BlobContainerCreated { get; internal set; }

        /// <summary>
        /// Optionally set by caller.  Optionally used by implementation. A name fragment that can be used when constructing default names.
        ///
        /// Can only be set once.
        /// </summary>
        public string NamingFragment { get; set; }

        /// <summary>
        /// Holds the SAS for the default container after it is created.
        /// </summary>
        internal string DefaultContainerSAS { get; set; }
    }
    internal sealed class FileStagingLinkedSources
    {

        private static string MakeDefaultNamePlusNamingFragment(string namingFragment)
        {
            StringBuilder newNameBuilder = new StringBuilder();

            newNameBuilder.Append(Microsoft.Azure.Batch.Constants.DefaultConveniencePrefix);

            if (!string.IsNullOrWhiteSpace(namingFragment))
            {
                newNameBuilder.Append(namingFragment);
                newNameBuilder.Append('-');
            }

            string newName = newNameBuilder.ToString();

            return newName;
        }

        // lock used to ensure only one name is created at a time.
        private static readonly object _lockForContainerNaming = new object();

        internal static string ConstructDefaultName(string namingFragment)
        {
            lock (_lockForContainerNaming)
            {
                Thread.Sleep(30);  // make sure no two names are identical

                string uniqueLetsHope = DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss-fff");
                string defContainerName = MakeDefaultNamePlusNamingFragment(namingFragment) + uniqueLetsHope;

                return defContainerName;
            }
        }
    }
}
