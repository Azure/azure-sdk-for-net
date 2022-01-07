// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Management.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Management
{
    /// <summary> A class representing collection of ManagementGroup and their operations over its parent. </summary>
    public partial class ManagementGroupCollection : ArmCollection, IEnumerable<ManagementGroup>, IAsyncEnumerable<ManagementGroup>
    {
        /// RequestPath: /providers/Microsoft.Management/checkNameAvailability
        /// ContextualPath: /providers/Microsoft.Management/managementGroups/{groupId}
        /// OperationId: ManagementGroups_CheckNameAvailability
        /// <summary> Checks if the specified management group name is valid and unique. </summary>
        /// <param name="checkNameAvailabilityRequest"> Management group name availability check parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="checkNameAvailabilityRequest"/> is null. </exception>
        public async virtual Task<Response<CheckNameAvailabilityResult>> CheckNameAvailabilityAsync(CheckNameAvailabilityOptions checkNameAvailabilityRequest, CancellationToken cancellationToken = default)
        {
            if (checkNameAvailabilityRequest == null)
            {
                throw new ArgumentNullException(nameof(checkNameAvailabilityRequest));
            }

            using var scope = _clientDiagnostics.CreateScope("ManagementGroupCollection.CheckNameAvailability");
            scope.Start();
            try
            {
                var response = await _managementGroupsRestClient.CheckNameAvailabilityAsync(checkNameAvailabilityRequest, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// RequestPath: /providers/Microsoft.Management/checkNameAvailability
        /// ContextualPath: /providers/Microsoft.Management/managementGroups/{groupId}
        /// OperationId: ManagementGroups_CheckNameAvailability
        /// <summary> Checks if the specified management group name is valid and unique. </summary>
        /// <param name="checkNameAvailabilityRequest"> Management group name availability check parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="checkNameAvailabilityRequest"/> is null. </exception>
        public virtual Response<CheckNameAvailabilityResult> CheckNameAvailability(CheckNameAvailabilityOptions checkNameAvailabilityRequest, CancellationToken cancellationToken = default)
        {
            if (checkNameAvailabilityRequest == null)
            {
                throw new ArgumentNullException(nameof(checkNameAvailabilityRequest));
            }

            using var scope = _clientDiagnostics.CreateScope("ManagementGroupCollection.CheckNameAvailability");
            scope.Start();
            try
            {
                var response = _managementGroupsRestClient.CheckNameAvailability(checkNameAvailabilityRequest, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
