// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.NetApp.Tests.Helpers;
using Azure.ResourceManager.Resources;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.ResourceManager.NetApp.Tests
{
    public class ANFBucketTests : NetAppTestBase
    {
        private string _pool1Name = "pool1";
        private NetAppAccountCollection _netAppAccountCollection { get => _resourceGroup.GetNetAppAccounts(); }
        internal NetAppBucketCollection _bucketCollection;
        internal NetAppVolumeResource _volumeResource;
        internal string _selfSignedCertificate;

        //private NetAppBucketCollection _netAppBucketCollection { get => _resourceGroup.GetNetAppBuckets(); }
        public ANFBucketTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            Console.WriteLine("ANFBucketTests Setup");
            string volumeName = Recording.GenerateAssetName("volumeName-");
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync(_accountNamePrefix, _resourceGroup, DefaultLocation);
            _selfSignedCertificate = CreateSelfSignedCertificate();
            _netAppAccount = (await _netAppAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultNetAppAccountParameters())).Value;

            CapacityPoolData capactiyPoolData = new(DefaultLocation, _poolSize.Value, NetAppFileServiceLevel.Premium);
            capactiyPoolData.Tags.InitializeFrom(DefaultTags);
            _capacityPool = (await _capacityPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, _pool1Name, capactiyPoolData)).Value;

            _volumeCollection = _capacityPool.GetNetAppVolumes();

            await CreateVirtualNetwork();
            _volumeResource = await CreateVolume(DefaultLocation, NetAppFileServiceLevel.Premium, _defaultUsageThreshold, subnetId: DefaultSubnetId, volumeName: volumeName);
            Console.WriteLine("VolumeTEST Setup create vnet");
            _bucketCollection = _volumeResource.GetNetAppBuckets();
            Console.WriteLine("ANFBucketTests Setup complete");
        }

        [TearDown]
        public async Task ClearBuckets()
        {
            //remove all buckets under current netAppAccount and remove netAppAccount
            if (_resourceGroup != null)
            {
                await foreach (NetAppBucketResource bucket in _bucketCollection.GetAllAsync())
                {
                    // invoke the operation
                    await bucket.DeleteAsync(WaitUntil.Completed);
                }
                //remove volumes
                await foreach (NetAppVolumeResource volume in _volumeCollection.GetAllAsync())
                {
                    // invoke the operation
                    await volume.DeleteAsync(WaitUntil.Completed);
                }
                //remove capacityPools
                await foreach (CapacityPoolResource capacityPool in _capacityPoolCollection.GetAllAsync())
                {
                    // invoke the operation
                    await capacityPool.DeleteAsync(WaitUntil.Completed);
                }
                //remove account
                await LiveDelay(40000);
                await _netAppAccount.DeleteAsync(WaitUntil.Completed);
            }
            _resourceGroup = null;
        }

        [RecordedTest]
        public async Task CreateGetDeleteBucket()
        {
            //create snapshot
            var bucketName = Recording.GenerateAssetName("bucket-");
            await SetUp();

            NetAppBucketData data = new NetAppBucketData
            {
                Path = "/path",
                FileSystemUser = new FileSystemUser
                {
                    NfsUser = new NfsUser
                    {
                        UserId = 1001L,
                        GroupId = 1000L,
                    },
                },
                Server = new NetAppBucketServerProperties
                {
                    Fqdn = "fullyqualified.domainname.com",
                    CertificateObject = _selfSignedCertificate,
                },
                Permissions = NetAppBucketPermission.ReadOnly,
            };
            ArmOperation<NetAppBucketResource> lro = await _bucketCollection.CreateOrUpdateAsync(WaitUntil.Completed, bucketName, data);
            NetAppBucketResource result = lro.Value;

            // the variable result is a resource
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(bucketName, result.Data.Name);
            Console.WriteLine($"Create Succeeded on id: {result.Data.Id}");

            // get the created resource
            NetAppBucketResource netAppBucket = Client.GetNetAppBucketResource(result.Data.Id);
            Assert.IsNotNull(netAppBucket.Data);
            Assert.AreEqual(bucketName, netAppBucket.Data.Name);
            Console.WriteLine($"GET Succeeded on id: {netAppBucket.Data.Id}");

            // invoke the delete operation
            await netAppBucket.DeleteAsync(WaitUntil.Completed);
            Console.WriteLine($"Delete Succeeded on id: {netAppBucket.Data.Id}");

            bool existsResult = await _bucketCollection.ExistsAsync(bucketName);
            existsResult.Should().BeFalse();
            Console.WriteLine($"Succeeded: {existsResult}");
        }

        [RecordedTest]
        public async Task ListBuckets()
        {
            //create bucket
            var bucketName = Recording.GenerateAssetName("bucket-");
            var bucket2Name = Recording.GenerateAssetName("bucket-2");
            await SetUp();

            NetAppBucketData data = new NetAppBucketData
            {
                Path = "/path",
                FileSystemUser = new FileSystemUser
                {
                    NfsUser = new NfsUser
                    {
                        UserId = 1001L,
                        GroupId = 1000L,
                    },
                },
                Server = new NetAppBucketServerProperties
                {
                    Fqdn = "fullyqualified.domainname.com",
                    CertificateObject = _selfSignedCertificate,
                },
                Permissions = NetAppBucketPermission.ReadOnly,
            };

            NetAppBucketData data2 = new NetAppBucketData
            {
                Path = "/path2",
                FileSystemUser = new FileSystemUser
                {
                    NfsUser = new NfsUser
                    {
                        UserId = 1001L,
                        GroupId = 1000L,
                    },
                },
                Server = new NetAppBucketServerProperties
                {
                    Fqdn = "fullyqualified.domainname.com",
                    CertificateObject = "<REDACTED>",
                },
                Permissions = NetAppBucketPermission.ReadOnly,
            };
            ArmOperation<NetAppBucketResource> lro = await _bucketCollection.CreateOrUpdateAsync(WaitUntil.Completed, bucketName, data);
            NetAppBucketResource result = lro.Value;

            ArmOperation<NetAppBucketResource> lro2 = await _bucketCollection.CreateOrUpdateAsync(WaitUntil.Completed, bucket2Name, data2);
            NetAppBucketResource result2 = lro2.Value;

            // Define a list to store results
            List<NetAppBucketResource> buckets = [];
            // invoke the List operation and iterate over the result
            await foreach (NetAppBucketResource item in _bucketCollection.GetAllAsync())
            {
                buckets.Add(item);
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {item.Id}");
            }
            Assert.GreaterOrEqual(buckets.Count, 2);
            Assert.IsTrue(buckets.Any(r => r.Data.Name == bucketName));
            Assert.IsTrue(buckets.Any(r => r.Data.Name == bucket2Name));
        }

        [RecordedTest]
        public async Task PatchBucket()
        {
            //create snapshot
            var bucketName = Recording.GenerateAssetName("bucket-");
            await SetUp();

            NetAppBucketData data = new NetAppBucketData
            {
                Path = "/path",
                FileSystemUser = new FileSystemUser
                {
                    NfsUser = new NfsUser
                    {
                        UserId = 1001L,
                        GroupId = 1000L,
                    },
                },
                Server = new NetAppBucketServerProperties
                {
                    Fqdn = "fullyqualified.domainname.com",
                    CertificateObject = _selfSignedCertificate,
                },
                Permissions = NetAppBucketPermission.ReadOnly,
            };
            ArmOperation<NetAppBucketResource> lro = await _bucketCollection.CreateOrUpdateAsync(WaitUntil.Completed, bucketName, data);
            NetAppBucketResource result = lro.Value;

            // the variable result is a resource
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(bucketName, result.Data.Name);
            Console.WriteLine($"Create Succeeded on id: {result.Data.Id}");

            // get the created resource
            NetAppBucketResource netAppBucket = Client.GetNetAppBucketResource(result.Data.Id);
            Assert.IsNotNull(netAppBucket.Data);
            Assert.AreEqual(bucketName, netAppBucket.Data.Name);
            Console.WriteLine($"GET Succeeded on id: {netAppBucket.Data.Id}");

            string expectedFqdn = "updatedfullyqualified.domainname.com";
            // invoke the operation
            NetAppBucketPatch patch = new NetAppBucketPatch
            {
                Server = new NetAppBucketServerPatchProperties
                {
                    Fqdn = expectedFqdn,
                    CertificateObject = _selfSignedCertificate,
                },
                Permissions = NetAppBucketPatchPermission.ReadWrite,
            };
            ArmOperation<NetAppBucketResource> lroUpdate = await netAppBucket.UpdateAsync(WaitUntil.Completed, patch);
            NetAppBucketResource updateResult = lroUpdate.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            NetAppBucketData resourceData = updateResult.Data;

            resourceData.Id.Should().Be(netAppBucket.Data.Id);
            resourceData.Name.Should().Be(netAppBucket.Data.Name);
            resourceData.Server.Fqdn.Should().Be(expectedFqdn);
        }

        [RecordedTest]
        public async Task GenerateCredentialsForBucket()
        {
            //create snapshot
            var bucketName = Recording.GenerateAssetName("bucket-");
            await SetUp();

            NetAppBucketData data = new NetAppBucketData
            {
                Path = "/path",
                FileSystemUser = new FileSystemUser
                {
                    NfsUser = new NfsUser
                    {
                        UserId = 1001L,
                        GroupId = 1000L,
                    },
                },
                Server = new NetAppBucketServerProperties
                {
                    Fqdn = "fullyqualified.domainname.com",
                    CertificateObject = _selfSignedCertificate,
                },
                Permissions = NetAppBucketPermission.ReadOnly,
            };
            ArmOperation<NetAppBucketResource> lro = await _bucketCollection.CreateOrUpdateAsync(WaitUntil.Completed, bucketName, data);
            NetAppBucketResource result = lro.Value;

            // the variable result is a resource
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(bucketName, result.Data.Name);
            Console.WriteLine($"Create Succeeded on id: {result.Data.Id}");

            // get the created resource
            NetAppBucketResource netAppBucket = Client.GetNetAppBucketResource(result.Data.Id);
            Assert.IsNotNull(netAppBucket.Data);
            Assert.AreEqual(bucketName, netAppBucket.Data.Name);
            Console.WriteLine($"GET Succeeded on id: {netAppBucket.Data.Id}");

            // invoke the operation
            NetAppBucketCredentialsExpiry body = new NetAppBucketCredentialsExpiry
            {
                KeyPairExpiryDays = 3,
            };
            NetAppBucketGenerateCredentials GenerateCredentialsResult = await netAppBucket.GenerateCredentialsAsync(body);

            NetAppBucketGenerateCredentials credentials = GenerateCredentialsResult;
            credentials.Should().NotBeNull();
            credentials.AccessKey.Should().NotBeNullOrEmpty();
            credentials.SecretKey.Should().NotBeNullOrEmpty();
        }

        private string CreateSelfSignedCertificate(string subjectName = "CN=TestCertificate", int validityPeriodInYears = 1)
        {
            return "-----BEGIN CERTIFICATE-----\nMIIBvzCCAUSgAwIBAgIUUYG5m2lzI5X88E3XLxMaVwJqolMwCgYIKoZIzj0EAwMw\nFjEUMBIGA1UEAwwLcGV0ZXJ3YWxrZXIwHhcNMjMwNTAxMTk1NjU3WhcNMjQwNDMw\nMTk1NjU3WjAWMRQwEgYDVQQDDAtwZXRlcndhbGtlcjB2MBAGByqGSM49AgEGBSuB\nBAAiA2IABH0CJdl/ZvmaLLDlkNU6gX56kKVP2pQDIr4NUVRe31Aycqa9Q5md1sBl\nE+e3c9hd5bz+Rjfok4uOaYvOWsr9EKbofzU4ztGWD5r2a6yvdbnmw7sjjoy2NN/N\nIOd0yW4pIKNTMFEwHQYDVR0OBBYEFEdO7YFlqF76lPXDwGOukMf9EVDFMB8GA1Ud\nIwQYMBaAFEdO7YFlqF76lPXDwGOukMf9EVDFMA8GA1UdEwEB/wQFMAMBAf8wCgYI\nKoZIzj0EAwMDaQAwZgIxAIv8BymJGDm4vQW/H6UvjXHfa6AA8+BhBUWYjq6vnRbj\nPP1phtfbnXOh3+6ACXMSZgIxANzw0ofI6ZMe36URpjiaRrAd9ubf9aG1sLMN3Amx\nr/CZgiIZe7uZuvi0UYtf0ZoeNw==\n-----END CERTIFICATE-----";
        }

        //     // Generate RSA key pair
            //     using (RSA rsa = RSA.Create())
            //     {
            //         rsa.KeySize = 2048;
            //         var certificateRequest = new CertificateRequest(
            //             subjectName,
            //             rsa,
            //             HashAlgorithmName.SHA256,
            //             RSASignaturePadding.Pkcs1);

            //         // Add basic constraints (self-signed, no CA)
            //         certificateRequest.CertificateExtensions.Add(
            //             new X509BasicConstraintsExtension(false, false, 0, false));

            //         // Add key usage (digital signature, key encipherment)
            //         certificateRequest.CertificateExtensions.Add(
            //             new X509KeyUsageExtension(
            //                 X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.KeyEncipherment,
            //                 false));

            //         // Add subject key identifier
            //         certificateRequest.CertificateExtensions.Add(
            //             new X509SubjectKeyIdentifierExtension(certificateRequest.PublicKey, false));

            //         // Create the self-signed certificate
            //         var certificate = certificateRequest.CreateSelfSigned(
            //             DateTimeOffset.Now,
            //             DateTimeOffset.Now.AddYears(validityPeriodInYears));

            //         // Export certificate as PEM
            //         certificateString = ExportToPem(certificate);
            //     }
            //     return certificateString;
            // }

            // private static string ExportToPem(X509Certificate2 certificate)
            // {
            //     // Export the certificate as Base64
            //     byte[] certBytes = certificate.Export(X509ContentType.Cert);
            //     string base64Cert = Convert.ToBase64String(certBytes);

            //     // Format as PEM
            //     StringBuilder pem = new StringBuilder();
            //     pem.AppendLine("-----BEGIN CERTIFICATE-----");
            //     for (int i = 0; i < base64Cert.Length; i += 64)
            //     {
            //         pem.AppendLine(base64Cert.Substring(i, Math.Min(64, base64Cert.Length - i)));
            //     }
            //     pem.AppendLine("-----END CERTIFICATE-----");

            //     return pem.ToString();
            // }
        }
}
