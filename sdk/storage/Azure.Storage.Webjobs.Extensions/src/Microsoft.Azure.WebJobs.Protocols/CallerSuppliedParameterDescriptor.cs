// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents a parameter bound to a caller-supplied value.</summary>
    [JsonTypeName("CallerSupplied")]
#if PUBLICPROTOCOL
    public class CallerSuppliedParameterDescriptor : ParameterDescriptor
#else
    internal class CallerSuppliedParameterDescriptor : ParameterDescriptor
#endif
    {
    }
}
