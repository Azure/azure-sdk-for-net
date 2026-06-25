// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618 // This compatibility shim intentionally exposes the obsolete legacy wrapper.

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.SecurityInsights.Mocking
{
    /// <summary> A class to add extension methods to <see cref="ArmClient"/>. </summary>
    public partial class MockableSecurityInsightsArmClient : ArmResource
    {
        /// <summary>
        /// Gets an object representing a <see cref="OperationalInsightsWorkspaceSecurityInsightsResource"/> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="OperationalInsightsWorkspaceSecurityInsightsResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual OperationalInsightsWorkspaceSecurityInsightsResource GetOperationalInsightsWorkspaceSecurityInsightsResource(ResourceIdentifier id)
        {
            OperationalInsightsWorkspaceSecurityInsightsResource.ValidateResourceId(id);
            return new OperationalInsightsWorkspaceSecurityInsightsResource(Client, id);
        }
    }
}

#pragma warning restore CS0618