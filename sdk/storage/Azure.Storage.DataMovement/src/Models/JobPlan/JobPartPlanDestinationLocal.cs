// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement.Models.JobPlan
{
    /// <summary>
    /// This matching the JobPartPlanDstLocal of azcopy
    /// </summary>
    internal class JobPartPlanDestinationLocal
    {
        // Once set, the following fields are constants; they should never be modified

        // Specifies whether the timestamp of destination file has to be set to the modified time of source file
        public bool PreserveLastModifiedTime;

        // Says how checksum verification failures should be actioned
        // TODO: Probably use an Enum once feature is implemented
        public byte ChecksumVerificationOption;

        public JobPartPlanDestinationLocal(
            bool preserveLastModifiedTime,
            byte checksumVerificationOption)
        {
            PreserveLastModifiedTime = preserveLastModifiedTime;
            ChecksumVerificationOption = checksumVerificationOption;
        }
    }
}
