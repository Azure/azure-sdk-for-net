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

using Microsoft.Azure.Common.Extensions.Interfaces;
using Microsoft.WindowsAzure.Common.Internals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Microsoft.Azure.Common.Extensions.Models
{
    public sealed class AzureProfile
    {
        private IDataStore store;
        private string profilePath;
        private string tokenCacheFile = Path.Combine(AzureSession.ProfileDirectory, AzureSession.TokenCacheFile);

        public AzureProfile()
        {
            Environments = new Dictionary<string, AzureEnvironment>(StringComparer.InvariantCultureIgnoreCase);
            Subscriptions = new Dictionary<Guid, AzureSubscription>();
            Accounts = new Dictionary<string, AzureAccount>(StringComparer.InvariantCultureIgnoreCase);
        }

        public AzureProfile(IDataStore store, string profilePath)
        {
            this.store = store;
            this.profilePath = profilePath;

            Load();
        }

        private void Load()
        {
            Environments = new Dictionary<string, AzureEnvironment>(StringComparer.InvariantCultureIgnoreCase);
            Subscriptions = new Dictionary<Guid, AzureSubscription>();
            Accounts = new Dictionary<string, AzureAccount>(StringComparer.InvariantCultureIgnoreCase);
            ProfileLoadErrors = new List<string>();

            if (!store.DirectoryExists(AzureSession.ProfileDirectory))
            {
                store.CreateDirectory(AzureSession.ProfileDirectory);
            }

            if (store.FileExists(profilePath))
            {
                string contents = store.ReadFileAsText(profilePath);

                IProfileSerializer serializer;

                if (ParserHelper.IsXml(contents))
                {
                    serializer = new XmlProfileSerializer();
                    if (!serializer.Deserialize(contents, this))
                    {
                        ProfileLoadErrors.AddRange(serializer.DeserializeErrors);
                    }
                }
                else if (ParserHelper.IsJson(contents))
                {
                    serializer = new JsonProfileSerializer();
                    if (!serializer.Deserialize(contents, this))
                    {
                        ProfileLoadErrors.AddRange(serializer.DeserializeErrors);
                    }
                }
            }

            // Adding predefined environments
            foreach (AzureEnvironment env in AzureEnvironment.PublicEnvironments.Values)
            {
                Environments[env.Name] = env;
            }
        }

        public void Save()
        {
            // Removing predefined environments
            foreach (string env in AzureEnvironment.PublicEnvironments.Keys)
            {
                Environments.Remove(env);
            }

            JsonProfileSerializer jsonSerializer = new JsonProfileSerializer();

            string contents = jsonSerializer.Serialize(this);
            string diskContents = string.Empty;
            if (store.FileExists(profilePath))
            {
                diskContents = store.ReadFileAsText(profilePath);
            }

            if (diskContents != contents)
            {
                store.WriteFile(profilePath, contents);
            }
        }

        public List<string> ProfileLoadErrors { get; private set; }

        public Dictionary<string, AzureEnvironment> Environments { get; set; }

        public Dictionary<Guid, AzureSubscription> Subscriptions { get; set; }

        public Dictionary<string, AzureAccount> Accounts { get; set; }

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
