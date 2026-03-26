// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Represents the identity information of the caller who triggered a change feed event,
    /// including the Microsoft Entra object ID and the Windows security identifier (SID).
    /// </summary>
    public class ShareChangeFeedEventIdentity
    {
        /// <summary>
        /// The Microsoft Entra (Azure AD) object ID of the authenticated caller, if available.
        /// </summary>
        public string EntraObjectId { get; internal set; }

        /// <summary>
        /// The Windows security identifier (SID) of the authenticated caller, if available.
        /// </summary>
        public string SecurityIdentifier { get; internal set; }

        /// <summary>
        /// Initializes a new <see cref="ShareChangeFeedEventIdentity"/> from a deserialized Avro identity dictionary.
        /// </summary>
        /// <param name="record">The dictionary containing identity fields (EntraOID, SID).</param>
        internal ShareChangeFeedEventIdentity(Dictionary<string, object> record)
        {
            if (record.TryGetValue("EntraOID", out object entraOid))
                EntraObjectId = (string)entraOid;
            if (record.TryGetValue("SID", out object sid))
                SecurityIdentifier = (string)sid;
        }

        /// <summary>
        /// Initializes a new <see cref="ShareChangeFeedEventIdentity"/> for mocking purposes.
        /// </summary>
        internal ShareChangeFeedEventIdentity() { }
    }
}
