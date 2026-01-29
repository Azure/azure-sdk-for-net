// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary> The updatable properties of the AutonomousDatabase. </summary>
    public partial class AutonomousDatabaseUpdateProperties
    {
        /// <summary> The list of scheduled operations. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release, please use ScheduledOperationsList instead", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScheduledOperationsTypeUpdate ScheduledOperations
        {
            get
            {
                throw new NotSupportedException("This property is obsolete and not supported, please use ScheduledOperationsList instead");
            }
            set
            {
                throw new NotSupportedException("This property is obsolete and not supported, please use ScheduledOperationsList instead");
            }
        }
    }
}
