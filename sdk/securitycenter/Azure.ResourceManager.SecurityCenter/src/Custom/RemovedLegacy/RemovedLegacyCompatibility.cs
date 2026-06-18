// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0169 // Compatibility extensible enums preserve generated backing fields.
#pragma warning disable CS1591 // Hidden obsolete compatibility shims do not need public docs.
#pragma warning disable SA1402 // Compatibility shims are grouped by purpose in one file.
#pragma warning disable SA1508 // Generated-style shim formatting is intentionally preserved.
#pragma warning disable SA1518 // Generated-style shim formatting is intentionally preserved.

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

// Compatibility shims for public SecurityCenter APIs that existed in the previous GA SDK but were removed from the latest service specification.
namespace Azure.ResourceManager.SecurityCenter
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AdaptiveApplicationControlGroupCollection : Azure.ResourceManager.ArmCollection
    {
        protected AdaptiveApplicationControlGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string groupName, Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string groupName, Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AdaptiveApplicationControlGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>
    {
        public AdaptiveApplicationControlGroupData() { }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus? ConfigurationStatus { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode? EnforcementMode { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssueSummary> Issues { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.Core.AzureLocation? Location { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.PathRecommendation> PathRecommendations { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode ProtectionMode { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus? RecommendationStatus { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem? SourceSystem { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.VmRecommendation> VmRecommendations { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AdaptiveApplicationControlGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdaptiveApplicationControlGroupResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData Data { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public virtual bool HasData { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation ascLocation, string groupName) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AdaptiveNetworkHardeningCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>, System.Collections.IEnumerable
    {
        protected AdaptiveNetworkHardeningCollection() { }
        public virtual Azure.Response<bool> Exists(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> Get(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>> GetAsync(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> GetIfExists(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>> GetIfExistsAsync(string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AdaptiveNetworkHardeningData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>
    {
        public AdaptiveNetworkHardeningData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups> EffectiveNetworkSecurityGroups { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.RecommendedSecurityRule> Rules { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.DateTimeOffset? RulesCalculatedOn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AdaptiveNetworkHardeningResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdaptiveNetworkHardeningResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData Data { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public virtual bool HasData { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceNamespace, string resourceType, string resourceName, string adaptiveNetworkHardeningResourceName) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.ResourceManager.ArmOperation Enforce(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnforceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class CustomAssessmentAutomationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>, System.Collections.IEnumerable
    {
        protected CustomAssessmentAutomationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string customAssessmentAutomationName, Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string customAssessmentAutomationName, Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<bool> Exists(string customAssessmentAutomationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string customAssessmentAutomationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> Get(string customAssessmentAutomationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>> GetAsync(string customAssessmentAutomationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetIfExists(string customAssessmentAutomationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>> GetIfExistsAsync(string customAssessmentAutomationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class CustomAssessmentAutomationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData>
    {
        public CustomAssessmentAutomationData() { }
        public string AssessmentKey { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string CompressedQuery { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Description { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string DisplayName { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string RemediationDescription { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity? Severity { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud? SupportedCloud { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class CustomAssessmentAutomationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CustomAssessmentAutomationResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData Data { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public virtual bool HasData { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string customAssessmentAutomationName) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class CustomEntityStoreAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>, System.Collections.IEnumerable
    {
        protected CustomEntityStoreAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string customEntityStoreAssignmentName, Azure.ResourceManager.SecurityCenter.Models.CustomEntityStoreAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string customEntityStoreAssignmentName, Azure.ResourceManager.SecurityCenter.Models.CustomEntityStoreAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<bool> Exists(string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> Get(string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>> GetAsync(string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetIfExists(string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>> GetIfExistsAsync(string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class CustomEntityStoreAssignmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData>
    {
        public CustomEntityStoreAssignmentData() { }
        public string EntityStoreDatabaseLink { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Principal { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class CustomEntityStoreAssignmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CustomEntityStoreAssignmentResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData Data { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public virtual bool HasData { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string customEntityStoreAssignmentName) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.CustomEntityStoreAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.CustomEntityStoreAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SecurityApplicationData : Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SecurityApplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityApplicationData>
    {
        public SecurityApplicationData() { }
        public new System.Collections.Generic.IList<System.BinaryData> ConditionSets { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public new string Description { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public new string DisplayName { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public new Azure.ResourceManager.SecurityCenter.Models.ApplicationSourceResourceType? SourceResourceType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.SecurityApplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SecurityApplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SecurityApplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.SecurityApplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityApplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityApplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityApplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SecurityCloudConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>, System.Collections.IEnumerable
    {
        protected SecurityCloudConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<bool> Exists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> Get(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> GetAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> GetIfExists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> GetIfExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SecurityCloudConnectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>
    {
        public SecurityCloudConnectorData() { }
        public Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties AuthenticationDetails { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.HybridComputeSettingsProperties HybridComputeSettings { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SecurityCloudConnectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityCloudConnectorResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData Data { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public virtual bool HasData { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string connectorName) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class ServerVulnerabilityAssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>, System.Collections.IEnumerable
    {
        protected ServerVulnerabilityAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<bool> Exists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> GetIfExists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>> GetIfExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.ServerVulnerabilityAssessmentResource>.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SoftwareInventoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource>, System.Collections.IEnumerable
    {
        protected SoftwareInventoryCollection() { }
        public virtual Azure.Response<bool> Exists(string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> Get(string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource>> GetAsync(string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetIfExists(string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource>> GetIfExistsAsync(string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource>.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SoftwareInventoryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>
    {
        public SoftwareInventoryData() { }
        public string DeviceId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string EndOfSupportDate { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus? EndOfSupportStatus { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.DateTimeOffset? FirstSeenOn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public int? NumberOfKnownVulnerabilities { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string OSPlatform { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string SoftwareName { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Vendor { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Version { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.SoftwareInventoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.SoftwareInventoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SoftwareInventoryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SoftwareInventoryResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.SoftwareInventoryData Data { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public virtual bool HasData { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceNamespace, string resourceType, string resourceName, string softwareName) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        Azure.ResourceManager.SecurityCenter.SoftwareInventoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.SoftwareInventoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SubscriptionGovernanceRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>, System.Collections.IEnumerable
    {
        protected SubscriptionGovernanceRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<bool> Exists(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> Get(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> GetAsync(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SubscriptionGovernanceRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionGovernanceRuleResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.GovernanceRuleData Data { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public virtual bool HasData { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string ruleId) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.ResourceManager.ArmOperation ExecuteRule(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteRuleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus> GetRuleExecutionStatus(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>> GetRuleExecutionStatusAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SubscriptionGovernanceRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.GovernanceRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
public static partial class SecurityCenterExtensions
    {
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource GetAdaptiveApplicationControlGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? includePathRecommendations = default(bool?), bool? summary = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? includePathRecommendations = default(bool?), bool? summary = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> GetAdaptiveNetworkHardening(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>> GetAdaptiveNetworkHardeningAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string adaptiveNetworkHardeningResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource GetAdaptiveNetworkHardeningResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningCollection GetAdaptiveNetworkHardenings(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetCustomAssessmentAutomation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customAssessmentAutomationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource>> GetCustomAssessmentAutomationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customAssessmentAutomationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource GetCustomAssessmentAutomationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationCollection GetCustomAssessmentAutomations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetCustomAssessmentAutomations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource> GetCustomAssessmentAutomationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource>> GetCustomEntityStoreAssignmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customEntityStoreAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource GetCustomEntityStoreAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentCollection GetCustomEntityStoreAssignments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignmentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> GetSecurityCloudConnector(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> GetSecurityCloudConnectorAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource GetSecurityCloudConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorCollection GetSecurityCloudConnectors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.SoftwareInventoryCollection GetSoftwareInventories(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetSoftwareInventories(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetSoftwareInventoriesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> GetSoftwareInventory(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource>> GetSoftwareInventoryAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceNamespace, string resourceType, string resourceName, string softwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource GetSoftwareInventoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    public partial class SecurityCenterLocationResource
    {
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> GetAdaptiveApplicationControlGroup(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> GetAdaptiveApplicationControlGroupAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupCollection GetAdaptiveApplicationControlGroups() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

}

namespace Azure.ResourceManager.SecurityCenter.Models
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class ActiveConnectionsNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ActiveConnectionsNotInAllowedRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ActiveConnectionsNotInAllowedRange>
    {
        public ActiveConnectionsNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base(default(bool), default(int), default(int), default(System.TimeSpan)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.ActiveConnectionsNotInAllowedRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ActiveConnectionsNotInAllowedRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ActiveConnectionsNotInAllowedRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.ActiveConnectionsNotInAllowedRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ActiveConnectionsNotInAllowedRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ActiveConnectionsNotInAllowedRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ActiveConnectionsNotInAllowedRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct AdaptiveApplicationControlEnforcementMode : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdaptiveApplicationControlEnforcementMode(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode Audit { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode Enforce { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode None { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode left, Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode left, Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct AdaptiveApplicationControlGroupSourceSystem : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdaptiveApplicationControlGroupSourceSystem(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem AzureAppLocker { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem AzureAuditD { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem NonAzureAppLocker { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem NonAzureAuditD { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem None { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem left, Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem left, Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct AdaptiveApplicationControlIssue : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdaptiveApplicationControlIssue(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue ExecutableViolationsAudited { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue MsiAndScriptViolationsAudited { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue MsiAndScriptViolationsBlocked { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue RulesViolatedManually { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue ViolationsAudited { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue ViolationsBlocked { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue left, Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue left, Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AdaptiveApplicationControlIssueSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssueSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssueSummary>
    {
        internal AdaptiveApplicationControlIssueSummary() { }
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssue? Issue { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public float? NumberOfVms { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssueSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssueSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssueSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssueSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssueSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssueSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssueSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AdaptiveNetworkHardeningEnforceContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent>
    {
        public AdaptiveNetworkHardeningEnforceContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityCenter.Models.RecommendedSecurityRule> rules, System.Collections.Generic.IEnumerable<string> networkSecurityGroups) { }
        public System.Collections.Generic.IList<string> NetworkSecurityGroups { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.RecommendedSecurityRule> Rules { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AmqpC2DMessagesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AmqpC2DMessagesNotInAllowedRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AmqpC2DMessagesNotInAllowedRange>
    {
        public AmqpC2DMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base(default(bool), default(int), default(int), default(System.TimeSpan)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AmqpC2DMessagesNotInAllowedRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AmqpC2DMessagesNotInAllowedRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AmqpC2DMessagesNotInAllowedRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AmqpC2DMessagesNotInAllowedRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AmqpC2DMessagesNotInAllowedRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AmqpC2DMessagesNotInAllowedRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AmqpC2DMessagesNotInAllowedRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AmqpC2DRejectedMessagesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AmqpC2DRejectedMessagesNotInAllowedRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AmqpC2DRejectedMessagesNotInAllowedRange>
    {
        public AmqpC2DRejectedMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base(default(bool), default(int), default(int), default(System.TimeSpan)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AmqpC2DRejectedMessagesNotInAllowedRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AmqpC2DRejectedMessagesNotInAllowedRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AmqpC2DRejectedMessagesNotInAllowedRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AmqpC2DRejectedMessagesNotInAllowedRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AmqpC2DRejectedMessagesNotInAllowedRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AmqpC2DRejectedMessagesNotInAllowedRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AmqpC2DRejectedMessagesNotInAllowedRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AmqpD2CMessagesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AmqpD2CMessagesNotInAllowedRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AmqpD2CMessagesNotInAllowedRange>
    {
        public AmqpD2CMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base(default(bool), default(int), default(int), default(System.TimeSpan)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AmqpD2CMessagesNotInAllowedRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AmqpD2CMessagesNotInAllowedRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AmqpD2CMessagesNotInAllowedRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AmqpD2CMessagesNotInAllowedRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AmqpD2CMessagesNotInAllowedRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AmqpD2CMessagesNotInAllowedRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AmqpD2CMessagesNotInAllowedRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public abstract partial class AuthenticationDetailsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties>
    {
        protected AuthenticationDetailsProperties() { }
        public Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState? AuthenticationProvisioningState { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission> GrantedPermissions { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct AuthenticationProvisioningState : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthenticationProvisioningState(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState Expired { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState IncorrectPolicy { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState Invalid { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState Valid { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState left, Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState left, Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct AvailableSubPlanType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvailableSubPlanType(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType P1 { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType P2 { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType left, Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType left, Azure.ResourceManager.SecurityCenter.Models.AvailableSubPlanType right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AwsCredsAuthenticationDetailsProperties : Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AwsCredsAuthenticationDetailsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AwsCredsAuthenticationDetailsProperties>
    {
        public AwsCredsAuthenticationDetailsProperties(string awsAccessKeyId, string awsSecretAccessKey) { }
        public string AccountId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string AwsAccessKeyId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string AwsSecretAccessKey { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AwsCredsAuthenticationDetailsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AwsCredsAuthenticationDetailsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AwsCredsAuthenticationDetailsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AwsCredsAuthenticationDetailsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AwsCredsAuthenticationDetailsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AwsCredsAuthenticationDetailsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AwsCredsAuthenticationDetailsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AwsEnvironment : Azure.ResourceManager.SecurityCenter.Models.SecurityConnectorEnvironment, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AwsEnvironment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AwsEnvironment>
    {
        public AwsEnvironment() { }
        public string AccountName { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.AwsOrganizationalInfo OrganizationalData { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IList<string> Regions { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public long? ScanInterval { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AwsEnvironment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AwsEnvironment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AwsEnvironment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AwsEnvironment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AwsEnvironment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AwsEnvironment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AwsEnvironment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AzureDevOpsScopeEnvironment : Azure.ResourceManager.SecurityCenter.Models.SecurityConnectorEnvironment, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AzureDevOpsScopeEnvironment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AzureDevOpsScopeEnvironment>
    {
        public AzureDevOpsScopeEnvironment() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AzureDevOpsScopeEnvironment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AzureDevOpsScopeEnvironment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AzureDevOpsScopeEnvironment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AzureDevOpsScopeEnvironment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AzureDevOpsScopeEnvironment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AzureDevOpsScopeEnvironment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AzureDevOpsScopeEnvironment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class ConnectionFromIPNotAllowed : Azure.ResourceManager.SecurityCenter.Models.AllowlistCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionFromIPNotAllowed>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionFromIPNotAllowed>
    {
        public ConnectionFromIPNotAllowed(bool isEnabled, System.Collections.Generic.IEnumerable<string> allowlistValues) : base(default(bool), default(System.Collections.Generic.IEnumerable<string>)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.ConnectionFromIPNotAllowed System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionFromIPNotAllowed>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionFromIPNotAllowed>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.ConnectionFromIPNotAllowed System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionFromIPNotAllowed>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionFromIPNotAllowed>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionFromIPNotAllowed>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class ConnectionToIPNotAllowed : Azure.ResourceManager.SecurityCenter.Models.AllowlistCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionToIPNotAllowed>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionToIPNotAllowed>
    {
        public ConnectionToIPNotAllowed(bool isEnabled, System.Collections.Generic.IEnumerable<string> allowlistValues) : base(default(bool), default(System.Collections.Generic.IEnumerable<string>)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.ConnectionToIPNotAllowed System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionToIPNotAllowed>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionToIPNotAllowed>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.ConnectionToIPNotAllowed System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionToIPNotAllowed>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionToIPNotAllowed>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionToIPNotAllowed>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class CustomAssessmentAutomationCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationCreateOrUpdateContent>
    {
        public CustomAssessmentAutomationCreateOrUpdateContent() { }
        public string CompressedQuery { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Description { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string DisplayName { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string RemediationDescription { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity? Severity { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud? SupportedCloud { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct CustomAssessmentAutomationSupportedCloud : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomAssessmentAutomationSupportedCloud(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud Aws { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud Gcp { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud left, Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud left, Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentAutomationSupportedCloud right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct CustomAssessmentSeverity : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomAssessmentSeverity(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity High { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity Low { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity Medium { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity left, Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity left, Azure.ResourceManager.SecurityCenter.Models.CustomAssessmentSeverity right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class CustomEntityStoreAssignmentCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.CustomEntityStoreAssignmentCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.CustomEntityStoreAssignmentCreateOrUpdateContent>
    {
        public CustomEntityStoreAssignmentCreateOrUpdateContent() { }
        public string Principal { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.CustomEntityStoreAssignmentCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.CustomEntityStoreAssignmentCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.CustomEntityStoreAssignmentCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.CustomEntityStoreAssignmentCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.CustomEntityStoreAssignmentCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.CustomEntityStoreAssignmentCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.CustomEntityStoreAssignmentCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration>
    {
        public DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration() { }
        public string PrivateLinkScope { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Proxy { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class DefenderForDatabasesAwsOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOffering>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOffering>
    {
        public DefenderForDatabasesAwsOffering() { }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingArcAutoProvisioning ArcAutoProvisioning { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderFoDatabasesAwsOfferingDatabasesDspm DatabasesDspm { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingRds Rds { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOffering System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOffering>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOffering>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOffering System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOffering>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOffering>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOffering>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class DefenderForDatabasesAwsOfferingArcAutoProvisioning : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingArcAutoProvisioning>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingArcAutoProvisioning>
    {
        public DefenderForDatabasesAwsOfferingArcAutoProvisioning() { }
        public string CloudRoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration Configuration { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool? IsEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingArcAutoProvisioning System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingArcAutoProvisioning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingArcAutoProvisioning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingArcAutoProvisioning System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingArcAutoProvisioning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingArcAutoProvisioning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingArcAutoProvisioning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class DefenderForDatabasesAwsOfferingRds : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingRds>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingRds>
    {
        public DefenderForDatabasesAwsOfferingRds() { }
        public string CloudRoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool? IsEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingRds System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingRds>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingRds>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingRds System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingRds>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingRds>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDatabasesAwsOfferingRds>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class DefenderForDevOpsAzureDevOpsOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDevOpsAzureDevOpsOffering>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDevOpsAzureDevOpsOffering>
    {
        public DefenderForDevOpsAzureDevOpsOffering() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.DefenderForDevOpsAzureDevOpsOffering System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDevOpsAzureDevOpsOffering>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDevOpsAzureDevOpsOffering>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.DefenderForDevOpsAzureDevOpsOffering System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDevOpsAzureDevOpsOffering>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDevOpsAzureDevOpsOffering>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDevOpsAzureDevOpsOffering>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class DefenderForDevOpsGithubOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDevOpsGithubOffering>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDevOpsGithubOffering>
    {
        public DefenderForDevOpsGithubOffering() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.DefenderForDevOpsGithubOffering System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDevOpsGithubOffering>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDevOpsGithubOffering>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.DefenderForDevOpsGithubOffering System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDevOpsGithubOffering>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDevOpsGithubOffering>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DefenderForDevOpsGithubOffering>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct DefenderForServersScanningMode : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefenderForServersScanningMode(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode Default { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode left, Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode left, Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct DefenderForStorageSettingName : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.DefenderForStorageSettingName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefenderForStorageSettingName(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.DefenderForStorageSettingName Current { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.DefenderForStorageSettingName other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.DefenderForStorageSettingName left, Azure.ResourceManager.SecurityCenter.Models.DefenderForStorageSettingName right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.DefenderForStorageSettingName(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.DefenderForStorageSettingName left, Azure.ResourceManager.SecurityCenter.Models.DefenderForStorageSettingName right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class DirectMethodInvokesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DirectMethodInvokesNotInAllowedRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DirectMethodInvokesNotInAllowedRange>
    {
        public DirectMethodInvokesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base(default(bool), default(int), default(int), default(System.TimeSpan)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.DirectMethodInvokesNotInAllowedRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DirectMethodInvokesNotInAllowedRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.DirectMethodInvokesNotInAllowedRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.DirectMethodInvokesNotInAllowedRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DirectMethodInvokesNotInAllowedRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DirectMethodInvokesNotInAllowedRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.DirectMethodInvokesNotInAllowedRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class EffectiveNetworkSecurityGroups : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups>
    {
        public EffectiveNetworkSecurityGroups() { }
        public string NetworkInterface { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IList<string> NetworkSecurityGroups { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct EndOfSupportStatus : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndOfSupportStatus(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus NoLongerSupported { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus None { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus UpcomingNoLongerSupported { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus UpcomingVersionNoLongerSupported { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus VersionNoLongerSupported { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus left, Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus left, Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class ExecuteRuleStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>
    {
        internal ExecuteRuleStatus() { }
        public string OperationId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class FailedLocalLoginsNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.FailedLocalLoginsNotInAllowedRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.FailedLocalLoginsNotInAllowedRange>
    {
        public FailedLocalLoginsNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base(default(bool), default(int), default(int), default(System.TimeSpan)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.FailedLocalLoginsNotInAllowedRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.FailedLocalLoginsNotInAllowedRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.FailedLocalLoginsNotInAllowedRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.FailedLocalLoginsNotInAllowedRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.FailedLocalLoginsNotInAllowedRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.FailedLocalLoginsNotInAllowedRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.FailedLocalLoginsNotInAllowedRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class FileUploadsNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.FileUploadsNotInAllowedRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.FileUploadsNotInAllowedRange>
    {
        public FileUploadsNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base(default(bool), default(int), default(int), default(System.TimeSpan)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.FileUploadsNotInAllowedRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.FileUploadsNotInAllowedRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.FileUploadsNotInAllowedRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.FileUploadsNotInAllowedRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.FileUploadsNotInAllowedRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.FileUploadsNotInAllowedRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.FileUploadsNotInAllowedRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class GcpCredentialsDetailsProperties : Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>
    {
        public GcpCredentialsDetailsProperties(string organizationId, string gcpCredentialType, string projectId, string privateKeyId, string privateKey, string clientEmail, string clientId, System.Uri authUri, System.Uri tokenUri, System.Uri authProviderX509CertUri, System.Uri clientX509CertUri) { }
        public System.Uri AuthProviderX509CertUri { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Uri AuthUri { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string ClientEmail { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string ClientId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Uri ClientX509CertUri { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string GcpCredentialType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string OrganizationId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string PrivateKey { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string PrivateKeyId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string ProjectId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Uri TokenUri { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class GcpMemberOrganizationalInfo : Azure.ResourceManager.SecurityCenter.Models.GcpOrganizationalInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GcpMemberOrganizationalInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpMemberOrganizationalInfo>
    {
        public GcpMemberOrganizationalInfo() { }
        public string ManagementProjectNumber { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string ParentHierarchyId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.GcpMemberOrganizationalInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GcpMemberOrganizationalInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GcpMemberOrganizationalInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.GcpMemberOrganizationalInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpMemberOrganizationalInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpMemberOrganizationalInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpMemberOrganizationalInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class GcpParentOrganizationalInfo : Azure.ResourceManager.SecurityCenter.Models.GcpOrganizationalInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GcpParentOrganizationalInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpParentOrganizationalInfo>
    {
        public GcpParentOrganizationalInfo() { }
        public System.Collections.Generic.IList<string> ExcludedProjectNumbers { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string OrganizationName { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string ServiceAccountEmailAddress { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string WorkloadIdentityProviderId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.GcpParentOrganizationalInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GcpParentOrganizationalInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GcpParentOrganizationalInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.GcpParentOrganizationalInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpParentOrganizationalInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpParentOrganizationalInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpParentOrganizationalInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class GcpProjectEnvironment : Azure.ResourceManager.SecurityCenter.Models.SecurityConnectorEnvironment, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GcpProjectEnvironment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpProjectEnvironment>
    {
        public GcpProjectEnvironment() { }
        public Azure.ResourceManager.SecurityCenter.Models.GcpOrganizationalInfo OrganizationalData { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.GcpProjectDetails ProjectDetails { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public long? ScanInterval { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.GcpProjectEnvironment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GcpProjectEnvironment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GcpProjectEnvironment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.GcpProjectEnvironment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpProjectEnvironment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpProjectEnvironment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpProjectEnvironment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class GithubScopeEnvironment : Azure.ResourceManager.SecurityCenter.Models.SecurityConnectorEnvironment, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GithubScopeEnvironment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GithubScopeEnvironment>
    {
        public GithubScopeEnvironment() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.GithubScopeEnvironment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GithubScopeEnvironment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GithubScopeEnvironment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.GithubScopeEnvironment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GithubScopeEnvironment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GithubScopeEnvironment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GithubScopeEnvironment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class HttpC2DMessagesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.HttpC2DMessagesNotInAllowedRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.HttpC2DMessagesNotInAllowedRange>
    {
        public HttpC2DMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base(default(bool), default(int), default(int), default(System.TimeSpan)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.HttpC2DMessagesNotInAllowedRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.HttpC2DMessagesNotInAllowedRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.HttpC2DMessagesNotInAllowedRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.HttpC2DMessagesNotInAllowedRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.HttpC2DMessagesNotInAllowedRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.HttpC2DMessagesNotInAllowedRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.HttpC2DMessagesNotInAllowedRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class HttpC2DRejectedMessagesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.HttpC2DRejectedMessagesNotInAllowedRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.HttpC2DRejectedMessagesNotInAllowedRange>
    {
        public HttpC2DRejectedMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base(default(bool), default(int), default(int), default(System.TimeSpan)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.HttpC2DRejectedMessagesNotInAllowedRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.HttpC2DRejectedMessagesNotInAllowedRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.HttpC2DRejectedMessagesNotInAllowedRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.HttpC2DRejectedMessagesNotInAllowedRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.HttpC2DRejectedMessagesNotInAllowedRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.HttpC2DRejectedMessagesNotInAllowedRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.HttpC2DRejectedMessagesNotInAllowedRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class HttpD2CMessagesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.HttpD2CMessagesNotInAllowedRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.HttpD2CMessagesNotInAllowedRange>
    {
        public HttpD2CMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base(default(bool), default(int), default(int), default(System.TimeSpan)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.HttpD2CMessagesNotInAllowedRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.HttpD2CMessagesNotInAllowedRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.HttpD2CMessagesNotInAllowedRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.HttpD2CMessagesNotInAllowedRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.HttpD2CMessagesNotInAllowedRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.HttpD2CMessagesNotInAllowedRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.HttpD2CMessagesNotInAllowedRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct HybridComputeProvisioningState : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridComputeProvisioningState(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState Expired { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState Invalid { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState Valid { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState left, Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState left, Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class HybridComputeSettingsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.HybridComputeSettingsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.HybridComputeSettingsProperties>
    {
        public HybridComputeSettingsProperties(Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState autoProvision) { }
        public Azure.ResourceManager.SecurityCenter.Models.AutoProvisionState AutoProvision { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.HybridComputeProvisioningState? HybridComputeProvisioningState { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.ProxyServerProperties ProxyServer { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Region { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string ResourceGroupName { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.ServicePrincipalProperties ServicePrincipal { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.HybridComputeSettingsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.HybridComputeSettingsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.HybridComputeSettingsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.HybridComputeSettingsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.HybridComputeSettingsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.HybridComputeSettingsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.HybridComputeSettingsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class InformationProtectionAwsOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionAwsOffering>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionAwsOffering>
    {
        public InformationProtectionAwsOffering() { }
        public string InformationProtectionCloudRoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.InformationProtectionAwsOffering System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionAwsOffering>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionAwsOffering>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.InformationProtectionAwsOffering System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionAwsOffering>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionAwsOffering>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionAwsOffering>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class InformationProtectionPolicy : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionPolicy>
    {
        public InformationProtectionPolicy() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.SecurityCenter.Models.SecurityInformationTypeInfo> InformationTypes { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.SecurityCenter.Models.SensitivityLabel> Labels { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.DateTimeOffset? LastModifiedUtc { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Version { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.InformationProtectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.InformationProtectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SecurityInformationTypeInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SecurityInformationTypeInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityInformationTypeInfo>
    {
        public SecurityInformationTypeInfo() { }
        public bool? Custom { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Description { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string DisplayName { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool? IsEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionKeyword> Keywords { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public int? Order { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Guid? RecommendedLabelId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.SecurityInformationTypeInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SecurityInformationTypeInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SecurityInformationTypeInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.SecurityInformationTypeInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityInformationTypeInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityInformationTypeInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityInformationTypeInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class LocalUserNotAllowed : Azure.ResourceManager.SecurityCenter.Models.AllowlistCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.LocalUserNotAllowed>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.LocalUserNotAllowed>
    {
        public LocalUserNotAllowed(bool isEnabled, System.Collections.Generic.IEnumerable<string> allowlistValues) : base(default(bool), default(System.Collections.Generic.IEnumerable<string>)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.LocalUserNotAllowed System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.LocalUserNotAllowed>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.LocalUserNotAllowed>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.LocalUserNotAllowed System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.LocalUserNotAllowed>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.LocalUserNotAllowed>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.LocalUserNotAllowed>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class MdeOnboarding : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding>
    {
        public MdeOnboarding() { }
        public byte[] OnboardingPackageLinux { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public byte[] OnboardingPackageWindows { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.MdeOnboarding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class MqttC2DMessagesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.MqttC2DMessagesNotInAllowedRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.MqttC2DMessagesNotInAllowedRange>
    {
        public MqttC2DMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base(default(bool), default(int), default(int), default(System.TimeSpan)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.MqttC2DMessagesNotInAllowedRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.MqttC2DMessagesNotInAllowedRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.MqttC2DMessagesNotInAllowedRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.MqttC2DMessagesNotInAllowedRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.MqttC2DMessagesNotInAllowedRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.MqttC2DMessagesNotInAllowedRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.MqttC2DMessagesNotInAllowedRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class MqttC2DRejectedMessagesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.MqttC2DRejectedMessagesNotInAllowedRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.MqttC2DRejectedMessagesNotInAllowedRange>
    {
        public MqttC2DRejectedMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base(default(bool), default(int), default(int), default(System.TimeSpan)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.MqttC2DRejectedMessagesNotInAllowedRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.MqttC2DRejectedMessagesNotInAllowedRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.MqttC2DRejectedMessagesNotInAllowedRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.MqttC2DRejectedMessagesNotInAllowedRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.MqttC2DRejectedMessagesNotInAllowedRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.MqttC2DRejectedMessagesNotInAllowedRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.MqttC2DRejectedMessagesNotInAllowedRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class MqttD2CMessagesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.MqttD2CMessagesNotInAllowedRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.MqttD2CMessagesNotInAllowedRange>
    {
        public MqttD2CMessagesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base(default(bool), default(int), default(int), default(System.TimeSpan)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.MqttD2CMessagesNotInAllowedRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.MqttD2CMessagesNotInAllowedRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.MqttD2CMessagesNotInAllowedRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.MqttD2CMessagesNotInAllowedRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.MqttD2CMessagesNotInAllowedRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.MqttD2CMessagesNotInAllowedRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.MqttD2CMessagesNotInAllowedRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class PathRecommendation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.PathRecommendation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.PathRecommendation>
    {
        public PathRecommendation() { }
        public Azure.ResourceManager.SecurityCenter.Models.RecommendationAction? Action { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus? ConfigurationStatus { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType? FileType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.IotSecurityRecommendationType? IotSecurityRecommendationType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool? IsCommon { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Path { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPublisherInfo PublisherInfo { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.UserRecommendation> Usernames { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IList<string> UserSids { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.PathRecommendation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.PathRecommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.PathRecommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.PathRecommendation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.PathRecommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.PathRecommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.PathRecommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct PathRecommendationFileType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PathRecommendationFileType(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType Dll { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType Exe { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType Executable { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType Msi { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType Script { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType Unknown { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType left, Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType left, Azure.ResourceManager.SecurityCenter.Models.PathRecommendationFileType right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class ProcessNotAllowed : Azure.ResourceManager.SecurityCenter.Models.AllowlistCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ProcessNotAllowed>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ProcessNotAllowed>
    {
        public ProcessNotAllowed(bool isEnabled, System.Collections.Generic.IEnumerable<string> allowlistValues) : base(default(bool), default(System.Collections.Generic.IEnumerable<string>)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.ProcessNotAllowed System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ProcessNotAllowed>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ProcessNotAllowed>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.ProcessNotAllowed System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ProcessNotAllowed>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ProcessNotAllowed>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ProcessNotAllowed>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class ProxyServerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ProxyServerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ProxyServerProperties>
    {
        public ProxyServerProperties() { }
        public string IP { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Port { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.ProxyServerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ProxyServerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ProxyServerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.ProxyServerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ProxyServerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ProxyServerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ProxyServerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class QueuePurgesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.QueuePurgesNotInAllowedRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.QueuePurgesNotInAllowedRange>
    {
        public QueuePurgesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base(default(bool), default(int), default(int), default(System.TimeSpan)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.QueuePurgesNotInAllowedRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.QueuePurgesNotInAllowedRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.QueuePurgesNotInAllowedRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.QueuePurgesNotInAllowedRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.QueuePurgesNotInAllowedRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.QueuePurgesNotInAllowedRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.QueuePurgesNotInAllowedRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct RecommendationAction : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.RecommendationAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationAction(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationAction Add { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationAction Recommended { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationAction Remove { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.RecommendationAction other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.RecommendationAction left, Azure.ResourceManager.SecurityCenter.Models.RecommendationAction right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.RecommendationAction(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.RecommendationAction left, Azure.ResourceManager.SecurityCenter.Models.RecommendationAction right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct RecommendationStatus : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationStatus(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus NoStatus { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus NotAvailable { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus NotRecommended { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus Recommended { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus left, Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus left, Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class RecommendedSecurityRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.RecommendedSecurityRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.RecommendedSecurityRule>
    {
        public RecommendedSecurityRule() { }
        public int? DestinationPort { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection? Direction { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IList<string> IPAddresses { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Name { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol> Protocols { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.RecommendedSecurityRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.RecommendedSecurityRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.RecommendedSecurityRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.RecommendedSecurityRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.RecommendedSecurityRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.RecommendedSecurityRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.RecommendedSecurityRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class RulesResultsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent>
    {
        public RulesResultsContent() { }
        public bool? LatestScan { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<System.Collections.Generic.IList<string>>> Results { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.RulesResultsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct SecurityAlertMinimalSeverity : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAlertMinimalSeverity(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity High { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity Low { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity Medium { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct SecurityAlertNotificationState : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAlertNotificationState(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState Off { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState On { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct SecurityAlertSimulatorBundleType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAlertSimulatorBundleType(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType AppServices { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType CosmosDbs { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType Dns { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType KeyVaults { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType KubernetesService { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType ResourceManager { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType SqlServers { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType StorageAccounts { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType VirtualMachines { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType left, Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SecurityAlertSyncSettings : Azure.ResourceManager.SecurityCenter.SecuritySettingData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSyncSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSyncSettings>
    {
        public SecurityAlertSyncSettings() { }
        public bool? IsEnabled { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSyncSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSyncSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSyncSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSyncSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSyncSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSyncSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSyncSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct SecurityCenterCloudPermission : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityCenterCloudPermission(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission AwsAmazonSsmAutomationRole { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission AwsAwsSecurityHubReadOnlyAccess { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission AwsSecurityAudit { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission GcpSecurityCenterAdminViewer { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct SecurityCenterConfigurationStatus : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityCenterConfigurationStatus(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus Configured { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus Failed { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus InProgress { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus NoStatus { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus NotConfigured { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct SecurityCenterConnectionType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityCenterConnectionType(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType External { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType Internal { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConnectionType right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SecurityCenterFileProtectionMode : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode>
    {
        public SecurityCenterFileProtectionMode() { }
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode? Exe { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode? Executable { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode? Msi { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode? Script { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SecurityCenterPublisherInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPublisherInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPublisherInfo>
    {
        public SecurityCenterPublisherInfo() { }
        public string BinaryName { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string ProductName { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string PublisherName { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Version { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPublisherInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPublisherInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPublisherInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPublisherInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPublisherInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPublisherInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterPublisherInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct SecurityCenterVmEnforcementSupportState : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityCenterVmEnforcementSupportState(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState NotSupported { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState Supported { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState Unknown { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState left, Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct SecurityFamilyProvisioningState : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityFamilyProvisioningState(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState Failed { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState Succeeded { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState Updating { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState left, Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState left, Azure.ResourceManager.SecurityCenter.Models.SecurityFamilyProvisioningState right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct SecuritySettingName : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecuritySettingName(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName Mcas { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName Sentinel { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName Wdatp { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName WdatpExcludeLinuxPublicPreview { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName WdatpUnifiedSolution { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName left, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName left, Azure.ResourceManager.SecurityCenter.Models.SecuritySettingName right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct SecurityTrafficDirection : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityTrafficDirection(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection Inbound { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection Outbound { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection left, Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection left, Azure.ResourceManager.SecurityCenter.Models.SecurityTrafficDirection right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct SecurityTransportProtocol : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityTransportProtocol(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol Tcp { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol Udp { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol left, Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol left, Azure.ResourceManager.SecurityCenter.Models.SecurityTransportProtocol right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class ServicePrincipalProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ServicePrincipalProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ServicePrincipalProperties>
    {
        public ServicePrincipalProperties() { }
        public System.Guid? ApplicationId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Secret { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.ServicePrincipalProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ServicePrincipalProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ServicePrincipalProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.ServicePrincipalProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ServicePrincipalProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ServicePrincipalProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ServicePrincipalProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SqlVulnerabilityAssessmentRemediation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentRemediation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentRemediation>
    {
        public SqlVulnerabilityAssessmentRemediation() { }
        public string Description { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool? IsAutomated { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string PortalLink { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IList<string> Scripts { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentRemediation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentRemediation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentRemediation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentRemediation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentRemediation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentRemediation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentRemediation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SqlVulnerabilityAssessmentScanResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult>
    {
        public SqlVulnerabilityAssessmentScanResult() { }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultProperties Properties { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SqlVulnerabilityAssessmentScanResultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultProperties>
    {
        public SqlVulnerabilityAssessmentScanResultProperties() { }
        public Azure.ResourceManager.SecurityCenter.Models.BaselineAdjustedResult BaselineAdjustedResult { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool? IsTrimmed { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> QueryResults { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentRemediation Remediation { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string RuleId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRule RuleMetadata { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultRuleStatus? Status { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SqlVulnerabilityAssessmentScanResultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class TwinUpdatesNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.TwinUpdatesNotInAllowedRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.TwinUpdatesNotInAllowedRange>
    {
        public TwinUpdatesNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base(default(bool), default(int), default(int), default(System.TimeSpan)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.TwinUpdatesNotInAllowedRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.TwinUpdatesNotInAllowedRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.TwinUpdatesNotInAllowedRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.TwinUpdatesNotInAllowedRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.TwinUpdatesNotInAllowedRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.TwinUpdatesNotInAllowedRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.TwinUpdatesNotInAllowedRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class UnauthorizedOperationsNotInAllowedRange : Azure.ResourceManager.SecurityCenter.Models.TimeWindowCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.UnauthorizedOperationsNotInAllowedRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.UnauthorizedOperationsNotInAllowedRange>
    {
        public UnauthorizedOperationsNotInAllowedRange(bool isEnabled, int minThreshold, int maxThreshold, System.TimeSpan timeWindowSize) : base(default(bool), default(int), default(int), default(System.TimeSpan)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.UnauthorizedOperationsNotInAllowedRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.UnauthorizedOperationsNotInAllowedRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.UnauthorizedOperationsNotInAllowedRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.UnauthorizedOperationsNotInAllowedRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.UnauthorizedOperationsNotInAllowedRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.UnauthorizedOperationsNotInAllowedRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.UnauthorizedOperationsNotInAllowedRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class UserRecommendation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.UserRecommendation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.UserRecommendation>
    {
        public UserRecommendation() { }
        public Azure.ResourceManager.SecurityCenter.Models.RecommendationAction? RecommendationAction { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Username { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.UserRecommendation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.UserRecommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.UserRecommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.UserRecommendation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.UserRecommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.UserRecommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.UserRecommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class VmRecommendation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.VmRecommendation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.VmRecommendation>
    {
        public VmRecommendation() { }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus? ConfigurationStatus { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState? EnforcementSupport { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.RecommendationAction? RecommendationAction { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.VmRecommendation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.VmRecommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.VmRecommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.VmRecommendation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.VmRecommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.VmRecommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.VmRecommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class VulnerabilityAssessmentRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRule>
    {
        public VulnerabilityAssessmentRule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.BenchmarkReference> BenchmarkReferences { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Category { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Description { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleQueryCheck QueryCheck { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Rationale { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string RuleId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType? RuleType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.RuleSeverity? Severity { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Title { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class VulnerabilityAssessmentRuleQueryCheck : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleQueryCheck>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleQueryCheck>
    {
        public VulnerabilityAssessmentRuleQueryCheck() { }
        public System.Collections.Generic.IList<string> ColumnNames { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> ExpectedResult { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Query { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleQueryCheck System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleQueryCheck>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleQueryCheck>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleQueryCheck System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleQueryCheck>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleQueryCheck>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleQueryCheck>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct VulnerabilityAssessmentRuleType : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VulnerabilityAssessmentRuleType(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType BaselineExpected { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType Binary { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType NegativeList { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType PositiveList { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType left, Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType left, Azure.ResourceManager.SecurityCenter.Models.VulnerabilityAssessmentRuleType right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

}

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    public partial class MockableSecurityCenterArmClient
    {
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource GetAdaptiveApplicationControlGroupResource(Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource GetAdaptiveNetworkHardeningResource(Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.SecurityCenter.CustomAssessmentAutomationResource GetCustomAssessmentAutomationResource(Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.SecurityCenter.CustomEntityStoreAssignmentResource GetCustomEntityStoreAssignmentResource(Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource GetSecurityCloudConnectorResource(Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        [Azure.Core.ForwardsClientCalls]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource GetSoftwareInventoryResource(Azure.Core.ResourceIdentifier id) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
