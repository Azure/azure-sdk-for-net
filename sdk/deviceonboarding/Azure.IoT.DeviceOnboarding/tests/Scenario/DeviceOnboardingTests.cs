// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.IoT.DeviceOnboarding.Models;
using Azure.IoT.DeviceOnboarding.Models.Providers;
using Azure.IoT.DeviceOnboarding.Samples;
using NUnit.Framework;

namespace Azure.IoT.DeviceOnboarding.Tests.Scenario
{
    public class DeviceOnboardingTests : DeviceOnboardingTestsBase
    {
        public DeviceOnboardingTests() : base(true, RecordedTestMode.Record) { }
        protected DeviceOnboardingTests(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }
        protected DeviceOnboardingTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task DeviceOnboarding_Initialize()
        {
            CBORConverterProvider cborProvider = new Sample_CBORConverter();
            DeviceCredentialProvider credentialProvider = new Sample_DeviceCredentialProvider();
            DeviceOnboardingClient client = new DeviceOnboardingClient(cborProvider, credentialProvider);
            DeviceInitializer deviceInitializer = client.GetDeviceInitializer();
#if NET9_0_OR_GREATER
            var mfgCert = X509CertificateLoader.LoadCertificateFromFile("C:\\Users\\shkuang\\Downloads\\testsdkov_59a626d5aff449748ae28e7e662d1af6.cer");
#else
            var mfgCert = new X509Certificate2("C:\\Users\\shkuang\\Downloads\\testsdkov_59a626d5aff449748ae28e7e662d1af6.cer");
#endif
            var rvDir = new RendezvousDirective();
            rvDir.Add(new RendezvousInstruction()
            {
                Variable = RendezvousVariable.IP_ADDRESS,
                Value = cborProvider.Serialize(IPAddress.Parse("10.10.10.10").GetAddressBytes())
            });
            rvDir.Add(new RendezvousInstruction()
            {
                Variable = RendezvousVariable.PROTOCOL,
                Value = cborProvider.Serialize(RendezvousProtocolValue.RVProtHttp)
            });
            rvDir.Add(new RendezvousInstruction()
            {
                Variable = RendezvousVariable.DEV_PORT,
                Value = cborProvider.Serialize(80)
            });
            var rvInfo = new RendezvousInfo();
            rvInfo.Add(rvDir);
            await deviceInitializer.CreateOwnershipVoucherAsync(new X509Certificate2Collection(mfgCert), PublicKeyEncoding.COSEX5CHAIN, rvInfo);
        }

        [TestCase]
        [RecordedTest]
        public async Task DeviceOnboarding_ExtendOwnershipVoucher()
        {
            CBORConverterProvider cborProvider = new Sample_CBORConverter();
            Sample_DeviceCredentialProvider credentialProvider = new Sample_DeviceCredentialProvider();
            DeviceOnboardingClient client = new DeviceOnboardingClient(cborProvider, credentialProvider);
            DeviceInitializer deviceInitializer = client.GetDeviceInitializer();
#if NET9_0_OR_GREATER
            var mfgCert = X509CertificateLoader.LoadCertificateFromFile("C:\\Users\\shkuang\\Downloads\\testsdkov_59a626d5aff449748ae28e7e662d1af6.cer");
#else
            var mfgCert = new X509Certificate2("C:\\Users\\shkuang\\Downloads\\testsdkov_59a626d5aff449748ae28e7e662d1af6.cer");
#endif
            var rvDir = new RendezvousDirective();
            rvDir.Add(new RendezvousInstruction()
            {
                Variable = RendezvousVariable.DNS,
                Value = cborProvider.Serialize("testrv-ddfvb3fkfkfshrbu.westus3.devicerendezvous.azure.net")
            });
            var rvInfo = new RendezvousInfo();
            rvInfo.Add(rvDir);
            await deviceInitializer.CreateOwnershipVoucherAsync(new X509Certificate2Collection(mfgCert), PublicKeyEncoding.COSEX5CHAIN, rvInfo);
            var creds = credentialProvider.GetDeviceCredentials(null);
#if NET8_0_OR_GREATER
            var voucherBytes = PemEncoding.WriteString("OwnershipVoucher", cborProvider.Serialize(deviceInitializer._ownershipVoucher));
            Console.Write($"OVbytes {voucherBytes.Length}");
            string pemFilePath = $"C:\\Users\\shkuang\\Downloads\\{creds.DeviceGuid}";
            File.WriteAllText(pemFilePath, Convert.ToBase64String(cborProvider.Serialize(deviceInitializer._ownershipVoucher), Base64FormattingOptions.InsertLineBreaks));
#endif
#if NET9_0_OR_GREATER

            X509Certificate2 extendTo = X509CertificateLoader.LoadCertificate(Convert.FromBase64String("MIIEqzCCBE+gAwIBAgIQD9s3tTRYuDWa74RNLEVKHDAMBggqhkjOPQQDAgUAMCsxKTAnBgNVBAMMIDMzM2ZiOTAwNTc4YjQxMTI5MmU0NWY3NDZkZjA4NGFjMB4XDTI1MDQxNTIwMDgwNloXDTI2MDQxNTIwMDgwNlowKzEpMCcGA1UEAxMgMzMzZmI5MDA1NzhiNDExMjkyZTQ1Zjc0NmRmMDg0YWMwWTATBgcqhkjOPQIBBggqhkjOPQMBBwNCAASrpkgzqmiuH2UerSBcdN1OYKt1j7TtshTi+2cKDkipKWCqGPI0pECecDd6kKip0AhJuN5iB56TLW05csnjs3Sso4IDUTCCA00wEQYDVR0RBAowCIIGUG9saWN5MAwGA1UdEwEB/wQCMAAwEwYDVR0lBAwwCgYIKwYBBQUHAwIwDgYDVR0PAQH/BAQDAgeAMB0GA1UdDgQWBBQHMv1OgBn+SVH/1VH+M01R06pFiDAfBgNVHSMEGDAWgBS/+aMLuw1xMGQhE2u7G76ewlJsQDCCARwGA1UdHwSCARMwggEPMIGAoH6gfIZ6aHR0cDovL3ByaW1hcnktY2RuLnBraS5henVyZS5uZXQvd2VzdHVzMy9jcmxzL3Jtc2VydmljZXk2NmZxeW81MGUxN2FuMnFsZHhjYWEvMzMzZmI5MDA1NzhiNDExMjkyZTQ1Zjc0NmRmMDg0YWMvY3VycmVudC5jcmwwgYmggYaggYOGgYBodHRwOi8vcm1zZXJ2aWNleTY2ZnF5bzUwZTE3YW4ycWxkeGNhYS53ZXN0dXMzLnBraS5henVyZS5uZXQvY2VydGlmaWNhdGVBdXRob3JpdGllcy8zMzNmYjkwMDU3OGI0MTEyOTJlNDVmNzQ2ZGYwODRhYy9jdXJyZW50LmNybDCCAaMGCCsGAQUFBwEBBIIBlTCCAZEwgYIGCCsGAQUFBzAChnZodHRwczovL3Jtc2VydmljZXk2NmZxeW81MGUxN2FuMnFsZHhjYWEud2VzdHVzMy5wa2kuYXp1cmUubmV0Ly9jZXJ0aWZpY2F0ZUF1dGhvcml0aWVzLzMzM2ZiOTAwNTc4YjQxMTI5MmU0NWY3NDZkZjA4NGFjMIGGBggrBgEFBQcwAoZ6aHR0cDovL3ByaW1hcnktY2RuLnBraS5henVyZS5uZXQvd2VzdHVzMy9jYWNlcnRzL3Jtc2VydmljZXk2NmZxeW81MGUxN2FuMnFsZHhjYWEvMzMzZmI5MDA1NzhiNDExMjkyZTQ1Zjc0NmRmMDg0YWMvY2VydC5jZXIwgYAGCCsGAQUFBzAChnRodHRwOi8vcm1zZXJ2aWNleTY2ZnF5bzUwZTE3YW4ycWxkeGNhYS53ZXN0dXMzLnBraS5henVyZS5uZXQvY2VydGlmaWNhdGVBdXRob3JpdGllcy8zMzNmYjkwMDU3OGI0MTEyOTJlNDVmNzQ2ZGYwODRhYzAMBggqhkjOPQQDAgUAA0gAMEUCIFRyNgJPTEodx1v9u07iAoOCXQegJcnUgCU+l0Z0Z4GZAiEA7EtDl7k79ghj3MlwbQsgBhB9odmER3s4cewi/mdTFIc="));
#else
            X509Certificate2 extendTo = new X509Certificate2(Convert.FromBase64String("MIIEqzCCBE+gAwIBAgIQD9s3tTRYuDWa74RNLEVKHDAMBggqhkjOPQQDAgUAMCsxKTAnBgNVBAMMIDMzM2ZiOTAwNTc4YjQxMTI5MmU0NWY3NDZkZjA4NGFjMB4XDTI1MDQxNTIwMDgwNloXDTI2MDQxNTIwMDgwNlowKzEpMCcGA1UEAxMgMzMzZmI5MDA1NzhiNDExMjkyZTQ1Zjc0NmRmMDg0YWMwWTATBgcqhkjOPQIBBggqhkjOPQMBBwNCAASrpkgzqmiuH2UerSBcdN1OYKt1j7TtshTi+2cKDkipKWCqGPI0pECecDd6kKip0AhJuN5iB56TLW05csnjs3Sso4IDUTCCA00wEQYDVR0RBAowCIIGUG9saWN5MAwGA1UdEwEB/wQCMAAwEwYDVR0lBAwwCgYIKwYBBQUHAwIwDgYDVR0PAQH/BAQDAgeAMB0GA1UdDgQWBBQHMv1OgBn+SVH/1VH+M01R06pFiDAfBgNVHSMEGDAWgBS/+aMLuw1xMGQhE2u7G76ewlJsQDCCARwGA1UdHwSCARMwggEPMIGAoH6gfIZ6aHR0cDovL3ByaW1hcnktY2RuLnBraS5henVyZS5uZXQvd2VzdHVzMy9jcmxzL3Jtc2VydmljZXk2NmZxeW81MGUxN2FuMnFsZHhjYWEvMzMzZmI5MDA1NzhiNDExMjkyZTQ1Zjc0NmRmMDg0YWMvY3VycmVudC5jcmwwgYmggYaggYOGgYBodHRwOi8vcm1zZXJ2aWNleTY2ZnF5bzUwZTE3YW4ycWxkeGNhYS53ZXN0dXMzLnBraS5henVyZS5uZXQvY2VydGlmaWNhdGVBdXRob3JpdGllcy8zMzNmYjkwMDU3OGI0MTEyOTJlNDVmNzQ2ZGYwODRhYy9jdXJyZW50LmNybDCCAaMGCCsGAQUFBwEBBIIBlTCCAZEwgYIGCCsGAQUFBzAChnZodHRwczovL3Jtc2VydmljZXk2NmZxeW81MGUxN2FuMnFsZHhjYWEud2VzdHVzMy5wa2kuYXp1cmUubmV0Ly9jZXJ0aWZpY2F0ZUF1dGhvcml0aWVzLzMzM2ZiOTAwNTc4YjQxMTI5MmU0NWY3NDZkZjA4NGFjMIGGBggrBgEFBQcwAoZ6aHR0cDovL3ByaW1hcnktY2RuLnBraS5henVyZS5uZXQvd2VzdHVzMy9jYWNlcnRzL3Jtc2VydmljZXk2NmZxeW81MGUxN2FuMnFsZHhjYWEvMzMzZmI5MDA1NzhiNDExMjkyZTQ1Zjc0NmRmMDg0YWMvY2VydC5jZXIwgYAGCCsGAQUFBzAChnRodHRwOi8vcm1zZXJ2aWNleTY2ZnF5bzUwZTE3YW4ycWxkeGNhYS53ZXN0dXMzLnBraS5henVyZS5uZXQvY2VydGlmaWNhdGVBdXRob3JpdGllcy8zMzNmYjkwMDU3OGI0MTEyOTJlNDVmNzQ2ZGYwODRhYzAMBggqhkjOPQQDAgUAA0gAMEUCIFRyNgJPTEodx1v9u07iAoOCXQegJcnUgCU+l0Z0Z4GZAiEA7EtDl7k79ghj3MlwbQsgBhB9odmER3s4cewi/mdTFIc="));
#endif
#if NET8_0_OR_GREATER
            RSA privateKey = RSA.Create();
            privateKey.ImportPkcs8PrivateKey(Convert.FromBase64String("MIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDiTc1kjN9mWlW/\r\nJjgp81hqGNFoNbbFjmxB2oOA6Bcqlh0+kZcwgqjMOHukr8QLMbxCaR/ROsXOTC+7\r\n7dYnUR1BSu33sBM+CT0BDWSomaFwapx9O+42+JJMQcaN50KLQjwfbEv0AyOTrLZO\r\n8jgP4Uxp6fYZ7PrTME64pcJMog8U6A4FZX3hlkSWh1tMDPI8yY9lSPtpc7roLZMJ\r\nS59H5XQ/0HiLTp1wqcnjv/lzCGFkONr97Cp4headknk+3bqFKRjGhaPOozWCTzPq\r\nSdICjZzXvg8QH522fZS2r9dIKh9+F/d+f8PDeA17Mf+Stg3liT5WkpBBZf8x2Dda\r\nsgizdXdZAgMBAAECggEBAIbc9tpFWZ0VmKQhkrbtXnNb9u+zkwiIp9tW7aeUqLmo\r\nXCU9fmxacV3DC2xJkvtY2Gh7XYrDC761iHzmcAlePaD7lnVVaSI/PyuxX5tacusb\r\nncbEQGJiIE1xpXJLr0xuXIYdc+YnOLx44OyLTP2ptnAoDZHFuHTDBSblIbWpnnNF\r\n+DAcTHMRbjrWQXqBo1iSiZIoD0rMRRKpDslzoOyfmB//9mRQ5Sw2A8IqSEERSdiY\r\n4CHjW+xu+uCzq6cqaUGNI5jw8jvnrObKHiiU0cOjduTsZkb374rWuKB+SmQs0c7U\r\nTKlshfk+yRLhPJavGdNjgubXtUIA/37HdWZU8+IsbUECgYEA/4OGsh04YHAWCMHD\r\nqlO230b8nXFAuDm6RaG2AbdFq6BXQDS9274A7wwL15V/qdahIll654Xxw4C46fRQ\r\n0ludDFoZGI5itrtBVTtWOfmTmnLQGsyx+yfGYo5tmE/Ev/sfQnkyvjPvukWu8ggF\r\nTkKC5Wd00HJAnp9KxKOv9I8gdlcCgYEA4rwL6i9aa/zh+30oDLGpEJKYE83b3DMG\r\nU+PzTkcadNSXl4lh0LbIAMD1ZrGiPCe9u9KrYGs353DdQRaY9vnkUc+bI91lCfTx\r\nhWrDY2/t/Av5T+bwr6YPyum1OPnr/lIqIgA054dSMb4zj6PIqCDkbnhu193kcyMG\r\nV3Y7e7Y2Ec8CgYEA96xgVipoyWIcmaRoq6O18bv3hg2PdIPQgUp9CDDEgdZMfNoi\r\n5uvIL+73U6OAOfrn+knODroRXTZbB7xg02cmViDHjrwGB6Z/b8SykkPPxbhg7Hla\r\nVF97t3Dj3u4DgyxCYsbkXuYtC9wb9lO8AN4Lz5525s64wIkbinw4RNCv4MUCgYAs\r\nYHfIhyogdqdYTJ+5FFCtwLNpNOJyT75OTxBA4uPHuBBPhYESk6PDmgCt79h8A588\r\nErieL34Km2mCosSfmjtY09ReiaeL8lgPL908Kh0fNsy+GcpD5rGymllw5GGPLk+2\r\nxemU40RwHfUDiR/t4Do1cPbo4zIiYtmL5sUvqnMcuwKBgBoto6bqeXKgPbGXx3q1\r\nvfUMTQQJnpGauvknNS0rqpAhFLm2lYp9bqbDZSSSVqhtdv/ZcS2/g00moinZrjMa\r\nJdNB3AKk+tcUhTmTfajUb9X9ysTgo2L32R2JTR8WMHIb7LBHTzm7jZzBBg+ouS8E\r\nGTA4/oEjk4hHDNSsnkrtXrdC"), out int bytesread);
#else
            RSA privateKey = RSA.Create();
#endif
            deviceInitializer.UpdateOwnershipVoucher(privateKey, new X509Certificate2Collection(extendTo));
            //save ownershipvoucher
#if NET8_0_OR_GREATER
            voucherBytes = PemEncoding.WriteString("OwnershipVoucher",cborProvider.Serialize(deviceInitializer._ownershipVoucher));
            Console.Write($"OVbytes {voucherBytes.Length}");
            pemFilePath = $"C:\\Users\\shkuang\\Downloads\\extended-{creds.DeviceGuid}";
            File.WriteAllText(pemFilePath, voucherBytes);
#endif
            //var rvServers = Sample_DeviceOnboarding.GetServerInstructions(creds.DeviceRVInfo, true, cborProvider);
            //Console.WriteLine($"{rvServers.Count} instructions: {rvServers}");
            //TO2OwnerInfo ownerInfo;
            //for (var i = 0; i<rvServers.Count; i++)
            //{
            //    var deviceDiscoverer = client.GetDeviceDiscoverer(rvServers[i]);
            //    try
            //    {
            //        ownerInfo = await deviceDiscoverer.GetOwnerInfoAsync();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"{ex.Message},{ex.StackTrace}");
            //        Console.WriteLine("Moving to next rv entry");
            //    }
            //}
            //throw new Exception("sanity check");
        }
    }
}
