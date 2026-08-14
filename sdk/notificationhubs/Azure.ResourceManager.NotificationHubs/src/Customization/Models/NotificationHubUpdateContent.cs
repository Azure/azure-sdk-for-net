// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// This model has been deleted from the TypeSpec spec. It is kept here only for backward
// API compatibility (ApiCompat). All public APIs throw NotSupportedException.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.NotificationHubs.Models
{
    /// <summary> Patch parameter for NamespaceResource. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NotificationHubUpdateContent
    {
        /// <summary> Initializes a new instance of <see cref="NotificationHubUpdateContent"/>. </summary>
        public NotificationHubUpdateContent()
        {
            throw new NotSupportedException($"{nameof(NotificationHubUpdateContent)} is obsolete and not supported.");
        }

        /// <summary> The Sku description for a namespace. </summary>
        public NotificationHubSku Sku { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Dictionary of &lt;string&gt;. </summary>
        public IDictionary<string, string> Tags { get => throw new NotSupportedException(); }
        /// <summary> Gets or sets the NotificationHub name. </summary>
        public string NotificationHubName { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Gets or sets the RegistrationTtl of the created NotificationHub. </summary>
        public TimeSpan? RegistrationTtl { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Gets or sets the AuthorizationRules of the created NotificationHub. </summary>
        public IList<SharedAccessAuthorizationRuleProperties> AuthorizationRules { get => throw new NotSupportedException(); }
        /// <summary> Description of a NotificationHub ApnsCredential. </summary>
        public NotificationHubApnsCredential ApnsCredential { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Description of a NotificationHub WnsCredential. </summary>
        public NotificationHubWnsCredential WnsCredential { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Description of a NotificationHub GcmCredential. </summary>
        public NotificationHubGcmCredential GcmCredential { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Description of a NotificationHub MpnsCredential. </summary>
        public NotificationHubMpnsCredential MpnsCredential { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Description of a NotificationHub AdmCredential. </summary>
        public NotificationHubAdmCredential AdmCredential { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Description of a NotificationHub BaiduCredential. </summary>
        public NotificationHubBaiduCredential BaiduCredential { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Description of a NotificationHub BrowserCredential. </summary>
        public BrowserCredential BrowserCredential { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Description of a NotificationHub XiaomiCredential. </summary>
        public XiaomiCredential XiaomiCredential { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Description of a NotificationHub FcmV1Credential. </summary>
        public FcmV1Credential FcmV1Credential { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Gets the daily max active devices. </summary>
        public long? DailyMaxActiveDevices { get => throw new NotSupportedException(); }
    }
}
