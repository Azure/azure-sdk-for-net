// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal static class ExtensionConstants
    {
        // WebPubSubOptions can be set by customers.
        public const string WebPubSubConnectionStringName = "WebPubSubConnectionString";
        public const string HubNameStringName = "WebPubSubHub";
        public const string WebPubSubTriggerValidationStringName = "WebPubSubTriggerValidation";

        public class ErrorMessages
        {
            public const string NotSupportedDataType = "Message only supports text, binary, json. Current value is: ";
            public const string NotValidWebPubSubRequest = "Invalid request that missing required fields.";
            public const string SignatureValidationFailed = "Invalid request signature.";
        }
    }
}
