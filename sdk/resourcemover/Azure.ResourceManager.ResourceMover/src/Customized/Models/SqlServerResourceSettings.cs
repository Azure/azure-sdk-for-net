// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ResourceMover.Models
{
    /// <summary> Defines the SQL Server resource settings. </summary>
    public partial class SqlServerResourceSettings : MoverResourceSettings
    {
        /// <summary> Initializes a new instance of SqlServerResourceSettings. </summary>
        /// <param name="targetResourceName"> Gets or sets the target Resource name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetResourceName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SqlServerResourceSettings(string targetResourceName) : this()
        {
            Argument.AssertNotNull(targetResourceName, nameof(targetResourceName));
            TargetResourceName = targetResourceName;
        }
    }
}
