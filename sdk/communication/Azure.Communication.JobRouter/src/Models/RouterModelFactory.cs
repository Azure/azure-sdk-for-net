// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    [CodeGenModel("AzureCommunicationServicesModelFactory")]
    public static partial class RouterModelFactory
    {
        /// <summary> Initializes a new instance of CommunicationError. </summary>
        /// <param name="code"> The error code. </param>
        /// <param name="message"> The error message. </param>
        /// <param name="target"> The error target. </param>
        /// <param name="details"> Further details about specific errors that led to this error. </param>
        /// <param name="innerError"> The inner error if any. </param>
        /// <returns> A new <see cref="Models.CommunicationError"/> instance for mocking. </returns>
        internal static CommunicationError CommunicationError(string code = null, string message = null, string target = null, IEnumerable<CommunicationError> details = null, CommunicationError innerError = null)
        {
            details ??= new List<CommunicationError>();

            return new CommunicationError(code, message, target, details?.ToList(), innerError);
        }
    }
}
