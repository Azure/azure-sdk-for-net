// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents a function parameter log for a runtime binder parameter.</summary>
    [JsonTypeName("IBinder")]
#if PUBLICPROTOCOL
    public class BinderParameterLog : ParameterLog
#else
    internal class BinderParameterLog : ParameterLog
#endif
    {
        /// <summary>Gets or sets the items bound.</summary>
        public IEnumerable<BinderParameterLogItem> Items { get; set; }
    }
}
