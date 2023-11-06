namespace DataBoxEdge.Tests
{
    /// <summary>
    /// Contains the constants used in tests
    /// </summary>
    public static class TestConstants
    {
        /// <summary>
        /// Location where test resources are created
        /// </summary>
        public const string DefaultResourceLocation = "centraluseuap";

        /// <summary>
        /// Resource group in which resources are created
        /// </summary>
        public const string DefaultResourceGroupName = "demo-resources";

        /// <summary>
        /// Encryption key of gateway resource
        /// </summary>
        public const string GatewayDeviceCIK = "rP34mlUOKd7HDQuOVvbzygjuzBu0VOEtmgj/gls6EhoUVFirT8jQruHJJ49+1XfGFix0TSdHfXP2Z3bSoWlFz72sWhUPRoIfHiUZzKbAe/3LRay89jQuUotFmhBPccMv";

        /// <summary>
        /// Encryption key of edge resource
        /// </summary>
        public const string EdgeDeviceCIK = "5a6ba59a0e67c9ccadd887c3573a0e0cdba8b9921406b6a5ed4107f0de4bad256092940f76954a7ab356e0ac7c8dc8cbfcf1a2c16aba4931758639008b3f8fc6";

        /// <summary>
        /// Name of the gateway resource being used in the test
        /// </summary>
        public const string GatewayResourceName = "demo-gateway-sdk-2021";

        /// <summary>
        /// Name of the edge resource being used in the test
        /// </summary>
        public const string EdgeResourceName = "sdk-refresh-2023";

        /// <summary>
        /// KeyVault associcated to Edge Device
        /// </summary>
        public const string EdgeDeviceKeyVault = "demo-edge-sdk-2021-kv";

        /// <summary>
        /// ARM Lite user name
        /// </summary>
        public const string ARMLiteUserName = "EdgeArmUser";

        /// <summary>
        /// SubscriptionId for the test resources
        /// </summary>
        public const string SubscriptionId = "706c087b-4c6c-46bf-8adf-766ae266d5bf";

        /// <summary>
        /// ProviderNameSpace
        /// </summary>
        public const string ProviderNameSpace = "Microsoft.DataBoxEdge";

        /// <summary>
        /// TestStorageAccountName
        /// </summary>
        public const string TestStorageAccountName = "storageaccounttest15";

        /// <summary>
        /// TestSAC
        /// </summary>
        public const string TestSAC = "asesdkrefresh";

        /// <summary>
        /// User1
        /// </summary>
        public const string User1 = "user1";
    }
}
