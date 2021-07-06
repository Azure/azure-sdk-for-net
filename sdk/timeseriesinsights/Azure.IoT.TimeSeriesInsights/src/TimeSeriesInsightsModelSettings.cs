// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// Perform operations such as getting and updating Time Series Model configuration settings.
    /// </summary>
    public class TimeSeriesInsightsModelSettings
    {
        private readonly ModelSettingsRestClient _modelSettingsRestClient;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Initializes a new instance of TimeSeriesInsightsModelSettings. This constructor should only be used for mocking purposes.
        /// </summary>
        protected TimeSeriesInsightsModelSettings()
        {
        }

        internal TimeSeriesInsightsModelSettings(ModelSettingsRestClient modelSettingsRestClient, ClientDiagnostics clientDiagnostics)
        {
            Argument.AssertNotNull(modelSettingsRestClient, nameof(modelSettingsRestClient));
            Argument.AssertNotNull(clientDiagnostics, nameof(clientDiagnostics));

            _modelSettingsRestClient = modelSettingsRestClient;
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>
        /// Gets Time Series model settings asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// The model settings which includes model display name, Time Series Id properties and default type Id with the
        /// http response <see cref="Response{TimeSeriesModelSettings}"/>.
        /// </returns>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleGetModelSettings" language="csharp">
        /// TimeSeriesInsightsModelSettings modelSettingsClient = client.GetModelSettingsClient();
        /// TimeSeriesInsightsTypes typesClient = client.GetTypesClient();
        /// Response&lt;TimeSeriesModelSettings&gt; getModelSettingsResponse = await modelSettingsClient.GetAsync();
        /// Console.WriteLine($&quot;Retrieved Time Series Insights model settings \nname : &apos;{getModelSettingsResponse.Value.Name}&apos;, &quot; +
        ///     $&quot;default type Id: {getModelSettingsResponse.Value.DefaultTypeId}&apos;&quot;);
        /// IReadOnlyList&lt;TimeSeriesIdProperty&gt; timeSeriesIdProperties = getModelSettingsResponse.Value.TimeSeriesIdProperties;
        /// foreach (TimeSeriesIdProperty property in timeSeriesIdProperties)
        /// {
        ///     Console.WriteLine($&quot;Time Series Id property name : &apos;{property.Name}&apos;, type : &apos;{property.PropertyType}&apos;.&quot;);
        /// }
        /// </code>
        /// </example>
        public virtual async Task<Response<TimeSeriesModelSettings>> GetAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(Get)}");
            scope.Start();
            try
            {
                Response<ModelSettingsResponse> modelSettings = await _modelSettingsRestClient.GetAsync(null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(modelSettings.Value.ModelSettings, modelSettings.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets Time Series model settings synchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// The model settings which includes model display name, Time Series Id properties and default type Id with the
        /// http response <see cref="Response{TimeSeriesModelSettings}"/>.
        /// </returns>
        /// <seealso cref="GetAsync(CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<TimeSeriesModelSettings> Get(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(Get)}");
            scope.Start();
            try
            {
                Response<ModelSettingsResponse> modelSettings = _modelSettingsRestClient.Get(null, cancellationToken);
                return Response.FromValue(modelSettings.Value.ModelSettings, modelSettings.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates model name on Time Series model settings asynchronously.
        /// </summary>
        /// <param name="name">Model display name which is mutable by the user. Initial value is &quot;DefaultModel&quot;.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The updated model settings with the http response <see cref="Response{TimeSeriesModelSettings}"/>.</returns>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleUpdateModelSettingsName" language="csharp">
        /// Response&lt;TimeSeriesModelSettings&gt; updateModelSettingsNameResponse = await modelSettingsClient.UpdateNameAsync(&quot;NewModelSettingsName&quot;);
        /// Console.WriteLine($&quot;Updated Time Series Insights model settings name: &quot; +
        ///     $&quot;{updateModelSettingsNameResponse.Value.Name}&quot;);
        /// </code>
        /// </example>
        public virtual async Task<Response<TimeSeriesModelSettings>> UpdateNameAsync(string name, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(UpdateName)}");
            scope.Start();
            try
            {
                var options = new UpdateModelSettingsRequest { Name = name };
                Response<ModelSettingsResponse> modelSettings = await _modelSettingsRestClient.UpdateAsync(options, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(modelSettings.Value.ModelSettings, modelSettings.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates model name on Time Series model settings synchronously.
        /// </summary>
        /// <param name="name">Model display name which is mutable by the user. Initial value is &quot;DefaultModel&quot;.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The updated model settings with the http response <see cref="Response{TimeSeriesModelSettings}"/>.</returns>
        /// <seealso cref="UpdateNameAsync(string, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<TimeSeriesModelSettings> UpdateName(string name, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(UpdateName)}");
            scope.Start();
            try
            {
                // To do: Generate client session Id
                var options = new UpdateModelSettingsRequest { Name = name };
                Response<ModelSettingsResponse> modelSettings = _modelSettingsRestClient.Update(options, null, cancellationToken);
                return Response.FromValue(modelSettings.Value.ModelSettings, modelSettings.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates model default type Id on Time Series model settings asynchronously.
        /// </summary>
        /// <param name="defaultTypeId">Default type Id of the model that new instances will automatically belong to.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The updated model settings with the http response <see cref="Response{TimeSeriesModelSettings}"/>.</returns>
        /// <example>
        /// <code snippet="Snippet:TimeSeriesInsightsSampleUpdateModelSettingsDefaultType" language="csharp">
        /// Response&lt;TimeSeriesModelSettings&gt; updateDefaultTypeIdResponse = await modelSettingsClient
        ///     .UpdateDefaultTypeIdAsync(tsiTypeId);
        /// Console.WriteLine($&quot;Updated Time Series Insights model settings default type Id: &quot; +
        ///     $&quot;{updateDefaultTypeIdResponse.Value.Name}&quot;);
        /// </code>
        /// </example>
        public virtual async Task<Response<TimeSeriesModelSettings>> UpdateDefaultTypeIdAsync(string defaultTypeId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(UpdateDefaultTypeId)}");
            scope.Start();
            try
            {
                var options = new UpdateModelSettingsRequest { DefaultTypeId = defaultTypeId };
                Response<ModelSettingsResponse> modelSettings = await _modelSettingsRestClient.UpdateAsync(options, null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(modelSettings.Value.ModelSettings, modelSettings.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates default type Id on Time Series model settings synchronously.
        /// </summary>
        /// <param name="defaultTypeId">Default type Id of the model that new instances will automatically belong to.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The updated model settings with the http response <see cref="Response{TimeSeriesModelSettings}"/>.</returns>
        /// <seealso cref="UpdateDefaultTypeIdAsync(string, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<TimeSeriesModelSettings> UpdateDefaultTypeId(string defaultTypeId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TimeSeriesInsightsClient)}.{nameof(UpdateDefaultTypeId)}");
            scope.Start();
            try
            {
                var options = new UpdateModelSettingsRequest { DefaultTypeId = defaultTypeId };
                Response<ModelSettingsResponse> modelSettings = _modelSettingsRestClient.Update(options, null, cancellationToken);
                return Response.FromValue(modelSettings.Value.ModelSettings, modelSettings.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
