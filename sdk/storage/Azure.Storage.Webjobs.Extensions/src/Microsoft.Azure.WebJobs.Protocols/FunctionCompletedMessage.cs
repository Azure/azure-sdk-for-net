// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents a message indicating that a function completed execution.</summary>
    [JsonTypeName("FunctionCompleted")]
#if PUBLICPROTOCOL
    public class FunctionCompletedMessage : FunctionStartedMessage
#else
    internal class FunctionCompletedMessage : FunctionStartedMessage
#endif
    {
        /// <summary>Gets or sets the time the function stopped executing.</summary>
        public DateTimeOffset EndTime { get; set; }

        /// <summary>Gets a value indicating whether the function completed successfully.</summary>
        [JsonIgnore]
        public bool Succeeded
        {
            get { return Failure == null; }
        }

        /// <summary>Gets or sets the details of the function's failure.</summary>
        /// <remarks>If the function succeeded, this value is <see langword="null"/>.</remarks>
        public FunctionFailure Failure { get; set; }

        /// <summary>Gets or sets the parameter logs.</summary>
        public IDictionary<string, ParameterLog> ParameterLogs { get; set; }

        internal override void AddMetadata(IDictionary<string, string> metadata)
        {
            metadata.Add(MessageTypeKeyName, "FunctionCompleted");
            metadata.Add(FunctionInstanceIdKey, FunctionInstanceId.ToString("N"));
        }
    }
}
