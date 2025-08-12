// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("ResultInformation", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class ResultInformation
    {
        /// <summary> Initializes a new instance of <see cref="ResultInformation"/>. </summary>
        /// <param name="code"> Code of the current result. This can be helpful to Call Automation team to troubleshoot the issue if this result was unexpected. </param>
        /// <param name="subCode"> Subcode of the current result. This can be helpful to Call Automation team to troubleshoot the issue if this result was unexpected. </param>
        /// <param name="message"> Detail message that describes the current result. </param>
        internal ResultInformation(int? code, int? subCode, string message)
        {
            Code = code;
            SubCode = subCode;
            Message = message;
        }
    }
}
