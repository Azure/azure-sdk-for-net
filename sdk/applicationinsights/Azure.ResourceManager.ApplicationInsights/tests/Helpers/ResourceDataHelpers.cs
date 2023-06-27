// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.ApplicationInsights.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Azure.Core;
using System;
using System.Text;
using Azure.ResourceManager.Resources;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using System.IO;

namespace Azure.ResourceManager.ApplicationInsights.Tests.Helpers
{
    public static class ResourceDataHelpers
    {
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)
        {
            dest.Clear();
            foreach (var kv in src)
            {
                dest.Add(kv);
            }

            return dest;
        }

        public static void AssertResource(ResourceData r1, ResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
        }

        #region Component
        public static ApplicationInsightsComponentData GetComponentData(AzureLocation location)
        {
            var data = new ApplicationInsightsComponentData(location, "device")
            {
                ApplicationType = ApplicationType.Web,
                FlowType = FlowType.Bluefield,
                RequestSource = new RequestSource(".NET SDK test")
            };
            return data;
        }

        public static void AssertComponment(ApplicationInsightsComponentData data1, ApplicationInsightsComponentData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Location, data2.Location);
            Assert.AreEqual(data1.ConnectionString, data2.ConnectionString);
            Assert.AreEqual(data1.ApplicationType, data2.ApplicationType);
            Assert.AreEqual(data1.FlowType, data2.FlowType);
        }
        #endregion

        #region WebTest
        public static WebTestData GetWebTestData(AzureLocation location, string resourcegroupName, string componentName, string webtestName)
        {
            var data = new WebTestData(location)
            {
                WebTestKind = WebTestKind.Ping,
                SyntheticMonitorId = "my-webtest-my-component",
                IsEnabled = true,
                WebTestName = webtestName,
                Locations =
                {
                    new WebTestGeolocation()
                    {
                        Location = "us-fl-mia-edge",
                    }
                },
                FrequencyInSeconds = 900,
                TimeoutInSeconds = 120,
                Kind = WebTestKind.Ping,
                IsRetryEnabled = true,
                Configuration = new WebTestPropertiesConfiguration()
                {
                    WebTest = "<WebTest Name=\"my-webtest\" Id=\"678ddf96-1ab8-44c8-9274-123456789abc\" Enabled=\"True\" CssProjectStructure=\"\" CssIteration=\"\" Timeout=\"120\" WorkItemIds=\"\" xmlns=\"http://microsoft.com/schemas/VisualStudio/TeamTest/2010\" Description=\"\" CredentialUserName=\"\" CredentialPassword=\"\" PreAuthenticate=\"True\" Proxy=\"default\" StopOnError=\"False\" RecordedResultFile=\"\" ResultsLocale=\"\" ><Items><Request Method=\"GET\" Guid=\"a4162485-9114-fcfc-e086-123456789abc\" Version=\"1.1\" Url=\"http://my-component.azurewebsites.net\" ThinkTime=\"0\" Timeout=\"120\" ParseDependentRequests=\"True\" FollowRedirects=\"True\" RecordResult=\"True\" Cache=\"False\" ResponseTimeGoal=\"0\" Encoding=\"utf-8\" ExpectedHttpStatusCode=\"200\" ExpectedResponseUrl=\"\" ReportingName=\"\" IgnoreHttpStatusCode=\"False\" /></Items></WebTest>"
                },
                Tags =
                {
                    {$"hidden-link:/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/{resourcegroupName}/providers/Microsoft.Insights/components/{componentName}", "Resource"},
                }
            };
            return data;
        }

        public static void AssertWebTestData(WebTestData data1, WebTestData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.FrequencyInSeconds, data2.FrequencyInSeconds);
            Assert.AreEqual(data1.TimeoutInSeconds, data2.TimeoutInSeconds);
            Assert.AreEqual(data1.IsEnabled, data2.IsEnabled);
        }
        #endregion

        #region MyWorkBook
        public static MyWorkbookData GetMyWorkbookData(AzureLocation location)
        {
            var data = new MyWorkbookData()
            {
                Kind = ApplicationInsightsKind.User,
                DisplayName = "Blah Blah Blah",
                Location = location,
                Category = "workbook",
                SerializedData = "{\"version\":\"Notebook/1.0\",\"items\":[{\"type\":1,\"content\":\"{\"json\":\"## New workbook\\r\\n---\\r\\n\\r\\nWelcome to your new workbook.  This area will display text formatted as markdown.\\r\\n\\r\\n\\r\\nWe've included a basic analytics query to get you started. Use the `Edit` button below each section to configure it or add more sections.\"}\",\"halfWidth\":null,\"conditionalVisibility\":null},{\"type\":3,\"content\":\"{\"version\":\"KqlItem/1.0\",\"query\":\"union withsource=TableName *\\n| summarize Count=count() by TableName\\n| render barchart\",\"showQuery\":false,\"size\":1,\"aggregation\":0,\"showAnnotations\":false}\",\"halfWidth\":null,\"conditionalVisibility\":null}],\"isLocked\":false}",
            };
            return data;
        }

        public static void AssertWorkBookData(MyWorkbookData data1, MyWorkbookData data2)
        {
            Assert.AreEqual(data1.Location, data2.Location);
            Assert.AreEqual(data1.Name, data2.Name);
            Assert.AreEqual(data1.Id, data2.Id);
            Assert.AreEqual(data1.ResourceType, data2.ResourceType);
        }
        #endregion

        #region LinkedStorageAccount
        public static ComponentLinkedStorageAccountData GetStorageAccountData()
        {
            return new ComponentLinkedStorageAccountData()
            {
                LinkedStorageAccount = $"/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourcegroups/deleteme0626/providers/Microsoft.Storage/storageAccounts/componentlinkedtest"
            };
        }

        public static void AssertLinkedStorageAccountData(ComponentLinkedStorageAccountData data1, ComponentLinkedStorageAccountData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.LinkedStorageAccount, data2.LinkedStorageAccount);
        }
        #endregion

        #region workbook
        public static WorkbookData GetWorkbookData(AzureLocation location)
        {
            var data = new WorkbookData(location)
            {
                DisplayName = "Sample workbook",
                SerializedData = "{\"version\":\"Notebook/1.0\",\"items\":[{\"type\":1,\"content\":\"{\"json\":\"## New workbook\\r\\n---\\r\\n\\r\\nWelcome to your new workbook.  This area will display text formatted as markdown.\\r\\n\\r\\n\\r\\nWe've included a basic analytics query to get you started. Use the `Edit` button below each section to configure it or add more sections.\"}\",\"halfWidth\":null,\"conditionalVisibility\":null},{\"type\":3,\"content\":\"{\"version\":\"KqlItem/1.0\",\"query\":\"union withsource=TableName *\\n| summarize Count=count() by TableName\\n| render barchart\",\"showQuery\":false,\"size\":1,\"aggregation\":0,\"showAnnotations\":false}\",\"halfWidth\":null,\"conditionalVisibility\":null}],\"isLocked\":false}",
                Category = "workbook",
                Description = "Sample workbook",
                Kind = WorkbookSharedTypeKind.Shared,
                Tags =
                {
                ["TagSample01"] = "sample01",
                ["TagSample02"] = "sample02",
                },
            };
            return data;
        }

        public static void AssertWorkBook(WorkbookData data1, WorkbookData data2)
        {
            AssertResource(data1, data2 );
            Assert.AreEqual(data1.DisplayName, data2.DisplayName);
            Assert.AreEqual(data1.Category, data2.Category);
            Assert.AreEqual(data1.Tags, data2.Tags);
            Assert.AreEqual(data1.SerializedData, data2.SerializedData);
        }
        #endregion

        #region WorkbookTemplate
        public static WorkbookTemplateData GetWorkbookTemplateData(AzureLocation location)
        {
            var data = new WorkbookTemplateData(location)
            {
                Priority = 1,
                Author = "Contoso",
                TemplateData = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    ["$schema"] = "https://github.com/Microsoft/Application-Insights-Workbooks/blob/master/schema/workbook.json",
                    ["items"] = new object[] { new Dictionary<string, object>()
{
["name"] = "text - 2",
["type"] = "1",
["content"] = new Dictionary<string, object>()
{
["json"] = "## New workbook\n---\n\nWelcome to your new workbook.  This area will display text formatted as markdown.\n\n\nWe've included a basic analytics query to get you started. Use the `Edit` button below each section to configure it or add more sections."}}, new Dictionary<string, object>()
{
["name"] = "query - 2",
["type"] = "3",
["content"] = new Dictionary<string, object>()
{
["exportToExcelOptions"] = "visible",
["query"] = "union withsource=TableName *\n| summarize Count=count() by TableName\n| render barchart",
["queryType"] = "0",
["resourceType"] = "microsoft.operationalinsights/workspaces",
["size"] = "1",
["version"] = "KqlItem/1.0"}} },
                    ["styleSettings"] = new Dictionary<string, object>()
                    {
                    },
                    ["version"] = "Notebook/1.0"
                }),
                Galleries =
{
new WorkbookTemplateGallery()
{
Name = "Simple Template",
Category = "Failures",
WorkbookTemplateGalleryType = "tsg",
Order = 100,
ResourceType = "microsoft.insights/components",
}
},
                Tags =
{
},
            };
            return data;
        }

        public static void AssertTemplateData(WorkbookTemplateData data1, WorkbookTemplateData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Author, data2.Author);
            Assert.AreEqual(data1.Location, data2.Location);
            Assert.AreEqual(data1.Priority, data2.Priority);
        }
        #endregion
    }
}
