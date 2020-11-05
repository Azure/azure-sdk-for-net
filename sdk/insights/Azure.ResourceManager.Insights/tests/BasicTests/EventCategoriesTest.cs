// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Insights.Models;
using Insights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Insights.Tests.BasicTests
{
    [AsyncOnly]
    public class EventCategoriesTest : InsightsManagementClientMockedBase
    {
        public EventCategoriesTest(bool isAsync)
            : base(isAsync)
        { }

        [Test]
        public async Task EventCategoriesListTest()
        {
            var EventCategoriesList = new List<LocalizableString>() { new LocalizableString("LocalizableString1") };
            var content = @"
{
    'value':[
                {
                    'value':'LocalizableString1',
                    'localizedValue':null
                }
            ]
}
".Replace("'", "\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = await insightsClient.EventCategories.ListAsync().ToEnumerableAsync();
            AreEqual(EventCategoriesList, result);
        }
    }
}
