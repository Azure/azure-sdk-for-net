// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Preserves the previous model factory overload for long-term-retention backup content.
    // Suppresses generated factory methods that would expose internal implementation types or duplicate existing custom API.
    [CodeGenSuppress("PostgreSqlFlexibleServerLtrBackupContent", typeof(string), typeof(IEnumerable<string>))]
    [CodeGenSuppress("PostgreSqlFlexibleServerNameAvailabilityResult", typeof(bool?), typeof(PostgreSqlFlexibleServerNameUnavailableReason?), typeof(string), typeof(string), typeof(ResourceType?))]
    [CodeGenSuppress("PostgreSqlFlexibleServerNameAvailabilityResponse", typeof(bool?), typeof(PostgreSqlFlexibleServerNameUnavailableReason?), typeof(string))]
    public static partial class ArmPostgreSqlModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupContent"/>. </summary>
        /// <param name="backupSettings"> Backup Settings. </param>
        /// <param name="targetDetailsSasUriList"> List of SAS uri of storage containers where backup data is to be streamed/copied. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupContent"/> instance for mocking. </returns>
        public static PostgreSqlFlexibleServerLtrBackupContent PostgreSqlFlexibleServerLtrBackupContent(PostgreSqlFlexibleServerBackupSettings backupSettings = null, IEnumerable<string> targetDetailsSasUriList = null)
        {
            PostgreSqlFlexibleServerBackupStoreDetails targetDetails = targetDetailsSasUriList is null
                ? null
                : PostgreSqlFlexibleServerBackupStoreDetails(targetDetailsSasUriList);
            return new PostgreSqlFlexibleServerLtrBackupContent(backupSettings, additionalBinaryDataProperties: null, targetDetails);
        }
    }
}
