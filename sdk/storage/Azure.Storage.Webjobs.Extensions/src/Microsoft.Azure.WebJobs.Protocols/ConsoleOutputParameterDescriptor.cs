// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.IO;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents a parameter bound to a <see cref="TextWriter"/> for console output.</summary>
    [JsonTypeName("ConsoleOutput")]
#if PUBLICPROTOCOL
    public class ConsoleOutputParameterDescriptor : ParameterDescriptor
#else
    internal class ConsoleOutputParameterDescriptor : ParameterDescriptor
#endif
    {
    }
}
