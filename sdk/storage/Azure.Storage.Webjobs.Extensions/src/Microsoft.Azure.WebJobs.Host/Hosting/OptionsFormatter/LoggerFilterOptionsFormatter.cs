// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Hosting
{
    internal class LoggerFilterOptionsFormatter : IOptionsFormatter<LoggerFilterOptions>
    {
        public string Format(LoggerFilterOptions options)
        {
            JArray rules = new JArray();

            foreach (LoggerFilterRule rule in options.Rules)
            {
                rules.Add(new JObject
                {
                    { nameof(LoggerFilterRule.ProviderName), rule.ProviderName },
                    { nameof(LoggerFilterRule.CategoryName), rule.CategoryName },
                    { nameof(LoggerFilterRule.LogLevel), rule.LogLevel?.ToString() },
                    { nameof(LoggerFilterRule.Filter), rule.Filter?.Method.Name }
                });
            }

            JObject optionsJson = new JObject
            {
                { nameof(LoggerFilterOptions.MinLevel), options.MinLevel.ToString() },
                { nameof(LoggerFilterOptions.Rules), rules }
            };

            return optionsJson.ToString(Formatting.Indented);
        }
    }
}