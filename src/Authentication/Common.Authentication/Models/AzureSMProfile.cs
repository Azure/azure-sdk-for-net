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
using Microsoft.Azure.Common.Authentication.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Common.Authentication.Models
{
    /// <summary>
    /// Represents Azure profile structure with multiple environments, subscriptions, and accounts.
    /// </summary>
    [Serializable]
    public sealed class AzureSMProfile : IAzureProfile
    {
        /// <summary>
        /// Gets Azure Accounts
        /// </summary>
        public Dictionary<string, AzureAccount> Accounts { get; set; }

        /// <summary>
        /// Gets Azure Subscriptions
        /// </summary>
        public Dictionary<Guid, AzureSubscription> Subscriptions { get; set; }

        /// <summary>
        /// Gets or sets current Azure Subscription
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

        /// <summary>
        /// Gets Azure Environments
        /// </summary>
        public Dictionary<string, AzureEnvironment> Environments { get; set; }

        /// <summary>
        /// Gets the default azure context object.
        /// </summary>
        [JsonIgnore]
        public AzureContext Context 
        { 
            get
            {
                var context = new AzureContext(null, null, null, null);

                if (DefaultSubscription != null)
                {
                    AzureAccount account = null;
                    AzureEnvironment environment = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
                    if (DefaultSubscription.Account != null &&
                        Accounts.ContainsKey(DefaultSubscription.Account))
                    {
                        account = Accounts[DefaultSubscription.Account];
                    }
                    else
                    {
                        TracingAdapter.Information(Resources.NoAccountInContext, DefaultSubscription.Account, DefaultSubscription.Id);
                    }

                    if (DefaultSubscription.Environment != null &&
                        Environments.ContainsKey(DefaultSubscription.Environment))
                    {
                        environment = Environments[DefaultSubscription.Environment];
                    }
                    else
                    {
                         TracingAdapter.Information(Resources.NoEnvironmentInContext, DefaultSubscription.Environment, DefaultSubscription.Id);                       
                    }

                    context = new AzureContext(DefaultSubscription, account, environment);
                }

                return context;
            } 
        }

        /// <summary>
        /// Gets errors from loading the profile.
        /// </summary>
        public List<string> ProfileLoadErrors { get; private set; }

        /// <summary>
        /// Location of the profile file. 
        /// </summary>
        public string ProfilePath { get; private set; }

        /// <summary>
        /// Initializes a new instance of AzureSMProfile
        /// </summary>
        public AzureSMProfile()
        {
            Environments = new Dictionary<string, AzureEnvironment>(StringComparer.InvariantCultureIgnoreCase);
            Subscriptions = new Dictionary<Guid, AzureSubscription>();
            Accounts = new Dictionary<string, AzureAccount>(StringComparer.InvariantCultureIgnoreCase);

            // Adding predefined environments
            foreach (AzureEnvironment env in AzureEnvironment.PublicEnvironments.Values)
            {
                Environments[env.Name] = env;
            }
        }

        /// <summary>
        /// Initializes a new instance of AzureSMProfile and loads its content from specified path.
        /// Any errors generated in the process are stored in ProfileLoadErrors collection.
        /// </summary>
        /// <param name="path">Location of profile file on disk.</param>
        public AzureSMProfile(string path) : this()
        {
            ProfilePath = path;
            ProfileLoadErrors = new List<string>();

            if (!AzureSession.DataStore.DirectoryExists(AzureSession.ProfileDirectory))
            {
                AzureSession.DataStore.CreateDirectory(AzureSession.ProfileDirectory);
            }

            if (AzureSession.DataStore.FileExists(ProfilePath))
            {
                string contents = AzureSession.DataStore.ReadFileAsText(ProfilePath);

                IProfileSerializer serializer;

                if (CloudException.IsXml(contents))
                {
                    serializer = new XmlProfileSerializer();
                    if (!serializer.Deserialize(contents, this))
                    {
                        ProfileLoadErrors.AddRange(serializer.DeserializeErrors);
                    }
                }
                else if (CloudException.IsJson(contents))
                {
                    serializer = new JsonProfileSerializer();
                    if (!serializer.Deserialize(contents, this))
                    {
                        ProfileLoadErrors.AddRange(serializer.DeserializeErrors);
                    }
                }
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
        /// <param name="path">File path on disk to save profile to</param>
        public void Save(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }
            
            // Removing predefined environments
            foreach (string env in AzureEnvironment.PublicEnvironments.Keys)
            {
                Environments.Remove(env);
            }

            try
            {
                string contents = ToString();
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
            finally
            {
                // Adding back predefined environments
                foreach (AzureEnvironment env in AzureEnvironment.PublicEnvironments.Values)
                {
                    Environments[env.Name] = env;
                }
            }
        }

        public override string ToString()
        {
            JsonProfileSerializer jsonSerializer = new JsonProfileSerializer();
            return jsonSerializer.Serialize(this);
        }
    }
}
