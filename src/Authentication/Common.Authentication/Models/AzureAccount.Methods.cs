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

using Microsoft.Azure.Common.Authentication.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Microsoft.Azure.Common.Authentication.Models
{
    public partial class AzureAccount
    {
        public AzureAccount()
        {
            Properties = new Dictionary<Property,string>();
        }

        public string GetProperty(Property property)
        {
            return Properties.GetProperty(property);
        }

        public string[] GetPropertyAsArray(Property property)
        {
            return Properties.GetPropertyAsArray(property);
        }

        public void SetProperty(Property property, params string[] values)
        {
            Properties.SetProperty(property, values);
        }

        public void SetOrAppendProperty(Property property, params string[] values)
        {
            Properties.SetOrAppendProperty(property, values);
        }

        public bool IsPropertySet(Property property)
        {
            return Properties.IsPropertySet(property);
        }

        public List<AzureSubscription> GetSubscriptions(AzureSMProfile profile)
        {
            string subscriptions = string.Empty;
            List<AzureSubscription> subscriptionsList = new List<AzureSubscription>();
            if (Properties.ContainsKey(Property.Subscriptions))
            {
                subscriptions = Properties[Property.Subscriptions];
            }

            foreach (var subscription in subscriptions.Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                try
                {
                    Guid subscriptionId = new Guid(subscription);
                    Debug.Assert(profile.Subscriptions.ContainsKey(subscriptionId));
                    subscriptionsList.Add(profile.Subscriptions[subscriptionId]);
                }
                catch
                {
                    // Skip
                }
            }

            return subscriptionsList;
        }

        public bool HasSubscription(Guid subscriptionId)
        {
            bool exists = false;
            string subscriptions = GetProperty(Property.Subscriptions);

            if (!string.IsNullOrEmpty(subscriptions))
            {
                exists = subscriptions.Contains(subscriptionId.ToString());
            }

            return exists;
        }

        public void SetSubscriptions(List<AzureSubscription> subscriptions)
        {
            if (subscriptions == null || subscriptions.Count == 0)
            {
                if (Properties.ContainsKey(Property.Subscriptions))
                {
                    Properties.Remove(Property.Subscriptions);
                }
            }
            else
            {
                string value = string.Join(",", subscriptions.Select(s => s.Id.ToString()));
                Properties[Property.Subscriptions] = value;
            }
        }

        public void RemoveSubscription(Guid id)
        {
            if (HasSubscription(id))
            {
                var remainingSubscriptions = GetPropertyAsArray(Property.Subscriptions).Where(s => s != id.ToString()).ToArray();

                if (remainingSubscriptions.Any())
                {
                    Properties[Property.Subscriptions] = string.Join(",", remainingSubscriptions);
                }
                else
                {
                    Properties.Remove(Property.Subscriptions);
                }
            }
        }

        public override bool Equals(object obj)
        {
            var anotherAccount = obj as AzureAccount;
            if (anotherAccount == null)
            {
                return false;
            }
            else
            {
                return string.Equals(anotherAccount.Id, Id, StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
