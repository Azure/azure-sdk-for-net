// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.DataBox.Models
{
    public partial class MitigateJobContent
    {
        // This is used to represent default null for breaking change of CustomerResolutionCode changed from required to optional
        private CustomerResolutionCode? _customerResolutionCode;

        /// <summary> Initializes a new instance of MitigateJobContent. </summary>
        public MitigateJobContent()
        {
            SerialNumberCustomerResolutionMap = new ChangeTrackingDictionary<string, CustomerResolutionCode>();
        }

        /// <summary> Initializes a new instance of MitigateJobContent. </summary>
        /// <param name="customerResolutionCode"> Resolution code for the job. </param>
        public MitigateJobContent(CustomerResolutionCode customerResolutionCode) : this()
        {
            CustomerResolutionCode = customerResolutionCode;
        }

        /// <summary> Resolution code for the job. </summary>
        public CustomerResolutionCode CustomerResolutionCode
        {
            get
            {
                return _customerResolutionCode ?? default;
            }
            private set
            {
                _customerResolutionCode = value;
            }
        }
    }
}
