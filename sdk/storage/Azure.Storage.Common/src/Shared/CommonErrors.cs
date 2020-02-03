// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage
{
    internal class CommonErrors
    {
        public static InvalidOperationException AccountSasMissingData()
            => new InvalidOperationException($"Account SAS is missing at least one of these: ExpiryTime, Permissions, Service, or ResourceType");
    }
}