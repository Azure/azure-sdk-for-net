// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.NotificationHubs.Models;

namespace Azure.ResourceManager.NotificationHubs
{
    // Backward-compat: baseline had CreateOrUpdate overloads accepting NotificationHubCreateOrUpdateContent
    // and GetAll overloads with CancellationToken-only parameter.
    public partial class NotificationHubCollection
    {
        /// <summary> Creates/Update a NotificationHub in a namespace. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> or <see cref="WaitUntil.Started"/>. </param>
        /// <param name="notificationHubName"> The notification hub name. </param>
        /// <param name="content"> Parameters supplied to the create/update a NotificationHub Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NotificationHubResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string notificationHubName, NotificationHubCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            var data = ContentToData(content);
            return await CreateOrUpdateAsync(waitUntil, notificationHubName, data, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Creates/Update a NotificationHub in a namespace. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> or <see cref="WaitUntil.Started"/>. </param>
        /// <param name="notificationHubName"> The notification hub name. </param>
        /// <param name="content"> Parameters supplied to the create/update a NotificationHub Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NotificationHubResource> CreateOrUpdate(WaitUntil waitUntil, string notificationHubName, NotificationHubCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            var data = ContentToData(content);
            return CreateOrUpdate(waitUntil, notificationHubName, data, cancellationToken);
        }

        /// <summary> Lists the notification hubs associated with a namespace. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NotificationHubResource> GetAllAsync(CancellationToken cancellationToken)
            => GetAllAsync(null, null, cancellationToken);

        /// <summary> Lists the notification hubs associated with a namespace. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NotificationHubResource> GetAll(CancellationToken cancellationToken)
            => GetAll(null, null, cancellationToken);

        // AuthorizationRules is intentionally not mapped — the generated NotificationHubProperties
        // exposes it as IReadOnlyList<T> (output-only). Auth rules are managed via the
        // AuthorizationRule sub-resource CRUD operations, not via the NotificationHub body.
        private static NotificationHubData ContentToData(NotificationHubCreateOrUpdateContent content)
        {
            var data = new NotificationHubData(content.Location);
            data.Properties = new NotificationHubProperties();
            data.Properties.NotificationHubName = content.NotificationHubName;
            data.Properties.RegistrationTtl = content.RegistrationTtl;
            data.Properties.ApnsCredential = content.ApnsCredential;
            data.Properties.WnsCredential = content.WnsCredential;
            data.Properties.GcmCredential = content.GcmCredential;
            data.Properties.MpnsCredential = content.MpnsCredential;
            data.Properties.AdmCredential = content.AdmCredential;
            data.Properties.BaiduCredential = content.BaiduCredential;
            data.Sku = content.Sku;
            if (content.Tags != null)
            {
                foreach (var tag in content.Tags)
                    data.Tags[tag.Key] = tag.Value;
            }
            return data;
        }
    }
}
