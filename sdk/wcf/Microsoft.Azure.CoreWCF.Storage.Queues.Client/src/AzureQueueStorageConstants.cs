// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel.Channels;

namespace Azure.Storage.WCF.Channels
{
    /// <summary>
    /// Collection of constants used by the AzureQueueStorage Channel classes
    /// </summary>
    internal static class AzureQueueStorageConstants
    {
        internal const string EventLogSourceName = "Microsoft.ServiceModel.AQS";
        internal const string Scheme = "net.aqs";
        private static MessageEncoderFactory s_messageEncoderFactory;
        static AzureQueueStorageConstants()
        {
            s_messageEncoderFactory = new TextMessageEncodingBindingElement().CreateMessageEncoderFactory();
        }

        // ensure our advertised MessageVersion matches the version we're
        // using to serialize/deserialize data to/from the wire
        internal static MessageVersion MessageVersion
        {
            get
            {
                return s_messageEncoderFactory.MessageVersion;
            }
        }

        internal static MessageEncoderFactory DefaultMessageEncoderFactory
       {
            get
            {
                return s_messageEncoderFactory;
            }
        }
    }
}
