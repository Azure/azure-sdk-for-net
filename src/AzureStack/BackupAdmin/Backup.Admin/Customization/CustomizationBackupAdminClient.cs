// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.AzureStack.Management.Backup.Admin
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Newtonsoft.Json;

    public partial class BackupAdminClient: ServiceClient<BackupAdminClient>, IBackupAdminClient, IAzureClient
    {
        partial void CustomInitialize()
        {
            //Diable parsing the DateTime string as DataTiem datatype

            this.DeserializationSettings.DateParseHandling = DateParseHandling.None;
            this.SerializationSettings.DateParseHandling = DateParseHandling.None;
        }
    }
}
