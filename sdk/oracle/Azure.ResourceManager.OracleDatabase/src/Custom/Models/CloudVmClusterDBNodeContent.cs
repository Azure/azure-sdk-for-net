// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary> Add/Remove (Virtual Machine) DbNode model. </summary>
    public partial class CloudVmClusterDBNodeContent
    {
        /// <summary> Initializes a new instance of <see cref="CloudVmClusterDBNodeContent"/>. </summary>
        /// <param name="dbServers"> Db servers ocids. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dbServers"/> is null. </exception>
        [Obsolete("This constructor is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CloudVmClusterDBNodeContent(IEnumerable<ResourceIdentifier> dbServers)
        {
            Argument.AssertNotNull(dbServers, nameof(dbServers));

            DBServers = dbServers.ToList();
        }

        /// <summary> Db servers ocids. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ResourceIdentifier> DBServers { get; }
    }
}
