// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Tests.Samples
{
    public static class BindingToReturnValue
    {
        #region Snippet:ServiceBusBindingToReturnValue
        [FunctionName("BindingToReturnValue")]
        [return: ServiceBus("<queue_or_topic_name>", Connection = "<connection_name>")]
        public static string BindToReturnValue([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
        {
            // This value would get stored in Service Bus message body.
            // The string would be UTF8 encoded.
            return $"C# Timer trigger function executed at: {DateTime.Now}";
        }
        #endregion
    }
}
