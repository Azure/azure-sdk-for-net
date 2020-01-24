// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class TextAnalyticsClientLiveTests : RecordedTestBase
    {
        public TextAnalyticsClientLiveTests(bool isAsync) : base(isAsync)
        {
            Sanitizer = new TextAnalyticsRecordedTestSanitizer();
            Matcher = new RecordMatcher(Sanitizer);
        }

        private TextAnalyticsClient GetClient()
        {
            string endpoint = Recording.GetVariableFromEnvironment("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Recording.GetVariableFromEnvironment("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            var options = Recording.InstrumentClientOptions(new TextAnalyticsClientOptions());
            var client = new TextAnalyticsClient(new Uri(endpoint), new TextAnalyticsSubscriptionKeyCredential(subscriptionKey), options);

            return InstrumentClient(client);
        }

        [Test]
        public async Task RecognizeEntitiesTypesSubTypes()
        {
            TextAnalyticsClient client = GetClient();
            const string input = "Bill Gates | Microsoft | New Mexico | 800-102-1100 | help@microsoft.com | April 4, 1975 12:34 | April 4, 1975 | 12:34 | five seconds | 9 | third | 120% | €30 | 11m | 22 °C";

            RecognizeEntitiesResult result = await client.RecognizeEntitiesAsync(input);
            List<NamedEntity> entities = result.NamedEntities.ToList();

            Assert.AreEqual(15, entities.Count);

            Assert.AreEqual(NamedEntityType.Person, entities[0].Type);
            Assert.AreEqual(NamedEntitySubType.None, entities[0].SubType);

            Assert.AreEqual(NamedEntityType.Organization, entities[1].Type);
            Assert.AreEqual(NamedEntitySubType.None, entities[1].SubType);

            Assert.AreEqual(NamedEntityType.Location, entities[2].Type);
            Assert.AreEqual(NamedEntitySubType.None, entities[2].SubType);

            Assert.AreEqual(NamedEntityType.PhoneNumber, entities[3].Type);
            Assert.AreEqual(NamedEntitySubType.None, entities[3].SubType);

            Assert.AreEqual(NamedEntityType.Email, entities[4].Type);
            Assert.AreEqual(NamedEntitySubType.None, entities[4].SubType);

            Assert.AreEqual(NamedEntityType.DateTime, entities[5].Type);
            Assert.AreEqual(NamedEntitySubType.None, entities[5].SubType);

            Assert.AreEqual(NamedEntityType.DateTime, entities[6].Type);
            Assert.AreEqual(NamedEntitySubType.Date, entities[6].SubType);

            Assert.AreEqual(NamedEntityType.DateTime, entities[7].Type);
            Assert.AreEqual(NamedEntitySubType.Time, entities[7].SubType);

            Assert.AreEqual(NamedEntityType.DateTime, entities[8].Type);
            Assert.AreEqual(NamedEntitySubType.Duration, entities[8].SubType);

            Assert.AreEqual(NamedEntityType.Quantity, entities[9].Type);
            Assert.AreEqual(NamedEntitySubType.Number, entities[9].SubType);

            Assert.AreEqual(NamedEntityType.Quantity, entities[10].Type);
            Assert.AreEqual(NamedEntitySubType.Ordinal, entities[10].SubType);

            Assert.AreEqual(NamedEntityType.Quantity, entities[11].Type);
            Assert.AreEqual(NamedEntitySubType.Percentage, entities[11].SubType);

            Assert.AreEqual(NamedEntityType.Quantity, entities[12].Type);
            Assert.AreEqual(NamedEntitySubType.Currency, entities[12].SubType);

            Assert.AreEqual(NamedEntityType.Quantity, entities[13].Type);
            Assert.AreEqual(NamedEntitySubType.Dimension, entities[13].SubType);

            Assert.AreEqual(NamedEntityType.Quantity, entities[14].Type);
            Assert.AreEqual(NamedEntitySubType.Temperature, entities[14].SubType);
        }
    }
}
