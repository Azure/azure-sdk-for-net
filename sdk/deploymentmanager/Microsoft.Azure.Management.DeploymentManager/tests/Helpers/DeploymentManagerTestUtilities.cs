// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Management.DeploymentManager.Tests
{
    using Microsoft.Azure.Management.Authorization;
    using Microsoft.Azure.Management.DeploymentManager;
    using Microsoft.Azure.Management.ManagedServiceIdentity;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Storage;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.Threading;

    public static class DeploymentManagerTestUtilities
    {
        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return client;
        }

        public static AuthorizationManagementClient GetAuthorizationManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<AuthorizationManagementClient>(handlers: handler);
            return client;
        }

        public static ManagedServiceIdentityClient GetManagedServiceIdentityClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ManagedServiceIdentityClient>(handlers: handler);
            return client;
        }

        public static AzureDeploymentManagerClient GetDeploymentManagerClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<AzureDeploymentManagerClient>(handlers: handler);
            return client;
        }

        public static StorageManagementClient GetStorageManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<StorageManagementClient>(handlers: handler);
            return client;
        }

        public static void Sleep(TimeSpan duration)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                Thread.Sleep(duration);
            }
        }
    }
}
