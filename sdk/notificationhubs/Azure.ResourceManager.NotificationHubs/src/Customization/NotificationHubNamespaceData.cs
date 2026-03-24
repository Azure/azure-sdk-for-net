// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NotificationHubs.Models;

namespace Azure.ResourceManager.NotificationHubs
{
    /// <summary>
    /// A class representing the NotificationHubNamespace data model.
    /// </summary>
    // Backward-compat: baseline had a constructor with only AzureLocation (no sku),
    // setters for output-only properties, and string/enum versions of ProvisioningState,
    // Status, and NamespaceType. Required by ApiCompat.
    public partial class NotificationHubNamespaceData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="NotificationHubNamespaceData"/>. </summary>
        /// <param name="location"> The location. </param>
        public NotificationHubNamespaceData(AzureLocation location) : base(location)
        {
        }

        // Backing fields provide setters for read-only properties to maintain backward-compat.
        // These properties are @visibility(Lifecycle.Read) in the spec, so:
        // - The generated serializer skips them on the wire (options.Format != "W" guard)
        // - The setter writes to the backing field, not Properties, but this won't cause
        //   practical issues because the values are never sent to the API anyway.
        // - The getter falls back to Properties for deserialized server data.
        private string _namespaceName;
        private bool? _isEnabled;
        private bool? _isCritical;
        private string _subscriptionId;
        private string _region;
        private DateTimeOffset? _createdOn;
        private DateTimeOffset? _updatedOn;
        private Uri _serviceBusEndpoint;

        /// <summary> The name of the namespace. </summary>
        public string NamespaceName
        {
            get => _namespaceName ?? Properties?.NamespaceName;
            set => _namespaceName = value;
        }

        /// <summary> Whether or not the namespace is currently enabled. </summary>
        public bool? IsEnabled
        {
            get => _isEnabled ?? Properties?.IsEnabled;
            set => _isEnabled = value;
        }

        /// <summary> Whether or not the namespace is set as Critical. </summary>
        public bool? IsCritical
        {
            get => _isCritical ?? Properties?.IsCritical;
            set => _isCritical = value;
        }

        /// <summary> The Id of the Azure subscription associated with the namespace. </summary>
        public string SubscriptionId
        {
            get => _subscriptionId ?? Properties?.SubscriptionId;
            set => _subscriptionId = value;
        }

        /// <summary> Specifies the targeted region. </summary>
        public string Region
        {
            get => _region ?? Properties?.Region;
            set => _region = value;
        }

        /// <summary> The time the namespace was created. </summary>
        public DateTimeOffset? CreatedOn
        {
            get => _createdOn ?? Properties?.CreatedOn;
            set => _createdOn = value;
        }

        /// <summary> The time the namespace was updated. </summary>
        public DateTimeOffset? UpdatedOn
        {
            get => _updatedOn ?? Properties?.UpdatedOn;
            set => _updatedOn = value;
        }

        /// <summary> Endpoint for NotificationHub operations. </summary>
        public Uri ServiceBusEndpoint
        {
            get => _serviceBusEndpoint ?? Properties?.ServiceBusEndpoint;
            set => _serviceBusEndpoint = value;
        }

        /// <summary> Provisioning state of the Namespace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProvisioningState
        {
            get => OperationProvisioningState?.ToString();
            set => OperationProvisioningState = string.IsNullOrEmpty(value) ? null : new OperationProvisioningState(value);
        }

        /// <summary> Status of the namespace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Status
        {
            get => NamespaceStatus?.ToString();
            set => NamespaceStatus = string.IsNullOrEmpty(value) ? null : new NotificationHubNamespaceStatus(value);
        }

        /// <summary> The namespace type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NotificationHubNamespaceType? NamespaceType
        {
            get => HubNamespaceType?.ToString().ToNotificationHubNamespaceType();
            set => HubNamespaceType = value.HasValue ? new NotificationHubNamespaceTypeExt(value.Value.ToString()) : null;
        }
    }
}
