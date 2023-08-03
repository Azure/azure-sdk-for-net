// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The possible Dtmf Tones.
    /// </summary>
    [CodeGenModel("Choice", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class RecognitionChoice
    {
    }
}
