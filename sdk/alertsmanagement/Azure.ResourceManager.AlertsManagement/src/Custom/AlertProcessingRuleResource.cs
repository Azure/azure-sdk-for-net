// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: this type was removed in the TypeSpec migration.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AlertsManagement.Models;

namespace Azure.ResourceManager.AlertsManagement
{
    /// <summary> Backward compatibility stub. The AlertProcessingRule types have been removed from this package and will be shipped in a separate package in a future release. </summary>
    [Obsolete("The AlertProcessingRule types have been removed from this package and will be shipped in a separate package in a future release.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AlertProcessingRuleResource : ArmResource, IJsonModel<AlertProcessingRuleData>, IPersistableModel<AlertProcessingRuleData>
    {
        /// <summary> The resource type. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.AlertsManagement/actionRules";

        /// <summary> Initializes a new instance for mocking. </summary>
        protected AlertProcessingRuleResource() { }

        /// <summary> Gets the data. </summary>
        public virtual AlertProcessingRuleData Data { get { throw new NotSupportedException(); } }

        /// <summary> Gets whether the resource has data. </summary>
        public virtual bool HasData { get { throw new NotSupportedException(); } }

        /// <summary> Creates a resource identifier. </summary>
        /// <param name="subscriptionId"> The subscription ID. </param>
        /// <param name="resourceGroupName"> The resource group name. </param>
        /// <param name="alertProcessingRuleName"> The alert processing rule name. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string alertProcessingRuleName) { throw new NotSupportedException(); }

        /// <summary> Adds a tag. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="value"> The tag value. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<AlertProcessingRuleResource> AddTag(string key, string value, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Adds a tag async. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="value"> The tag value. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Task<Response<AlertProcessingRuleResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Deletes the resource. </summary>
        /// <param name="waitUntil"> Wait until. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Deletes the resource async. </summary>
        /// <param name="waitUntil"> Wait until. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets the resource. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<AlertProcessingRuleResource> Get(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets the resource async. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Task<Response<AlertProcessingRuleResource>> GetAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Removes a tag. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<AlertProcessingRuleResource> RemoveTag(string key, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Removes a tag async. </summary>
        /// <param name="key"> The tag key. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Task<Response<AlertProcessingRuleResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Sets tags. </summary>
        /// <param name="tags"> The tags. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<AlertProcessingRuleResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Sets tags async. </summary>
        /// <param name="tags"> The tags. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Task<Response<AlertProcessingRuleResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Updates the resource. </summary>
        /// <param name="patch"> The patch data. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<AlertProcessingRuleResource> Update(AlertProcessingRulePatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Updates the resource async. </summary>
        /// <param name="patch"> The patch data. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Task<Response<AlertProcessingRuleResource>> UpdateAsync(AlertProcessingRulePatch patch, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Creates from JSON. </summary>
        AlertProcessingRuleData IJsonModel<AlertProcessingRuleData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to JSON. </summary>
        void IJsonModel<AlertProcessingRuleData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Creates from BinaryData. </summary>
        AlertProcessingRuleData IPersistableModel<AlertProcessingRuleData>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Gets format. </summary>
        string IPersistableModel<AlertProcessingRuleData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to BinaryData. </summary>
        BinaryData IPersistableModel<AlertProcessingRuleData>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
    }
}
