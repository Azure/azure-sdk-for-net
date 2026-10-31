// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class NetworkSecurityPerimeterLinkReferenceData
    {
        // Preserve the 1.15.0 setter signature; the current service model only supplies this value in responses.
        /// <summary> Gets the status of the link. </summary>
        /// <remarks> The setter is retained for compatibility with version 1.15.0. Assignments have no effect because the service now treats this property as read-only. </remarks>
        public NetworkSecurityPerimeterLinkStatus? Status
        {
            get => Properties is null ? default : Properties.Status;
            set
            {
                // The current service model does not accept a status value in requests.
            }
        }
    }
}
