// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Provides extension methods for the <see cref="FunctionStartedMessage"/> class.</summary>
#if PUBLICPROTOCOL
    public static class FunctionStartedMessageExtensions
#else
    internal static class FunctionStartedMessageExtensions
#endif
    {
        /// <summary>Formats a function's <see cref="ExecutionReason"/> in a display-friendly text format.</summary>
        /// <param name="message">The function whose reason to format.</param>
        /// <returns>A function's <see cref="ExecutionReason"/> in a display-friendly text format.</returns>
        public static string FormatReason(this FunctionStartedMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

#if PUBLICPROTOCOL
            // If the message already contains details use them. This will be the case for
            // messages serialized from the Host to the Dashboard. The host will format the
            // reason before sending
            return message.ReasonDetails;
#else
            if (!string.IsNullOrEmpty(message.ReasonDetails))
            {
                return message.ReasonDetails;
            }

            switch (message.Reason)
            {
                case ExecutionReason.AutomaticTrigger:
                    return message.Function.TriggerParameterDescriptor?.GetTriggerReason(message.Arguments);
                case ExecutionReason.HostCall:
                    return "This function was programmatically called via the host APIs.";
                case ExecutionReason.Dashboard:
                    return message.ParentId.HasValue ? "Replayed from Dashboard." : "Ran from Dashboard.";
                default:
                    return null;
            }
#endif       
        }
    }
}
