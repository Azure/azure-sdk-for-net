// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents a message that reports the status of a function invocation.</summary>
    [JsonTypeName("FunctionStatus")]
#if PUBLICPROTOCOL
    public class FunctionStatusMessage
#else
    internal class FunctionStatusMessage
#endif
    {
        /// <summary>Gets or sets the ID of the function.</summary>
        public string FunctionId { get; set; }

        /// <summary>Gets or sets the function instance ID.</summary>
        public Guid FunctionInstanceId { get; set; }

        /// <summary>Gets or sets the status of the function.</summary>
        public string Status { get; set; }

        /// <summary>Gets or sets the time the function started executing.</summary>
        public DateTimeOffset StartTime { get; set; }

        /// <summary>Gets or sets the time the function execution completed.</summary>
        public DateTimeOffset EndTime { get; set; }

        /// <summary>Gets or sets the details of the function's failure.</summary>
        /// <remarks>If the function succeeded, this value is <see langword="null"/>.</remarks>
        public FunctionFailure Failure { get; set; }

        /// <summary>Gets or sets the path of the blob containing console output from the function.</summary>
        public LocalBlobDescriptor OutputBlob { get; set; }

        /// <summary>Gets or sets the path of the blob containing per-parameter logging data.</summary>
        public LocalBlobDescriptor ParameterLogBlob { get; set; }
    }
}
