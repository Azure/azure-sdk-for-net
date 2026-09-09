// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Models
{
    [CodeGenSuppress("CanMigrateResult", typeof(string), typeof(string), typeof(bool?), typeof(CanMigrateDefaultSku?), typeof(IEnumerable<MigrationErrorType>))]
    [CodeGenSuppress("MigrateResult", typeof(string), typeof(string), typeof(ResourceIdentifier))]
    public static partial class ArmCdnModelFactory
    {
        // The generator does not restore the GA uppercase Id parameter on these back-compat overloads.

        /// <summary> Initializes a new instance of <see cref="Models.CanMigrateResult"/>. </summary>
        /// <param name="Id">
        /// Resource ID, String.
        ///             Serialized Name: CanMigrateResult.Id
        /// </param>
        /// <param name="canMigrateResultType">
        /// Resource type.
        ///             Serialized Name: CanMigrateResult.type
        /// </param>
        /// <param name="canMigrate">
        /// Flag that says if the profile can be migrated
        ///             Serialized Name: CanMigrateResult.properties.canMigrate
        /// </param>
        /// <param name="defaultSku">
        /// Recommended sku for the migration
        ///             Serialized Name: CanMigrateResult.properties.defaultSku
        /// </param>
        /// <param name="errors"> Serialized Name: CanMigrateResult.properties.errors. </param>
        /// <returns> A new <see cref="Models.CanMigrateResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CanMigrateResult CanMigrateResult(string Id = default, string canMigrateResultType = default, bool? canMigrate = default, CanMigrateDefaultSku? defaultSku = default, IEnumerable<MigrationErrorType> errors = default)
        {
            return new CanMigrateResult(default, canMigrateResultType, canMigrate is null && defaultSku is null && errors is null ? default : new CanMigrateProperties(canMigrate, defaultSku, (errors ?? new ChangeTrackingList<MigrationErrorType>()).ToList(), default), default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MigrateResult"/>. </summary>
        /// <param name="Id">
        /// Resource ID.
        ///             Serialized Name: MigrateResult.Id
        /// </param>
        /// <param name="migrateResultType">
        /// Resource type.
        ///             Serialized Name: MigrateResult.type
        /// </param>
        /// <param name="migratedProfileResourceIdId">
        /// Arm resource Id of the migrated profile
        ///             Serialized Name: MigrateResult.properties.migratedProfileResourceId
        /// </param>
        /// <returns> A new <see cref="Models.MigrateResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MigrateResult MigrateResult(string Id = default, string migrateResultType = default, ResourceIdentifier migratedProfileResourceIdId = default)
        {
            return new MigrateResult(default, migrateResultType, migratedProfileResourceIdId is null ? default : new MigrateResultProperties(new CdnResourceReference(migratedProfileResourceIdId, default), default), default);
        }
    }
}
