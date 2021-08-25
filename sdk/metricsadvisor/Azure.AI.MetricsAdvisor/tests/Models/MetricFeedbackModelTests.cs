// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class MetricFeedbackModelTests : MockClientTestBase
    {
        public MetricFeedbackModelTests(bool isAsync) : base(isAsync)
        {
        }

        private string UnknownFeedbackContent => $@"
        {{
            ""feedbackId"": ""{FakeGuid}"",
            ""createdTime"": ""2021-01-01T00:00:00.000Z"",
            ""userPrincipal"": ""fake@email.com"",
            ""metricId"": ""{FakeGuid}"",
            ""dimensionFilter"": {{
                ""dimension"": {{
                    ""city"": ""Delhi""
                }}
            }},
            ""feedbackType"": ""unknownType""
        }}
        ";

        [Test]
        public async Task MetricFeedbackGetsUnknownFeedback()
        {
            MockResponse getResponse = new MockResponse(200);
            getResponse.SetContent(UnknownFeedbackContent);

            MetricsAdvisorClient client = CreateInstrumentedClient(getResponse);
            MetricFeedback feedback = await client.GetFeedbackAsync(FakeGuid);

            Assert.That(feedback.Id, Is.EqualTo(FakeGuid));
            Assert.That(feedback.CreatedOn, Is.EqualTo(DateTimeOffset.Parse("2021-01-01T00:00:00.000Z")));
            Assert.That(feedback.UserPrincipal, Is.EqualTo("fake@email.com"));
            Assert.That(feedback.MetricId, Is.EqualTo(FakeGuid));
            Assert.That(feedback.DimensionKey.TryGetValue("city", out string city));
            Assert.That(city, Is.EqualTo("Delhi"));
        }
    }
}
