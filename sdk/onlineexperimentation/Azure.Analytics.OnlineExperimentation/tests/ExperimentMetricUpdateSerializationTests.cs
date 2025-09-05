// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;

using FluentAssertions;

using NUnit.Framework;

namespace Azure.Analytics.OnlineExperimentation.Tests
{
    [TestFixture]
    public class ExperimentMetricUpdateSerializationTests
    {
        [Test]
        public void AllProperties()
        {
            TestSerializationRoundtrip(new ExperimentMetricUpdate
            {
                Lifecycle = LifecycleStage.Inactive,
                DisplayName = "Serialization Test",
                Description = "Serialization Test Description",
                Categories = { "Test", "Serialization" },
                DesiredDirection = DesiredDirection.Increase,
                Definition = new UserRateMetricDefinition("startEventName", "endEventName")
                {
                    StartEvent = { Filter = "startEventFilter" },
                    EndEvent = { Filter = "endEventFilter" }
                }
            });
        }

        [Test]
        public void NoProperties()
        {
            TestSerializationRoundtrip(new ExperimentMetricUpdate());
        }

        [Test]
        public void UpdateLifecycleStage()
        {
            TestSerializationRoundtrip(new ExperimentMetricUpdate
            {
                Lifecycle = LifecycleStage.Inactive
            });
        }

        [Test]
        public void UpdateDisplayFields()
        {
            TestSerializationRoundtrip(new ExperimentMetricUpdate
            {
                DisplayName = "Updated Display Name",
                Description = "Updated Description"
            });
        }

        [Test]
        public void SetCategories()
        {
            TestSerializationRoundtrip(new ExperimentMetricUpdate
            {
                Categories = { "NewCategory" }
            });
        }

        [Test]
        public void CategoriesOmittedByDefault()
        {
            var update = new ExperimentMetricUpdate { DisplayName = "something" };
            Assert.That(update.Categories, Is.Not.Null);
            Assert.That(update.Categories, Is.Empty);

            TestSerializationRoundtrip(update);
        }

        [Test]
        public void SetCategoriesEmpty()
        {
            var update = new ExperimentMetricUpdate { DisplayName = "something" };
            update.Categories.Clear(); // initializes internal state causing the property to be emitted.

            TestSerializationRoundtrip(update);
        }

        [Test]
        public void SetEventCountMetricDefinition()
        {
            TestSerializationRoundtrip(new ExperimentMetricUpdate
            {
                Definition = new EventCountMetricDefinition("eventName")
            });
        }

        [Test]
        public void SetEventCountMetricDefinitionWithFilter()
        {
            TestSerializationRoundtrip(new ExperimentMetricUpdate
            {
                Definition = new EventCountMetricDefinition("eventName")
                {
                    Event = { Filter = "eventFilter" }
                }
            });
        }

        [Test]
        public void SetAverageMetricDefinition()
        {
            TestSerializationRoundtrip(new ExperimentMetricUpdate
            {
                Definition = new AverageMetricDefinition("eventName", "eventProperty")
            });
        }

        [Test]
        public void SetAverageMetricDefinitionWithFilter()
        {
            TestSerializationRoundtrip(new ExperimentMetricUpdate
            {
                Definition = new AverageMetricDefinition("eventName", "eventProperty")
                {
                    Value = { Filter = "eventFilter" }
                }
            });
        }

        private static void TestSerializationRoundtrip(ExperimentMetricUpdate original)
        {
            using var requestContent = original.ToRequestContent();

            using var buffer = new MemoryStream();
            requestContent.WriteTo(buffer, cancellation: default);

            buffer.Position = 0; // rewind stream for reading

            // Deserialization matches ExperimentMetric.FromResponse()
            using var document = JsonDocument.Parse(buffer, ModelSerializationExtensions.JsonDocumentOptions);
            var deserialized = ExperimentMetric.DeserializeExperimentMetric(document.RootElement);

            // _serializedAdditionalRawData is originally null, Deserialize*() methods set it empty dictionary.
            deserialized.Should().BeEquivalentTo(
                original,
                c => c.Excluding(m => m.Categories)
                      .Excluding(m => m.SelectedMemberPath.EndsWith("._serializedAdditionalRawData")));

            var originalCategories = original.Categories.Should().BeOfType<ChangeTrackingList<string>>().Which;
            var categoriesEmitted = document.RootElement.TryGetProperty("categories", out var categoriesElement);
            if (originalCategories.IsUndefined)
            {
                Assert.IsFalse(categoriesEmitted);
            }
            else
            {
                Assert.IsTrue(categoriesEmitted);
                Assert.AreEqual(JsonValueKind.Array, categoriesElement.ValueKind);
                Assert.AreEqual(originalCategories.Count, categoriesElement.GetArrayLength());
                for (int i = 0; i < originalCategories.Count; i++)
                {
                    Assert.AreEqual(originalCategories[i], categoriesElement[i].GetString());
                }
            }
        }
    }
}
