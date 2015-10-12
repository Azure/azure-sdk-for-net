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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.Azure.Common.Authentication.Models
{
    public class XmlProfileSerializer : IProfileSerializer
    {
        public string Serialize(AzureSMProfile obj)
        {
            // We do not use the serialize for xml serializer anymore and rely solely on the JSON serializer.
            throw new NotImplementedException();
        }

        public bool Deserialize(string contents, AzureSMProfile profile)
        {
            ProfileData data;
            Debug.Assert(profile != null);

            DeserializeErrors = new List<string>();

            DataContractSerializer serializer = new DataContractSerializer(typeof(ProfileData));
            using (MemoryStream s = new MemoryStream(Encoding.UTF8.GetBytes(contents ?? "")))
            {
                data = (ProfileData)serializer.ReadObject(s);
            }

            if (data != null)
            {
                foreach (AzureEnvironmentData oldEnv in data.Environments)
                {
                    profile.Environments[oldEnv.Name] = oldEnv.ToAzureEnvironment();
                }

                List<AzureEnvironment> envs = profile.Environments.Values.ToList();
                foreach (AzureSubscriptionData oldSubscription in data.Subscriptions)
                {
                    try
                    {
                        var newSubscription = oldSubscription.ToAzureSubscription(envs);
                        if (newSubscription.Account == null)
                        {
                            continue;
                        }

                        var newAccounts = oldSubscription.ToAzureAccounts();
                        foreach (var account in newAccounts)
                        {
                            if (profile.Accounts.ContainsKey(account.Id))
                            {
                                profile.Accounts[account.Id].SetOrAppendProperty(AzureAccount.Property.Tenants,
                                    account.GetPropertyAsArray(AzureAccount.Property.Tenants));
                                profile.Accounts[account.Id].SetOrAppendProperty(AzureAccount.Property.Subscriptions,
                                    account.GetPropertyAsArray(AzureAccount.Property.Subscriptions));
                            }
                            else
                            {
                                profile.Accounts[account.Id] = account;
                            }
                        }

                        profile.Subscriptions[newSubscription.Id] = newSubscription;
                    }
                    catch (Exception ex)
                    {
                        // Skip subscription if failed to load
                        DeserializeErrors.Add(ex.Message);
                    }
                }
            }

            return DeserializeErrors.Count == 0;
        }

        public IList<string> DeserializeErrors { get; private set; }
    }
}
