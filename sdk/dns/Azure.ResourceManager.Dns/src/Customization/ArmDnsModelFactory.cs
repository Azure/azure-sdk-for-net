// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Dns;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Dns.Models
{
    public static partial class ArmDnsModelFactory
    {
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="resourceType"></param>
        /// <param name="systemData"></param>
        /// <param name="properties"></param>
        /// <param name="eTag"></param>
        /// <returns> A new <see cref="Dns.DnsRecordData"/> instance for mocking. </returns>
        public static DnsRecordData DnsRecordData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, RecordSetProperties properties = default, ETag? eTag = default)
        {
            throw new NotImplementedException();
        }
    }
}
