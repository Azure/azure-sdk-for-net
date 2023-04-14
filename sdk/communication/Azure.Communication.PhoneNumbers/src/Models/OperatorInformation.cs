// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Communication.PhoneNumbers
{
    /// <summary>
    /// Information about a phone number that is controled by and obtained from the operator of the phone number.
    /// </summary>
    public partial class OperatorInformation
    {
        /// <summary>
        /// Creates a new operator information object.
        /// </summary>
        public OperatorInformation() { }

        /// <summary>
        /// The phone number in E.164 format.
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// The type of phone number, which can be used to indicate it's likely capabilities.
        /// </summary>
        public OperatorPhoneType PhoneNumberType { get; set; }
        /// <summary>
        /// Details about the current operator of the phone number.
        /// </summary>
        public PhoneNumberOperator Operator { get; set; }
    }
}
