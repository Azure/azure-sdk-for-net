// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace BatchProxyIntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using BatchTestCommon;

    using Microsoft.Azure.Batch.Protocol;
    using Microsoft.Azure.Batch.Protocol.Models;
    using Microsoft.Azure.Management.Batch;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Xunit.Abstractions;

    public class IntegrationPoolApplicationPackageReferencesTests : IDisposable
    {
        private readonly string AccountName = TestCommon.Configuration.BatchAccountName;
        private readonly string AccountKey = TestCommon.Configuration.BatchAccountKey;
        private readonly string Url = TestCommon.Configuration.BatchAccountUrl;

        private readonly ITestOutputHelper output;

        private const string AppPackageIdOne = "pool-application-package-references-one";
        private const string AppPackageIdTwo = "pool-application-package-references-two";


        public IntegrationPoolApplicationPackageReferencesTests(ITestOutputHelper output)
        {
            this.output = output;
            ApplicationPackageCommon.UploadTestApplicationPackageIfNotAlreadyUploadedAsync(AppPackageIdOne, "1.0").Wait();
            ApplicationPackageCommon.UpdateApplicationPackageAsync(AppPackageIdOne, "1.0", "My First App", false).Wait();
            ApplicationPackageCommon.UploadTestApplicationPackageIfNotAlreadyUploadedAsync(AppPackageIdTwo, "1.0").Wait();
            ApplicationPackageCommon.UploadTestApplicationPackageIfNotAlreadyUploadedAsync(AppPackageIdTwo, "1.1").Wait();
            ApplicationPackageCommon.UpdateApplicationPackageAsync(AppPackageIdTwo, "1.0", "My Second App", true).Wait();
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void BadAppPackageReferenceFails()
        {
            var poolId = Guid.NewGuid().ToString();
            var client = new BatchServiceClient(new Uri(Url), new BatchSharedKeyCredential(AccountName, AccountKey));

            var poolAddParameter = new PoolAddParameter(poolId, "small", "4");
            poolAddParameter.ApplicationPackageReferences = new[] { new ApplicationPackageReference { ApplicationId = "bad" } };

            var exception = Assert.Throws<AggregateException>(() => client.Pool.AddAsync(poolAddParameter).Result);

            var batchException = (BatchErrorException)exception.InnerException;

            Assert.NotNull(batchException);
            Assert.Equal("InvalidApplicationPackageReferences", batchException.Body.Code);
            Assert.Equal(1, batchException.Body.Values.Count());
            Assert.Equal("bad", batchException.Body.Values[0].Key);
            Assert.Equal("The specified application package does not exist.", batchException.Body.Values[0].Value);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void BadAppPackageReferenceAndVersionFails()
        {
            var poolId = Guid.NewGuid().ToString();
            var client = new BatchServiceClient(new Uri(Url), new BatchSharedKeyCredential(AccountName, AccountKey));

            var poolAddParameter = new PoolAddParameter(poolId, "small", "4");
            poolAddParameter.ApplicationPackageReferences = new[] { new ApplicationPackageReference { ApplicationId = "bad", Version = "999" } };
            var exception = Assert.Throws<AggregateException>(() => client.Pool.AddAsync(poolAddParameter).Result);

            var batchException = (BatchErrorException)exception.InnerException;

            Assert.NotNull(batchException);
            Assert.Equal("InvalidApplicationPackageReferences", batchException.Body.Code);
            Assert.Equal(1, batchException.Body.Values.Count());
            Assert.Equal("bad:999", batchException.Body.Values[0].Key);
            Assert.Equal("The specified application package does not exist.", batchException.Body.Values[0].Value);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void AppPackageReferenceWithInvalidVersionFails()
        {
            var poolId = Guid.NewGuid().ToString();
            var client = new BatchServiceClient(new Uri(Url), new BatchSharedKeyCredential(AccountName, AccountKey));
            var poolAddParameter = new PoolAddParameter(poolId, "small", "4");

            poolAddParameter.ApplicationPackageReferences = new[]
            {
                new ApplicationPackageReference { ApplicationId = AppPackageIdOne, Version = "999" }, // invalid version
            };

            var exception = Assert.Throws<AggregateException>(() => client.Pool.AddAsync(poolAddParameter).Result);
            var batchException = (BatchErrorException)exception.InnerException;

            Assert.NotNull(batchException);
            Assert.Equal("InvalidApplicationPackageReferences", batchException.Body.Code);
            Assert.Equal(1, batchException.Body.Values.Count());
            Assert.Equal(AppPackageIdOne + ":999", batchException.Body.Values[0].Key);
            Assert.Equal("The specified application package does not exist.", batchException.Body.Values[0].Value);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void ValidAppPackageReferenceWithNoDefaultFails()
        {
            var poolId = Guid.NewGuid().ToString();

            var poolAddParameter = new PoolAddParameter(poolId, "small", "4");
            var client = new BatchServiceClient(new Uri(Url), new BatchSharedKeyCredential(AccountName, AccountKey));

            poolAddParameter.ApplicationPackageReferences = new[] { new ApplicationPackageReference { ApplicationId = AppPackageIdOne } }; // valid pkg, but has no default set
            var exception = Assert.Throws<AggregateException>(() => client.Pool.AddAsync(poolAddParameter).Result);
            var batchException = (BatchErrorException)exception.InnerException;
            client.Application.List();

            Assert.NotNull(batchException);
            Assert.Equal("InvalidApplicationPackageReferences", batchException.Body.Code);
            Assert.Equal(1, batchException.Body.Values.Count);
            Assert.Equal(AppPackageIdOne, batchException.Body.Values[0].Key);
            Assert.Equal("The specified application package does not have a default version set.", batchException.Body.Values[0].Value);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void MultipleAppPackageReferenceWithNoDefaultFails()
        {
            string poolId = Guid.NewGuid().ToString();
            var client = new BatchServiceClient(new Uri(Url), new BatchSharedKeyCredential(AccountName, AccountKey));

            var poolAddParameter = new PoolAddParameter(poolId, "small", "4");

            poolAddParameter.ApplicationPackageReferences = new[]
            {
                new ApplicationPackageReference { ApplicationId = AppPackageIdOne }, // valid pkg, but has no default set
                new ApplicationPackageReference { ApplicationId = AppPackageIdTwo }
            };

            var exception = Assert.Throws<AggregateException>(() => client.Pool.AddAsync(poolAddParameter).Result);
            var batchException = (BatchErrorException)exception.InnerException;

            Assert.NotNull(batchException);
            Assert.Equal("InvalidApplicationPackageReferences", batchException.Body.Code);
            Assert.Equal(1, batchException.Body.Values.Count);
            Assert.Equal(AppPackageIdOne, batchException.Body.Values[0].Key);
            Assert.Equal("The specified application package does not have a default version set.", batchException.Body.Values[0].Value);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void CanCreatePoolWithAppPkgRefAndVersion()
        {
            var poolId = Guid.NewGuid().ToString();
            var client = new BatchServiceClient(new Uri(Url), new BatchSharedKeyCredential(AccountName, AccountKey));

            var poolAddParameter = new PoolAddParameter(poolId, "small", "4");

            poolAddParameter.ApplicationPackageReferences = new[]
            {
                new ApplicationPackageReference { ApplicationId = AppPackageIdOne, Version = "1.0"}
            };

            try
            {
                var response = client.Pool.AddWithHttpMessagesAsync(poolAddParameter).Result;
                Assert.Equal(HttpStatusCode.Created, response.Response.StatusCode);
            }
            finally
            {
                TestUtilities.DeletePoolIfExistsNoThrow(client, poolId, output);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void CanCreatePoolWithAppPkgRefAndDefault()
        {
            var poolId = Guid.NewGuid().ToString();
            var client = new BatchServiceClient(new Uri(Url), new BatchSharedKeyCredential(AccountName, AccountKey));
            var poolAddParameter = new PoolAddParameter(poolId, "small", "4");

            poolAddParameter.ApplicationPackageReferences = new[]
            {
                new ApplicationPackageReference { ApplicationId = AppPackageIdTwo },
            };

            try
            {
                var response = client.Pool.AddWithHttpMessagesAsync(poolAddParameter).Result;
                Assert.Equal(HttpStatusCode.Created, response.Response.StatusCode);
            }
            finally
            {
                TestUtilities.DeletePoolIfExistsNoThrow(client, poolId, output);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void CanCreatePoolWithTwoAppPkgRefAndVersion()
        {
            var poolId = Guid.NewGuid().ToString();
            var client = new BatchServiceClient(new Uri(Url), new BatchSharedKeyCredential(AccountName, AccountKey));

            var poolAddParameter = new PoolAddParameter(poolId, "small", "4");

            poolAddParameter.ApplicationPackageReferences = new[]
            {
                new ApplicationPackageReference { ApplicationId = AppPackageIdOne, Version = "1.0" },
                new ApplicationPackageReference { ApplicationId = AppPackageIdTwo },
            };

            try
            {
                var response = client.Pool.AddWithHttpMessagesAsync(poolAddParameter).Result;
                Assert.Equal(HttpStatusCode.Created, response.Response.StatusCode);
            }
            finally
            {
                TestUtilities.DeletePoolIfExistsNoThrow(client, poolId, output);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void CanCreatePoolAndRetrieveAppPkgRefs()
        {
            var poolId = Guid.NewGuid().ToString();
            var client = new BatchServiceClient(new Uri(Url), new BatchSharedKeyCredential(AccountName, AccountKey));

            var poolAddParameter = new PoolAddParameter(poolId, "small", "4");

            poolAddParameter.ApplicationPackageReferences = new[]
            {
                new ApplicationPackageReference { ApplicationId = AppPackageIdOne, Version = "1.0" },
                new ApplicationPackageReference { ApplicationId = AppPackageIdTwo },
            };

            try
            {
                var addResponse = client.Pool.AddAsync(poolAddParameter).Result;
            
                var pool = client.Pool.GetAsync(poolId).Result;
                Assert.Equal(poolId, pool.Id);
                Assert.Equal(2, pool.ApplicationPackageReferences.Count);
                Assert.Equal(AppPackageIdOne, pool.ApplicationPackageReferences[0].ApplicationId);
                Assert.Equal("1.0", pool.ApplicationPackageReferences[0].Version);
                Assert.Equal(AppPackageIdTwo, pool.ApplicationPackageReferences[1].ApplicationId);
                Assert.Null(pool.ApplicationPackageReferences[1].Version);
            }
            finally
            {
                TestUtilities.DeletePoolIfExistsNoThrow(client, poolId, output);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void CanUpdatePoolByAddingAppPkgRefs()
        {
            var poolId = Guid.NewGuid().ToString();
            var client = new BatchServiceClient(new Uri(Url), new BatchSharedKeyCredential(AccountName, AccountKey));

            var poolAddParameter = new PoolAddParameter(poolId, "small", "4");
            try
            {
                var addResponse = client.Pool.AddAsync(poolAddParameter).Result;

                var appRefs = new List<ApplicationPackageReference>
                {
                    new ApplicationPackageReference { ApplicationId = AppPackageIdOne, Version = "1.0"},
                    new ApplicationPackageReference { ApplicationId = AppPackageIdTwo },
                };

                var updateParams = new PoolUpdatePropertiesParameter(new List<CertificateReference>(), appRefs, new List<MetadataItem>());
                var updateResponse = client.Pool.UpdatePropertiesWithHttpMessagesAsync(poolId, updateParams).Result;
                Assert.Equal(HttpStatusCode.NoContent, updateResponse.Response.StatusCode);

                var pool = client.Pool.GetAsync(poolId).Result;
                Assert.Equal(poolId, pool.Id);
                Assert.Equal(2, pool.ApplicationPackageReferences.Count);
                Assert.Equal(AppPackageIdOne, pool.ApplicationPackageReferences[0].ApplicationId);
                Assert.Equal("1.0", pool.ApplicationPackageReferences[0].Version);
                Assert.Equal(AppPackageIdTwo, pool.ApplicationPackageReferences[1].ApplicationId);
                Assert.Null(pool.ApplicationPackageReferences[1].Version);
            }
            finally
            {
                TestUtilities.DeletePoolIfExistsNoThrow(client, poolId, output);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void CanUpdatePoolByDeletingAppPkgRefs()
        {
            var poolId = Guid.NewGuid().ToString();
            var client = new BatchServiceClient(new Uri(Url), new BatchSharedKeyCredential(AccountName, AccountKey));

            var poolAddParameter = new PoolAddParameter(poolId, "small", "4");

            poolAddParameter.ApplicationPackageReferences = new[]
            {
                new ApplicationPackageReference { ApplicationId = AppPackageIdOne, Version = "1.0"},
                new ApplicationPackageReference { ApplicationId = AppPackageIdTwo },
            };
            try
            {
                client.Pool.AddAsync(poolAddParameter).Wait();

                var updateParams = new PoolUpdatePropertiesParameter(
                    new List<CertificateReference>(), 
                    new List<ApplicationPackageReference>(), 
                    new List<MetadataItem>());

                var updateResponse = client.Pool.UpdatePropertiesWithHttpMessagesAsync(poolId, updateParams).Result;
                Assert.Equal(HttpStatusCode.NoContent, updateResponse.Response.StatusCode);

                var pool = client.Pool.GetAsync(poolId).Result;
                
                Assert.Equal(poolId, pool.Id);
                Assert.Null(pool.ApplicationPackageReferences);
            }
            finally
            {
                TestUtilities.DeletePoolIfExistsNoThrow(client, poolId, output);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void CanPatchPoolByAddingAppPkgRefs()
        {
            var poolId = Guid.NewGuid().ToString();
            var client = new BatchServiceClient(new Uri(Url), new BatchSharedKeyCredential(AccountName, AccountKey));

            var poolAddParameter = new PoolAddParameter(poolId, "small", "4");
            try
            {
                client.Pool.AddAsync(poolAddParameter).Wait();
                
                var appRefs = new List<ApplicationPackageReference>
                {
                    new ApplicationPackageReference { ApplicationId = AppPackageIdOne, Version = "1.0"},
                    new ApplicationPackageReference { ApplicationId = AppPackageIdTwo },
                };

                var patchParams = new PoolPatchParameter();
                patchParams.ApplicationPackageReferences = appRefs;
                var updateResponse = client.Pool.PatchWithHttpMessagesAsync(poolId, patchParams).Result;
                Assert.Equal(HttpStatusCode.OK, updateResponse.Response.StatusCode);

                var pool = client.Pool.GetAsync(poolId).Result;
                Assert.Equal(poolId, pool.Id);
                Assert.Equal(2, pool.ApplicationPackageReferences.Count);
                Assert.Equal(AppPackageIdOne, pool.ApplicationPackageReferences[0].ApplicationId);
                Assert.Equal("1.0", pool.ApplicationPackageReferences[0].Version);
                Assert.Equal(AppPackageIdTwo, pool.ApplicationPackageReferences[1].ApplicationId);
                Assert.Null(pool.ApplicationPackageReferences[1].Version);
            }
            finally
            {
                TestUtilities.DeletePoolIfExistsNoThrow(client, poolId, output);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void CanPatchPoolByDeletingAppPkgRefs()
        {
            var poolId = Guid.NewGuid().ToString();
            var client = new BatchServiceClient(new Uri(Url), new BatchSharedKeyCredential(AccountName, AccountKey));

            var poolAddParameter = new PoolAddParameter(poolId, "small", "4");

            poolAddParameter.ApplicationPackageReferences = new[]
            {
                new ApplicationPackageReference { ApplicationId = AppPackageIdOne, Version = "1.0" },
                new ApplicationPackageReference { ApplicationId = AppPackageIdTwo },
            };

            try
            {
                client.Pool.AddAsync(poolAddParameter).Wait();
            
                var patchParams = new PoolPatchParameter();
                patchParams.ApplicationPackageReferences = new ApplicationPackageReference[] { };
                var updateResponse = client.Pool.PatchWithHttpMessagesAsync(poolId, patchParams).Result;
                Assert.Equal(HttpStatusCode.OK, updateResponse.Response.StatusCode);

                var pool = client.Pool.GetAsync(poolId).Result;
                Assert.Equal(poolId, pool.Id);
                Assert.Null(pool.ApplicationPackageReferences);
            }
            finally
            {
                TestUtilities.DeletePoolIfExistsNoThrow(client, poolId, output);
            }
        }

        public void Dispose()
        {
            using (var mgmtClient = TestCommon.OpenBatchManagementClient())
            {
                string accountName = TestCommon.Configuration.BatchAccountName;
                string resourceGroupName = TestCommon.Configuration.BatchAccountResourceGroup;

                Func<Task> cleanupTask = async () =>
                    {
                        await mgmtClient.Applications.DeleteApplicationPackageAsync(resourceGroupName, accountName, AppPackageIdOne, "1.0");
                        await mgmtClient.Applications.DeleteApplicationPackageAsync(resourceGroupName, accountName, AppPackageIdTwo, "1.0");
                        await mgmtClient.Applications.DeleteApplicationPackageAsync(resourceGroupName, accountName, AppPackageIdTwo, "1.1");
                        await mgmtClient.Applications.DeleteApplicationAsync(resourceGroupName, accountName, AppPackageIdOne);
                        await mgmtClient.Applications.DeleteApplicationAsync(resourceGroupName, accountName, AppPackageIdTwo);
                    };

                Task.Run(cleanupTask).GetAwaiter().GetResult();
            }
        }
    }
}
