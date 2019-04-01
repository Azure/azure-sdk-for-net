// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http;

namespace Microsoft.Azure.Management.RecoveryServices.Backup
{
    public partial class RecoveryServicesBackupClient
    {
        public bool DisableDispose { get; set; } = false;

        public void SetHttpClient(HttpClient client)
        {
            HttpClient = client;
        }

        public new void Dispose()
        {
            if (!DisableDispose)
            {
                base.Dispose();
            }
        }
    }
}