// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class GeoBackupPolicyData
    {
        /// <summary> The state of the geo backup policy. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GeoBackupPolicyState State
        {
            get => GeoBackupPolicyState.Value;
            set => GeoBackupPolicyState = value;
        }

        /// <summary> Initializes a new instance of <see cref="GeoBackupPolicyData"/>. </summary>
        /// <param name="state"> The state of the geo backup policy. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GeoBackupPolicyData(GeoBackupPolicyState state)
        {
            State = state;
        }
    }
}
