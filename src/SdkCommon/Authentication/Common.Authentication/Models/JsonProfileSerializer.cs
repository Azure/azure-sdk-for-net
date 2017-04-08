// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
