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

using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using System.Linq;
using System.Net;
using Xunit;

namespace ResourceGroups.Tests
{    
    public class LiveManagementLockTests : TestBase
    {
        public AuthorizationClient GetAuthorizationClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return this.GetAuthorizationClient().WithHandler(handler);
        }
        
        [Fact]
        public void CRUDSubscriptionLock()
        {
            var handler = new RecordedDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetAuthorizationClient(handler);

                string lockName = TestUtilities.GenerateName("mylock");
                string lockType = "Microsoft.Authorization/locks";
                var lockProperties = new ManagementLockProperties
                {
                    Level = "CanNotDelete",
                    Notes = "optional text."
                };
               
                // 1 Create lock
                var createResult1 = client.ManagementLocks.CreateOrUpdateAtSubscriptionLevel(lockName, lockProperties);

                Assert.Equal(HttpStatusCode.Created, createResult1.StatusCode);
                Assert.Equal(lockName, createResult1.ManagementLock.Name);
                Assert.Equal(lockProperties.Level, createResult1.ManagementLock.Properties.Level);
                Assert.Equal(lockProperties.Notes, createResult1.ManagementLock.Properties.Notes);
                Assert.Equal(lockType, createResult1.ManagementLock.Type);

                // 2 Get all subscription level locks with no filter
                var getResult1 = client.ManagementLocks.ListSubscriptionLevel(new ManagementLockGetQueryParameter { AtScope = "" });

                Assert.Equal(HttpStatusCode.OK, getResult1.StatusCode);
                Assert.True(getResult1.Lock.Count > 0);
                Assert.True(getResult1.Lock.Any(p => p.Name == lockName));

                // Get all subscription level locks with filter
                var getResult2 = client.ManagementLocks.ListSubscriptionLevel(new ManagementLockGetQueryParameter() { AtScope = "atScope()" });

                Assert.Equal(HttpStatusCode.OK, getResult2.StatusCode);
                Assert.True(getResult2.Lock.Any(p => p.Name == lockName));

                //Delete lock
                var deleteResult = client.ManagementLocks.DeleteAtSubscriptionLevel(lockName);
                Assert.Equal(HttpStatusCode.OK, deleteResult.StatusCode);
            }
        }

        [Fact]
        public void CRUDResourceGroupLock()
        {
            var handler = new RecordedDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetAuthorizationClient(handler);

                string resourceGroupName = "myRG";
                string lockName = TestUtilities.GenerateName("mylock");
                string lockType = "Microsoft.Authorization/locks";
                var lockProperties = new ManagementLockProperties()
                {
                    Level = "CanNotDelete",
                    Notes = "optional text."
                };
               
               // 1 Create lock
                var createResult1 = client.ManagementLocks.CreateOrUpdateAtResourceGroupLevel(resourceGroupName, lockName, lockProperties);

                Assert.Equal(HttpStatusCode.Created, createResult1.StatusCode);
                Assert.Equal(lockName, createResult1.ManagementLock.Name);
                Assert.Equal(lockProperties.Level, createResult1.ManagementLock.Properties.Level);
                Assert.Equal(lockProperties.Notes, createResult1.ManagementLock.Properties.Notes);
                Assert.Equal(lockType, createResult1.ManagementLock.Type);

                // 2 Get all RG locks with no filter
                var getResult1 = client.ManagementLocks.ListResourceGroupLevel(resourceGroupName, new ManagementLockGetQueryParameter { AtScope = "" });

                Assert.Equal(HttpStatusCode.OK, getResult1.StatusCode);
                Assert.True(getResult1.Lock.Count > 0);
                Assert.True(getResult1.Lock.Any(p => p.Name == lockName));

                // Get all subscription level locks with filter
                var getResult2 = client.ManagementLocks.ListResourceGroupLevel(resourceGroupName, new ManagementLockGetQueryParameter() { AtScope = "atScope()" });

                Assert.Equal(HttpStatusCode.OK, getResult2.StatusCode);
                Assert.True(getResult2.Lock.Count == 1);
                Assert.True(getResult2.Lock.Any(p => p.Name == lockName));

                //Delete lock
                var deleteResult = client.ManagementLocks.DeleteAtResourceGroupLevel(resourceGroupName,lockName);
                Assert.Equal(HttpStatusCode.OK, deleteResult.StatusCode);
            }
        }

        [Fact]
        public void CRUDResourceLock()
        {
            var handler = new RecordedDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetAuthorizationClient(handler);

                string resourceGroupName = "Default-SQL-EastAsia";
                ResourceIdentity resourceIdentity = new ResourceIdentity
                {
                    ParentResourcePath = "servers/g6gsefjdal",
                    ResourceName = "AutomatedSqlExport_manikdb_20131123T091548Z",
                    ResourceProviderNamespace = "Microsoft.Sql",
                    ResourceProviderApiVersion = "2014-01-04",
                    ResourceType = "databases"
                };
                string lockName = TestUtilities.GenerateName("mylock");
                string lockType = "Microsoft.Authorization/locks";
                var lockProperties = new ManagementLockProperties()
                {
                    Level = "CanNotDelete",
                    Notes = "optional text."
                };
                
                // 1 Create lock
                var createResult = client.ManagementLocks.CreateOrUpdateAtResourceLevel(resourceGroupName, resourceIdentity, lockName, lockProperties);
                
                Assert.Equal(HttpStatusCode.Created, createResult.StatusCode);
                Assert.Equal(lockName, createResult.ManagementLock.Name);
                Assert.Equal(lockProperties.Level, createResult.ManagementLock.Properties.Level);
                Assert.Equal(lockProperties.Notes, createResult.ManagementLock.Properties.Notes);
                Assert.Equal(lockType, createResult.ManagementLock.Type);

                // 2 Get all RG locks with no filter
                var getResult1 = client.ManagementLocks.ListResourceLevel(resourceGroupName, resourceIdentity, new ManagementLockGetQueryParameter { AtScope = "" });

                Assert.Equal(HttpStatusCode.OK, getResult1.StatusCode);
                Assert.True(getResult1.Lock.Any(p => p.Name==lockName));
                
                // 3 Get all resource level locks with filter
                var getResult2 = client.ManagementLocks.ListResourceLevel(resourceGroupName, resourceIdentity, new ManagementLockGetQueryParameter() { AtScope = "atScope()" });

                Assert.Equal(HttpStatusCode.OK, getResult2.StatusCode);
                Assert.True(getResult2.Lock.Any(p => p.Name == lockName));

                //Delete lock
                var deleteResult = client.ManagementLocks.DeleteAtResourceLevel(resourceGroupName, resourceIdentity, lockName);
                Assert.Equal(HttpStatusCode.OK, deleteResult.StatusCode);
            }
        }
    }
}