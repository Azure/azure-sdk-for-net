// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Sql
{
    public partial class FailoverGroupData
    {
        /// <summary> List of databases in the failover group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        public IList<string> Databases { get; }
    }
}
