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
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Security;
using System.Runtime.InteropServices;

namespace Microsoft.Azure.Batch.FileStaging
{
    internal sealed class FileStagingLinkedSources
    {
        internal static SecureString MakeSecure(string secret)
        {
            SecureString secStr = new SecureString();

            foreach (char ch in secret)
            {
                secStr.AppendChar(ch);
            }

            return secStr;
        }

        public static string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
                throw new ArgumentNullException("securePassword");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        private static string MakeDefaultNamePlusNamingFragment(string namingFragment)
        {
            StringBuilder newNameBuilder = new StringBuilder();
            
            newNameBuilder.Append(Batch.Constants.DefaultConveniencePrefix);

            if (!string.IsNullOrWhiteSpace(namingFragment))
            {
                newNameBuilder.Append(namingFragment);
                newNameBuilder.Append("-");
            }

            string newName = newNameBuilder.ToString();

            return newName;
        }

        // lock used to ensure only one name is created at a time.
        private static object _lockForContainerNaming = new object();

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
                List<IFileStagingProvider> foundFileStagingProvider;

                // if no bucket exists create one and register it
                if (!bucketizedProviders.TryGetValue(curType, out foundFileStagingProvider))
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

        internal static async System.Threading.Tasks.Task StageFilesAsync(List<IFileStagingProvider> filesToStage, ConcurrentDictionary<Type, IFileStagingArtifact> allFileStagingArtifacts)
        {
            using (System.Threading.Tasks.Task asyncTask = FileStagingLinkedSources.StageFilesAsync(filesToStage, allFileStagingArtifacts, string.Empty))
            {
                await asyncTask.ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        internal static async System.Threading.Tasks.Task StageFilesAsync(List<IFileStagingProvider> filesToStage, ConcurrentDictionary<Type, IFileStagingArtifact> allFileStagingArtifacts, string namingFragment)
        {
            try
            {
                if (null == allFileStagingArtifacts)
                {
                    throw new ArgumentNullException("allFileStagingArtifacts");
                }

                if (allFileStagingArtifacts.Count > 0)
                {
                    throw new ArgumentOutOfRangeException("allFileStagingArtifacts.Count");
                }

                // first we get the buckets.  One for each file staging provider that contains only the files for that provider.
                Dictionary<Type, List<IFileStagingProvider>> bucketByProviders = BucketizeFileStagingProviders(filesToStage);

                // missing artifacts will be instantiated and stored here temporarily
                Dictionary<Type, IFileStagingArtifact> pendingArtifactsToAdd = new Dictionary<Type, IFileStagingArtifact>();

                // detect any missing staging artifacts.  Each bucket must have a staging artifact.
                foreach (Type curProviderType in bucketByProviders.Keys)
                {
                    IFileStagingArtifact curProviderArtifact;

                    // if no artifact was passed in, instantiate one and have it added
                    if (!allFileStagingArtifacts.TryGetValue(curProviderType, out curProviderArtifact))
                    {
                        // we need to have the staging provider create an artifact instance
                        // so first we retrieve the list of files and ask one of them
                        List<IFileStagingProvider> filesForProviderType;

                        if (bucketByProviders.TryGetValue(curProviderType, out filesForProviderType))
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
                    IFileStagingArtifact curArtifact;
                    
                    if (pendingArtifactsToAdd.TryGetValue(curProvderType, out curArtifact))
                    {
                        allFileStagingArtifacts.TryAdd(curProvderType, curArtifact);
                    }
                }

                // now we have buckets of files for each provider and artifacts for each provider
                // start tasks for each provider

                // list of all running providers
                List<System.Threading.Tasks.Task> runningProviders = new List<System.Threading.Tasks.Task>();

                // start a task for each FileStagingProvider
                foreach (List<IFileStagingProvider> curProviderFilesToStage in bucketByProviders.Values)
                {
                    Debug.Assert(curProviderFilesToStage.Count > 0);

                    IFileStagingProvider anyInstance = curProviderFilesToStage[0];  // had to be at least one to get here.
                    System.Threading.Tasks.Task providerTask;  // this is the async task for this provider
                    IFileStagingArtifact stagingArtifact; // artifact for this provider

                    if (allFileStagingArtifacts.TryGetValue(anyInstance.GetType(), out stagingArtifact))  // register the staging artifact
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
                System.Threading.Tasks.Task[] runningArray = runningProviders.ToArray();

                System.Threading.Tasks.Task allRunningTasks = System.Threading.Tasks.Task.WhenAll(runningArray);

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
