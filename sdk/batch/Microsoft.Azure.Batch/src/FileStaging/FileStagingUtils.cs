// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.FileStaging
{
    internal static class FileStagingUtils
    {
        /// <summary>
        /// Creates buckets for the FileStagingProviders.
        /// </summary>
        /// <returns></returns>
        private static Dictionary<Type, List<IFileStagingProvider>> BucketizeFileStagingProviders(List<IFileStagingProvider> filesToStage)
        {
            Dictionary<Type, List<IFileStagingProvider>> bucketizedProviders = new Dictionary<Type, List<IFileStagingProvider>>();

            // walk all files and create buckets and populate them.
            foreach (IFileStagingProvider curFSP in filesToStage)
            {
                Type curType = curFSP.GetType();

                // if no bucket exists create one and register it
                if (!bucketizedProviders.TryGetValue(curType, out List<IFileStagingProvider> foundFileStagingProvider))
                {
                    foundFileStagingProvider = new List<IFileStagingProvider>();

                    // one more bucket
                    bucketizedProviders.Add(curType, foundFileStagingProvider);
                }

                // bucket has one more file
                foundFileStagingProvider.Add(curFSP);
            }

            return bucketizedProviders;
        }

        internal static async Task StageFilesAsync(List<IFileStagingProvider> filesToStage, ConcurrentDictionary<Type, IFileStagingArtifact> allFileStagingArtifacts)
        {
            Task asyncTask = StageFilesAsync(filesToStage, allFileStagingArtifacts, string.Empty);
            await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        internal static async Task StageFilesAsync(List<IFileStagingProvider> filesToStage, ConcurrentDictionary<Type, IFileStagingArtifact> allFileStagingArtifacts, string namingFragment)
        {
            try
            {
                if (null == allFileStagingArtifacts)
                {
                    throw new ArgumentNullException(nameof(allFileStagingArtifacts));
                }

                if (!allFileStagingArtifacts.IsEmpty)
                {
                    throw new ArgumentOutOfRangeException(nameof(allFileStagingArtifacts));
                }

                // first we get the buckets.  One for each file staging provider that contains only the files for that provider.
                Dictionary<Type, List<IFileStagingProvider>> bucketByProviders = BucketizeFileStagingProviders(filesToStage);

                // missing artifacts will be instantiated and stored here temporarily
                Dictionary<Type, IFileStagingArtifact> pendingArtifactsToAdd = new Dictionary<Type, IFileStagingArtifact>();

                // detect any missing staging artifacts.  Each bucket must have a staging artifact.
                foreach (Type curProviderType in bucketByProviders.Keys)
                {

                    // if no artifact was passed in, instantiate one and have it added
                    if (!allFileStagingArtifacts.TryGetValue(curProviderType, out IFileStagingArtifact curProviderArtifact))
                    {
                        // we need to have the staging provider create an artifact instance
                        // so first we retrieve the list of files and ask one of them
                        if (bucketByProviders.TryGetValue(curProviderType, out List<IFileStagingProvider> filesForProviderType))
                        {
                            Debug.Assert(filesForProviderType.Count > 0); // to be in a bucket means there must be at least one.

                            IFileStagingProvider curProviderAsInterface = filesForProviderType[0];

                            IFileStagingArtifact newArtifactFreshFromProvider = curProviderAsInterface.CreateStagingArtifact();

                            // give the file stager the naming fragment if it does not already have one by default
                            if (string.IsNullOrEmpty(newArtifactFreshFromProvider.NamingFragment) && !string.IsNullOrEmpty(namingFragment))
                            {
                                newArtifactFreshFromProvider.NamingFragment = namingFragment;
                            }

                            pendingArtifactsToAdd.Add(curProviderType, newArtifactFreshFromProvider);
                        }
                    }
                }

                // add missing artifacts to collection
                foreach (Type curProvderType in pendingArtifactsToAdd.Keys)
                {

                    if (pendingArtifactsToAdd.TryGetValue(curProvderType, out IFileStagingArtifact curArtifact))
                    {
                        allFileStagingArtifacts.TryAdd(curProvderType, curArtifact);
                    }
                }

                // now we have buckets of files for each provider and artifacts for each provider
                // start tasks for each provider

                // list of all running providers
                List<Task> runningProviders = new List<Task>();

                // start a task for each FileStagingProvider
                foreach (List<IFileStagingProvider> curProviderFilesToStage in bucketByProviders.Values)
                {
                    Debug.Assert(curProviderFilesToStage.Count > 0);

                    IFileStagingProvider anyInstance = curProviderFilesToStage[0];  // had to be at least one to get here.
                    Task providerTask;  // this is the async task for this provider

                    if (allFileStagingArtifacts.TryGetValue(anyInstance.GetType(), out IFileStagingArtifact stagingArtifact))  // register the staging artifact
                    {
                        providerTask = anyInstance.StageFilesAsync(curProviderFilesToStage, stagingArtifact);

                        runningProviders.Add(providerTask);
                    }
                    else
                    {
                        Debug.Assert(true, "The staging artifacts collection is somehow missing an artifact for " + anyInstance.GetType().ToString());
                    }
                }

                //
                // the individual tasks were created above
                // now a-wait for them all to finish
                //
                Task[] runningArray = runningProviders.ToArray();

                Task allRunningTasks = Task.WhenAll(runningArray);

                // actual a-wait for all the providers
                await allRunningTasks.ConfigureAwait(continueOnCapturedContext: false);
            }
            catch (Exception ex)
            {
                if (null != ex)
                {
                    throw; // TODO:  trace here?
                }
            }
        }
    }
}
