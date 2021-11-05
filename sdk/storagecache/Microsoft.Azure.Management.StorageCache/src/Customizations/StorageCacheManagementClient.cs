// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
//using Microsoft.Azure.Management.BotService.Customizations;
//..using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Azure.Management.StorageCache;

namespace Microsoft.Azure.Management.StorageCache
{
        using Microsoft.Rest;
        using Microsoft.Rest.Serialization;
        using Models;
        using Newtonsoft.Json;
        using System.Collections;
        using System.Collections.Generic;
        using System.Net;
        using System.Net.Http;

    /// <summary>
    /// A Storage Cache provides scalable caching service for NAS clients,
    /// serving data from either NFSv3 or Blob at-rest storage (referred to as
    /// "Storage Targets"). These operations allow you to manage Caches.
    /// </summary>
    public partial class StorageCacheManagementClient : ServiceClient<StorageCacheManagementClient>, IStorageCacheManagementClient
    {

        partial void CustomInitialize()
        {
            // Override the bot services operations with an augmented bot services operations,
            // which includes operations required to complete the provisioning of the bot
            this.ApiVersion = "2021-03-01";
        }
    }
}
