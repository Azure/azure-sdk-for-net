// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Security.KeyVault.Certificates
{
    [Flags]
    public enum ActionType : uint
    {
        AutoRenew = 0x0001,
        EmailContacts = 0x0002,
        Other = 0x0004,
    }
}
