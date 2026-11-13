// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// This model has been deleted from the TypeSpec spec. It is kept here only for backward
// API compatibility (ApiCompat). All public APIs throw NotSupportedException.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NotificationHubs.Models
{
    /// <summary> Parameters supplied to the CreateOrUpdate Namespace operation. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NotificationHubNamespaceCreateOrUpdateContent : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="NotificationHubNamespaceCreateOrUpdateContent"/>. </summary>
        /// <param name="location"> The location. </param>
        public NotificationHubNamespaceCreateOrUpdateContent(AzureLocation location) : base(location)
        {
            throw new NotSupportedException($"{nameof(NotificationHubNamespaceCreateOrUpdateContent)} is obsolete and not supported.");
        }

        /// <summary> The name of the namespace. </summary>
        public string NamespaceName { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Provisioning state of the Namespace. </summary>
        public string ProvisioningState { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Specifies the targeted region in which the namespace should be created. </summary>
        public string Region { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Identifier for Azure Insights metrics. </summary>
        public string MetricId { get => throw new NotSupportedException(); }
        /// <summary> Status of the namespace. </summary>
        public string Status { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> The time the namespace was created. </summary>
        public DateTimeOffset? CreatedOn { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> The time the namespace was updated. </summary>
        public DateTimeOffset? UpdatedOn { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Endpoint you can use to perform NotificationHub operations. </summary>
        public Uri ServiceBusEndpoint { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> The Id of the Azure subscription associated with the namespace. </summary>
        public string SubscriptionId { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> ScaleUnit where the namespace gets created. </summary>
        public string ScaleUnit { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Whether or not the namespace is currently enabled. </summary>
        public bool? IsEnabled { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Whether or not the namespace is set as Critical. </summary>
        public bool? IsCritical { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Data center for the namespace. </summary>
        public string DataCenter { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> The namespace type. </summary>
        public NotificationHubNamespaceType? NamespaceType { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> The sku of the created namespace. </summary>
        public NotificationHubSku Sku { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
    }
}
