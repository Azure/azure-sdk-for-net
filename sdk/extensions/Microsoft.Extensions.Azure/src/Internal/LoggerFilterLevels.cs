// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Determines the most verbose level that any logging provider could be enabled at for a category,
    /// from the <see cref="LoggerFilterOptions"/> alone.
    /// </summary>
    /// <remarks>
    /// The filter rules are an upper bound for what a logging provider can emit: whatever a provider decides
    /// for itself (for example its own level switches, or being added to the <see cref="ILoggerFactory"/> later)
    /// can only restrict the events further. Using only the filter rules means that the result does not
    /// become stale when the providers change, only when the filter rules change.
    /// The rules are selected in the same way as the default <see cref="LoggerFactory"/>: for each provider the
    /// rules for that provider are preferred over the rules for all providers, and then the rule with the longest
    /// category that matches the category is used, with later rules taking precedence over earlier ones.
    /// </remarks>
    internal static class LoggerFilterLevels
    {
        public static EventLevel? GetEventLevel(LoggerFilterOptions options, string category)
        {
            switch (GetMostVerboseLevel(options, category))
            {
                case LogLevel.Trace:
                case LogLevel.Debug:
                    return EventLevel.Verbose;
                case LogLevel.Information:
                    return EventLevel.Informational;
                case LogLevel.Warning:
                    return EventLevel.Warning;
                case LogLevel.Error:
                    return EventLevel.Error;
                case LogLevel.Critical:
                    return EventLevel.Critical;
                default:
                    return null;
            }
        }

        public static LogLevel GetMostVerboseLevel(LoggerFilterOptions options, string category)
        {
            LoggerFilterRule allProviders = null;
            Dictionary<string, LoggerFilterRule> byProvider = null;

            foreach (var rule in options.Rules)
            {
                if (!Matches(rule.CategoryName, category))
                {
                    continue;
                }

                if (rule.ProviderName is null)
                {
                    allProviders = Select(rule, allProviders);
                }
                else
                {
                    byProvider ??= new Dictionary<string, LoggerFilterRule>(StringComparer.Ordinal);
                    byProvider.TryGetValue(rule.ProviderName, out var current);
                    byProvider[rule.ProviderName] = Select(rule, current);
                }
            }

            // A provider without any matching rules of its own uses the rule that applies to all providers,
            // or if there isn't one, the global minimum level.
            var lowest = allProviders is null ? options.MinLevel : GetLevel(allProviders);

            if (byProvider is not null)
            {
                foreach (var rule in byProvider.Values)
                {
                    var level = GetLevel(rule);

                    if (level < lowest)
                    {
                        lowest = level;
                    }
                }
            }

            return lowest;
        }

        // A rule that only has a filter delegate can allow any level.
        private static LogLevel GetLevel(LoggerFilterRule rule) => rule.LogLevel ?? LogLevel.Trace;

        private static LoggerFilterRule Select(LoggerFilterRule rule, LoggerFilterRule current)
        {
            if (current is null)
            {
                return rule;
            }

            // A rule with a category is preferred over a rule without one, then the longest category wins, then the last rule wins.
            var length = rule.CategoryName?.Length ?? -1;
            var currentLength = current.CategoryName?.Length ?? -1;

            return length >= currentLength ? rule : current;
        }

        private static bool Matches(string ruleCategory, string category)
        {
            if (ruleCategory is null)
            {
                return true;
            }

            var wildcard = ruleCategory.IndexOf('*');

            if (wildcard < 0)
            {
                return category.StartsWith(ruleCategory, StringComparison.OrdinalIgnoreCase);
            }

            if (ruleCategory.IndexOf('*', wildcard + 1) >= 0)
            {
                // Not valid (LoggerFactory throws), so be conservative and consider the rule.
                return true;
            }

            return category.StartsWith(ruleCategory.Substring(0, wildcard), StringComparison.OrdinalIgnoreCase) &&
                category.EndsWith(ruleCategory.Substring(wildcard + 1), StringComparison.OrdinalIgnoreCase);
        }
    }
}
