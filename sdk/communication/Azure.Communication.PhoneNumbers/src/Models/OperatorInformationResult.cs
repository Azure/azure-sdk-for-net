// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.PhoneNumbers
{
    [CodeGenModel("OperatorInformationResult")]
    public partial class OperatorInformationResult
    {
        /// <summary>
        /// Results of a search.
        /// This array will have one entry per requested phone number which will contain the relevant operator information.
        /// </summary>
        [CodeGenMember("Values")]
        public IReadOnlyList<OperatorInformation> Results { get; }
    }
}
