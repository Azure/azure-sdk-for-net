// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.RecoveryServicesBackup.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.RecoveryServicesBackup
{
    /// <summary>
    /// RecoveryServicesBackupExtensions
    /// </summary>
    public static partial class RecoveryServicesBackupExtensions
    {
        /// <summary>
        ///GetSecurityPin.
        /// </summary>
        /// <param name="resourceGroupResource"></param>
        /// <param name="vaultName"></param>
        /// <param name="securityPinContent"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Response<TokenInformation> GetSecurityPin(ResourceGroupResource resourceGroupResource, string vaultName, SecurityPinContent securityPinContent, CancellationToken cancellationToken)
        {
            return GetSecurityPin(resourceGroupResource, vaultName, securityPinContent, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }

        /// <summary>
        ///GetSecurityPin Async.
        /// </summary>
        /// <param name="resourceGroupResource"></param>
        /// <param name="vaultName"></param>
        /// <param name="securityPinContent"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<Response<TokenInformation>> GetSecurityPinAsync(ResourceGroupResource resourceGroupResource, string vaultName, SecurityPinContent securityPinContent, CancellationToken cancellationToken)
        {
            return GetSecurityPinAsync(resourceGroupResource, vaultName, securityPinContent, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }
    }
}
