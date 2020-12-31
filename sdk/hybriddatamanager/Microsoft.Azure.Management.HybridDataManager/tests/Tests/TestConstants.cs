namespace HybridData.Tests.Tests
{
    public static class TestConstants
    {
        #region Default Strings
        public const string DefaultResourceGroupName = "ResourceGroupForSDKTest";
        public const string DefaultDataManagerName = "TestAzureSDKOperations";
        public const string DefaultLocation = "westus";
        public const string DefaultDataServiceName = "DataTransformation";
        public const string DefaultDataSinkType = "AzureStorageAccount";
        public const string DefaultDataSourceType = "StorSimple8000Series";
        public const string DefaultDataSinkName = "TestAzureStorage1";
        public const string DefaultDataSourceName = "TestStorSimpleSource1";
        public const string DefaultStorSimpleResourceName = "BLR8600";
        public const string DefaultStorSimpleResourceSubscriptionId = "c5fc377d-0085-41b9-86b7-cc96dc56d1e9";
        public const string DefaultStorSimpleDeviceName = "8600-SHG0997877L71FC";
        public const string DefaultStorSimpleDeviceResourceGroup = "ForDMS";
        public const string DefaultStorageContainerName = "containerfromtest";
        public const string DefaultStorageAccountName = "dmsdatasink";
        public const string DefaultStorSimpleVolumeName = "TestAutomation";
        public const string DefaultJobDefinitiontName = "jobdeffromtestcode1";
        #endregion

        #region Error Codes
        public const string ResourceNotFoundErrorCode = "ResourceNotFound";
        public const string DmsUserErrorEntityNotFoundErrorCode = "DmsUserErrorEntityNotFound";
        #endregion
    }
}
