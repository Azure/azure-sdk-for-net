// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor
{
    /// <summary> A class representing an AlertRule resource and its operations. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public partial class AlertRuleResource : ArmResource, IJsonModel<AlertRuleData>, IPersistableModel<AlertRuleData>
    {
        /// <summary> The resource type for AlertRule resources. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Insights/alertrules";

        /// <summary> Initializes a new instance of the <see cref="AlertRuleResource"/> class for mocking. </summary>
        protected AlertRuleResource()
        {
        }

        /// <summary> Gets the resource data. </summary>
        public virtual AlertRuleData Data => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets whether the resource has data. </summary>
        public virtual bool HasData => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Creates a resource identifier for an AlertRule resource. </summary>
        /// <param name="subscriptionId"> The subscription id. </param>
        /// <param name="resourceGroupName"> The resource group name. </param>
        /// <param name="ruleName"> The rule name. </param>
        /// <returns> A resource identifier. </returns>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ruleName) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets the alert rule. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The alert rule resource. </returns>
        public virtual Response<AlertRuleResource> Get(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets the alert rule. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The alert rule resource. </returns>
        public virtual Task<Response<AlertRuleResource>> GetAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Adds a tag to the alert rule. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="value"> The tag value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated alert rule resource. </returns>
        public virtual Response<AlertRuleResource> AddTag(string key, string value, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Adds a tag to the alert rule. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="value"> The tag value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated alert rule resource. </returns>
        public virtual Task<Response<AlertRuleResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Removes a tag from the alert rule. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated alert rule resource. </returns>
        public virtual Response<AlertRuleResource> RemoveTag(string key, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Removes a tag from the alert rule. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated alert rule resource. </returns>
        public virtual Task<Response<AlertRuleResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Replaces alert rule tags. </summary>
        /// <param name="tags"> The tags. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated alert rule resource. </returns>
        public virtual Response<AlertRuleResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Replaces alert rule tags. </summary>
        /// <param name="tags"> The tags. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated alert rule resource. </returns>
        public virtual Task<Response<AlertRuleResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an alert rule incident. </summary>
        /// <param name="incidentName"> The incident name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The monitor incident. </returns>
        public virtual Response<MonitorIncident> GetAlertRuleIncident(string incidentName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an alert rule incident. </summary>
        /// <param name="incidentName"> The incident name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The monitor incident. </returns>
        public virtual Task<Response<MonitorIncident>> GetAlertRuleIncidentAsync(string incidentName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets alert rule incidents. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of monitor incidents. </returns>
        public virtual Pageable<MonitorIncident> GetAlertRuleIncidents(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets alert rule incidents. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of monitor incidents. </returns>
        public virtual AsyncPageable<MonitorIncident> GetAlertRuleIncidentsAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Deletes the alert rule. </summary>
        /// <param name="waitUntil"> Completion behavior for the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The delete operation. </returns>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Deletes the alert rule. </summary>
        /// <param name="waitUntil"> Completion behavior for the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The delete operation. </returns>
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Updates the alert rule. </summary>
        /// <param name="patch"> The alert rule patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated alert rule resource. </returns>
        public virtual Response<AlertRuleResource> Update(BinaryData patch, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Updates the alert rule. </summary>
        /// <param name="patch"> The alert rule patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated alert rule resource. </returns>
        public virtual Task<Response<AlertRuleResource>> UpdateAsync(BinaryData patch, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Updates the alert rule. </summary>
        /// <param name="patch"> The alert rule patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated alert rule resource. </returns>
        public virtual Response<AlertRuleResource> Update(AlertRulePatch patch, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Updates the alert rule. </summary>
        /// <param name="patch"> The alert rule patch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The updated alert rule resource. </returns>
        public virtual Task<Response<AlertRuleResource>> UpdateAsync(AlertRulePatch patch, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        AlertRuleData IJsonModel<AlertRuleData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<AlertRuleData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        AlertRuleData IPersistableModel<AlertRuleData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<AlertRuleData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<AlertRuleData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");
    }
}
