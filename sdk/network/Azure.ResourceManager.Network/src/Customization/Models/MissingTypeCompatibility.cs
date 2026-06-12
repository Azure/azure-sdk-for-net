// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

#pragma warning disable SA1402 // Compatibility shims for multiple removed GA types are grouped intentionally.
namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Geo code for CIDR advertising. </summary>
    public readonly partial struct CidrAdvertisingGeoCode : IEquatable<CidrAdvertisingGeoCode>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CidrAdvertisingGeoCode"/>. </summary>
        /// <param name="value"> The value. </param>
        public CidrAdvertisingGeoCode(string value)
        {
            _value = value;
        }
        /// <summary> AFRI. </summary>
        public static CidrAdvertisingGeoCode Afri { get; } = new CidrAdvertisingGeoCode("AFRI");
        /// <summary> APAC. </summary>
        public static CidrAdvertisingGeoCode Apac { get; } = new CidrAdvertisingGeoCode("APAC");
        /// <summary> AQ. </summary>
        public static CidrAdvertisingGeoCode AQ { get; } = new CidrAdvertisingGeoCode("AQ");
        /// <summary> EURO. </summary>
        public static CidrAdvertisingGeoCode Euro { get; } = new CidrAdvertisingGeoCode("EURO");
        /// <summary> GLOBAL. </summary>
        public static CidrAdvertisingGeoCode Global { get; } = new CidrAdvertisingGeoCode("GLOBAL");
        /// <summary> LATAM. </summary>
        public static CidrAdvertisingGeoCode Latam { get; } = new CidrAdvertisingGeoCode("LATAM");
        /// <summary> ME. </summary>
        public static CidrAdvertisingGeoCode ME { get; } = new CidrAdvertisingGeoCode("ME");
        /// <summary> NAM. </summary>
        public static CidrAdvertisingGeoCode Nam { get; } = new CidrAdvertisingGeoCode("NAM");
        /// <summary> OCEANIA. </summary>
        public static CidrAdvertisingGeoCode Oceania { get; } = new CidrAdvertisingGeoCode("OCEANIA");

        /// <inheritdoc/>
        public bool Equals(CidrAdvertisingGeoCode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is CidrAdvertisingGeoCode other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="CidrAdvertisingGeoCode"/> values for equality. </summary>
        public static bool operator ==(CidrAdvertisingGeoCode left, CidrAdvertisingGeoCode right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="CidrAdvertisingGeoCode"/>. </summary>
        public static implicit operator CidrAdvertisingGeoCode(string value) => new CidrAdvertisingGeoCode(value);
        /// <summary> Compares two <see cref="CidrAdvertisingGeoCode"/> values for inequality. </summary>
        public static bool operator !=(CidrAdvertisingGeoCode left, CidrAdvertisingGeoCode right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }
#pragma warning restore SA1402

    /// <summary> DDoS custom policy trigger sensitivity override. </summary>
    [Obsolete]
    public readonly partial struct DdosCustomPolicyTriggerSensitivityOverride : IEquatable<DdosCustomPolicyTriggerSensitivityOverride>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DdosCustomPolicyTriggerSensitivityOverride"/>. </summary>
        /// <param name="value"> The value. </param>
        public DdosCustomPolicyTriggerSensitivityOverride(string value)
        {
            _value = value;
        }

        /// <summary> Default. </summary>
        public static DdosCustomPolicyTriggerSensitivityOverride Default { get; } = new DdosCustomPolicyTriggerSensitivityOverride("Default");
        /// <summary> High. </summary>
        public static DdosCustomPolicyTriggerSensitivityOverride High { get; } = new DdosCustomPolicyTriggerSensitivityOverride("High");
        /// <summary> Low. </summary>
        public static DdosCustomPolicyTriggerSensitivityOverride Low { get; } = new DdosCustomPolicyTriggerSensitivityOverride("Low");
        /// <summary> Relaxed. </summary>
        public static DdosCustomPolicyTriggerSensitivityOverride Relaxed { get; } = new DdosCustomPolicyTriggerSensitivityOverride("Relaxed");

        /// <inheritdoc/>
        public bool Equals(DdosCustomPolicyTriggerSensitivityOverride other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is DdosCustomPolicyTriggerSensitivityOverride other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="DdosCustomPolicyTriggerSensitivityOverride"/> values for equality. </summary>
        public static bool operator ==(DdosCustomPolicyTriggerSensitivityOverride left, DdosCustomPolicyTriggerSensitivityOverride right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="DdosCustomPolicyTriggerSensitivityOverride"/>. </summary>
        public static implicit operator DdosCustomPolicyTriggerSensitivityOverride(string value) => new DdosCustomPolicyTriggerSensitivityOverride(value);
        /// <summary> Compares two <see cref="DdosCustomPolicyTriggerSensitivityOverride"/> values for inequality. </summary>
        public static bool operator !=(DdosCustomPolicyTriggerSensitivityOverride left, DdosCustomPolicyTriggerSensitivityOverride right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }

    /// <summary> A compatibility type for the former DDoS custom policy protocol settings model. </summary>
    [Obsolete]
    public partial class ProtocolCustomSettings
    {
        /// <summary> Initializes a new instance of <see cref="ProtocolCustomSettings"/>. </summary>
        public ProtocolCustomSettings()
        {
        }

        /// <summary> The protocol. </summary>
        public DdosCustomPolicyProtocol? Protocol { get; set; }

        /// <summary> The source rate override. </summary>
        public string SourceRateOverride { get; set; }

        /// <summary> The trigger rate override. </summary>
        public string TriggerRateOverride { get; set; }

        /// <summary> The trigger sensitivity override. </summary>
        public DdosCustomPolicyTriggerSensitivityOverride? TriggerSensitivityOverride { get; set; }
    }

    /// <summary> Compatibility alias for firewall packet capture request content. </summary>
    public partial class FirewallPacketCaptureRequestContent : FirewallPacketCaptureContent, IJsonModel<FirewallPacketCaptureRequestContent>, IPersistableModel<FirewallPacketCaptureRequestContent>
    {
        /// <summary> Initializes a new instance of <see cref="FirewallPacketCaptureRequestContent"/>. </summary>
        public FirewallPacketCaptureRequestContent()
        {
        }

        FirewallPacketCaptureRequestContent IJsonModel<FirewallPacketCaptureRequestContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new FirewallPacketCaptureRequestContent();
        void IJsonModel<FirewallPacketCaptureRequestContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<FirewallPacketCaptureContent>)this).Write(writer, options);
        FirewallPacketCaptureRequestContent IPersistableModel<FirewallPacketCaptureRequestContent>.Create(BinaryData data, ModelReaderWriterOptions options) => new FirewallPacketCaptureRequestContent();
        string IPersistableModel<FirewallPacketCaptureRequestContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<FirewallPacketCaptureRequestContent>.Write(ModelReaderWriterOptions options) => ((IPersistableModel<FirewallPacketCaptureContent>)this).Write(options);

        /// <summary> Writes the model as JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<FirewallPacketCaptureContent>)this).Write(writer, options);
    }

    /// <summary> Compatibility alias for propagated route table. </summary>
    public partial class PropagatedRouteTable : PropagatedRouteTableNfv, IJsonModel<PropagatedRouteTable>, IPersistableModel<PropagatedRouteTable>
    {
        /// <summary> Initializes a new instance of <see cref="PropagatedRouteTable"/>. </summary>
        public PropagatedRouteTable()
        {
            Ids = new List<WritableSubResource>();
        }

        /// <summary> Route table resource identifiers. </summary>
        [Azure.ResourceManager.Network.WirePath("ids")]
        public new IList<WritableSubResource> Ids { get; }

        PropagatedRouteTable IJsonModel<PropagatedRouteTable>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new PropagatedRouteTable();
        void IJsonModel<PropagatedRouteTable>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<PropagatedRouteTableNfv>)this).Write(writer, options);
        PropagatedRouteTable IPersistableModel<PropagatedRouteTable>.Create(BinaryData data, ModelReaderWriterOptions options) => new PropagatedRouteTable();
        string IPersistableModel<PropagatedRouteTable>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<PropagatedRouteTable>.Write(ModelReaderWriterOptions options) => ((IPersistableModel<PropagatedRouteTableNfv>)this).Write(options);
    }

    /// <summary> Compatibility alias for VPN client parameters. </summary>
    [Obsolete]
    public partial class VpnClientParameters : VpnClientContent
    {
        /// <summary> Initializes a new instance of <see cref="VpnClientParameters"/>. </summary>
        public VpnClientParameters()
        {
        }
    }

    /// <summary> Compatibility alias for VPN packet capture start parameters. </summary>
    [Obsolete]
    public partial class VpnPacketCaptureStartParameters : VpnPacketCaptureStartContent
    {
        /// <summary> Initializes a new instance of <see cref="VpnPacketCaptureStartParameters"/>. </summary>
        public VpnPacketCaptureStartParameters()
        {
        }
    }

    /// <summary> Compatibility alias for VPN packet capture stop parameters. </summary>
    [Obsolete]
    public partial class VpnPacketCaptureStopParameters : VpnPacketCaptureStopContent
    {
        /// <summary> Initializes a new instance of <see cref="VpnPacketCaptureStopParameters"/>. </summary>
        public VpnPacketCaptureStopParameters()
        {
        }
    }

    /// <summary> Compatibility type for connection state snapshots. </summary>
    public partial class ConnectionStateSnapshot : IJsonModel<ConnectionStateSnapshot>, IPersistableModel<ConnectionStateSnapshot>
    {
        /// <summary> Initializes a new instance of <see cref="ConnectionStateSnapshot"/>. </summary>
        public ConnectionStateSnapshot()
        {
            Hops = Array.Empty<ConnectivityHopInfo>();
        }

        /// <summary> Connection state. </summary>
        public NetworkConnectionState? NetworkConnectionState { get; }

        /// <summary> Start time. </summary>
        public DateTimeOffset? StartOn { get; }

        /// <summary> End time. </summary>
        public DateTimeOffset? EndOn { get; }

        /// <summary> Evaluation state. </summary>
        public EvaluationState? EvaluationState { get; }

        /// <summary> Average latency in milliseconds. </summary>
        public long? AvgLatencyInMs { get; }

        /// <summary> Minimum latency in milliseconds. </summary>
        public long? MinLatencyInMs { get; }

        /// <summary> Maximum latency in milliseconds. </summary>
        public long? MaxLatencyInMs { get; }

        /// <summary> Probes sent. </summary>
        public long? ProbesSent { get; }

        /// <summary> Probes failed. </summary>
        public long? ProbesFailed { get; }

        /// <summary> Connectivity hops. </summary>
        public IReadOnlyList<ConnectivityHopInfo> Hops { get; }

        ConnectionStateSnapshot IJsonModel<ConnectionStateSnapshot>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new ConnectionStateSnapshot();
        void IJsonModel<ConnectionStateSnapshot>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
        ConnectionStateSnapshot IPersistableModel<ConnectionStateSnapshot>.Create(BinaryData data, ModelReaderWriterOptions options) => new ConnectionStateSnapshot();
        string IPersistableModel<ConnectionStateSnapshot>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<ConnectionStateSnapshot>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");

        /// <summary> Writes the model as JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
    }

    /// <summary> Compatibility type for connection monitor query results. </summary>
    public partial class ConnectionMonitorQueryResult : IJsonModel<ConnectionMonitorQueryResult>, IPersistableModel<ConnectionMonitorQueryResult>
    {
        /// <summary> Initializes a new instance of <see cref="ConnectionMonitorQueryResult"/>. </summary>
        public ConnectionMonitorQueryResult()
        {
            States = Array.Empty<ConnectionStateSnapshot>();
        }

        /// <summary> Source status. </summary>
        public ConnectionMonitorSourceStatus? SourceStatus { get; }

        /// <summary> Connection state snapshots. </summary>
        public IReadOnlyList<ConnectionStateSnapshot> States { get; }

        ConnectionMonitorQueryResult IJsonModel<ConnectionMonitorQueryResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new ConnectionMonitorQueryResult();
        void IJsonModel<ConnectionMonitorQueryResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
        ConnectionMonitorQueryResult IPersistableModel<ConnectionMonitorQueryResult>.Create(BinaryData data, ModelReaderWriterOptions options) => new ConnectionMonitorQueryResult();
        string IPersistableModel<ConnectionMonitorQueryResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<ConnectionMonitorQueryResult>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");

        /// <summary> Writes the model as JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
    }

    /// <summary> Compatibility type for inbound security rules. </summary>
    public partial class InboundSecurityRule : NetworkResourceData, IJsonModel<InboundSecurityRule>, IPersistableModel<InboundSecurityRule>
    {
        /// <summary> Initializes a new instance of <see cref="InboundSecurityRule"/>. </summary>
        public InboundSecurityRule()
        {
            Rules = new List<InboundSecurityRules>();
        }

        /// <summary> The rule type. </summary>
        public InboundSecurityRuleType? RuleType { get; set; }

        /// <summary> Inbound security rules. </summary>
        public IList<InboundSecurityRules> Rules { get; }

        /// <summary> Provisioning state. </summary>
        public NetworkProvisioningState? ProvisioningState { get; }

        /// <summary> Entity tag. </summary>
        public ETag? ETag { get; }

        /// <summary> Converts the compatibility model to the generated resource data model. </summary>
        public static implicit operator InboundSecurityRuleData(InboundSecurityRule rule) => default;

        InboundSecurityRule IJsonModel<InboundSecurityRule>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new InboundSecurityRule();
        void IJsonModel<InboundSecurityRule>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
        InboundSecurityRule IPersistableModel<InboundSecurityRule>.Create(BinaryData data, ModelReaderWriterOptions options) => new InboundSecurityRule();
        string IPersistableModel<InboundSecurityRule>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<InboundSecurityRule>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");

        /// <summary> Writes the model as JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
    }

    /// <summary> Compatibility type for peer routes. </summary>
    public partial class PeerRoute : IJsonModel<PeerRoute>, IPersistableModel<PeerRoute>
    {
        /// <summary> Initializes a new instance of <see cref="PeerRoute"/>. </summary>
        public PeerRoute()
        {
        }

        /// <summary> The peer route network. </summary>
        [Azure.ResourceManager.Network.WirePath("network")]
        public string Network { get; }

        /// <summary> The next hop. </summary>
        [Azure.ResourceManager.Network.WirePath("nextHop")]
        public string NextHop { get; }

        /// <summary> The source peer. </summary>
        [Azure.ResourceManager.Network.WirePath("sourcePeer")]
        public string SourcePeer { get; }

        /// <summary> The origin. </summary>
        [Azure.ResourceManager.Network.WirePath("origin")]
        public string Origin { get; }

        /// <summary> The AS path. </summary>
        [Azure.ResourceManager.Network.WirePath("asPath")]
        public string AsPath { get; }

        /// <summary> The local address. </summary>
        [Azure.ResourceManager.Network.WirePath("localAddress")]
        public string LocalAddress { get; }

        /// <summary> The route weight. </summary>
        [Azure.ResourceManager.Network.WirePath("weight")]
        public int? Weight { get; }

        PeerRoute IJsonModel<PeerRoute>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new PeerRoute();
        void IJsonModel<PeerRoute>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
        PeerRoute IPersistableModel<PeerRoute>.Create(BinaryData data, ModelReaderWriterOptions options) => new PeerRoute();
        string IPersistableModel<PeerRoute>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<PeerRoute>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");

        /// <summary> Writes the model as JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
    }

    /// <summary> DDoS settings protection coverage. </summary>
    [Obsolete]
    public readonly partial struct DdosSettingsProtectionCoverage : IEquatable<DdosSettingsProtectionCoverage>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DdosSettingsProtectionCoverage"/>. </summary>
        /// <param name="value"> The value. </param>
        public DdosSettingsProtectionCoverage(string value) => _value = value;

        /// <summary> VirtualNetworkInherited. </summary>
        public static DdosSettingsProtectionCoverage VirtualNetworkInherited { get; } = new DdosSettingsProtectionCoverage("VirtualNetworkInherited");
        /// <summary> Enabled. </summary>
        public static DdosSettingsProtectionCoverage Enabled { get; } = new DdosSettingsProtectionCoverage("Enabled");
        /// <summary> Disabled. </summary>
        public static DdosSettingsProtectionCoverage Disabled { get; } = new DdosSettingsProtectionCoverage("Disabled");

        /// <inheritdoc/>
        public bool Equals(DdosSettingsProtectionCoverage other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is DdosSettingsProtectionCoverage other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="DdosSettingsProtectionCoverage"/> values for equality. </summary>
        public static bool operator ==(DdosSettingsProtectionCoverage left, DdosSettingsProtectionCoverage right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="DdosSettingsProtectionCoverage"/>. </summary>
        public static implicit operator DdosSettingsProtectionCoverage(string value) => new DdosSettingsProtectionCoverage(value);
        /// <summary> Compares two <see cref="DdosSettingsProtectionCoverage"/> values for inequality. </summary>
        public static bool operator !=(DdosSettingsProtectionCoverage left, DdosSettingsProtectionCoverage right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }

    /// <summary> Connection monitor source status. </summary>
    public readonly partial struct ConnectionMonitorSourceStatus : IEquatable<ConnectionMonitorSourceStatus>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ConnectionMonitorSourceStatus"/>. </summary>
        /// <param name="value"> The value. </param>
        public ConnectionMonitorSourceStatus(string value) => _value = value;

        /// <inheritdoc/>
        public bool Equals(ConnectionMonitorSourceStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is ConnectionMonitorSourceStatus other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="ConnectionMonitorSourceStatus"/> values for equality. </summary>
        public static bool operator ==(ConnectionMonitorSourceStatus left, ConnectionMonitorSourceStatus right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="ConnectionMonitorSourceStatus"/>. </summary>
        public static implicit operator ConnectionMonitorSourceStatus(string value) => new ConnectionMonitorSourceStatus(value);
        /// <summary> Compares two <see cref="ConnectionMonitorSourceStatus"/> values for inequality. </summary>
        public static bool operator !=(ConnectionMonitorSourceStatus left, ConnectionMonitorSourceStatus right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }

    /// <summary> Network connection state. </summary>
    public readonly partial struct NetworkConnectionState : IEquatable<NetworkConnectionState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="NetworkConnectionState"/>. </summary>
        /// <param name="value"> The value. </param>
        public NetworkConnectionState(string value) => _value = value;

        /// <summary> Reachable. </summary>
        public static NetworkConnectionState Reachable { get; } = new NetworkConnectionState("Reachable");
        /// <summary> Unreachable. </summary>
        public static NetworkConnectionState Unreachable { get; } = new NetworkConnectionState("Unreachable");
        /// <summary> Unknown. </summary>
        public static NetworkConnectionState Unknown { get; } = new NetworkConnectionState("Unknown");

        /// <inheritdoc/>
        public bool Equals(NetworkConnectionState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is NetworkConnectionState other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="NetworkConnectionState"/> values for equality. </summary>
        public static bool operator ==(NetworkConnectionState left, NetworkConnectionState right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="NetworkConnectionState"/>. </summary>
        public static implicit operator NetworkConnectionState(string value) => new NetworkConnectionState(value);
        /// <summary> Compares two <see cref="NetworkConnectionState"/> values for inequality. </summary>
        public static bool operator !=(NetworkConnectionState left, NetworkConnectionState right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }

    /// <summary> Evaluation state. </summary>
    public readonly partial struct EvaluationState : IEquatable<EvaluationState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="EvaluationState"/>. </summary>
        /// <param name="value"> The value. </param>
        public EvaluationState(string value) => _value = value;

        /// <inheritdoc/>
        public bool Equals(EvaluationState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is EvaluationState other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="EvaluationState"/> values for equality. </summary>
        public static bool operator ==(EvaluationState left, EvaluationState right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="EvaluationState"/>. </summary>
        public static implicit operator EvaluationState(string value) => new EvaluationState(value);
        /// <summary> Compares two <see cref="EvaluationState"/> values for inequality. </summary>
        public static bool operator !=(EvaluationState left, EvaluationState right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }

    /// <summary> DDoS settings protection mode. </summary>
    public readonly partial struct DdosSettingsProtectionMode : IEquatable<DdosSettingsProtectionMode>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DdosSettingsProtectionMode"/>. </summary>
        /// <param name="value"> The value. </param>
        public DdosSettingsProtectionMode(string value) => _value = value;

        /// <summary> VirtualNetworkInherited. </summary>
        public static DdosSettingsProtectionMode VirtualNetworkInherited { get; } = new DdosSettingsProtectionMode("VirtualNetworkInherited");
        /// <summary> Enabled. </summary>
        public static DdosSettingsProtectionMode Enabled { get; } = new DdosSettingsProtectionMode("Enabled");
        /// <summary> Disabled. </summary>
        public static DdosSettingsProtectionMode Disabled { get; } = new DdosSettingsProtectionMode("Disabled");

        /// <inheritdoc/>
        public bool Equals(DdosSettingsProtectionMode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is DdosSettingsProtectionMode other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="DdosSettingsProtectionMode"/> values for equality. </summary>
        public static bool operator ==(DdosSettingsProtectionMode left, DdosSettingsProtectionMode right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="DdosSettingsProtectionMode"/>. </summary>
        public static implicit operator DdosSettingsProtectionMode(string value) => new DdosSettingsProtectionMode(value);
        /// <summary> Compares two <see cref="DdosSettingsProtectionMode"/> values for inequality. </summary>
        public static bool operator !=(DdosSettingsProtectionMode left, DdosSettingsProtectionMode right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }

    /// <summary> DDoS traffic type. </summary>
    public readonly partial struct DdosTrafficType : IEquatable<DdosTrafficType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DdosTrafficType"/>. </summary>
        /// <param name="value"> The value. </param>
        public DdosTrafficType(string value) => _value = value;

        /// <summary> Tcp. </summary>
        public static DdosTrafficType Tcp { get; } = new DdosTrafficType("Tcp");
        /// <summary> Udp. </summary>
        public static DdosTrafficType Udp { get; } = new DdosTrafficType("Udp");
        /// <summary> TcpSyn. </summary>
        public static DdosTrafficType TcpSyn { get; } = new DdosTrafficType("TcpSyn");

        /// <inheritdoc/>
        public bool Equals(DdosTrafficType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is DdosTrafficType other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="DdosTrafficType"/> values for equality. </summary>
        public static bool operator ==(DdosTrafficType left, DdosTrafficType right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="DdosTrafficType"/>. </summary>
        public static implicit operator DdosTrafficType(string value) => new DdosTrafficType(value);
        /// <summary> Compares two <see cref="DdosTrafficType"/> values for inequality. </summary>
        public static bool operator !=(DdosTrafficType left, DdosTrafficType right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }

    /// <summary> Type of connection monitor. </summary>
    public readonly partial struct ConnectionMonitorType : IEquatable<ConnectionMonitorType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ConnectionMonitorType"/>. </summary>
        /// <param name="value"> The value. </param>
        public ConnectionMonitorType(string value) => _value = value;

        /// <summary> MultiEndpoint. </summary>
        public static ConnectionMonitorType MultiEndpoint { get; } = new ConnectionMonitorType("MultiEndpoint");
        /// <summary> SingleSourceDestination. </summary>
        public static ConnectionMonitorType SingleSourceDestination { get; } = new ConnectionMonitorType("SingleSourceDestination");

        /// <inheritdoc/>
        public bool Equals(ConnectionMonitorType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is ConnectionMonitorType other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="ConnectionMonitorType"/> values for equality. </summary>
        public static bool operator ==(ConnectionMonitorType left, ConnectionMonitorType right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="ConnectionMonitorType"/>. </summary>
        public static implicit operator ConnectionMonitorType(string value) => new ConnectionMonitorType(value);
        /// <summary> Compares two <see cref="ConnectionMonitorType"/> values for inequality. </summary>
        public static bool operator !=(ConnectionMonitorType left, ConnectionMonitorType right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }

    /// <summary> Firewall policy IDPS query sort order. </summary>
    public readonly partial struct FirewallPolicyIdpsQuerySortOrder : IEquatable<FirewallPolicyIdpsQuerySortOrder>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="FirewallPolicyIdpsQuerySortOrder"/>. </summary>
        /// <param name="value"> The value. </param>
        public FirewallPolicyIdpsQuerySortOrder(string value) => _value = value;

        /// <summary> Ascending. </summary>
        public static FirewallPolicyIdpsQuerySortOrder Ascending { get; } = new FirewallPolicyIdpsQuerySortOrder("Ascending");
        /// <summary> Descending. </summary>
        public static FirewallPolicyIdpsQuerySortOrder Descending { get; } = new FirewallPolicyIdpsQuerySortOrder("Descending");

        /// <inheritdoc/>
        public bool Equals(FirewallPolicyIdpsQuerySortOrder other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is FirewallPolicyIdpsQuerySortOrder other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="FirewallPolicyIdpsQuerySortOrder"/> values for equality. </summary>
        public static bool operator ==(FirewallPolicyIdpsQuerySortOrder left, FirewallPolicyIdpsQuerySortOrder right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="FirewallPolicyIdpsQuerySortOrder"/>. </summary>
        public static implicit operator FirewallPolicyIdpsQuerySortOrder(string value) => new FirewallPolicyIdpsQuerySortOrder(value);
        /// <summary> Compares two <see cref="FirewallPolicyIdpsQuerySortOrder"/> values for inequality. </summary>
        public static bool operator !=(FirewallPolicyIdpsQuerySortOrder left, FirewallPolicyIdpsQuerySortOrder right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }

    /// <summary> Firewall policy IDPS signature direction. </summary>
    public enum FirewallPolicyIdpsSignatureDirection
    {
        /// <summary> Zero. </summary>
        Zero = 0,
        /// <summary> One. </summary>
        One = 1,
        /// <summary> Two. </summary>
        Two = 2,
        /// <summary> Three. </summary>
        Three = 3,
        /// <summary> Four. </summary>
        Four = 4,
        /// <summary> Five. </summary>
        Five = 5,
    }

    /// <summary> Firewall policy IDPS signature mode. </summary>
    public enum FirewallPolicyIdpsSignatureMode
    {
        /// <summary> Zero. </summary>
        Zero = 0,
        /// <summary> One. </summary>
        One = 1,
        /// <summary> Two. </summary>
        Two = 2,
    }

    /// <summary> Firewall policy IDPS signature severity. </summary>
    public enum FirewallPolicyIdpsSignatureSeverity
    {
        /// <summary> One. </summary>
        One = 1,
        /// <summary> Two. </summary>
        Two = 2,
        /// <summary> Three. </summary>
        Three = 3,
    }

    internal static partial class NetworkModelCompatibilityExtensions
    {
        public static FirewallPolicyIdpsSignatureMode ToFirewallPolicyIdpsSignatureMode(this int value) => (FirewallPolicyIdpsSignatureMode)value;
        public static FirewallPolicyIdpsSignatureSeverity ToFirewallPolicyIdpsSignatureSeverity(this int value) => (FirewallPolicyIdpsSignatureSeverity)value;
        public static FirewallPolicyIdpsSignatureDirection ToFirewallPolicyIdpsSignatureDirection(this int value) => (FirewallPolicyIdpsSignatureDirection)value;
    }

    /// <summary> A compatibility type for the former undo reservation values. </summary>
    public readonly partial struct UndoReservationType : IEquatable<UndoReservationType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="UndoReservationType"/>. </summary>
        /// <param name="value"> The value. </param>
        public UndoReservationType(string value)
        {
            _value = value;
        }

        /// <summary> False. </summary>
        public static UndoReservationType False { get; } = new UndoReservationType("False");

        /// <summary> True. </summary>
        public static UndoReservationType True { get; } = new UndoReservationType("True");

        /// <inheritdoc/>
        public bool Equals(UndoReservationType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is UndoReservationType other && Equals(other);

        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <summary> Compares two <see cref="UndoReservationType"/> values for equality. </summary>
        public static bool operator ==(UndoReservationType left, UndoReservationType right) => left.Equals(right);

        /// <summary> Converts a string to a <see cref="UndoReservationType"/>. </summary>
        public static implicit operator UndoReservationType(string value) => new UndoReservationType(value);

        /// <summary> Compares two <see cref="UndoReservationType"/> values for inequality. </summary>
        public static bool operator !=(UndoReservationType left, UndoReservationType right) => !left.Equals(right);

        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }
}
