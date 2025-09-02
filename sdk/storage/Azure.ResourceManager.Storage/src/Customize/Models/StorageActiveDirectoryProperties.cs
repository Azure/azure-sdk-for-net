// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    //[CodeGenSerialization(nameof(DomainGuid), DeserializationValueHook = nameof(DeserializeNullableGuid))]
    public partial class StorageActiveDirectoryProperties
    {
        /// <summary> Initializes a new instance of <see cref="StorageActiveDirectoryProperties"/>. </summary>
        /// <param name="domainName"> Specifies the primary domain that the AD DNS server is authoritative for. </param>
        /// <param name="domainGuid"> Specifies the domain GUID. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="domainName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StorageActiveDirectoryProperties(string domainName, Guid domainGuid)
        {
            Argument.AssertNotNull(domainName, nameof(domainName));

            DomainName = domainName;
            DomainGuid = domainGuid;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeNullableGuid(JsonProperty property, ref Guid domainGuid)
        {
            if (string.IsNullOrEmpty(property.Value.GetString()))
            {
                domainGuid = Guid.Empty;
            }
            else
            {
                domainGuid = property.Value.GetGuid();
            }
        }

        /// <summary>
        /// Specifies the domain GUID.
        /// This property is deprecated. Use <see cref="ActiveDirectoryDomainGuid"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("domainGuid")]
        public Guid DomainGuid
        {
            get => ActiveDirectoryDomainGuid ?? Guid.Empty;
            set => ActiveDirectoryDomainGuid = value == Guid.Empty ? null : value;
        }
    }
}
