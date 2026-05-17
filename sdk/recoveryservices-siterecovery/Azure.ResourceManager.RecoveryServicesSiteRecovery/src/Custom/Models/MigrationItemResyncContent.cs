// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public partial class MigrationItemResyncContent
    {
        /// <summary> Initializes a new instance of <see cref="MigrationItemResyncContent"/>. </summary>
        /// <param name="properties"> Resync input properties. </param>
        public MigrationItemResyncContent(MigrationItemResyncProperties properties) : this(properties, additionalBinaryDataProperties: null)
        {
        }
    }
}
