// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Newtonsoft.Json;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>
    /// Represents a trigger parameter to an Azure WebJobs SDK function.
    /// </summary>
#if PUBLICPROTOCOL
    public class TriggerParameterDescriptor : ParameterDescriptor
#else
    public class TriggerParameterDescriptor : ParameterDescriptor
#endif
    {
        /// <summary>
        /// Gets a descriptive reason for why a triggered function executed.
        /// This function is called by the framework when logging triggered
        /// function invocations.
        /// </summary>
        /// <param name="arguments">The collection of arguments for the current function invocation.</param>
        /// <returns>The descriptive reason string</returns>
        public virtual string GetTriggerReason(IDictionary<string, string> arguments) 
        { 
            return string.Empty; 
        }
    }
}
