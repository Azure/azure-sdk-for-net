// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Specs.Azure.Core.Page;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.Core.Page
{
    public class AzureCorePageTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_Core_Page_listWithPage() => Test(async (host) =>
        {
            var responses = new PageClient(host, null).GetWithPageAsync();
            var sum = 0;
            await foreach (var response in responses)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(response.Id, Is.EqualTo(1));
                    Assert.That(response.Name, Is.EqualTo("Madge"));
                    Assert.That(response.Etag.ToString(), Is.EqualTo("11bdc430-65e8-45ad-81d9-8ffa60d55b59"));
                });
                sum++;
            };
            Assert.That(sum, Is.EqualTo(1));
        });

        [SpectorTest]
        public Task Azure_Core_Page_listWithParameters() => Test(async (host) =>
        {
            var bodyInput = new ListItemInputBody("Madge");
            var responses = new PageClient(host, null).GetWithParametersAsync(bodyInput, ListItemInputExtensibleEnum.Second);
            var sum = 0;
            await foreach (var response in responses)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(response.Id, Is.EqualTo(1));
                    Assert.That(response.Name, Is.EqualTo("Madge"));
                    Assert.That(response.Etag.ToString(), Is.EqualTo("11bdc430-65e8-45ad-81d9-8ffa60d55b59"));
                });
                sum++;
            };
            Assert.That(sum, Is.EqualTo(1));
        });

        [SpectorTest]
        public Task Azure_Core_Page_TwoModelsAsPageItem() => Test(async (host) =>
        {
            var twoModelsAsPageItemClient = new PageClient(host, null).GetTwoModelsAsPageItemClient();
            var responses_firstItem = twoModelsAsPageItemClient.GetFirstItemAsync();
            var responses_secondItem = twoModelsAsPageItemClient.GetSecondItemAsync();
            var sum = 0;
            await foreach (var response in responses_firstItem)
            {
                Assert.That(response.Id, Is.EqualTo(1));
                sum++;
            };
            Assert.That(sum, Is.EqualTo(1));
            sum = 0;
            await foreach (var response in responses_secondItem)
            {
                Assert.That(response.Name, Is.EqualTo("Madge"));
                sum++;
            };
            Assert.That(sum, Is.EqualTo(1));
        });

        [SpectorTest]
        public Task Azure_Core_Page_listWithCustomPageModel() => Test(async (host) =>
        {
            var responses = new PageClient(host, null).GetWithCustomPageModelAsync();
            var sum = 0;
            await foreach (var response in responses)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(response.Id, Is.EqualTo(1));
                    Assert.That(response.Name, Is.EqualTo("Madge"));
                    Assert.That(response.Etag.ToString(), Is.EqualTo("11bdc430-65e8-45ad-81d9-8ffa60d55b59"));
                });
                sum++;
            };
            Assert.That(sum, Is.EqualTo(1));
        });

        [SpectorTest]
        public Task Azure_Core_Page_withParameterizedNextLink() => Test(async (host) =>
        {
            var responses = new PageClient(host, null).WithParameterizedNextLinkAsync(includePending: true, select: "name");
            var sum = 0;
            await foreach (var response in responses)
            {
                if (sum == 0)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(response.Id, Is.EqualTo(1));
                        Assert.That(response.Name, Is.EqualTo("User1"));
                    });
                }
                else
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(response.Id, Is.EqualTo(2));
                        Assert.That(response.Name, Is.EqualTo("User2"));
                    });
                }

                sum++;
            }
            Assert.That(sum, Is.EqualTo(2));
        });
    }
}