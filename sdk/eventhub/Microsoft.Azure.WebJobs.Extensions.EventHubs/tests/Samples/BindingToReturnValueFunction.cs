// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.EventHubs.Tests.Samples
{
    public static class BindingToReturnValueFunction
    {
        #region Snippet:BindingToReturnValue
        [FunctionName("BindingToReturnValue")]
        [return: EventHub("<event_hub_name>", Connection = "<connection_name>")]
        public static string Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
        {
            // This value would get stored in EventHub event body.
            // The string would be UTF8 encoded
            return $"C# Timer trigger function executed at: {DateTime.Now}";
        }
        #endregion
    }
}