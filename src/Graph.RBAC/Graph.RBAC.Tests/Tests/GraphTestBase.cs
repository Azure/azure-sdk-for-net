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
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Azure.Test.HttpRecorder;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Graph.RBAC.Tests
{
    class GraphTestBase : TestBase
    {
        public const string TenantIdKey = "TenantId";
        public const string DomainKey = "Domain";

        public GraphRbacManagementClient GraphClient { get; private set; }

        public string Domain { get; private set; }

        public GraphTestBase()
        {
            var testFactory = new CSMTestEnvironmentFactory();
            TestEnvironment environment = testFactory.GetTestEnvironment();

            string tenantId = null;
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                tenantId = environment.AuthorizationContext.TenantId;
                Domain = environment.AuthorizationContext.UserId
                            .Split(new [] {"@"}, StringSplitOptions.RemoveEmptyEntries)
                            .Last();

                HttpMockServer.Variables[TenantIdKey] = tenantId;
                HttpMockServer.Variables[DomainKey] = Domain;
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                tenantId = HttpMockServer.Variables[TenantIdKey];
                Domain = HttpMockServer.Variables[DomainKey];
            }

            GraphClient = TestBase.GetGraphServiceClient<GraphRbacManagementClient>(testFactory, tenantId);
        }

        public KeyCredential CreateKeyCredential()
        {
            X509Certificate applicationCertificate = new X509Certificate("SampleApplicationCredential.cer");
            KeyCredential cred = new KeyCredential();
            cred.StartDate = DateTime.Now;
            cred.EndDate = DateTime.Now.AddMonths(12);
            cred.KeyId = Guid.NewGuid();
            cred.Value = Convert.ToBase64String(applicationCertificate.GetRawCertData());
            cred.Type = "AsymmetricX509Cert";
            cred.Usage = "Verify";
            return cred;
        }

        public PasswordCredential CreatePasswordCredential()
        {
            string DirectoryAccessKey;
            using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider())
            {
                byte[] key = new byte[32];
                provider.GetBytes(key);
                DirectoryAccessKey = Convert.ToBase64String(key);
            }
            PasswordCredential cred = new PasswordCredential();
            cred.StartDate = DateTime.Now;
            cred.EndDate = DateTime.Now.AddMonths(12);
            cred.KeyId = Guid.NewGuid();
            cred.Value = DirectoryAccessKey;
            return cred;
        }

        public Application CreateApplication(PasswordCredential passwordCredential = null, KeyCredential keyCredential = null, string applicationName = null)
        {
            var appName = applicationName ?? TestUtilities.GenerateName("adApplication");
            var url = string.Format("http://{0}/home", appName);
            var parameters = new ApplicationCreateParameters();

            parameters.AvailableToOtherTenants = false;
            parameters.DisplayName = appName;
            parameters.Homepage = url;
            parameters.IdentifierUris = new[] { url };
            parameters.ReplyUrls = new[] { url };

            if (passwordCredential != null)
            {
                parameters.PasswordCredentials = new PasswordCredential[] { passwordCredential };
            }

            if (keyCredential != null)
            {
                parameters.KeyCredentials = new KeyCredential[] { keyCredential };
            }

            return GraphClient.Application.Create(parameters).Application;
        }

        public void UpdateApplication(String applicaitonObjectId, PasswordCredential passwordCredential = null, KeyCredential keyCredential = null)
        {
            var appName = TestUtilities.GenerateName("adApplication");
            var url = string.Format("http://{0}/home", appName);
            var parameters = new ApplicationCreateParameters();

            parameters.AvailableToOtherTenants = false;
            parameters.DisplayName = appName;
            parameters.Homepage = url;
            parameters.IdentifierUris = new[] { url };
            parameters.ReplyUrls = new[] { url };

            if (passwordCredential != null)
            {
                parameters.PasswordCredentials = new PasswordCredential[] { passwordCredential };
            }

            if (keyCredential != null)
            {
                parameters.KeyCredentials = new KeyCredential[] { keyCredential };
            }

            GraphClient.Application.Update(applicaitonObjectId, parameters);
        }

        public void DeleteApplication(string appObjectId)
        {
            GraphClient.Application.Delete(appObjectId);
        }

        public Application GetpplicationByAppObjectId(string appObjectId)
        {
            return GraphClient.Application.Get(appObjectId).Application;
        }

        public IList<Application> ListApplicationsByFilters(ApplicationFilterParameters parameters)
        {
            return GraphClient.Application.List(parameters).Applications;
        }

        public ServicePrincipal CreateServicePrincipal(string appId)
        {
            var parameters = new ServicePrincipalCreateParameters
            {
                AccountEnabled = true,
                AppId = appId
            };

            return GraphClient.ServicePrincipal.Create(parameters).ServicePrincipal;
        }

        public void DeleteServicePrincipal(string spObjectId)
        {
            GraphClient.ServicePrincipal.Delete(spObjectId);
        }

        public void SearchServicePrincipal(string spObjectId)
        {
            GraphClient.ServicePrincipal.Get(spObjectId);
        }

        public User CreateUser()
        {
            string username = TestUtilities.GenerateName("aduser");
            string upn = username + "@" + Domain;

            UserCreateParameters parameter = new UserCreateParameters();
            parameter.UserPrincipalName = upn;
            parameter.DisplayName = username;
            parameter.AccountEnabled = true;
            parameter.MailNickname = username + "test"; 
            parameter.PasswordProfileSettings = new UserCreateParameters.PasswordProfile();
            parameter.PasswordProfileSettings.ForceChangePasswordNextLogin = false;
            parameter.PasswordProfileSettings.Password = "Test12345";

            return GraphClient.User.Create(parameter).User;
        }

        public void DeleteUser(string upnOrObjectId)
        {
            GraphClient.User.Delete(upnOrObjectId);
        }

        public void SearchUser(string upnOrObjectId)
        {
            GraphClient.User.Get(upnOrObjectId);
        }

        public Group CreateGroup()
        {
            string groupname = TestUtilities.GenerateName("adgroup");
            string mailNickName = groupname + "tester";
            GroupCreateParameters parameters = new GroupCreateParameters();
            parameters.DisplayName = groupname;
            parameters.MailEnabled = false;
            parameters.SecurityEnabled = true;
            parameters.MailNickname = mailNickName;

            return GraphClient.Group.Create(parameters).Group;
        }

        public void DeleteGroup(string objectId)
        {
            GraphClient.Group.Delete(objectId);
        }

        public void SearchGroup(string objectId)
        {
            GraphClient.Group.Get(objectId);
        }

        public void AddMember(Group group, User user)
        {
            string memberUrl = string.Format("{0}{1}/directoryObjects/{2}",
                GraphClient.BaseUri.AbsoluteUri, GraphClient.TenantID, user.ObjectId);
            GraphClient.Group.AddMember(group.ObjectId, new GroupAddMemberParameters(memberUrl));
        }

        //return all groups the user is a member of (transitive)
        public IList<string> GetMemberGroups(User user)
        {
            return GraphClient.User.GetMemberGroups(new UserGetMemberGroupsParameters(user.ObjectId, false)).ObjectIds;
        }

        public void RemoveMember(Group group, User user)
        {
            GraphClient.Group.RemoveMember(group.ObjectId, user.ObjectId);
        }
    }
}
