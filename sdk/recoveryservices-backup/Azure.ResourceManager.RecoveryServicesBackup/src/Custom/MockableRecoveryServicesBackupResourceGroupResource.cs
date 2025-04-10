// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.RecoveryServicesBackup.Models;

namespace Azure.ResourceManager.RecoveryServicesBackup.Mocking
{
    /// <summary>
    /// MockableRecoveryServicesBackupResourceGroupResource
    /// </summary>
    public partial class MockableRecoveryServicesBackupResourceGroupResource
    {
        /// <summary>
        /// GetSecurityPin
        /// </summary>
        /// <param name="vaultName"></param>
        /// <param name="securityPinContent"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<TokenInformation> GetSecurityPin(string vaultName, SecurityPinContent securityPinContent, CancellationToken cancellationToken)
        {
            return GetSecurityPin(vaultName, securityPinContent, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// GetSecurityPin Async
        /// </summary>
        /// <param name="vaultName"></param>
        /// <param name="securityPinContent"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<Response<TokenInformation>> GetSecurityPinAsync(string vaultName, SecurityPinContent securityPinContent, CancellationToken cancellationToken)
        {
            return GetSecurityPinAsync(vaultName, securityPinContent, xMsAuthorizationAuxiliary: null, cancellationToken: cancellationToken);
        }
    }
}
