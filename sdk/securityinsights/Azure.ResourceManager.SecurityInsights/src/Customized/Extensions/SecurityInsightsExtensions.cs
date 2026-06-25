// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618 // This compatibility shim intentionally exposes the obsolete legacy wrapper.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.SecurityInsights
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.SecurityInsights. </summary>
    public static partial class SecurityInsightsExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="OperationalInsightsWorkspaceSecurityInsightsResource"/> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="OperationalInsightsWorkspaceSecurityInsightsResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OperationalInsightsWorkspaceSecurityInsightsResource GetOperationalInsightsWorkspaceSecurityInsightsResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));

            return new OperationalInsightsWorkspaceSecurityInsightsResource(client, id);
        }
    }
}

#pragma warning restore CS0618