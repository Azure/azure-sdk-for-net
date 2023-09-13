// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.ResourceMover.Models
{
    /// <summary> Defines the SQL Server resource settings. </summary>
    public partial class SqlServerResourceSettings : MoverResourceSettings
    {
        /// <summary> Initializes a new instance of SqlServerResourceSettings. </summary>
        public SqlServerResourceSettings(string targetResourceName) : base(targetResourceName)
        {
            Argument.AssertNotNull(targetResourceName, nameof(targetResourceName));
            ResourceType = "Microsoft.Sql/servers";
        }
    }
}
