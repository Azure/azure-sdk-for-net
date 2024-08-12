// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class FailoverGroupData
    {
        /// <summary> List of databases in the failover group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        public IList<string> Databases { get; }

        /// <summary> Failover policy of the read-only endpoint for the failover group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ReadOnlyEndpointFailoverPolicy? ReadOnlyEndpointFailoverPolicy
        {
            get => ReadOnlyEndpoint is null ? default : ReadOnlyEndpoint.FailoverPolicy;
            set
            {
                if (ReadOnlyEndpoint is null)
                    ReadOnlyEndpoint = new FailoverGroupReadOnlyEndpoint();
                ReadOnlyEndpoint.FailoverPolicy = value;
            }
        }
    }
}
