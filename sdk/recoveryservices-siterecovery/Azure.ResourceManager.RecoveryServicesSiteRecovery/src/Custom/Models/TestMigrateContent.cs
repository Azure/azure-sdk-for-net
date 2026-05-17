// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public partial class TestMigrateContent
    {
        /// <summary> Initializes a new instance of <see cref="TestMigrateContent"/>. </summary>
        /// <param name="properties"> Test migrate input properties. </param>
        public TestMigrateContent(TestMigrateProperties properties) : this(properties, additionalBinaryDataProperties: null)
        {
        }
    }
}
