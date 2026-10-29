// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Microsoft.Extensions.Azure.Tests
{
    public class LoggerFilterLevelsTests
    {
        private const string Category = "Azure.Core";

        [Test]
        public void UsesMinimumLevelWhenThereAreNoRules()
        {
            Assert.That(GetLevel(LogLevel.Information), Is.EqualTo(LogLevel.Information));
            Assert.That(GetLevel(LogLevel.Warning), Is.EqualTo(LogLevel.Warning));
            Assert.That(GetLevel(LogLevel.Trace), Is.EqualTo(LogLevel.Trace));
            Assert.That(GetLevel(LogLevel.None), Is.EqualTo(LogLevel.None));
        }

        [Test]
        public void IgnoresRulesForOtherCategories()
        {
            var level = GetLevel(LogLevel.Information, Rule(null, "Microsoft", LogLevel.Debug), Rule(null, "Azure.Storage", LogLevel.Trace));

            Assert.That(level, Is.EqualTo(LogLevel.Information));
        }

        [Test]
        public void MostSpecificCategoryWinsRegardlessOfOrder()
        {
            Assert.That(
                GetLevel(LogLevel.Debug, Rule(null, null, LogLevel.Information), Rule(null, "Azure", LogLevel.Warning)),
                Is.EqualTo(LogLevel.Warning));
            Assert.That(
                GetLevel(LogLevel.Debug, Rule(null, "Azure", LogLevel.Warning), Rule(null, null, LogLevel.Information)),
                Is.EqualTo(LogLevel.Warning));
            Assert.That(
                GetLevel(LogLevel.Debug, Rule(null, "Azure", LogLevel.Error), Rule(null, "Azure.Core", LogLevel.Warning)),
                Is.EqualTo(LogLevel.Warning));
        }

        [Test]
        public void LastRuleWinsForTheSameCategory()
        {
            Assert.That(GetLevel(LogLevel.Information, Rule(null, "Azure", LogLevel.Debug), Rule(null, "Azure", LogLevel.Warning)), Is.EqualTo(LogLevel.Warning));
            Assert.That(GetLevel(LogLevel.Information, Rule(null, "Azure", LogLevel.Warning), Rule(null, "Azure", LogLevel.Debug)), Is.EqualTo(LogLevel.Debug));
        }

        [Test]
        public void CategoriesAreMatchedCaseInsensitivelyAndSupportWildcards()
        {
            Assert.That(GetLevel(LogLevel.Information, Rule(null, "azure", LogLevel.Warning)), Is.EqualTo(LogLevel.Warning));
            Assert.That(GetLevel(LogLevel.Information, Rule(null, "Azure.*", LogLevel.Warning)), Is.EqualTo(LogLevel.Warning));
            Assert.That(GetLevel(LogLevel.Information, Rule(null, "Azure.*.Storage", LogLevel.Warning)), Is.EqualTo(LogLevel.Information));
            Assert.That(GetLevel(LogLevel.Information, Rule(null, "*.Core", LogLevel.Warning)), Is.EqualTo(LogLevel.Warning));
        }

        [Test]
        public void RulesForAProviderCanEnableMoreLevelsThanRulesForAllProviders()
        {
            // A provider with a rule of its own does not use the rule for all providers
            var level = GetLevel(
                LogLevel.Information,
                Rule(null, "Azure", LogLevel.Warning),
                Rule("Sentry", "Azure", LogLevel.Debug),
                Rule("Sentry", null, LogLevel.Error));

            Assert.That(level, Is.EqualTo(LogLevel.Debug));
        }

        [Test]
        public void RulesForAProviderCanNotEnableMoreLevelsThanTheirMostSpecificCategory()
        {
            var level = GetLevel(
                LogLevel.Information,
                Rule(null, "Azure", LogLevel.Warning),
                Rule("Console", null, LogLevel.Trace),
                Rule("Console", "Azure", LogLevel.Error));

            Assert.That(level, Is.EqualTo(LogLevel.Warning));
        }

        [Test]
        public void RulesForAProviderThatDisableLevelsDoNotAffectOtherProviders()
        {
            var level = GetLevel(LogLevel.Information, Rule(null, "Azure", LogLevel.Warning), Rule("Console", null, LogLevel.None));

            Assert.That(level, Is.EqualTo(LogLevel.Warning));
        }

        [Test]
        public void ProvidersWithoutRulesUseTheMinimumLevelIfNoRuleAppliesToAllProviders()
        {
            var level = GetLevel(LogLevel.Information, Rule("Console", "Azure", LogLevel.Error));

            Assert.That(level, Is.EqualTo(LogLevel.Information));
        }

        [Test]
        public void RulesWithOnlyAFilterCanEnableAnyLevel()
        {
            var filter = new LoggerFilterRule(null, "Azure", null, (_, _, _) => true);

            Assert.That(GetLevel(LogLevel.Error, filter), Is.EqualTo(LogLevel.Trace));
            Assert.That(
                GetLevel(LogLevel.Error, new LoggerFilterRule("Sentry", null, null, (_, _, _) => true)),
                Is.EqualTo(LogLevel.Trace));
        }

        [Test]
        public void NothingIsEnabledIfAllRulesDisableLogging()
        {
            var level = GetLevel(LogLevel.None, Rule(null, null, LogLevel.None), Rule(null, "Azure", LogLevel.None));

            Assert.That(level, Is.EqualTo(LogLevel.None));
            Assert.That(LoggerFilterLevels.GetEventLevel(CreateOptions(LogLevel.None), Category), Is.Null);
        }

        [TestCase(LogLevel.Trace, EventLevel.Verbose)]
        [TestCase(LogLevel.Debug, EventLevel.Verbose)]
        [TestCase(LogLevel.Information, EventLevel.Informational)]
        [TestCase(LogLevel.Warning, EventLevel.Warning)]
        [TestCase(LogLevel.Error, EventLevel.Error)]
        [TestCase(LogLevel.Critical, EventLevel.Critical)]
        public void MapsLevelsToEventLevels(LogLevel level, EventLevel expected)
        {
            Assert.That(LoggerFilterLevels.GetEventLevel(CreateOptions(level), Category), Is.EqualTo(expected));
        }

        private static LoggerFilterRule Rule(string provider, string category, LogLevel level) => new LoggerFilterRule(provider, category, level, null);

        private static LoggerFilterOptions CreateOptions(LogLevel minimumLevel, params LoggerFilterRule[] rules)
        {
            var options = new LoggerFilterOptions { MinLevel = minimumLevel };

            foreach (var rule in rules)
            {
                options.Rules.Add(rule);
            }

            return options;
        }

        private static LogLevel GetLevel(LogLevel minimumLevel, params LoggerFilterRule[] rules)
            => LoggerFilterLevels.GetMostVerboseLevel(CreateOptions(minimumLevel, rules), Category);
    }
}
