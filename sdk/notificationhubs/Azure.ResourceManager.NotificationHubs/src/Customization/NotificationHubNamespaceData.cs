// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NotificationHubs.Models;

namespace Azure.ResourceManager.NotificationHubs
{
    /// <summary>
    /// A class representing the NotificationHubNamespace data model.
    /// Description of a Namespace resource.
    /// </summary>
    public partial class NotificationHubNamespaceData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="NotificationHubNamespaceData"/>. </summary>
        /// <param name="location"> The location. </param>
        public NotificationHubNamespaceData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Provisioning state of the Namespace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProvisioningState
        {
            get => OperationProvisioningState.ToString();
            set => OperationProvisioningState = string.IsNullOrEmpty(value) ? null : new OperationProvisioningState(value);
        }
        /// <summary> Status of the namespace. It can be any of these values:1 = Created/Active2 = Creating3 = Suspended4 = Deleting. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Status
        {
            get => NamespaceStatus.ToString();
            set => NamespaceStatus = string.IsNullOrEmpty(value) ? null : new NotificationHubNamespaceStatus(value);
        }
        /// <summary> The namespace type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NotificationHubNamespaceType? NamespaceType
        {
            get => HubNamespaceType.ToString().ToNotificationHubNamespaceType();
            set => HubNamespaceType = new NotificationHubNamespaceTypeExt(value.ToString());
        }
    }
}
