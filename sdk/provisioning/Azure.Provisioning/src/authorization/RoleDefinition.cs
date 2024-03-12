// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Authorization
{
    /// <summary> Role definition. </summary>
    public readonly partial struct RoleDefinition : IEquatable<RoleDefinition>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RoleDefinition"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RoleDefinition(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Storage blob data contributor role.
        /// </summary>
        public static RoleDefinition StorageBlobDataContributor { get; } = new RoleDefinition("ba92f5b4-2d11-453d-a403-e96b0029c9fe");

        /// <summary>
        /// Storage queue data contributor role.
        /// </summary>
        public static RoleDefinition StorageQueueDataContributor { get; } = new RoleDefinition("974c5e8b-45b9-4653-ba55-5f855dd0fb88");

        /// <summary>
        /// Storage table data contributor role.
        /// </summary>
        public static RoleDefinition StorageTableDataContributor { get; } = new RoleDefinition("0a9a7e1f-b9d0-4cc4-a60d-0319b160aaa3");

        /// <summary>
        /// Key Vault administrator role.
        /// </summary>
        public static RoleDefinition KeyVaultAdministrator { get; } = new RoleDefinition("00482a5a-887f-4fb3-b363-3b7fe8e74483");

        /// <summary>
        /// Cognitive Services Open AI contributor role.
        /// </summary>
        public static RoleDefinition CognitiveServicesOpenAIContributor { get; } = new RoleDefinition("a001fd3d-188f-4b5d-821b-7da978bf7442");

        /// <summary>
        /// Service Bus data owner role.
        /// </summary>
        public static RoleDefinition ServiceBusDataOwner { get; } = new RoleDefinition("090c5cfd-751d-490a-894a-3ce6f1109419");

        /// <summary>
        /// Event Hubs data owner role.
        /// </summary>
        public static RoleDefinition EventHubsDataOwner { get; } = new RoleDefinition("f526a384-b230-433a-b45c-95f59c4a2dec");

        /// <summary>
        /// App configuration data owner role.
        /// </summary>
        public static RoleDefinition AppConfigurationDataOwner { get; } = new RoleDefinition("5ae67dd6-50cb-40e7-96ff-dc2bfa4b606b");

        /// <summary>
        /// Search service contributor role.
        /// </summary>
        public static RoleDefinition SearchServiceContributor { get; } = new RoleDefinition("7ca78c08-252a-4471-8644-bb5ff32d4ba0");

        /// <summary>
        /// Search index data contributor role.
        /// </summary>
        public static RoleDefinition SearchIndexDataContributor { get; } = new RoleDefinition("8ebe5a00-799e-43f5-93ac-243d3dce84a7");

        /// <summary>
        /// SignalR App Server role.
        /// </summary>
        public static RoleDefinition SignalRAppServer { get; } = new RoleDefinition("420fcaa2-552c-430f-98ca-3264be4806c7");

        /// <summary> Converts a string to a <see cref="RoleDefinition"/>. </summary>
        public static implicit operator RoleDefinition(string value) => new RoleDefinition(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is RoleDefinition other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RoleDefinition other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
