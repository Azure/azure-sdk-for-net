// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // Back-compat shim: the new spec wraps each key's metadata in an AccountKeyMetadata sub-model
    // (PrimaryMasterKey/SecondaryMasterKey/... with GeneratedOn). The GA surface flattened those
    // generation timestamps directly onto DatabaseAccountKeysMetadata. Re-expose them so existing
    // consumers continue to compile and read the same values.
    public partial class DatabaseAccountKeysMetadata
    {
        /// <summary> Generation time in UTC of the Primary Read-Write Key. </summary>
        [WirePath("primaryMasterKey.generationTime")]
        public DateTimeOffset? PrimaryMasterKeyGeneratedOn => PrimaryMasterKey?.GeneratedOn;

        /// <summary> Generation time in UTC of the Secondary Read-Write Key. </summary>
        [WirePath("secondaryMasterKey.generationTime")]
        public DateTimeOffset? SecondaryMasterKeyGeneratedOn => SecondaryMasterKey?.GeneratedOn;

        /// <summary> Generation time in UTC of the Primary Read-Only Key. </summary>
        [WirePath("primaryReadonlyMasterKey.generationTime")]
        public DateTimeOffset? PrimaryReadonlyMasterKeyGeneratedOn => PrimaryReadonlyMasterKey?.GeneratedOn;

        /// <summary> Generation time in UTC of the Secondary Read-Only Key. </summary>
        [WirePath("secondaryReadonlyMasterKey.generationTime")]
        public DateTimeOffset? SecondaryReadonlyMasterKeyGeneratedOn => SecondaryReadonlyMasterKey?.GeneratedOn;
    }
}
