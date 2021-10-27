// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.KeyVault.Models;

namespace Azure.ResourceManager.KeyVault
{
    public partial class VaultCollection
    {
        /// <summary> Add access policies in a key vault in the specified subscription. </summary>
        /// <param name="properties"> Properties of the access policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public virtual async Task<Response<VaultAccessPolicyParameters>> AddAccessPolicyAsync(VaultAccessPolicyProperties properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var scope = _clientDiagnostics.CreateScope("VaultCollection.UpdateAccessPolicy");
            scope.Start();
            try
            {
                var response = await _restClient.AddAccessPolicyAsync(Id.ResourceGroupName, Id.Parent.Name, properties, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Add access policies in a key vault in the specified subscription. </summary>
        /// <param name="properties"> Properties of the access policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public virtual Response<VaultAccessPolicyParameters> AddAccessPolicy(VaultAccessPolicyProperties properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var scope = _clientDiagnostics.CreateScope("VaultCollection.UpdateAccessPolicy");
            scope.Start();
            try
            {
                var response = _restClient.AddAccessPolicy(Id.ResourceGroupName, Id.Parent.Name, properties, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace access policies in a key vault in the specified subscription. </summary>
        /// <param name="properties"> Properties of the access policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public virtual async Task<Response<VaultAccessPolicyParameters>> ReplaceAccessPolicyAsync(VaultAccessPolicyProperties properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var scope = _clientDiagnostics.CreateScope("VaultCollection.UpdateAccessPolicy");
            scope.Start();
            try
            {
                var response = await _restClient.ReplaceAccessPolicyAsync(Id.ResourceGroupName, Id.Parent.Name, properties, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Replace access policies in a key vault in the specified subscription. </summary>
        /// <param name="properties"> Properties of the access policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public virtual Response<VaultAccessPolicyParameters> ReplaceAccessPolicy(VaultAccessPolicyProperties properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var scope = _clientDiagnostics.CreateScope("VaultCollection.UpdateAccessPolicy");
            scope.Start();
            try
            {
                var response = _restClient.ReplaceAccessPolicy(Id.ResourceGroupName, Id.Parent.Name, properties, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Remove access policies in a key vault in the specified subscription. </summary>
        /// <param name="properties"> Properties of the access policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public virtual async Task<Response<VaultAccessPolicyParameters>> RemoveAccessPolicyAsync(VaultAccessPolicyProperties properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var scope = _clientDiagnostics.CreateScope("VaultCollection.UpdateAccessPolicy");
            scope.Start();
            try
            {
                var response = await _restClient.RemoveAccessPolicyAsync(Id.ResourceGroupName, Id.Parent.Name, properties, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Remove access policies in a key vault in the specified subscription. </summary>
        /// <param name="properties"> Properties of the access policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public virtual Response<VaultAccessPolicyParameters> RemoveAccessPolicy(VaultAccessPolicyProperties properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var scope = _clientDiagnostics.CreateScope("VaultCollection.UpdateAccessPolicy");
            scope.Start();
            try
            {
                var response = _restClient.RemoveAccessPolicy(Id.ResourceGroupName, Id.Parent.Name, properties, cancellationToken);
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
