// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Security;
using System.Runtime.InteropServices;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

using BatchFS=Microsoft.Azure.Batch.FileStaging;

namespace Microsoft.Azure.Batch.FileStaging
{
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
            this.LocalFileToStage = localFileToStage;
            this.StagingStorageAccount = storageCredentials;

            if (string.IsNullOrWhiteSpace(this.LocalFileToStage))
            {
                throw new ArgumentOutOfRangeException("localFileToStage");
            }

            // map null to base name of local file
            if (string.IsNullOrWhiteSpace(nodeFileName))
            {
                this.NodeFileName = Path.GetFileName(this.LocalFileToStage);
            }
            else
            {
                this.NodeFileName = nodeFileName;
            }
        }

#endregion // constructors

#region // IFileStagingProvider

        /// <summary>
        /// See <see cref="IFileStagingProvider.StageFilesAsync"/>.
        /// </summary>
        /// <param name="filesToStage">The instances of IFileStagingProvider to stage.</param>
        /// <param name="fileStagingArtifact">IFileStagingProvider specific staging artifacts including error/progress.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public async System.Threading.Tasks.Task StageFilesAsync(List<IFileStagingProvider> filesToStage, IFileStagingArtifact fileStagingArtifact)
        {
            System.Threading.Tasks.Task taskForStaticStaging = FileToStage.StageFilesInternalAsync(filesToStage, fileStagingArtifact);

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
            if (!File.Exists(this.LocalFileToStage))
            {
                throw new FileNotFoundException(string.Format(BatchFS.ErrorMessages.FileStagingLocalFileNotFound, this.LocalFileToStage));
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
        /// create a container if doesn't exist, setting permission with policy, and return assosciated SAS signature
        /// </summary>
        /// <param name="account">storage account</param>
        /// <param name="key">storage key</param>
        /// <param name="container">container to be created</param>
        /// <param name="policy">name for the policy</param>
        /// <param name="start">start time of the policy</param>
        /// <param name="end">expire time of the policy</param>
        /// <param name="permissions">permission on the name</param>
        /// <param name="blobUri">blob URI</param>
        /// <returns>the SAS for the container, in full URI format.</returns>
        private static string CreateContainerWithPolicySASIfNotExist(string account, string key, Uri blobUri, string container, string policy, DateTime start, DateTime end, SharedAccessBlobPermissions permissions)
        {
            // 1. form the credentail and initial client
            CloudStorageAccount storageaccount = new CloudStorageAccount(new WindowsAzure.Storage.Auth.StorageCredentials(account, key), 
                                                                         blobEndpoint: blobUri,
                                                                         queueEndpoint: null,
                                                                         tableEndpoint: null,
                                                                         fileEndpoint: null);

            CloudBlobClient client = storageaccount.CreateCloudBlobClient();

            // 2. create container if it doesn't exist
            CloudBlobContainer storagecontainer = client.GetContainerReference(container);
            storagecontainer.CreateIfNotExists();

            // 3. validate policy, create/overwrite if doesn't match
            bool policyFound = false;

            SharedAccessBlobPolicy accesspolicy = new SharedAccessBlobPolicy()
            {
                SharedAccessExpiryTime = end,
                SharedAccessStartTime = start,
                Permissions = permissions
            };

            BlobContainerPermissions blobPermissions = storagecontainer.GetPermissions();

            if (blobPermissions.SharedAccessPolicies.ContainsKey(policy))
            {
                SharedAccessBlobPolicy containerpolicy = blobPermissions.SharedAccessPolicies[policy];
                if (!(permissions == (containerpolicy.Permissions & permissions) && start <= containerpolicy.SharedAccessStartTime && end >= containerpolicy.SharedAccessExpiryTime))
                {
                    blobPermissions.SharedAccessPolicies[policy] = accesspolicy;
                }
                else
                {
                    policyFound = true;
                }
            }
            else
            {
                blobPermissions.SharedAccessPolicies.Add(policy, accesspolicy);
            }

            if (!policyFound)
            {
                storagecontainer.SetPermissions(blobPermissions);
            }

            // 4. genereate SAS and return
            string container_sas = storagecontainer.GetSharedAccessSignature(new SharedAccessBlobPolicy(), policy);
            string container_url = storagecontainer.Uri.AbsoluteUri + container_sas;

            return container_url;
        }

        private static void CreateDefaultBlobContainerAndSASIfNeededReturn(List<IFileStagingProvider> filesToStage, SequentialFileStagingArtifact seqArtifact)
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
                    string policyName = Batch.Constants.DefaultConveniencePrefix + Constants.DefaultContainerPolicyFragment;
                    DateTime startTime = DateTime.UtcNow;
                    DateTime expiredAtTime = startTime + new TimeSpan(24 /* hrs*/, 0, 0);

                    seqArtifact.DefaultContainerSAS = CreateContainerWithPolicySASIfNotExist(
                                                            creds.StorageAccount, 
                                                            creds.StorageAccountKey, 
                                                            creds.BlobUri,
                                                            seqArtifact.BlobContainerCreated, 
                                                            policyName, 
                                                            startTime, 
                                                            expiredAtTime, 
                                                            SharedAccessBlobPermissions.Read);

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
            if ((null != filesToStage) && (filesToStage.Count > 0))
            {
                foreach(IFileStagingProvider curProvider in filesToStage)
                {
                    FileToStage thisIsReal = curProvider as FileToStage;

                    if (null != thisIsReal)
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
        private static async System.Threading.Tasks.Task StageFilesInternalAsync(List<IFileStagingProvider> filesToStage, IFileStagingArtifact fileStagingArtifact)
        {
            if (null == filesToStage)
            {
                throw new ArgumentNullException("filesToStage");
            }

            if (null == fileStagingArtifact)
            {
                throw new ArgumentNullException("filesStagingArtifact");
            }

            SequentialFileStagingArtifact seqArtifact = fileStagingArtifact as SequentialFileStagingArtifact;

            if (null == seqArtifact)
            {
                throw new ArgumentOutOfRangeException(BatchFS.ErrorMessages.FileStagingIncorrectArtifact);
            }

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
            System.Threading.Tasks.Task createContainerTask = System.Threading.Tasks.Task.Run(() => { CreateDefaultBlobContainerAndSASIfNeededReturn(filesToStage, seqArtifact); });

            // wait for container to be created
            await createContainerTask.ConfigureAwait(continueOnCapturedContext: false);

            // begin staging the files
            System.Threading.Tasks.Task stageTask = StageFilesAsync(filesToStage, seqArtifact); 

            // wait for files to be staged
            await stageTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Stages all files in the queue 
        /// </summary>
        private async static System.Threading.Tasks.Task StageFilesAsync(List<IFileStagingProvider> filesToStage, SequentialFileStagingArtifact seqArtifacts)
        {
            foreach (IFileStagingProvider currentFile in filesToStage)
            {
                // for "retry" and/or "double calls" we ignore files that have already been staged
                if (null == currentFile.StagedFiles)
                {
                    FileToStage fts = currentFile as FileToStage;

                    if (null != fts)
                    {
                        System.Threading.Tasks.Task stageTask = StageOneFileAsync(fts, seqArtifacts);

                        await stageTask.ConfigureAwait(continueOnCapturedContext: false);
                    }
                }
            }
        }

        /// <summary>
        /// Stage a single file.
        /// </summary>
        private async static System.Threading.Tasks.Task StageOneFileAsync(FileToStage stageThisFile, SequentialFileStagingArtifact seqArtifacts)
        {
            StagingStorageAccount storecreds = stageThisFile.StagingStorageAccount;
            string containerName = seqArtifacts.BlobContainerCreated;

            // TODO: this flattens all files to the top of the compute node/task relative file directory. solve the hiearchy problem (virt dirs?)
            string blobName = Path.GetFileName(stageThisFile.LocalFileToStage);

            // Create the storage account with the connection string.
            CloudStorageAccount storageAccount = new CloudStorageAccount(
                                                        new WindowsAzure.Storage.Auth.StorageCredentials(storecreds.StorageAccount, storecreds.StorageAccountKey), 
                                                        blobEndpoint: storecreds.BlobUri, 
                                                        queueEndpoint: null,
                                                        tableEndpoint: null,
                                                        fileEndpoint: null);

            CloudBlobClient client = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference(containerName);
            ICloudBlob blob = container.GetBlockBlobReference(blobName);  
            bool doesBlobExist;

            try
            {
                // fetch attributes so we can compare file lengths
                System.Threading.Tasks.Task fetchTask = blob.FetchAttributesAsync();

                await fetchTask.ConfigureAwait(continueOnCapturedContext: false);

                doesBlobExist = true;
            }
            catch (StorageException scex)
            {
                // check to see if blob does not exist
                if ((int)System.Net.HttpStatusCode.NotFound == scex.RequestInformation.HttpStatusCode)
                {
                    doesBlobExist = false;
                }
                else
                {
                    throw;  // unknown exception, throw to caller
                }
            }

            bool mustUploadBlob = true;  // we do not re-upload blobs if they have already been uploaded

            if (doesBlobExist) // if the blob exists, compare
            {
                FileInfo fi = new FileInfo(stageThisFile.LocalFileToStage);

                // since we don't have a hash of the contents... we check length
                if (blob.Properties.Length == fi.Length)
                {
                    mustUploadBlob = false;
                }
            }

            if (mustUploadBlob)
            {
                // upload the file
                System.Threading.Tasks.Task uploadTask = blob.UploadFromFileAsync(stageThisFile.LocalFileToStage, FileMode.Open);

                await uploadTask.ConfigureAwait(continueOnCapturedContext: false);
            }

            // get the SAS for the blob
            string blobSAS = ConstructBlobSource(seqArtifacts.DefaultContainerSAS, blobName);
            string nodeFileName = stageThisFile.NodeFileName;

            // create a new ResourceFile and populate it.  This file is now staged!
            stageThisFile.StagedFiles = new ResourceFile[] { new ResourceFile(blobSAS, nodeFileName) };
        }

#endregion internal/private
    }
}
