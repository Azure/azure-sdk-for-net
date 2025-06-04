// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.NotificationHubs.Models
{
    /// <summary> Patch parameter for NamespaceResource. </summary>
    public partial class NotificationHubUpdateContent
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="NotificationHubUpdateContent"/>. </summary>
        public NotificationHubUpdateContent()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
            AuthorizationRules = new ChangeTrackingList<SharedAccessAuthorizationRuleProperties>();
        }

        /// <summary> Initializes a new instance of <see cref="NotificationHubUpdateContent"/>. </summary>
        /// <param name="sku"> The Sku description for a namespace. </param>
        /// <param name="tags"> Dictionary of &lt;string&gt;. </param>
        /// <param name="notificationHubName"> Gets or sets the NotificationHub name. </param>
        /// <param name="registrationTtl"> Gets or sets the RegistrationTtl of the created NotificationHub. </param>
        /// <param name="authorizationRules"> Gets or sets the AuthorizationRules of the created NotificationHub. </param>
        /// <param name="apnsCredential"> Description of a NotificationHub ApnsCredential. </param>
        /// <param name="wnsCredential"> Description of a NotificationHub WnsCredential. </param>
        /// <param name="gcmCredential"> Description of a NotificationHub GcmCredential. </param>
        /// <param name="mpnsCredential"> Description of a NotificationHub MpnsCredential. </param>
        /// <param name="admCredential"> Description of a NotificationHub AdmCredential. </param>
        /// <param name="baiduCredential"> Description of a NotificationHub BaiduCredential. </param>
        /// <param name="browserCredential"> Description of a NotificationHub BrowserCredential. </param>
        /// <param name="xiaomiCredential"> Description of a NotificationHub XiaomiCredential. </param>
        /// <param name="fcmV1Credential"> Description of a NotificationHub FcmV1Credential. </param>
        /// <param name="dailyMaxActiveDevices"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal NotificationHubUpdateContent(NotificationHubSku sku, IDictionary<string, string> tags, string notificationHubName, TimeSpan? registrationTtl, IList<SharedAccessAuthorizationRuleProperties> authorizationRules, NotificationHubApnsCredential apnsCredential, NotificationHubWnsCredential wnsCredential, NotificationHubGcmCredential gcmCredential, NotificationHubMpnsCredential mpnsCredential, NotificationHubAdmCredential admCredential, NotificationHubBaiduCredential baiduCredential, BrowserCredential browserCredential, XiaomiCredential xiaomiCredential, FcmV1Credential fcmV1Credential, long? dailyMaxActiveDevices, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Sku = sku;
            Tags = tags;
            NotificationHubName = notificationHubName;
            RegistrationTtl = registrationTtl;
            AuthorizationRules = authorizationRules;
            ApnsCredential = apnsCredential;
            WnsCredential = wnsCredential;
            GcmCredential = gcmCredential;
            MpnsCredential = mpnsCredential;
            AdmCredential = admCredential;
            BaiduCredential = baiduCredential;
            BrowserCredential = browserCredential;
            XiaomiCredential = xiaomiCredential;
            FcmV1Credential = fcmV1Credential;
            DailyMaxActiveDevices = dailyMaxActiveDevices;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The Sku description for a namespace. </summary>
        public NotificationHubSku Sku { get; set; }
        /// <summary> Dictionary of &lt;string&gt;. </summary>
        public IDictionary<string, string> Tags { get; }
        /// <summary> Gets or sets the NotificationHub name. </summary>
        public string NotificationHubName { get; set; }
        /// <summary> Gets or sets the RegistrationTtl of the created NotificationHub. </summary>
        public TimeSpan? RegistrationTtl { get; set; }
        /// <summary> Gets or sets the AuthorizationRules of the created NotificationHub. </summary>
        public IList<SharedAccessAuthorizationRuleProperties> AuthorizationRules { get; }
        /// <summary> Description of a NotificationHub ApnsCredential. </summary>
        public NotificationHubApnsCredential ApnsCredential { get; set; }
        /// <summary> Description of a NotificationHub WnsCredential. </summary>
        public NotificationHubWnsCredential WnsCredential { get; set; }
        /// <summary> Description of a NotificationHub GcmCredential. </summary>
        public NotificationHubGcmCredential GcmCredential { get; set; }
        /// <summary> Description of a NotificationHub MpnsCredential. </summary>
        public NotificationHubMpnsCredential MpnsCredential { get; set; }
        /// <summary> Description of a NotificationHub AdmCredential. </summary>
        public NotificationHubAdmCredential AdmCredential { get; set; }
        /// <summary> Description of a NotificationHub BaiduCredential. </summary>
        public NotificationHubBaiduCredential BaiduCredential { get; set; }
        /// <summary> Description of a NotificationHub BrowserCredential. </summary>
        public BrowserCredential BrowserCredential { get; set; }
        /// <summary> Description of a NotificationHub XiaomiCredential. </summary>
        public XiaomiCredential XiaomiCredential { get; set; }
        /// <summary> Description of a NotificationHub FcmV1Credential. </summary>
        public FcmV1Credential FcmV1Credential { get; set; }
        /// <summary> Gets the daily max active devices. </summary>
        public long? DailyMaxActiveDevices { get; }
    }
}
