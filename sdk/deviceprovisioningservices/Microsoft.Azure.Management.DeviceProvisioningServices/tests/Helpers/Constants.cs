namespace DeviceProvisioningServices.Tests.Helpers
{
    public static class Constants
    {
        public const string AccessKeyName = "provisioningserviceowner";

        public static class Certificate
        {
            public const string Content =
                "MIIBvjCCAWOgAwIBAgIQG6PoBFT6GLJGNKn/EaxltTAKBggqhkjOPQQDAjAcMRow"
                + "GAYDVQQDDBFBenVyZSBJb1QgUm9vdCBDQTAeFw0xNzExMDMyMDUyNDZaFw0xNzEy"
                + "MDMyMTAyNDdaMBwxGjAYBgNVBAMMEUF6dXJlIElvVCBSb290IENBMFkwEwYHKoZI"
                + "zj0CAQYIKoZIzj0DAQcDQgAE+CgpnW3K+KRNIi/U6Zqe/Al9m8PExHX2KgakmGTf"
                + "E04nNBwnSoygWb0ekqpT+Lm+OP56LMMe9ynVNryDEr9OSKOBhjCBgzAOBgNVHQ8B"
                + "Af8EBAMCAgQwHQYDVR0lBBYwFAYIKwYBBQUHAwIGCCsGAQUFBwMBMB8GA1UdEQQY"
                + "MBaCFENOPUF6dXJlIElvVCBSb290IENBMBIGA1UdEwEB/wQIMAYBAf8CAQwwHQYD"
                + "VR0OBBYEFDjiklfHQzw1G0A33BcmRQTjAivTMAoGCCqGSM49BAMCA0kAMEYCIQCt"
                + "jJ4bAvoYuDhwr92Kk+OkvpPF+qBFiRfrA/EC4YGtzQIhAO79WPtbUnBQ5fsQnW2a"
                + "UAT4yJGWL+7l4/qfmqblb96n";

            public const string Name = "DPStestCert";
            public const string Subject = "Azure IoT Root CA";
            public const string Thumbprint = "9F0983E8F2DB2DB3582997FEF331247D872DEE32";
        }

        public const string DefaultLocation = "WestUS2";

        public static class DefaultSku
        {
            public const string Name = "S1";
            public const int Capacity = 1;
            public const string Tier = "S1";
        }

        public static readonly string[] AllocationPolicies = { "Hashed", "GeoLatency", "Static" };

        public const int ArmAttemptWaitMs = 500;
        public const int RandomAllocationWeight = 870084357;
        public const int ArmAttemptLimit = 5;
    }
}
