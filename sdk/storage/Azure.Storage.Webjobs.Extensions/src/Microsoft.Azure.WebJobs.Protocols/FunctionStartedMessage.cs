// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents a message indicating that a function started executing.</summary>
    [JsonTypeName("FunctionStarted")]
#if PUBLICPROTOCOL
    public class FunctionStartedMessage : HostOutputMessage
#else
    internal class FunctionStartedMessage : HostOutputMessage
#endif
    {
        /// <summary>The name of the key used to store the function instance ID in metadata.</summary>
        protected const string FunctionInstanceIdKey = "FunctionInstanceId";

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public FunctionStartedMessage()
        {
        }

        /// <summary>Gets or sets the function instance ID.</summary>
        public Guid FunctionInstanceId { get; set; }

        /// <summary>Gets or sets the function executing.</summary>
        public FunctionDescriptor Function { get; set; }

        /// <summary>Gets or sets the function's argument values.</summary>
        public IDictionary<string, string> Arguments { get; set; }

        /// <summary>Gets or sets the ID of the ancestor function instance.</summary>
        public Guid? ParentId { get; set; }

        /// <summary>Gets or sets the details of the trigger</summary>
        public IDictionary<string, string> TriggerDetails { get; set; }

        /// <summary>Gets or sets the reason the function executed.</summary>
        public ExecutionReason Reason { get; set; }

        /// <summary>Gets or sets the detailed reason the function executed.</summary>
        public string ReasonDetails { get; set; }

        /// <summary>Gets or sets the time the function started executing.</summary>
        public DateTimeOffset StartTime { get; set; }

        /// <summary>Gets or sets the path of the blob containing console output from the function.</summary>
        public LocalBlobDescriptor OutputBlob { get; set; }

        /// <summary>Gets or sets the path of the blob containing per-parameter logging data.</summary>
        public LocalBlobDescriptor ParameterLogBlob { get; set; }

        internal override void AddMetadata(IDictionary<string, string> metadata)
        {
            metadata.Add(MessageTypeKeyName, "FunctionStarted");
            metadata.Add(FunctionInstanceIdKey, FunctionInstanceId.ToString("N"));
        }
    }
}
