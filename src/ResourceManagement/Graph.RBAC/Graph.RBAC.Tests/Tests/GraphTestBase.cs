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
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Azure.Test.HttpRecorder;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Net;
using Microsoft.Azure.Graph.RBAC.Models;
using System.Threading;

namespace Microsoft.Azure.Graph.RBAC.Tests
{
    public class TenantAndDomain
    {
        public TenantAndDomain()
        {

        }

        public TenantAndDomain(string t, string d)
        {
            TenantId = t;
            Domain = d;
        }
        public string TenantId { get; set; }
        public string Domain { get; set; }
    }

    public class GraphTestBase : TestBase
    {
        public const string TenantIdKey = "TenantId";
        public const string DomainKey = "Domain";

        public TenantAndDomain GetTenantAndDomain()
        {
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
            TenantAndDomain result = new TenantAndDomain();
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                result.TenantId = environment.Tenant;
                result.Domain = environment.UserName
                            .Split(new [] {"@"}, StringSplitOptions.RemoveEmptyEntries)
                            .Last();

                HttpMockServer.Variables[TenantIdKey] = result.TenantId;
                HttpMockServer.Variables[DomainKey] = result.Domain;
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                result.TenantId = HttpMockServer.Variables[TenantIdKey];
                result.Domain = HttpMockServer.Variables[DomainKey];
            }
            return result;
        }

        public GraphRbacManagementClient GetGraphClient(MockContext context, RecordedDelegatingHandler handler = null)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }
            var client = handler == null ?
                context.GetServiceClient<GraphRbacManagementClient>() :
                context.GetServiceClient<GraphRbacManagementClient>(handler);
            client.TenantID = GetTenantAndDomain().TenantId;
            return client;
        }

        public KeyCredential CreateKeyCredential()
        {
            X509Certificate applicationCertificate = new X509Certificate("SampleApplicationCredential.cer");
            KeyCredential cred = new KeyCredential();
            cred.StartDate = DateTime.Now;
            cred.EndDate = DateTime.Now.AddMonths(12);
            cred.KeyId = Guid.NewGuid().ToString();
            cred.Value = Convert.ToBase64String(applicationCertificate.Export(X509ContentType.Cert));
            cred.Type = "AsymmetricX509Cert";
            cred.Usage = "Verify";
            return cred;
        }

        public PasswordCredential CreatePasswordCredential()
        {
            var bytes = new byte[32] { 1, 2 ,3 , 4, 5, 6, 7, 8, 9, 10,
                                        1, 2 ,3 , 4, 5, 6, 7, 8, 9, 10,
                                        1, 2 ,3 , 4, 5, 6, 7, 8, 9, 10,
                                        1, 2 };
            PasswordCredential cred = new PasswordCredential();
            cred.StartDate = DateTime.Now;
            cred.EndDate = DateTime.Now.AddMonths(12);
            cred.KeyId = Guid.NewGuid().ToString();
            cred.Value = Convert.ToBase64String(bytes);
            return cred;
        }

        public Application CreateApplication(MockContext context, PasswordCredential passwordCredential = null, KeyCredential keyCredential = null)
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

            if(keyCredential != null)
            {
                parameters.KeyCredentials = new KeyCredential[] { keyCredential };
            }

            return GetGraphClient(context).Application.Create(parameters);
        }

        public void UpdateApplication(MockContext context, string applicaitonObjectId, PasswordCredential passwordCredential = null, KeyCredential keyCredential = null)
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

            GetGraphClient(context).Application.Update(applicaitonObjectId, parameters);
        }

        public void DeleteApplication(MockContext context, string appObjectId)
        {
            GetGraphClient(context).Application.Delete(appObjectId);
        }

        public void SearchApplication(MockContext context, string appObjectId)
        {
            GetGraphClient(context).Application.Get(appObjectId);
        }

        public ServicePrincipal CreateServicePrincipal(MockContext context, string appId)
        {
            var parameters = new ServicePrincipalCreateParameters
            {
                AccountEnabled = true,
                AppId = appId
            };

            return GetGraphClient(context).ServicePrincipal.Create(parameters);
        }

        public void DeleteServicePrincipal(MockContext context, string spObjectId)
        {
            GetGraphClient(context).ServicePrincipal.Delete(spObjectId);
        }

        public void SearchServicePrincipal(MockContext context, string spObjectId)
        {
            GetGraphClient(context).ServicePrincipal.Get(spObjectId);
        }

        public User CreateUser(MockContext context)
        {
            string username = TestUtilities.GenerateName("aduser");
            string upn = username + "@" + GetTenantAndDomain().Domain;

            UserCreateParameters parameter = new UserCreateParameters();
            parameter.UserPrincipalName = upn;
            parameter.DisplayName = username;
            parameter.AccountEnabled = true;
            parameter.MailNickname = username + "test";
            parameter.PasswordProfile = new UserCreateParametersPasswordProfile();
            parameter.PasswordProfile.ForceChangePasswordNextLogin = false;
            parameter.PasswordProfile.Password = "Test12345";

            return GetGraphClient(context).User.Create(parameter);
        }

        public void DeleteUser(MockContext context, string upnOrObjectId)
        {
            GetGraphClient(context).User.Delete(upnOrObjectId);
        }

        public void SearchUser(MockContext context, string upnOrObjectId)
        {
            GetGraphClient(context).User.Get(upnOrObjectId);
        }

        public ADGroup CreateGroup(MockContext context)
        {
            string groupname = TestUtilities.GenerateName("adgroup");
            string mailNickName = groupname + "tester";
            GroupCreateParameters parameters = new GroupCreateParameters();
            parameters.DisplayName = groupname;
            parameters.MailEnabled = false;
            parameters.SecurityEnabled = true;
            parameters.MailNickname = mailNickName;

            return GetGraphClient(context).Group.Create(parameters);
        }

        public void DeleteGroup(MockContext context, string objectId)
        {
            GetGraphClient(context).Group.Delete(objectId);
        }

        public void SearchGroup(MockContext context, string objectId)
        {
            GetGraphClient(context).Group.Get(objectId);
        }

        public void AddMember(MockContext context, ADGroup group, User user)
        {
            string memberUrl = string.Format("{0}{1}/directoryObjects/{2}",
                GetGraphClient(context).BaseUri.AbsoluteUri, GetGraphClient(context).TenantID, user.ObjectId);
            GetGraphClient(context).Group.AddMember(group.ObjectId, new GroupAddMemberParameters(memberUrl));
        }

        //return all groups the user is a member of (transitive)
        public IEnumerable<string> GetMemberGroups(MockContext context, User user)
        {
            return GetGraphClient(context).User.GetMemberGroups(user.ObjectId, new UserGetMemberGroupsParameters(false));
        }

        public void RemoveMember(MockContext context, ADGroup group, User user)
        {
            GetGraphClient(context).Group.RemoveMember(group.ObjectId, user.ObjectId);
        }
    }
}
