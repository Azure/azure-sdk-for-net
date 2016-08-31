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

using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Azure.OData;

namespace Microsoft.Azure.Graph.RBAC.Tests
{
    public class ApplicationAndServicePrincipalTests : GraphTestBase
    {
        [Fact]
        public void CRUDApplicationTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var passwordCredential = CreatePasswordCredential();
                var keyCredential = CreateKeyCredential();
                Application application = null;

                try
                {
                    application = CreateApplication(context, passwordCredential, keyCredential);

                    // Get application by appId, appObjectId, displayname, identifierUri
                    var fetchedAppByObjectId = GetApplicationByObjectId(context, application.ObjectId);
                    ValidateApplication(application, fetchedAppByObjectId);

                    var fetchedAppByAppId = SearchApplication(context, new ODataQuery<Application>(a => a.AppId == application.AppId)).FirstOrDefault();
                    ValidateApplication(application, fetchedAppByAppId);

                    var fetchedAppByDisplayName = SearchApplication(context, new ODataQuery<Application>(a => a.DisplayName.StartsWith(application.DisplayName))).FirstOrDefault();
                    ValidateApplication(application, fetchedAppByDisplayName);

                    var identifierUri = application.IdentifierUris.First();
                    var fetchedAppByIdentifierUri = SearchApplication(context, new ODataQuery<Application>(a => a.IdentifierUris.Contains(identifierUri))).FirstOrDefault();
                    ValidateApplication(application, fetchedAppByIdentifierUri);

                    // update displayName and identifierUri
                    string newDisplayName = application.DisplayName + "Updated";
                    string newIdentifierUri = application.IdentifierUris.First() + "Updated";
                    application.DisplayName = newDisplayName;
                    application.IdentifierUris = new List<string>() { newIdentifierUri };

                    UpdateApplication(context, application.ObjectId, newDisplayName: newDisplayName, newIdentifierUri: newIdentifierUri);

                    var updatedApplication = GetApplicationByObjectId(context, application.ObjectId);
                    ValidateApplication(application, updatedApplication);

                    var newPasswordCredential = CreatePasswordCredential();
                    UpdateApplication(context, application.ObjectId, passwordCredential: newPasswordCredential);
                }
                finally
                {
                    if(application !=null)
                    {
                        DeleteApplication(context, application.ObjectId);
                    }                    
                }

                //verify the application has been deleted.
                Assert.Throws(typeof(GraphErrorException), () => { GetApplicationByObjectId(context, application.ObjectId); });
            }
        }

        [Fact]
        public void CreateDeleteAppCredentialTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                Application application = null;
                try
                {
                    // Create a new application without credentials
                    application = CreateApplication(context);
                    var appObjectId = application.ObjectId;

                    // Get App credentials - should be 0
                    var keyCreds = GetAppKeyCredential(context, appObjectId);
                    Assert.Equal(0, keyCreds.Count);

                    var passwordCreds = GetAppPasswordCredential(context, appObjectId);
                    Assert.Equal(0, passwordCreds.Count);

                    // Add a password credential
                    string keyId = "a687d7e2-7c5f-4411-afae-e78ae43a9395";
                    var passwordCredential1 = CreatePasswordCredential(keyId);
                    UpdateAppPasswordCredential(context, appObjectId, passwordCredential1);

                    // Add a keyCredential
                    keyId = "8e7911c6-f9ff-46d2-9124-76ffb307cadc";
                    var keyCredential = CreateKeyCredential(keyId);
                    UpdateAppKeyCredential(context, appObjectId, keyCredential);

                    // Get app credentials
                    keyCreds = GetAppKeyCredential(context, appObjectId);
                    Assert.Equal(1, keyCreds.Count);
                    Assert.True(keyCreds.Any(c => c.KeyId == keyCredential.KeyId));

                    passwordCreds = GetAppPasswordCredential(context, appObjectId);
                    Assert.Equal(1, passwordCreds.Count);
                    Assert.True(passwordCreds.Any(c => c.KeyId == passwordCredential1.KeyId));

                    // Append a new passwordCredential to exisitng credentials
                    keyId = "71986590-87c7-45c2-b85e-f5ef022e821f";
                    var passwordCredential2 = CreatePasswordCredential(keyId);
                    passwordCreds.Add(passwordCredential2);
                    UpdateAppPasswordCredential(context, appObjectId, passwordCreds);

                    //Get
                    var fetchedpasswordCreds2 = GetAppPasswordCredential(context, appObjectId);
                    Assert.Equal(2, fetchedpasswordCreds2.Count);
                    Assert.True(fetchedpasswordCreds2.Any(c => c.KeyId == passwordCredential2.KeyId));
                    Assert.True(fetchedpasswordCreds2.Any(c => c.KeyId == passwordCredential1.KeyId));

                    // Add 2 new password credentils -- older should be removed
                    keyId = "7880f3aa-66ee-4e63-a427-3a89d316b039";
                    var passwordCredential3 = CreatePasswordCredential(keyId);
                    keyId = "18a32ca3-536f-462f-b3b4-eec49e505e96";
                    var passwordCredential4 = CreatePasswordCredential(keyId);
                    UpdateAppPasswordCredential(context, appObjectId, new List<PasswordCredential> { passwordCredential3, passwordCredential4 });

                    //Get
                    var fetchedpasswordCreds3 = GetAppPasswordCredential(context, appObjectId);
                    Assert.Equal(2, fetchedpasswordCreds3.Count);
                    Assert.True(fetchedpasswordCreds3.Any(c => c.KeyId == passwordCredential3.KeyId));
                    Assert.True(fetchedpasswordCreds3.Any(c => c.KeyId == passwordCredential4.KeyId));

                    // Remove key credentials
                    UpdateAppKeyCredential(context, appObjectId, new List<KeyCredential>());

                    // Get app credentials
                    var deletedkeyCreds = GetAppKeyCredential(context, appObjectId);
                    Assert.Equal(0, deletedkeyCreds.Count);

                    // Remove password credentials
                    UpdateAppPasswordCredential(context, appObjectId, new List<PasswordCredential>());

                    // Get app credentials
                    var deletedPasswordCreds = GetAppPasswordCredential(context, appObjectId);
                    Assert.Equal(0, deletedPasswordCreds.Count);
                }
                finally
                {
                    if (application != null)
                    {
                        // Delete application
                        DeleteApplication(context, application.ObjectId);
                    }
                }
            }
        }


        [Fact]
        public void CreateDeleteSpCredentialTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                Application application = null;
                ServicePrincipal sp = null;
                try
                {
                    // Create a new application without credentials
                    application = CreateApplication(context);
                    sp = CreateServicePrincipal(context, application.AppId);
                    var spObjectId = sp.ObjectId;

                    // Get Sp credentials - should be 0
                    var keyCreds = GetSpKeyCredential(context, spObjectId);
                    Assert.Equal(0, keyCreds.Count);

                    var passwordCreds = GetSpPasswordCredential(context, spObjectId);
                    Assert.Equal(0, passwordCreds.Count);

                    // Add a password credential
                    string keyId = "dbf1c168-ebe9-4b93-8b14-83462734c164";
                    var passwordCredential1 = CreatePasswordCredential(keyId);
                    UpdateSpPasswordCredential(context, spObjectId, passwordCredential1);

                    // Add a keyCredential
                    keyId = "9baef13d-5d0d-455e-9920-95acb87265e6";
                    var keyCredential = CreateKeyCredential(keyId);
                    UpdateSpKeyCredential(context, spObjectId, keyCredential);

                    // Get sp credentials
                    keyCreds = GetSpKeyCredential(context, spObjectId);
                    Assert.Equal(1, keyCreds.Count);
                    Assert.True(keyCreds.Any(c => c.KeyId == keyCredential.KeyId));

                    passwordCreds = GetSpPasswordCredential(context, spObjectId);
                    Assert.Equal(1, passwordCreds.Count);
                    Assert.True(passwordCreds.Any(c => c.KeyId == passwordCredential1.KeyId));

                    // Append a new passwordCredential to exisitng credentials
                    keyId = "debcca8c-4fa0-4b40-8d21-853a3213f328";
                    var passwordCredential2 = CreatePasswordCredential(keyId);
                    passwordCreds.Add(passwordCredential2);
                    UpdateSpPasswordCredential(context, spObjectId, passwordCreds);

                    //Get
                    var fetchedpasswordCreds2 = GetSpPasswordCredential(context, spObjectId);
                    Assert.Equal(2, fetchedpasswordCreds2.Count);
                    Assert.True(fetchedpasswordCreds2.Any(c => c.KeyId == passwordCredential2.KeyId));
                    Assert.True(fetchedpasswordCreds2.Any(c => c.KeyId == passwordCredential1.KeyId));

                    // Add 2 new password credentils -- older should be removed
                    keyId = "19b89f7a-b2fd-444e-bed6-41d66df7eba5";
                    var passwordCredential3 = CreatePasswordCredential(keyId);
                    keyId = "047db843-cff1-4e64-b924-8b235650a4c2";
                    var passwordCredential4 = CreatePasswordCredential(keyId);
                    UpdateSpPasswordCredential(context, spObjectId, new List<PasswordCredential> { passwordCredential3, passwordCredential4 });

                    //Get
                    var fetchedpasswordCreds3 = GetSpPasswordCredential(context, spObjectId);
                    Assert.Equal(2, fetchedpasswordCreds3.Count);
                    Assert.True(fetchedpasswordCreds3.Any(c => c.KeyId == passwordCredential3.KeyId));
                    Assert.True(fetchedpasswordCreds3.Any(c => c.KeyId == passwordCredential4.KeyId));

                    // Remove key credentials
                    UpdateSpKeyCredential(context, spObjectId, new List<KeyCredential>());

                    // Get sp credentials
                    var deletedkeyCreds = GetSpKeyCredential(context, spObjectId);
                    Assert.Equal(0, deletedkeyCreds.Count);

                    // Remove password credentials
                    UpdateSpPasswordCredential(context, spObjectId, new List<PasswordCredential>());

                    // Get sp credentials
                    var deletedPasswordCreds = GetSpPasswordCredential(context, spObjectId);
                    Assert.Equal(0, deletedPasswordCreds.Count);
                }
                finally
                {
                    if (sp != null)
                    {
                        DeleteServicePrincipal(context, sp.ObjectId);
                    }

                    if (application != null)
                    {
                        // Delete application
                        DeleteApplication(context, application.ObjectId);
                    }
                }
            }
        }


        [Fact]
        public void NegativeCredentialTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Get App credentials on a random app- should fail
                var randomObjectId = "bb66c9c6-7101-4a84-9bd1-c7aef0a561b1";
                var newPasswordCredential = CreatePasswordCredential();
                var newKeyCredential = CreateKeyCredential();

                // Get App credentials - should fail
                Assert.Throws(typeof(GraphErrorException), () => GetAppKeyCredential(context, randomObjectId));
                Assert.Throws(typeof(GraphErrorException), () => GetAppPasswordCredential(context, randomObjectId));

                // Add credentials on a random app - should fail
                Assert.Throws(typeof(GraphErrorException), () => UpdateAppKeyCredential(context, randomObjectId, newKeyCredential));
                Assert.Throws(typeof(GraphErrorException), () => UpdateAppPasswordCredential(context, randomObjectId, newPasswordCredential));

                // Get Sp credentials - should fail
                Assert.Throws(typeof(GraphErrorException), () => GetSpKeyCredential(context, randomObjectId));
                Assert.Throws(typeof(GraphErrorException), () => GetAppPasswordCredential(context, randomObjectId));

                // Add credentials on a random app - should fail
                Assert.Throws(typeof(GraphErrorException), () => UpdateSpKeyCredential(context, randomObjectId, newKeyCredential));
                Assert.Throws(typeof(GraphErrorException), () => UpdateSpPasswordCredential(context, randomObjectId, newPasswordCredential));
            }
        }

        [Fact]
        public void CreateDeleteServicePrincipalTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                ServicePrincipal sp = null;

                //Test
                var passwordCredential = CreatePasswordCredential();
                var application = CreateApplication(context, passwordCredential);
                try
                {
                    sp = CreateServicePrincipal(context, application.AppId);
                    DeleteServicePrincipal(context, sp.ObjectId);
                }
                finally
                {
                    DeleteApplication(context, application.ObjectId);
                }

                //verify the user has been deleted.
                Assert.Throws(typeof(GraphErrorException), () => { SearchServicePrincipal(context, sp.ObjectId); });
            }
        }

        private void ValidateApplication(Application expected, Application actual)
        {
            if(expected == null && actual ==null)
            {
                return;
            }

            Assert.NotNull(expected);
            Assert.NotNull(actual);
            Assert.Equal(expected.AppId, actual.AppId);
            Assert.Equal(expected.ObjectId, actual.ObjectId);
            Assert.Equal(expected.DisplayName, actual.DisplayName);
            Assert.Equal(expected.IdentifierUris, actual.IdentifierUris);
            Assert.Equal(expected.ReplyUrls, actual.ReplyUrls);
            Assert.Equal(expected.Homepage, actual.Homepage);
            Assert.Equal(expected.AvailableToOtherTenants, actual.AvailableToOtherTenants);
        }
    }
}
