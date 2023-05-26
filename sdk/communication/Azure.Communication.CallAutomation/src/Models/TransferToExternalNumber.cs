// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// TranferToExternalNumber
    /// </summary>
    [CodeGenModel("TransferToExternalNumber", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class TransferToExternalNumber
    {
        /// <summary>
        /// Type
        /// </summary>
        [CodeGenMember("Type")]
        public string Type {get; set;}
        /// <summary>
        /// TransferDestination
        /// </summary>
        [CodeGenMember("TransferDestination")]
        public string TransferDestination { get; set; }
    }
}
