//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Batch.Tests.Helpers;

namespace Microsoft.Azure.Batch.Tests
{
    public class InMemoryAccountTests
    {
        public BatchManagementClient GetBatchManagementClient(RecordedDelegatingHandler handler)
        {
            var certCreds = new CertificateCloudCredentials(Guid.NewGuid().ToString(), new System.Security.Cryptography.X509Certificates.X509Certificate2());
            handler.IsPassThrough = false;
            return new BatchManagementClient(certCreds).WithHandler(handler);
        }

        [Fact]
        public void AccountActionsListValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"[
                            {
                            'action': 'Microsoft.Batch/ListKeys',
                            'friendlyName' : 'List Batch Account Keys',
                            'friendlyTarget' : 'Batch Account',
                            'friendlyDescription' : 'List Batch account keys including both primary key and secondary key.'
                            },
                            {
                            'action': 'Microsoft.Batch/RegenerateKeys',
                            'friendlyName' : 'Regenerate Batch account key',
                            'friendlyTarget' : 'Batch Account',
                            'friendlyDescription' : 'Regenerate the specified Batch account key.'
                            }
                        ]")
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            var result = client.Accounts.ListActions();

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            Assert.Equal("Microsoft.Batch/ListKeys",result.Actions[0].Action);
            Assert.Equal("List Batch Account Keys",result.Actions[0].FriendlyName);
            Assert.Equal("Batch Account",result.Actions[0].FriendlyTarget);
            Assert.True(result.Actions[0].FriendlyDescription.StartsWith("List Batch account keys"));
            Assert.Equal("Microsoft.Batch/RegenerateKeys",result.Actions[1].Action);
            Assert.Equal("Regenerate Batch account key",result.Actions[1].FriendlyName);
            Assert.Equal("Batch Account",result.Actions[1].FriendlyTarget);
            Assert.True(result.Actions[1].FriendlyDescription.StartsWith("Regenerate the specified"));
        }

        [Fact]
        public void AccountCreateThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Accounts.Create(null, "bar", new BatchAccountCreateParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Accounts.Create("foo", null, new BatchAccountCreateParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Accounts.Create("foo", "bar", null));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Accounts.Create("invalid+", "account", new BatchAccountCreateParameters()));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Accounts.Create("rg", "invalid%", new BatchAccountCreateParameters()));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Accounts.Create("rg", "/invalid", new BatchAccountCreateParameters()));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Accounts.Create("rg", "s", new BatchAccountCreateParameters()));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Accounts.Create("rg", "account_name_that_is_too_long", new BatchAccountCreateParameters()));
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

            var client = GetBatchManagementClient(handler);
            var tags = new Dictionary<string, string>();
            tags.Add("tag1", "value for tag1");
            tags.Add("tag2", "value for tag2");

            var result = client.Accounts.Create("foo", "acctName", new BatchAccountCreateParameters
            {
                Location = "South Central US",
                Tags = tags
            });

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.NotNull(handler.Requests[0].Headers.GetValues("User-Agent"));

            // op status is a get
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.NotNull(handler.Requests[1].Headers.GetValues("User-Agent"));

            // Validate result
            Assert.Equal("South Central US", result.Resource.Location);
            Assert.NotEmpty(result.Resource.Properties.AccountEndpoint);
            Assert.Equal(AccountProvisioningState.Succeeded, result.Resource.Properties.ProvisioningState);
            Assert.Equal(2, result.Resource.Tags.Count);
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

            var handler = new RecordedDelegatingHandler(new HttpResponseMessage[] { acceptedResponse, okResponse });

            var client = GetBatchManagementClient(handler);

            var result = client.Accounts.Create("resourceGroupName", "acctName", new BatchAccountCreateParameters
            {
                Location = "South Central US",
                Properties = new AccountBaseProperties
                {
                    AutoStorage = new AutoStorageBaseProperties
                    {
                        StorageAccountId = "//storageAccount1"
                    }
                }
            });

            // Validate result
            Assert.Equal("//storageAccount1", result.Resource.Properties.AutoStorage.StorageAccountId);
            Assert.Equal(utcNow, result.Resource.Properties.AutoStorage.LastKeySync);
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

            var client = GetBatchManagementClient(handler);
            var tags = new Dictionary<string, string>();
            tags.Add("tag1", "value for tag1");
            tags.Add("tag2", "value for tag2");

            var result = client.Accounts.Update("foo", "acctName", new BatchAccountUpdateParameters
            {
                Tags = tags,
                Properties = new AccountBaseProperties
                {
                    AutoStorage = new AutoStorageBaseProperties
                    {
                        StorageAccountId = "//StorageAccountId",
                    }
                },
            });

            // Validate headers - User-Agent for certs, Authorization for tokens
            //Assert.Equal(HttpMethod.Patch, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal("South Central US", result.Resource.Location);
            Assert.NotEmpty(result.Resource.Properties.AccountEndpoint);
            Assert.Equal(AccountProvisioningState.Succeeded, result.Resource.Properties.ProvisioningState);
            Assert.Equal("//StorageAccountId", result.Resource.Properties.AutoStorage.StorageAccountId);
            Assert.Equal(utcNow, result.Resource.Properties.AutoStorage.LastKeySync);
            Assert.Equal(result.Resource.Tags.Count, 2);
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

            var client = GetBatchManagementClient(handler);
            var tags = new Dictionary<string, string>();
            tags.Add("tag1", "value for tag1");
            tags.Add("tag2", "value for tag2");

            var result = client.Accounts.Create("foo", "acctName", new BatchAccountCreateParameters
            {
                Tags = tags,
            });

            // Validate headers - User-Agent for certs, Authorization for tokens
            //Assert.Equal(HttpMethod.Patch, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal("South Central US", result.Resource.Location);
            Assert.NotEmpty(result.Resource.Properties.AccountEndpoint);
            Assert.Equal(result.Resource.Properties.ProvisioningState, AccountProvisioningState.Succeeded);
            Assert.Equal(2, result.Resource.Tags.Count);
        }

        [Fact]
        public void AccountUpdateValidateMessage()
        {
            var utcNow = DateTime.UtcNow.ToString("o");

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
                                },
                                'tags' : {
                                    'tag1' : 'value for tag1',
                                    'tag2' : 'value for tag2',
                                }
                            }")
            };

            var handler = new RecordedDelegatingHandler(response);

            var client = GetBatchManagementClient(handler);
            var tags = new Dictionary<string, string>();
            tags.Add("tag1", "value for tag1");
            tags.Add("tag2", "value for tag2");

            var result = client.Accounts.Update("foo", "acctName", new BatchAccountUpdateParameters
            {
                Tags = tags,
            });

            // Validate headers - User-Agent for certs, Authorization for tokens
            //Assert.Equal(HttpMethod.Patch, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal("South Central US", result.Resource.Location);
            Assert.NotEmpty(result.Resource.Properties.AccountEndpoint);
            Assert.Equal(AccountProvisioningState.Succeeded, result.Resource.Properties.ProvisioningState);

            Assert.Equal(2, result.Resource.Tags.Count);
        }

        [Fact]
        public void AccountUpdateThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Accounts.Update(null, null, new BatchAccountUpdateParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Accounts.Update("foo", null, new BatchAccountUpdateParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Accounts.Update("foo", "bar", null));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Accounts.Update("invalid+", "account", new BatchAccountUpdateParameters()));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Accounts.Update("rg", "invalid%", new BatchAccountUpdateParameters()));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Accounts.Update("rg", "/invalid", new BatchAccountUpdateParameters()));

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

            var client = GetBatchManagementClient(handler);
            var result = client.Accounts.Delete("resGroup", "acctName");

            // Validate headers
            Assert.Equal(HttpMethod.Delete, handler.Requests[0].Method);
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
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

            var client = GetBatchManagementClient(handler);
            var result = client.Accounts.Delete("resGroup", "acctName");

            // Validate headers
            Assert.Equal(HttpMethod.Delete, handler.Requests[0].Method);
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);

            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public void AccountDeleteNoContentValidateMessage()
        {
            var noContentResponse = new HttpResponseMessage(HttpStatusCode.NoContent)
            {
                Content = new StringContent(@"")
            };

            noContentResponse.Headers.Add("x-ms-request-id", "1");

            var handler = new RecordedDelegatingHandler(noContentResponse);

            var client = GetBatchManagementClient(handler);
            var result = client.Accounts.Delete("resGroup", "acctName");

            // Validate headers
            Assert.Equal(HttpMethod.Delete, handler.Requests[0].Method);

            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
        }

        [Fact]
        public void AccountDeleteThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Accounts.Delete("foo", null));
            Assert.Throws<ArgumentNullException>(() => client.Accounts.Delete(null, "bar"));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Accounts.Delete("invalid+", "account"));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Accounts.Delete("rg", "invalid%"));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Accounts.Delete("rg", "/invalid"));
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
                        'coreQuota' : '20',
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
            var client = GetBatchManagementClient(handler);

            var result = client.Accounts.Get("foo", "acctName");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.Equal("South Central US", result.Resource.Location);
            Assert.Equal("acctName", result.Resource.Name);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName", result.Resource.Id);
            Assert.NotEmpty(result.Resource.Properties.AccountEndpoint);
            Assert.Equal(20, result.Resource.Properties.CoreQuota);
            Assert.Equal(100, result.Resource.Properties.PoolQuota);
            Assert.Equal(200, result.Resource.Properties.ActiveJobAndJobScheduleQuota);

            Assert.True(result.Resource.Tags.ContainsKey("tag1"));
        }

        [Fact]
        public void AccountGetThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Accounts.Get("foo", null));
            Assert.Throws<ArgumentNullException>(() => client.Accounts.Get(null, "bar"));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Accounts.Get("invalid+", "account"));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Accounts.Get("rg", "invalid%"));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Accounts.Get("rg", "/invalid"));
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
                                        'coreQuota' : '20',
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
                                        'coreQuota' : '20',
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
                                    'coreQuota' : '20',
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
                                    'coreQuota' : '20',
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
                                    'coreQuota' : '20',
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
                                    'coreQuota' : '20',
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
            var client = GetBatchManagementClient(handler);

            var result = client.Accounts.List(null);

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.True(result.Accounts.Count == 2);
            Assert.Equal("West US", result.Accounts[0].Location);
            Assert.Equal("acctName", result.Accounts[0].Name);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName", result.Accounts[0].Id);
            Assert.Equal("/subscriptions/12345/resourceGroups/bar/providers/Microsoft.Batch/batchAccounts/acctName1", result.Accounts[1].Id);
            Assert.NotEmpty(result.Accounts[0].Properties.AccountEndpoint);
            Assert.Equal(20, result.Accounts[0].Properties.CoreQuota);
            Assert.Equal(100, result.Accounts[0].Properties.PoolQuota);
            Assert.Equal(200, result.Accounts[1].Properties.ActiveJobAndJobScheduleQuota);

            Assert.True(result.Accounts[0].Tags.ContainsKey("tag1"));

            // all accounts under sub and a non-empty nextLink
            handler = new RecordedDelegatingHandler(allSubsResponseNonemptyNextLink) { StatusCodeToReturn = HttpStatusCode.OK };
            client = GetBatchManagementClient(handler);

            result = client.Accounts.List(null);

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // all accounts under sub with a non-empty nextLink response
            handler = new RecordedDelegatingHandler(allSubsResponseNonemptyNextLink1) { StatusCodeToReturn = HttpStatusCode.OK };
            client = GetBatchManagementClient(handler);

            result = client.Accounts.ListNext(result.NextLink);

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
                                    'coreQuota' : '20',
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
                                    'coreQuota' : '10',
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
            var client = GetBatchManagementClient(handler);

            var result = client.Accounts.List(new AccountListParameters
            {
                ResourceGroupName = "foo"
            });

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.True(result.Accounts.Count == 2);

            Assert.Equal("West US", result.Accounts[0].Location);
            Assert.Equal("acctName", result.Accounts[0].Name);
            Assert.Equal(result.Accounts[0].Id, @"/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName" );
            Assert.Equal( @"http://acctName.batch.core.windows.net/", result.Accounts[0].Properties.AccountEndpoint);
            Assert.Equal(AccountProvisioningState.Succeeded, result.Accounts[0].Properties.ProvisioningState);
            Assert.Equal(20, result.Accounts[0].Properties.CoreQuota);
            Assert.Equal(100, result.Accounts[0].Properties.PoolQuota);
            Assert.Equal(200, result.Accounts[0].Properties.ActiveJobAndJobScheduleQuota);

            Assert.Equal("South Central US", result.Accounts[1].Location);
            Assert.Equal("acctName1", result.Accounts[1].Name);
            Assert.Equal(@"/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Batch/batchAccounts/acctName1", result.Accounts[1].Id);
            Assert.Equal(@"http://acctName1.batch.core.windows.net/", result.Accounts[1].Properties.AccountEndpoint);
            Assert.Equal(AccountProvisioningState.Failed, result.Accounts[1].Properties.ProvisioningState);
            Assert.Equal(10, result.Accounts[1].Properties.CoreQuota);
            Assert.Equal(50, result.Accounts[1].Properties.PoolQuota);
            Assert.Equal(100, result.Accounts[1].Properties.ActiveJobAndJobScheduleQuota);

            Assert.Equal(2, result.Accounts[0].Tags.Count);
            Assert.True(result.Accounts[0].Tags.ContainsKey("tag2"));

            Assert.Equal(1, result.Accounts[1].Tags.Count);
            Assert.True(result.Accounts[1].Tags.ContainsKey("tag1"));

            Assert.Equal(@"originalRequestURl?$skipToken=opaqueStringThatYouShouldntCrack", result.NextLink);
        }

        [Fact]
        public void AccountListNextThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Accounts.ListNext(null));
        }

        [Fact]
        public void AccountKeysListValidateMessage()
        {
            var primaryKeyString = "primaryKeyString";
            var secondaryKeyString = "secondaryKeyString";

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'primary' : 'primaryKeyString',
                    'secondary' : 'secondaryKeyString',
                }")
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetBatchManagementClient(handler);

            var result = client.Accounts.ListKeys("foo", "acctName");

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.NotEmpty(result.PrimaryKey);
            Assert.Equal(primaryKeyString, result.PrimaryKey);
            Assert.NotEmpty(result.SecondaryKey);
            Assert.Equal(secondaryKeyString, result.SecondaryKey);
        }

        [Fact]
        public void AccountKeysListThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Accounts.ListKeys("foo", null));
            Assert.Throws<ArgumentNullException>(() => client.Accounts.ListKeys(null, "bar"));
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
            var client = GetBatchManagementClient(handler);

            var result = client.Accounts.RegenerateKey("foo", "acctName", new BatchAccountRegenerateKeyParameters
            {
                KeyName = AccountKeyType.Primary
            });

            // Validate headers - User-Agent for certs, Authorization for tokens
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("User-Agent"));

            // Validate result
            Assert.NotEmpty(result.PrimaryKey);
            Assert.Equal(primaryKeyString, result.PrimaryKey);
            Assert.NotEmpty(result.SecondaryKey);
            Assert.Equal(secondaryKeyString, result.SecondaryKey);
        }

        [Fact]
        public void AccountKeysRegenerateThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetBatchManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Accounts.RegenerateKey(null, "bar", new BatchAccountRegenerateKeyParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Accounts.RegenerateKey("foo", null, new BatchAccountRegenerateKeyParameters()));
            Assert.Throws<ArgumentNullException>(() => client.Accounts.RegenerateKey("foo", "bar", null));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Accounts.RegenerateKey("invalid+", "account", new BatchAccountRegenerateKeyParameters()));
            Assert.Throws<ArgumentOutOfRangeException>(() => client.Accounts.RegenerateKey("rg", "invalid%", new BatchAccountRegenerateKeyParameters()));
        }
    }
}
