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
        /// <summary>
        /// Gets the resource id of the target Azure resource.
        /// </summary>
        string TargetAzureResourceId { get; }

        /// <summary>
        /// Gets the type of the target Azure resource.
        /// </summary>
        Microsoft.Azure.Management.Trafficmanager.Fluent.TargetAzureResourceType TargetResourceType { get; }
    }
}