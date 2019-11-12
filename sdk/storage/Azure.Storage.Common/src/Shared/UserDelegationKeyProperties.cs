// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#if CommonSDK
namespace Azure.Storage.Sas.Shared.Common
#else
namespace Azure.Storage.Sas.Shared
#endif
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
