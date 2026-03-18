// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    /// <summary> SqlDataDirectory info. </summary>
    public partial class SqlDataDirectory
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="SqlDataDirectory"/>. </summary>
        internal SqlDataDirectory()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SqlDataDirectory"/>. </summary>
        /// <param name="type"> Type of data directory mapping. </param>
        /// <param name="path"> File path. </param>
        /// <param name="logicalName"> Logical name of the file. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal SqlDataDirectory(SqlDataDirectoryType? @type, string path, string logicalName, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Type = @type;
            Path = path;
            LogicalName = logicalName;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Type of data directory mapping. </summary>
        public SqlDataDirectoryType? Type { get; }

        /// <summary> File path. </summary>
        public string Path { get; }

        /// <summary> Logical name of the file. </summary>
        public string LogicalName { get; }
    }
}
