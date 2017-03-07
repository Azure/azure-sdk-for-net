// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISenderClient : IClientEntity
    {
        Task SendAsync(Message message);

        Task SendAsync(IList<Message> messageList);

        Task<long> ScheduleMessageAsync(Message message, DateTimeOffset scheduleEnqueueTimeUtc);

        Task CancelScheduledMessageAsync(long sequenceNumber);
    }
}