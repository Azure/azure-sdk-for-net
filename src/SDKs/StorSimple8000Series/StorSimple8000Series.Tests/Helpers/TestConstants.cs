using System;

namespace StorSimple8000Series.Tests
{
    public static class TestConstants
    {
        public const string DefaultResourceGroupName = "ResourceGroupForSDKTest";
        public const string DefaultManagerName = "ManagerForSDKTest1";
        public const string ManagerForManagerOperationTests = "ManagerForSDKTest2";
        public const string DefaultVirtualNetworkName = "VNForSdkTest";
        public const string DefaultSubnetName = "Default";
        public const string DefaultStorageAccountCredential = "safortestrecording";
        public const string DefaultStorageAccountEndPoint = "blob.core.windows.net";
        public const string DefaultDeviceName = "Device05ForSDKTest";
        public const string DeviceForFailover = "jemdeviceforsdk";
        public const string DeviceForUpdateTests = "sugattdeviceforSDK";
        public const string DeviceForDeviceOperationTests = "Device001ForSDKTest";
        public const string DeviceForSCATests = "sca07forsdktest";
        public const string SecondaryDnsServers = "10.67.64.15;10.67.64.14";
        public const string FirstDeviceControllerZeroIp = "10.168.241.122";
        public const string FirstDeviceControllerOneIp = "10.168.241.121";

        public static readonly DateTime MetricsStartTime = new DateTime(2017, 06, 17, 18, 30, 00, DateTimeKind.Utc);
        public static readonly DateTime MetricsEndTime = new DateTime(2017, 06, 21, 18, 30, 00, DateTimeKind.Utc);
        public static readonly DateTime TimeBeforeBackupRestoreJobStart = new DateTime(2017, 06, 22, 18, 30, 00, DateTimeKind.Utc);
        public static readonly DateTime Schedule1StartTime = new DateTime(2017, 06, 23, 18, 30, 00, DateTimeKind.Utc);
        public static readonly DateTime Schedule2StartTime = new DateTime(2017, 06, 23, 19, 30, 00, DateTimeKind.Utc);
        public static readonly DateTime MinTimeForAlert = new DateTime(2017, 06, 09, 18, 30, 00, DateTimeKind.Utc);
        public static readonly DateTime MaxTimeForAlert = new DateTime(2017, 06, 19, 18, 30, 00, DateTimeKind.Utc);
        public static readonly DateTime TimeBeforeCancelledBackupJobStart = new DateTime(2017, 06, 28, 9, 00, 00, DateTimeKind.Utc);
    }
}