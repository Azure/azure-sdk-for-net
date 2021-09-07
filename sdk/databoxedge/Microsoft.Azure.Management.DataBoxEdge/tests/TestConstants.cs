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
        public const string GatewayDeviceCIK = "";

        /// <summary>
        /// Encryption key of edge resource
        /// </summary>
        public const string EdgeDeviceCIK = "9e16239d72a75fed6401a8f20d7425dfe954c72635d3280323a81ef4246f2fca10cd4e94ac4a715add15b4583e1e2ebf348256603cff1148b40b73de91dc5e7d";

        /// <summary>
        /// Name of the gateway resource being used in the test
        /// </summary>
        public const string GatewayResourceName = "demo-gateway-device-5";


        /// <summary>
        /// Name of the edge resource being used in the test
        /// </summary>
        public const string EdgeResourceName = "demo-sdk-2021";
        /// <summary>
        /// ARM Lite user name
        /// </summary>
        public const string ARMLiteUserName = "EdgeArmUser";

        /// <summary>
        /// SubscriptionId for the test resources
        /// </summary>
        public const string SubscriptionId = "706c087b-4c6c-46bf-8adf-766ae266d5bf";


    }
}
