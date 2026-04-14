// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.CostManagement.Models
{
    /// <summary> Backward-compat: restore Complete enum value. </summary>
    public partial struct OperationStatusType
    {
        private const string CompleteValue = "Complete";

        /// <summary> Complete. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static OperationStatusType Complete { get; } = new OperationStatusType(CompleteValue);
    }
}
