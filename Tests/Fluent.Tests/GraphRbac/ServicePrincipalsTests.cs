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
                            .WithNewApplication("http://easycreate.azure.com/anotherapp/40")
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
                    Assert.NotNull(resourceManager.ResourceGroups.List());
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