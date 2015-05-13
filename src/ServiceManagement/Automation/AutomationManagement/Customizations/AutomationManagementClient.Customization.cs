//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Hyak.Common;
using Microsoft.WindowsAzure.Management.Automation.Models;

namespace Microsoft.WindowsAzure.Management.Automation
{
    public partial class AutomationManagementClient
    {
        public static List<T> ContinuationTokenHandler<T>(Func<string, ResponseWithSkipToken<T>> listFunc)
        {
            var models = new List<T>();
            string skipToken = null;
            do
            {
                var result = listFunc.Invoke(skipToken);
                models.AddRange(result.AutomationManagementModels);
                skipToken = result.SkipToken;
            }
            while (!string.IsNullOrEmpty(skipToken));
            return models;
        }
    }

    public static class AutomationManagementExtensions
    {
        public static void CreateAutomationAccount(this IAutomationManagementClient client, string automationAccountName, string location)
        {
            if (automationAccountName == null)
            {
                throw new ArgumentNullException("automationAccountName");
            }

            if (location == null)
            {
                throw new ArgumentNullException("location");
            }

            var generatedCsName = string.Format(CultureInfo.InvariantCulture, "OaasCS{0}-{1}", client.Credentials.SubscriptionId, location.Replace(' ', '-'));

            try
            {
                client.CloudServices.Create(
                        new CloudServiceCreateParameters()
                        {
                            Name = generatedCsName,
                            GeoRegion = location,
                            Label = generatedCsName,
                            Description = "Cloud Service created via SDK client"
                        });
            }
            catch (CloudException)
            {
                // Ignore create cloud service error
            }

            client.AutomationAccounts.Create(generatedCsName,
                    new AutomationAccountCreateParameters()
                    {
                        Name = automationAccountName,
                        CloudServiceSettings = new CloudServiceSettings
                        {
                            GeoRegion = location
                        },
                    });
        }

        public static void DeleteAutomationAccount(this IAutomationManagementClient client, string automationAccountName)
        {
            if (automationAccountName == null)
            {
                throw new ArgumentNullException("automationAccountName");
            }

            var cloudServices = client.CloudServices.List().CloudServices;

            foreach (var cloudService in cloudServices)
            {
                if (cloudService.Resources.Any(resource => 0 == String.Compare(resource.Name, automationAccountName, CultureInfo.InvariantCulture,
                    CompareOptions.IgnoreCase)))
                {
                    client.AutomationAccounts.Delete(cloudService.Name, automationAccountName);
                    return;
                }
            }
        }
    }
}