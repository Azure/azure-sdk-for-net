// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.OperationalInsights;
using Azure.ResourceManager.OperationalInsights.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityInsights.Tests
{
    public class SecurityInsightsManagementTestBase : ManagementRecordedTestBase<SecurityInsightsManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected AzureLocation DefaultLocation => AzureLocation.EastUS;
        protected string groupName;
        protected SubscriptionResource DefaultSubscription { get; private set; }
        private readonly Dictionary<string, Queue<string>> _recordedAssetNames = new(StringComparer.OrdinalIgnoreCase);

        protected SecurityInsightsManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            IgnoreOperationalInsightsDependencyVersion();
        }

        public ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}";
            return new ResourceIdentifier(resourceId);
        }

        protected SecurityInsightsManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            IgnoreOperationalInsightsDependencyVersion();
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        private void IgnoreOperationalInsightsDependencyVersion()
        {
            // MPG SDK omits Accept on some operations where the existing recordings include it.
            LegacyExcludedHeaders.Add("Accept");
            UriRegexSanitizers.Add(new UriRegexSanitizer(@"/providers\/Microsoft.OperationalInsights\/(.*?)\?api-version=(?<group>[a-z0-9-]+)")
            {
                GroupForReplace = "group",
                Value = "**"
            });
            UriRegexSanitizers.Add(new UriRegexSanitizer(@"/resourceGroups/")
            {
                Value = "/resourcegroups/"
            });
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            var resourceGroupName = Recording.GenerateAssetName("testRG-");
            var rgOp = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "env" }
                    }
                });
            if (Mode == RecordedTestMode.Playback)
            {
                groupName = resourceGroupName;
            }
            else
            {
                using (Recording.DisableRecording())
                {
                    groupName = rgOp.Value.Data.Name;
                }
            }

            return rgOp.Value;
        }

        protected string GenerateAssetNameFromRecording(string prefix, string resourcePathSegment)
        {
            if (Mode == RecordedTestMode.Playback && TryGetRecordedAssetName(resourcePathSegment, out var recordedName))
            {
                return recordedName;
            }

            return Recording.GenerateAssetName(prefix);
        }

        private bool TryGetRecordedAssetName(string resourcePathSegment, out string recordedName)
        {
            if (!_recordedAssetNames.TryGetValue(resourcePathSegment, out var names))
            {
                names = new Queue<string>(GetRecordedAssetNames(resourcePathSegment));
                _recordedAssetNames[resourcePathSegment] = names;
            }

            if (names.Count > 0)
            {
                recordedName = names.Dequeue();
                return true;
            }

            recordedName = null;
            return false;
        }

        private IEnumerable<string> GetRecordedAssetNames(string resourcePathSegment)
        {
            var sessionFile = GetExistingSessionFilePath();
            if (!File.Exists(sessionFile))
            {
                return Enumerable.Empty<string>();
            }

            var content = File.ReadAllText(sessionFile);
            var pattern = $"/{Regex.Escape(resourcePathSegment)}/([^/?\\\"]+)";
            return Regex.Matches(content, pattern, RegexOptions.IgnoreCase)
                .Cast<Match>()
                .Select(match => Uri.UnescapeDataString(match.Groups[1].Value))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();
        }

        private string GetExistingSessionFilePath()
        {
            var sessionFile = GetSessionFilePath();
            if (!Path.IsPathRooted(sessionFile))
            {
                sessionFile = Path.Combine(Azure.Core.TestFramework.TestEnvironment.RepositoryRoot, sessionFile);
            }

            if (File.Exists(sessionFile))
            {
                return sessionFile;
            }

            var assetsPath = Path.Combine(Azure.Core.TestFramework.TestEnvironment.RepositoryRoot, ".assets");
            if (!Directory.Exists(assetsPath))
            {
                return sessionFile;
            }

            var className = GetType().Name;
            var fileName = Path.GetFileName(sessionFile);
            var sessionRecordsClassPath = $"{Path.DirectorySeparatorChar}SessionRecords{Path.DirectorySeparatorChar}{className}{Path.DirectorySeparatorChar}";
            return Directory.EnumerateFiles(assetsPath, fileName, SearchOption.AllDirectories)
                .FirstOrDefault(path => path.IndexOf(sessionRecordsClassPath, StringComparison.OrdinalIgnoreCase) >= 0)
                ?? sessionFile;
        }

        #region workspace
        public static OperationalInsightsWorkspaceData GetWorkspaceData()
        {
            var data = new OperationalInsightsWorkspaceData(AzureLocation.WestUS)
            {
                RetentionInDays = 30,
                Sku = new OperationalInsightsWorkspaceSku(OperationalInsightsWorkspaceSkuName.PerNode),
                PublicNetworkAccessForIngestion = OperationalInsightsPublicNetworkAccessType.Enabled,
                PublicNetworkAccessForQuery = OperationalInsightsPublicNetworkAccessType.Enabled,
            };
            return data;
        }

        #endregion
    }
}
