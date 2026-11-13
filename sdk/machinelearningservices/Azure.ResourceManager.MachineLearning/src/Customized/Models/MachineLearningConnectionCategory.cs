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
        public static MachineLearningConnectionCategory AzureMySqlDB { get; } = new MachineLearningConnectionCategory("AzureMySqlDb");

        /// <summary> Gets the AzurePostgresDB. </summary>
        public static MachineLearningConnectionCategory AzurePostgresDB { get; } = new MachineLearningConnectionCategory("AzurePostgresDb");

        /// <summary> Gets the AzureSqlDB. </summary>
        public static MachineLearningConnectionCategory AzureSqlDB { get; } = new MachineLearningConnectionCategory("AzureSqlDb");

        /// <summary> Gets the AzureMySqlDb. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningConnectionCategory AzureMySqlDb => AzureMySqlDB;

        /// <summary> Gets the AzurePostgresDb. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningConnectionCategory AzurePostgresDb => AzurePostgresDB;

        /// <summary> Gets the AzureSqlDb. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MachineLearningConnectionCategory AzureSqlDb => AzureSqlDB;
    }
}
