// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    public class ShareChangeFeedEventIdentity
    {
        public string EntraObjectId { get; internal set; }
        public string SecurityIdentifier { get; internal set; }

        internal ShareChangeFeedEventIdentity(Dictionary<string, object> record)
        {
            if (record.TryGetValue("EntraOID", out object entraOid))
                EntraObjectId = (string)entraOid;
            if (record.TryGetValue("SID", out object sid))
                SecurityIdentifier = (string)sid;
        }

        internal ShareChangeFeedEventIdentity() { }
    }
}
