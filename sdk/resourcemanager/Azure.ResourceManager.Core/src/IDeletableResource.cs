// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Interface for operations to delete a resource
    /// </summary>
    public interface IDeletableResource
    {
        /// <summary>
        /// Delete the resource.
        /// </summary>
        /// <param name="cancellationToken"> A token allowing immediate cancellation of any blocking call performed during the deletion. </param>
        /// <returns> The status of the delete operation. </returns>
        ArmResponse<Response> Delete(CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete the resource.
        /// </summary>
        /// <param name="cancellationToken"> A token allowing immediate cancellation of any blocking call performed during the deletion. </param>
        /// <returns> A <see cref="Task"/> that on completion returns the status of the delete operation. </returns>
        Task<ArmResponse<Response>> DeleteAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete the resource.
        /// </summary>
        /// <param name="cancellationToken"> A token allowing immediate cancellation of any blocking call performed during the deletion. </param>
        /// <returns> A <see cref="ArmOperation{Response}"/> which allows the caller to control polling and waiting for resource deletion.
        /// The operation yields the final http response to the delete request when complete. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        ArmOperation<Response> StartDelete(CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete the resource.  This call returns a Task that blocks until the delete operation is accepted on the service.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service.
        /// The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a <see cref="ArmOperation{Response}"/> which
        /// allows the caller to control polling and waiting for resource deletion.
        /// The operation yields the final http response to the delete request when complete. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        Task<ArmOperation<Response>> StartDeleteAsync(CancellationToken cancellationToken = default);
    }
}
