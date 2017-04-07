// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Linq;
using System.Net.Http;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;

namespace Microsoft.Azure.Management.RecoveryServices
{
    public partial class RecoveryServicesClient
    {
        bool DisableDispose { get; set; }

        protected RecoveryServicesClient(HttpClient httpClient, params DelegatingHandler[] handlers)
        {
            InitializeHttpClient(httpClient, null, handlers);
            Initialize();
        }

        public RecoveryServicesClient(System.Uri baseUri, ServiceClientCredentials credentials, HttpClient httpClient, bool disableDispose, params DelegatingHandler[] handlers)
            : this(httpClient, handlers)
        {
            if (baseUri == null)
            {
                throw new System.ArgumentNullException("baseUri");
            }
            if (credentials == null)
            {
                throw new System.ArgumentNullException("credentials");
            }
            BaseUri = baseUri;
            Credentials = credentials;
            if (Credentials != null)
            {
                Credentials.InitializeServiceClient(this);
            }
            DisableDispose = disableDispose;
        }

        protected override void Dispose(bool disposing)
        {
            if (DisableDispose)
            {
                base.Dispose(disposing);
            }
        }

        partial void CustomInitialize()
        {
            var iso8601TimeSpanConverter = DeserializationSettings.Converters.First(conv => conv is Iso8601TimeSpanConverter);
            if (iso8601TimeSpanConverter != null)
            {
                DeserializationSettings.Converters.Remove(iso8601TimeSpanConverter);
            }
        }
    }
}