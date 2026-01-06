// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Dell.Storage.Models
{
    public partial class DellFileSystemProperties
    {
        /// <summary> Initializes a new instance of <see cref="DellFileSystemProperties"/>. </summary>
        /// <param name="marketplace"> Marketplace details. </param>
        /// <param name="delegatedSubnetId"> Delegated subnet id for Vnet injection. </param>
        /// <param name="delegatedSubnetCidr"> Domain range for the delegated subnet. </param>
        /// <param name="user"> User Details. </param>
        /// <param name="dellReferenceNumber"> DellReferenceNumber of the resource. </param>
        /// <param name="encryption"> EncryptionProperties of the resource. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="marketplace"/>, <paramref name="delegatedSubnetId"/>, <paramref name="delegatedSubnetCidr"/>, <paramref name="user"/>, <paramref name="dellReferenceNumber"/> or <paramref name="encryption"/> is null. </exception>
        public DellFileSystemProperties(DellFileSystemMarketplaceDetails marketplace, ResourceIdentifier delegatedSubnetId, string delegatedSubnetCidr, DellFileSystemUserDetails user, string dellReferenceNumber, DellFileSystemEncryptionProperties encryption)
        {
            Argument.AssertNotNull(marketplace, nameof(marketplace));
            Argument.AssertNotNull(delegatedSubnetId, nameof(delegatedSubnetId));
            Argument.AssertNotNull(delegatedSubnetCidr, nameof(delegatedSubnetCidr));
            Argument.AssertNotNull(user, nameof(user));
            Argument.AssertNotNull(dellReferenceNumber, nameof(dellReferenceNumber));
            Argument.AssertNotNull(encryption, nameof(encryption));

            Marketplace = marketplace;
            DelegatedSubnetId = delegatedSubnetId;
            DelegatedSubnetCidr = delegatedSubnetCidr;
            User = user;
            DellReferenceNumber = dellReferenceNumber;
            Encryption = encryption;
        }
    }
}
