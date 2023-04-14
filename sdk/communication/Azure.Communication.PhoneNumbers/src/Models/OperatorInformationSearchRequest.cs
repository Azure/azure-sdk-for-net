// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Communication.PhoneNumbers
{
    /// <summary>
    /// Defines a search request to obtain operator information about phone numbers.
    /// </summary>
    public partial class OperatorInformationSearchRequest
    {
        /// <summary>
        /// Creates a new operator information search request.
        /// </summary>
        public OperatorInformationSearchRequest() { }

        /// <summary>
        /// The list of phone numbers to obtain Operator Information about.
        /// </summary>
        public List<string> PhoneNumbers { get; set; }
    }
}
