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

using Hyak.Common;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace Microsoft.Azure.Graph.RBAC.Tests
{
    public class ApplicationTests
    {
        [Fact]
        public void CreateDeleteApplicationTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                //Arrange
                var client = new GraphTestBase();

                //Test
                var passwordCredential = client.CreatePasswordCredential();
                var keyCredential = client.CreateKeyCredential();
                var application = client.CreateApplication(passwordCredential, keyCredential);
                try
                {
                    var newPasswordCredential = client.CreatePasswordCredential();
                    client.UpdateApplication(application.ObjectId, newPasswordCredential);
                }
                finally
                {
                    client.DeleteApplication(application.ObjectId);
                }

                //verify the app has been deleted.
                Assert.Throws(typeof(CloudException), () => { client.GetpplicationByAppObjectId(application.ObjectId); });
            }
        }

        [Fact]
        public void GetListApplicationTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                //Arrange
                var client = new GraphTestBase();

                //Test
                var passwordCredential = client.CreatePasswordCredential();
                var keyCredential = client.CreateKeyCredential();
                var application = client.CreateApplication(passwordCredential, keyCredential);
                try
                {
                    // Get Application by applicationObjectId
                    var fetchedApplicationByAppObjectId = client.GetpplicationByAppObjectId(application.ObjectId);
                    Assert.NotNull(fetchedApplicationByAppObjectId);
                    Assert.Equal(application.ObjectId, fetchedApplicationByAppObjectId.ObjectId);

                    //Get Application by applicationId
                    var fetchedApplicationsByAppId = client.ListApplicationsByFilters(new ApplicationFilterParameters { AppId = Guid.Parse(application.AppId) });
                    Assert.NotNull(fetchedApplicationsByAppId);
                    Assert.Equal(1, fetchedApplicationsByAppId.Count);
                    Assert.Equal(application.AppId, fetchedApplicationsByAppId.First().AppId);

                    // Get Application by identifierUri
                    var fetchedApplicationsByIdentifierUri = client.ListApplicationsByFilters(new ApplicationFilterParameters { IdentifierUri = application.IdentifierUris.First() });
                    Assert.NotNull(fetchedApplicationsByIdentifierUri);
                    Assert.Equal(1, fetchedApplicationsByIdentifierUri.Count);
                    Assert.True(fetchedApplicationsByIdentifierUri.First().IdentifierUris.Contains(application.IdentifierUris.First()));

                    // Get Application by startswith name
                    var fetchedApplicationsByDisplayNamePrefix = client.ListApplicationsByFilters(new ApplicationFilterParameters { DisplayNameStartsWith = "adApplication" });
                    Assert.NotNull(fetchedApplicationsByDisplayNamePrefix);
                    Assert.True(fetchedApplicationsByDisplayNamePrefix.Count >= 1);
                    Assert.True(fetchedApplicationsByDisplayNamePrefix.All(a => a.DisplayName.StartsWith("adApplication")));

                    // Get Application by startswith name
                    var fetchedApplicationsByDisplayNameExact = client.ListApplicationsByFilters(new ApplicationFilterParameters { DisplayNameStartsWith = application.DisplayName });
                    Assert.NotNull(fetchedApplicationsByDisplayNameExact);
                    Assert.Equal(1, fetchedApplicationsByDisplayNameExact.Count);
                    Assert.True(fetchedApplicationsByDisplayNameExact.First().DisplayName.StartsWith(application.DisplayName));
                }
                finally
                {
                    client.DeleteApplication(application.ObjectId);
                }

                Assert.Throws(typeof(CloudException), () => { client.GetpplicationByAppObjectId(application.ObjectId); });
            }
        }

    }
}
