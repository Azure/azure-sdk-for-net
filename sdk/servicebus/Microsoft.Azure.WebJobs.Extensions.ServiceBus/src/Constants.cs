// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    internal static class Constants
    {
        public const string DefaultConnectionStringName = "ServiceBus";
        public const string DefaultConnectionSettingStringName = "AzureWebJobsServiceBus";
        public const string DynamicSku = "Dynamic";
        public const string FlexConsumptionSku = "FlexConsumption";
        public const string AzureWebsiteSku = "WEBSITE_SKU";
        public const string ProcessMessagesActivityName = "ServiceBusListener.ProcessMessages";
        public const string ProcessSessionMessagesActivityName = "ServiceBusListener.ProcessSessionMessages";
    }
}
