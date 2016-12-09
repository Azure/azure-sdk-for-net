// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure compute resource usage info object.
    /// </summary>
    public interface INetworkUsage :
        IWrapper<Models.Usage>
    {
        Models.NetworkUsageUnit Unit { get; }

        long Limit { get; }

        Models.UsageName Name { get; }

        long CurrentValue { get; }
    }
}