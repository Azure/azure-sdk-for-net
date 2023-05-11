// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.DataBox.Models
{
    public partial class MitigateJobContent
    {
        // This is used to represent default null for breaking change of CustomerResolutionCode changed from requried to optional
        internal CustomerResolutionCode? _customerResolutionCode;

        /// <summary> Initializes a new instance of MitigateJobContent. </summary>
        public MitigateJobContent()
        {
            SerialNumberCustomerResolutionMap = new ChangeTrackingDictionary<string, CustomerResolutionCode>();
        }

        /// <summary> Initializes a new instance of MitigateJobContent. </summary>
        /// <param name="customerResolutionCode"> Resolution code for the job. </param>
        public MitigateJobContent(CustomerResolutionCode customerResolutionCode) : this()
        {
            _customerResolutionCode = customerResolutionCode;
        }

        /// <summary> Resolution code for the job. </summary>
        public CustomerResolutionCode CustomerResolutionCode => _customerResolutionCode ?? default;
    }
}
