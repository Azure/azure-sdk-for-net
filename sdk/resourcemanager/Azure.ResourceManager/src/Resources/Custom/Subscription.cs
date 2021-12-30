// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A class representing the operations that can be performed over a specific subscription.
    /// </summary>
    public partial class Subscription : ArmResource
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Subscription"/> class.
        /// </summary>
        /// <param name="clientContext"></param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal Subscription(ClientContext clientContext, ResourceIdentifier id)
            : base(clientContext,  id)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _subscriptionsRestClient = new SubscriptionsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, BaseUri);
            // _featuresRestOperations = new FeaturesRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        /// <summary>
        /// Provides a way to reuse the protected client context.
        /// </summary>
        /// <typeparam name="T"> The actual type returned by the delegate. </typeparam>
        /// <param name="func"> The method to pass the internal properties to. </param>
        /// <returns> Whatever the delegate returns. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual T UseClientContext<T>(Func<Uri, TokenCredential, ArmClientOptions, HttpPipeline, T> func)
        {
            return func(BaseUri, Credential, ClientOptions, Pipeline);
        }

        // /// <summary>
        // /// Gets the predefined tag collection under this subscription.
        // /// </summary>
        // /// <returns> The tags collection. </returns>
        // public virtual PredefinedTagCollection GetPredefinedTags()
        // {
        //     return new PredefinedTagCollection(new ClientContext(ClientOptions, Credential, BaseUri, Pipeline), Id);
        // }

        // /// <summary>
        // /// Gets the provider collection under this subscription.
        // /// </summary>
        // /// <returns> The provider collection. </returns>
        // public virtual ProviderCollection GetProviders()
        // {
        //     return new ProviderCollection(this);
        // }

        // /// <summary> This operation provides all the locations that are available for resource providers; however, each resource provider may support a subset of this list. </summary>
        // /// <param name="cancellationToken"> The cancellation token to use. </param>
        // public virtual AsyncPageable<LocationExpanded> GetLocationsAsync(CancellationToken cancellationToken = default)
        // {
        //     async Task<Page<LocationExpanded>> FirstPageFunc(int? pageSizeHint)
        //     {
        //         using var scope = _clientDiagnostics.CreateScope("Subscription.GetLocations");
        //         scope.Start();
        //         try
        //         {
        //             var response = await _restClient.ListLocationsAsync(Id.Name, cancellationToken).ConfigureAwait(false);
        //             return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
        //         }
        //         catch (Exception e)
        //         {
        //             scope.Failed(e);
        //             throw;
        //         }
        //     }
        //     return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        // }

        // /// <summary> This operation provides all the locations that are available for resource providers; however, each resource provider may support a subset of this list. </summary>
        // /// <param name="cancellationToken"> The cancellation token to use. </param>
        // public virtual Pageable<LocationExpanded> GetLocations(CancellationToken cancellationToken = default)
        // {
        //     Page<LocationExpanded> FirstPageFunc(int? pageSizeHint)
        //     {
        //         using var scope = _clientDiagnostics.CreateScope("Subscription.GetLocations");
        //         scope.Start();
        //         try
        //         {
        //             var response = _restClient.ListLocations(Id.Name, cancellationToken);
        //             return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
        //         }
        //         catch (Exception e)
        //         {
        //             scope.Failed(e);
        //             throw;
        //         }
        //     }
        //     return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        // }

    //     /// <summary>
    //     /// Gets a collection representing all resources as generic objects in the current tenant.
    //     /// </summary>
    //     /// <returns> GenericResource collection. </returns>
    //     public virtual GenericResourceCollection GetGenericResources()
    //     {
    //         return new GenericResourceCollection(new ClientContext(ClientOptions, Credential, BaseUri, Pipeline), Id);
    //     }

    //     /// <summary> Gets all the preview features that are available through AFEC for the subscription. </summary>
    //     /// <param name="cancellationToken"> The cancellation token to use. </param>
    //     public virtual Pageable<Feature> GetFeatures(CancellationToken cancellationToken = default)
    //     {
    //         Page<Feature> FirstPageFunc(int? pageSizeHint)
    //         {
    //             using var scope = _clientDiagnostics.CreateScope("Subscription.GetFeatures");
    //             scope.Start();
    //             try
    //             {
    //                 var response = _featuresRestOperations.ListAll(cancellationToken);
    //                 return Page.FromValues(response.Value.Value.Select(d => new Feature(this, d)), response.Value.NextLink, response.GetRawResponse());
    //             }
    //             catch (Exception e)
    //             {
    //                 scope.Failed(e);
    //                 throw;
    //             }
    //         }
    //         Page<Feature> NextPageFunc(string nextLink, int? pageSizeHint)
    //         {
    //             using var scope = _clientDiagnostics.CreateScope("Subscription.GetFeatures");
    //             scope.Start();
    //             try
    //             {
    //                 var response = _featuresRestOperations.ListAllNextPage(nextLink, cancellationToken);
    //                 return Page.FromValues(response.Value.Value.Select(d => new Feature(this, d)), response.Value.NextLink, response.GetRawResponse());
    //             }
    //             catch (Exception e)
    //             {
    //                 scope.Failed(e);
    //                 throw;
    //             }
    //         }
    //         return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
    //     }

    //     /// <summary> Gets all the preview features that are available through AFEC for the subscription. </summary>
    //     /// <param name="cancellationToken"> The cancellation token to use. </param>
    //     public virtual AsyncPageable<Feature> GetFeaturesAsync(CancellationToken cancellationToken = default)
    //     {
    //         async Task<Page<Feature>> FirstPageFunc(int? pageSizeHint)
    //         {
    //             using var scope = _clientDiagnostics.CreateScope("Subscription.GetFeatures");
    //             scope.Start();
    //             try
    //             {
    //                 var response = await _featuresRestOperations.ListAllAsync(cancellationToken).ConfigureAwait(false);
    //                 return Page.FromValues(response.Value.Value.Select(d => new Feature(this, d)), response.Value.NextLink, response.GetRawResponse());
    //             }
    //             catch (Exception e)
    //             {
    //                 scope.Failed(e);
    //                 throw;
    //             }
    //         }
    //         async Task<Page<Feature>> NextPageFunc(string nextLink, int? pageSizeHint)
    //         {
    //             using var scope = _clientDiagnostics.CreateScope("Subscription.GetFeatures");
    //             scope.Start();
    //             try
    //             {
    //                 var response = await _featuresRestOperations.ListAllNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
    //                 return Page.FromValues(response.Value.Value.Select(d => new Feature(this, d)), response.Value.NextLink, response.GetRawResponse());
    //             }
    //             catch (Exception e)
    //             {
    //                 scope.Failed(e);
    //                 throw;
    //             }
    //         }
    //         return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
    //     }
    // }
    }
}