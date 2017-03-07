// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Core
{
    using System.Threading.Tasks;
    using Filters;

    internal interface IInnerSubscriptionClient : IInnerReceiver
    {
        Task OnAddRuleAsync(RuleDescription description);

        Task OnRemoveRuleAsync(string ruleName);
    }
}