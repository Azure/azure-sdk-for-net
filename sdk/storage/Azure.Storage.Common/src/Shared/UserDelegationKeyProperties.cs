// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Sas
{
internal struct UserDelegationKeyProperties
    {
        // skoid
        internal string _objectId;

        // sktid
        internal string _tenantId;

        // skt
        internal DateTimeOffset _startsOn;

        // ske
        internal DateTimeOffset _expiresOn;

        // sks
        internal string _service;

        // skv
        internal string _version;
    }
}
