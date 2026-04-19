// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.CostManagement.Models
{
    // Backward-compat: restore Complete enum value (renamed to Completed in new spec).
    public partial struct OperationStatusType
    {
        private const string CompleteValue = "Complete";

        /// <summary> Complete. </summary>
        public static OperationStatusType Complete { get; } = new OperationStatusType(CompleteValue);
    }
}
