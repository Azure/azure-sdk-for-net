// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents a parameter bound to a cancellation token.</summary>
    [JsonTypeName("CancellationToken")]
#if PUBLICPROTOCOL
    public class CancellationTokenParameterDescriptor : ParameterDescriptor
#else
    internal class CancellationTokenParameterDescriptor : ParameterDescriptor
#endif
    {
    }
}
