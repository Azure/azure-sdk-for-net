// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable SA1402 // File may only contain a single type - grouping obsolete stub types together

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Azure.ResourceManager.KubernetesConfiguration.Models
{
    // ---------------------------------------------------------------
    // Extensible enum struct types (removed during TypeSpec migration)
    // ---------------------------------------------------------------

    /// <summary> The compliance state of the configuration. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct KubernetesConfigurationComplianceStateType : IEquatable<KubernetesConfigurationComplianceStateType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="KubernetesConfigurationComplianceStateType"/>. </summary>
        public KubernetesConfigurationComplianceStateType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

        /// <summary> Compliant. </summary>
        public static KubernetesConfigurationComplianceStateType Compliant { get; } = new("Compliant");
        /// <summary> Failed. </summary>
        public static KubernetesConfigurationComplianceStateType Failed { get; } = new("Failed");
        /// <summary> Installed. </summary>
        public static KubernetesConfigurationComplianceStateType Installed { get; } = new("Installed");
        /// <summary> Noncompliant. </summary>
        public static KubernetesConfigurationComplianceStateType Noncompliant { get; } = new("Noncompliant");
        /// <summary> Pending. </summary>
        public static KubernetesConfigurationComplianceStateType Pending { get; } = new("Pending");

        /// <summary> Converts a string to a <see cref="KubernetesConfigurationComplianceStateType"/>. </summary>
        public static implicit operator KubernetesConfigurationComplianceStateType(string value) => new(value);

        /// <inheritdoc />
        public static bool operator ==(KubernetesConfigurationComplianceStateType left, KubernetesConfigurationComplianceStateType right) => left.Equals(right);
        /// <inheritdoc />
        public static bool operator !=(KubernetesConfigurationComplianceStateType left, KubernetesConfigurationComplianceStateType right) => !left.Equals(right);

        /// <inheritdoc />
        public bool Equals(KubernetesConfigurationComplianceStateType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is KubernetesConfigurationComplianceStateType other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }

    /// <summary> Level of the message. Note: "Mesage" is an intentional typo preserved for backward compatibility. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct KubernetesConfigurationMesageLevel : IEquatable<KubernetesConfigurationMesageLevel>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="KubernetesConfigurationMesageLevel"/>. </summary>
        public KubernetesConfigurationMesageLevel(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

        /// <summary> Error. </summary>
        public static KubernetesConfigurationMesageLevel Error { get; } = new("Error");
        /// <summary> Information. </summary>
        public static KubernetesConfigurationMesageLevel Information { get; } = new("Information");
        /// <summary> Warning. </summary>
        public static KubernetesConfigurationMesageLevel Warning { get; } = new("Warning");

        /// <summary> Converts a string to a <see cref="KubernetesConfigurationMesageLevel"/>. </summary>
        public static implicit operator KubernetesConfigurationMesageLevel(string value) => new(value);

        /// <inheritdoc />
        public static bool operator ==(KubernetesConfigurationMesageLevel left, KubernetesConfigurationMesageLevel right) => left.Equals(right);
        /// <inheritdoc />
        public static bool operator !=(KubernetesConfigurationMesageLevel left, KubernetesConfigurationMesageLevel right) => !left.Equals(right);

        /// <inheritdoc />
        public bool Equals(KubernetesConfigurationMesageLevel other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is KubernetesConfigurationMesageLevel other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }

    /// <summary> The provisioning state of the source control configuration resource. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct KubernetesConfigurationProvisioningStateType : IEquatable<KubernetesConfigurationProvisioningStateType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="KubernetesConfigurationProvisioningStateType"/>. </summary>
        public KubernetesConfigurationProvisioningStateType(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

        /// <summary> Accepted. </summary>
        public static KubernetesConfigurationProvisioningStateType Accepted { get; } = new("Accepted");
        /// <summary> Deleting. </summary>
        public static KubernetesConfigurationProvisioningStateType Deleting { get; } = new("Deleting");
        /// <summary> Failed. </summary>
        public static KubernetesConfigurationProvisioningStateType Failed { get; } = new("Failed");
        /// <summary> Running. </summary>
        public static KubernetesConfigurationProvisioningStateType Running { get; } = new("Running");
        /// <summary> Succeeded. </summary>
        public static KubernetesConfigurationProvisioningStateType Succeeded { get; } = new("Succeeded");

        /// <summary> Converts a string to a <see cref="KubernetesConfigurationProvisioningStateType"/>. </summary>
        public static implicit operator KubernetesConfigurationProvisioningStateType(string value) => new(value);

        /// <inheritdoc />
        public static bool operator ==(KubernetesConfigurationProvisioningStateType left, KubernetesConfigurationProvisioningStateType right) => left.Equals(right);
        /// <inheritdoc />
        public static bool operator !=(KubernetesConfigurationProvisioningStateType left, KubernetesConfigurationProvisioningStateType right) => !left.Equals(right);

        /// <inheritdoc />
        public bool Equals(KubernetesConfigurationProvisioningStateType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is KubernetesConfigurationProvisioningStateType other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }

    /// <summary> Scope at which the configuration will be installed. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct KubernetesConfigurationScope : IEquatable<KubernetesConfigurationScope>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="KubernetesConfigurationScope"/>. </summary>
        public KubernetesConfigurationScope(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

        /// <summary> Cluster. </summary>
        public static KubernetesConfigurationScope Cluster { get; } = new("cluster");
        /// <summary> Namespace. </summary>
        public static KubernetesConfigurationScope Namespace { get; } = new("namespace");

        /// <summary> Converts a string to a <see cref="KubernetesConfigurationScope"/>. </summary>
        public static implicit operator KubernetesConfigurationScope(string value) => new(value);

        /// <inheritdoc />
        public static bool operator ==(KubernetesConfigurationScope left, KubernetesConfigurationScope right) => left.Equals(right);
        /// <inheritdoc />
        public static bool operator !=(KubernetesConfigurationScope left, KubernetesConfigurationScope right) => !left.Equals(right);

        /// <inheritdoc />
        public bool Equals(KubernetesConfigurationScope other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is KubernetesConfigurationScope other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }

    /// <summary> Source Kind to pull the configuration data from. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct KubernetesConfigurationSourceKind : IEquatable<KubernetesConfigurationSourceKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="KubernetesConfigurationSourceKind"/>. </summary>
        public KubernetesConfigurationSourceKind(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

        /// <summary> AzureBlob. </summary>
        public static KubernetesConfigurationSourceKind AzureBlob { get; } = new("AzureBlob");
        /// <summary> Bucket. </summary>
        public static KubernetesConfigurationSourceKind Bucket { get; } = new("Bucket");
        /// <summary> GitRepository. </summary>
        public static KubernetesConfigurationSourceKind GitRepository { get; } = new("GitRepository");

        /// <summary> Converts a string to a <see cref="KubernetesConfigurationSourceKind"/>. </summary>
        public static implicit operator KubernetesConfigurationSourceKind(string value) => new(value);

        /// <inheritdoc />
        public static bool operator ==(KubernetesConfigurationSourceKind left, KubernetesConfigurationSourceKind right) => left.Equals(right);
        /// <inheritdoc />
        public static bool operator !=(KubernetesConfigurationSourceKind left, KubernetesConfigurationSourceKind right) => !left.Equals(right);

        /// <inheritdoc />
        public bool Equals(KubernetesConfigurationSourceKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is KubernetesConfigurationSourceKind other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }

    /// <summary> The compliance state of the Flux configuration. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct KubernetesFluxComplianceState : IEquatable<KubernetesFluxComplianceState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="KubernetesFluxComplianceState"/>. </summary>
        public KubernetesFluxComplianceState(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

        /// <summary> Compliant. </summary>
        public static KubernetesFluxComplianceState Compliant { get; } = new("Compliant");
        /// <summary> Non-Compliant. </summary>
        public static KubernetesFluxComplianceState NonCompliant { get; } = new("Non-Compliant");
        /// <summary> Pending. </summary>
        public static KubernetesFluxComplianceState Pending { get; } = new("Pending");
        /// <summary> Suspended. </summary>
        public static KubernetesFluxComplianceState Suspended { get; } = new("Suspended");
        /// <summary> Unknown. </summary>
        public static KubernetesFluxComplianceState Unknown { get; } = new("Unknown");

        /// <summary> Converts a string to a <see cref="KubernetesFluxComplianceState"/>. </summary>
        public static implicit operator KubernetesFluxComplianceState(string value) => new(value);

        /// <inheritdoc />
        public static bool operator ==(KubernetesFluxComplianceState left, KubernetesFluxComplianceState right) => left.Equals(right);
        /// <inheritdoc />
        public static bool operator !=(KubernetesFluxComplianceState left, KubernetesFluxComplianceState right) => !left.Equals(right);

        /// <inheritdoc />
        public bool Equals(KubernetesFluxComplianceState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is KubernetesFluxComplianceState other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }

    /// <summary> Type of Kubernetes operator. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct KubernetesOperator : IEquatable<KubernetesOperator>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="KubernetesOperator"/>. </summary>
        public KubernetesOperator(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

        /// <summary> Flux. </summary>
        public static KubernetesOperator Flux { get; } = new("Flux");

        /// <summary> Converts a string to a <see cref="KubernetesOperator"/>. </summary>
        public static implicit operator KubernetesOperator(string value) => new(value);

        /// <inheritdoc />
        public static bool operator ==(KubernetesOperator left, KubernetesOperator right) => left.Equals(right);
        /// <inheritdoc />
        public static bool operator !=(KubernetesOperator left, KubernetesOperator right) => !left.Equals(right);

        /// <inheritdoc />
        public bool Equals(KubernetesOperator other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is KubernetesOperator other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }

    /// <summary> Scope of the operator. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct KubernetesOperatorScope : IEquatable<KubernetesOperatorScope>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="KubernetesOperatorScope"/>. </summary>
        public KubernetesOperatorScope(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

        /// <summary> Cluster. </summary>
        public static KubernetesOperatorScope Cluster { get; } = new("cluster");
        /// <summary> Namespace. </summary>
        public static KubernetesOperatorScope Namespace { get; } = new("namespace");

        /// <summary> Converts a string to a <see cref="KubernetesOperatorScope"/>. </summary>
        public static implicit operator KubernetesOperatorScope(string value) => new(value);

        /// <inheritdoc />
        public static bool operator ==(KubernetesOperatorScope left, KubernetesOperatorScope right) => left.Equals(right);
        /// <inheritdoc />
        public static bool operator !=(KubernetesOperatorScope left, KubernetesOperatorScope right) => !left.Equals(right);

        /// <inheritdoc />
        public bool Equals(KubernetesOperatorScope other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is KubernetesOperatorScope other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }

    // ---------------------------------------------------------------
    // Class types (removed during TypeSpec migration)
    // ---------------------------------------------------------------

    /// <summary> Properties for Helm operator. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class HelmOperatorProperties
    {
        /// <summary> Initializes a new instance of <see cref="HelmOperatorProperties"/>. </summary>
        public HelmOperatorProperties() { }

        /// <summary> Values override for the operator Helm chart. </summary>
        public string ChartValues { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Version of the operator Helm chart. </summary>
        public string ChartVersion { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
    }

    /// <summary> Properties for HelmRelease objects. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class HelmReleaseProperties
    {
        internal HelmReleaseProperties() { }

        /// <summary> The revision number of the last released object change. </summary>
        public long? LastRevisionApplied => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> The reference to the HelmChart object used as the source to this HelmRelease. </summary>
        public KubernetesObjectReference HelmChartRef => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Total number of times that the HelmRelease failed to install or upgrade. </summary>
        public long? FailureCount => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Number of times that the HelmRelease failed to install. </summary>
        public long? InstallFailureCount => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Number of times that the HelmRelease failed to upgrade. </summary>
        public long? UpgradeFailureCount => throw new NotSupportedException("This resource type is no longer supported in this package.");
    }

    /// <summary> Parameters to reconcile to the AzureBlob source kind type. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesAzureBlob
    {
        /// <summary> Initializes a new instance of <see cref="KubernetesAzureBlob"/>. </summary>
        public KubernetesAzureBlob() { }

        /// <summary> The account key (shared key) to access the storage account. </summary>
        public string AccountKey { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The Azure Blob container name to sync from the url endpoint for the flux configuration. </summary>
        public string ContainerName { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Name of a local secret on the Kubernetes cluster to use as the authentication secret. </summary>
        public string LocalAuthRef { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The client Id for authenticating a Managed Identity. </summary>
        public Guid? ManagedIdentityClientId { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The Shared Access token to access the storage container. </summary>
        public string SasToken { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Parameters to authenticate using Service Principal. </summary>
        public KubernetesServicePrincipal ServicePrincipal { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The interval at which to re-reconcile the cluster Azure Blob source with the remote. </summary>
        public long? SyncIntervalInSeconds { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The maximum time to attempt to reconcile the cluster Azure Blob source with the remote. </summary>
        public long? TimeoutInSeconds { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The URL to sync for the flux configuration Azure Blob storage account. </summary>
        public Uri Uri { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
    }

    /// <summary> Parameters to reconcile to the AzureBlob source kind type. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesAzureBlobUpdateContent
    {
        /// <summary> Initializes a new instance of <see cref="KubernetesAzureBlobUpdateContent"/>. </summary>
        public KubernetesAzureBlobUpdateContent() { }

        /// <summary> The account key (shared key) to access the storage account. </summary>
        public string AccountKey { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The Azure Blob container name to sync from the url endpoint for the flux configuration. </summary>
        public string ContainerName { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Name of a local secret on the Kubernetes cluster to use as the authentication secret. </summary>
        public string LocalAuthRef { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The client Id for authenticating a Managed Identity. </summary>
        public string ManagedIdentityClientId { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The Shared Access token to access the storage container. </summary>
        public string SasToken { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Parameters to authenticate using Service Principal. </summary>
        public KubernetesServicePrincipalUpdateContent ServicePrincipal { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The interval at which to re-reconcile the cluster Azure Blob source with the remote. </summary>
        public long? SyncIntervalInSeconds { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The maximum time to attempt to reconcile the cluster Azure Blob source with the remote. </summary>
        public long? TimeoutInSeconds { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The URL to sync for the flux configuration Azure Blob storage account. </summary>
        public Uri Uri { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
    }

    /// <summary> Parameters to reconcile to the Bucket source kind type. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesBucket
    {
        /// <summary> Initializes a new instance of <see cref="KubernetesBucket"/>. </summary>
        public KubernetesBucket() { }

        /// <summary> Plaintext access key used to securely access the S3 bucket. </summary>
        public string AccessKey { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The bucket name to sync from the url endpoint for the flux configuration. </summary>
        public string BucketName { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Name of a local secret on the Kubernetes cluster to use as the authentication secret. </summary>
        public string LocalAuthRef { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The interval at which to re-reconcile the cluster bucket source with the remote. </summary>
        public long? SyncIntervalInSeconds { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The maximum time to attempt to reconcile the cluster bucket source with the remote. </summary>
        public long? TimeoutInSeconds { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The URL to sync for the flux configuration S3 bucket. </summary>
        public Uri Uri { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Specify whether to use insecure communication when puling data from the S3 bucket. </summary>
        public bool? UseInsecureCommunication { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
    }

    /// <summary> Parameters to reconcile to the Bucket source kind type (update). </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesBucketUpdateContent
    {
        /// <summary> Initializes a new instance of <see cref="KubernetesBucketUpdateContent"/>. </summary>
        public KubernetesBucketUpdateContent() { }

        /// <summary> Plaintext access key used to securely access the S3 bucket. </summary>
        public string AccessKey { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The bucket name to sync from the url endpoint for the flux configuration. </summary>
        public string BucketName { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Name of a local secret on the Kubernetes cluster to use as the authentication secret. </summary>
        public string LocalAuthRef { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The interval at which to re-reconcile the cluster bucket source with the remote. </summary>
        public long? SyncIntervalInSeconds { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The maximum time to attempt to reconcile the cluster bucket source with the remote. </summary>
        public long? TimeoutInSeconds { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The URL to sync for the flux configuration S3 bucket. </summary>
        public Uri Uri { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Specify whether to use insecure communication when puling data from the S3 bucket. </summary>
        public bool? UseInsecureCommunication { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
    }

    /// <summary> The compliance status for the source control configuration. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesConfigurationComplianceStatus
    {
        internal KubernetesConfigurationComplianceStatus() { }

        /// <summary> The compliance state of the configuration. </summary>
        public KubernetesConfigurationComplianceStateType? ComplianceState => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Datetime the configuration was last applied. </summary>
        public DateTimeOffset? LastConfigAppliedOn => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Message from when the configuration was applied. </summary>
        public string Message => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Level of the message. </summary>
        public KubernetesConfigurationMesageLevel? MessageLevel => throw new NotSupportedException("This resource type is no longer supported in this package.");
    }

    /// <summary> The FluxConfiguration Patch Request object. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesFluxConfigurationPatch
    {
        /// <summary> Initializes a new instance of <see cref="KubernetesFluxConfigurationPatch"/>. </summary>
        public KubernetesFluxConfigurationPatch() { }

        /// <summary> Parameters to reconcile to the AzureBlob source kind type. </summary>
        public KubernetesAzureBlobUpdateContent AzureBlob { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Parameters to reconcile to the Bucket source kind type. </summary>
        public KubernetesBucketUpdateContent Bucket { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Key-value pairs of protected configuration settings for the configuration. </summary>
        public IDictionary<string, string> ConfigurationProtectedSettings { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Parameters to reconcile to the GitRepository source kind type. </summary>
        public KubernetesGitRepositoryUpdateContent GitRepository { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Array of kustomizations used to reconcile the artifact pulled by the source type on the cluster. </summary>
        public IDictionary<string, KustomizationUpdateContent> Kustomizations { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Source Kind to pull the configuration data from. </summary>
        public KubernetesConfigurationSourceKind? SourceKind { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Whether this configuration should suspend its reconciliation of its kustomizations and sources. </summary>
        public bool? Suspend { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
    }

    /// <summary> Parameters to reconcile to the GitRepository source kind type. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesGitRepository
    {
        /// <summary> Initializes a new instance of <see cref="KubernetesGitRepository"/>. </summary>
        public KubernetesGitRepository() { }

        /// <summary> Base64-encoded HTTPS certificate authority contents used to access git private git repositories over HTTPS. </summary>
        public string HttpsCACert { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Plaintext HTTPS username used to access private git repositories over HTTPS. </summary>
        public string HttpsUser { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Name of a local secret on the Kubernetes cluster to use as the authentication secret. </summary>
        public string LocalAuthRef { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The source reference for the GitRepository object. </summary>
        public KubernetesGitRepositoryRef RepositoryRef { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Base64-encoded known_hosts value containing public SSH keys required to access private git repositories over SSH. </summary>
        public string SshKnownHosts { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The interval at which to re-reconcile the cluster git repository source with the remote. </summary>
        public long? SyncIntervalInSeconds { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The maximum time to attempt to reconcile the cluster git repository source with the remote. </summary>
        public long? TimeoutInSeconds { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The URL to sync for the flux configuration git repository. </summary>
        public Uri Uri { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
    }

    /// <summary> The source reference for the GitRepository object. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesGitRepositoryRef
    {
        /// <summary> Initializes a new instance of <see cref="KubernetesGitRepositoryRef"/>. </summary>
        public KubernetesGitRepositoryRef() { }

        /// <summary> The git repository branch name to checkout. </summary>
        public string Branch { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The commit SHA to checkout. </summary>
        public string Commit { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The semver range used to match against git repository tags. </summary>
        public string Semver { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The git repository tag name to checkout. </summary>
        public string Tag { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
    }

    /// <summary> Parameters to reconcile to the GitRepository source kind type (update). </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesGitRepositoryUpdateContent
    {
        /// <summary> Initializes a new instance of <see cref="KubernetesGitRepositoryUpdateContent"/>. </summary>
        public KubernetesGitRepositoryUpdateContent() { }

        /// <summary> Base64-encoded HTTPS certificate authority contents used to access git private git repositories over HTTPS. </summary>
        public string HttpsCACert { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Plaintext HTTPS username used to access private git repositories over HTTPS. </summary>
        public string HttpsUser { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Name of a local secret on the Kubernetes cluster to use as the authentication secret. </summary>
        public string LocalAuthRef { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The source reference for the GitRepository object. </summary>
        public KubernetesGitRepositoryRef RepositoryRef { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Base64-encoded known_hosts value containing public SSH keys required to access private git repositories over SSH. </summary>
        public string SshKnownHosts { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The interval at which to re-reconcile the cluster git repository source with the remote. </summary>
        public long? SyncIntervalInSeconds { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The maximum time to attempt to reconcile the cluster git repository source with the remote. </summary>
        public long? TimeoutInSeconds { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The URL to sync for the flux configuration git repository. </summary>
        public Uri Uri { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
    }

    /// <summary> Object reference to a Kubernetes object on a cluster. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesObjectReference
    {
        internal KubernetesObjectReference() { }

        /// <summary> Name of the object. </summary>
        public string Name => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Namespace of the object. </summary>
        public string Namespace => throw new NotSupportedException("This resource type is no longer supported in this package.");
    }

    /// <summary> Statuses of applied Kubernetes objects. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesObjectStatus
    {
        internal KubernetesObjectStatus() { }

        /// <summary> Object reference to the Kustomization that applied this object. </summary>
        public KubernetesObjectReference AppliedBy => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Compliance state of the applied object. </summary>
        public KubernetesFluxComplianceState? ComplianceState => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Additional properties that are provided from objects of the HelmRelease kind. </summary>
        public HelmReleaseProperties HelmReleaseProperties => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Kind of the applied object. </summary>
        public string Kind => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Name of the applied object. </summary>
        public string Name => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Namespace of the applied object. </summary>
        public string Namespace => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Current condition of the applied object. </summary>
        public IReadOnlyList<KubernetesObjectStatusCondition> StatusConditions => throw new NotSupportedException("This resource type is no longer supported in this package.");
    }

    /// <summary> Status condition of Kubernetes object. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesObjectStatusCondition
    {
        internal KubernetesObjectStatusCondition() { }

        /// <summary> Last time this status condition has changed. </summary>
        public DateTimeOffset? LastTransitionOn => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> A more verbose description of the object status condition. </summary>
        public string Message => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> The reason for the condition. </summary>
        public string Reason => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Status of the condition. </summary>
        public string Status => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Object status condition type for this object. </summary>
        public string ObjectStatusConditionDefinitionType => throw new NotSupportedException("This resource type is no longer supported in this package.");
    }

    /// <summary> Parameters to authenticate using Service Principal. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesServicePrincipal
    {
        /// <summary> Initializes a new instance of <see cref="KubernetesServicePrincipal"/>. </summary>
        public KubernetesServicePrincipal() { }

        /// <summary> Base64-encoded certificate used to authenticate a Service Principal. </summary>
        public string ClientCertificate { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The password for the certificate used to authenticate a Service Principal. </summary>
        public string ClientCertificatePassword { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Specifies whether to include x5c header in client claims when acquiring a token to enable subject name / issuer based authentication for the Client Certificate. </summary>
        public bool? ClientCertificateSendChain { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The client Id for authenticating a Service Principal. </summary>
        public Guid? ClientId { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The client secret for authenticating a Service Principal. </summary>
        public string ClientSecret { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The tenant Id for authenticating a Service Principal. </summary>
        public Guid? TenantId { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
    }

    /// <summary> Parameters to authenticate using Service Principal (update). </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesServicePrincipalUpdateContent
    {
        /// <summary> Initializes a new instance of <see cref="KubernetesServicePrincipalUpdateContent"/>. </summary>
        public KubernetesServicePrincipalUpdateContent() { }

        /// <summary> Base64-encoded certificate used to authenticate a Service Principal. </summary>
        public string ClientCertificate { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The password for the certificate used to authenticate a Service Principal. </summary>
        public string ClientCertificatePassword { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Specifies whether to include x5c header in client claims when acquiring a token to enable subject name / issuer based authentication for the Client Certificate. </summary>
        public bool? ClientCertificateSendChain { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The client Id for authenticating a Service Principal. </summary>
        public Guid? ClientId { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The client secret for authenticating a Service Principal. </summary>
        public string ClientSecret { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The tenant Id for authenticating a Service Principal. </summary>
        public Guid? TenantId { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
    }

    /// <summary> The Kustomization defining how to reconcile the artifact pulled by the source type on the cluster. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class Kustomization
    {
        /// <summary> Initializes a new instance of <see cref="Kustomization"/>. </summary>
        public Kustomization() { }

        /// <summary> Specifies other Kustomizations that this Kustomization depends on. </summary>
        public IList<string> DependsOn { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Enable/disable re-creating Kubernetes resources on the cluster when patching fails due to an immutable field change. </summary>
        public bool? Force { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The name of the Kustomization. </summary>
        public string Name => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> The path in the source reference to reconcile on the cluster. </summary>
        public string Path { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Enable/disable garbage collections of Kubernetes objects created by this Kustomization. </summary>
        public bool? Prune { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The interval at which to re-reconcile the Kustomization on the cluster in the event of failure on reconciliation. </summary>
        public long? RetryIntervalInSeconds { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The interval at which to re-reconcile the Kustomization on the cluster. </summary>
        public long? SyncIntervalInSeconds { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The maximum time to attempt to reconcile the Kustomization on the cluster. </summary>
        public long? TimeoutInSeconds { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
    }

    /// <summary> The Kustomization defining how to reconcile the artifact (update). </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KustomizationUpdateContent
    {
        /// <summary> Initializes a new instance of <see cref="KustomizationUpdateContent"/>. </summary>
        public KustomizationUpdateContent() { }

        /// <summary> Specifies other Kustomizations that this Kustomization depends on. </summary>
        public IList<string> DependsOn { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Enable/disable re-creating Kubernetes resources on the cluster when patching fails due to an immutable field change. </summary>
        public bool? Force { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The path in the source reference to reconcile on the cluster. </summary>
        public string Path { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Enable/disable garbage collections of Kubernetes objects created by this Kustomization. </summary>
        public bool? Prune { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The interval at which to re-reconcile the Kustomization on the cluster in the event of failure on reconciliation. </summary>
        public long? RetryIntervalInSeconds { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The interval at which to re-reconcile the Kustomization on the cluster. </summary>
        public long? SyncIntervalInSeconds { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The maximum time to attempt to reconcile the Kustomization on the cluster. </summary>
        public long? TimeoutInSeconds { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
    }

    // ---------------------------------------------------------------
    // ModelFactory stub methods for removed types
    // ---------------------------------------------------------------

    public static partial class ArmKubernetesConfigurationModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.HelmReleaseProperties"/>. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HelmReleaseProperties HelmReleaseProperties(long? lastRevisionApplied = default, KubernetesObjectReference helmChartRef = default, long? failureCount = default, long? installFailureCount = default, long? upgradeFailureCount = default)
            => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Initializes a new instance of <see cref="Models.KubernetesConfigurationComplianceStatus"/>. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KubernetesConfigurationComplianceStatus KubernetesConfigurationComplianceStatus(KubernetesConfigurationComplianceStateType? complianceState = default, DateTimeOffset? lastConfigAppliedOn = default, string message = default, KubernetesConfigurationMesageLevel? messageLevel = default)
            => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Initializes a new instance of <see cref="KubernetesConfiguration.KubernetesFluxConfigurationData"/>. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KubernetesFluxConfigurationData KubernetesFluxConfigurationData(Azure.Core.ResourceIdentifier id = default, string name = default, Azure.Core.ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = default, KubernetesConfigurationScope? scope = default, string @namespace = default, KubernetesConfigurationSourceKind? sourceKind = default, bool? isReconciliationSuspended = default, KubernetesGitRepository gitRepository = default, KubernetesBucket bucket = default, KubernetesAzureBlob azureBlob = default, IDictionary<string, Kustomization> kustomizations = default, IDictionary<string, string> configurationProtectedSettings = default, IEnumerable<KubernetesObjectStatus> statuses = default, string repositoryPublicKey = default, string sourceSyncedCommitId = default, DateTimeOffset? sourceUpdatedOn = default, DateTimeOffset? statusUpdatedOn = default, KubernetesFluxComplianceState? complianceState = default, KubernetesConfigurationProvisioningState? provisioningState = default, string errorMessage = default)
            => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Initializes a new instance of <see cref="Models.KubernetesObjectReference"/>. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KubernetesObjectReference KubernetesObjectReference(string name = default, string @namespace = default)
            => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Initializes a new instance of <see cref="Models.KubernetesObjectStatus"/>. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KubernetesObjectStatus KubernetesObjectStatus(string name = default, string @namespace = default, string kind = default, KubernetesFluxComplianceState? complianceState = default, KubernetesObjectReference appliedBy = default, IEnumerable<KubernetesObjectStatusCondition> statusConditions = default, HelmReleaseProperties helmReleaseProperties = default)
            => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Initializes a new instance of <see cref="Models.KubernetesObjectStatusCondition"/>. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KubernetesObjectStatusCondition KubernetesObjectStatusCondition(DateTimeOffset? lastTransitionOn = default, string message = default, string reason = default, string status = default, string objectStatusConditionDefinitionType = default)
            => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Initializes a new instance of <see cref="KubernetesConfiguration.KubernetesSourceControlConfigurationData"/>. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KubernetesSourceControlConfigurationData KubernetesSourceControlConfigurationData(Azure.Core.ResourceIdentifier id = default, string name = default, Azure.Core.ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = default, Uri repositoryUri = default, string operatorNamespace = default, string operatorInstanceName = default, KubernetesOperator? operatorType = default, string operatorParams = default, IDictionary<string, string> configurationProtectedSettings = default, KubernetesOperatorScope? operatorScope = default, string repositoryPublicKey = default, string sshKnownHostsContents = default, bool? isHelmOperatorEnabled = default, HelmOperatorProperties helmOperatorProperties = default, KubernetesConfigurationProvisioningStateType? provisioningState = default, KubernetesConfigurationComplianceStatus complianceStatus = default)
            => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Initializes a new instance of <see cref="Models.Kustomization"/>. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Kustomization Kustomization(string name = default, string path = default, IEnumerable<string> dependsOn = default, long? timeoutInSeconds = default, long? syncIntervalInSeconds = default, long? retryIntervalInSeconds = default, bool? prune = default, bool? force = default)
            => throw new NotSupportedException("This resource type is no longer supported in this package.");
    }
}
