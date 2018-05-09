// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.AzureStack.Management.Backup.Admin
{
    using Microsoft.Rest;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Microsoft.Rest.Azure;

    public partial class BackupAdminClient: ServiceClient<BackupAdminClient>
    {
        partial void CustomInitialize()
        {
            //Diable parsing the string datetime as DataTiem datatype

            this.DeserializationSettings.DateParseHandling = DateParseHandling.None;
            this.SerializationSettings.DateParseHandling = DateParseHandling.None;
        }
    }
}
