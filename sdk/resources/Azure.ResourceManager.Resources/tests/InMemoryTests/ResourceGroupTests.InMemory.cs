// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Resources.Tests;
using NUnit.Framework;

namespace ResourceGroups.Tests
{
    public class InMemoryResourceGroupTests : ResourceOperationsTestsBase
    {
        public InMemoryResourceGroupTests(bool isAsync) : base(isAsync)
        {
        }

        public ResourcesManagementClient GetResourceManagementClient(HttpPipelineTransport transport)
        {
            ResourcesManagementClientOptions options = new ResourcesManagementClientOptions();
            options.Transport = transport;

            return CreateClient<ResourcesManagementClient>(
                TestEnvironment.SubscriptionId,
                new TestCredential(), options);
        }

        [Test]
        public async Task ResourceGroupCreateOrUpdateValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
                    'id': '/subscriptions/abc123/resourcegroups/csmrgr5mfggio',
                    'name': 'foo',
                    'location': 'WestEurope',
                    'tags' : {
                        'department':'finance',
                        'tagname':'tagvalue'
                    },
                    'properties': {
                        'provisioningState': 'Succeeded'
                      }
                }".Replace("'", "\"");
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = (await client.ResourceGroups.CreateOrUpdateAsync("foo", new ResourceGroup("WestEurope")
            {
                Tags = new Dictionary<string, string>() { { "department", "finance" }, { "tagname", "tagvalue" } }
            })).Value;

            var request = mockTransport.Requests[0];
            Stream stream = new MemoryStream();
            await request.Content.WriteToAsync(stream, default);
            stream.Position = 0;
            var resquestContent = new StreamReader(stream).ReadToEnd();
            var json = JsonDocument.Parse(resquestContent).RootElement;

            // Validate headers
            Assert.IsTrue(request.Headers.Contains(new HttpHeader("Content-Type", "application/json")));
            Assert.AreEqual(HttpMethod.Put.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate payload
            Assert.AreEqual("WestEurope", json.GetProperty("location").GetString());
            Assert.AreEqual("finance", json.GetProperty("tags").GetProperty("department").GetString());
            Assert.AreEqual("tagvalue", json.GetProperty("tags").GetProperty("tagname").GetString());

            // Validate response
            Assert.AreEqual("/subscriptions/abc123/resourcegroups/csmrgr5mfggio", result.Id);
            Assert.AreEqual("Succeeded", result.Properties.ProvisioningState);
            Assert.AreEqual("foo", result.Name);
            Assert.AreEqual("finance", result.Tags["department"]);
            Assert.AreEqual("tagvalue", result.Tags["tagname"]);
            Assert.AreEqual("WestEurope", result.Location);
        }

        [Test]
        public async Task ResourceGroupCreateOrUpdateThrowsExceptions()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.NoContent);
            var content = JsonDocument.Parse("{}").RootElement.ToString();
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            try
            {
                await client.ResourceGroups.CreateOrUpdateAsync(null, new ResourceGroup("westus"));
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Value cannot be null"));
            }

            try
            {
                await client.ResourceGroups.CreateOrUpdateAsync("foo", null);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Value cannot be null"));
            }
        }

        [Test]
        public async Task ResourceGroupExistsReturnsTrue()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.NoContent);
            var content = JsonDocument.Parse("{}").RootElement.ToString();
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = await client.ResourceGroups.CheckExistenceAsync("foo");

            // Validate payload
            var request = mockTransport.Requests[0];
            Assert.IsNull(request.Content);

            // Validate response
            Assert.NotNull(result);
        }

        [Test]
        public async Task ResourceGroupExistsReturnsFalse()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.NotFound);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = await client.ResourceGroups.CheckExistenceAsync(Guid.NewGuid().ToString());

            // Validate payload
            var request = mockTransport.Requests[0];
            Assert.IsNull(request.Content);

            // Validate response
            Assert.AreEqual(404, result.Status);
        }

        [Test]
        public async Task ResourceGroupExistsThrowsException()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.BadRequest);
            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);
            try
            {
                await client.ResourceGroups.CheckExistenceAsync("foo");
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }

        [Test]
        public async Task ResourceGroupPatchValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
                    'subscriptionId': '123456',
                    'name': 'foo',
                    'location': 'WestEurope',
                    'id': '/subscriptions/abc123/resourcegroups/csmrgr5mfggio',
                    'properties': {
                        'provisioningState': 'Succeeded'
                    }
                }".Replace("'", "\"");
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = (await client.ResourceGroups.UpdateAsync("foo", new ResourceGroupPatchable
            {
                Name = "foo",
            })).Value;

            var request = mockTransport.Requests[0];
            Stream stream = new MemoryStream();
            await request.Content.WriteToAsync(stream, default);
            stream.Position = 0;
            var resquestContent = new StreamReader(stream).ReadToEnd();
            var json = JsonDocument.Parse(resquestContent).RootElement;

            // Validate headers
            Assert.IsTrue(request.Headers.Contains(new HttpHeader("Content-Type", "application/json")));
            Assert.AreEqual(new HttpMethod("PATCH").Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate payload
            Assert.AreEqual("foo", json.GetProperty("name").GetString());

            // Validate response
            Assert.AreEqual("/subscriptions/abc123/resourcegroups/csmrgr5mfggio", result.Id);
            Assert.AreEqual("Succeeded", result.Properties.ProvisioningState);
            Assert.AreEqual("foo", result.Name);
            Assert.AreEqual("WestEurope", result.Location);
        }

        [Test]
        public async Task ResourceGroupGetValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
                    'id': '/subscriptions/abc123/resourcegroups/csmrgr5mfggio',
                    'name': 'foo',
                    'location': 'WestEurope',
                    'properties': {
                        'provisioningState': 'Succeeded'
                     }
                }".Replace("'", "\"");
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = (await client.ResourceGroups.GetAsync("foo")).Value;

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate result
            Assert.AreEqual("/subscriptions/abc123/resourcegroups/csmrgr5mfggio", result.Id);
            Assert.AreEqual("WestEurope", result.Location);
            Assert.AreEqual("foo", result.Name);
            Assert.AreEqual("Succeeded", result.Properties.ProvisioningState);
            Assert.True(result.Properties.ProvisioningState == "Succeeded");
        }

        [Test]
        public async Task ResourceGroupNameAcceptsAllAllowableCharacters()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
                    'id': '/subscriptions/abc123/resourcegroups/csmrgr5mfggio',
                    'name': 'foo',
                    'location': 'WestEurope',
                    'properties': {
                        'provisioningState': 'Succeeded'
                     }
                }".Replace("'", "\"");
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            await client.ResourceGroups.GetAsync("foo-123_(bar)");
        }

        [Test]
        public async Task ResourceGroupListAllValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{ 
                'value': [{ 
                    'id': '/subscriptions/abc123/resourcegroups/csmrgr5mfggio',
                    'name': 'myresourcegroup1',
                    'location': 'westus',
                    'properties': {
                        'provisioningState': 'Succeeded'
                      }
                    }, 
                    { 
                    'id': '/subscriptions/abc123/resourcegroups/fdfdsdsf',
                    'name': 'myresourcegroup2',
                    'location': 'eastus', 
                    'properties': {
                        'provisioningState': 'Succeeded'
                      }
                    } 
                ]}".Replace("'", "\"");
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = await client.ResourceGroups.ListAsync(null).ToEnumerableAsync();

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate result
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("myresourcegroup1", result.First().Name);
            Assert.AreEqual("Succeeded", result.First().Properties.ProvisioningState);
            Assert.AreEqual("/subscriptions/abc123/resourcegroups/csmrgr5mfggio", result.First().Id);
        }

        [Test]
        public async Task ResourceGroupListAllWorksForEmptyLists()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = JsonDocument.Parse(("{\"value\": []}")).RootElement.ToString();
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = await client.ResourceGroups.ListAsync(null).ToEnumerableAsync();

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate result
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task ResourceGroupListValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{ 
                'value': [{ 
                    'name': 'myresourcegroup1',
                    'location': 'westus', 
                    'locked': 'true'
                    }, 
                    { 
                    'name': 'myresourcegroup2',
                    'location': 'eastus', 
                    'locked': 'false' 
                    } 
                ]}".Replace("'", "\"");
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = await client.ResourceGroups.ListAsync(top:5).ToEnumerableAsync();

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));
            Assert.IsTrue(request.Uri.ToString().Contains("$top=5"));

            // Validate result
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("myresourcegroup1", result.First().Name);
        }

        [Test]
        public async Task ResourceGroupDeleteValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.Accepted);
            var header = new HttpHeader("Location", "http://foo");
            mockResponse.AddHeader(header);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            await client.ResourceGroups.StartDeleteAsync("foo");
        }

        [Test]
        public async Task ResourceGroupDeleteThrowsExceptions()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.NoContent);
            var content = JsonDocument.Parse("{}").RootElement.ToString();
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            try
            {
                var raw = await client.ResourceGroups.StartDeleteAsync(null);
                await WaitForCompletionAsync(raw);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
            // No use since We don't check parameter value any more
            //try
            //{
            //    var raw = await client.ResourceGroups.StartDeleteAsync("~`123");
            //    await WaitForCompletionAsync(raw);
            //}
            //catch (Exception ex)
            //{

            //    Assert.IsTrue(ex.Message.Contains("Value cannot be null"));
            //}
        }
    }
}
