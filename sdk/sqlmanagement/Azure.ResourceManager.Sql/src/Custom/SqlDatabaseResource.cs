// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlDatabaseResource : ArmResource
    {
        private readonly ClientDiagnostics _metricDefinitionsClientDiagnostics;
        private readonly MetricDefinitionsRestOperations _metricDefinitionsRestClient;
        private readonly ClientDiagnostics _metricsClientDiagnostics;
        private readonly MetricsRestOperations _metricsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SqlDatabaseResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SqlDatabaseResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _sqlDatabaseDatabasesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string sqlDatabaseDatabasesApiVersion);
            _sqlDatabaseDatabasesRestClient = new DatabasesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, sqlDatabaseDatabasesApiVersion);
            _sqlDatabaseColumnDatabaseColumnsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", SqlDatabaseColumnResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SqlDatabaseColumnResource.ResourceType, out string sqlDatabaseColumnDatabaseColumnsApiVersion);
            _sqlDatabaseColumnDatabaseColumnsRestClient = new DatabaseColumnsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, sqlDatabaseColumnDatabaseColumnsApiVersion);
            _databaseEncryptionProtectorsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _databaseEncryptionProtectorsRestClient = new DatabaseEncryptionProtectorsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
            _databaseExtensionsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _databaseExtensionsRestClient = new DatabaseExtensionsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
            _databaseOperationsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _databaseOperationsRestClient = new DatabaseRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
            _databaseUsagesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _databaseUsagesRestClient = new DatabaseUsagesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
            _sqlServerDatabaseRestorePointRestorePointsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", SqlServerDatabaseRestorePointResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SqlServerDatabaseRestorePointResource.ResourceType, out string sqlServerDatabaseRestorePointRestorePointsApiVersion);
            _sqlServerDatabaseRestorePointRestorePointsRestClient = new RestorePointsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, sqlServerDatabaseRestorePointRestorePointsApiVersion);
            _sqlDatabaseSensitivityLabelSensitivityLabelsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", SqlDatabaseSensitivityLabelResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SqlDatabaseSensitivityLabelResource.ResourceType, out string sqlDatabaseSensitivityLabelSensitivityLabelsApiVersion);
            _sqlDatabaseSensitivityLabelSensitivityLabelsRestClient = new SensitivityLabelsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, sqlDatabaseSensitivityLabelSensitivityLabelsApiVersion);
            _synapseLinkWorkspacesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _synapseLinkWorkspacesRestClient = new SynapseLinkWorkspacesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
            _metricDefinitionsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _metricDefinitionsRestClient = new MetricDefinitionsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
            _metricsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _metricsRestClient = new MetricsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        /// <summary>
        /// Gets a database.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Databases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SqlDatabaseResource>> GetAsync(CancellationToken cancellationToken)
        {
            return await GetAsync(null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a database.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Databases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SqlDatabaseResource> Get(CancellationToken cancellationToken)
        {
            return Get(null, null, cancellationToken);
        }

        /// <summary> Gets an object representing a DataMaskingPolicyResource along with the instance operations that can be performed on it in the SqlDatabase. </summary>
        /// <returns> Returns a <see cref="DataMaskingPolicyResource"/> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DataMaskingPolicyResource GetDataMaskingPolicy()
        {
            return new DataMaskingPolicyResource(Client, Id.AppendChildResource("dataMaskingPolicies", "Default"));
        }

        /// <summary>
        /// Returns database metric definitions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/metricDefinitions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MetricDefinitions_ListDatabase</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SqlMetricDefinition"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SqlMetricDefinition> GetMetricDefinitionsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _metricDefinitionsRestClient.CreateListDatabaseRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => SqlMetricDefinition.DeserializeSqlMetricDefinition(e), _metricDefinitionsClientDiagnostics, Pipeline, "SqlDatabaseResource.GetMetricDefinitions", "value", null, cancellationToken);
        }

        /// <summary>
        /// Returns database metric definitions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/metricDefinitions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MetricDefinitions_ListDatabase</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlMetricDefinition"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SqlMetricDefinition> GetMetricDefinitions(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _metricDefinitionsRestClient.CreateListDatabaseRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => SqlMetricDefinition.DeserializeSqlMetricDefinition(e), _metricDefinitionsClientDiagnostics, Pipeline, "SqlDatabaseResource.GetMetricDefinitions", "value", null, cancellationToken);
        }

        /// <summary>
        /// Returns database metrics.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/metrics</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Metrics_ListDatabase</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> An OData filter expression that describes a subset of metrics to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> An async collection of <see cref="SqlMetric"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SqlMetric> GetMetricsAsync(string filter, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(filter, nameof(filter));

            HttpMessage FirstPageRequest(int? pageSizeHint) => _metricsRestClient.CreateListDatabaseRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => SqlMetric.DeserializeSqlMetric(e), _metricsClientDiagnostics, Pipeline, "SqlDatabaseResource.GetMetrics", "value", null, cancellationToken);
        }

        /// <summary>
        /// Returns database metrics.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/metrics</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Metrics_ListDatabase</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> An OData filter expression that describes a subset of metrics to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> A collection of <see cref="SqlMetric"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SqlMetric> GetMetrics(string filter, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(filter, nameof(filter));

            HttpMessage FirstPageRequest(int? pageSizeHint) => _metricsRestClient.CreateListDatabaseRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => SqlMetric.DeserializeSqlMetric(e), _metricsClientDiagnostics, Pipeline, "SqlDatabaseResource.GetMetrics", "value", null, cancellationToken);
        }
    }
}
