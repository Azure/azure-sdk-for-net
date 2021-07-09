// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.KeyVault
{
    public partial class VaultContainer
    {
        /// <summary> Update access policies in a key vault in the specified subscription. </summary>
        /// <param name="properties"> Properties of the access policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public virtual async Task<Response<VaultAccessPolicyParameters>> UpdateAccessPolicyAsync(VaultAccessPolicyProperties properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var scope = _clientDiagnostics.CreateScope("VaultContainer.UpdateAccessPolicy");
            scope.Start();
            try
            {
                var response = await _restClient.UpdateAccessPolicyAsync(Id.ResourceGroupName, Id.Parent.Name, Id.Name, properties, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update access policies in a key vault in the specified subscription. </summary>
        /// <param name="properties"> Properties of the access policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public virtual Response<VaultAccessPolicyParameters> UpdateAccessPolicy(VaultAccessPolicyProperties properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var scope = _clientDiagnostics.CreateScope("VaultContainer.UpdateAccessPolicy");
            scope.Start();
            try
            {
                var response = _restClient.UpdateAccessPolicy(Id.ResourceGroupName, Id.Parent.Name, Id.Name, properties, cancellationToken);
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
