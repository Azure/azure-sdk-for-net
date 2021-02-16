// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
#pragma warning disable AZC0012
    public static class Constants
    {
#pragma warning restore AZC0012
        private static JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            // The default value, DateParseHandling.DateTime, drops time zone information from DateTimeOffets.
            // This value appears to work well with both DateTimes (without time zone information) and DateTimeOffsets.
            DateParseHandling = DateParseHandling.DateTimeOffset,
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented
        };

#pragma warning disable AZC0014
        public static JsonSerializerSettings JsonSerializerSettings
        {
            get
            {
                return _serializerSettings;
            }
        }
#pragma warning restore AZC0014

        public const string DefaultConnectionStringName = "ServiceBus";
        public const string DefaultConnectionSettingStringName = "AzureWebJobsServiceBus";
        public const string DynamicSku = "Dynamic";
        public const string AzureWebsiteSku = "WEBSITE_SKU";
    }
}
