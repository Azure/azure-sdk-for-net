// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.NetworkTraversal
{
    /// <summary>
    /// The user should be able to serialize or deserialize CommunicationIceServer
    /// for better experience.
    /// </summary>
    [CodeGenModel(Usage = new[] { "input", "converter" })]
    public partial class CommunicationIceServer
    {
    }
}
