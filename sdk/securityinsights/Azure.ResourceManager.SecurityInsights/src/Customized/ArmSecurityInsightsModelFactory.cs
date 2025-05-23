// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    public static partial class ArmSecurityInsightsModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="SecurityInsights.SecurityInsightsAlertRuleActionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> Etag of the action. </param>
        /// <param name="logicAppResourceId"> Logic App Resource Id, /subscriptions/{my-subscription}/resourceGroups/{my-resource-group}/providers/Microsoft.Logic/workflows/{my-workflow-id}. </param>
        /// <param name="workflowId"> The name of the logic app's workflow. </param>
        /// <returns> A new <see cref="SecurityInsights.SecurityInsightsAlertRuleActionData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SecurityInsightsAlertRuleActionData SecurityInsightsAlertRuleActionData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ETag? etag = null, ResourceIdentifier logicAppResourceId = null, string workflowId = null)
        {
            return new SecurityInsightsAlertRuleActionData(
                id,
                name,
                resourceType,
                systemData,
                logicAppResourceId,
                workflowId,
                etag,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.SecurityInsightsClientInfo"/>. </summary>
        /// <param name="email"> The email of the client. </param>
        /// <param name="name"> The name of the client. </param>
        /// <param name="objectId"> The object id of the client. </param>
        /// <param name="userPrincipalName"> The user principal name of the client. </param>
        /// <returns> A new <see cref="Models.SecurityInsightsClientInfo"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SecurityInsightsClientInfo SecurityInsightsClientInfo(string email = null, string name = null, Guid? objectId = null, string userPrincipalName = null)
        {
            return new SecurityInsightsClientInfo(email, name, objectId, userPrincipalName, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="SecurityInsights.SecurityInsightsIncidentCommentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="createdOn"> The time the comment was created. </param>
        /// <param name="lastModifiedOn"> The time the comment was updated. </param>
        /// <param name="message"> The comment message. </param>
        /// <param name="author"> Describes the client that created the comment. </param>
        /// <param name="etag"> Etag of the azure resource. </param>
        /// <returns> A new <see cref="SecurityInsights.SecurityInsightsIncidentCommentData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SecurityInsightsIncidentCommentData SecurityInsightsIncidentCommentData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, DateTimeOffset? createdOn = null, DateTimeOffset? lastModifiedOn = null, string message = null, SecurityInsightsClientInfo author = null, ETag? etag = null)
        {
            return new SecurityInsightsIncidentCommentData(
                id,
                name,
                resourceType,
                systemData,
                message,
                createdOn,
                lastModifiedOn,
                author,
                etag,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.SecurityInsightsIncidentEntitiesMetadata"/>. </summary>
        /// <param name="count"> Total number of aggregations of the given kind in the incident related entities result. </param>
        /// <param name="entityKind"> The kind of the aggregated entity. </param>
        /// <returns> A new <see cref="Models.SecurityInsightsIncidentEntitiesMetadata"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SecurityInsightsIncidentEntitiesMetadata SecurityInsightsIncidentEntitiesMetadata(int count = default, SecurityInsightsEntityKind entityKind = default)
        {
            return new SecurityInsightsIncidentEntitiesMetadata(entityKind, count, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.SecurityInsightsUriEntity"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="additionalData"> A bag of custom fields that should be part of the entity and will be presented to the user. </param>
        /// <param name="friendlyName"> The graph item display name which is a short humanly readable description of the graph item instance. This property is optional and might be system generated. </param>
        /// <param name="uri"> A full URL the entity points to. </param>
        /// <returns> A new <see cref="Models.SecurityInsightsUriEntity"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SecurityInsightsUriEntity SecurityInsightsUriEntity(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IReadOnlyDictionary<string, BinaryData> additionalData = null, string friendlyName = null, Uri uri = null)
        {
            additionalData ??= new Dictionary<string, BinaryData>();

            return new SecurityInsightsUriEntity(
                id,
                name,
                resourceType,
                systemData,
                SecurityInsightsEntityKind.Uri,
                serializedAdditionalRawData: null,
                additionalData,
                friendlyName,
                uri?.AbsoluteUri);
        }

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
        /// header1,header2
        /// value1,value2
        /// </param>
        /// <param name="itemsSearchKey"> The search key is used to optimize query performance when using watchlists for joins with other data. For example, enable a column with IP addresses to be the designated SearchKey field, then use this field as the key field when joining to other event data by IP address. </param>
        /// <param name="contentType"> The content type of the raw content. For now, only text/csv is valid. </param>
        /// <param name="uploadStatus"> The status of the Watchlist upload : New, InProgress or Complete. **Note** : When a Watchlist upload status is InProgress, the Watchlist cannot be deleted. </param>
        /// <param name="etag"> Etag of the azure resource. </param>
        /// <returns> A new <see cref="SecurityInsights.SecurityInsightsWatchlistData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SecurityInsightsWatchlistData SecurityInsightsWatchlistData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, Guid? watchlistId = null, string displayName = null, string provider = null, Source? source = null, DateTimeOffset? createdOn = null, DateTimeOffset? updatedOn = null, SecurityInsightsUserInfo createdBy = null, SecurityInsightsUserInfo updatedBy = null, string description = null, string watchlistType = null, string watchlistAlias = null, bool? isDeleted = null, IEnumerable<string> labels = null, TimeSpan? defaultDuration = null, Guid? tenantId = null, int? numberOfLinesToSkip = null, string rawContent = null, string itemsSearchKey = null, string contentType = null, string uploadStatus = null, ETag? etag = null)
        {
            labels ??= new List<string>();

            return new SecurityInsightsWatchlistData(
                id,
                name,
                resourceType,
                systemData,
                watchlistId,
                displayName,
                provider,
                null,
                null,
                createdOn,
                updatedOn,
                createdBy,
                updatedBy,
                description,
                watchlistType,
                watchlistAlias,
                isDeleted,
                labels?.ToList(),
                defaultDuration,
                tenantId,
                numberOfLinesToSkip,
                rawContent,
                itemsSearchKey,
                contentType,
                uploadStatus,
                etag,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="SecurityInsights.SecurityInsightsWatchlistItemData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="watchlistItemType"> The type of the watchlist item. </param>
        /// <param name="watchlistItemId"> The id (a Guid) of the watchlist item. </param>
        /// <param name="tenantId"> The tenantId to which the watchlist item belongs to. </param>
        /// <param name="isDeleted"> A flag that indicates if the watchlist item is deleted or not. </param>
        /// <param name="createdOn"> The time the watchlist item was created. </param>
        /// <param name="updatedOn"> The last time the watchlist item was updated. </param>
        /// <param name="createdBy"> Describes a user that created the watchlist item. </param>
        /// <param name="updatedBy"> Describes a user that updated the watchlist item. </param>
        /// <param name="itemsKeyValue"> key-value pairs for a watchlist item. </param>
        /// <param name="entityMapping"> key-value pairs for a watchlist item entity mapping. </param>
        /// <param name="etag"> Etag of the azure resource. </param>
        /// <returns> A new <see cref="SecurityInsights.SecurityInsightsWatchlistItemData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SecurityInsightsWatchlistItemData SecurityInsightsWatchlistItemData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string watchlistItemType = null, string watchlistItemId = null, Guid? tenantId = null, bool? isDeleted = null, DateTimeOffset? createdOn = null, DateTimeOffset? updatedOn = null, SecurityInsightsUserInfo createdBy = null, SecurityInsightsUserInfo updatedBy = null, BinaryData itemsKeyValue = null, BinaryData entityMapping = null, ETag? etag = null)
        {
            return new SecurityInsightsWatchlistItemData(
                id,
                name,
                resourceType,
                systemData,
                watchlistItemType,
                watchlistItemId,
                tenantId,
                isDeleted,
                createdOn,
                updatedOn,
                createdBy,
                updatedBy,
                null,
                null,
                etag,
                serializedAdditionalRawData: null);
        }
    }
}
