// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using NUnit.Framework;
using Payload.Pageable;

namespace TestProjects.Spector.Tests.Http.Payload.Pageable
{
    public class PageSizePaginationTests : SpectorTestBase
    {
        private static readonly string[] ExpectedPetNames = ["dog", "cat", "bird", "fish"];

        [SpectorTest]
        public Task WithoutContinuationConvenienceMethod() => Test(async (host) =>
        {
            var result = new PageableClient(host, null).GetPageSizeClient().GetWithoutContinuationAsync();
            await ValidatePagesAsync(result.AsPages(), 4, ValidatePet);
        });

        [SpectorTest]
        public Task WithoutContinuationConvenienceMethodSync() => Test((host) =>
        {
            var result = new PageableClient(host, null).GetPageSizeClient().GetWithoutContinuation();
            ValidatePages(result.AsPages(), 4, ValidatePet);
            return Task.CompletedTask;
        });

        [SpectorTest]
        public Task WithoutContinuationProtocolMethod() => Test(async (host) =>
        {
            var result = new PageableClient(host, null).GetPageSizeClient().GetWithoutContinuationAsync(new RequestContext());
            await ValidatePagesAsync(result.AsPages(), 4, ValidatePet);
        });

        [SpectorTest]
        public Task WithoutContinuationProtocolMethodSync() => Test((host) =>
        {
            var result = new PageableClient(host, null).GetPageSizeClient().GetWithoutContinuation(new RequestContext());
            ValidatePages(result.AsPages(), 4, ValidatePet);
            return Task.CompletedTask;
        });

        [SpectorTest]
        [TestCase(2, null, 2)]
        [TestCase(4, null, 4)]
        [TestCase(null, 2, 2)]
        [TestCase(null, 4, 4)]
        [TestCase(2, 4, 4)]
        [TestCase(4, 2, 2)]
        public Task WithPageSizeConvenienceMethod(int? pageSize, int? pageSizeHint, int expectedCount) => Test(async (host) =>
        {
            var result = new PageableClient(host, null).GetPageSizeClient().GetWithPageSizeAsync(pageSize);
            await ValidatePagesAsync(result.AsPages(pageSizeHint: pageSizeHint), expectedCount, ValidatePet);
        });

        [SpectorTest]
        [TestCase(2, null, 2)]
        [TestCase(4, null, 4)]
        [TestCase(null, 2, 2)]
        [TestCase(null, 4, 4)]
        [TestCase(2, 4, 4)]
        [TestCase(4, 2, 2)]
        public Task WithPageSizeConvenienceMethodSync(int? pageSize, int? pageSizeHint, int expectedCount) => Test((host) =>
        {
            var result = new PageableClient(host, null).GetPageSizeClient().GetWithPageSize(pageSize);
            ValidatePages(result.AsPages(pageSizeHint: pageSizeHint), expectedCount, ValidatePet);
            return Task.CompletedTask;
        });

        [SpectorTest]
        [TestCase(2, null, 2)]
        [TestCase(4, null, 4)]
        [TestCase(null, 2, 2)]
        [TestCase(null, 4, 4)]
        [TestCase(2, 4, 4)]
        [TestCase(4, 2, 2)]
        public Task WithPageSizeProtocolMethod(int? pageSize, int? pageSizeHint, int expectedCount) => Test(async (host) =>
        {
            var result = new PageableClient(host, null).GetPageSizeClient().GetWithPageSizeAsync(pageSize, new RequestContext());
            await ValidatePagesAsync(result.AsPages(pageSizeHint: pageSizeHint), expectedCount, ValidatePet);
        });

        [SpectorTest]
        [TestCase(2, null, 2)]
        [TestCase(4, null, 4)]
        [TestCase(null, 2, 2)]
        [TestCase(null, 4, 4)]
        [TestCase(2, 4, 4)]
        [TestCase(4, 2, 2)]
        public Task WithPageSizeProtocolMethodSync(int? pageSize, int? pageSizeHint, int expectedCount) => Test((host) =>
        {
            var result = new PageableClient(host, null).GetPageSizeClient().GetWithPageSize(pageSize, new RequestContext());
            ValidatePages(result.AsPages(pageSizeHint: pageSizeHint), expectedCount, ValidatePet);
            return Task.CompletedTask;
        });

        private static async Task ValidatePagesAsync<T>(IAsyncEnumerable<Page<T>> pages, int expectedCount, Action<T, string, string> validatePet)
        {
            int pageCount = 0;
            await foreach (var page in pages)
            {
                ValidatePage(page, expectedCount, validatePet);
                pageCount++;
            }
            Assert.AreEqual(1, pageCount);
        }

        private static void ValidatePages<T>(IEnumerable<Page<T>> pages, int expectedCount, Action<T, string, string> validatePet)
        {
            int pageCount = 0;
            foreach (var page in pages)
            {
                ValidatePage(page, expectedCount, validatePet);
                pageCount++;
            }
            Assert.AreEqual(1, pageCount);
        }

        private static void ValidatePage<T>(Page<T> page, int expectedCount, Action<T, string, string> validatePet)
        {
            Assert.AreEqual(200, page.GetRawResponse().Status);
            Assert.IsNull(page.ContinuationToken);
            Assert.AreEqual(expectedCount, page.Values.Count);
            for (int i = 0; i < page.Values.Count; i++)
            {
                validatePet(page.Values[i], (i + 1).ToString(), ExpectedPetNames[i]);
            }
        }

        private static void ValidatePet(Pet pet, string expectedId, string expectedName)
        {
            Assert.AreEqual(expectedId, pet.Id);
            Assert.AreEqual(expectedName, pet.Name);
        }

        private static void ValidatePet(BinaryData pet, string expectedId, string expectedName)
        {
            using var document = JsonDocument.Parse(pet);
            Assert.AreEqual(expectedId, document.RootElement.GetProperty("id").GetString());
            Assert.AreEqual(expectedName, document.RootElement.GetProperty("name").GetString());
        }
    }
}
