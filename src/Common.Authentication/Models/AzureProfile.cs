// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Hyak.Common;
using Microsoft.Azure.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Common.Authentication.Models
{
    /// <summary>
    /// Represents Azure profile structure with multiple environments, subscriptions, and accounts.
    /// </summary>
    public sealed class AzureProfile
    {
        /// <summary>
        /// Location of the profile file. 
        /// </summary>
        public string ProfilePath { get; private set; }

        /// <summary>
        /// Initializes a new instance of AzureProfile
        /// </summary>
        public AzureProfile()
        {
            Environments = new Dictionary<string, AzureEnvironment>(StringComparer.InvariantCultureIgnoreCase);
            Subscriptions = new Dictionary<Guid, AzureSubscription>();
            Accounts = new Dictionary<string, AzureAccount>(StringComparer.InvariantCultureIgnoreCase);

            LoadDefaultEnvironments();
        }

        /// <summary>
        /// Initializes a new instance of AzureProfile and loads its content from specified path.
        /// Any errors generated in the process are stored in ProfileLoadErrors collection.
        /// </summary>
        /// <param name="path">Location of profile file on disk.</param>
        public AzureProfile(string path)
        {
            ProfilePath = path;
            Environments = new Dictionary<string, AzureEnvironment>(StringComparer.InvariantCultureIgnoreCase);
            Subscriptions = new Dictionary<Guid, AzureSubscription>();
            Accounts = new Dictionary<string, AzureAccount>(StringComparer.InvariantCultureIgnoreCase);
            ProfileLoadErrors = new List<string>();

            if (!AzureSession.DataStore.DirectoryExists(AzureSession.ProfileDirectory))
            {
                AzureSession.DataStore.CreateDirectory(AzureSession.ProfileDirectory);
            }

            if (AzureSession.DataStore.FileExists(ProfilePath))
            {
                string contents = AzureSession.DataStore.ReadFileAsText(ProfilePath);

                IProfileSerializer serializer;

                if (HttpOperationException.IsXml(contents))
                {
                    serializer = new XmlProfileSerializer();
                    if (!serializer.Deserialize(contents, this))
                    {
                        ProfileLoadErrors.AddRange(serializer.DeserializeErrors);
                    }
                }
                else if (HttpOperationException.IsJson(contents))
                {
                    serializer = new JsonProfileSerializer();
                    if (!serializer.Deserialize(contents, this))
                    {
                        ProfileLoadErrors.AddRange(serializer.DeserializeErrors);
                    }
                }
            }

            LoadDefaultEnvironments();
        }

        private void LoadDefaultEnvironments()
        {
            // Adding predefined environments
            foreach (AzureEnvironment env in AzureEnvironment.PublicEnvironments.Values)
            {
                Environments[env.Name] = env;
            }
        }

        /// <summary>
        /// Writes profile to a ProfilePath
        /// </summary>
        public void Save()
        {
            Save(ProfilePath);
        }

        /// <summary>
        /// Writes profile to a specified path.
        /// </summary>
        /// <param name="path"></param>
        public void Save(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }

            // Removing predefined environments
            foreach (string env in AzureEnvironment.PublicEnvironments.Keys)
            {
                Environments.Remove(env);
            }

            JsonProfileSerializer jsonSerializer = new JsonProfileSerializer();

            string contents = jsonSerializer.Serialize(this);
            string diskContents = string.Empty;
            if (AzureSession.DataStore.FileExists(path))
            {
                diskContents = AzureSession.DataStore.ReadFileAsText(path);
            }

            if (diskContents != contents)
            {
                AzureSession.DataStore.WriteFile(path, contents);
            }
        }

        /// <summary>
        /// Gets errors from loading the profile.
        /// </summary>
        public List<string> ProfileLoadErrors { get; private set; }

        /// <summary>
        /// Gets Azure Environments
        /// </summary>
        public Dictionary<string, AzureEnvironment> Environments { get; set; }

        /// <summary>
        /// Gets Azure Subscriptions
        /// </summary>
        public Dictionary<Guid, AzureSubscription> Subscriptions { get; set; }

        /// <summary>
        /// Gets Azure Accounts
        /// </summary>
        public Dictionary<string, AzureAccount> Accounts { get; set; }

        /// <summary>
        /// Gets or sets default Azure Subscription
        /// </summary>
        public AzureSubscription DefaultSubscription
        {
            get
            {
                return Subscriptions.Values.FirstOrDefault(
                    s => s.Properties.ContainsKey(AzureSubscription.Property.Default));
            }

            set
            {
                if (value == null)
                {
                    foreach (var subscription in Subscriptions.Values)
                    {
                        subscription.SetProperty(AzureSubscription.Property.Default, null);
                    }
                }
                else if (Subscriptions.ContainsKey(value.Id))
                {
                    foreach (var subscription in Subscriptions.Values)
                    {
                        subscription.SetProperty(AzureSubscription.Property.Default, null);
                    }

                    Subscriptions[value.Id].Properties[AzureSubscription.Property.Default] = "True";
                    value.Properties[AzureSubscription.Property.Default] = "True";
                }
            }
        }
    }
}
