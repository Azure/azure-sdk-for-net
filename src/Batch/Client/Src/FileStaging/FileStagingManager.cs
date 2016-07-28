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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.Azure.Batch.FileStaging
{
    /*

    internal class FileStagingManager : IFileStagingManager
    {
        private readonly StorageCredentials _customerStorageCreds;
        private readonly string _containerName;

#region // Constructors

        private FileStagingManager()
        {
        }

        internal FileStagingManager(StorageCredentials storeCredentials, string containerName)
        {
            _customerStorageCreds = storeCredentials;
            _containerName = containerName;
        }

#endregion // Constructors

        /// <summary>
        /// Opens and returns a FileStagingManager for the given container.
        /// </summary>
        /// <param name="storeCredentials"></param>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public static IFileStagingManager OpenFileStagingManager(StorageCredentials storeCredentials, string containerName)
        {
            FileStagingManager newMgr = new FileStagingManager(storeCredentials, containerName);

            return newMgr;
        }

#region // IFileStagingManager

        public System.Threading.Tasks.Task<List<ICloudBlob>> ListBlobsAsync()
        {
            return null;
        }

        public List<ICloudBlob> ListBlobs()
        {
            using (System.Threading.Tasks.Task<List<ICloudBlob>> listBlobsTask = ListBlobsAsync())
            {
                return listBlobsTask.WaitAndUnaggregateException();
            }
        }

        public string CreateSASForBlob(ICloudBlob blob, TimeSpan ttl)
        {
            SharedAccessBlobPolicy policy = new SharedAccessBlobPolicy();

            policy.Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.List;
            policy.SharedAccessStartTime = DateTime.UtcNow;
            policy.SharedAccessExpiryTime = DateTime.UtcNow + ttl;

            string blob_sas = blob.GetSharedAccessSignature(policy);
            string blob_sasurl = blob.Uri.AbsoluteUri + blob_sas;

            return blob_sasurl;
        }

#endregion // IFileStagingManager


        /// <summary>
        /// Begins asynchronous call to stage the given files.
        /// </summary>
        /// <param name="filesToStage">Collection of all file staging objects.</param>
        /// <param name="allFileStagingArtifacts">Collection that all IFileStagingArtifacts.  This collection can be prepopulated.  If an IFileStagingArtifact for a given provider is missing, that provider will be asked to create one and it will be added to the collection.</param>
        /// <param name="namingFragment">A name fragment that will be inserted as part of any generated default names.</param>
        /// <returns></returns>
        public static async System.Threading.Tasks.Task StageFilesAsync(List<IFileStagingProvider> filesToStage, ConcurrentDictionary<Type, IFileStagingArtifact> allFileStagingArtifacts)
        {
            try
            {
                if (null == allFileStagingArtifacts)
                {
                    throw new ArgumentNullException("allFileStagingArtifacts");
                }

                System.Threading.Tasks.Task fileStagingTask = FileStagingLinkedSources.StageFilesAsync(filesToStage, allFileStagingArtifacts, string.Empty);

                await fileStagingTask.ConfigureAwait(continueOnCapturedContext: false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Blocking call to state the given files.
        /// </summary>
        /// <param name="filesToStage"></param>
        public static void StageFiles(List<IFileStagingProvider> filesToStage)
        {
            ConcurrentDictionary<Type, IFileStagingArtifact> artifacts = new ConcurrentDictionary<Type,IFileStagingArtifact>();

            using (System.Threading.Tasks.Task stagingTask = StageFilesAsync(filesToStage, artifacts))
            {
                stagingTask.WaitAndUnaggregateException();
            }
        }

        public static void StageFiles(IFileStagingProvider fileToStage)
        {
            ConcurrentDictionary<Type, IFileStagingArtifact> artifacts = new ConcurrentDictionary<Type, IFileStagingArtifact>();
            List<IFileStagingProvider> filesToStage = new List<IFileStagingProvider>(1);

            filesToStage.Add(fileToStage);

            using (System.Threading.Tasks.Task stagingTask = StageFilesAsync(filesToStage, artifacts))
            {
                stagingTask.WaitAndUnaggregateException();
            }
        }


#region // IDisposable

        public void Dispose()
        {
        }

#endregion // IDisposable
    }

    */
}
