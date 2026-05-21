// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Kusto.Models;

namespace Azure.ResourceManager.Kusto
{
    public partial class KustoDatabaseResource
    {
        /// <summary> Updates this database using the legacy overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<KustoDatabaseResource> Update(WaitUntil waitUntil, KustoDatabaseData data, CancellationToken cancellationToken)
            => Update(waitUntil, data, null, cancellationToken);

        /// <summary> Updates this database using the legacy overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<KustoDatabaseResource>> UpdateAsync(WaitUntil waitUntil, KustoDatabaseData data, CancellationToken cancellationToken)
            => UpdateAsync(waitUntil, data, null, cancellationToken);

        /// <summary> Validates a data connection using the legacy method name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DataConnectionValidationResults> ValidateDataConnection(WaitUntil waitUntil, DataConnectionValidationContent content, CancellationToken cancellationToken)
            => DataConnectionValidation(waitUntil, content, cancellationToken);

        /// <summary> Validates a data connection using the legacy method name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<DataConnectionValidationResults>> ValidateDataConnectionAsync(WaitUntil waitUntil, DataConnectionValidationContent content, CancellationToken cancellationToken)
            => DataConnectionValidationAsync(waitUntil, content, cancellationToken);

        /// <summary> Invites a follower database using the legacy method name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DatabaseInviteFollowerResult> InviteFollowerDatabase(DatabaseInviteFollowerContent content, CancellationToken cancellationToken)
            => InviteFollower(content, cancellationToken);

        /// <summary> Invites a follower database using the legacy method name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DatabaseInviteFollowerResult>> InviteFollowerDatabaseAsync(DatabaseInviteFollowerContent content, CancellationToken cancellationToken)
            => InviteFollowerAsync(content, cancellationToken);

        /// <summary> Checks database principal assignment name availability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<KustoNameAvailabilityResult> CheckKustoDatabasePrincipalAssignmentNameAvailability(KustoDatabasePrincipalAssignmentNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailability(content, cancellationToken);

        /// <summary> Checks database principal assignment name availability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<KustoNameAvailabilityResult>> CheckKustoDatabasePrincipalAssignmentNameAvailabilityAsync(KustoDatabasePrincipalAssignmentNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailabilityAsync(content, cancellationToken);

        /// <summary> Checks data connection name availability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<KustoNameAvailabilityResult> CheckKustoDataConnectionNameAvailability(KustoDataConnectionNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailability(content, cancellationToken);

        /// <summary> Checks data connection name availability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<KustoNameAvailabilityResult>> CheckKustoDataConnectionNameAvailabilityAsync(KustoDataConnectionNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailabilityAsync(content, cancellationToken);

        /// <summary> Checks script name availability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<KustoNameAvailabilityResult> CheckKustoScriptNameAvailability(KustoScriptNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailability(content, cancellationToken);

        /// <summary> Checks script name availability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<KustoNameAvailabilityResult>> CheckKustoScriptNameAvailabilityAsync(KustoScriptNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailabilityAsync(content, cancellationToken);
    }
}
