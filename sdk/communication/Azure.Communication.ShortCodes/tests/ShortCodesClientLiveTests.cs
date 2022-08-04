// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.ShortCodes.Tests
{
    public class ShortCodesClientLiveTests : ShortCodesClientLiveTestBase
    {
        public ShortCodesClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task GetShortCodes()
        {
            var connectionString = TestEnvironment.LiveTestStaticConnectionString;

            #region Snippet:CreateShortCodesClient
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new ShortCodesClient(connectionString);
            #endregion Snippet:CreateShortCodesClient

            client = CreateClient();
            var shortCodesPageable = client.GetShortCodesAsync();
            var shortCodes = await shortCodesPageable.ToEnumerableAsync();

            #region Snippet:GetShortCodes
            var pageable = client.GetShortCodesAsync();
            await foreach (var shortCode in pageable)
            {
                Console.WriteLine($"Short Code Number: {shortCode.Number}");
            }
            #endregion Snippet:GetShortCodes

            Assert.NotNull(shortCodes);
        }

        [Test]
        public async Task UpsertUSProgramBriefWithNullBody()
        {
            var client = CreateClient();
            var programBriefId = Guid.Empty;

            try
            {
                await client.UpsertUSProgramBriefAsync(programBriefId, body: null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("body", ex.ParamName);
                return;
            }

            Assert.Fail("UpsertUSProgramBriefWithNullBody should have thrown an ArgumentNullException.");
        }

        [Test]
        public async Task DeleteUSProgramBrief()
        {
            var programBriefId = Guid.Empty;
            var client = CreateClient();
            var response = await client.DeleteUSProgramBriefAsync(programBriefId);

            Assert.AreEqual(204, response.Status);
        }

        [Test]
        public async Task GetUSProgramBrief_WithNonexistentId()
        {
            var client = CreateClient();
            var programBriefId = Guid.Empty;

            try
            {
                var response = await client.GetUSProgramBriefAsync(programBriefId);
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual(404, ex.Status);
                return;
            }

            Assert.Fail("GetUSProgramBrief_WithNonexistentId should have thrown an exception.");
        }

        [Test]
        public async Task GetUSProgramBriefs()
        {
            var client = CreateClient();
            var pageable = client.GetUSProgramBriefsAsync();
            var programBriefs = await pageable.ToEnumerableAsync();

            Assert.NotNull(programBriefs);
        }

        [Test]
        public async Task SubmitUSProgramBrief_WithNonexistentId()
        {
            var client = CreateClient();
            var programBriefId = Guid.Empty;

            try
            {
                var response = await client.SubmitUSProgramBriefAsync(programBriefId);
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual(404, ex.Status);
                return;
            }

            Assert.Fail("SubmitUSProgramBrief_WithNonexistentId should have thrown an exception.");
        }
    }
}
