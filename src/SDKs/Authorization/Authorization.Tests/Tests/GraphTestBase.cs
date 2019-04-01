// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
using Microsoft.Rest.Azure.OData;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Management.Authorization;

namespace Authorization.Tests
{
	public class TenantAndDomain
	{
		public TenantAndDomain()
		{

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
			                .Split(new[] { "@" }, StringSplitOptions.RemoveEmptyEntries)
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
				context.GetGraphServiceClient<GraphRbacManagementClient>() :
				context.GetGraphServiceClient<GraphRbacManagementClient>(handlers: handler);

			client.TenantID = GetTenantAndDomain().TenantId;
			return client;
		}

		public User CreateUser(MockContext context,string username)
		{
			string upn = username + "@" + GetTenantAndDomain().Domain;

			UserCreateParameters parameter = new UserCreateParameters();
			parameter.UserPrincipalName = upn;
			parameter.DisplayName = username;
			parameter.AccountEnabled = true;
			parameter.MailNickname = username + "test";
			parameter.PasswordProfile = new PasswordProfile();
			parameter.PasswordProfile.ForceChangePasswordNextLogin = false;
			parameter.PasswordProfile.Password = "Test12345";

			return GetGraphClient(context).Users.Create(parameter);
		}

		public void DeleteUser(MockContext context, string upnOrObjectId)
		{
			GetGraphClient(context).Users.Delete(upnOrObjectId);
		}

		public ADGroup CreateGroup(MockContext context,string groupname)
		{
			string mailNickName = groupname + "tester";
			GroupCreateParameters parameters = new GroupCreateParameters();
			parameters.DisplayName = groupname;
			parameters.MailNickname = mailNickName;

			return GetGraphClient(context).Groups.Create(parameters);
		}

		public void DeleteGroup(MockContext context, string objectId)
		{
			GetGraphClient(context).Groups.Delete(objectId);
		}

		public void AddMember(MockContext context, ADGroup group, User user)
		{
			string memberUrl = string.Format("{0}{1}/directoryObjects/{2}",
				GetGraphClient(context).BaseUri.AbsoluteUri, GetGraphClient(context).TenantID, user.ObjectId);
			GetGraphClient(context).Groups.AddMember(group.ObjectId, new GroupAddMemberParameters(memberUrl));
		}
	}
}
