// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.CostManagement.Models
{
    // Backward-compat: The baseline SDK exposed both "Complete" (wire value "Complete") and
    // "Completed" (wire value "Completed") as distinct enum members. The new spec only models
    // "Completed". Both wire values remain valid on the service historically, so we restore the
    // "Complete" member here to preserve ApiCompat and avoid dropping a legitimate wire value
    // that older server responses may still return.
    public partial struct OperationStatusType
    {
        private const string CompleteValue = "Complete";

        /// <summary> Complete. </summary>
        public static OperationStatusType Complete { get; } = new OperationStatusType(CompleteValue);
    }
}
