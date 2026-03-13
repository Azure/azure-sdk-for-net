// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.SecurityInsights.Models;

namespace Azure.ResourceManager.SecurityInsights
{
    // Add this class due to the api compat check with property breaking chang to string type in 2024-01-01-preview version
    public partial class SecurityInsightsWatchlistData
    {
        /// <summary> The source of the watchlist. </summary>
        public Source? Source
        {
            get
            {
                if (Properties?.SourceType is null)
                {
                    return null;
                }

                var sourceType = Properties.SourceType.Value;
                if (sourceType == WatchlistSourceType.Local)
                {
                    return Azure.ResourceManager.SecurityInsights.Models.Source.LocalFile;
                }

                if (sourceType == WatchlistSourceType.AzureStorage)
                {
                    return Azure.ResourceManager.SecurityInsights.Models.Source.RemoteStorage;
                }

                return new Azure.ResourceManager.SecurityInsights.Models.Source(sourceType.ToString());
            }
            set
            {
                if (value is null)
                {
                    if (Properties is not null)
                    {
                        Properties.SourceType = null;
                    }

                    return;
                }

                Properties ??= new WatchlistProperties();
                var source = value.Value;
                if (source == Azure.ResourceManager.SecurityInsights.Models.Source.LocalFile)
                {
                    Properties.SourceType = WatchlistSourceType.Local;
                }
                else if (source == Azure.ResourceManager.SecurityInsights.Models.Source.RemoteStorage)
                {
                    Properties.SourceType = WatchlistSourceType.AzureStorage;
                }
                else
                {
                    Properties.SourceType = new WatchlistSourceType(source.ToString());
                }
            }
        }
    }
}
