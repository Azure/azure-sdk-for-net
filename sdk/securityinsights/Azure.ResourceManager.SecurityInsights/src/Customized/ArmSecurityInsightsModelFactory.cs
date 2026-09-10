// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618 // This compatibility overload intentionally exposes the obsolete Source type.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.SecurityInsights.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    /// <summary> Model factory for models. </summary>
    // Preserve the GA model factory overload that accepted Source while hiding it from new code.
    [CodeGenSuppress("SecurityInsightsWatchlistData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(Guid?), typeof(string), typeof(string), typeof(Source?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(SecurityInsightsUserInfo), typeof(SecurityInsightsUserInfo), typeof(string), typeof(string), typeof(string), typeof(bool?), typeof(IEnumerable<string>), typeof(TimeSpan?), typeof(Guid?), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(ETag?))]
    public static partial class ArmSecurityInsightsModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="SecurityInsights.SecurityInsightsWatchlistData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="watchlistId"> The id (a Guid) of the watchlist. </param>
        /// <param name="displayName"> The display name of the watchlist. </param>
        /// <param name="provider"> The provider of the watchlist. </param>
        /// <param name="source"> The source of the watchlist. </param>
        /// <param name="createdOn"> The time the watchlist was created. </param>
        /// <param name="updatedOn"> The last time the watchlist was updated. </param>
        /// <param name="createdBy"> Describes a user that created the watchlist. </param>
        /// <param name="updatedBy"> Describes a user that updated the watchlist. </param>
        /// <param name="description"> A description of the watchlist. </param>
        /// <param name="watchlistType"> The type of the watchlist. </param>
        /// <param name="watchlistAlias"> The alias of the watchlist. </param>
        /// <param name="isDeleted"> A flag that indicates if the watchlist is deleted or not. </param>
        /// <param name="labels"> List of labels relevant to this watchlist. </param>
        /// <param name="defaultDuration"> The default duration of a watchlist (in ISO 8601 duration format). </param>
        /// <param name="tenantId"> The tenantId where the watchlist belongs to. </param>
        /// <param name="numberOfLinesToSkip"> The number of lines in a csv content to skip before the header. </param>
        /// <param name="rawContent">
        /// The raw content that represents to watchlist items to create. Example : This line will be skipped
        ///             header1,header2
        ///             value1,value2
        /// </param>
        /// <param name="itemsSearchKey"> The search key is used to optimize query performance when using watchlists for joins with other data. For example, enable a column with IP addresses to be the designated SearchKey field, then use this field as the key field when joining to other event data by IP address. </param>
        /// <param name="contentType"> The content type of the raw content. For now, only text/csv is valid. </param>
        /// <param name="uploadStatus"> The status of the Watchlist upload : New, InProgress or Complete. **Note** : When a Watchlist upload status is InProgress, the Watchlist cannot be deleted. </param>
        /// <param name="etag"> Etag of the azure resource. </param>
        /// <returns> A new <see cref="SecurityInsights.SecurityInsightsWatchlistData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is obsolete because Source has been replaced by SourceString. Use the overload that accepts sourceString instead.", false)]
        public static SecurityInsightsWatchlistData SecurityInsightsWatchlistData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, Guid? watchlistId = default, string displayName = default, string provider = default, Source? source = default, DateTimeOffset? createdOn = default, DateTimeOffset? updatedOn = default, SecurityInsightsUserInfo createdBy = default, SecurityInsightsUserInfo updatedBy = default, string description = default, string watchlistType = default, string watchlistAlias = default, bool? isDeleted = default, IEnumerable<string> labels = default, TimeSpan? defaultDuration = default, Guid? tenantId = default, int? numberOfLinesToSkip = default, string rawContent = default, string itemsSearchKey = default, string contentType = default, string uploadStatus = default, ETag? etag = default)
        {
            return ArmSecurityInsightsModelFactory.SecurityInsightsWatchlistData(
                id, name, resourceType, systemData,
                watchlistId: watchlistId,
                displayName: displayName,
                provider: provider,
                sourceString: source?.ToString(),   // Source → string translation
                sourceType: null,
                createdOn: createdOn,
                updatedOn: updatedOn,
                createdBy: createdBy,
                updatedBy: updatedBy,
                description: description,
                watchlistType: watchlistType,
                watchlistAlias: watchlistAlias,
                isDeleted: isDeleted,
                labels: labels,
                defaultDuration: defaultDuration,
                tenantId: tenantId,
                numberOfLinesToSkip: numberOfLinesToSkip,
                rawContent: rawContent,
                itemsSearchKey: itemsSearchKey,
                contentType: contentType,
                uploadStatus: uploadStatus,
                provisioningState: null,
                eTag: etag);
        }
    }
}

#pragma warning restore CS0618
