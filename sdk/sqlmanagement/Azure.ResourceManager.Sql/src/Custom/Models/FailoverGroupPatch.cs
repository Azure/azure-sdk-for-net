// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Sql.Models
{
    public partial class FailoverGroupPatch
    {
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

        /// <summary> List of databases in the failover group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release, please use FailoverDatabases instead.", false)]
        public IList<string> Databases { get; }
    }
}
