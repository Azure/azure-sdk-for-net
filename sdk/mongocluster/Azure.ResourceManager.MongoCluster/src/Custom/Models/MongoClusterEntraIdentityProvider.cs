// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.MongoCluster;

namespace Azure.ResourceManager.MongoCluster.Models
{
    /// <summary> Defines a Microsoft Entra ID Mongo user. </summary>
    public partial class MongoClusterEntraIdentityProvider : MongoClusterIdentityProvider
    {
        /// <summary> Initializes a new instance of <see cref="MongoClusterEntraIdentityProvider"/>. </summary>
        /// <param name="properties"> The Entra identity properties for the user. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public MongoClusterEntraIdentityProvider(MongoClusterEntraIdentityProviderProperties properties) : base(IdentityProviderType.MicrosoftEntraID)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            Properties = properties;
        }
    }
}
