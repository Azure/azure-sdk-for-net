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
                await LiveDelay(40000);
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
            //await SetUp();

            NetAppBucketData data = new NetAppBucketData
            {
                Path = "/",
                FileSystemUser = new BucketFileSystemUser
                {
                    NfsUser = new BucketNfsUser
                    {
                        UserId = 1001L,
                        GroupId = 1000L,
                    },
                },
                Server = new NetAppBucketServerProperties
                {
                    Fqdn = "www.acme.com",
                    CertificateObject = _selfSignedCertificate,
                },
                Permissions = NetAppBucketPermission.ReadOnly,
            };
            ArmOperation<NetAppBucketResource> lro = await _bucketCollection.CreateOrUpdateAsync(WaitUntil.Completed, bucketName, data);
            NetAppBucketResource result = lro.Value;

            // the variable result is a resource
            Assert.IsNotNull(result.Data);
            Assert.AreEqual($"{_volumeResource.Data.Name}/{bucketName}", result.Data.Name);
            Console.WriteLine($"Create Succeeded on id: {result.Data.Id}");

            // get the created resource
            NetAppBucketResource netAppBucket = Client.GetNetAppBucketResource(result.Data.Id);
            // invoke the operation
            NetAppBucketResource bucketResult = await netAppBucket.GetAsync();
            string bucketResourceName = bucketResult.Data.Name;

            Assert.IsNotNull(bucketResult.Data);
            Assert.AreEqual($"{_volumeResource.Data.Name}/{bucketName}", bucketResult.Data.Name);
            Console.WriteLine($"GET Succeeded on id: {bucketResult.Data.Id}");

            // invoke the delete operation
            await netAppBucket.DeleteAsync(WaitUntil.Completed);
            Console.WriteLine($"Delete Succeeded on id: {bucketResult.Data.Id}");

            Console.WriteLine($"Check if exists: {bucketResourceName}");
            //check if the bucket exists
            await LiveDelay(30000);
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
                Path = "/",
                FileSystemUser = new BucketFileSystemUser
                {
                    NfsUser = new BucketNfsUser
                    {
                        UserId = 1001L,
                        GroupId = 1000L,
                    },
                },
                Server = new NetAppBucketServerProperties
                {
                    Fqdn = "www.acme.com",
                    CertificateObject = _selfSignedCertificate,
                },
                Permissions = NetAppBucketPermission.ReadOnly,
            };

            NetAppBucketData data2 = new NetAppBucketData
            {
                Path = "/",
                FileSystemUser = new BucketFileSystemUser
                {
                    NfsUser = new BucketNfsUser
                    {
                        UserId = 1001L,
                        GroupId = 1000L,
                    },
                },
                Server = new NetAppBucketServerProperties
                {
                    Fqdn = "www.acme.com",
                    CertificateObject = _selfSignedCertificate,
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
            Assert.IsTrue(buckets.Any(r => r.Data.Name.Split('/').Last() == bucketName));
            Assert.IsTrue(buckets.Any(r => r.Data.Name.Split('/').Last() == bucket2Name));
        }

        [RecordedTest]
        public async Task PatchBucket()
        {
            //create snapshot
            var bucketName = Recording.GenerateAssetName("bucket-");
            await SetUp();

            NetAppBucketData data = new NetAppBucketData
            {
                Path = "/",
                FileSystemUser = new BucketFileSystemUser
                {
                    NfsUser = new BucketNfsUser
                    {
                        UserId = 1001L,
                        GroupId = 1000L,
                    },
                },
                Server = new NetAppBucketServerProperties
                {
                    Fqdn = "www.acme.com",
                    CertificateObject = _selfSignedCertificate,
                },
                Permissions = NetAppBucketPermission.ReadOnly,
            };
            ArmOperation<NetAppBucketResource> lro = await _bucketCollection.CreateOrUpdateAsync(WaitUntil.Completed, bucketName, data);
            NetAppBucketResource result = lro.Value;

            // the variable result is a resource
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(bucketName, result.Data.Name.Split('/').Last());
            Console.WriteLine($"Create Succeeded on id: {result.Data.Id}");

            // get the created resource
            NetAppBucketResource netAppBucket = Client.GetNetAppBucketResource(result.Data.Id);
            // invoke the operation
            NetAppBucketResource bucketResult = await netAppBucket.GetAsync();
            Assert.IsNotNull(bucketResult.Data);
            Assert.AreEqual(bucketName, bucketResult.Data.Name.Split('/').Last());
            Console.WriteLine($"GET Succeeded on id: {bucketResult.Data.Id}");

            // invoke the operation
            NetAppBucketPatch patch = new NetAppBucketPatch
            {
                Permissions = NetAppBucketPatchPermission.ReadWrite
            };
            ArmOperation<NetAppBucketResource> lroUpdate = await netAppBucket.UpdateAsync(WaitUntil.Completed, patch);
            NetAppBucketResource updateResult = lroUpdate.Value;
            Assert.IsNotNull(updateResult.Data);
            await LiveDelay(30000);
            NetAppBucketResource updateResultData = await netAppBucket.GetAsync();

            updateResultData.Id.Should().Be(bucketResult.Data.Id);
            updateResult.Data.Name.Should().Be(bucketResult.Data.Name);
            updateResult.Data.ProvisioningState.Should().Be(NetAppProvisioningState.Succeeded);
            //updateResultData.Data.Permissions.Should().Be(NetAppBucketPatchPermission.ReadWrite);
        }

        [RecordedTest]
        public async Task GenerateCredentialsForBucket()
        {
            //create snapshot
            var bucketName = Recording.GenerateAssetName("bucket-");
            await SetUp();

            NetAppBucketData data = new NetAppBucketData
            {
                Path = "/",
                FileSystemUser = new BucketFileSystemUser
                {
                    NfsUser = new BucketNfsUser
                    {
                        UserId = 1001L,
                        GroupId = 1000L,
                    },
                },
                Server = new NetAppBucketServerProperties
                {
                    Fqdn = "www.acme.com",
                    CertificateObject = _selfSignedCertificate,
                },
                Permissions = NetAppBucketPermission.ReadOnly,
            };
            ArmOperation<NetAppBucketResource> lro = await _bucketCollection.CreateOrUpdateAsync(WaitUntil.Completed, bucketName, data);
            NetAppBucketResource result = lro.Value;

            // the variable result is a resource
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(bucketName, result.Data.Name.Split('/').Last());
            Console.WriteLine($"Create Succeeded on id: {result.Data.Id}");

            // get the created resource
            NetAppBucketResource netAppBucket = Client.GetNetAppBucketResource(result.Data.Id);
            NetAppBucketResource resultData = await netAppBucket.GetAsync();
            Assert.IsNotNull(resultData.Data);
            Assert.AreEqual(bucketName, resultData.Data.Name.Split('/').Last());
            Console.WriteLine($"GET Succeeded on id: {resultData.Data.Id}");

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
            return @"LS0tLS1CRUdJTiBDRVJUSUZJQ0FURS0tLS0tCk1JSUZEekNDQXZlZ0F3SUJBZ0lVTTF2bUZFNHZNU1k4MUFDaTBMNVBqbFlmWXgwd0RRWUpLb1pJaHZjTkFRRUwKQlFBd0Z6RVZNQk1HQTFVRUF3d01kM2QzTG1GamJXVXVZMjl0TUI0WERUSTFNRFl4TWpFMU5ESTBObG9YRFRJMgpNRFl4TWpFMU5ESTBObG93RnpFVk1CTUdBMVVFQXd3TWQzZDNMbUZqYldVdVkyOXRNSUlDSWpBTkJna3Foa2lHCjl3MEJBUUVGQUFPQ0FnOEFNSUlDQ2dLQ0FnRUFzanQ1ZHdvWkx0YWpWT2VtTWtBSFVyMys3U0llVFBORzJvVU4KbERBVXRHRVRzOUgwY2VMMGhzZlA4bmxHbUNEZzFiM3NjcjdHekpTMmEyMm9FR0g3VVFhbmhNeFBhdGVrd2FJRwovSmh1VjVWMURkZjdLa1dibUFwQVNDUWZPMTNUOFlXTDY0UnZaQ3F1K0VMMi9WeWRmSEx4ejNXNXBNMHB2K3JhClFLK0lXVDJQTzZYRjBqNTlQcE9wV1l1bGVSQXpjOE9HVDNEUmtEY25oU2ZIRWQ5bG1jWGhhSHVnc1JualFUVWYKdmpDZHVHZEFtcHFheEx4cERReWtGbmI1VlpsNUFNN3lNTW9mUkVVVEo0a1FVUVlWdjliQ1p5V2s1MTNqR0pvTQpZZEs3d2xQRTNtaTZObEtuV0REYkhmU1FUdzhtUjFiaTBodnNnd3o2Vm80SWI2YTFHTFdZT3lJcHI1V2o0MVRJCm9aWXA2UDdDVDY3Unhud2s1aWY2ejU1R1hxTDhHQkNhR0IxNHoxcUtZR0x4QkZ1S2MzYjBCbEYreUE0TDRRRlEKVkJsRThSR3FvMWlOeDdJeEQydk9xQzc5TnlJdXNCYThMbFovdExjQUp4V1VEOTVQVFlhbnpVZHBVZ3BIODkvVQpYc2lBdUVDb2NIYUNwNkxhdFU3SCtRQXQ3bTh6NEtTTHpnWk5tR0dwK24vWlhGYjB0c3gzRkxkUjZXMk9FRmFtClpXdHN6QkY0NjVBa0wwcVhxMEZOZzFwekNsUitwalNTOGhHWGRDS3NIWldMakFmNU5CUE5PVDJRTW1zL1dFZVYKMUwrOGIrTDBlVGZXV3dJa0lLV1dkT0ZmRUxFbmFqYVBuZXJzSlRoZTRIT1dJMGtlRDJmaG1YTVQ3Ynp6ZGZKTgpKcWxHWjlrQ0F3RUFBYU5UTUZFd0hRWURWUjBPQkJZRUZOa3A5a05ISzZmaEtKNnRaK2kzUlpCWmxoTUFNQjhHCkExVWRJd1FZTUJhQUZOa3A5a05ISzZmaEtKNnRaK2kzUlpCWmxoTUFNQThHQTFVZEV3RUIvd1FGTUFNQkFmOHcKRFFZSktvWklodmNOQVFFTEJRQURnZ0lCQUZFSGUxRHFpNXNRS0wvSmR2MTNIcEhyVkNoR0x6dGtxTHFwT0MyVgpyMWJUSzVUSWJCbW5CcEdQS3poQkU3bVF5MlFlWkZkT2c3RTRGblRVNzQ4eEtsWE04WkwrOFNWbDFLdlZaRkxjCkV0QWpqLzIwZE12N3JUVyt0UVhvVnBkZ1Q3OVVzMHpyVTJ2cVFJVFBWRE9GNjhickFtVkpsSzQyV1NELzh5YWcKL2VWSGpPUGkrQ3hodWJFOFR3NlBtVzkxOFM0QmNFQVF6Z0h3OVF0UWJxTzBlVWJ1OGdyV1lYbmlDcllhVmlVVApRY0VBTzF4cStpeFhtQ2o1VkFVQzlab211Z1VHNWlNZmM4dGdPQ0NpV092MldOM2NNNzNYV3IyekhLblBQOEZWCmJRVTZUM1Vwa3FDVGR4UnVkY3AyN1UvZ1ZkZ0szcVdIUTlOSnBhSmVRVDhKSTdMMDVFVFlObjRMeXYzSzVaWDUKRWJuZmxPNUljY1QzSG5Gby8vSk5aU2s1NTJmUHc0Q0d1blcrU3JNRE1iYk4rSzRTS3FMOXV6VEc5ZXBmN1NLZwpwRktyVmtQTDFPa3dmNDdmdy9LK1lTY0tWaGpWL1RTWVFjOUlNTUxpUXNsTExrMkFCQm41NDJwdjdqWGRqcllvCk50YTlnMjY5SzZjaG0zcXN1RG1lRkczSFYrRE9wUGh4dmRkdzRHUVdQNmZXLzZFeW45Y1RIZjZuZFdieEVGSWMKZ2VHYWF3SjlQR2ZKZnpPRDFPVkpDMTZsMEVrK3NiWVY3M0ZJM3VaR2pFYUVxTGZLanNMYjludUU5Q2JwbE1QMQp4c3F0WWpKWFJvSkdLVFpkOGNIVE5CbysxYzN6NzNjWEp6UDFwN1VWQUtmaDdGZ1NOWkJrbnB5YnZEeGVkOExuCkxCRFoKLS0tLS1FTkQgQ0VSVElGSUNBVEUtLS0tLQotLS0tLUJFR0lOIFBSSVZBVEUgS0VZLS0tLS0KTUlJSlF3SUJBREFOQmdrcWhraUc5dzBCQVFFRkFBU0NDUzB3Z2drcEFnRUFBb0lDQVFDeU8zbDNDaGt1MXFOVQo1Nll5UUFkU3ZmN3RJaDVNODBiYWhRMlVNQlMwWVJPejBmUng0dlNHeDgveWVVYVlJT0RWdmV4eXZzYk1sTFpyCmJhZ1FZZnRSQnFlRXpFOXExNlRCb2diOG1HNVhsWFVOMS9zcVJadVlDa0JJSkI4N1hkUHhoWXZyaEc5a0txNzQKUXZiOVhKMThjdkhQZGJta3pTbS82dHBBcjRoWlBZODdwY1hTUG4wK2s2bFppNlY1RUROenc0WlBjTkdRTnllRgpKOGNSMzJXWnhlRm9lNkN4R2VOQk5SKytNSjI0WjBDYW1wckV2R2tOREtRV2R2bFZtWGtBenZJd3loOUVSUk1uCmlSQlJCaFcvMXNKbkphVG5YZU1ZbWd4aDBydkNVOFRlYUxvMlVxZFlNTnNkOUpCUER5WkhWdUxTRyt5RERQcFcKamdodnByVVl0Wmc3SWltdmxhUGpWTWlobGluby9zSlBydEhHZkNUbUovclBua1plb3Z3WUVKb1lIWGpQV29wZwpZdkVFVzRwemR2UUdVWDdJRGd2aEFWQlVHVVR4RWFxaldJM0hzakVQYTg2b0x2MDNJaTZ3RnJ3dVZuKzB0d0FuCkZaUVAzazlOaHFmTlIybFNDa2Z6MzlSZXlJQzRRS2h3ZG9Lbm90cTFUc2Y1QUMzdWJ6UGdwSXZPQmsyWVlhbjYKZjlsY1Z2UzJ6SGNVdDFIcGJZNFFWcVpsYTJ6TUVYanJrQ1F2U3BlclFVMkRXbk1LVkg2bU5KTHlFWmQwSXF3ZApsWXVNQi9rMEU4MDVQWkF5YXo5WVI1WFV2N3h2NHZSNU45WmJBaVFncFpaMDRWOFFzU2RxTm8rZDZ1d2xPRjdnCmM1WWpTUjRQWitHWmN4UHR2UE4xOGswbXFVWm4yUUlEQVFBQkFvSUNBQnZtTGhWRzEyVDY1RER6aHozR2JWOEoKQS92MVRlNURCb3hJMTRuNEhNV1U0ZWltck5wRzZjLzU1eFhRTmc5ZmdOSkp4ZGE3QU9qS2srT0NhV204YkswNgpSVzZ4Z2ZKUGlkSzY4aTBJRDFNQkZObWQ2QXNEUDdVdnBacjZvZDVCSHdsbmNOemxBTlZ2emxrVGpSQzJpL3NNCll4MnBFcGpoZWUrT0ZsYVp6aXRwOU1uT3k5c2xQUHNCVWprRXl3VGJBYkxWU3hPVVdBN052ZzlITXJvY0pnMzAKRTdJRWtzVjdoVDg5SkVMajNxSEc4b05BNnQ1dzZtRElqSEdYeUxVYTJQNGFFWDgyK2IzNHNnN2c2RlR4TVpFSQpwUUJRWnQwYlYrTzUrWERoU1NnYUdobXIwR1RySmV3cXp2Y3V3OTF4bWFSV2VCcm1Qc0lrMDBCSlFMak96UG9BCktsMHZNNXNKdVB6STJTeWF6RnlVM1ovaWw2MzJHM2pMa2l0c1hBdHlmTTN5VEF2KzhCT1RSSTY4aXpOQmptbHYKQVNkRlZLQTF4cndmUFF2VXlYWnUwd2JUU0MwU2oxcmlUcERJMUl6NnQ1bndlUlVRNm1qSHg0OTAyS0liM2NjYQpoVEE0dnRtUjdackN0blE3YUpNa3o2REcxbUk1N0NiS0JKV2h6S0JtNTEwQVV5UGZsTFdGSGhXM1Z0N3BnVFo2CjRibjRaM1p1K1NBOFh4cUtDMmEyTENPRlkvZWY2UXhmUTlyekFHSWRzbzJzKzJsTENCV09kNXAvVyt2aC9oTU8KTWZYS0piRWYwSGpBTVVId3FvbUNUZmdSRU0xVkZ4U3JOeXRGUGs1NFdiOE5rOUh1Q1hQczlSazA1bUE0c2k5UQorOXR4U0psYzU0L3BQYnJqOXVFaEFvSUJBUUMyalBqUzFtYzJWVUhjaFVCdWVVZUFuMFRLdCswR3JlWTlwd0doCnduVFE5TEhvYU9xUUt0Vkc2VTUyYVQ4UUdpVHBpR3dNakJsSkQzNGlsN0o0cnBjNk9xRytkeTZYM29lcnl4TVIKRnlBN3VxWncvbTBzaEZORzNnK2t5R1hybE1KOU5yUnE4OHN5QlM1eVBvb2JHRkNORW9VQS9QT2lVaWROSm9mYQpVaDJzMmNuMnZWUzlDV1lwMGY0SWxTRXdYRm5VdStuc1dpYlVLSXFSam85SlRtRHcrdU5OZFFtNXhIb3ZpSlRkCnlYR3NONTFDdDFpVS9US3Q2ZnZBUHNrRXF2Q3VtcElQMjFEeXI0ejhsZ2Jyd3l4bXJoUW5yVVJkRUc1SmREcDUKVHdGL24xaktHK202bDJ4ejZEYmE2eVVValFDKzk4TzFjRjZ5bHVxQkJHcENidGN2QW9JQkFRRDU4YlNIZUVybQpzV3ZhM2lrNWJ2ZE9QRmdsRDJOVVd5VUJSeStsSjQyZ0RBdmdteWttN0RtK1lab3ViYkNkREZqL2V5YVZ0QTd2CklxdEJZUHNtejI3YzI1b3FoRUdIQTNpOFltWW1uYjRsbjZSTUIzdE8zSFlVT2J2MnY4Yy91WGlIbzBVN1lEMngKSnhxN05xRjFINlA5ZzlBbHNGVUl3a3hmTFA4UUc4YjBtWG0weWs5TGNxYVBkZVRvRkZ5dUpSdGlpQUY3UnZwbgpPM3hRL09tclFPL0hjeldzUE9WenkxMlVsMzROeUFOUGxzNGhXQlVacm9tUGxKZFB5R09CZmxEdU9RSXRPRzBECklzZFpwOWdwUFZvT2ZQZ25COG9KaEZCcUZEbVFlNk1YUFo1aU11YW1mMlVYMGI0SzNzVkVBdnVNZkdQeitON1MKK1FGNVZCUWgvVzkzQW9JQkFRQ2c4T3BTWDRwQllhc2VNekNaOVR5dnpqc0ZDbURqT1orNmpTbW9KbHQ4K2E1NworenVKZk9ucGlibU9OYjNPZ1c0M29mbTRtaStVdFI3OGVvZHpWR0dwaVpXZDZVOWZ2MllYZElOTDF2cXBEaWE5CmllSlFsQjBqWnBXZUxydUVsZk5lRjBPNjQxTXF0MXk2aGg2V1FycUpsV0ZEZkwrRFJUQzNHUmcreDVTNEZvNnoKaFRwWEt4a3lGNXdDancvaXBoamdzQWROUkRIbGJCUzJ2VnZnUWtTL1VFSGp3U0tnNy9MVlEzSVRrdzB2eXh4UApmSHVSWnlVdUpSSzU2K0NueDlsSDVxaU5hRXNXbXVVT3IycE1veGJiTS9BN0JzdzF6RTJmWHVSS25QZnlQMWMxCllLU1F4LzFxdHJqZUN0LzNIVlVpQ0NnNEoyaWx4TjNjZnpyN2RPTXJBb0lCQVFDWXJHdjUxQ0RzaWJPNEhieFEKdU5lWGtvVEZIb0V1SmY2VXFVY1JPdmZucTNRVjNyRmtkU2RRZzQ0S2pqWXp1RGNrMTdUWi9RS2lVQ3NMNUpHRgpRM0FVdUkrVEtQWmQ0bUQ5c1oxME9TYk5GSmJuV2lxWUlWSi9TRVRvbEh6QkVDbnZzR3U1dVMvMTVrME56bkVSCmVpSlIyUkpyOHluK0Q3Rlc4Y1Zic1p2MkRVbXFoV21xVEg0eFkzSlAwU0JMdjU3YXNQazJ0RVNBaW5XRmd2ZTUKQkJGelk0eUZpUzBmYmpuYmFpNDFmTmVJNWpWRGFPcDZwWUtoa2NKYm1hd3VqVm9pS2ZDS2JzMG4vVGFJTFY1OAowbDBRUElYWVVZbTRCbnFZVVlKWUh5MmdKS042bUYwTGx3WEpadlVPN3NUUXBvSEJicm9mYlFXdkdTc3RVWTU2CnRMUkJBb0lCQURUblFPWEszdHhYbkdMMERMU1k4QXE1TDdkT3lUUDdzSllzMHRGcFhnTDRkRXpyVEV0bHYrd1MKMEtKSnZKWWt5RjlzcmpCWGI4TjBmNFhvWi9jL3d4c2d4TUtKRXVrOHFNZHFzeUxBelZpaHNhNU4vcW90MUR4SgpMcTc5aVBIVk1FOFV1bXFiWldUSDVyVWFBTE5RQnY4azdJQkIydUNzRTl0dFlFWk5WcThtWHZGZklteXhkN1k2CkxnNVVIeEg3a2RkQjNkZzlDdExBM3ZsQUNMcEVyTlk4SDNrakIzaGVxM0RzdXJVNlVxTGdad1Qvc0JPSWl3b1QKVmdZbEFFUE1GbmsrNE10Z1BVcG9UUEVMQ21YQjkwM3VpQ0p1NlEyd0VrN3ZvU0VtWlBZR1JwSkRobjVrSnFQVwozM3BlT3Q3K2lTQVV0eHZHNFVzc1hZdFh6ZS9hQmNBPQotLS0tLUVORCBQUklWQVRFIEtFWS0tLS0t";
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
