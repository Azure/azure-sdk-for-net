﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A class representing collection of tag and their operations over a scope. </summary>
    public class TagResourceContainer : ArmContainer
    {
        private ClientDiagnostics _clientDiagnostics;

        /// <summary> Initializes a new instance of the <see cref="TagResourceContainer"/> class for mocking. </summary>
        protected TagResourceContainer()
        {
        }

        internal TagResourceContainer(ArmResource operationsBase) : base(operationsBase)
        {
        }

        private string _subscriptionId
        {
            get
            {
                string subscriptionId;
                Id.TryGetSubscriptionId(out subscriptionId);
                return subscriptionId;
            }
        }

        /// <summary> Represents the REST operations. </summary>
        private TagRestOperations RestClient => new TagRestOperations(_clientDiagnostics, Pipeline, ClientOptions, _subscriptionId, BaseUri);

        private ClientDiagnostics Diagnostics => _clientDiagnostics ??= new ClientDiagnostics(ClientOptions);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceIdentifier Id => base.Id as ResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => Id.ResourceType;

        /// <summary>
        /// Create or update tags with the resource.
        /// </summary>
        /// <param name="parameters"> The tags to create or update. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The created or updated tags. </returns>
        public virtual TagCreateOrUpdateOperation CreateOrUpdate(TagResourceData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (parameters is null)
                throw new ArgumentException($"{nameof(parameters)} provided cannot be null.", nameof(parameters));

            using var scope = Diagnostics.CreateScope("TagsOperations.CreateOrUpdateAtScope");
            scope.Start();

            try
            {
                var response = RestClient.CreateOrUpdateAtScope(Id, parameters, cancellationToken);
                var operation = new TagCreateOrUpdateOperation(this, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update tags with the resource.
        /// </summary>
        /// <param name="parameters"> The tags to create or update. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The created or updated tags. </returns>
        public virtual async Task<TagCreateOrUpdateOperation> CreateOrUpdateAsync(TagResourceData parameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (parameters is null)
                throw new ArgumentException($"{nameof(parameters)} provided cannot be null.", nameof(parameters));

            using var scope = Diagnostics.CreateScope("TagsOperations.CreateOrUpdateAtScope");
            scope.Start();

            try
            {
                var response = await RestClient.CreateOrUpdateAtScopeAsync(Id, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new TagCreateOrUpdateOperation(this, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
