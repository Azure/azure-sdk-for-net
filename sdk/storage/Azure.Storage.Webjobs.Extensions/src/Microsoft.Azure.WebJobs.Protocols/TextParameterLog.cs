// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents a function parameter log stored as text.</summary>
    [JsonTypeName("Text")]
#if PUBLICPROTOCOL
    public class TextParameterLog : ParameterLog
#else
    internal class TextParameterLog : ParameterLog
#endif
    {
        /// <summary>Gets or sets the log contents.</summary>
        public string Value { get; set; }
    }
}
