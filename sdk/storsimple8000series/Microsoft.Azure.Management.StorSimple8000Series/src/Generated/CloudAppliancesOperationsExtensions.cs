
namespace Microsoft.Azure.Management.StorSimple8000Series
{
    using Azure;
    using Management;
    using Rest;
    using Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for CloudAppliancesOperations.
    /// </summary>
    public static partial class CloudAppliancesOperationsExtensions
    {
            /// <summary>
            /// Lists supported cloud appliance models and supported configurations.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static IEnumerable<CloudApplianceConfiguration> ListSupportedConfigurations(this ICloudAppliancesOperations operations, string resourceGroupName, string managerName)
            {
                return operations.ListSupportedConfigurationsAsync(resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists supported cloud appliance models and supported configurations.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IEnumerable<CloudApplianceConfiguration>> ListSupportedConfigurationsAsync(this ICloudAppliancesOperations operations, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListSupportedConfigurationsWithHttpMessagesAsync(resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Provisions cloud appliance.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parameters'>
            /// The cloud appliance
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static void Provision(this ICloudAppliancesOperations operations, CloudAppliance parameters, string resourceGroupName, string managerName)
            {
                operations.ProvisionAsync(parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Provisions cloud appliance.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parameters'>
            /// The cloud appliance
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ProvisionAsync(this ICloudAppliancesOperations operations, CloudAppliance parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.ProvisionWithHttpMessagesAsync(parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Provisions cloud appliance.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parameters'>
            /// The cloud appliance
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static void BeginProvision(this ICloudAppliancesOperations operations, CloudAppliance parameters, string resourceGroupName, string managerName)
            {
                operations.BeginProvisionAsync(parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Provisions cloud appliance.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parameters'>
            /// The cloud appliance
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginProvisionAsync(this ICloudAppliancesOperations operations, CloudAppliance parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginProvisionWithHttpMessagesAsync(parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

    }
}

