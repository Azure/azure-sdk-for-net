// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    /// <summary>
    /// An immutable client-side representation of an Azure traffic manager profile Azure endpoint.
    /// </summary>
    public interface ITrafficManagerAzureEndpoint  :
        ITrafficManagerEndpoint
    {
        /// <return>The resource id of the target Azure resource.</return>
        string TargetAzureResourceId { get; }

        /// <return>The type of the target Azure resource.</return>
        TargetAzureResourceType TargetResourceType { get; }
    }
}