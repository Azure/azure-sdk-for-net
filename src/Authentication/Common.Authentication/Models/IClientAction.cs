// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Hyak.Common;

namespace Microsoft.Azure.Common.Authentication.Models
{
    public interface IClientAction
    {
        IClientFactory ClientFactory { get; set; }

        void Apply<TClient>(TClient client, AzureSMProfile profile, AzureEnvironment.Endpoint endpoint) where TClient : ServiceClient<TClient>;

        void ApplyArm<TClient>(TClient client, AzureRMProfile profile, AzureEnvironment.Endpoint endpoint) where TClient : Microsoft.Rest.ServiceClient<TClient>;
    }
}
