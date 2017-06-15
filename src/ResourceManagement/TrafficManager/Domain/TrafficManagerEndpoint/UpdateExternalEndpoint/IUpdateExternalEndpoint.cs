// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.UpdateExternalEndpoint
{
    using Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.Update;

    /// <summary>
    /// The entirety of an external endpoint update as a part of parent traffic manager profile profile update.
    /// </summary>
    public interface IUpdateExternalEndpoint  :
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.Update.IWithFqdn,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.Update.IWithSourceTrafficRegion,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.Update.IUpdate
    {
    }
}