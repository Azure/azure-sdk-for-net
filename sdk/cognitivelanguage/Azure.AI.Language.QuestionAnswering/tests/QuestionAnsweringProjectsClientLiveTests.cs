// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Language.QuestionAnswering.Projects;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.QuestionAnswering.Tests
{
    public class QuestionAnsweringProjectsClientLiveTests : QuestionAnsweringProjectsLiveTestBase
    {
        public QuestionAnsweringProjectsClientLiveTests(bool isAsync, QuestionAnsweringClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        [RecordedTest]
        public async Task UpdateQnAs()
        {
            string testProjectName = CreateTestProjectName();
            await CreateProjectAsync(testProjectName);

            string question = "What is the easiest way to use azure services in my .NET project?";
            string answer = "Using Microsoft's Azure SDKs";
            RequestContent updateQnasRequestContent = RequestContent.Create(
                new[] {
                    new {
                            op = "add",
                            value = new
                            {
                                questions = new[]
                                    {
                                        question
                                    },
                                answer = answer
                            }
                        }
                });

            Operation<BinaryData> updateQnasOperation = await Client.UpdateQnasAsync(testProjectName, updateQnasRequestContent);
            await updateQnasOperation.WaitForCompletionAsync();

            AsyncPageable<BinaryData> sources = Client.GetQnasAsync(testProjectName);

            Assert.True(updateQnasOperation.HasCompleted);
            Assert.AreEqual(200, updateQnasOperation.GetRawResponse().Status);
            Assert.That((await sources.ToEnumerableAsync()).Any(source => source.ToString().Contains(question)));
            Assert.That((await sources.ToEnumerableAsync()).Any(source => source.ToString().Contains(answer)));

            await DeleteProjectAsync(testProjectName);
        }
    }
}
