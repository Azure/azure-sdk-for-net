// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Template.Models;

namespace Azure.Template
{
    /// <summary> The Pets service client - generated convenience method implementations. </summary>
    public partial class PetsClient
    {
        /// <summary> Returns a pet. Supports eTags. </summary>
        /// <param name="cancellationToken"> The CancellationToken to use.</param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<Pet>> ReadValueAsync(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("PetsClient.ReadValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await ReadAsync(context).ConfigureAwait(false);
                return Response.FromValue(Pet.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Returns a pet. Supports eTags. </summary>
        /// <param name="cancellationToken"> The CancellationToken to use.</param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<Pet> ReadValue(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("PetsClient.ReadValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = Read(context);
                return Response.FromValue(Pet.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> </summary>
        /// <param name="pet"> </param>
        /// <param name="cancellationToken"> The CancellationToken to use.</param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<Pet>> CreateAsync(Pet pet, CancellationToken cancellationToken = default)
        {
            RequestContent content = pet.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await CreateAsync(content, context).ConfigureAwait(false);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <summary> </summary>
        /// <param name="pet"> </param>
        /// <param name="cancellationToken"> The CancellationToken to use.</param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<Pet> Create(Pet pet, CancellationToken cancellationToken = default)
        {
            RequestContent content = pet.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Create(content, context);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <summary> Delete a pet. </summary>
        /// <param name="cancellationToken"> The CancellationToken to use.</param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> DeleteValueAsync(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("PetsClient.DeleteValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                return await DeleteAsync(context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete a pet. </summary>
        /// <param name="cancellationToken"> The CancellationToken to use.</param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response DeleteValue(CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("PetsClient.DeleteValue");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                return Delete(context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static RequestContext DefaultRequestContext = new RequestContext();

        // TODO: move this into Azure.Core.
        internal static RequestContext FromCancellationToken(CancellationToken cancellationToken)
        {
            if (cancellationToken == CancellationToken.None)
            {
                return DefaultRequestContext;
            }

            return new RequestContext() { CancellationToken = cancellationToken };
        }
    }
}
