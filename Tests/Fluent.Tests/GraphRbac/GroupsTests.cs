// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.KeyVault.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.KeyVault.Fluent.Models;
using System.Linq;
using Xunit;
using System;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;

namespace Fluent.Tests.Graph.RBAC
{

    public class Groups
    {

        [Fact]
        public void CanCRUDGroup()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                IGraphRbacManager manager = TestHelper.CreateGraphRbacManager();
                var userName = SdkContext.RandomResourceName("user", 16);
                var spName = SdkContext.RandomResourceName("sp", 16);
                var group1Name = SdkContext.RandomResourceName("group", 16);
                var group2Name = SdkContext.RandomResourceName("group", 16);
                IActiveDirectoryUser user = null;
                IServicePrincipal servicePrincipal = null;
                IActiveDirectoryGroup group1 = null;
                IActiveDirectoryGroup group2 = null;
                try
                {
                    user = manager.Users.Define(userName)
                            .WithEmailAlias(userName)
                            .WithPassword("StrongPass!123")
                            .Create();
                    servicePrincipal = manager.ServicePrincipals.Define(spName)
                            .WithNewApplication("https://" + spName)
                            .Create();
                    group1 = manager.Groups.Define(group1Name)
                            .WithEmailAlias(group1Name)
                            .Create();
                    SdkContext.DelayProvider.Delay(15000);
                    group2 = manager.Groups.Define(group2Name)
                            .WithEmailAlias(group2Name)
                            .WithMember(user.Id)
                            .WithMember(servicePrincipal.Id)
                            .WithMember(group1.Id)
                            .Create();

                    Assert.NotNull(group2);
                    Assert.NotNull(group2.Id);
                    var members = group2.ListMembers();
                    Assert.Equal(3, members.Count());
                    var enumerator = members.GetEnumerator();
                    Assert.True(enumerator.MoveNext());
                    Assert.NotNull(enumerator.Current.Id);
                    Assert.True(enumerator.MoveNext());
                    Assert.NotNull(enumerator.Current.Id);
                    Assert.True(enumerator.MoveNext());
                    Assert.NotNull(enumerator.Current.Id);
                    Assert.False(enumerator.MoveNext());
                }
                finally
                {
                    if (servicePrincipal != null)
                    {
                        manager.ServicePrincipals.DeleteById(servicePrincipal.Id);
                    }
                    // cannot delete users or groups from service principal
                    // if (user != null) {
                    //     manager.Users.DeleteById(user.Id);
                    // }
                    // if (group != null) {
                    //     manager.Groups.DeleteById(group.Id);
                    // }
                }
            }
        }
    }
}