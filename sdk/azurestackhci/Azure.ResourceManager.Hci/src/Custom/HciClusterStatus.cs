// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Hci.Models
{
    public readonly partial struct HciClusterStatus
    {
        private const string FailedValue = "Failed";
        private const string InProgressValue = "InProgress";
        private const string SucceededValue = "Succeeded";

        /// <summary> Failed. </summary>
        public static HciClusterStatus Failed { get; } = new HciClusterStatus(FailedValue);
        /// <summary> InProgress. </summary>
        public static HciClusterStatus InProgress { get; } = new HciClusterStatus(InProgressValue);
        /// <summary> Succeeded. </summary>
        public static HciClusterStatus Succeeded { get; } = new HciClusterStatus(SucceededValue);
    }
}
