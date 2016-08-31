// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Azure.Batch.Protocol.Models;

namespace Microsoft.Azure.Batch
{
    /// <summary>
    /// Performs application-related operations on an Azure Batch account.
    /// </summary>
    public class ApplicationOperations : IInheritedBehaviors
    {
        private readonly BatchClient _parentBatchClient;

#region // constructors

        private ApplicationOperations()
        {
        }

        internal ApplicationOperations(BatchClient parentBatchClient, IEnumerable<BatchClientBehavior> inheritedBehaviors)
        {
            _parentBatchClient = parentBatchClient;

            // set up the behavior inheritance
            InheritUtil.InheritClientBehaviorsAndSetPublicProperty(this, inheritedBehaviors);
        }

#endregion

#region // internal/private

        /// <summary>
        /// allows child objects to access the protocol wrapper and secrets to make verb calls
        /// </summary>
        internal BatchClient ParentBatchClient
        {
            get { return _parentBatchClient; }
        }

#endregion // internal/private


#region IInheritedBehaviors

        /// <summary>
        /// Gets or sets a list of behaviors that modify or customize requests to the Batch service
        /// made via this <see cref="ApplicationOperations"/>.
        /// </summary>
        /// <remarks>
        /// <para>These behaviors are inherited by child objects.</para>
        /// <para>Modifications are applied in the order of the collection. The last write wins.</para>
        /// </remarks>
        public IList<BatchClientBehavior> CustomBehaviors { get; set; }

#endregion IInheritedBehaviors

#region // ApplicationOperations

        /// <summary>
        /// Enumerates the <see cref="ApplicationSummary">applications</see> in the Batch account.
        /// </summary>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for filtering the list and for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="IPagedEnumerable{ApplicationSummary}"/> that can be used to enumerate applications asynchronously or synchronously.</returns>
        /// <remarks>This method returns immediately; the applications are retrieved from the Batch service only when the collection is enumerated.
        /// Retrieval is non-atomic; applications are retrieved in pages during enumeration of the collection.</remarks>
        public IPagedEnumerable<ApplicationSummary> ListApplicationSummaries(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            // craft the behavior manager for this call
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors);

            PagedEnumerable<ApplicationSummary> enumerable = new PagedEnumerable<ApplicationSummary>(
                // the lambda will be the enumerator factory
                () =>
                    {
                        // here is the actual strongly typed enumerator
                        AsyncApplicationSummariesEnumerator typedEnumerator = new AsyncApplicationSummariesEnumerator(this, bhMgr, detailLevel);

                        // here is the base
                        PagedEnumeratorBase<ApplicationSummary> enumeratorBase = typedEnumerator;

                        return enumeratorBase;
                    });

            return enumerable;
        }

        /// <summary>
        /// Gets information about the specified application.
        /// </summary>
        /// <param name="applicationId">The id of the application to get.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>An <see cref="ApplicationSummary"/> containing information about the specified application.</returns>
        /// <remarks>The get application operation runs asynchronously.</remarks>
        public async System.Threading.Tasks.Task<ApplicationSummary> GetApplicationSummaryAsync(string applicationId, DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // create the behavior manager
            BehaviorManager bhMgr = new BehaviorManager(this.CustomBehaviors, additionalBehaviors, detailLevel);

            // start call to server
            var asyncTask = this.ParentBatchClient.ProtocolLayer.GetApplicationSummary(applicationId, bhMgr, cancellationToken);

            var response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            // construct object model ApplicationSummary
            ApplicationSummary applicationSummary = new ApplicationSummary(response.Body);

            return applicationSummary;
        }

        /// <summary>
        /// Gets information about the specified application.
        /// </summary>
        /// <param name="applicationId">The id of the application to get.</param>
        /// <param name="detailLevel">A <see cref="DetailLevel"/> used for controlling which properties are retrieved from the service.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/> and <paramref name="detailLevel"/>.</param>
        /// <returns>An <see cref="ApplicationSummary"/> containing information about the specified application.</returns>
        /// <remarks>This is a blocking operation. For a non-blocking equivalent, see <see cref="GetApplicationSummaryAsync"/>.</remarks>
        public ApplicationSummary GetApplicationSummary(string applicationId, DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            using (System.Threading.Tasks.Task<ApplicationSummary> asyncTask = GetApplicationSummaryAsync(applicationId, detailLevel, additionalBehaviors))
            {
                ApplicationSummary applicationSummary = asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);

                return applicationSummary;     
            }
        }

        #endregion


    }
}
