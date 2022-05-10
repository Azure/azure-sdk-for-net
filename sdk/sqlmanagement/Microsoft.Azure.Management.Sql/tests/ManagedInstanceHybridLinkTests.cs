// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace Sql.Tests
{
    public class ManagedInstanceHybridLinkTests
    {
        private const string certificateName1 = "test_cert1";
        private const string thumbprint1 = "0x5E1C40529126487B5B20C0E7E299FFF7190E94D7";
        private const string publicBlob1 =
            "0x3082031E30820206A00302010202107339C358890D88B04D584E95AD40EFA0300D06092A864886F70D01010B0500304B3149304706035504031E40004D0053005F0053006D006F0045007800740065" +
            "006E006400650064005300690067006E0069006E006700430065007200740069006600690063006100740065301E170D3231303332333031343733385A170D3232303332333031343733385A304B3149" +
            "304706035504031E40004D0053005F0053006D006F0045007800740065006E006400650064005300690067006E0069006E00670043006500720074006900660069006300610074006530820122300D06" +
            "092A864886F70D01010105000382010F003082010A0282010100B796616200301A3E8E06A594CD45EB665676E23368222D7F7F70E6474B602978A7A3D45381B293D6FE5C4EB47298496CDA2599DBC264" +
            "5B2A1CEB311FC4D5AD5AE162E337776D90B8D1E30BF2BB1D19783B22AA261EBA70FBF6896FFE356ED7A7E09EA71F67B6E2213ACE95E8DA12038B6D2D2C986D56CA0859D6A1BDA7DA08DCFFE11FF1E59E" +
            "DA4225BC0A252405025E49F5C34B65E9614DF8BBD78AFE33CD14E32F2043D833EE7EF6CE3E663BF437A72DE2933D6FC62FB5E87F6B443A0257135C09B8308B231358594EE2FD3A384B3AD5B7D22B1B35" +
            "E1682F28CC5F7F27A233D704E7DE46126B811E5CF4D2835C316DBD9A4288DA02B2481FF8FCEF754F957D0203010001300D06092A864886F70D01010B0500038201010029577117B09612B085B6AE4741" +
            "7C556013DEF38F61E726E1DEE908332BDD50F830CE43B7D61F20E300E50E23305C94D19DB5FF0F66D0E7B6DAB6510680A10B346653359C1B20F219BF1EB4217B6AEC4CD01BB96F0E84CC9C5DC6DA325E" +
            "B8979DCA9E9F61AF1C2BB3E3DAB4DE7D118588184FF98FE8E803F3374392464A64563D097AB878DB01115CD443EAF58B0705E13A1E27021F6C0E0104CF5307DCCA79D4CA70F26A3FD2CE89AAE0AD1C08" +
            "E884AB1BD8FAF3983A0667820BB122688E30C873932FB25BF85EA0B23E651D4DBA5436EC6F17D770832E7041ED44952883470E1B599FDB0E518E663CBD6FED7983849101A89497CF4D0C9FE2DF7F9C2B" +
            "E3C21A";
        private const string certificateName2 = "test_cert2";
        private const string publicBlob2 = "0x3082" +
            "031E30820206A003020102021015ECCB530A52D0874A9B4DFB69FFCAA0300D06092A864886F70D01010B0500304B3149304706035504031E40004D0053005F00530051004C005200650073006F007500" +
            "7200630065005300690067006E0069006E006700430065007200740069006600690063006100740065301E170D3231303332333031343733385A170D3232303332333031343733385A304B3149304706" +
            "035504031E40004D0053005F00530051004C005200650073006F0075007200630065005300690067006E0069006E00670043006500720074006900660069006300610074006530820122300D06092A86" +
            "4886F70D01010105000382010F003082010A0282010100C3BC903BD030D2EE904E941B603040F7DF38262BBA86AD3B9AD4BFE361D910378C5459DE540398E43124272BAE97AE502490F5140393A66EC4" +
            "9667D1B64449EAECC0DCB7FCA5BBF2E214F0AF8A697CBAF790B0FCD086C69C06A363849D7481468894E40F0B6466591775FFA6B3E387F5C56126078EBB69CB7EA9FD842233A29C9D92EE0ED2D9D09C96" +
            "EBE2B4089EBE9A2D2276F75F506FD09CB3DF312C2B737E8E20AB4C7F48EF5D730D8AB4BB7234315ABD4CB2568896801CECB2B6452EADAEE2DFC7E8B03B01B0F8742BF9DA941E5449F14ABA8BAA58189D" +
            "4F7558068E782580181038EB3DBAC7FD53D200357298258F3AC9ACCA4845F83C8539E35FC36B750203010001300D06092A864886F70D01010B0500038201010072200767AE16B164DCC9A7439F96CA3E" +
            "BFDEEF8440B2BD9356E0257520FB8A2763E90BB6D727F7CE63CC40B40872A7C77B451EFD5CB022D349303C75956CA372D3FF513516EEA0F545240D451FC98EA743008EFDE63ABC003AEE3FA80CA05425" +
            "CA3FD9C0EC8123BD6F1E9DAFE5AC33AF3A1DE89E6F28349DE7A5EE5AE39F0E6AD87B3D03037FDB9F1B1A7BB1B55A51A70C9E0604BC9EDDFA4BF1582C039826E89F960720FC6B6AB398DFFC4B38A2F7C5" +
            "26C9AC31D96BA40D9B02FC58FFAA37BE5B3DC0DCCF9F1ED1358A23E4E7D0E3A397B841BCFB7AE8405DE8A42511C2C3B14DFB13F467F16ED63EEB0E22127E281EEDCBD9A3D3C957AC51D5D75FBB713018";
        private const string thumbprint2 = "0x3B3209B3F06A633946AB89FA5E18D7A7E81A066E";
        private const string invalidCertName1 = "invalid_cert1";
        private const string invalidCertName2 = "invalid_cert2";
        private const string invalidCertName3 = "invalid_cert3";
        private const string invalidPublicBlob = "0x3082031E30820206A00302010202107339C358890D88B04D584E95AD40EFA0300D06092A864886F70D01010B0500304B3149304706035504031E40004D0053005F0053006D006F0045007800740065";
        private const string publicBlob3 =
            "0x30820316308201FEA003020102021072F30C6F228A33B64405E7EA8BB1C949300D06092A864886F70D01010B050030473145304306035504031E3C004D0053005F00530051004C0041007500740068" +
            "0065006E00740069006300610074006F007200430065007200740069006600690063006100740065301E170D3231303332333031343733385A170D3232303332333031343733385A3047314530430603" +
            "5504031E3C004D0053005F00530051004C00410075007400680065006E00740069006300610074006F00720043006500720074006900660069006300610074006530820122300D06092A864886F70D01" +
            "010105000382010F003082010A0282010100C6DB530E4E055B502D75A1E25EE65403B754A4079898027018E3032DDD42A67C243797DAA737C32E933E4582DC2BBADE16F35C41E55ED77B6AC640F7DE78" +
            "8FCD617A594FD6A4A0BC4F2FCAC84D031F1D1F4DD82225E953918550DF657633C1FB1D5D227DCBF7A924122165E3C67F5E88AA68EA509BAB82966C377C1F3CF83A0AEAFFD18B3C24D631FE12DF7D1065" +
            "9A6601ACD55CAA95CC57CD3E4B29B01271F0FA64725E288BEAEB7792B15FE2FD36EF8A86CEBF3AAEFCCAD3A84295EB01E0AD776617FB42A470A9F5956011C11BFFB881C97650647C734393A68AC379EB" +
            "9187DEBAD9C61F26BB8AEFE5A1AD549010DA7DBF0478EEEBB4D55C5863DB336A7F7D0203010001300D06092A864886F70D01010B05000382010100C052781B299ECFB0B833B5DC3CC96E0C9DAB690070" +
            "8F16059E13A8A5D07493A7BB551E7E2513284F11AA8D6F8AB85374B43A97388387FC8E0DB45650D68E61F634E1CD86D064F8831CD5E353FD6D304087A604CEB4388866BCB64CD95F3F45D76D4A97C4EC" +
            "AA1512202F24001784C00243D63AFC402247A961FB48578B28BBC8496A4441A0A72BF12755F1C16810A53723510F498908C824340F0B18081615A2EF75B4B94F5A22D9D1B4A0AA483006B0A8B035F4D5" +
            "D0E5FD247C7199874C3E0BD4E80DF013BA7636BE906146C888B1C4848A729797A971C74D67FFC6A926978F6F9A3A222AD534F27A1F7FEFB48E54C335050447BF41D8CCB71889D836BB6AC6";
        private const string thumbprint3 = "0xC8002E47F5BC5A3D3692B57D6987C7D9D79863DA";
        private const string certType = "Microsoft.Sql/managedInstances/serverTrustCertificates";

        private static readonly Func<string, string, string> makeId = (managedInstanceId, certificateName) =>
        {
            return managedInstanceId + "/serverTrustCertificates/" + certificateName;
        };

        private const string endpointTypeDatabaseMirroring = "DATABASE_MIRRORING";
        private const string endpointTypeServiceBroker = "SERVICE_BROKER";
        private const string endpointCertType = "Microsoft.Sql/managedInstances/endpointCertificates";
        private static readonly Func<string, string, string> makeEndpointCertID = (managedInstanceId, endpointType) => { return managedInstanceId + "/endpointCertificates/" + endpointType; };

        [Fact]
        public void TestServerTrustCertificates()
        {
            string suiteName = this.GetType().Name;
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                // Test setup (rg, mi):
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                //ResourceGroup rg = new ResourceGroup(location: "eastus2euap", id: "/subscriptions/8313371e-0879-428e-b1da-6353575a9192/resourceGroups/CustomerExperienceTeam_RG", name: "CustomerExperienceTeam_RG");
                //ManagedInstance managedInstance = sqlClient.ManagedInstances.Get(rg.Name, "chimera-ps-cli-v2");
                ResourceGroup rg = context.CreateResourceGroup(ManagedInstanceTestUtilities.Region);
                ManagedInstance managedInstance = context.CreateManagedInstance(rg);
                Assert.NotNull(managedInstance);

                // Test data:
                var resourceGroupName = rg.Name;
                var managedInstanceName = managedInstance.Name;
                var expectedCert1 = new ServerTrustCertificate(makeId(managedInstance.Id, certificateName1), certificateName1, certType, publicBlob1, thumbprint1, certificateName1);
                var expectedCert2 = new ServerTrustCertificate(makeId(managedInstance.Id, certificateName2), certificateName2, certType, publicBlob2, thumbprint2, certificateName2);

                // Make API calls
                var upsertResp1 = sqlClient.ServerTrustCertificates.CreateOrUpdate(resourceGroupName, managedInstanceName, certificateName1, expectedCert1);
                var upsertResp2 = sqlClient.ServerTrustCertificates.CreateOrUpdate(resourceGroupName, managedInstanceName, certificateName2, expectedCert2);
                var getResp1 = sqlClient.ServerTrustCertificates.Get(resourceGroupName, managedInstanceName, certificateName1);
                var getResp2 = sqlClient.ServerTrustCertificates.Get(resourceGroupName, managedInstanceName, certificateName2);
                var listResp = sqlClient.ServerTrustCertificates.ListByInstance(resourceGroupName, managedInstanceName);

                // Test all result fields
                var listRespCert1 = listResp.Where(cert => cert.Name.Equals(certificateName1)).FirstOrDefault();
                var listRespCert2 = listResp.Where(cert => cert.Name.Equals(certificateName2)).FirstOrDefault();
                var expected = new[] { expectedCert1, expectedCert2, expectedCert1, expectedCert2, expectedCert1, expectedCert2 };
                var actual = new[] { upsertResp1, upsertResp2, getResp1, getResp2, listRespCert1, listRespCert2 };
                var exp_act = expected.Zip(actual, (e, a) => new { Expected = e, Actual = a });
                foreach (var ea in exp_act)
                {
                    Assert.NotNull(ea.Actual);
                    Assert.Equal(ea.Expected.CertificateName, ea.Actual.CertificateName);
                    Assert.Equal(ea.Expected.Id, ea.Actual.Id);
                    Assert.Equal(ea.Expected.Name, ea.Actual.Name);
                    Assert.Equal(ea.Expected.PublicBlob, "0x" + ea.Actual.PublicBlob);
                    Assert.Equal(ea.Expected.Thumbprint, "0x" + ea.Actual.Thumbprint);
                    Assert.Equal(ea.Expected.Type, ea.Actual.Type);
                }

                // cert with invalid public key blob
                var invalidCert1 = new ServerTrustCertificate(makeId(managedInstance.Id, invalidCertName1), invalidCertName1, certType, invalidPublicBlob, thumbprint1, invalidCertName1);
                // cert without public key blob
                var invalidCert2 = new ServerTrustCertificate(makeId(managedInstance.Id, invalidCertName2), invalidCertName2, certType, null, thumbprint2, invalidCertName2);
                // cert with a public blob that already exist on the instance under a different name
                var invalidCert3 = new ServerTrustCertificate(makeId(managedInstance.Id, invalidCertName3), invalidCertName3, certType, publicBlob1, thumbprint1, invalidCertName3);
                // cert blob empty
                var invalidCert4 = new ServerTrustCertificate(makeId(managedInstance.Id, invalidCertName3), invalidCertName3, certType, "", thumbprint1, invalidCertName3);
                // cert name exists, different blob
                var invalidCert5 = new ServerTrustCertificate(makeId(managedInstance.Id, certificateName1), certificateName1, certType, publicBlob3, thumbprint3, certificateName1);
                // cert name empty
                var invalidCert6 = new ServerTrustCertificate(makeId(managedInstance.Id, ""), "", certType, publicBlob1, thumbprint1, "");
                var exception1 = Assert.Throws<CloudException>(() => sqlClient.ServerTrustCertificates.CreateOrUpdate(resourceGroupName, managedInstanceName, invalidCertName1, invalidCert1));
                var exception2 = Assert.Throws<CloudException>(() => sqlClient.ServerTrustCertificates.CreateOrUpdate(resourceGroupName, managedInstanceName, invalidCertName2, invalidCert2));
                var exception3 = Assert.Throws<CloudException>(() => sqlClient.ServerTrustCertificates.CreateOrUpdate(resourceGroupName, managedInstanceName, invalidCertName3, invalidCert3));
                var exception4 = Assert.Throws<CloudException>(() => sqlClient.ServerTrustCertificates.CreateOrUpdate(resourceGroupName, managedInstanceName, invalidCertName3, invalidCert4));
                var exception5 = Assert.Throws<CloudException>(() => sqlClient.ServerTrustCertificates.CreateOrUpdate(resourceGroupName, managedInstanceName, certificateName1, invalidCert5));
                var exception6 = Assert.Throws<CloudException>(() => sqlClient.ServerTrustCertificates.CreateOrUpdate(resourceGroupName, managedInstanceName, "", invalidCert6));
                Assert.Contains("InvalidPublicBlob", exception1.Body.Code);
                Assert.Contains("MissingPublicBlob", exception4.Body.Code);
                Assert.Contains("MethodNotAllowed", exception6.Body.Code);

                sqlClient.ServerTrustCertificates.Delete(resourceGroupName, managedInstanceName, certificateName1);
                sqlClient.ServerTrustCertificates.Delete(resourceGroupName, managedInstanceName, certificateName2);
            }
        }

        [Fact]
        public void TestDistributedAvailabilityGroup()
        {
            string suiteName = this.GetType().Name;
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {

                // Test setup (rg, mi):
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                //ResourceGroup rg = new ResourceGroup(location: "eastus2euap", id: "/subscriptions/8313371e-0879-428e-b1da-6353575a9192/resourceGroups/CustomerExperienceTeam_RG", name: "CustomerExperienceTeam_RG");
                //ManagedInstance managedInstance = sqlClient.ManagedInstances.Get(rg.Name, "chimera-ps-cli-v2");
                ResourceGroup rg = context.CreateResourceGroup(ManagedInstanceTestUtilities.Region);
                ManagedInstance managedInstance = context.CreateManagedInstance(rg);
                Assert.NotNull(managedInstance);

                var resourceGroupName = rg.Name;
                var managedInstanceName = managedInstance.Name;
                var dagName = "TestDAG";
                var dagParams = new DistributedAvailabilityGroup()
                {
                    TargetDatabase = "testdb",
                    SourceEndpoint = "TCP://SERVER:7022",
                    PrimaryAvailabilityGroupName = "BoxLocalAg1",
                    SecondaryAvailabilityGroupName = "testcl",
                };
                var invalidDAG1 = new DistributedAvailabilityGroup()
                {
                    //TargetDatabase = "testdb",
                    SourceEndpoint = "TCP://SERVER:7022",
                    PrimaryAvailabilityGroupName = "BoxLocalAg1",
                    SecondaryAvailabilityGroupName = "testcl",
                };
                var invalidDAG2 = new DistributedAvailabilityGroup()
                {
                    TargetDatabase = "testdb",
                    //SourceEndpoint = "TCP://SERVER:7022",
                    PrimaryAvailabilityGroupName = "BoxLocalAg1",
                    SecondaryAvailabilityGroupName = "testcl",
                };
                var invalidDAG3 = new DistributedAvailabilityGroup()
                {
                    TargetDatabase = "testdb",
                    SourceEndpoint = "TCP://SERVER:7022",
                    //PrimaryAvailabilityGroupName = "BoxLocalAg1",
                    SecondaryAvailabilityGroupName = "testcl",
                };
                var invalidDAG4 = new DistributedAvailabilityGroup()
                {
                    TargetDatabase = "testdb",
                    SourceEndpoint = "TCP://SERVER:7022",
                    PrimaryAvailabilityGroupName = "BoxLocalAg1",
                    //SecondaryAvailabilityGroupName = "testcl",
                };
                var invalidDAG5 = new DistributedAvailabilityGroup();

                var exCreate1 = Assert.Throws<CloudException>(() => sqlClient.DistributedAvailabilityGroups.CreateOrUpdate(resourceGroupName, managedInstanceName, "invalid_dag1", invalidDAG1));
                var exCreate2 = Assert.Throws<CloudException>(() => sqlClient.DistributedAvailabilityGroups.CreateOrUpdate(resourceGroupName, managedInstanceName, "invalid_dag2", invalidDAG2));
                var exCreate3 = Assert.Throws<CloudException>(() => sqlClient.DistributedAvailabilityGroups.CreateOrUpdate(resourceGroupName, managedInstanceName, "invalid_dag3", invalidDAG3));
                var exCreate4 = Assert.Throws<CloudException>(() => sqlClient.DistributedAvailabilityGroups.CreateOrUpdate(resourceGroupName, managedInstanceName, "invalid_dag4", invalidDAG4));
                var exCreate5 = Assert.Throws<CloudException>(() => sqlClient.DistributedAvailabilityGroups.CreateOrUpdate(resourceGroupName, managedInstanceName, "invalid_dag5", invalidDAG5));
                Assert.Equal("InvalidParameterValue", exCreate1.Body.Code);
                Assert.Equal("InvalidParameterValue", exCreate2.Body.Code);
                Assert.Equal("InvalidParameterValue", exCreate3.Body.Code);
                Assert.Equal("InvalidParameterValue", exCreate4.Body.Code);

                var upsertResp = sqlClient.DistributedAvailabilityGroups.BeginCreateOrUpdate(resourceGroupName, managedInstanceName, dagName, dagParams);
                var listResp = sqlClient.DistributedAvailabilityGroups.ListByInstance(resourceGroupName, managedInstanceName);

                var tries = 0;
                while (listResp.Count() == 0 && ++tries <= 3)
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(30));
                    listResp = sqlClient.DistributedAvailabilityGroups.ListByInstance(resourceGroupName, managedInstanceName);
                }

                var getResp = sqlClient.DistributedAvailabilityGroups.Get(resourceGroupName, managedInstanceName, dagName);
                Assert.NotNull(getResp);
                Assert.Single(listResp);
                Assert.Equal(dagParams.TargetDatabase, getResp.TargetDatabase);
                Assert.Equal(dagParams.SourceEndpoint, getResp.SourceEndpoint);
                Assert.Equal(dagParams.TargetDatabase, listResp.First().TargetDatabase);
                Assert.Equal(dagParams.SourceEndpoint, listResp.First().SourceEndpoint);

                sqlClient.DistributedAvailabilityGroups.Delete(resourceGroupName, managedInstanceName, dagName);
                var listRespEmpty = sqlClient.DistributedAvailabilityGroups.ListByInstance(resourceGroupName, managedInstanceName);
                Assert.Empty(listRespEmpty);
                var exceptionGet = Assert.Throws<CloudException>(() => sqlClient.DistributedAvailabilityGroups.Get(resourceGroupName, managedInstanceName, dagName));
                Assert.Equal("ResourceNotFound", exceptionGet.Body.Code);
            }
        }


        [Fact]
        public void TestEndpointCertificates()
        {
            string suiteName = this.GetType().Name;
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                // Test setup (rg, mi):
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                //ResourceGroup rg = new ResourceGroup(location: "eastus2euap", id: "/subscriptions/8313371e-0879-428e-b1da-6353575a9192/resourceGroups/CustomerExperienceTeam_RG", name: "CustomerExperienceTeam_RG");
                //ManagedInstance managedInstance = sqlClient.ManagedInstances.Get(rg.Name, "chimera-ps-cli-v2");
                ResourceGroup rg = context.CreateResourceGroup(ManagedInstanceTestUtilities.Region);
                ManagedInstance managedInstance = context.CreateManagedInstance(rg);
                Assert.NotNull(managedInstance);

                var resourceGroupName = rg.Name;
                var managedInstanceName = managedInstance.Name;

                var exceptionGet = Assert.Throws<CloudException>(() => sqlClient.EndpointCertificates.Get(resourceGroupName, managedInstanceName, "invalid_endpoint_type"));
                Assert.Equal("ResourceNotFound", exceptionGet.Body.Code);

                var certServiceBroker = sqlClient.EndpointCertificates.Get(resourceGroupName, managedInstanceName, endpointTypeServiceBroker);
                Assert.NotNull(certServiceBroker);
                Assert.NotNull(certServiceBroker.PublicBlob);
                Assert.True(Regex.Match(certServiceBroker.PublicBlob, @"^[0-9a-fA-F]+$").Success);
                Assert.Equal(endpointTypeServiceBroker, certServiceBroker.Name);
                Assert.Equal(makeEndpointCertID(managedInstance.Id, endpointTypeServiceBroker), certServiceBroker.Id);
                Assert.Equal(endpointCertType, certServiceBroker.Type);

                var certDatabaseMirroring = sqlClient.EndpointCertificates.Get(resourceGroupName, managedInstanceName, endpointTypeDatabaseMirroring);
                Assert.NotNull(certDatabaseMirroring);
                Assert.NotNull(certDatabaseMirroring.PublicBlob);
                Assert.True(Regex.Match(certDatabaseMirroring.PublicBlob, @"^[0-9a-fA-F]+$").Success);
                Assert.Equal(endpointTypeDatabaseMirroring, certDatabaseMirroring.Name);
                Assert.Equal(makeEndpointCertID(managedInstance.Id, endpointTypeDatabaseMirroring), certDatabaseMirroring.Id);
                Assert.Equal(endpointCertType, certDatabaseMirroring.Type);

                var certList = sqlClient.EndpointCertificates.ListByInstance(resourceGroupName, managedInstanceName);
                Assert.NotNull(certList);
                var listCertDBM = certList.Where(cert => cert.Name.Equals(endpointTypeDatabaseMirroring)).FirstOrDefault();
                var listCertSB = certList.Where(cert => cert.Name.Equals(endpointTypeServiceBroker)).FirstOrDefault();
                Assert.NotNull(listCertDBM.PublicBlob);
                Assert.True(Regex.Match(listCertDBM.PublicBlob, @"^[0-9a-fA-F]+$").Success);
                Assert.Equal(endpointTypeDatabaseMirroring, listCertDBM.Name);
                Assert.Equal(makeEndpointCertID(managedInstance.Id, endpointTypeDatabaseMirroring), listCertDBM.Id);
                Assert.Equal(endpointCertType, listCertDBM.Type);
                Assert.NotNull(listCertSB.PublicBlob);
                Assert.True(Regex.Match(listCertSB.PublicBlob, @"^[0-9a-fA-F]+$").Success);
                Assert.Equal(endpointTypeServiceBroker, listCertSB.Name);
                Assert.Equal(makeEndpointCertID(managedInstance.Id, endpointTypeServiceBroker), listCertSB.Id);
                Assert.Equal(endpointCertType, listCertSB.Type);
            }
        }
    }
}
