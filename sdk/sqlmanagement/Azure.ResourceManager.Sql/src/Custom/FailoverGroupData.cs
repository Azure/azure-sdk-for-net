// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Sql
{
    public partial class FailoverGroupData
    {
        /// <summary> List of databases in the failover group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> Databases { get; }
    }
}
