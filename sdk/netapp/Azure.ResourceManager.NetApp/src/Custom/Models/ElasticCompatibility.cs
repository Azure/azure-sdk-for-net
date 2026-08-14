// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402
#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    public readonly partial struct DayOfWeek : IEquatable<DayOfWeek>
    {
        private readonly string _value;
        public DayOfWeek(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static implicit operator DayOfWeek(string value) => new DayOfWeek(value);
        public static implicit operator DayOfWeek?(string value) => value == null ? null : new DayOfWeek(value);
        public static bool operator ==(DayOfWeek left, DayOfWeek right) => left.Equals(right);
        public static bool operator !=(DayOfWeek left, DayOfWeek right) => !left.Equals(right);
        public bool Equals(DayOfWeek other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is DayOfWeek other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct ElasticBackupPolicyState : IEquatable<ElasticBackupPolicyState>
    {
        private readonly string _value;
        public ElasticBackupPolicyState(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static implicit operator ElasticBackupPolicyState(string value) => new ElasticBackupPolicyState(value);
        public static implicit operator ElasticBackupPolicyState?(string value) => value == null ? null : new ElasticBackupPolicyState(value);
        public static bool operator ==(ElasticBackupPolicyState left, ElasticBackupPolicyState right) => left.Equals(right);
        public static bool operator !=(ElasticBackupPolicyState left, ElasticBackupPolicyState right) => !left.Equals(right);
        public bool Equals(ElasticBackupPolicyState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is ElasticBackupPolicyState other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct ElasticBackupSnapshotUsage : IEquatable<ElasticBackupSnapshotUsage>
    {
        private readonly string _value;
        public ElasticBackupSnapshotUsage(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static implicit operator ElasticBackupSnapshotUsage(string value) => new ElasticBackupSnapshotUsage(value);
        public static implicit operator ElasticBackupSnapshotUsage?(string value) => value == null ? null : new ElasticBackupSnapshotUsage(value);
        public static bool operator ==(ElasticBackupSnapshotUsage left, ElasticBackupSnapshotUsage right) => left.Equals(right);
        public static bool operator !=(ElasticBackupSnapshotUsage left, ElasticBackupSnapshotUsage right) => !left.Equals(right);
        public bool Equals(ElasticBackupSnapshotUsage other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is ElasticBackupSnapshotUsage other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct ElasticBackupType : IEquatable<ElasticBackupType>
    {
        private readonly string _value;
        public ElasticBackupType(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static implicit operator ElasticBackupType(string value) => new ElasticBackupType(value);
        public static implicit operator ElasticBackupType?(string value) => value == null ? null : new ElasticBackupType(value);
        public static bool operator ==(ElasticBackupType left, ElasticBackupType right) => left.Equals(right);
        public static bool operator !=(ElasticBackupType left, ElasticBackupType right) => !left.Equals(right);
        public bool Equals(ElasticBackupType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is ElasticBackupType other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct ElasticBackupVolumeSize : IEquatable<ElasticBackupVolumeSize>
    {
        private readonly string _value;
        public ElasticBackupVolumeSize(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static implicit operator ElasticBackupVolumeSize(string value) => new ElasticBackupVolumeSize(value);
        public static implicit operator ElasticBackupVolumeSize?(string value) => value == null ? null : new ElasticBackupVolumeSize(value);
        public static bool operator ==(ElasticBackupVolumeSize left, ElasticBackupVolumeSize right) => left.Equals(right);
        public static bool operator !=(ElasticBackupVolumeSize left, ElasticBackupVolumeSize right) => !left.Equals(right);
        public bool Equals(ElasticBackupVolumeSize other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is ElasticBackupVolumeSize other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct ElasticKeyVaultStatus : IEquatable<ElasticKeyVaultStatus>
    {
        private readonly string _value;
        public ElasticKeyVaultStatus(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static implicit operator ElasticKeyVaultStatus(string value) => new ElasticKeyVaultStatus(value);
        public static implicit operator ElasticKeyVaultStatus?(string value) => value == null ? null : new ElasticKeyVaultStatus(value);
        public static bool operator ==(ElasticKeyVaultStatus left, ElasticKeyVaultStatus right) => left.Equals(right);
        public static bool operator !=(ElasticKeyVaultStatus left, ElasticKeyVaultStatus right) => !left.Equals(right);
        public bool Equals(ElasticKeyVaultStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is ElasticKeyVaultStatus other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct ElasticNfsv3Access : IEquatable<ElasticNfsv3Access>
    {
        private readonly string _value;
        public ElasticNfsv3Access(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static implicit operator ElasticNfsv3Access(string value) => new ElasticNfsv3Access(value);
        public static implicit operator ElasticNfsv3Access?(string value) => value == null ? null : new ElasticNfsv3Access(value);
        public static bool operator ==(ElasticNfsv3Access left, ElasticNfsv3Access right) => left.Equals(right);
        public static bool operator !=(ElasticNfsv3Access left, ElasticNfsv3Access right) => !left.Equals(right);
        public bool Equals(ElasticNfsv3Access other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is ElasticNfsv3Access other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct ElasticNfsv4Access : IEquatable<ElasticNfsv4Access>
    {
        private readonly string _value;
        public ElasticNfsv4Access(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static implicit operator ElasticNfsv4Access(string value) => new ElasticNfsv4Access(value);
        public static implicit operator ElasticNfsv4Access?(string value) => value == null ? null : new ElasticNfsv4Access(value);
        public static bool operator ==(ElasticNfsv4Access left, ElasticNfsv4Access right) => left.Equals(right);
        public static bool operator !=(ElasticNfsv4Access left, ElasticNfsv4Access right) => !left.Equals(right);
        public bool Equals(ElasticNfsv4Access other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is ElasticNfsv4Access other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct ElasticPoolEncryptionKeySource : IEquatable<ElasticPoolEncryptionKeySource>
    {
        private readonly string _value;
        public ElasticPoolEncryptionKeySource(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static implicit operator ElasticPoolEncryptionKeySource(string value) => new ElasticPoolEncryptionKeySource(value);
        public static bool operator ==(ElasticPoolEncryptionKeySource left, ElasticPoolEncryptionKeySource right) => left.Equals(right);
        public static bool operator !=(ElasticPoolEncryptionKeySource left, ElasticPoolEncryptionKeySource right) => !left.Equals(right);
        public bool Equals(ElasticPoolEncryptionKeySource other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is ElasticPoolEncryptionKeySource other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct ElasticProtocolType : IEquatable<ElasticProtocolType>
    {
        private readonly string _value;
        public ElasticProtocolType(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static implicit operator ElasticProtocolType(string value) => new ElasticProtocolType(value);
        public static implicit operator ElasticProtocolType?(string value) => value == null ? null : new ElasticProtocolType(value);
        public static bool operator ==(ElasticProtocolType left, ElasticProtocolType right) => left.Equals(right);
        public static bool operator !=(ElasticProtocolType left, ElasticProtocolType right) => !left.Equals(right);
        public bool Equals(ElasticProtocolType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is ElasticProtocolType other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct ElasticResourceAvailabilityStatus : IEquatable<ElasticResourceAvailabilityStatus>
    {
        private readonly string _value;
        public ElasticResourceAvailabilityStatus(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static implicit operator ElasticResourceAvailabilityStatus(string value) => new ElasticResourceAvailabilityStatus(value);
        public static implicit operator ElasticResourceAvailabilityStatus?(string value) => value == null ? null : new ElasticResourceAvailabilityStatus(value);
        public static bool operator ==(ElasticResourceAvailabilityStatus left, ElasticResourceAvailabilityStatus right) => left.Equals(right);
        public static bool operator !=(ElasticResourceAvailabilityStatus left, ElasticResourceAvailabilityStatus right) => !left.Equals(right);
        public bool Equals(ElasticResourceAvailabilityStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is ElasticResourceAvailabilityStatus other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct ElasticRootAccess : IEquatable<ElasticRootAccess>
    {
        private readonly string _value;
        public ElasticRootAccess(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static implicit operator ElasticRootAccess(string value) => new ElasticRootAccess(value);
        public static implicit operator ElasticRootAccess?(string value) => value == null ? null : new ElasticRootAccess(value);
        public static bool operator ==(ElasticRootAccess left, ElasticRootAccess right) => left.Equals(right);
        public static bool operator !=(ElasticRootAccess left, ElasticRootAccess right) => !left.Equals(right);
        public bool Equals(ElasticRootAccess other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is ElasticRootAccess other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct ElasticServiceLevel : IEquatable<ElasticServiceLevel>
    {
        private readonly string _value;
        public ElasticServiceLevel(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static implicit operator ElasticServiceLevel(string value) => new ElasticServiceLevel(value);
        public static implicit operator ElasticServiceLevel?(string value) => value == null ? null : new ElasticServiceLevel(value);
        public static bool operator ==(ElasticServiceLevel left, ElasticServiceLevel right) => left.Equals(right);
        public static bool operator !=(ElasticServiceLevel left, ElasticServiceLevel right) => !left.Equals(right);
        public bool Equals(ElasticServiceLevel other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is ElasticServiceLevel other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct ElasticSmbEncryption : IEquatable<ElasticSmbEncryption>
    {
        private readonly string _value;
        public ElasticSmbEncryption(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static implicit operator ElasticSmbEncryption(string value) => new ElasticSmbEncryption(value);
        public static implicit operator ElasticSmbEncryption?(string value) => value == null ? null : new ElasticSmbEncryption(value);
        public static bool operator ==(ElasticSmbEncryption left, ElasticSmbEncryption right) => left.Equals(right);
        public static bool operator !=(ElasticSmbEncryption left, ElasticSmbEncryption right) => !left.Equals(right);
        public bool Equals(ElasticSmbEncryption other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is ElasticSmbEncryption other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct ElasticSnapshotPolicyStatus : IEquatable<ElasticSnapshotPolicyStatus>
    {
        private readonly string _value;
        public ElasticSnapshotPolicyStatus(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static implicit operator ElasticSnapshotPolicyStatus(string value) => new ElasticSnapshotPolicyStatus(value);
        public static implicit operator ElasticSnapshotPolicyStatus?(string value) => value == null ? null : new ElasticSnapshotPolicyStatus(value);
        public static bool operator ==(ElasticSnapshotPolicyStatus left, ElasticSnapshotPolicyStatus right) => left.Equals(right);
        public static bool operator !=(ElasticSnapshotPolicyStatus left, ElasticSnapshotPolicyStatus right) => !left.Equals(right);
        public bool Equals(ElasticSnapshotPolicyStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is ElasticSnapshotPolicyStatus other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct ElasticUnixAccessRule : IEquatable<ElasticUnixAccessRule>
    {
        private readonly string _value;
        public ElasticUnixAccessRule(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static implicit operator ElasticUnixAccessRule(string value) => new ElasticUnixAccessRule(value);
        public static implicit operator ElasticUnixAccessRule?(string value) => value == null ? null : new ElasticUnixAccessRule(value);
        public static bool operator ==(ElasticUnixAccessRule left, ElasticUnixAccessRule right) => left.Equals(right);
        public static bool operator !=(ElasticUnixAccessRule left, ElasticUnixAccessRule right) => !left.Equals(right);
        public bool Equals(ElasticUnixAccessRule other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is ElasticUnixAccessRule other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct ElasticVolumePolicyEnforcement : IEquatable<ElasticVolumePolicyEnforcement>
    {
        private readonly string _value;
        public ElasticVolumePolicyEnforcement(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static implicit operator ElasticVolumePolicyEnforcement(string value) => new ElasticVolumePolicyEnforcement(value);
        public static implicit operator ElasticVolumePolicyEnforcement?(string value) => value == null ? null : new ElasticVolumePolicyEnforcement(value);
        public static bool operator ==(ElasticVolumePolicyEnforcement left, ElasticVolumePolicyEnforcement right) => left.Equals(right);
        public static bool operator !=(ElasticVolumePolicyEnforcement left, ElasticVolumePolicyEnforcement right) => !left.Equals(right);
        public bool Equals(ElasticVolumePolicyEnforcement other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is ElasticVolumePolicyEnforcement other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct ElasticVolumeRestorationState : IEquatable<ElasticVolumeRestorationState>
    {
        private readonly string _value;
        public ElasticVolumeRestorationState(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static implicit operator ElasticVolumeRestorationState(string value) => new ElasticVolumeRestorationState(value);
        public static implicit operator ElasticVolumeRestorationState?(string value) => value == null ? null : new ElasticVolumeRestorationState(value);
        public static bool operator ==(ElasticVolumeRestorationState left, ElasticVolumeRestorationState right) => left.Equals(right);
        public static bool operator !=(ElasticVolumeRestorationState left, ElasticVolumeRestorationState right) => !left.Equals(right);
        public bool Equals(ElasticVolumeRestorationState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is ElasticVolumeRestorationState other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct SnapshotDirectoryVisibility : IEquatable<SnapshotDirectoryVisibility>
    {
        private readonly string _value;
        public SnapshotDirectoryVisibility(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static implicit operator SnapshotDirectoryVisibility(string value) => new SnapshotDirectoryVisibility(value);
        public static implicit operator SnapshotDirectoryVisibility?(string value) => value == null ? null : new SnapshotDirectoryVisibility(value);
        public static bool operator ==(SnapshotDirectoryVisibility left, SnapshotDirectoryVisibility right) => left.Equals(right);
        public static bool operator !=(SnapshotDirectoryVisibility left, SnapshotDirectoryVisibility right) => !left.Equals(right);
        public bool Equals(SnapshotDirectoryVisibility other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is SnapshotDirectoryVisibility other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct CheckElasticResourceAvailabilityStatus : IEquatable<CheckElasticResourceAvailabilityStatus>
    {
        private readonly string _value;
        public CheckElasticResourceAvailabilityStatus(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static CheckElasticResourceAvailabilityStatus True { get; } = new CheckElasticResourceAvailabilityStatus("True");
        public static CheckElasticResourceAvailabilityStatus False { get; } = new CheckElasticResourceAvailabilityStatus("False");
        public static implicit operator CheckElasticResourceAvailabilityStatus(string value) => new CheckElasticResourceAvailabilityStatus(value);
        public static implicit operator CheckElasticResourceAvailabilityStatus?(string value) => value == null ? null : new CheckElasticResourceAvailabilityStatus(value);
        public static bool operator ==(CheckElasticResourceAvailabilityStatus left, CheckElasticResourceAvailabilityStatus right) => left.Equals(right);
        public static bool operator !=(CheckElasticResourceAvailabilityStatus left, CheckElasticResourceAvailabilityStatus right) => !left.Equals(right);
        public bool Equals(CheckElasticResourceAvailabilityStatus other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is CheckElasticResourceAvailabilityStatus other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct CheckElasticResourceAvailabilityReason : IEquatable<CheckElasticResourceAvailabilityReason>
    {
        private readonly string _value;
        public CheckElasticResourceAvailabilityReason(string value) { Argument.AssertNotNull(value, nameof(value)); _value = value; }
        public static CheckElasticResourceAvailabilityReason AlreadyExists { get; } = new CheckElasticResourceAvailabilityReason("AlreadyExists");
        public static CheckElasticResourceAvailabilityReason Invalid { get; } = new CheckElasticResourceAvailabilityReason("Invalid");
        public static implicit operator CheckElasticResourceAvailabilityReason(string value) => new CheckElasticResourceAvailabilityReason(value);
        public static implicit operator CheckElasticResourceAvailabilityReason?(string value) => value == null ? null : new CheckElasticResourceAvailabilityReason(value);
        public static bool operator ==(CheckElasticResourceAvailabilityReason left, CheckElasticResourceAvailabilityReason right) => left.Equals(right);
        public static bool operator !=(CheckElasticResourceAvailabilityReason left, CheckElasticResourceAvailabilityReason right) => !left.Equals(right);
        public bool Equals(CheckElasticResourceAvailabilityReason other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is CheckElasticResourceAvailabilityReason other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }

    public readonly partial struct ElasticKeyVaultStatus
    {
        public static ElasticKeyVaultStatus Created { get; } = new ElasticKeyVaultStatus("Created");
        public static ElasticKeyVaultStatus Deleted { get; } = new ElasticKeyVaultStatus("Deleted");
        public static ElasticKeyVaultStatus Error { get; } = new ElasticKeyVaultStatus("Error");
        public static ElasticKeyVaultStatus InUse { get; } = new ElasticKeyVaultStatus("InUse");
        public static ElasticKeyVaultStatus Updating { get; } = new ElasticKeyVaultStatus("Updating");
    }

    public readonly partial struct ElasticNfsv3Access
    {
        public static ElasticNfsv3Access Disabled { get; } = new ElasticNfsv3Access("Disabled");
        public static ElasticNfsv3Access Enabled { get; } = new ElasticNfsv3Access("Enabled");
    }

    public readonly partial struct ElasticNfsv4Access
    {
        public static ElasticNfsv4Access Disabled { get; } = new ElasticNfsv4Access("Disabled");
        public static ElasticNfsv4Access Enabled { get; } = new ElasticNfsv4Access("Enabled");
    }

    public readonly partial struct ElasticPoolEncryptionKeySource
    {
        public static ElasticPoolEncryptionKeySource KeyVault { get; } = new ElasticPoolEncryptionKeySource("KeyVault");
        public static ElasticPoolEncryptionKeySource NetApp { get; } = new ElasticPoolEncryptionKeySource("NetApp");
        public static implicit operator ElasticPoolEncryptionKeySource?(string value) => value == null ? null : new ElasticPoolEncryptionKeySource(value);
    }

    public readonly partial struct ElasticProtocolType
    {
        public static ElasticProtocolType Nfsv3 { get; } = new ElasticProtocolType("Nfsv3");
        public static ElasticProtocolType Nfsv4 { get; } = new ElasticProtocolType("Nfsv4");
        public static ElasticProtocolType SMB { get; } = new ElasticProtocolType("SMB");
    }

    public readonly partial struct ElasticResourceAvailabilityStatus
    {
        public static ElasticResourceAvailabilityStatus Offline { get; } = new ElasticResourceAvailabilityStatus("Offline");
        public static ElasticResourceAvailabilityStatus Online { get; } = new ElasticResourceAvailabilityStatus("Online");
    }

    public readonly partial struct ElasticRootAccess
    {
        public static ElasticRootAccess Disabled { get; } = new ElasticRootAccess("Disabled");
        public static ElasticRootAccess Enabled { get; } = new ElasticRootAccess("Enabled");
    }

    public readonly partial struct ElasticServiceLevel
    {
        public static ElasticServiceLevel ZoneRedundant { get; } = new ElasticServiceLevel("ZoneRedundant");
    }

    public readonly partial struct ElasticSmbEncryption
    {
        public static ElasticSmbEncryption Disabled { get; } = new ElasticSmbEncryption("Disabled");
        public static ElasticSmbEncryption Enabled { get; } = new ElasticSmbEncryption("Enabled");
    }

    public readonly partial struct ElasticSnapshotPolicyStatus
    {
        public static ElasticSnapshotPolicyStatus Disabled { get; } = new ElasticSnapshotPolicyStatus("Disabled");
        public static ElasticSnapshotPolicyStatus Enabled { get; } = new ElasticSnapshotPolicyStatus("Enabled");
    }

    public readonly partial struct ElasticUnixAccessRule
    {
        public static ElasticUnixAccessRule NoAccess { get; } = new ElasticUnixAccessRule("NoAccess");
        public static ElasticUnixAccessRule ReadOnly { get; } = new ElasticUnixAccessRule("ReadOnly");
        public static ElasticUnixAccessRule ReadWrite { get; } = new ElasticUnixAccessRule("ReadWrite");
    }

    public readonly partial struct ElasticVolumePolicyEnforcement
    {
        public static ElasticVolumePolicyEnforcement Enforced { get; } = new ElasticVolumePolicyEnforcement("Enforced");
        public static ElasticVolumePolicyEnforcement NotEnforced { get; } = new ElasticVolumePolicyEnforcement("NotEnforced");
    }

    public readonly partial struct ElasticVolumeRestorationState
    {
        public static ElasticVolumeRestorationState Failed { get; } = new ElasticVolumeRestorationState("Failed");
        public static ElasticVolumeRestorationState Restored { get; } = new ElasticVolumeRestorationState("Restored");
        public static ElasticVolumeRestorationState Restoring { get; } = new ElasticVolumeRestorationState("Restoring");
    }

    public readonly partial struct SnapshotDirectoryVisibility
    {
        public static SnapshotDirectoryVisibility Hidden { get; } = new SnapshotDirectoryVisibility("Hidden");
        public static SnapshotDirectoryVisibility Visible { get; } = new SnapshotDirectoryVisibility("Visible");
    }
}
