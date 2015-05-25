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

using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RemoteApp.Tests
{
    /// <summary>
    /// RemoteApp collection user specific test cases
    /// </summary>
    public class RemoteAppPrincipalTests : RemoteAppTestBase
    {
        private IEnumerable<Collection> GetAllActiveCollections(RemoteAppManagementClient client)
        {
            CollectionListResult result = client.Collections.List();

            Assert.NotNull(result);
            Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK, "Failed retrieving the list of collections.");

            IEnumerable<Collection> activeCollections = result.Collections.Where(
                (service, index) =>
                {
                    return string.Equals(service.Status, "Active", StringComparison.OrdinalIgnoreCase);
                });

            Assert.True(activeCollections.Count() > 0, "No active collection exist for the test.");

            return activeCollections;
        }

        /// <summary>
        /// Testing of querying the assigned users from a collection
        /// </summary>
        [Fact]
        public void CanGetRemoteAppPrincipalList()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var client = GetRemoteAppManagementClient();

                // get the list of active collections
                IEnumerable<Collection> collections = GetAllActiveCollections(client);

                foreach (Collection collection in collections)
                {
                    SecurityPrincipalInfoListResult principalList = client.Principals.List(collection.Name);
                    Assert.NotNull(principalList);
                    Assert.True(principalList.SecurityPrincipalInfoList.Count > 0, "No user assigned to the collection with id: " + collection.Name + ".");
                }
            }
        }

        /// <summary>
        /// Testing of negetive case of adding a user to a collection
        /// </summary>
        [Fact]
        public void CanNotAddInvalidPrincipalToCollection()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                RemoteAppManagementClient client = GetRemoteAppManagementClient();

                string collectionName = "asquick";

                SecurityPrincipal user = new SecurityPrincipal("johndoe_test");
                user.SecurityPrincipalType = PrincipalType.User;
                user.UserIdType = PrincipalProviderType.MicrosoftAccount;

                SecurityPrincipalList principals = new SecurityPrincipalList();
                principals.SecurityPrincipals.Add(user);

                SecurityPrincipalOperationsResult result = client.Principals.Add(collectionName, principals);

                Assert.NotNull(result);
                Assert.NotNull(result.Errors);
                Assert.NotEmpty(result.Errors);
            }
        }

        /// <summary>
        /// Testing of adding and removing of users from a collection
        /// </summary>
        [Fact]
        public void CanAddAndRemovePrincipalToCollection()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                string collectionName = "simple";

                RemoteAppManagementClient client = GetRemoteAppManagementClient();

                // verifying the added principals
                SecurityPrincipalInfoListResult principalList = client.Principals.List(collectionName);

                int numberOfUsersBeforeAdd = principalList.SecurityPrincipalInfoList.Count;

                SecurityPrincipalList principals = new SecurityPrincipalList();

                // adding the principals to the collection

                SecurityPrincipal user = new SecurityPrincipal("johndoe_test@hotmail.com");
                user.SecurityPrincipalType = PrincipalType.User;
                user.UserIdType = PrincipalProviderType.MicrosoftAccount;

                principals.SecurityPrincipals.Add(user);

                SecurityPrincipalOperationsResult result = client.Principals.Add(collectionName, principals);

                Assert.NotNull(result);
                Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK || result.StatusCode == System.Net.HttpStatusCode.Accepted, "Failed to add security principal. Status code: " + result.StatusCode + ".");
                Assert.NotNull(result.Errors);
                Assert.Empty(result.Errors);

                // verifying the added principals
                principalList = client.Principals.List(collectionName);

                Assert.NotNull(principalList);

                // verify that all the requested users are added
                Assert.True(principalList.SecurityPrincipalInfoList.Count == (numberOfUsersBeforeAdd + principals.SecurityPrincipals.Count), "Add users did not add the requested users to the collection.");

                List<SecurityPrincipal> matchedPrincipals = new List<SecurityPrincipal>();

                foreach (var principal in principalList.SecurityPrincipalInfoList)
                {
                    foreach (SecurityPrincipal p in principals.SecurityPrincipals)
                    {
                        if (String.Equals(principal.SecurityPrincipal.Name, p.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedPrincipals.Add(principal.SecurityPrincipal);
                        }
                    }
                }

                Assert.True(matchedPrincipals.Count() == 1);
                Assert.Equal(matchedPrincipals.First().Name.ToLowerInvariant(), user.Name.ToLowerInvariant());

                // now remove the added security principals here
                result = client.Principals.Delete(collectionName, principals);

                Assert.NotNull(result);
                Assert.True(result.StatusCode == System.Net.HttpStatusCode.OK || result.StatusCode == System.Net.HttpStatusCode.Accepted, "Failed to remove security principal. Status code: " + result.StatusCode + ".");

                // verifying the deletion of the principals
                principalList = client.Principals.List(collectionName);

                Assert.NotNull(principalList);

                // verify that all the requested users are added
                Assert.Equal(principalList.SecurityPrincipalInfoList.Count, numberOfUsersBeforeAdd);

                matchedPrincipals.Clear();
                Assert.Empty(matchedPrincipals);

                foreach (var principal in principalList.SecurityPrincipalInfoList)
                {
                    foreach (SecurityPrincipal p in principals.SecurityPrincipals)
                    {
                        if (String.Equals(principal.SecurityPrincipal.Name, p.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedPrincipals.Add(principal.SecurityPrincipal);
                        }
                    }
                }

                Assert.Empty(matchedPrincipals);
            }
        }
    }
}
