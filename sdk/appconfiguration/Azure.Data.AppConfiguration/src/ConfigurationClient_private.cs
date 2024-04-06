// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    public partial class ConfigurationClient
    {
        private const string AcceptDateTimeFormat = "R";
        private const string KeyQueryFilter = "key";
        private const string LabelQueryFilter = "label";
        private const string FieldsQueryFilter = "$select";

        private static async Task<Response<ConfigurationSetting>> CreateResponseAsync(Response response, CancellationToken cancellation)
        {
            ConfigurationSetting result = await ConfigurationServiceSerializer.DeserializeSettingAsync(response.Content, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<ConfigurationSetting> CreateResponse(Response response)
        {
            return Response.FromValue(ConfigurationServiceSerializer.DeserializeSetting(response.Content), response);
        }

        private static Response<ConfigurationSetting> CreateResourceModifiedResponse(Response response)
        {
            return new NoBodyResponse<ConfigurationSetting>(response);
        }

        private static void ParseConnectionString(string connectionString, out Uri uri, out string credential, out byte[] secret)
        {
            Debug.Assert(connectionString != null); // callers check this

            var parsed = ConnectionString.Parse(connectionString);

            uri = new Uri(parsed.GetRequired("Endpoint"));
            credential = parsed.GetRequired("Id");
            try
            {
                secret = Convert.FromBase64String(parsed.GetRequired("Secret"));
            }
            catch (FormatException)
            {
                throw new InvalidOperationException("Specified Secret value isn't a valid base64 string");
            }
        }

        #region nobody wants to see these
        /// <summary>
        /// Check if two ConfigurationSetting instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the ConfigurationSetting.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Creates a Key Value string in reference to the ConfigurationSetting.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
        #endregion
    }
}
