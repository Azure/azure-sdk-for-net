// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.NetworkTraversal
{
    [CodeGenModel(Usage = new[] { "input", "converter" })]
    public partial class CommunicationRelayConfiguration
    {
        /// <summary> The date for which the username and credentials are not longer valid. Will be 48 hours from request time. </summary>
        public DateTimeOffset? ExpiresOn { get; set; }
    }
}
