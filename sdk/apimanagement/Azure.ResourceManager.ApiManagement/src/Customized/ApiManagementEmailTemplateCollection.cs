// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    /// <summary>
    /// A class representing a collection of <see cref="ApiManagementEmailTemplateResource" /> and their operations.
    /// Each <see cref="ApiManagementEmailTemplateResource" /> in the collection will belong to the same instance of <see cref="ApiManagementServiceResource" />.
    /// To get an <see cref="ApiManagementEmailTemplateCollection" /> instance call the GetApiManagementEmailTemplates method from an instance of <see cref="ApiManagementServiceResource" />.
    /// </summary>
    public partial class ApiManagementEmailTemplateCollection : ArmCollection, IEnumerable<ApiManagementEmailTemplateResource>, IAsyncEnumerable<ApiManagementEmailTemplateResource>
    {
        /// <summary>
        /// Gets all email templates
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/templates
        /// Operation Id: EmailTemplate_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementEmailTemplateResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementEmailTemplateResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new ApiManagementEmailTemplateCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);

        /// <summary>
        /// Gets all email templates
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/templates
        /// Operation Id: EmailTemplate_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementEmailTemplateResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementEmailTemplateResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetAll(new ApiManagementEmailTemplateCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);
    }
}
