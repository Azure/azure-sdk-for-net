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

using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Testing;

namespace Microsoft.WindowsAzure.Management.Testing
{
    using System;
    using System.Linq;
    using Management;
    using Management.Models;
    using Microsoft.Azure.Test;
    using Xunit;
    public class SubscriptionPrincipalTest : TestBase
    {
        [Fact]
        public void SubscriptionCRUD()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var mgmt = this.GetManagementClient();

                // Retrive existing SPN's if any
                var existingSPNs = mgmt.SubscriptionServicePrincipals.List();

                // Generate a Random SPN Object Id
                string newSPNObjectId = Guid.NewGuid().ToString();

                // Add SPN to subscription
                mgmt.SubscriptionServicePrincipals.Create(new SubscriptionServicePrincipalCreateParameters(newSPNObjectId));

                // List SPNs in the subscription
                var subscriptionPrincipals = mgmt.SubscriptionServicePrincipals.List();

                Assert.Equal(existingSPNs.Count() + 1, subscriptionPrincipals.Count());

                // Verify SPN added is returned correctly
                bool found = false;
                foreach(var spn in subscriptionPrincipals)
                {
                    if (existingSPNs.Any(s => s.ServicePrincipalId.Equals(spn.ServicePrincipalId)))
                    {
                        continue;
                    }

                    if(spn.ServicePrincipalId.Equals(newSPNObjectId))
                    {
                        found = true;
                        break;
                    }
                }
                Assert.True(found, "New SPN added should have been returned");

                // Get SPN by SPN Id
                var subscriptionPrincipal = mgmt.SubscriptionServicePrincipals.Get(newSPNObjectId);
                Assert.Equal(newSPNObjectId, subscriptionPrincipal.ServicePrincipalId);

                // Delete SPN
                var response = mgmt.SubscriptionServicePrincipals.Delete(newSPNObjectId);

                // Verify Delete was successful
                subscriptionPrincipals = mgmt.SubscriptionServicePrincipals.List();

                Assert.Equal(existingSPNs.Count(), subscriptionPrincipals.Count());

                foreach (var spn in subscriptionPrincipals)
                {
                    if (existingSPNs.Any(s => s.ServicePrincipalId.Equals(spn.ServicePrincipalId)))
                    {
                        continue;
                    }

                    if (spn.ServicePrincipalId.Equals(newSPNObjectId))
                    {
                        Assert.True(false, "New SPN should not be returned, it was deleted.");
                    }
                }
            }
        }
    }
}
