// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.DataLake.Store
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// Creates a Data Lake Store account management client.
    /// </summary>
    public partial class DataLakeStoreAccountManagementClient : ServiceClient<DataLakeStoreAccountManagementClient>, IDataLakeStoreAccountManagementClient, IAzureClient
    {
        /// <summary>
        /// Initializes a new instance of the DataLakeStoreManagementClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Gets Azure subscription credentials.
        /// </param>
        /// <param name='userAgentAssemblyVersion'>
        /// Optional. The version string that should be sent in the user-agent header for all requests. The default is the current version of the SDK.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        public DataLakeStoreAccountManagementClient(ServiceClientCredentials credentials, string userAgentAssemblyVersion = "", params DelegatingHandler[] handlers) : this(credentials, handlers)
        {
            DataLakeStoreCustomizationHelper.UpdateUserAgentAssemblyVersion(this, userAgentAssemblyVersion);
        }

        /// <summary>
        /// Initializes a new instance of the DataLakeStoreManagementClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Gets Azure subscription credentials.
        /// </param>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='userAgentAssemblyVersion'>
        /// Optional. The version string that should be sent in the user-agent header for all requests. The default is the current version of the SDK.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        public DataLakeStoreAccountManagementClient(ServiceClientCredentials credentials, HttpClientHandler rootHandler, string userAgentAssemblyVersion = "", params DelegatingHandler[] handlers) : this(credentials, rootHandler, handlers)
        {
            DataLakeStoreCustomizationHelper.UpdateUserAgentAssemblyVersion(this, userAgentAssemblyVersion);
        }

        /// <summary>
        /// Initializes a new instance of the DataLakeStoreManagementClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='credentials'>
        /// Required. Gets Azure subscription credentials.
        /// </param>
        /// <param name='userAgentAssemblyVersion'>
        /// Optional. The version string that should be sent in the user-agent header for all requests. The default is the current version of the SDK.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        public DataLakeStoreAccountManagementClient(Uri baseUri, ServiceClientCredentials credentials, string userAgentAssemblyVersion = "", params DelegatingHandler[] handlers) : this(baseUri, credentials, handlers)
        {
            DataLakeStoreCustomizationHelper.UpdateUserAgentAssemblyVersion(this, userAgentAssemblyVersion);
        }

        /// <summary>
        /// Initializes a new instance of the DataLakeStoreManagementClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='credentials'>
        /// Required. Gets Azure subscription credentials.
        /// </param>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='userAgentAssemblyVersion'>
        /// Optional. The version string that should be sent in the user-agent header for all requests. The default is the current version of the SDK.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        public DataLakeStoreAccountManagementClient(Uri baseUri, ServiceClientCredentials credentials, HttpClientHandler rootHandler, string userAgentAssemblyVersion = "", params DelegatingHandler[] handlers) : this(baseUri, credentials, rootHandler, handlers)
        {
            DataLakeStoreCustomizationHelper.UpdateUserAgentAssemblyVersion(this, userAgentAssemblyVersion);
        } 
    }
}
