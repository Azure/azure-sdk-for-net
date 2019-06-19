// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace StorSimple1200Series.Tests
{
    using System;

    public static class TestConstants
    {
        public const string DefaultResourceGroupName = "ResourceGroupForSDKTest";
        public const string DefaultManagerName = "hAzureSDKOperations";
        public const string ManagerForAlertsAndDeviceUpdates = "hManagerForSDKTest4";
        public const string ManagerForManagerOperationTests = "hManagerForSDKTest";
        public const string ManagerForDeleteOperation = "ManagerForDeleteOperation";
        public const string DefaultAcrName = "AcrForSDKTest";
        public const string DefaultSacName = "SacForSDKTest";
        public const string DefaultStorageDomainForSDKTestName = "StorageDomainForSDKTest";
        public const string DefaultStorageDomainFileServerNamePrefix = "sd-fs-";
        public const string DefaultStorageDomainIscsiServerNamePrefix = "sd-isci-";
        public const string DefaultStorageAccountEndPoint = "blob.core.windows.net";
        public const string DefaultDeviceName = "DeviceForSDKTest";
        public const string DefaultBackupSchGroupName = "BackupSchGroupForSDKTest";
        public const string DefaultLocalFileShareName = "LocalFileShareForSDKTest";
        public const string DefaultTieredFileShareName = "TieredFileShareForSDKTest";
        public const string DefaultTieredIscsiDiskName = "TieredIscsiDiskForSDKTest";
        public const string DefaultClonedTieredFileShareName = "ClonedTieredFileShareForSDKTest";
        public const string DefaultClonedTieredIscsiDiskName = "ClonedTieredIscsiDiskForSDKTest";
        public const string DefaultChapSettingName = "ChapSettingForSDK";
        public const string DefaultChapSettingNameForDelete = "ChapSettingForSDKForDelete";
        public const string DefaultChapSettingPwd = "ChapSettingPwd1";

        public static readonly DateTime MetricsStartTime = new DateTime(2017, 06, 17, 18, 30, 00, DateTimeKind.Utc);
        public static readonly DateTime MetricsEndTime = new DateTime(2017, 06, 21, 18, 30, 00, DateTimeKind.Utc);
        public static readonly DateTime TimeBeforeBackupRestoreJobStart = new DateTime(2017, 06, 22, 18, 30, 00, DateTimeKind.Utc);
        public static readonly DateTime Schedule1StartTime = new DateTime(2017, 06, 23, 18, 30, 00, DateTimeKind.Utc);
        public static readonly DateTime Schedule2StartTime = new DateTime(2017, 06, 23, 19, 30, 00, DateTimeKind.Utc);
        public static readonly DateTime MinTimeForAlert = new DateTime(2017, 06, 09, 18, 30, 00, DateTimeKind.Utc);
        public static readonly DateTime MaxTimeForAlert = new DateTime(2017, 06, 19, 18, 30, 00, DateTimeKind.Utc);
        public static readonly DateTime TimeBeforeCancelledBackupJobStart = new DateTime(2017, 06, 28, 9, 00, 00, DateTimeKind.Utc);

        public const string DefaultEncryptionKey = "DummyKey890123456789012345678901";
        public const string TestSacAccessKey = "DummyAccessKeyForSDKTest";
        public const string DomainName = "fareast.corp.microsoft.com";
        public const string DomainUser = @"fareast\idcdlslb";
        public const string TestSacLogin = DefaultSacName;
        public const long ProvisionedCapacityInBytesForLocal = (long)50 * 1024 * 1024 * 1024;
        public const long ProvisionedCapacityInBytesForNonLocal = (long)500 * 1024 * 1024 * 1024;
        public const long ProvisionedCapacityInBytesForDisk = (long)512000 * 1024 * 1024;
        public const string ChannelIntegrityKey = "Cz+5r6QNGSbExPUtsBoXEQ==";
        public const string DefaultBackupJobStartTime = "8/15/2018 11:07:23 AM";

        public const string ProviderNamespace = "Microsoft.StorSimple";
        public const string ManagerMetricStartTime = "2018-08-04T18:30:00Z";
        public const string ManagerMetricEndTime = "2018-08-11T18:30:00Z";
        public const string DeviceMetricStartTime = "2018-08-10T18:30:00Z";
        public const string DeviceMetricEndTime = "2018-08-11T18:30:00Z";
        public const string FileServerMetricStartTime = "2018-08-10T18:30:00Z";
        public const string FileServerMetricEndTime = "2018-08-11T18:30:00Z";
        public const string FileShareMetricStartTime = "2018-08-10T18:30:00Z";
        public const string FileShareMetricEndTime = "2018-08-11T18:30:00Z";
        public const string IscsiServerMetricStartTime = "2018-08-10T18:30:00Z";
        public const string IscsiServerMetricEndTime = "2018-08-11T18:30:00Z";
        public const string IscsiDiskMetricStartTime = "2018-08-10T18:30:00Z";
        public const string IscsiDiskMetricEndTime = "2018-08-11T18:30:00Z";
        public const string BackupsCreatedTime = "2018-08-10T17:30:03Z";
        public const string BackupsEndTime = "2018-08-14T17:30:03Z";

    }
}