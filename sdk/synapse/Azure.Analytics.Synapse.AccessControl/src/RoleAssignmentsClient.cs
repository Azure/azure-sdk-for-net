// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.AccessControl
{
    public partial class RoleAssignmentsClient
    {
        /// <summary> Initializes a new instance of RoleAssignmentsClient. </summary>
        /// <param name="endpoint"> The workspace development endpoint, for example https://myworkspace.dev.azuresynapse.net. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public RoleAssignmentsClient(Uri endpoint, TokenCredential credential, AccessControlClientOptions options = null)
        {
            // This replaces generated code in order to include the ResponsePropertiesPolicy from Core.Experimental in the pipeline.
            // This may be removed in favor of an alternate approach when moved to Core: https://github.com/Azure/azure-sdk-for-net/issues/24699

            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            options ??= new AccessControlClientOptions();

            _clientDiagnostics = new ClientDiagnostics(options);
            _tokenCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new LowLevelCallbackPolicy() }, new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes), new ResponsePropertiesPolicy(options) }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        public virtual Response<RoleAssignmentDetails> GetRoleAssignmentById(string roleAssignmentId)
        {
            Response response = GetRoleAssignmentById(roleAssignmentId, default);
            return Response.FromValue((RoleAssignmentDetails)response, response);
        }

        public virtual async Task<Response<RoleAssignmentDetails>> GetRoleAssignmentByIdAsync(string roleAssignmentId)
        {
            Response response = await GetRoleAssignmentByIdAsync(roleAssignmentId, default).ConfigureAwait(false);
            return Response.FromValue((RoleAssignmentDetails)response, response);
        }
    }
}
