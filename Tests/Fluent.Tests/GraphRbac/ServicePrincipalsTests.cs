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
using System.IO;

namespace Fluent.Tests.Graph.RBAC
{

    public class ServicePrincipals
    {

        [Fact]
        public void CanCRUDServicePrincipal()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                IGraphRbacManager manager = TestHelper.CreateGraphRbacManager();
                IServicePrincipal servicePrincipal = null;
                string name = SdkContext.RandomResourceName("javasdksp", 20);
                try
                {
                    servicePrincipal = manager.ServicePrincipals.Define(name)
                            .WithNewApplication("http://easycreate.azure.com/anotherapp/" + name)
                            .DefinePasswordCredential("sppass")
                                .WithPasswordValue("StrongPass!12")
                                .Attach()
                            .Create();
                    Console.WriteLine(servicePrincipal.Id + " - " + string.Join(", ", servicePrincipal.ServicePrincipalNames));
                    Assert.NotNull(servicePrincipal.Id);
                    Assert.NotNull(servicePrincipal.ApplicationId);
                    Assert.Equal(2, servicePrincipal.ServicePrincipalNames.Count);
                    Assert.Equal(1, servicePrincipal.PasswordCredentials.Count);
                    Assert.Equal(0, servicePrincipal.CertificateCredentials.Count);

                    // Get
                    servicePrincipal = manager.ServicePrincipals.GetByName(servicePrincipal.ApplicationId);
                    Assert.NotNull(servicePrincipal);
                    Assert.NotNull(servicePrincipal.ApplicationId);
                    Assert.Equal(2, servicePrincipal.ServicePrincipalNames.Count);
                    Assert.Equal(1, servicePrincipal.PasswordCredentials.Count);
                    Assert.Equal(0, servicePrincipal.CertificateCredentials.Count);

                    // Update
                    servicePrincipal.Update()
                            .WithoutCredential("sppass")
                            .DefineCertificateCredential("spcert")
                                .WithAsymmetricX509Certificate()
                                .WithPublicKey(File.ReadAllBytes("Assets/myTest.cer"))
                                .WithDuration(TimeSpan.FromDays(1))
                                .Attach()
                            .Apply();
                    Assert.NotNull(servicePrincipal);
                    Assert.NotNull(servicePrincipal.ApplicationId);
                    Assert.Equal(2, servicePrincipal.ServicePrincipalNames.Count);
                    Assert.Equal(0, servicePrincipal.PasswordCredentials.Count);
                    Assert.Equal(1, servicePrincipal.CertificateCredentials.Count);
                }
                finally
                {
                    if (servicePrincipal != null)
                    {
                        manager.ServicePrincipals.DeleteById(servicePrincipal.Id);
                        manager.Applications.DeleteById(manager.Applications.GetByName(servicePrincipal.ApplicationId).Id);
                    }
                }
            }
        }

        [Fact(Skip = "Do not record - Can contain sensitive auth info")]
        public void CanCRUDServicePrincipalWithRole()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                IGraphRbacManager manager = TestHelper.CreateGraphRbacManager();
                IServicePrincipal servicePrincipal = null;
                string subscriptionId = TestHelper.CreateResourceManager().SubscriptionId;
                string authFile = "mytest.azureauth";
                string name = SdkContext.RandomResourceName("javasdksp", 20);
                string rgName = SdkContext.RandomResourceName("rg", 20);
                try
                {
                    servicePrincipal = manager.ServicePrincipals.Define(name)
                            .WithNewApplication("http://easycreate.azure.com/" + name)
                            .DefinePasswordCredential("sppass")
                                .WithPasswordValue("StrongPass!12")
                                .Attach()
                            .DefineCertificateCredential("spcert")
                                .WithAsymmetricX509Certificate()
                                .WithPublicKey(File.ReadAllBytes("Assets/myTest.cer"))
                                .WithDuration(TimeSpan.FromDays(100))
                                .WithAuthFileToExport(new StreamWriter(new FileStream(authFile, FileMode.OpenOrCreate)))
                                .WithPrivateKeyFile("Assets/myTest._pfx")
                                .WithPrivateKeyPassword("Abc123")
                                .Attach()
                            .WithNewRoleInSubscription(BuiltInRole.Contributor, subscriptionId)
                            .Create();
                    Console.WriteLine(servicePrincipal.Id + " - " + string.Join(", ", servicePrincipal.ServicePrincipalNames));
                    Assert.NotNull(servicePrincipal.Id);
                    Assert.NotNull(servicePrincipal.ApplicationId);
                    Assert.Equal(2, servicePrincipal.ServicePrincipalNames.Count);
                    Assert.Equal(1, servicePrincipal.PasswordCredentials.Count);
                    Assert.Equal(1, servicePrincipal.CertificateCredentials.Count);

                    SdkContext.DelayProvider.Delay(10000);
                    IResourceManager resourceManager = Microsoft.Azure.Management.ResourceManager.Fluent.ResourceManager.Authenticate(
                        new AzureCredentialsFactory().FromFile(authFile)).WithSubscription(subscriptionId);
                    var group = resourceManager.ResourceGroups.Define(rgName).WithRegion(Region.USWest).Create();

                    // Update
                    IRoleAssignment ra = servicePrincipal.RoleAssignments.First();
                    servicePrincipal.Update()
                            .WithoutRole(ra)
                            .WithNewRoleInResourceGroup(BuiltInRole.Contributor, group)
                            .Apply();

                    SdkContext.DelayProvider.Delay(120000);
                    Assert.NotNull(resourceManager.ResourceGroups.GetByName(group.Name));
                    try
                    {
                        resourceManager.ResourceGroups.Define(rgName + "2")
                                .WithRegion(Region.USWest).Create();
                    }
                    catch (Exception)
                    {
                        // expected
                    }
                }
                finally
                {
                    if (servicePrincipal != null)
                    {
                        manager.ServicePrincipals.DeleteById(servicePrincipal.Id);
                        manager.Applications.DeleteById(manager.Applications.GetByName(servicePrincipal.ApplicationId).Id);
                    }
                }
            }
        }
    }
}