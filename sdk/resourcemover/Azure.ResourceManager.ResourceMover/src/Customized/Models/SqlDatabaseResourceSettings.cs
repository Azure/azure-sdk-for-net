// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.ResourceMover.Models
{
    /// <summary> Defines the Sql Database resource settings. </summary>
    public partial class SqlDatabaseResourceSettings : MoverResourceSettings
    {
        /// <summary> Initializes a new instance of SqlDatabaseResourceSettings. </summary>
        public SqlDatabaseResourceSettings(string targetResourceName) : base(targetResourceName)
        {
            Argument.AssertNotNull(targetResourceName, nameof(targetResourceName));
            Tags = new ChangeTrackingDictionary<string, string>();
            ResourceType = "Microsoft.Sql/servers/databases";
        }
    }
}
