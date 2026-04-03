// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class MigrationContent
    {
        /// <summary> Initializes a new instance of <see cref="MigrationContent"/>. </summary>
        /// <param name="sku"> Sku for the migration. </param>
        /// <param name="classicResourceReference"> Resource reference of the classic cdn profile or classic frontdoor that need to be migrated. </param>
        /// <param name="profileName"> Name of the new profile that need to be created. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sku"/>, <paramref name="classicResourceReference"/> or <paramref name="profileName"/> is null. </exception>
        public MigrationContent(CdnSku sku, WritableSubResource classicResourceReference, string profileName)
        {
            Argument.AssertNotNull(sku, nameof(sku));
            Argument.AssertNotNull(classicResourceReference, nameof(classicResourceReference));
            Argument.AssertNotNull(profileName, nameof(profileName));

            Sku = sku;
            ClassicResourceReference = classicResourceReference;
            ProfileName = profileName;
            MigrationWebApplicationFirewallMappings = new ChangeTrackingList<MigrationWebApplicationFirewallMapping>();
        }
    }
}
