// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public partial class TestMigrateCleanupContent
    {
        /// <summary> Initializes a new instance of <see cref="TestMigrateCleanupContent"/>. </summary>
        /// <param name="properties"> Test migrate cleanup input properties. </param>
        public TestMigrateCleanupContent(TestMigrateCleanupProperties properties) : this(properties, additionalBinaryDataProperties: null)
        {
        }
    }
}
