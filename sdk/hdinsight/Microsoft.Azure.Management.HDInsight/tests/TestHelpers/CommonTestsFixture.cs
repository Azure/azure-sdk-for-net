// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Management.HDInsight.Tests
{
    /// <summary>
    /// Common data
    /// </summary>
    public class CommonTestFixture : TestBase
    {
        /// <summary>
        /// Gets or sets resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets resource location.
        /// </summary>
        public string Location  { get; set; }

        /// <summary>
        /// Required role for MSI to access ADLS Gen2
        /// </summary>
        public string AdlsGen2RequiredRoleName { get; }

        /// <summary>
        /// Gets or sets storage account name.
        /// </summary>
        public string StorageAccountName { get; set; }

        /// <summary>
        /// Gets or sets managed identity name.
        /// </summary>
        public string ManagedIdentityName { get; private set; }

        /// <summary>
        /// Gets or sets managed identity name.
        /// </summary>
        public string VaultName { get; private set; }

        /// <summary>
        /// Gets or sets storage account access key.
        /// </summary>
        public string StorageAccountKey { get; set; }

        /// <summary>
        /// Gets or sets storage account container name.
        /// </summary>
        public string ContainerName { get; set; }

        /// <summary>
        /// Gets or sets storage account blob endpoint suffix.
        /// </summary>
        public string BlobEndpointSuffix { get; set; }

        /// <summary>
        /// Gets or sets storage account dfs endpoint suffix.
        /// </summary>
        public string DfsEndpointSuffix { get; set; }

        /// <summary>
        /// Gets or sets Client id used for accessing ADLS Gen1 account.
        /// </summary>
        public string DataLakeClientId { get; set; }

        /// <summary>
        /// Gets or sets cert password.
        /// </summary>
        public string CertPassword { get; set; }

        /// <summary>
        /// Gets or sets cert content.
        /// </summary>
        public string CertContent { get; set; }

        /// <summary>
        /// Gets or sets workspace id.
        /// </summary>
        public string WorkspaceId { get; set; }

        /// <summary>
        /// Gets or sets ADLS account name.
        /// </summary>
        public string DataLakeStoreAccountName { get; set; }

        /// <summary>
        /// Gets or sets ADLS mount point.
        /// </summary>
        public string DataLakeStoreMountpoint { get; set; }

        /// <summary>
        /// Gets or sets SSH user name.
        /// </summary>
        public string SshUsername { get; set; }

        /// <summary>
        /// Gets or sets SSH user password.
        /// </summary>
        public string SshPassword { get; set; }

        /// <summary>
        /// Gets or sets cluster user name.
        /// </summary>
        public string ClusterUserName { get; set; }

        /// <summary>
        /// Gets or sets cluster user password.
        /// </summary>
        public string ClusterPassword { get; set; }

        /// <summary>
        /// Gets or sets subscription id.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets tenant id.
        /// </summary>
        public string TenantId { get;  set; }

        /// <summary>
        /// Gets or sets managed identity name.
        /// </summary>
        public string ClientObjectId { get;  set; }

        /// <summary>
        /// Ctor
        /// </summary>
        public CommonTestFixture()
        {
            Location = "South Central US";
            AdlsGen2RequiredRoleName = "Storage Blob Data Owner";
            ClusterUserName = TestUtilities.GenerateName("admin");
            ClusterPassword = TestUtilities.GenerateName("Password1!");
            SshUsername = TestUtilities.GenerateName("sshuser");
            SshPassword = TestUtilities.GenerateName("Password1!");
            DataLakeStoreMountpoint = "/clusters/hdi";
            CertPassword = "123";
            CertContent = @"MIIJ8gIBAzCCCa4GCSqGSIb3DQEHAaCCCZ8EggmbMIIJlzCCBgAGCSqGSIb3DQEHAaCCBfEEggXtMIIF6TCCBeUGCyqGSIb3DQEMCgECoIIE9jCCBPIwHAYKKoZIhvcNAQwBAzAOBAiTJstpWcGFZAICB9AEggTQZvg9qVE2ptb3hdH9hnDf5pwIeGghe9assBeEKj/W1JMUjsdEu7qzXH9/3Ro6C1HF6MvSqbav7MD8je9AMb0jl7T3ZmXPgGtrbUsSBTPruVv0hTXPRTxQmcfwae5vEkD03b/4W22sXMMYZB7wOTQMl1d5+0wt267qdF+G1XWtRI2jnxetK8/oyMQxn5Cwuz/VAmn1tXwRAN9gIiZDA8MwvpYha/iFVWKu/vnHg8HT47ry+27/wh8ifM9ea7JWhKh2tZoPIMou9/P/CgkkMv9KVHlmiMldA3Phxsrqjbh/wbd8RWBOtSM7rryMVnc1MYonZraDJMGOLGAhvEcXNBKLwRdmrDDYvpOYlDYKlmNvDXYDm410XCOia2aKP0WoP4qLsExtUwW8Qk2r2QRy5O4B5p2EbPZBlPlMMO4S1NkASjJCghuTCUgvk3uwe2L/mMf0IajAf+R0/VW/fXHbhJkFKobi5JlIqWaHsSC7hMidWj6771Yi8UEXOMshWERs2UHH05aIO3c50lnyypHyhA3BohKUXzNhHA0o7ImQRjmjjTJFBLMNiIZSW0aPtLN1+92pT0a6iS7P1PC0DqEnOjkcs/VOUI3qTt0X78b6wnDO+ATo39B13njGD0mtrVvtTeHclBouoFzpKHkS86GSGmDoHQH6EHhpGF/7wPVfAjAiSrNQb/QLjPHWo+BeiOml4Xrti0K6rWb0AXhY8AmtIlEUC9GscDSdT55v9j9tWONzOXECCgZBYDzNlagMLkCDIFHZwbEGPn3pOc7BTOmQf1GQjfvunLiLWWfe3of9pR+NCDyi1VJUNvjoE+/YnVoBBUMBBO6/4t2SL92iouEF4fyqkQFDb0FOPW4Kfh7H5W+sDZIN9NfqNzniK6HFcpS+jnGm9x9rx81DmMcwtiYZTfYDSivtNxOYrmRFXx574stBzvG0En11uc6E4QhWnkCSsBnnOMjRGDyv95BFVMZC0gIS0rWoKYxjdblpmo9w/yfDtAmQuCs3bdqcJ4mMYt0ueUUZImPRQRJOSrVyoq+brLw657EqM1SahtBmzTG7+HTl1Qi/xZ1xmz6paQDSFVPRcb5QSIp4v08j/Lmj0x4R9jQ4cAmZ3CfPKXBKuIRu2AI2EuqGOoAxvQQEpSjSKUs3fbQxjptUhK7o5FcXAfAxHLzdx2/9L1Iqbo/3HDkbmuix24NRXESG0e/kVr7VAGhoALI7L+eKAdn4AkgmBt55FXZ+uHY9bSKZUoz4Oed2bz2A+9sQBcXG06fLqQEwGVPhATEbYyRduuY6AdTRAmOKmadT5BTTD7+dnFlIt+u7ZpbXm6S6LcSqGqHVacig27SwDt0VznQsjMRDVCiHaWKg4W78xbP7YVvNTB/cBCHmhh5ZXfO/TucizXsQPJlwEMr2CbqByqldXi0i1GUrbg4aLUGZtxgUYex7dHlx6GUejOGRh7fLYCNBo43pjCFvbhFwb0/dWya0crJjpGiY3DNtl1YosJBmvso/Rli4QqVeN7tb45ZsGWTEUg1MDeoGRDqal7GDsvBnH574T5Sz3nSLAoNXR7k0rYaWhezJNobo/SDkuSXskVjNJpv+vjEyW2UGYNhaeK/UHKBP8IrmSAEIZejQj6OEzSPM6TNLW5qJb6LK9agxgdswEwYJKoZIhvcNAQkVMQYEBAEAAAAwXQYJKwYBBAGCNxEBMVAeTgBNAGkAYwByAG8AcwBvAGYAdAAgAFMAdAByAG8AbgBnACAAQwByAHkAcAB0AG8AZwByAGEAcABoAGkAYwAgAFAAcgBvAHYAaQBkAGUAcjBlBgkqhkiG9w0BCRQxWB5WAFAAdgBrAFQAbQBwADoAMAAyAGYAZQA0AGUAOAAzAC0AMgAzADEANgAtADQAMQA3AGMALQA5ADQANQBjAC0AZgA1ADUAMABhADUAZAAwAGIAMAAzAGEwggOPBgkqhkiG9w0BBwagggOAMIIDfAIBADCCA3UGCSqGSIb3DQEHATAcBgoqhkiG9w0BDAEDMA4ECAR1hzovrDkgAgIH0ICCA0gq6boOLRoE5PHFfVIXYtzqg1u2vPMm5mgBUvrh3u+VZ/1FMGTj8od9+Yu91cnumVSgfRiGq7lz+K6by5JsBqP68ksLA2d/PqtTdofCoZ7SgVIo+qqzA64HIQFkElNpo/BJMX/JGpc5OlFq7mdHe6xL2Pfx/3z/pNSV+D+WaAwaDnbLqI7MU6ED3j5l63mExk/8H/VVbiPdqMTzbhIp65oHTGanw86w7RlywqeNb3DkPVMB78Jhcg8vf2AxB8hKf6QiO2uJc/4WKkyLoLmNoD/zhaoUuAbC6hrNVAa9VRWNRfwKZrzwIMSLlKYwWmVcD/QgC8gwxuF+wV3UHwDNAdEe8TEsOhE99/ZiUiogxMdkopZwwtZMszzBB/x5mHCGySauDMVPwoYT6QXewJhGrUap0jwB/Vzy5FaWHi/m8964zWpwC6xfkT2hkDb+rfouWutpiAgMne5tD9YvqxTUmZFIlgwpLrVdPcKQS+b/uIXPTv8uW177XsCOmGGu728ld8H1Ifb2nPveK09Y0AA+ARFpOX0p0ZuxMQqk6NnlA+eESJVm5cLfKszorRcrNPINXaEOGl2okuijm8va30FH9GIYWRt+Be6s8qG672aTO/2eHaTHeR/qQ9aEt0ASDXGcugYS14Jnu2wbauyvotZ6eAvgl5tM2leMpgSLaQqYzPTV2uiD6zDUqxwjm2P8EZQihEQqLUV1jvQuQB4Ui7MryDQ+QiDBD2m5c+9SDPafcR7qgRe/cP4hj5BqzHTcNQAD5BLXze7Yx+TMdf+Qe/R1uBYm8bLjUv9hwUmtMeZP4RU6RPJrN2aRf7BUdgS0j/8YAhxViPucRENuhEfS4sotHf1CJZ7xJz0ZE9cpVY6JLl1tbmuf1Eh50cicZ1SHQhqSP0ggLHV6DNcJz+kyekEe9qggGDi6mreYz/kJnnumsDy5cToIHy9jJhtXzj+/ZNGkdpq9HWMiwAT/VR1WPpzjn06m7Z87PiLaiC3simQtjnl0gVF11Ev4rbIhYjFBL0nKfNpzaWlMaOVF+EumROk3EbZVpx1K6Yh0zWh/NocWSUrtSoHVklzwPCNRvnE1Ehyw5t9YbEBsTIDWRYyqbVYoFVfOUhq5p4TXrqEwOzAfMAcGBSsOAwIaBBSx7sJo66zYk4VOsgD9V/co1SikFAQUUvU/kE4wTRnPRnaWXnno+FCb56kCAgfQ";
            WorkspaceId = TestUtilities.GenerateGuid().ToString();
            ResourceGroupName = TestUtilities.GenerateName("hdicsharprg");
            StorageAccountName = TestUtilities.GenerateName("hdicsharpstorage");
            ManagedIdentityName = TestUtilities.GenerateName("hdicsharpmsi");
            VaultName = TestUtilities.GenerateName("hdicsharpvault");
            DataLakeStoreAccountName = TestUtilities.GenerateName("hdicsharpadls");
            ContainerName = TestUtilities.GenerateName("default");
            StorageAccountKey = TestUtilities.GenerateName("storageaccountkey");
        }
    }
}
