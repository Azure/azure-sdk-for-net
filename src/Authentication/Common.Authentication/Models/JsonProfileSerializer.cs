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

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Common.Authentication.Models
{
    public class JsonProfileSerializer : IProfileSerializer
    {
        public string Serialize(AzureSMProfile profile)
        {
            return JsonConvert.SerializeObject(new
            {
                Environments = profile.Environments.Values.ToList(),
                Subscriptions = profile.Subscriptions.Values.ToList(),
                Accounts = profile.Accounts.Values.ToList()
            }, Formatting.Indented);
        }

        public bool Deserialize(string contents, AzureSMProfile profile)
        {
            DeserializeErrors = new List<string>();

            try
            {
                var jsonProfile = JObject.Parse(contents);

                foreach (var env in jsonProfile["Environments"])
                {
                    try
                    {
                        profile.Environments[(string) env["Name"]] =
                            JsonConvert.DeserializeObject<AzureEnvironment>(env.ToString());
                    }
                    catch (Exception ex)
                    {
                        DeserializeErrors.Add(ex.Message);
                    }
                }

                foreach (var subscription in jsonProfile["Subscriptions"])
                {
                    try
                    {
                        profile.Subscriptions[new Guid((string) subscription["Id"])] =
                            JsonConvert.DeserializeObject<AzureSubscription>(subscription.ToString());
                    }
                    catch (Exception ex)
                    {
                        DeserializeErrors.Add(ex.Message);
                    }
                }

                foreach (var account in jsonProfile["Accounts"])
                {
                    try
                    {
                        profile.Accounts[(string) account["Id"]] =
                            JsonConvert.DeserializeObject<AzureAccount>(account.ToString());
                    }
                    catch (Exception ex)
                    {
                        DeserializeErrors.Add(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                DeserializeErrors.Add(ex.Message);
            }
            return DeserializeErrors.Count == 0;
        }

        public IList<string> DeserializeErrors { get; private set; }
    }
}
