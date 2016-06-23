// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Azure.Management.Logic;    
    using System.IO;

    public class IntegrationAccountMapInMemoryTests : BaseInMemoryTests
    {
        public IntegrationAccountMapInMemoryTests()
        {
            var content = File.ReadAllText(@"TestData/IntegrationAccountMapResponseContent.json");

            this.MapList = new StringContent(string.Format(Constants.ListFormat,
                content, Constants.NextPageLink));
            this.Map = new StringContent(content);
        }

        private StringContent MapList { get; set; }

        private StringContent Map { get; set; }

        [Fact]
        public void IntegrationAccountMap_ListByResourceGroup_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(
                () => client.IntegrationAccountMaps.List(null, "IntegrationAccount",null));
            Assert.Throws<CloudException>(() => client.IntegrationAccountMaps.List(ResourceGroupName, "IntegrationAccount"));
        }

        [Fact]
        public void IntegrationAccountMap_ListByResourceGroup_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.MapList
            };

            var result = client.IntegrationAccountMaps.List(ResourceGroupName, "IntegrationAccount");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateMapList(result);
        }

        [Fact]
        public void IntegrationAccountMap_ListByResourceGroupNext_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountMaps.ListNext(null));
            Assert.Throws<CloudException>(() => client.IntegrationAccountMaps.ListNext(Constants.NextPageLink));
        }

        [Fact]
        public void IntegrationAccountMap_ListByResourceGroupNext_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.MapList
            };

            var result = client.IntegrationAccountMaps.ListNext(Constants.NextPageLink);

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateMapList(result);
        }

        [Fact]
        public void IntegrationAccountMap_CreateOrUpdate_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountMaps.CreateOrUpdate(null, "IntegrationAccountName", "MapName", new IntegrationAccountMap()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountMaps.CreateOrUpdate(ResourceGroupName, null, "MapName", new IntegrationAccountMap()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountMaps.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", null, new IntegrationAccountMap()));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountMaps.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "MapName", null));
            Assert.Throws<CloudException>(() => client.IntegrationAccountMaps.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "MapName", new IntegrationAccountMap()));
        }

        [Fact]
        public void IntegrationAccountMap_CreateOrUpdate_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Map
            };

            var map = client.IntegrationAccountMaps.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "MapName", new IntegrationAccountMap());

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Put);

            // Validates result.
            this.ValidateMap(map);
        }

        [Fact]
        public void IntegrationAccountMap_CreateOrUpdate_Created()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = this.Map
            };

            var map = client.IntegrationAccountMaps.CreateOrUpdate(ResourceGroupName, "IntegrationAccountName", "MapName", new IntegrationAccountMap());

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Put);

            // Validates result.
            this.ValidateMap(map);
        }

        [Fact]
        public void IntegrationAccountMap_Delete_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountMaps.Delete(null, "IntegrationAccountName","MapName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountMaps.Delete(ResourceGroupName, null, "MapName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountMaps.Delete(ResourceGroupName, "IntegrationAccountName", null));
            Assert.Throws<CloudException>(() => client.IntegrationAccountMaps.Delete(ResourceGroupName, "IntegrationAccountName", "MapName"));
        }

        [Fact]
        public void IntegrationAccountMap_Delete_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };

            client.IntegrationAccountMaps.Delete(ResourceGroupName, "IntegrationAccountName", "MapName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Delete);
        }

        [Fact]
        public void IntegrationAccountMap_Delete_NoContent()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent
            };

            client.IntegrationAccountMaps.Delete(ResourceGroupName, "IntegrationAccountName","MapName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Delete);
        }

        [Fact]
        public void IntegrationAccountMap_Get_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.IntegrationAccountMaps.Get(null, "IntegrationAccountName", "MapName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountMaps.Get(ResourceGroupName, null, "MapName"));
            Assert.Throws<ValidationException>(() => client.IntegrationAccountMaps.Get(ResourceGroupName, "IntegrationAccountName", null));
            Assert.Throws<CloudException>(() => client.IntegrationAccountMaps.Get(ResourceGroupName, "IntegrationAccountName", "MapName"));
        }

        [Fact]
        public void IntegrationAccountMap_Get_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateIntegrationAccountClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Map
            };

            var result = client.IntegrationAccountMaps.Get(ResourceGroupName, "IntegrationAccountName", "MapName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateMap(result);
        }

        private void ValidateMapList(IPage<IntegrationAccountMap> result)
        {            
            Assert.Equal(1, result.Count());
            this.ValidateMap(result.First());
            Assert.Equal(Constants.NextPageLink, result.NextPageLink);
        }

        private void ValidateMap(IntegrationAccountMap map)
        {
            Assert.Equal("/subscriptions/f34b22a3-2202-4fb1-b040-1332bd928c84/resourceGroups/IntegrationAccountSdkTest/providers/Microsoft.Logic/integrationAccounts/IntegrationAccount5935/maps/IntegrationAccountMap1", map.Id);            
            Assert.Equal("IntegrationAccountMap1", map.Name);
            Assert.Equal("Microsoft.Logic/integrationAccounts/maps", map.Type);

            Assert.Equal(MapType.Xslt, map.MapType);
            Assert.NotNull(map.ContentLink.Uri);
            Assert.Equal("\"0x8D33E418F1236A3\"", map.ContentLink.ContentVersion);
            Assert.Equal(3056, map.ContentLink.ContentSize);
            Assert.Equal("md5", map.ContentLink.ContentHash.Algorithm);
            Assert.NotNull(map.ContentLink.ContentHash.Value);


            //"2016-02-26T00:12:48.7095746Z"
            Assert.Equal(2016, map.CreatedTime.Value.Year);
            Assert.Equal(02, map.CreatedTime.Value.Month);
            Assert.Equal(26, map.CreatedTime.Value.Day);
            Assert.Equal(00, map.CreatedTime.Value.Hour);
            Assert.Equal(12, map.CreatedTime.Value.Minute);
            Assert.Equal(48, map.CreatedTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, map.CreatedTime.Value.Kind);

            //{2/24/2016 7:49:39 PM}
            Assert.Equal(2016, map.ChangedTime.Value.Year);
            Assert.Equal(02, map.ChangedTime.Value.Month);
            Assert.Equal(26, map.ChangedTime.Value.Day);
            Assert.Equal(00, map.ChangedTime.Value.Hour);
            Assert.Equal(12, map.ChangedTime.Value.Minute);
            Assert.Equal(48, map.ChangedTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, map.ChangedTime.Value.Kind);

        }
    }
}