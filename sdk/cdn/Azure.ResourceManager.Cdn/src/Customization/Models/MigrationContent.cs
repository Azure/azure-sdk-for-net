// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds the old constructor and ClassicResourceReferenceId property to MigrationContent
    // for backward API compatibility with the previous SDK.
    // Reason 1: The old SDK constructor accepted a WritableSubResource-typed classicResourceReference parameter,
    // but after the TypeSpec migration, the parameter type changed. The old constructor signature is preserved here.
    // Reason 2: The old SDK exposed a flattened ClassicResourceReferenceId property (of type ResourceIdentifier).
    // The TypeSpec generator did not preserve this flattened property, so it is manually added here with a WirePath attribute for the JSON path.
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

        /// <summary> Gets or sets Id. </summary>
        [WirePath("classicResourceReference.id")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ClassicResourceReferenceId
        {
            get => ClassicResourceReference?.Id;
        }
    }
}
