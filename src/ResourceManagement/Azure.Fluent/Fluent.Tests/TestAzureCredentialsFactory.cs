// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Collections.Generic;

namespace Azure.Tests
{
    public class TestAzureCredentialsFactory : AzureCredentialsFactory
    {
        public override AzureCredentials FromFile(string authFile)
        {
            var config = new Dictionary<string, string>()
            {
                { "authurl", AzureEnvironment.AzureGlobalCloud.AuthenticationEndpoint },
                { "baseurl", AzureEnvironment.AzureGlobalCloud.ResourceManagerEndpoint },
                { "managementuri", AzureEnvironment.AzureGlobalCloud.ManagementEnpoint },
                { "graphurl", AzureEnvironment.AzureGlobalCloud.GraphEndpoint }
            };
#if !NETSTANDARD11
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                config["authurl"] = "https://www.contoso.com";
                config["managementuri"] = "https://www.contoso.com";
                config["baseurl"] = "https://www.contoso.com";
                config["graphurl"] = "https://www.contoso.com";
                config["client"] = "[guid]";
                config["key"] = "[guid]";
                config["tenant"] = Guid.NewGuid().ToString();
                config["subscription"] = Guid.NewGuid().ToString();

                var env = new AzureEnvironment()
                {
                    AuthenticationEndpoint = config["authurl"].Replace("\\", ""),
                    ManagementEnpoint = config["managementuri"].Replace("\\", ""),
                    ResourceManagerEndpoint = config["baseurl"].Replace("\\", ""),
                    GraphEndpoint = config["graphurl"].Replace("\\", "")
                };

                AzureCredentials credentials = new TestAzureCredentials(new ServicePrincipalLoginInformation
                {
                    ClientId  = config["client"],
                    ClientSecret = config["key"]
                }
                , config["tenant"], env);
                credentials.WithDefaultSubscription(config["subscription"]);
                return credentials;
            }
#endif
            return base.FromFile(authFile);
        }
    }
}
