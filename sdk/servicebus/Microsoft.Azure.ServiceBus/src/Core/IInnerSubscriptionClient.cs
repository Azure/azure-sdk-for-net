// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal interface IInnerSubscriptionClient
    {
        MessageReceiver InnerReceiver { get; }

        int PrefetchCount { get; set; }

        Task OnAddRuleAsync(RuleDescription description);

        Task OnRemoveRuleAsync(string ruleName);

        Task<IList<RuleDescription>> OnGetRulesAsync(int top, int skip);

        Task CloseAsync();
    }
}