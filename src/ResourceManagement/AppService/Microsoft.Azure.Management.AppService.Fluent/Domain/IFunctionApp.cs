// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;

    /// <summary>
    /// An immutable client-side representation of an Azure Function App.
    /// </summary>
    public interface IFunctionApp  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.AppService.Fluent.IWebAppBase,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.AppService.Fluent.IFunctionApp>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<FunctionApp.Update.IUpdate>
    {
        /// <return>The master key for the function app.</return>
        string GetMasterKey();

        /// <return>The master key for the function app.</return>
        Task<string> GetMasterKeyAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Syncs the triggers on the function app.
        /// </summary>
        void SyncTriggers();

        /// <summary>
        /// Gets Syncs the triggers on the function app.
        /// </summary>
        /// <returns>a completable for the operation</returns>
        Task SyncTriggersAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the storage account associated with the function app.
        /// </summary>
        Microsoft.Azure.Management.Storage.Fluent.IStorageAccount StorageAccount { get; }
    }
}