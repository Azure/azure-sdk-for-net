// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Communication.PhoneNumbers
{
    /// <summary>
    /// Results of a search for Operator Information about given phone numbers.
    /// </summary>
    public partial class OperatorInformationSearchResult
    {
        /// <summary>
        /// Creates a new operator information search result object.
        /// </summary>
        public OperatorInformationSearchResult() { }

        /// <summary>
        /// List of values, each will correspond to one of the phone numbers in the search request.
        /// </summary>
        public List<OperatorInformation> Values { get; set; }
    }
}
