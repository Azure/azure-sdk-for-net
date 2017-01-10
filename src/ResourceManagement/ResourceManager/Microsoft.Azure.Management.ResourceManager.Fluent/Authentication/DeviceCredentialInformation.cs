// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Azure.Management.Resource.Fluent.Authentication
{
    public class DeviceCredentialInformation
    {
        public string ClientId { get; set; }

#if PORTABLE
        public Func<DeviceCodeResult, bool> DeviceCodeFlowHandler { get; set; }
#endif

    }
}
