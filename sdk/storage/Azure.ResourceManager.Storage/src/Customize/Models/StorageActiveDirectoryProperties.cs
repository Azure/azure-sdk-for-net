// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds constructor overload preserving prior GA required-parameter shape
// and restores DomainGuid property as non-nullable Guid (generated is Guid?).

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Storage.Models
{
    [CodeGenSerialization(nameof(ActiveDirectoryDomainGuid), DeserializationValueHook = nameof(DeserializeNullableGuid))]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeNullableGuid(JsonProperty property, ref Guid? domainGuid)
        {
            var str = property.Value.GetString();
            if (string.IsNullOrWhiteSpace(str) || !Guid.TryParse(str, out var parsed))
            {
                domainGuid = null;
            }
            else
            {
                domainGuid = parsed;
            }
        }
    }
}
