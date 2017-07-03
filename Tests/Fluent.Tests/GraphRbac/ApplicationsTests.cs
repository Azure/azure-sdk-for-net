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
    public class Applications
    {

        [Fact]
        public void CanCRUDApplication()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                IGraphRbacManager manager = TestHelper.CreateGraphRbacManager();
                String name = SdkContext.RandomResourceName("javasdkapp", 20);

                IActiveDirectoryApplication application = null;
                try
                {
                    application = manager.Applications.Define(name)
                            .WithSignOnUrl("http://easycreate.azure.com/" + name)
                            .DefinePasswordCredential("passwd")
                                .WithPasswordValue("P@ssw0rd")
                                .WithDuration(TimeSpan.FromDays(100))
                                .Attach()
                            .DefineCertificateCredential("cert")
                                .WithAsymmetricX509Certificate()
                                .WithPublicKey(File.ReadAllBytes("Assets/myTest.cer"))
                                .WithDuration(TimeSpan.FromDays(100))
                                .Attach()
                            .Create();
                    Console.WriteLine(application.Id + " - " + application.ApplicationId);
                    Assert.NotNull(application.Id);
                    Assert.NotNull(application.ApplicationId);
                    Assert.Equal(name, application.Name);
                    Assert.Equal(1, application.CertificateCredentials.Count);
                    Assert.Equal(1, application.PasswordCredentials.Count);
                    Assert.Equal(1, application.ReplyUrls.Count);
                    Assert.Equal(1, application.IdentifierUris.Count);
                    Assert.Equal("http://easycreate.azure.com/" + name, application.SignOnUrl.ToString());

                    application.Update()
                            .WithoutCredential("passwd")
                            .Apply();
                    Console.WriteLine(application.Id + " - " + application.ApplicationId);
                    Assert.Equal(0, application.PasswordCredentials.Count);
                }
                finally
                {
                    if (application != null)
                    {
                        manager.Applications.DeleteById(application.Id);
                    }
                }
            }
        }
    }
}