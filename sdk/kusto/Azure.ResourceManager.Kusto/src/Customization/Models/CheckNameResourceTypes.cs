// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// These extensible enum types existed in the GA SDK as generated types for
// single-value "type" discriminator properties on check-name-availability
// request models. In TypeSpec these properties are string literals, so the
// generator no longer emits the enum types, but the model factory still
// generates backward-compat overloads that reference them. Providing them
// here preserves API compatibility.
// Generator bug: model factory references non-existent enum types for
// string-literal properties.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Kusto.Models
{
    /// <summary> The type of resource, Microsoft.Kusto/clusters/principalAssignments. </summary>
    public readonly partial struct KustoClusterPrincipalAssignmentType : IEquatable<KustoClusterPrincipalAssignmentType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="KustoClusterPrincipalAssignmentType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public KustoClusterPrincipalAssignmentType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MicrosoftKustoClustersPrincipalAssignmentsValue = "Microsoft.Kusto/clusters/principalAssignments";

        /// <summary> Microsoft.Kusto/clusters/principalAssignments. </summary>
        public static KustoClusterPrincipalAssignmentType MicrosoftKustoClustersPrincipalAssignments { get; } = new KustoClusterPrincipalAssignmentType(MicrosoftKustoClustersPrincipalAssignmentsValue);

        /// <summary> Determines if two <see cref="KustoClusterPrincipalAssignmentType"/> values are the same. </summary>
        public static bool operator ==(KustoClusterPrincipalAssignmentType left, KustoClusterPrincipalAssignmentType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="KustoClusterPrincipalAssignmentType"/> values are not the same. </summary>
        public static bool operator !=(KustoClusterPrincipalAssignmentType left, KustoClusterPrincipalAssignmentType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="KustoClusterPrincipalAssignmentType"/>. </summary>
        public static implicit operator KustoClusterPrincipalAssignmentType(string value) => new KustoClusterPrincipalAssignmentType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is KustoClusterPrincipalAssignmentType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(KustoClusterPrincipalAssignmentType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }

    /// <summary> The type of resource, Microsoft.Kusto/clusters. </summary>
    public readonly partial struct KustoClusterType : IEquatable<KustoClusterType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="KustoClusterType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public KustoClusterType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MicrosoftKustoClustersValue = "Microsoft.Kusto/clusters";

        /// <summary> Microsoft.Kusto/clusters. </summary>
        public static KustoClusterType MicrosoftKustoClusters { get; } = new KustoClusterType(MicrosoftKustoClustersValue);

        /// <summary> Determines if two <see cref="KustoClusterType"/> values are the same. </summary>
        public static bool operator ==(KustoClusterType left, KustoClusterType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="KustoClusterType"/> values are not the same. </summary>
        public static bool operator !=(KustoClusterType left, KustoClusterType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="KustoClusterType"/>. </summary>
        public static implicit operator KustoClusterType(string value) => new KustoClusterType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is KustoClusterType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(KustoClusterType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }

    /// <summary> The type of resource, Microsoft.Kusto/clusters/attachedDatabaseConfigurations. </summary>
    public readonly partial struct AttachedDatabaseType : IEquatable<AttachedDatabaseType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AttachedDatabaseType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AttachedDatabaseType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MicrosoftKustoClustersAttachedDatabaseConfigurationsValue = "Microsoft.Kusto/clusters/attachedDatabaseConfigurations";

        /// <summary> Microsoft.Kusto/clusters/attachedDatabaseConfigurations. </summary>
        public static AttachedDatabaseType MicrosoftKustoClustersAttachedDatabaseConfigurations { get; } = new AttachedDatabaseType(MicrosoftKustoClustersAttachedDatabaseConfigurationsValue);

        /// <summary> Determines if two <see cref="AttachedDatabaseType"/> values are the same. </summary>
        public static bool operator ==(AttachedDatabaseType left, AttachedDatabaseType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AttachedDatabaseType"/> values are not the same. </summary>
        public static bool operator !=(AttachedDatabaseType left, AttachedDatabaseType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="AttachedDatabaseType"/>. </summary>
        public static implicit operator AttachedDatabaseType(string value) => new AttachedDatabaseType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AttachedDatabaseType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AttachedDatabaseType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }

    /// <summary> The type of resource, Microsoft.Kusto/clusters/managedPrivateEndpoints. </summary>
    public readonly partial struct KustoManagedPrivateEndpointsType : IEquatable<KustoManagedPrivateEndpointsType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="KustoManagedPrivateEndpointsType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public KustoManagedPrivateEndpointsType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MicrosoftKustoClustersManagedPrivateEndpointsValue = "Microsoft.Kusto/clusters/managedPrivateEndpoints";

        /// <summary> Microsoft.Kusto/clusters/managedPrivateEndpoints. </summary>
        public static KustoManagedPrivateEndpointsType MicrosoftKustoClustersManagedPrivateEndpoints { get; } = new KustoManagedPrivateEndpointsType(MicrosoftKustoClustersManagedPrivateEndpointsValue);

        /// <summary> Determines if two <see cref="KustoManagedPrivateEndpointsType"/> values are the same. </summary>
        public static bool operator ==(KustoManagedPrivateEndpointsType left, KustoManagedPrivateEndpointsType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="KustoManagedPrivateEndpointsType"/> values are not the same. </summary>
        public static bool operator !=(KustoManagedPrivateEndpointsType left, KustoManagedPrivateEndpointsType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="KustoManagedPrivateEndpointsType"/>. </summary>
        public static implicit operator KustoManagedPrivateEndpointsType(string value) => new KustoManagedPrivateEndpointsType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is KustoManagedPrivateEndpointsType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(KustoManagedPrivateEndpointsType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }

    /// <summary> The type of resource, Microsoft.Kusto/clusters/databases/principalAssignments. </summary>
    public readonly partial struct KustoDatabasePrincipalAssignmentType : IEquatable<KustoDatabasePrincipalAssignmentType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="KustoDatabasePrincipalAssignmentType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public KustoDatabasePrincipalAssignmentType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MicrosoftKustoClustersDatabasesPrincipalAssignmentsValue = "Microsoft.Kusto/clusters/databases/principalAssignments";

        /// <summary> Microsoft.Kusto/clusters/databases/principalAssignments. </summary>
        public static KustoDatabasePrincipalAssignmentType MicrosoftKustoClustersDatabasesPrincipalAssignments { get; } = new KustoDatabasePrincipalAssignmentType(MicrosoftKustoClustersDatabasesPrincipalAssignmentsValue);

        /// <summary> Determines if two <see cref="KustoDatabasePrincipalAssignmentType"/> values are the same. </summary>
        public static bool operator ==(KustoDatabasePrincipalAssignmentType left, KustoDatabasePrincipalAssignmentType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="KustoDatabasePrincipalAssignmentType"/> values are not the same. </summary>
        public static bool operator !=(KustoDatabasePrincipalAssignmentType left, KustoDatabasePrincipalAssignmentType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="KustoDatabasePrincipalAssignmentType"/>. </summary>
        public static implicit operator KustoDatabasePrincipalAssignmentType(string value) => new KustoDatabasePrincipalAssignmentType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is KustoDatabasePrincipalAssignmentType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(KustoDatabasePrincipalAssignmentType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }

    /// <summary> The type of resource, Microsoft.Kusto/clusters/databases/dataConnections. </summary>
    public readonly partial struct KustoDataConnectionType : IEquatable<KustoDataConnectionType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="KustoDataConnectionType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public KustoDataConnectionType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MicrosoftKustoClustersDatabasesDataConnectionsValue = "Microsoft.Kusto/clusters/databases/dataConnections";

        /// <summary> Microsoft.Kusto/clusters/databases/dataConnections. </summary>
        public static KustoDataConnectionType MicrosoftKustoClustersDatabasesDataConnections { get; } = new KustoDataConnectionType(MicrosoftKustoClustersDatabasesDataConnectionsValue);

        /// <summary> Determines if two <see cref="KustoDataConnectionType"/> values are the same. </summary>
        public static bool operator ==(KustoDataConnectionType left, KustoDataConnectionType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="KustoDataConnectionType"/> values are not the same. </summary>
        public static bool operator !=(KustoDataConnectionType left, KustoDataConnectionType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="KustoDataConnectionType"/>. </summary>
        public static implicit operator KustoDataConnectionType(string value) => new KustoDataConnectionType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is KustoDataConnectionType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(KustoDataConnectionType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }

    /// <summary> The type of resource, Microsoft.Kusto/clusters/sandboxCustomImages. </summary>
    public readonly partial struct SandboxCustomImageType : IEquatable<SandboxCustomImageType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SandboxCustomImageType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SandboxCustomImageType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MicrosoftKustoClustersSandboxCustomImagesValue = "Microsoft.Kusto/clusters/sandboxCustomImages";

        /// <summary> Microsoft.Kusto/clusters/sandboxCustomImages. </summary>
        public static SandboxCustomImageType MicrosoftKustoClustersSandboxCustomImages { get; } = new SandboxCustomImageType(MicrosoftKustoClustersSandboxCustomImagesValue);

        /// <summary> Determines if two <see cref="SandboxCustomImageType"/> values are the same. </summary>
        public static bool operator ==(SandboxCustomImageType left, SandboxCustomImageType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SandboxCustomImageType"/> values are not the same. </summary>
        public static bool operator !=(SandboxCustomImageType left, SandboxCustomImageType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="SandboxCustomImageType"/>. </summary>
        public static implicit operator SandboxCustomImageType(string value) => new SandboxCustomImageType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SandboxCustomImageType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SandboxCustomImageType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }

    /// <summary> The type of resource, Microsoft.Kusto/clusters/databases/scripts. </summary>
    public readonly partial struct KustoScriptType : IEquatable<KustoScriptType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="KustoScriptType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public KustoScriptType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string MicrosoftKustoClustersDatabasesScriptsValue = "Microsoft.Kusto/clusters/databases/scripts";

        /// <summary> Microsoft.Kusto/clusters/databases/scripts. </summary>
        public static KustoScriptType MicrosoftKustoClustersDatabasesScripts { get; } = new KustoScriptType(MicrosoftKustoClustersDatabasesScriptsValue);

        /// <summary> Determines if two <see cref="KustoScriptType"/> values are the same. </summary>
        public static bool operator ==(KustoScriptType left, KustoScriptType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="KustoScriptType"/> values are not the same. </summary>
        public static bool operator !=(KustoScriptType left, KustoScriptType right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="KustoScriptType"/>. </summary>
        public static implicit operator KustoScriptType(string value) => new KustoScriptType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is KustoScriptType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(KustoScriptType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
