﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The states of a call.
    /// </summary>
    [CodeGenModel("CallState", Usage = new string[] { "input", "output" }, Formats = new string[] { "json" })]
    public readonly partial struct CallState
    {
    }
}
