// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    // TypeSpec models configuration PUT/PATCH with ConfigurationForUpdate, so generation uses
    // PostgreSqlFlexibleServerConfigurationCreateOrUpdateContent for the request body. Preserve
    // previous GA resource-level Update overloads that accepted PostgreSqlFlexibleServerConfigurationData.
    public partial class PostgreSqlFlexibleServerConfigurationResource
    {
        /// <summary> Update a configuration. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="data"> The required parameters for updating a server configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<PostgreSqlFlexibleServerConfigurationResource>> UpdateAsync(WaitUntil waitUntil, PostgreSqlFlexibleServerConfigurationData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            var content = new PostgreSqlFlexibleServerConfigurationCreateOrUpdateContent()
            {
                Value = data.Value,
                Source = data.Source
            };
            return await UpdateAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Update a configuration. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="data"> The required parameters for updating a server configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<PostgreSqlFlexibleServerConfigurationResource> Update(WaitUntil waitUntil, PostgreSqlFlexibleServerConfigurationData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            var content = new PostgreSqlFlexibleServerConfigurationCreateOrUpdateContent()
            {
                Value = data.Value,
                Source = data.Source
            };
            return Update(waitUntil, content, cancellationToken);
        }
    }
}
