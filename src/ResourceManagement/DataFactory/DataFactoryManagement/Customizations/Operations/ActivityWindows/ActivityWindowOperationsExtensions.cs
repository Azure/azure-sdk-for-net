// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using Microsoft.Azure.Management.DataFactories.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.DataFactories
{
    public static partial class ActivityWindowOperationsExtensions
    {
        /// <summary>
        /// Gets the first page of activity window instances for a data factory
        /// with the link to the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IActivityWindowOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Activity windows list optional filter parameters.
        /// </param>
        /// <returns>
        /// The List activity windows operation response.
        /// </returns>
        public static ActivityWindowListResponse List(this IActivityWindowOperations operations, ActivityWindowsByDataFactoryListParameters parameters)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IActivityWindowOperations)s).ListAsync(parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the first page of activity window instances for a data factory
        /// with the link to the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IActivityWindowOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Activity windows list optional filter parameters.
        /// </param>
        /// <returns>
        /// The List activity windows operation response.
        /// </returns>
        public static Task<ActivityWindowListResponse> ListAsync(this IActivityWindowOperations operations, ActivityWindowsByDataFactoryListParameters parameters)
        {
            return operations.ListAsync(parameters, CancellationToken.None);
        }

        /// <summary>
        /// Gets the first page of activity window instances for a dataset with
        /// the link to the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IActivityWindowOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Activity windows list by dataset parameters.
        /// </param>
        /// <returns>
        /// The List activity windows operation response.
        /// </returns>
        public static ActivityWindowListResponse List(this IActivityWindowOperations operations, ActivityWindowsByDatasetListParameters parameters)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IActivityWindowOperations)s).ListAsync(parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the first page of activity window instances for a dataset with
        /// the link to the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IActivityWindowOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Activity windows list by dataset parameters.
        /// </param>
        /// <returns>
        /// The List activity windows operation response.
        /// </returns>
        public static Task<ActivityWindowListResponse> ListAsync(this IActivityWindowOperations operations, ActivityWindowsByDatasetListParameters parameters)
        {
            return operations.ListAsync(parameters, CancellationToken.None);
        }

        /// <summary>
        /// Gets the first page of activity window instances for a pipeline
        /// with the link to the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IActivityWindowOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Activity windows list by pipeline parameters.
        /// </param>
        /// <returns>
        /// The List activity windows operation response.
        /// </returns>
        public static ActivityWindowListResponse List(this IActivityWindowOperations operations, ActivityWindowsByPipelineListParameters parameters)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IActivityWindowOperations)s).ListAsync(parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the first page of activity window instances for a pipeline
        /// with the link to the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IActivityWindowOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Activity windows list by pipeline parameters.
        /// </param>
        /// <returns>
        /// The List activity windows operation response.
        /// </returns>
        public static Task<ActivityWindowListResponse> ListAsync(this IActivityWindowOperations operations, ActivityWindowsByPipelineListParameters parameters)
        {
            return operations.ListAsync(parameters, CancellationToken.None);
        }

        /// <summary>
        /// Gets the first page of activity window instances for a pipeline
        /// activity with the link to the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IActivityWindowOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Activity windows list by pipeline activity parameters.
        /// </param>
        /// <returns>
        /// The List activity windows operation response.
        /// </returns>
        public static ActivityWindowListResponse List(this IActivityWindowOperations operations, ActivityWindowsByActivityListParameters parameters)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IActivityWindowOperations)s).ListAsync(parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Use List(ActivityWindowsByActivityListParameters parameters) instead. This will be deprecated soon.
        /// Gets the first page of activity window instances for a pipeline
        /// activity with the link to the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IActivityWindowOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Activity windows list by pipeline activity parameters.
        /// </param>
        /// <returns>
        /// The List activity windows operation response.
        /// </returns>
        public static ActivityWindowListResponse ListByPipelineActivity(this IActivityWindowOperations operations, ActivityWindowsByActivityListParameters parameters)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IActivityWindowOperations)s).ListAsync(parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the first page of activity window instances for a pipeline
        /// activity with the link to the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IActivityWindowOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Activity windows list by pipeline activity parameters.
        /// </param>
        /// <returns>
        /// The List activity windows operation response.
        /// </returns>
        public static Task<ActivityWindowListResponse> ListAsync(this IActivityWindowOperations operations, ActivityWindowsByActivityListParameters parameters)
        {
            return operations.ListAsync(parameters, CancellationToken.None);
        }

        /// <summary>
        /// Gets the next page of activity window instances with the link to
        /// the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IActivityWindowOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The URL to the next page of activity windows.
        /// </param>
        /// <param name='parameters'>
        /// Required. Filter parameters for activity windows list.
        /// </param>
        /// <returns>
        /// The List activity windows operation response.
        /// </returns>
        public static ActivityWindowListResponse ListNext(this IActivityWindowOperations operations, string nextLink, ActivityWindowsByDataFactoryListParameters parameters)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IActivityWindowOperations)s).ListNextAsync(nextLink, parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the next page of activity window instances with the link to
        /// the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IActivityWindowOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The URL to the next page of activity windows.
        /// </param>
        /// <param name='parameters'>
        /// Required. Filter parameters for activity windows list.
        /// </param>
        /// <returns>
        /// The List activity windows operation response.
        /// </returns>
        public static Task<ActivityWindowListResponse> ListNextAsync(this IActivityWindowOperations operations, string nextLink, ActivityWindowsByDataFactoryListParameters parameters)
        {
            return operations.ListNextAsync(nextLink, parameters, CancellationToken.None);
        }

        /// <summary>
        /// Gets the next page of activity window instances with the link to
        /// the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IActivityWindowOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The URL to the next page of activity windows.
        /// </param>
        /// <param name='parameters'>
        /// Required. Filter parameters for activity windows list.
        /// </param>
        /// <returns>
        /// The List activity windows operation response.
        /// </returns>
        public static ActivityWindowListResponse ListNext(this IActivityWindowOperations operations, string nextLink, ActivityWindowsByDatasetListParameters parameters)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IActivityWindowOperations)s).ListNextAsync(nextLink, parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the next page of activity window instances with the link to
        /// the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IActivityWindowOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The URL to the next page of activity windows.
        /// </param>
        /// <param name='parameters'>
        /// Required. Filter parameters for activity windows list.
        /// </param>
        /// <returns>
        /// The List activity windows operation response.
        /// </returns>
        public static Task<ActivityWindowListResponse> ListNextAsync(this IActivityWindowOperations operations, string nextLink, ActivityWindowsByDatasetListParameters parameters)
        {
            return operations.ListNextAsync(nextLink, parameters, CancellationToken.None);
        }

        /// <summary>
        /// Gets the next page of activity window instances with the link to
        /// the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IActivityWindowOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The URL to the next page of activity windows.
        /// </param>
        /// <param name='parameters'>
        /// Required. Filter parameters for activity windows list.
        /// </param>
        /// <returns>
        /// The List activity windows operation response.
        /// </returns>
        public static ActivityWindowListResponse ListNext(this IActivityWindowOperations operations, string nextLink, ActivityWindowsByPipelineListParameters parameters)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IActivityWindowOperations)s).ListNextAsync(nextLink, parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the next page of activity window instances with the link to
        /// the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IActivityWindowOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The URL to the next page of activity windows.
        /// </param>
        /// <param name='parameters'>
        /// Required. Filter parameters for activity windows list.
        /// </param>
        /// <returns>
        /// The List activity windows operation response.
        /// </returns>
        public static Task<ActivityWindowListResponse> ListNextAsync(this IActivityWindowOperations operations, string nextLink, ActivityWindowsByPipelineListParameters parameters)
        {
            return operations.ListNextAsync(nextLink, parameters, CancellationToken.None);
        }

        /// <summary>
        /// Gets the next page of activity window instances with the link to
        /// the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IActivityWindowOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The URL to the next page of activity windows.
        /// </param>
        /// <param name='parameters'>
        /// Required. Filter parameters for activity windows list.
        /// </param>
        /// <returns>
        /// The List activity windows operation response.
        /// </returns>
        public static ActivityWindowListResponse ListNext(this IActivityWindowOperations operations, string nextLink, ActivityWindowsByActivityListParameters parameters)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IActivityWindowOperations)s).ListNextAsync(nextLink, parameters);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the next page of activity window instances with the link to
        /// the next page.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.DataFactories.Core.IActivityWindowOperations.
        /// </param>
        /// <param name='nextLink'>
        /// Required. The URL to the next page of activity windows.
        /// </param>
        /// <param name='parameters'>
        /// Required. Filter parameters for activity windows list.
        /// </param>
        /// <returns>
        /// The List activity windows operation response.
        /// </returns>
        public static Task<ActivityWindowListResponse> ListNextAsync(this IActivityWindowOperations operations, string nextLink, ActivityWindowsByActivityListParameters parameters)
        {
            return operations.ListNextAsync(nextLink, parameters, CancellationToken.None);
        }
    }
}
