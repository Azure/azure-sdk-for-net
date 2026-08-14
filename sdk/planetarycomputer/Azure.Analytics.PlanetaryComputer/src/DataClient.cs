// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Analytics.PlanetaryComputer
{
    // Workaround for generator bug: ToObjectFromJson<T>() causes AOT warnings (IL2026, IL3050)
    [CodeGenSuppress("GetTileMatrices", typeof(CancellationToken))]
    [CodeGenSuppress("GetTileMatricesAsync", typeof(CancellationToken))]
    // Workaround for generator bug: an @@override-supplied body on an operation whose underlying
    // parameters are a spread body forwards the body's first property instead of the body itself.
    [CodeGenSuppress("RegisterMosaicsSearch", typeof(RegisterMosaic), typeof(CancellationToken))]
    [CodeGenSuppress("RegisterMosaicsSearchAsync", typeof(RegisterMosaic), typeof(CancellationToken))]
    public partial class DataClient
    {
        #region Generator Workaround - spread body forwarded as its first property

        /// <summary> Register a Search query. </summary>
        /// <param name="body"> The request body for the registerMosaicsSearch request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<TilerMosaicSearchRegistrationResult> RegisterMosaicsSearch(RegisterMosaic body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            Response result = RegisterMosaicsSearch(RequestContent.Create(body, ModelSerializationExtensions.WireOptions), cancellationToken.ToRequestContext());
            return Response.FromValue((TilerMosaicSearchRegistrationResult)result, result);
        }

        /// <summary> Register a Search query. </summary>
        /// <param name="body"> The request body for the registerMosaicsSearch request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<TilerMosaicSearchRegistrationResult>> RegisterMosaicsSearchAsync(RegisterMosaic body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            Response result = await RegisterMosaicsSearchAsync(RequestContent.Create(body, ModelSerializationExtensions.WireOptions), cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((TilerMosaicSearchRegistrationResult)result, result);
        }

        #endregion

        #region AOT Workaround - ToObjectFromJson<T>() causes IL2026/IL3050 warnings

        /// <summary> Return Matrix List. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<IReadOnlyList<string>> GetTileMatrices(CancellationToken cancellationToken = default)
        {
            Response result = GetTileMatrices(cancellationToken.ToRequestContext());
            return Response.FromValue(DeserializeStringList(result.Content), result);
        }

        /// <summary> Return Matrix List. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<IReadOnlyList<string>>> GetTileMatricesAsync(CancellationToken cancellationToken = default)
        {
            Response result = await GetTileMatricesAsync(cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue(DeserializeStringList(result.Content), result);
        }

        /// <summary>
        /// Deserializes a JSON array of strings from the response content.
        /// This is an AOT-compatible alternative to BinaryData.ToObjectFromJson&lt;IReadOnlyList&lt;string&gt;&gt;().
        /// </summary>
        private static IReadOnlyList<string> DeserializeStringList(BinaryData content)
        {
            using JsonDocument document = JsonDocument.Parse(content);
            var list = new List<string>();
            foreach (JsonElement element in document.RootElement.EnumerateArray())
            {
                list.Add(element.GetString());
            }
            return list;
        }

        #endregion
    }
}
