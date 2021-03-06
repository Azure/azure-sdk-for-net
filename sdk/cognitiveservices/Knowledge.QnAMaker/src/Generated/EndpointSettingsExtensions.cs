// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for EndpointSettings.
    /// </summary>
    public static partial class EndpointSettingsExtensions
    {
            /// <summary>
            /// Gets endpoint settings for an endpoint.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<EndpointSettingsDTO> GetSettingsAsync(this IEndpointSettings operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetSettingsWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates endpoint settings for an endpoint.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='endpointSettingsPayload'>
            /// Post body of the request.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task UpdateSettingsAsync(this IEndpointSettings operations, EndpointSettingsDTO endpointSettingsPayload, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.UpdateSettingsWithHttpMessagesAsync(endpointSettingsPayload, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

    }
}
