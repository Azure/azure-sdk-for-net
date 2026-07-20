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
    /// <summary> Parameters supplied to the CreateOrUpdate NotificationHub operation. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NotificationHubCreateOrUpdateContent : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="NotificationHubCreateOrUpdateContent"/>. </summary>
        /// <param name="location"> The location. </param>
        public NotificationHubCreateOrUpdateContent(AzureLocation location) : base(location)
        {
            throw new NotSupportedException($"{nameof(NotificationHubCreateOrUpdateContent)} is obsolete and not supported.");
        }

        /// <summary> The NotificationHub name. </summary>
        public string NotificationHubName { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> The RegistrationTtl of the created NotificationHub. </summary>
        public TimeSpan? RegistrationTtl { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> The AuthorizationRules of the created NotificationHub. </summary>
        public IList<SharedAccessAuthorizationRuleProperties> AuthorizationRules { get => throw new NotSupportedException(); }
        /// <summary> The ApnsCredential of the created NotificationHub. </summary>
        public NotificationHubApnsCredential ApnsCredential { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> The WnsCredential of the created NotificationHub. </summary>
        public NotificationHubWnsCredential WnsCredential { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> The GcmCredential of the created NotificationHub. </summary>
        public NotificationHubGcmCredential GcmCredential { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> The MpnsCredential of the created NotificationHub. </summary>
        public NotificationHubMpnsCredential MpnsCredential { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> The AdmCredential of the created NotificationHub. </summary>
        public NotificationHubAdmCredential AdmCredential { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> The BaiduCredential of the created NotificationHub. </summary>
        public NotificationHubBaiduCredential BaiduCredential { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> The sku of the created namespace. </summary>
        public NotificationHubSku Sku { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
    }
}
