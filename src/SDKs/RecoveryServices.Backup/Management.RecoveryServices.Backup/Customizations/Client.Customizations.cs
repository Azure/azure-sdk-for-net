// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.RecoveryServices.Backup
{
    public partial class RecoveryServicesBackupClient
    {
        partial void CustomInitialize()
        {
            var iso8601TimeSpanConverter = DeserializationSettings.Converters.First(conv => conv is Iso8601TimeSpanConverter);
            if (iso8601TimeSpanConverter != null)
            {
                DeserializationSettings.Converters.Remove(iso8601TimeSpanConverter);
            }
        }
    }
}