// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public class WebPubSubAttribute : Attribute
    {
        [ConnectionString]
        public string ConnectionStringSetting { get; set; } = Constants.WebPubSubConnectionStringName;

        [AutoResolve]
        public string Hub { get; set; }
    }
}
