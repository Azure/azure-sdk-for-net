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
        public const string EdgeDeviceCIK = "A+etUJ991YyaVRVuKEfL9eKZjc9OHh6FkM3M2raJZLhts6uvtVq3flrsFo6xrdDYXZJucIqN+w8TO8t3mXvsBpy6sllkMMvZyDjoO3zhOOTw/7mq0yFW0bFBsJDIXmMo";

        /// <summary>
        /// Name of the gateway resource being used in the test
        /// </summary>
        public const string GatewayResourceName = "demo-gateway-sdk-2021";

        /// <summary>
        /// Name of the edge resource being used in the test
        /// </summary>
        public const string EdgeResourceName = "demo-edge-sdk-2021";

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
    }
}
