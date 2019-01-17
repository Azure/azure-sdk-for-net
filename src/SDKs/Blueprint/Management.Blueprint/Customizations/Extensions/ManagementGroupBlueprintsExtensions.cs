using Microsoft.Azure.Management.Blueprint.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Blueprint
{
    /// <summary>
    /// Extension methods for BlueprintsOperations.
    /// </summary>
    public static partial class ManagementGroupBlueprintsExtensions
    {
        /// <summary>
        /// Create or update Blueprint definition.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// azure managementGroup name, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        /// <param name='blueprint'>
        /// Blueprint definition.
        /// </param>
        public static BlueprintModel CreateOrUpdateInManagementGroup(this IBlueprintsOperations operations, string managementGroupName, string blueprintName, BlueprintModel blueprint)
        {
            var scope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            return operations.CreateOrUpdateAsync(scope, blueprintName, blueprint).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create or update Blueprint definition.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// azure managementGroup name, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        /// <param name='blueprint'>
        /// Blueprint definition.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<BlueprintModel> CreateOrUpdateInManagementGroupAsync(this IBlueprintsOperations operations, string managementGroupName, string blueprintName, BlueprintModel blueprint, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(scope, blueprintName, blueprint, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Get a blueprint definition.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// azure managementGroup name, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        public static BlueprintModel GetInManagementGroup(this IBlueprintsOperations operations, string managementGroupName, string blueprintName)
        {
            var scope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            return operations.GetAsync(scope, blueprintName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a blueprint definition.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// azure managementGroup name, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<BlueprintModel> GetInManagementGroupAsync(this IBlueprintsOperations operations, string managementGroupName, string blueprintName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            using (var _result = await operations.GetWithHttpMessagesAsync(scope, blueprintName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Delete a blueprint definition.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// azure managementGroup name, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        public static BlueprintModel DeleteInManagementGroup(this IBlueprintsOperations operations, string managementGroupName, string blueprintName)
        {
            var scope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            return operations.DeleteAsync(scope, blueprintName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Delete a blueprint definition.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// azure managementGroup name, which we save the blueprint to.
        /// </param>
        /// <param name='blueprintName'>
        /// name of the blueprint.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<BlueprintModel> DeleteInManagementGroupAsync(this IBlueprintsOperations operations, string managementGroupName, string blueprintName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            using (var _result = await operations.DeleteWithHttpMessagesAsync(scope, blueprintName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Create or update blueprint definition.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// azure managementGroup name, which we save the blueprint to.
        /// </param>
        public static IPage<BlueprintModel> ListInManagementGroup(this IBlueprintsOperations operations, string managementGroupName)
        {
            var scope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            return operations.ListAsync(scope).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create or update blueprint definition.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='managementGroupName'>
        /// azure managementGroup name, which we save the blueprint to.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<IPage<BlueprintModel>> ListInManagementGroupAsync(this IBlueprintsOperations operations, string managementGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = string.Format(Constants.ResourceScopes.ManagementGroupScope, managementGroupName);
            using (var _result = await operations.ListWithHttpMessagesAsync(scope, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
