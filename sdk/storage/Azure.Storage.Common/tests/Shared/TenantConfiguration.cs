// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Storage.Test
{
    public class TenantConfiguration
    {
        public string TenantName { get; internal set; }
        public string AccountName { get; internal set; }
        public string AccountKey { get; internal set; }
        public string BlobServiceEndpoint { get; internal set; }
        public string FileServiceEndpoint { get; internal set; }
        public string QueueServiceEndpoint { get; internal set; }
        public string TableServiceEndpoint { get; internal set; }
        public string BlobSecurePortOverride { get; internal set; }
        public string FileSecurePortOverride { get; internal set; }
        public string TableSecurePortOverride { get; internal set; }
        public string QueueSecurePortOverride { get; internal set; }
        public string BlobServiceSecondaryEndpoint { get; internal set; }
        public string FileServiceSecondaryEndpoint { get; internal set; }
        public string QueueServiceSecondaryEndpoint { get; internal set; }
        public string TableServiceSecondaryEndpoint { get; internal set; }
        public string ActiveDirectoryApplicationId { get; internal set; }
        public string ActiveDirectoryApplicationSecret { get; internal set; }
        public string ActiveDirectoryTenantId { get; internal set; }
        public string ActiveDirectoryAuthEndpoint { get; internal set; }
        public TenantType TenantType { get; internal set; }
        public string ConnectionString { get; internal set; }
    }
}
