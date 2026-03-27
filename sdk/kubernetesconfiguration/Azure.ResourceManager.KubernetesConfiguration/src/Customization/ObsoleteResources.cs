// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.KubernetesConfiguration.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.KubernetesConfiguration
{
    // Customization reason: The KubernetesConfiguration service spec was split into separate TypeSpec
    // projects. FluxConfiguration and SourceControlConfiguration resource types, their collections,
    // extension methods, and mockable resource classes are no longer auto-generated since the SDK now
    // only generates from the "extensions" project. These types are preserved as [Obsolete] stubs
    // with all operations throwing NotSupportedException, ensuring backward API compatibility with
    // the previous GA SDK (v1.2.0, ApiCompatVersion = 1.2.0).

    /// <summary> The KubernetesFluxConfiguration data model. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesFluxConfigurationData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="KubernetesFluxConfigurationData"/>. </summary>
        public KubernetesFluxConfigurationData() { }

        /// <summary> Parameters to reconcile to the AzureBlob source kind type. </summary>
        public KubernetesAzureBlob AzureBlob { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Parameters to reconcile to the Bucket source kind type. </summary>
        public KubernetesBucket Bucket { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Combined status of the Flux Kubernetes resources created by the fluxConfiguration. </summary>
        public KubernetesFluxComplianceState? ComplianceState => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Key-value pairs of protected configuration settings for the configuration. </summary>
        public IDictionary<string, string> ConfigurationProtectedSettings { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Error message returned to the user in the case of provisioning failure. </summary>
        public string ErrorMessage => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Parameters to reconcile to the GitRepository source kind type. </summary>
        public KubernetesGitRepository GitRepository { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Whether this configuration should suspend its reconciliation of its kustomizations and sources. </summary>
        public bool? IsReconciliationSuspended { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Array of kustomizations used to reconcile the artifact pulled by the source type on the cluster. </summary>
        public IDictionary<string, Kustomization> Kustomizations { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The namespace to which this configuration is installed to. Maximum of 253 lower case alphanumeric characters, hyphen and period only. </summary>
        public string Namespace { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Status of the creation of the fluxConfiguration. </summary>
        public KubernetesConfigurationProvisioningState? ProvisioningState => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Public Key associated with this fluxConfiguration (either generated within the cluster or provided by the user). </summary>
        public string RepositoryPublicKey => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Scope at which the operator will be installed. </summary>
        public KubernetesConfigurationScope? Scope { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Source Kind to pull the configuration data from. </summary>
        public KubernetesConfigurationSourceKind? SourceKind { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Branch and/or SHA of the source commit synced with the cluster. </summary>
        public string SourceSyncedCommitId => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Datetime that the source was last synced. </summary>
        public DateTimeOffset? SourceUpdatedOn => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Statuses of the Flux Kubernetes resources created by the fluxConfiguration. </summary>
        public IReadOnlyList<KubernetesObjectStatus> Statuses => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Datetime that the fluxConfiguration status was last updated. </summary>
        public DateTimeOffset? StatusUpdatedOn => throw new NotSupportedException("This resource type is no longer supported in this package.");
    }

    /// <summary> The KubernetesFluxConfigurationResource stub. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesFluxConfigurationResource : ArmResource
    {
        /// <summary> The resource type for this resource. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.KubernetesConfiguration/fluxConfigurations";

        /// <summary> Initializes a new instance of the <see cref="KubernetesFluxConfigurationResource"/> class for mocking. </summary>
        protected KubernetesFluxConfigurationResource() { }

        /// <summary> Gets the data representing this Feature. </summary>
        public virtual KubernetesFluxConfigurationData Data => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Generate the resource identifier of a <see cref="KubernetesFluxConfigurationResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterRp, string clusterResourceName, string clusterName, string fluxConfigurationName) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Delete a Flux Configuration. </summary>
        public virtual ArmOperation Delete(WaitUntil waitUntil, bool? forceDelete = default, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Delete a Flux Configuration. </summary>
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, bool? forceDelete = default, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Gets details of the Flux Configuration. </summary>
        public virtual Response<KubernetesFluxConfigurationResource> Get(CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Gets details of the Flux Configuration. </summary>
        public virtual Task<Response<KubernetesFluxConfigurationResource>> GetAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Update an existing Kubernetes Flux Configuration. </summary>
        public virtual ArmOperation<KubernetesFluxConfigurationResource> Update(WaitUntil waitUntil, KubernetesFluxConfigurationPatch patch, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Update an existing Kubernetes Flux Configuration. </summary>
        public virtual Task<ArmOperation<KubernetesFluxConfigurationResource>> UpdateAsync(WaitUntil waitUntil, KubernetesFluxConfigurationPatch patch, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
    }

    /// <summary> The KubernetesFluxConfigurationCollection stub. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesFluxConfigurationCollection : ArmCollection, IEnumerable<KubernetesFluxConfigurationResource>, IAsyncEnumerable<KubernetesFluxConfigurationResource>
    {
        /// <summary> Initializes a new instance of the <see cref="KubernetesFluxConfigurationCollection"/> class for mocking. </summary>
        protected KubernetesFluxConfigurationCollection() { }

        /// <summary> Create a new Kubernetes Flux Configuration. </summary>
        public virtual ArmOperation<KubernetesFluxConfigurationResource> CreateOrUpdate(WaitUntil waitUntil, string fluxConfigurationName, KubernetesFluxConfigurationData data, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Create a new Kubernetes Flux Configuration. </summary>
        public virtual Task<ArmOperation<KubernetesFluxConfigurationResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string fluxConfigurationName, KubernetesFluxConfigurationData data, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Checks to see if the resource exists in azure. </summary>
        public virtual Response<bool> Exists(string fluxConfigurationName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Checks to see if the resource exists in azure. </summary>
        public virtual Task<Response<bool>> ExistsAsync(string fluxConfigurationName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Gets details of the Flux Configuration. </summary>
        public virtual Response<KubernetesFluxConfigurationResource> Get(string fluxConfigurationName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> List all Flux Configurations. </summary>
        public virtual Pageable<KubernetesFluxConfigurationResource> GetAll(CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> List all Flux Configurations. </summary>
        public virtual AsyncPageable<KubernetesFluxConfigurationResource> GetAllAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Gets details of the Flux Configuration. </summary>
        public virtual Task<Response<KubernetesFluxConfigurationResource>> GetAsync(string fluxConfigurationName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Tries to get details for this resource from the service. </summary>
        public virtual NullableResponse<KubernetesFluxConfigurationResource> GetIfExists(string fluxConfigurationName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Tries to get details for this resource from the service. </summary>
        public virtual Task<NullableResponse<KubernetesFluxConfigurationResource>> GetIfExistsAsync(string fluxConfigurationName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");

        IEnumerator<KubernetesFluxConfigurationResource> IEnumerable<KubernetesFluxConfigurationResource>.GetEnumerator() => throw new NotSupportedException("This resource type is no longer supported in this package.");
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => throw new NotSupportedException("This resource type is no longer supported in this package.");
        IAsyncEnumerator<KubernetesFluxConfigurationResource> IAsyncEnumerable<KubernetesFluxConfigurationResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => throw new NotSupportedException("This resource type is no longer supported in this package.");
    }

    /// <summary> The KubernetesSourceControlConfigurationData model. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesSourceControlConfigurationData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="KubernetesSourceControlConfigurationData"/>. </summary>
        public KubernetesSourceControlConfigurationData() { }

        /// <summary> Compliance Status of the Configuration. </summary>
        public KubernetesConfigurationComplianceStatus ComplianceStatus => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Name-value pairs of protected configuration settings for the configuration. </summary>
        public IDictionary<string, string> ConfigurationProtectedSettings => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Properties for Helm operator. </summary>
        public HelmOperatorProperties HelmOperatorProperties { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Option to enable Helm Operator for this git configuration. </summary>
        public bool? IsHelmOperatorEnabled { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Instance name of the operator - identifying the specific configuration. </summary>
        public string OperatorInstanceName { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The namespace to which this operator is installed to. Maximum of 253 lower case alphanumeric characters, hyphen and period only. </summary>
        public string OperatorNamespace { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Any Parameters for the Operator instance in string format. </summary>
        public string OperatorParams { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Scope at which the operator will be installed. </summary>
        public KubernetesOperatorScope? OperatorScope { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Type of the operator. </summary>
        public KubernetesOperator? OperatorType { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> The provisioning state of the resource provider. </summary>
        public KubernetesConfigurationProvisioningStateType? ProvisioningState => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Public Key associated with this SourceControl configuration (either generated within the cluster or provided by the user). </summary>
        public string RepositoryPublicKey => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Url of the SourceControl Repository. </summary>
        public Uri RepositoryUri { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
        /// <summary> Base64-encoded known_hosts contents containing public SSH keys required to access private git instances. </summary>
        public string SshKnownHostsContents { get => throw new NotSupportedException("This resource type is no longer supported in this package."); set => throw new NotSupportedException("This resource type is no longer supported in this package."); }
    }

    /// <summary> The KubernetesSourceControlConfigurationResource stub. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesSourceControlConfigurationResource : ArmResource
    {
        /// <summary> The resource type for this resource. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.KubernetesConfiguration/sourceControlConfigurations";

        /// <summary> Initializes a new instance of the <see cref="KubernetesSourceControlConfigurationResource"/> class for mocking. </summary>
        protected KubernetesSourceControlConfigurationResource() { }

        /// <summary> Gets the data representing this Feature. </summary>
        public virtual KubernetesSourceControlConfigurationData Data => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Generate the resource identifier of a <see cref="KubernetesSourceControlConfigurationResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterRp, string clusterResourceName, string clusterName, string sourceControlConfigurationName) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Delete a SourceControlConfiguration. </summary>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Delete a SourceControlConfiguration. </summary>
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Gets details of the Source Control Configuration. </summary>
        public virtual Response<KubernetesSourceControlConfigurationResource> Get(CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Gets details of the Source Control Configuration. </summary>
        public virtual Task<Response<KubernetesSourceControlConfigurationResource>> GetAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Update an existing Source Control Configuration. </summary>
        public virtual ArmOperation<KubernetesSourceControlConfigurationResource> Update(WaitUntil waitUntil, KubernetesSourceControlConfigurationData data, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Update an existing Source Control Configuration. </summary>
        public virtual Task<ArmOperation<KubernetesSourceControlConfigurationResource>> UpdateAsync(WaitUntil waitUntil, KubernetesSourceControlConfigurationData data, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
    }

    /// <summary> The KubernetesSourceControlConfigurationCollection stub. </summary>
    [Obsolete("This type is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class KubernetesSourceControlConfigurationCollection : ArmCollection, IEnumerable<KubernetesSourceControlConfigurationResource>, IAsyncEnumerable<KubernetesSourceControlConfigurationResource>
    {
        /// <summary> Initializes a new instance of the <see cref="KubernetesSourceControlConfigurationCollection"/> class for mocking. </summary>
        protected KubernetesSourceControlConfigurationCollection() { }

        /// <summary> Create a new SourceControlConfiguration. </summary>
        public virtual ArmOperation<KubernetesSourceControlConfigurationResource> CreateOrUpdate(WaitUntil waitUntil, string sourceControlConfigurationName, KubernetesSourceControlConfigurationData data, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Create a new SourceControlConfiguration. </summary>
        public virtual Task<ArmOperation<KubernetesSourceControlConfigurationResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string sourceControlConfigurationName, KubernetesSourceControlConfigurationData data, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Checks to see if the resource exists in azure. </summary>
        public virtual Response<bool> Exists(string sourceControlConfigurationName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Checks to see if the resource exists in azure. </summary>
        public virtual Task<Response<bool>> ExistsAsync(string sourceControlConfigurationName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Gets details of the Source Control Configuration. </summary>
        public virtual Response<KubernetesSourceControlConfigurationResource> Get(string sourceControlConfigurationName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> List all Source Control Configurations. </summary>
        public virtual Pageable<KubernetesSourceControlConfigurationResource> GetAll(CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> List all Source Control Configurations. </summary>
        public virtual AsyncPageable<KubernetesSourceControlConfigurationResource> GetAllAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Gets details of the Source Control Configuration. </summary>
        public virtual Task<Response<KubernetesSourceControlConfigurationResource>> GetAsync(string sourceControlConfigurationName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Tries to get details for this resource from the service. </summary>
        public virtual NullableResponse<KubernetesSourceControlConfigurationResource> GetIfExists(string sourceControlConfigurationName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");
        /// <summary> Tries to get details for this resource from the service. </summary>
        public virtual Task<NullableResponse<KubernetesSourceControlConfigurationResource>> GetIfExistsAsync(string sourceControlConfigurationName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");

        IEnumerator<KubernetesSourceControlConfigurationResource> IEnumerable<KubernetesSourceControlConfigurationResource>.GetEnumerator() => throw new NotSupportedException("This resource type is no longer supported in this package.");
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => throw new NotSupportedException("This resource type is no longer supported in this package.");
        IAsyncEnumerator<KubernetesSourceControlConfigurationResource> IAsyncEnumerable<KubernetesSourceControlConfigurationResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => throw new NotSupportedException("This resource type is no longer supported in this package.");
    }

    public static partial class KubernetesConfigurationExtensions
    {
        /// <summary> Gets a KubernetesFluxConfigurationResource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<KubernetesFluxConfigurationResource> GetKubernetesFluxConfiguration(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string fluxConfigurationName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Gets a KubernetesFluxConfigurationResource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<Response<KubernetesFluxConfigurationResource>> GetKubernetesFluxConfigurationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string fluxConfigurationName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Gets an object representing a KubernetesFluxConfigurationResource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KubernetesFluxConfigurationResource GetKubernetesFluxConfigurationResource(this ArmClient client, ResourceIdentifier id) => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Gets a collection of KubernetesFluxConfigurationResources. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KubernetesFluxConfigurationCollection GetKubernetesFluxConfigurations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName) => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Gets a KubernetesSourceControlConfigurationResource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<KubernetesSourceControlConfigurationResource> GetKubernetesSourceControlConfiguration(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string sourceControlConfigurationName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Gets a KubernetesSourceControlConfigurationResource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<Response<KubernetesSourceControlConfigurationResource>> GetKubernetesSourceControlConfigurationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string sourceControlConfigurationName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Gets an object representing a KubernetesSourceControlConfigurationResource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KubernetesSourceControlConfigurationResource GetKubernetesSourceControlConfigurationResource(this ArmClient client, ResourceIdentifier id) => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Gets a collection of KubernetesSourceControlConfigurationResources. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KubernetesSourceControlConfigurationCollection GetKubernetesSourceControlConfigurations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName) => throw new NotSupportedException("This resource type is no longer supported in this package.");
    }
}

namespace Azure.ResourceManager.KubernetesConfiguration.Mocking
{
    // Partial class extensions for mocking classes to add removed resource type methods.

    public partial class MockableKubernetesConfigurationArmClient
    {
        /// <summary> Gets an object representing a KubernetesFluxConfigurationResource along with the instance operations that can be performed on it but with no data. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual KubernetesFluxConfigurationResource GetKubernetesFluxConfigurationResource(Azure.Core.ResourceIdentifier id) => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Gets an object representing a KubernetesSourceControlConfigurationResource along with the instance operations that can be performed on it but with no data. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual KubernetesSourceControlConfigurationResource GetKubernetesSourceControlConfigurationResource(Azure.Core.ResourceIdentifier id) => throw new NotSupportedException("This resource type is no longer supported in this package.");
    }

    public partial class MockableKubernetesConfigurationResourceGroupResource
    {
        /// <summary> Gets a KubernetesFluxConfigurationResource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Azure.Core.ForwardsClientCalls]
        public virtual Response<KubernetesFluxConfigurationResource> GetKubernetesFluxConfiguration(string clusterRp, string clusterResourceName, string clusterName, string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Gets a KubernetesFluxConfigurationResource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Azure.Core.ForwardsClientCalls]
        public virtual Task<Response<KubernetesFluxConfigurationResource>> GetKubernetesFluxConfigurationAsync(string clusterRp, string clusterResourceName, string clusterName, string fluxConfigurationName, System.Threading.CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Gets a collection of KubernetesFluxConfigurationResources. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual KubernetesFluxConfigurationCollection GetKubernetesFluxConfigurations(string clusterRp, string clusterResourceName, string clusterName) => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Gets a KubernetesSourceControlConfigurationResource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Azure.Core.ForwardsClientCalls]
        public virtual Response<KubernetesSourceControlConfigurationResource> GetKubernetesSourceControlConfiguration(string clusterRp, string clusterResourceName, string clusterName, string sourceControlConfigurationName, System.Threading.CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Gets a KubernetesSourceControlConfigurationResource. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Azure.Core.ForwardsClientCalls]
        public virtual Task<Response<KubernetesSourceControlConfigurationResource>> GetKubernetesSourceControlConfigurationAsync(string clusterRp, string clusterResourceName, string clusterName, string sourceControlConfigurationName, System.Threading.CancellationToken cancellationToken = default) => throw new NotSupportedException("This resource type is no longer supported in this package.");

        /// <summary> Gets a collection of KubernetesSourceControlConfigurationResources. </summary>
        [Obsolete("This method is obsolete and will be removed in a future version. The service spec has been split into separate TypeSpec projects.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual KubernetesSourceControlConfigurationCollection GetKubernetesSourceControlConfigurations(string clusterRp, string clusterResourceName, string clusterName) => throw new NotSupportedException("This resource type is no longer supported in this package.");
    }
}
