// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Authorization
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// A user delegation key
    /// </summary>
    [DataContract(Name = nameof(MessagingUserDelegationKey))]
    [XmlRoot("UserDelegationKey", Namespace = "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect")]
    public class MessagingUserDelegationKey
    {
        /// <summary>
        /// The Azure Active Directory object ID in GUID format.
        /// </summary>
        [DataMember(Name = "SignedOid")]
        public string SignedOid { get; set; }

        /// <summary>
        /// The Azure Active Directory tenant ID in GUID format
        /// </summary>
        [DataMember(Name = "SignedTid")]
        public string SignedTid { get; set; }

        /// <summary>
        /// The date-time the key is active
        /// </summary>
        [DataMember(Name = "SignedStart")]
        public string SignedStart { get; set; }

        /// <summary>
        ///  Abbreviation of the Messaging service that accepts the key.
        /// </summary>
        [DataMember(Name = "SignedService")]
        public string SignedService { get; set; }

        /// <summary>
        /// The date-time the key expires
        /// </summary>
        [DataMember(Name = "SignedExpiry")]
        public string SignedExpiry { get; set; }

        /// <summary>
        /// The service version that created the key
        /// </summary>
        [DataMember(Name = "SignedVersion")]
        public string SignedVersion { get; set; }

        /// <summary>
        /// The key as a base64 string
        /// </summary>
        [DataMember(Name = "Value")]
        public string Value { get; set; }

        /// <summary>
        /// Private constructor to force use of static method.
        /// </summary>
        private MessagingUserDelegationKey()
        {
        }
    }
}
