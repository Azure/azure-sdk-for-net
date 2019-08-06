// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace ContainerRegistry.Tests
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using global::ContainerRegistry.Tests;
    using Microsoft.Azure.Management.ContainerRegistry;
    using Microsoft.Rest;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Azure.ContainerRegistry;
    using System.Threading;
    using System.Net.Http;

    public static class ACRTestUtil
    {
        private static readonly string _testResourceGroup = "ereyTest";

        public static readonly string ProdRepository = "prod/bash";
        public static readonly string TestRepository = "test/bash";

        public static readonly string ManagedTestRegistry = "azuresdkunittest";
        public static readonly string ManagedTestRegistryFullName = "azuresdkunittest.azurecr.io";
        public static readonly string ManagedTestRegistryForDeleting = "managedtestregistryfordel";

        public static readonly string ClassicTestRegistry = "classictestregistry";
        public static readonly string ClassicTestRegistryNameFullName = "classictestregistry.azurecr.io";
        public static readonly string ClassicTestRegistryForDeleting = "classictestregistryfordel";
        public static readonly string AadAccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6InU0T2ZORlBId0VCb3NIanRyYXVPYlY4NExuWSIsImtpZCI6InU0T2ZORlBId0VCb3NIanRyYXVPYlY4NExuWSJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuY29yZS53aW5kb3dzLm5ldC8iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC83MmY5ODhiZi04NmYxLTQxYWYtOTFhYi0yZDdjZDAxMWRiNDcvIiwiaWF0IjoxNTY1MTE4NTEzLCJuYmYiOjE1NjUxMTg1MTMsImV4cCI6MTU2NTEyMjQxMywiX2NsYWltX25hbWVzIjp7Imdyb3VwcyI6InNyYzEifSwiX2NsYWltX3NvdXJjZXMiOnsic3JjMSI6eyJlbmRwb2ludCI6Imh0dHBzOi8vZ3JhcGgud2luZG93cy5uZXQvNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3L3VzZXJzLzU3ZmEyMGQwLWNhODItNGY4Ni05ZGE2LWQ3YjBkZWM4YmM4Ni9nZXRNZW1iZXJPYmplY3RzIn19LCJhY3IiOiIxIiwiYWlvIjoiQVVRQXUvOE1BQUFBdCtNVmZHcDZkUGFmWUE5TlB1WUlGK1NqZ1g5cm4xWGVqbzQxbFY1YmxPMWM0dGMvYjcxL1RjU2dTK2RVZk9xOEhmVURFaUZVNUkrbVpuNFVidklLeGc9PSIsImFtciI6WyJyc2EiLCJtZmEiXSwiYXBwaWQiOiIwNGIwNzc5NS04ZGRiLTQ2MWEtYmJlZS0wMmY5ZTFiZjdiNDYiLCJhcHBpZGFjciI6IjAiLCJkZXZpY2VpZCI6IjVmY2ZjZWRlLTI1NGYtNDQ4Yy05MWI2LWUyMjQ5MjZlNDNlYSIsImZhbWlseV9uYW1lIjoiUmV5IExvbmRvbm8iLCJnaXZlbl9uYW1lIjoiRXN0ZWJhbiIsImlwYWRkciI6IjEzMS4xMDcuMTc0LjE1MyIsIm5hbWUiOiJFc3RlYmFuIFJleSBMb25kb25vIiwib2lkIjoiNTdmYTIwZDAtY2E4Mi00Zjg2LTlkYTYtZDdiMGRlYzhiYzg2Iiwib25wcmVtX3NpZCI6IlMtMS01LTIxLTIxMjc1MjExODQtMTYwNDAxMjkyMC0xODg3OTI3NTI3LTM2MDA2NDYzIiwicHVpZCI6IjEwMDMyMDAwNDk3N0Q1NTQiLCJzY3AiOiJ1c2VyX2ltcGVyc29uYXRpb24iLCJzdWIiOiJPU0NZSl80WXhkNUx1bUlaUDhJc2Ridjl3cmhsVnV6Tk1qRkk5cWtMejlnIiwidGlkIjoiNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3IiwidW5pcXVlX25hbWUiOiJ0LWVzcmVAbWljcm9zb2Z0LmNvbSIsInVwbiI6InQtZXNyZUBtaWNyb3NvZnQuY29tIiwidXRpIjoiNjBvejJKTzRYRWFTYUxwWHBhQWRBQSIsInZlciI6IjEuMCJ9.VuczTTez-Ad0qHvikaUxBIpbtS8dZbnR9wBSTaftoQ9AqmphoOyzpazV74eQqbZB5zsGsxRqIiaG-2V2MsojBNZHaVsYABDz4gF2reOWUgDRAfVqKDFKio3VVEkE-G11aDaMWK-7wxto0Dqn1JH5qCn6H-JAMWt579BQ8hnr6_HbEwRuAYbX2Sr0X5t51jH5EtWZwiGo5jNM-Jce_3Dv4klSLc-6rJ8558SPlfW97E72008HYLrKXHnbQ6LaD9BgTN0ZkO8KXr5U7U3NJGxAQd9AmcDQ9fzFu76bczYIE8nxmVkUD8igwNL-Oi2-bzlvmZt5jK8jFlOxJFmzTbH4gw";
        public static readonly string Scope = "registry:catalog:*";

        private class TokenCredentials : ServiceClientCredentials
        {
            /*To be used for exchanging AAD Tokens for ACR Tokens*/
            public TokenCredentials() {}
            public override async Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                await base.ProcessHttpRequestAsync(request, cancellationToken);
            }
        }

        public static async Task<AzureContainerRegistryClient> GetACRClientAsync(MockContext context, string registryName)
        {
            var registryManagementClient = context.GetServiceClient<ContainerRegistryManagementClient>(handlers: CreateNewRecordedDelegatingHandler());
            var registry = await registryManagementClient.Registries.GetAsync(_testResourceGroup, registryName);
            var registryCredentials = await registryManagementClient.Registries.ListCredentialsAsync(_testResourceGroup, registryName);
            string username = registryCredentials.Username;
            string password = registryCredentials.Passwords[0].Value;
            AcrClientCredentials credential = new AcrClientCredentials(AcrClientCredentials.LoginMode.Basic, registry.LoginServer, username, password);
            var acrClient = context.GetServiceClientWithCredentials<AzureContainerRegistryClient>(credential, CreateNewRecordedDelegatingHandler());
            acrClient.LoginUri = "https://" + registry.LoginServer;

            return acrClient;
        }

        public static ContainerRegistryManagementClient GetACRManagementClient(MockContext context, string registryName)
        {
            var registryManagementClient = context.GetServiceClient<ContainerRegistryManagementClient>(handlers: CreateNewRecordedDelegatingHandler());
            return registryManagementClient;
        }

        private static RecordedDelegatingHandler CreateNewRecordedDelegatingHandler()
        {
            return new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };
        }

    }
}
