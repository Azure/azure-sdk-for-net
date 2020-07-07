// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents a parameter bound to binding data.</summary>
    [JsonTypeName("BindingData")]
#if PUBLICPROTOCOL
    public class BindingDataParameterDescriptor : ParameterDescriptor
#else
    internal class BindingDataParameterDescriptor : ParameterDescriptor
#endif
    {
    }
}
