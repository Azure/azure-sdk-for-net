// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.ServiceBus;
using System;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Tests.Samples
{
    public static class BindingToOutputParameter
    {
        #region Snippet:ServiceBusBindingToOutputParameter
        [FunctionName("BindingToOutputParameter")]
        public static void Run(
        [TimerTrigger("0 */5 * * * *")] TimerInfo myTimer,
        [ServiceBus("<queue_or_topic_name>", Connection = "<connection_name>")] out ServiceBusMessage message)
        {
            message = new ServiceBusMessage($"C# Timer trigger function executed at: {DateTime.Now}");
        }
        #endregion
    }
}
