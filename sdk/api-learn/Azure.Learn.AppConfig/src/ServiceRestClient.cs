// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using Azure.Core;
using Azure.Learn.AppConfig.Models;

namespace Azure.Learn.AppConfig
{
    internal partial class ServiceRestClient
    {

        /// <summary> Gets a single key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> The label of the key-value to retrieve. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public async Task<ResponseWithHeaders<ConfigurationSetting, ServiceGetKeyValueHeaders>> GetKeyValueAsync(string key, string label = null, string acceptDatetime = null, string ifMatch = null, string ifNoneMatch = null, IEnumerable<Get7ItemsItem> select = null, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var message = CreateGetKeyValueRequest(key, label, acceptDatetime, ifMatch, ifNoneMatch, select);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new ServiceGetKeyValueHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ConfigurationSetting value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ConfigurationSetting.DeserializeConfigurationSetting(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                case 304:
                    {
                        return ResponseWithHeaders.FromValue(default(ConfigurationSetting), headers, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Gets a single key-value. </summary>
        /// <param name="key"> The key of the key-value to retrieve. </param>
        /// <param name="label"> The label of the key-value to retrieve. </param>
        /// <param name="acceptDatetime"> Requests the server to respond with the state of the resource at the specified time. </param>
        /// <param name="ifMatch"> Used to perform an operation only if the targeted resource&apos;s etag matches the value provided. </param>
        /// <param name="ifNoneMatch"> Used to perform an operation only if the targeted resource&apos;s etag does not match the value provided. </param>
        /// <param name="select"> Used to select what fields are present in the returned resource(s). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public ResponseWithHeaders<ConfigurationSetting, ServiceGetKeyValueHeaders> GetKeyValue(string key, string label = null, string acceptDatetime = null, string ifMatch = null, string ifNoneMatch = null, IEnumerable<Get7ItemsItem> select = null, CancellationToken cancellationToken = default)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using var message = CreateGetKeyValueRequest(key, label, acceptDatetime, ifMatch, ifNoneMatch, select);
            _pipeline.Send(message, cancellationToken);
            var headers = new ServiceGetKeyValueHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ConfigurationSetting value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ConfigurationSetting.DeserializeConfigurationSetting(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                case 304:
                    {
                        return ResponseWithHeaders.FromValue(default(ConfigurationSetting), headers, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
