// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.DataBox.Models
{
    public abstract partial class DataBoxBasicJobDetails
    {
        /// <summary> Initializes a new instance of <see cref="DataBoxBasicJobDetails"/>. </summary>
        /// <param name="contactDetails"> Contact details for notification and shipping. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="contactDetails"/> is null. </exception>
        protected DataBoxBasicJobDetails(DataBoxContactDetails contactDetails)
        {
            JobStages = new ChangeTrackingList<DataBoxJobStage>();
            ContactDetails = contactDetails;
            DataImportDetails = new ChangeTrackingList<DataImportDetails>();
            DataExportDetails = new ChangeTrackingList<DataExportDetails>();
            CopyLogDetails = new ChangeTrackingList<CopyLogDetails>();
            Actions = new ChangeTrackingList<CustomerResolutionCode>();
        }
    }
}
