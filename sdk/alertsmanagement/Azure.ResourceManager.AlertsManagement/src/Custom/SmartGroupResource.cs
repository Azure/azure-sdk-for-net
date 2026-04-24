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
    /// <summary> Backward compatibility stub. The SmartGroup types have been removed from this package and will be shipped in a separate package in a future release. </summary>
    [Obsolete("The SmartGroup types have been removed from this package and will be shipped in a separate package in a future release.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SmartGroupResource : ArmResource, IJsonModel<SmartGroupData>, IPersistableModel<SmartGroupData>
    {
        /// <summary> The resource type. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.AlertsManagement/smartGroups";

        /// <summary> Initializes a new instance for mocking. </summary>
        protected SmartGroupResource() { }

        /// <summary> Gets the data. </summary>
        public virtual SmartGroupData Data { get { throw new NotSupportedException(); } }

        /// <summary> Gets whether the resource has data. </summary>
        public virtual bool HasData { get { throw new NotSupportedException(); } }

        /// <summary> Creates a resource identifier. </summary>
        /// <param name="subscriptionId"> The subscription ID. </param>
        /// <param name="smartGroupId"> The smart group ID. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Guid smartGroupId) { throw new NotSupportedException(); }

        /// <summary> Changes the state. </summary>
        /// <param name="newState"> The new state. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<SmartGroupResource> ChangeState(ServiceAlertState newState, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Changes the state async. </summary>
        /// <param name="newState"> The new state. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Task<Response<SmartGroupResource>> ChangeStateAsync(ServiceAlertState newState, CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets the resource. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<SmartGroupResource> Get(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets the resource async. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Task<Response<SmartGroupResource>> GetAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets the history. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<SmartGroupModification> GetHistory(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Gets the history async. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Task<Response<SmartGroupModification>> GetHistoryAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(); }

        /// <summary> Creates from JSON. </summary>
        SmartGroupData IJsonModel<SmartGroupData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to JSON. </summary>
        void IJsonModel<SmartGroupData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Creates from BinaryData. </summary>
        SmartGroupData IPersistableModel<SmartGroupData>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Gets format. </summary>
        string IPersistableModel<SmartGroupData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
        /// <summary> Writes to BinaryData. </summary>
        BinaryData IPersistableModel<SmartGroupData>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException(); }
    }
}
