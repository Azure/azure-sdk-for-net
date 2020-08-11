// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Az.Auth.Net452.Test
{
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure.Authentication;
    using System;
    using Xunit;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Reflection;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;

    public class UserLogin: AuthNet452TestBase
    {  
        public UserLogin() : base()
        {

        }

        [Fact]
        public void VerifyUserTokenProviderApi()
        {
            Type userProviderType = null;
            Type appProviderType = null;

            Assembly asm = Assembly.LoadFrom(GetProductAssemblyPath());
            var tknProviderTypes = asm.GetTypes().Where<Type>((t) => t.Name.Equals("UserTokenProvider", StringComparison.OrdinalIgnoreCase));
            var appTknProviderTypes = asm.GetTypes().Where<Type>((t) => t.Name.Equals("ApplicationTokenProvider", StringComparison.OrdinalIgnoreCase));


            if (tknProviderTypes.Any<Type>())
            {
                userProviderType = tknProviderTypes.First<Type>();
            }

            if (appTknProviderTypes.Any<Type>())
            {
                appProviderType = appTknProviderTypes.First<Type>();
            }

            var userLoginApis = userProviderType.GetMethods().Where<MethodInfo>((mi) => mi.Name.Contains("Login"));
            var deviceAuthApis = userProviderType.GetMethods().Where<MethodInfo>((mi) => mi.Name.Contains("LoginByDeviceCodeAsync"));
            var interactiveLoginApis = userProviderType.GetMethods().Where<MethodInfo>((mi) => mi.Name.Contains("LoginWithPromptAsync"));
            var appLoginApis = appProviderType.GetMethods().Where<MethodInfo>((mi) => mi.Name.Contains("Login"));

            Assert.Equal(19, userLoginApis.Count<MethodInfo>());
            Assert.Equal(15, interactiveLoginApis.Count<MethodInfo>());
            Assert.Equal(0, deviceAuthApis.Count<MethodInfo>());
            Assert.Equal(20, appLoginApis.Count<MethodInfo>());
        }


        [Theory(Skip = "Interactive tests")]
        [InlineData("AADTenant=<tenantId>;" +
                "HttpRecorderMode=Record;" +
                "Environment=Custom;" +
                "ResourceManagementUri=https://management.microsoftazure.de/;" +
                "ServiceManagementUri=https://management.core.cloudapi.de/;" +
                "GalleryUri=https://gallery.cloudapi.de/;" +
                "GraphUri=https://graph.cloudapi.de/;" +
                "AADAuthUri=https://login.microsoftonline.de/;" +
                "IbizaPortalUri=http://portal.microsoftazure.de/;" +
                "RdfePortalUri=https://management.core.cloudapi.de/;" +
                "GraphTokenAudienceUri=https://graph.cloudapi.de/;" +
                "AADTokenAudienceUri=https://management.core.cloudapi.de/"
            )]
        public void InteractiveUserLogin(string cnnStr)
        {
            LiteralCnnString = cnnStr;
            ServiceClientCredentials svcClientCred = null;
            svcClientCred = UserTokenProvider.LoginWithPromptAsync( this.TenantId, GetADClientSettings(), 
                ActiveDirectoryServiceSettings.AzureGermany, 
                () => { return TaskScheduler.FromCurrentSynchronizationContext(); }).GetAwaiter().GetResult();
            Assert.NotNull(svcClientCred);
        }


        [Theory(Skip = "Interactive tests")]
        [InlineData("AADTenant=<tenantId>;" +
                "UserId=<userId>;" +
                "Password=<pwd>;" +
                "ServicePrincipal=1950a258-227b-4e31-a9cf-717495945fc2;" +
               "HttpRecorderMode=Record;" +
               "Environment=Custom;" +
               "ResourceManagementUri=https://management.microsoftazure.de/;" +
               "ServiceManagementUri=https://management.core.cloudapi.de/;" +
               "GalleryUri=https://gallery.cloudapi.de/;" +
               "GraphUri=https://graph.cloudapi.de/;" +
               "AADAuthUri=https://login.microsoftonline.de/;" +
               "IbizaPortalUri=http://portal.microsoftazure.de/;" +
               "RdfePortalUri=https://management.core.cloudapi.de/;" +
               "GraphTokenAudienceUri=https://graph.cloudapi.de/;" +
               "AADTokenAudienceUri=https://management.core.cloudapi.de/"
           )]
        public void SilentUserLogin(string cnnStr)
        {
            LiteralCnnString = cnnStr;
            ServiceClientCredentials svcClientCred = null;
            svcClientCred = UserTokenProvider.LoginSilentAsync(this.ClientId, this.TenantId, this.UserName, this.Password, ActiveDirectoryServiceSettings.AzureGermany).GetAwaiter().GetResult();
            Assert.NotNull(svcClientCred);
        }

        public ActiveDirectoryClientSettings GetADClientSettings()
        {
            ActiveDirectoryClientSettings adClient = new ActiveDirectoryClientSettings()
            {
                ClientId = this.ClientId,
                ClientRedirectUri = new Uri("urn:ietf:wg:oauth:2.0:oob"),
                PromptBehavior = PromptBehavior.Always
            };

            return adClient;
        }

        private string GetProductAssemblyPath()
        {
            string prodAsmName = "Microsoft.Rest.ClientRuntime.Azure.Authentication.dll";
            string asmPath = Path.Combine(this.TestOutputDir, prodAsmName);

            if (File.Exists(asmPath))
            {
                return asmPath;
            }
            else
                return string.Empty;
        }
    }
}
