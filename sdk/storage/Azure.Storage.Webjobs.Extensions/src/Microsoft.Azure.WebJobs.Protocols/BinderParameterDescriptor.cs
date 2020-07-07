// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents a parameter bound to an IBinder.</summary>
    [JsonTypeName("IBinder")]
#if PUBLICPROTOCOL
    public class BinderParameterDescriptor : ParameterDescriptor
#else
    internal class BinderParameterDescriptor : ParameterDescriptor
#endif
    {
    }
}
