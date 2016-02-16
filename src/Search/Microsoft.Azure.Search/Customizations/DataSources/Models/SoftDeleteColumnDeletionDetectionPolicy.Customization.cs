// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    public partial class SoftDeleteColumnDeletionDetectionPolicy
    {
        /// <summary>
        /// Initializes a new instance of the SoftDeleteColumnDeletionDetectionPolicy class with required arguments. 
        /// </summary>
        /// <param name="softDeleteColumnName">
        /// Specifies the name of the column to use for soft-deletion detection.
        /// </param>
        /// <param name="softDeleteMarkerValue">
        /// Specifies the marker value that indentifies an item as deleted.
        /// </param>
        public SoftDeleteColumnDeletionDetectionPolicy(string softDeleteColumnName, object softDeleteMarkerValue)
        {
            Throw.IfArgumentNull(softDeleteColumnName, "softDeleteColumnName");
            Throw.IfArgumentNull(softDeleteMarkerValue, "softDeleteMarkerValue");

            bool isValidType =
                softDeleteMarkerValue is int || softDeleteMarkerValue is long || softDeleteMarkerValue is byte ||
                softDeleteMarkerValue is short || softDeleteMarkerValue is string || softDeleteMarkerValue is bool;

            Throw.IfArgument(
                !isValidType, 
                "softDeleteMarkerValue", 
                "Soft-delete marker value must be an integer, string, or bool value.");

            this.SoftDeleteColumnName = softDeleteColumnName;
            this.SoftDeleteMarkerValue = softDeleteMarkerValue.ToString();
        }
    }
}
