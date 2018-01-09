// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Batch.Tests.Helpers;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Batch.Tests
{
    public class InMemoryAccountTests
    {
        [Fact]
        public void AccountCreateThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.BatchAccount.Create(null, "bar", new BatchAccountCreateParameters()));
            Assert.Throws<ValidationException>(() => client.BatchAccount.Create("foo", null, new BatchAccountCreateParameters()));
            Assert.Throws<ValidationException>(() => client.BatchAccount.Create("foo", "bar", null));
            Assert.Throws<ValidationException>(() => client.BatchAccount.Create("invalid+", "account", new BatchAccountCreateParameters()));
            Assert.Throws<ValidationException>(() => client.BatchAccount.Create("rg", "invalid%", new BatchAccountCreateParameters()));
            Assert.Throws<ValidationException>(() => client.BatchAccount.Create("rg", "/invalid", new BatchAccountCreateParameters()));
            Assert.Throws<ValidationException>(() => client.BatchAccount.Create("rg", "s", new BatchAccountCreateParameters()));
            Assert.Throws<ValidationException>(() => client.BatchAccount.Create("rg", "account_name_that_is_too_long", new BatchAccountCreateParameters()));
        }

        [Fact]
        public void AccountCreateAsyncValidateMessage()
        {
            var acceptedResponse = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"")
            };

            acceptedResponse.Headers.Add("x-ms-request-id", "1");
            acceptedResponse.Headers.Add("Location", @"http://someLocationURL");

            var okResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                                'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName',
                                'type' : 'Microsoft.Batch/batchAccounts',
                                'name': 'acctName',
                                'location': 'South Central US',
                                'properties': {
                                    'accountEndpoint' : 'http://acctName.batch.core.windows.net/',
                                    'provisioningState' : 'Succeeded'
                                },
                                'tags' : {
                                    'tag1' : 'value for tag1',
                                    'tag2' : 'value for tag2',
                                }
                            }")
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { acceptedResponse, okResponse });

            var client = BatchTestHelper.GetBatchManagementClient(handler);
            var tags = new Dictionary<string, string>();
            tags.Add("tag1", "value for tag1");
            tags.Add("tag2", "value for tag2");

            var result = Task.Factory.StartNew(() => client.BatchAccount.CreateWithHttpMessagesAsync(
                "foo",
                "acctName",
                new BatchAccountCreateParameters
                {
                    Location = "South Central US",
                    Tags = tags
                })).Unwrap().GetAwaiter().GetResult();

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.NotNull(handler.Requests[0].Headers.GetValues("User-Agent"));

            // Validate result
            Assert.Equal("South Central US", result.Body.Location);
            Assert.NotEmpty(result.Body.AccountEndpoint);
            Assert.Equal(ProvisioningState.Succeeded, result.Body.ProvisioningState);
            Assert.Equal(2, result.Body.Tags.Count);
        }

        [Fact]
        public void CreateAccountWithAutoStorageAsyncValidateMessage()
        {
            var acceptedResponse = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"")
            };

            acceptedResponse.Headers.Add("x-ms-request-id", "1");
            acceptedResponse.Headers.Add("Location", @"http://someLocationURL");
            var utcNow = DateTime.UtcNow;

            var okResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                                'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName',
                                'type' : 'Microsoft.Batch/batchAccounts',
                                'name': 'acctName',
                                'location': 'South Central US',
                                'properties': {
                                    'accountEndpoint' : 'http://acctName.batch.core.windows.net/',
                                    'provisioningState' : 'Succeeded',
                                    'autoStorage' :{
                                        'storageAccountId' : '//storageAccount1',
                                        'lastKeySync': '" + utcNow.ToString("o") + @"',
                                    }
                                },
                            }")
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { okResponse });

            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = client.BatchAccount.Create("resourceGroupName", "acctName", new BatchAccountCreateParameters
            {
                Location = "South Central US",
                AutoStorage = new AutoStorageBaseProperties()
                {
                    StorageAccountId = "//storageAccount1"
                }
            });

            // Validate result
            Assert.Equal("//storageAccount1", result.AutoStorage.StorageAccountId);
            Assert.Equal(utcNow, result.AutoStorage.LastKeySync);
        }

        [Fact]
        public void AccountUpdateWithAutoStorageValidateMessage()
        {
            var utcNow = DateTime.UtcNow;

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                                'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName',
                                'type' : 'Microsoft.Batch/batchAccounts',
                                'name': 'acctName',
                                'location': 'South Central US',
                                'properties': {
                                    'accountEndpoint' : 'http://acctName.batch.core.windows.net/',
                                    'provisioningState' : 'Succeeded',
                                    'autoStorage' : {
                                        'storageAccountId' : '//StorageAccountId',
                                        'lastKeySync': '" + utcNow.ToString("o") + @"',
                                    }
                                },
                                'tags' : {
                                    'tag1' : 'value for tag1',
                                    'tag2' : 'value for tag2',
                                }
                            }")
            };

            var handler = new RecordedDelegatingHandler(response);

            var client = BatchTestHelper.GetBatchManagementClient(handler);
            var tags = new Dictionary<string, string>();
            tags.Add("tag1", "value for tag1");
            tags.Add("tag2", "value for tag2");

            var result = client.BatchAccount.Update("foo", "acctName", new BatchAccountUpdateParameters
            {
                Tags = tags,
            });

            // Validate headers - User-Agent for certs, Authorization for tokens
            //Assert.Equal(HttpMethod.Patch, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal("South Central US", result.Location);
            Assert.NotEmpty(result.AccountEndpoint);
            Assert.Equal(ProvisioningState.Succeeded, result.ProvisioningState);
            Assert.Equal("//StorageAccountId", result.AutoStorage.StorageAccountId);
            Assert.Equal(utcNow, result.AutoStorage.LastKeySync);
            Assert.Equal(2, result.Tags.Count);
        }

        [Fact]
        public void AccountCreateSyncValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                                'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName',
                                'type' : 'Microsoft.Batch/batchAccounts',
                                'name': 'acctName',
                                'location': 'South Central US',
                                'properties': {
                                    'accountEndpoint' : 'http://acctName.batch.core.windows.net/',
                                    'provisioningState' : 'Succeeded'
                                },
                                'tags' : {
                                    'tag1' : 'value for tag1',
                                    'tag2' : 'value for tag2',
                                }
                            }")
            };

            var handler = new RecordedDelegatingHandler(response);

            var client = BatchTestHelper.GetBatchManagementClient(handler);
            var tags = new Dictionary<string, string>();
            tags.Add("tag1", "value for tag1");
            tags.Add("tag2", "value for tag2");

            var result = client.BatchAccount.Create("foo", "acctName", new BatchAccountCreateParameters("westus")
            {
                Tags = tags,
                AutoStorage = new AutoStorageBaseProperties()
                {
                    StorageAccountId = "//storageAccount1"
                }
            });

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal("South Central US", result.Location);
            Assert.NotEmpty(result.AccountEndpoint);
            Assert.Equal(ProvisioningState.Succeeded, result.ProvisioningState);
            Assert.Equal(2, result.Tags.Count);
        }

        [Fact]
        public void AccountUpdateValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                                'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName',
                                'type' : 'Microsoft.Batch/batchAccounts',
                                'name': 'acctName',
                                'location': 'South Central US',
                                'properties': {
                                    'accountEndpoint' : 'http://acctName.batch.core.windows.net/',
                                    'provisioningState' : 'Succeeded'
                                },
                                'tags' : {
                                    'tag1' : 'value for tag1',
                                    'tag2' : 'value for tag2',
                                }
                            }")
            };

            var handler = new RecordedDelegatingHandler(response);

            var client = BatchTestHelper.GetBatchManagementClient(handler);
            var tags = new Dictionary<string, string>();
            tags.Add("tag1", "value for tag1");
            tags.Add("tag2", "value for tag2");

            var result = client.BatchAccount.Update("foo", "acctName", new BatchAccountUpdateParameters
            {
                Tags = tags,
                AutoStorage = new AutoStorageBaseProperties()
                {
                    StorageAccountId = "//StorageAccountId"
                }
            });

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal("South Central US", result.Location);
            Assert.NotEmpty(result.AccountEndpoint);
            Assert.Equal(ProvisioningState.Succeeded, result.ProvisioningState);

            Assert.Equal(2, result.Tags.Count);
        }

        [Fact]
        public void AccountUpdateThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.BatchAccount.Update(null, null, new BatchAccountUpdateParameters()));
            Assert.Throws<ValidationException>(() => client.BatchAccount.Update("foo", null, new BatchAccountUpdateParameters()));
            Assert.Throws<ValidationException>(() => client.BatchAccount.Update("foo", "bar", null));
            Assert.Throws<ValidationException>(() => client.BatchAccount.Update("rg", "invalid%", new BatchAccountUpdateParameters()));
            Assert.Throws<ValidationException>(() => client.BatchAccount.Update("rg", "/invalid", new BatchAccountUpdateParameters()));

        }

        [Fact]
        public void AccountDeleteValidateMessage()
        {
            var acceptedResponse = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"")
            };

            acceptedResponse.Headers.Add("x-ms-request-id", "1");
            acceptedResponse.Headers.Add("Location", @"http://someLocationURL");

            var okResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"")
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { acceptedResponse, okResponse });

            var client = BatchTestHelper.GetBatchManagementClient(handler);
            client.BatchAccount.Delete("resGroup", "acctName");

            // Validate headers
            Assert.Equal(HttpMethod.Delete, handler.Requests[0].Method);
        }

        [Fact]
        public void AccountDeleteNotFoundValidateMessage()
        {
            var acceptedResponse = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"")
            };

            acceptedResponse.Headers.Add("x-ms-request-id", "1");
            acceptedResponse.Headers.Add("Location", @"http://someLocationURL");

            var notFoundResponse = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(@"")
            };

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { acceptedResponse, notFoundResponse });

            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Assert.Throws<CloudException>(() => Task.Factory.StartNew(() =>
                client.BatchAccount.DeleteWithHttpMessagesAsync(
                "resGroup",
                "acctName")).Unwrap().GetAwaiter().GetResult());

            // Validate headers
            Assert.Equal(HttpMethod.Delete, handler.Requests[0].Method);
            Assert.Equal(HttpStatusCode.NotFound, result.Response.StatusCode);
        }

        [Fact]
        public void AccountDeleteOkValidateMessage()
        {
            var noContentResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"")
            };

            noContentResponse.Headers.Add("x-ms-request-id", "1");

            var handler = new RecordedDelegatingHandler(noContentResponse);

            var client = BatchTestHelper.GetBatchManagementClient(handler);
            client.BatchAccount.Delete("resGroup", "acctName");

            // Validate headers
            Assert.Equal(HttpMethod.Delete, handler.Requests[0].Method);
        }

        [Fact]
        public void AccountDeleteThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.BatchAccount.Delete("foo", null));
            Assert.Throws<ValidationException>(() => client.BatchAccount.Delete(null, "bar"));
            Assert.Throws<ValidationException>(() => client.BatchAccount.Delete("rg", "invalid%"));
            Assert.Throws<ValidationException>(() => client.BatchAccount.Delete("rg", "/invalid"));
        }

        [Fact]
        public void AccountGetValidateResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName',
                    'type' : 'Microsoft.Batch/batchAccounts',
                    'name': 'acctName',
                    'location': 'South Central US',
                    'properties': {
                        'accountEndpoint' : 'http://acctName.batch.core.windows.net/',
                        'provisioningState' : 'Succeeded',
                        'dedicatedCoreQuota' : '20',
                        'lowPriorityCoreQuota' : '50',
                        'poolQuota' : '100',
                        'activeJobAndJobScheduleQuota' : '200'
                    },
                    'tags' : {
                        'tag1' : 'value for tag1',
                        'tag2' : 'value for tag2',
                    }
                }")
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = client.BatchAccount.Get("foo", "acctName");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal("South Central US", result.Location);
            Assert.Equal("acctName", result.Name);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName", result.Id);
            Assert.NotEmpty(result.AccountEndpoint);
            Assert.Equal(20, result.DedicatedCoreQuota);
            Assert.Equal(50, result.LowPriorityCoreQuota);
            Assert.Equal(100, result.PoolQuota);
            Assert.Equal(200, result.ActiveJobAndJobScheduleQuota);

            Assert.True(result.Tags.ContainsKey("tag1"));
        }

        [Fact]
        public void AccountGetThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.BatchAccount.Get("foo", null));
            Assert.Throws<ValidationException>(() => client.BatchAccount.Get(null, "bar"));
            Assert.Throws<ValidationException>(() => client.BatchAccount.Get("rg", "invalid%"));
            Assert.Throws<ValidationException>(() => client.BatchAccount.Get("rg", "/invalid"));
        }

        [Fact]
        public void AccountListValidateMessage()
        {
            var allSubsResponseEmptyNextLink = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                            'value':
                            [
                                {
                                    'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName',
                                    'type' : 'Microsoft.Batch/batchAccounts',
                                    'name': 'acctName',
                                    'location': 'West US',
                                    'properties': {
                                        'accountEndpoint' : 'http://acctName.batch.core.windows.net/',
                                        'provisioningState' : 'Succeeded',
                                        'dedicatedCoreQuota' : '20',
                                        'lowPriorityCoreQuota' : '50',
                                        'poolQuota' : '100',
                                        'activeJobAndJobScheduleQuota' : '200'
                                    },
                                    'tags' : {
                                        'tag1' : 'value for tag1',
                                        'tag2' : 'value for tag2',
                                    }
                                },
                                {
                                    'id': '/subscriptions/12345/resourceGroups/bar/providers/Microsoft.Batch/batchAccounts/acctName1',
                                    'type' : 'Microsoft.Batch/batchAccounts',
                                    'name': 'acctName1',
                                    'location': 'South Central US',
                                    'properties': {
                                        'accountEndpoint' : 'http://acctName1.batch.core.windows.net/',
                                        'provisioningState' : 'Succeeded',
                                        'dedicatedCoreQuota' : '20',
                                        'lowPriorityCoreQuota' : '50',
                                        'poolQuota' : '100',
                                        'activeJobAndJobScheduleQuota' : '200'
                                    },
                                    'tags' : {
                                        'tag1' : 'value for tag1',
                                        'tag2' : 'value for tag2',
                                    }
                                }
                            ],
                            'nextLink' : ''
                        }")
            };

            var allSubsResponseNonemptyNextLink = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                        'value':
                        [
                            {
                                'id': '/subscriptions/12345/resourceGroups/resGroup/providers/Microsoft.Batch/batchAccounts/acctName',
                                'type' : 'Microsoft.Batch/batchAccounts',
                                'name': 'acctName',
                                'location': 'West US',
                                'properties': {
                                    'accountEndpoint' : 'http://acctName.batch.core.windows.net/',
                                    'provisioningState' : 'Succeeded',
                                    'dedicatedCoreQuota' : '20',
                                    'lowPriorityCoreQuota' : '50',
                                    'poolQuota' : '100',
                                    'activeJobAndJobScheduleQuota' : '200'
                                },
                                'tags' : {
                                    'tag1' : 'value for tag1',
                                    'tag2' : 'value for tag2',
                                }
                            },
                            {
                                'id': '/subscriptions/12345/resourceGroups/resGroup/providers/Microsoft.Batch/batchAccounts/acctName1',
                                'type' : 'Microsoft.Batch/batchAccounts',
                                'name': 'acctName1',
                                'location': 'South Central US',
                                'properties': {
                                    'accountEndpoint' : 'http://acctName1.batch.core.windows.net/',
                                    'provisioningState' : 'Succeeded'
                                },
                                'tags' : {
                                    'tag1' : 'value for tag1',
                                    'tag2' : 'value for tag2',
                                }
                            }
                        ],
                        'nextLink' : 'https://fake.net/subscriptions/12345/resourceGroups/resGroup/providers/Microsoft.Batch/batchAccounts/acctName?$skipToken=opaqueStringThatYouShouldntCrack'
                    }
                 ")
            };


            var allSubsResponseNonemptyNextLink1 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                        'value':
                        [
                            {
                                'id': '/subscriptions/12345/resourceGroups/resGroup/providers/Microsoft.Batch/batchAccounts/acctName',
                                'type' : 'Microsoft.Batch/batchAccounts',
                                'name': 'acctName',
                                'location': 'West US',
                                'properties': {
                                    'accountEndpoint' : 'http://acctName.batch.core.windows.net/',
                                    'provisioningState' : 'Succeeded',
                                    'dedicatedCoreQuota' : '20',
                                    'lowPriorityCoreQuota' : '50',
                                    'poolQuota' : '100',
                                    'activeJobAndJobScheduleQuota' : '200'

                                },
                                'tags' : {
                                    'tag1' : 'value for tag1',
                                    'tag2' : 'value for tag2',
                                }
                            },
                            {
                                'id': '/subscriptions/12345/resourceGroups/resGroup/providers/Microsoft.Batch/batchAccounts/acctName1',
                                'type' : 'Microsoft.Batch/batchAccounts',
                                'name': 'acctName1',
                                'location': 'South Central US',
                                'properties': {
                                    'accountEndpoint' : 'http://acctName1.batch.core.windows.net/',
                                    'provisioningState' : 'Succeeded',
                                    'dedicatedCoreQuota' : '20',
                                    'lowPriorityCoreQuota' : '50',
                                    'poolQuota' : '100',
                                    'activeJobAndJobScheduleQuota' : '200'
                                },
                                'tags' : {
                                    'tag1' : 'value for tag1',
                                    'tag2' : 'value for tag2',
                                }
                            }
                        ],
                        'nextLink' : 'https://fake.net/subscriptions/12345/resourceGroups/resGroup/providers/Microsoft.Batch/batchAccounts/acctName?$skipToken=opaqueStringThatYouShouldntCrack'
                    }
                 ")
            };
            allSubsResponseEmptyNextLink.Headers.Add("x-ms-request-id", "1");
            allSubsResponseNonemptyNextLink.Headers.Add("x-ms-request-id", "1");
            allSubsResponseNonemptyNextLink1.Headers.Add("x-ms-request-id", "1");

            // all accounts under sub and empty next link
            var handler = new RecordedDelegatingHandler(allSubsResponseEmptyNextLink) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = Task.Factory.StartNew(() => client.BatchAccount.ListWithHttpMessagesAsync())
                .Unwrap()
                .GetAwaiter()
                .GetResult();

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.Response.StatusCode);

            // Validate result
            Assert.Equal(2, result.Body.Count());

            var account1 = result.Body.ElementAt(0);
            var account2 = result.Body.ElementAt(1);
            Assert.Equal("West US", account1.Location);
            Assert.Equal("acctName", account1.Name);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName", account1.Id);
            Assert.Equal("/subscriptions/12345/resourceGroups/bar/providers/Microsoft.Batch/batchAccounts/acctName1", account2.Id);
            Assert.NotEmpty(account1.AccountEndpoint);
            Assert.Equal(20, account1.DedicatedCoreQuota);
            Assert.Equal(50, account1.LowPriorityCoreQuota);
            Assert.Equal(100, account1.PoolQuota);
            Assert.Equal(200, account2.ActiveJobAndJobScheduleQuota);

            Assert.True(account1.Tags.ContainsKey("tag1"));

            // all accounts under sub and a non-empty nextLink
            handler = new RecordedDelegatingHandler(allSubsResponseNonemptyNextLink) { StatusCodeToReturn = HttpStatusCode.OK };
            client = BatchTestHelper.GetBatchManagementClient(handler);

            var result1 = client.BatchAccount.List();

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // all accounts under sub with a non-empty nextLink response
            handler = new RecordedDelegatingHandler(allSubsResponseNonemptyNextLink1) { StatusCodeToReturn = HttpStatusCode.OK };
            client = BatchTestHelper.GetBatchManagementClient(handler);

            result1 = client.BatchAccount.ListNext(result1.NextPageLink);

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));
        }

        [Fact]
        public void AccountListByResourceGroupValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                        'value':
                        [
                            {
                                'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName',
                                'type' : 'Microsoft.Batch/batchAccounts',
                                'name': 'acctName',
                                'location': 'West US',
                                'properties': {
                                    'accountEndpoint' : 'http://acctName.batch.core.windows.net/',
                                    'provisioningState' : 'Succeeded',
                                    'dedicatedCoreQuota' : '20',
                                    'lowPriorityCoreQuota' : '50',
                                    'poolQuota' : '100',
                                    'activeJobAndJobScheduleQuota' : '200'
                                },
                                'tags' : {
                                    'tag1' : 'value for tag1',
                                    'tag2' : 'value for tag2',
                                }
                            },
                            {
                                'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName1',
                                'type' : 'Microsoft.Batch/batchAccounts',
                                'name': 'acctName1',
                                'location': 'South Central US',
                                'properties': {
                                    'accountEndpoint' : 'http://acctName1.batch.core.windows.net/',
                                    'provisioningState' : 'Failed',
                                    'dedicatedCoreQuota' : '10',
                                    'lowPriorityCoreQuota' : '50',
                                    'poolQuota' : '50',
                                    'activeJobAndJobScheduleQuota' : '100'
                                },
                                'tags' : {
                                    'tag1' : 'value for tag1'
                                }
                            }
                        ],
                        'nextLink' : 'originalRequestURl?$skipToken=opaqueStringThatYouShouldntCrack'
                    }")
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = client.BatchAccount.List();

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal(2, result.Count());

            var account1 = result.ElementAt(0);
            var account2 = result.ElementAt(1);

            Assert.Equal("West US", account1.Location);
            Assert.Equal("acctName", account1.Name);
            Assert.Equal( @"/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName", account1.Id);
            Assert.Equal(@"http://acctName.batch.core.windows.net/", account1.AccountEndpoint);
            Assert.Equal(ProvisioningState.Succeeded, account1.ProvisioningState);
            Assert.Equal(20, account1.DedicatedCoreQuota);
            Assert.Equal(50, account1.LowPriorityCoreQuota);
            Assert.Equal(100, account1.PoolQuota);
            Assert.Equal(200, account1.ActiveJobAndJobScheduleQuota);

            Assert.Equal("South Central US", account2.Location);
            Assert.Equal("acctName1", account2.Name);
            Assert.Equal(@"/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName1", account2.Id);
            Assert.Equal(@"http://acctName1.batch.core.windows.net/", account2.AccountEndpoint);
            Assert.Equal(ProvisioningState.Failed, account2.ProvisioningState);
            Assert.Equal(10, account2.DedicatedCoreQuota);
            Assert.Equal(50, account2.LowPriorityCoreQuota);
            Assert.Equal(50, account2.PoolQuota);
            Assert.Equal(100, account2.ActiveJobAndJobScheduleQuota);

            Assert.Equal(2, account1.Tags.Count);
            Assert.True(account1.Tags.ContainsKey("tag2"));

            Assert.Equal(1, account2.Tags.Count);
            Assert.True(account2.Tags.ContainsKey("tag1"));

            Assert.Equal(@"originalRequestURl?$skipToken=opaqueStringThatYouShouldntCrack", result.NextPageLink);
        }

        [Fact]
        public void AccountListNextThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<Microsoft.Rest.ValidationException>(() => client.BatchAccount.ListNext(null));
        }

        [Fact]
        public void AccountKeysListValidateMessage()
        {
            var primaryKeyString = "primary key string which is alot longer than this";
            var secondaryKeyString = "secondary key string which is alot longer than this";

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'primary' : 'primary key string which is alot longer than this',
                    'secondary' : 'secondary key string which is alot longer than this',
                }")
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = client.BatchAccount.GetKeys("foo", "acctName");

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.NotEmpty(result.Primary);
            Assert.Equal(primaryKeyString, result.Primary);
            Assert.NotEmpty(result.Secondary);
            Assert.Equal(secondaryKeyString, result.Secondary);
        }

        [Fact]
        public void AccountKeysListThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.BatchAccount.GetKeys("foo", null));
            Assert.Throws<ValidationException>(() => client.BatchAccount.GetKeys(null, "bar"));
        }

        [Fact]
        public void AccountKeysRegenerateValidateMessage()
        {
            var primaryKeyString = "primary key string which is alot longer than this";
            var secondaryKeyString = "secondary key string which is alot longer than this";

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'primary' : 'primary key string which is alot longer than this',
                    'secondary' : 'secondary key string which is alot longer than this',
                }")
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            var result = client.BatchAccount.RegenerateKey(
                "foo",
                "acctName",
                AccountKeyType.Primary);

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.NotEmpty(result.Primary);
            Assert.Equal(primaryKeyString, result.Primary);
            Assert.NotEmpty(result.Secondary);
            Assert.Equal(secondaryKeyString, result.Secondary);
        }

        [Fact]
        public void AccountKeysRegenerateThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = BatchTestHelper.GetBatchManagementClient(handler);

            Assert.Throws<ValidationException>(() => client.BatchAccount.RegenerateKey(null, "bar", AccountKeyType.Primary));
            Assert.Throws<ValidationException>(() => client.BatchAccount.RegenerateKey("foo", null, AccountKeyType.Primary));
            Assert.Throws<ValidationException>(() => client.BatchAccount.RegenerateKey("rg", "invalid%", AccountKeyType.Primary));
        }
    }
}
