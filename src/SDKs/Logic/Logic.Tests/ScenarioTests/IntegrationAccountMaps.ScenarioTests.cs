// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;
    using System;

    /// <summary>
    /// Scenario tests for the integration accounts map.
    /// </summary>
    [Collection("IntegrationAccountMapScenarioTests")]
    public class IntegrationAccountMapScenarioTests : ScenarioTestsBase, IDisposable
    {
        private readonly MockContext context;
        private readonly ILogicManagementClient client;
        private readonly string integrationAccountName;
        private readonly string mapName;
        private readonly IntegrationAccount integrationAccount;

        public IntegrationAccountMapScenarioTests()
        {
            this.context = MockContext.Start(className: this.TestClassName);
            this.client = this.GetClient(this.context);

            this.integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
            this.integrationAccount = this.client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.CreateIntegrationAccount(this.integrationAccountName));

            this.mapName = TestUtilities.GenerateName(Constants.IntegrationAccountMapPrefix);
        }

        public void Dispose()
        {
            this.client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, this.integrationAccountName);

            this.client.Dispose();
            this.context.Dispose();
        }

        [Fact]
        public void IntegrationAccountMaps_CreateXslt_OK()
        {
            var map = this.CreateIntegrationAccountMap(this.mapName, MapType.Xslt);
            var createdMap = this.client.IntegrationAccountMaps.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.mapName,
                map);

            this.ValidateMap(map, createdMap);
        }

        [Fact]
        public void IntegrationAccountMaps_CreateXslt20_OK()
        {
            var map = this.CreateIntegrationAccountMap(this.mapName, MapType.Xslt20);
            var createdMap = this.client.IntegrationAccountMaps.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.mapName,
                map);

            this.ValidateMap(map, createdMap);
        }

        [Fact]
        public void IntegrationAccountMaps_CreateXslt30_OK()
        {
            var map = this.CreateIntegrationAccountMap(this.mapName, MapType.Xslt30);
            var createdMap = this.client.IntegrationAccountMaps.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.mapName,
                map);

            this.ValidateMap(map, createdMap);
        }

        [Fact]
        public void IntegrationAccountMaps_CreateLiquid_OK()
        {
            var map = this.CreateIntegrationAccountMap(this.mapName, MapType.Liquid);
            var createdMap = this.client.IntegrationAccountMaps.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.mapName,
                map);

            this.ValidateMap(map, createdMap);
        }

        [Fact]
        public void IntegrationAccountMaps_Get_OK()
        {
            var map = this.CreateIntegrationAccountMap(this.mapName, MapType.Xslt);
            var createdMap = this.client.IntegrationAccountMaps.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.mapName,
                map);

            var retrievedMap = this.client.IntegrationAccountMaps.Get(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.mapName);

            this.ValidateMap(map, retrievedMap);
        }

        [Fact]
        public void IntegrationAccountMaps_List_OK()
        {
            var map1 = this.CreateIntegrationAccountMap(this.mapName, MapType.Xslt);
            var createdMap = this.client.IntegrationAccountMaps.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.mapName,
                map1);

            var mapName2 = TestUtilities.GenerateName(Constants.IntegrationAccountMapPrefix);
            var map2 = this.CreateIntegrationAccountMap(mapName2, MapType.Xslt20);
            var createdMap2 = this.client.IntegrationAccountMaps.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                mapName2,
                map2);

            var mapName3 = TestUtilities.GenerateName(Constants.IntegrationAccountMapPrefix);
            var map3 = this.CreateIntegrationAccountMap(mapName3, MapType.Liquid);
            var createdMap3 = this.client.IntegrationAccountMaps.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                mapName3,
                map3);

            var maps = this.client.IntegrationAccountMaps.List(Constants.DefaultResourceGroup, this.integrationAccountName);

            Assert.Equal(3, maps.Count());
            this.ValidateMap(map1, maps.Single(x => x.MapType == map1.MapType));
            this.ValidateMap(map2, maps.Single(x => x.MapType == map2.MapType));
            this.ValidateMap(map3, maps.Single(x => x.MapType == map3.MapType));
        }

        [Fact]
        public void IntegrationAccountMaps_Update_OK()
        {
            var map = this.CreateIntegrationAccountMap(this.mapName, MapType.Xslt);
            var createdMap = this.client.IntegrationAccountMaps.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.mapName,
                map);

            var newMap = this.CreateIntegrationAccountMap(this.mapName, MapType.Xslt);

            var updatedMap = this.client.IntegrationAccountMaps.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.mapName,
                newMap);

            this.ValidateMap(newMap, updatedMap);
        }

        [Fact]
        public void IntegrationAccountMaps_Delete_OK()
        {
            var map = this.CreateIntegrationAccountMap(this.mapName, MapType.Xslt);
            var createdMap = this.client.IntegrationAccountMaps.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.mapName,
                map);

            this.client.IntegrationAccountMaps.Delete(Constants.DefaultResourceGroup, this.integrationAccountName, this.mapName);
            Assert.Throws<CloudException>(() => this.client.IntegrationAccountMaps.Get(Constants.DefaultResourceGroup, this.integrationAccountName, this.mapName));
        }

        [Fact]
        public void IntegrationAccountMaps_DeleteWhenDeleteIntegrationAccount_OK()
        {
            var map = this.CreateIntegrationAccountMap(this.mapName, MapType.Xslt);
            var createdMap = this.client.IntegrationAccountMaps.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.mapName,
                map);

            this.client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, this.integrationAccountName);
            Assert.Throws<CloudException>(() => this.client.IntegrationAccountMaps.Get(Constants.DefaultResourceGroup, this.integrationAccountName, this.mapName));
        }

        [Fact]
        public void IntegrationAccountMaps_ListContentCallbackUrl_OK()
        {
            var map = this.CreateIntegrationAccountMap(this.mapName, MapType.Xslt);
            var createdMap = this.client.IntegrationAccountMaps.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.mapName,
                map);

            var contentCallbackUrl = this.client.IntegrationAccountMaps.ListContentCallbackUrl(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.mapName,
                new GetCallbackUrlParameters
                {
                    KeyType = "Primary"
                });

            Assert.Equal("GET", contentCallbackUrl.Method);
            Assert.Contains(this.mapName, contentCallbackUrl.Value);
        }

        #region Private

        private void ValidateMap(IntegrationAccountMap expected, IntegrationAccountMap actual)
        {
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.MapType, actual.MapType);
            Assert.NotNull(actual.ContentLink.ContentSize);
            Assert.NotEmpty(actual.ContentLink.Uri);
            Assert.NotNull(actual.CreatedTime);
            Assert.NotNull(actual.ChangedTime);
        }

        private IntegrationAccountMap CreateIntegrationAccountMap(string mapName, string mapType)
        {
            string contentType;
            string mapContent;

            switch (mapType)
            {
                case MapType.Xslt:
                    contentType = "application/xml";
                    mapContent = this.XsltMapContent;
                    break;
                case MapType.Xslt20:
                    contentType = "application/xml";
                    mapContent = this.Xslt20MapContent;
                    break;
                case MapType.Xslt30:
                    contentType = "application/xml";
                    mapContent = this.Xslt30MapContent;
                    break;
                case MapType.Liquid:
                default:
                    contentType = "text/plain";
                    mapContent = this.LiquidMapContent;
                    break;
            }

            var map = new IntegrationAccountMap(mapType,
                name: mapName,
                location: Constants.DefaultLocation,
                content: mapContent,
                contentType: contentType);

            return map;
        }

        private string XsltMapContent
        {
            get
            {
                return @"<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
	                        <xsl:template match='/hello-world'>
		                        <HTML>
			                        <HEAD>
				                        <TITLE/>
			                        </HEAD>
			                        <BODY>
				                        <H1>
					                        <xsl:value-of select='greeting'/>
				                        </H1>
				                        <xsl:apply-templates select='greeter'/>
			                        </BODY>
		                        </HTML>
	                        </xsl:template>
	                        <xsl:template match='greeter'>
		                        <DIV>
			                        from
			                        <I>
				                        <xsl:value-of select='.'/>
			                        </I>
		                        </DIV>
	                        </xsl:template>
                        </xsl:stylesheet>";
            }
        }

        private string Xslt20MapContent
        {
            get
            {
                return @"<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='2.0'>
	                        <xsl:template match='@*|node()'>
		                        <xsl:copy>
			                        <xsl:apply-templates select='@*|node()'/>
		                        </xsl:copy>
	                        </xsl:template>
                        </xsl:stylesheet>";
            }
        }

        private string Xslt30MapContent
        {
            get
            {
                return @"<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' xmlns:xs='http://www.w3.org/2001/XMLSchema' version='3.0'>
	                        <xsl:output method='text'/>
	                        <xsl:template match='/'>
		                        <xsl:value-of select='company/employee/name'/>
		                        <xsl:variable name='test'>
			                        <xsl:text>company/employee/name</xsl:text>
		                        </xsl:variable>
		                        <xsl:evaluate xpath='$test'/>
	                        </xsl:template>
                        </xsl:stylesheet>";
            }
        }

        private string LiquidMapContent
        {
            get
            {
                return @"{% if user %}
                        Hello, {{ user.firstname }}
                        {% else %}
                        Hello World!
                        {% endif %}";
            }
        }

        #endregion Private
    }
}