// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.DataMigration.Models
{
    // Backward-compat justification: the GA contract exposed OutputErrors as IReadOnlyList, so this customization replaces the generated declaration to preserve the exact API shape.
    public partial class MigrateMISyncCompleteCommandProperties : DataMigrationCommandProperties
    {
        public MigrateMISyncCompleteCommandProperties() : base(DataMigrationCommandType.MigrateSqlServerAzureDbSqlMiComplete)
        {
        }

        internal MigrateMISyncCompleteCommandProperties(DataMigrationCommandType commandType, IReadOnlyList<DataMigrationODataError> errors, DataMigrationCommandState? state, IDictionary<string, BinaryData> additionalBinaryDataProperties, MigrateMISyncCompleteCommandInput input, MigrateMISyncCompleteCommandOutput output) : base(commandType, errors, state, additionalBinaryDataProperties)
        {
            Input = input;
            Output = output;
        }

        internal MigrateMISyncCompleteCommandInput Input { get; set; }

        internal MigrateMISyncCompleteCommandOutput Output { get; }

        public string InputSourceDatabaseName
        {
            get => Input is null ? default : Input.SourceDatabaseName;
            set => Input = new MigrateMISyncCompleteCommandInput(value);
        }

        public IReadOnlyList<DataMigrationReportableException> OutputErrors => Output is null ? default : (IReadOnlyList<DataMigrationReportableException>)Output.Errors;
    }
}
