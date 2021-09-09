// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.Webjobs.Extensions.SignalRService.E2ETests
{
    public static class Utils
    {
        public const string UrlSectionKey = "FunctionBaseUrl";
        public static readonly IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        public static readonly IConfiguration UrlConfiguration = Configuration.GetSection(UrlSectionKey);

        public static IEnumerable<object[]> GetFunctionUrls(string sectionName) =>
            from section in UrlConfiguration.GetSection(sectionName).GetChildren()
            select new object[] { section.Key, section.Value };

        /// <summary>
        /// Generate 4-bit numbers as user names.
        /// </summary>
        /// <param name="count">The number of users</param>
        /// <returns></returns>
        public static IEnumerable<string> GenerateRandomUsers(int count)
        {
            return Enumerable.Range(0, count).Select(i => Guid.NewGuid().ToString().Substring(0, 4));
        }

        public static HubConnection CreateHubConnection(string endpoint, string accessToken) => new HubConnectionBuilder()
                .WithUrl(endpoint, option =>
                {
                    option.AccessTokenProvider = () =>
                    {
                        return Task.FromResult(accessToken);
                    };
                })
                .AddNewtonsoftJsonProtocol()
                .Build();

        public static async Task OrTimeout(this Task task, TimeSpan timeout = default)
        {
            if (timeout == default) timeout = TimeSpan.FromSeconds(10);
            var timeoutTask = Task.Delay(timeout);
            await Task.WhenAny(task, timeoutTask);

            if (!task.IsCompletedSuccessfully)
            {
                throw new Exception("Task is not completed in time.");
            }
        }

        public class SkipIfFunctionAbsentAttribute : TheoryAttribute
        {
            private readonly string _section;

            public SkipIfFunctionAbsentAttribute(string section)
            {
                _section = section;
                if (!UrlConfiguration.GetSection(_section).GetChildren().Any())
                {
                    Skip = $"Functions base urls are not configured in section: '{UrlSectionKey}:{_section} '";
                }
            }
        }
    }
}