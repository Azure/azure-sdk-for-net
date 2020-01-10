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
        public const string EdgeDeviceCIK = "5d21566d7f55501f02c06ddeaf4984370e499c340458f2f0775223bd316f93c1ff2390de554cf108c07b46f4d42dd302e78a46501d16bf485d515a0e62f7b811";

        /// <summary>
        /// Name of the gateway resource being used in the test
        /// </summary>
        public const string GatewayResourceName = "demo-gateway-device";


        /// <summary>
        /// Name of the edge resource being used in the test
        /// </summary>
        public const string EdgeResourceName = "demo-edge-device";
        /// <summary>
        /// ARM Lite user name
        /// </summary>
        public const string ARMLiteUserName = "EdgeArmUser";


    }
}
