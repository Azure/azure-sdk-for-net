// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Data.SqlTypes;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    internal static class Constants
    {
        public const string DefaultConnectionStringName = "ServiceBus";
        public const string DefaultConnectionSettingStringName = "AzureWebJobsServiceBus";
        public const string DynamicSku = "Dynamic";
        public const string AzureWebsiteSku = "WEBSITE_SKU";
        public const string TargetBasedScalingEnabled = "TARGET_BASED_SCALING_ENABLED";
        public const string DynamicConcurrencyEnabled = "DYNAMIC_CONCURRENCY_ENABLED";
        public const string TargetServiceBusMetric = "TARGET_SERVICEBUS_METRIC";
        public const int DefaultTargetServiceBusMetric = 16;
        public const string ProcessMessagesActivityName = "ServiceBusListener.ProcessMessages";
        public const string ProcessSessionMessagesActivityName = "ServiceBusListener.ProcessSessionMessages";
    }
}
