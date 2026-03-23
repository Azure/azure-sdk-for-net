// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: this type was removed in the TypeSpec migration.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AlertsManagement.Models;

namespace Azure.ResourceManager.AlertsManagement
{
    /// <summary> Backward compatibility stub. This type is no longer supported. </summary>
    [Obsolete("This type is no longer supported.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ServiceAlertResource : ArmResource, IJsonModel<ServiceAlertData>, IPersistableModel<ServiceAlertData>
    {
        /// <summary> The resource type. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.AlertsManagement/alerts";

        /// <summary> Initializes a new instance for mocking. </summary>
        protected ServiceAlertResource() { }

        /// <summary> Gets the data. </summary>
        public virtual ServiceAlertData Data { get { throw new NotSupportedException(); } }

        /// <summary> Gets whether the resource has data. </summary>
        public virtual bool HasData { get { throw new NotSupportedException(); } }

        /// <summary> Creates a resource identifier. </summary>
        /// <param name="subscriptionId"> The subscription ID. </param>
        /// <param name="alertId"> The alert ID. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Guid alertId) { throw new NotSupportedException(); }

        /// <summary> Changes the state. </summary>
        /// <param name="newState"> The new state. </param>
        /// <param name="comment"> The comment. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<ServiceAlertResource> ChangeState(ServiceAlertState newState, string comment = null, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Changes the state async. </summary>
        /// <param name="newState"> The new state. </param>
        /// <param name="comment"> The comment. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Task<Response<ServiceAlertResource>> ChangeStateAsync(ServiceAlertState newState, string comment = null, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets the resource. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<ServiceAlertResource> Get(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets the resource async. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Task<Response<ServiceAlertResource>> GetAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets the history. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<ServiceAlertModification> GetHistory(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets the history async. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Task<Response<ServiceAlertModification>> GetHistoryAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Creates from JSON. </summary>
        ServiceAlertData IJsonModel<ServiceAlertData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to JSON. </summary>
        void IJsonModel<ServiceAlertData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Creates from BinaryData. </summary>
        ServiceAlertData IPersistableModel<ServiceAlertData>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Gets format. </summary>
        string IPersistableModel<ServiceAlertData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to BinaryData. </summary>
        BinaryData IPersistableModel<ServiceAlertData>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
    }
}
