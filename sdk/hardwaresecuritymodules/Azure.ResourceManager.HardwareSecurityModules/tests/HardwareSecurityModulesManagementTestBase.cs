// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
#if !NETFRAMEWORK
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
#endif
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.HardwareSecurityModules.Tests
{
    public class HardwareSecurityModulesManagementTestBase : ManagementRecordedTestBase<HardwareSecurityModulesManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected HardwareSecurityModulesManagementTestEnvironment testEnvironment => TestEnvironment;
        protected AzureLocation Location;
        protected ResourceGroupResource ResourceGroupResource { get; private set; }
        protected GenericResourceCollection GenericResourceCollection { get; private set; }

        protected HardwareSecurityModulesManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected HardwareSecurityModulesManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task BaseSetUpForTests(bool isDedicatedHsm = false, bool isPaymentHsm = false)
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();
            }
            //TODO will initialize resource groups here as well
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
            Location = isDedicatedHsm ? AzureLocation.NorthCentralUS
                : isPaymentHsm ? new AzureLocation("centraluseuap")
                : AzureLocation.UKWest;
            GenericResourceCollection = Client.GetGenericResources();
            ResourceGroupResource = await CreateResourceGroup(DefaultSubscription, "chsmSdkTest", Location);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(AzureLocation.EastUS);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        /// <summary>
        /// Creates a self-signed CA certificate and returns it as a base64 encoded DER blob, which is the
        /// format expected by the Payment HSM Cluster trusted issuer properties.
        /// </summary>
        protected static string GetValidClientTrustCaBase64()
        {
#if NETFRAMEWORK
            // CertificateRequest is not available in the net462 reference assemblies.
            throw new PlatformNotSupportedException("Generating the Payment HSM trusted issuer certificate requires .NET Core or later.");
#else
            using var ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);
            var request = new CertificateRequest("CN=Payment HSM Test Client Trust CA", ecdsa, HashAlgorithmName.SHA256);
            request.CertificateExtensions.Add(new X509BasicConstraintsExtension(certificateAuthority: true, hasPathLengthConstraint: false, pathLengthConstraint: 0, critical: true));
            request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.CrlSign, critical: true));
            using var certificate = request.CreateSelfSigned(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(5));
            return Convert.ToBase64String(certificate.Export(X509ContentType.Cert));
#endif
        }
    }
}
