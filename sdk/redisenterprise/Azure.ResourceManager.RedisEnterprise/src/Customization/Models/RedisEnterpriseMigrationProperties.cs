// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.RedisEnterprise.Models
{
    public partial class RedisEnterpriseMigrationProperties
    {
        /// <summary> The timestamp until which a successful migration remains eligible to be undone (rolled back) to the source cache. This property is only returned while the migration is in the Succeeded state, and is calculated from the time the migration succeeded plus the rollback window. After this time the source cache is released and the migration can no longer be undone. </summary>
        [CodeGenMember("RollbackEligibleUntil")]
        public DateTimeOffset? RollbackEligibilityExpiresOn { get; }
    }
}
