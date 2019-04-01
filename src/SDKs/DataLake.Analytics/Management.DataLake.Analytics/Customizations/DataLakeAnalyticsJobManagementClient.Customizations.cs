// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.DataLake.Analytics
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
    /// Creates a Data Lake Store filesystem management client.
    /// </summary>
    public partial class DataLakeAnalyticsJobManagementClient : ServiceClient<DataLakeAnalyticsJobManagementClient>, IDataLakeAnalyticsJobManagementClient, IAzureClient
    {
        /// <summary>
        /// Initializes a new instance of the DataLakeStoreFileSystemManagementClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Gets Azure subscription credentials.
        /// </param>
        /// <param name='userAgentAssemblyVersion'>
        /// Optional. The version string that should be sent in the user-agent header for all requests. The default is the current version of the SDK.
        /// </param>
        /// <param name='adlaJobDnsSuffix'>
        /// Optional. The dns suffix to use for all requests for this client instance. The default is 'azuredatalakeanalytics.net'.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        public DataLakeAnalyticsJobManagementClient(ServiceClientCredentials credentials, string userAgentAssemblyVersion = "", string adlaJobDnsSuffix = DataLakeAnalyticsCustomizationHelper.DefaultAdlaDnsSuffix, params DelegatingHandler[] handlers) : this(credentials, handlers)
        {
            this.AdlaJobDnsSuffix = adlaJobDnsSuffix;
            DataLakeAnalyticsCustomizationHelper.UpdateUserAgentAssemblyVersion(this, userAgentAssemblyVersion);
        }

        /// <summary>
        /// Initializes a new instance of the DataLakeStoreFileSystemManagementClient class.
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
        /// <param name='adlaJobDnsSuffix'>
        /// Optional. The dns suffix to use for all requests for this client instance. The default is 'azuredatalakeanalytics.net'.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        public DataLakeAnalyticsJobManagementClient(ServiceClientCredentials credentials, HttpClientHandler rootHandler, string userAgentAssemblyVersion = "", string adlaJobDnsSuffix = DataLakeAnalyticsCustomizationHelper.DefaultAdlaDnsSuffix, params DelegatingHandler[] handlers) : this(credentials, rootHandler, handlers)
        {
            this.AdlaJobDnsSuffix = adlaJobDnsSuffix;
            DataLakeAnalyticsCustomizationHelper.UpdateUserAgentAssemblyVersion(this, userAgentAssemblyVersion);
        }
    }
}
