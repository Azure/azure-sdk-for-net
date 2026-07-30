// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore legacy enum member casing aliases; @@clientName does not affect generated extensible-union value member names.
    public readonly partial struct MachineLearningConnectionCategory
    {
        /// <summary> Gets the AdlsGen2. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningConnectionCategory AdlsGen2 => ADLSGen2;

        /// <summary> Gets the AzureMySqlDB. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningConnectionCategory AzureMySqlDB => AzureMySqlDb;

        /// <summary> Gets the AzurePostgresDB. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningConnectionCategory AzurePostgresDB => AzurePostgresDb;

        /// <summary> Gets the AzureSqlDB. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningConnectionCategory AzureSqlDB => AzureSqlDb;
    }
}
