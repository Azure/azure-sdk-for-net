// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Template.Models;

namespace Azure.Template
{
    /// <summary> The Template service client. </summary>
    public partial class TemplateClient
    {
        /// <summary> The GET operation is applicable to any secret stored in Azure Key Vault. This operation requires the secrets/get permission. </summary>
        /// <param name="secretName"> The name of the secret. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SecretBundle>> GetSecretValueAsync(string secretName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(TemplateClient)}.{nameof(GetSecretValue)}");
            scope.Start();

            try
            {
                RequestContext context = new RequestContext()
                {
                    CancellationToken = cancellationToken,
                };
                Response response = await GetSecretAsync(secretName, context).ConfigureAwait(false);
                SecretBundle value = SecretBundle.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The GET operation is applicable to any secret stored in Azure Key Vault. This operation requires the secrets/get permission. </summary>
        /// <param name="secretName"> The name of the secret. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SecretBundle> GetSecretValue(string secretName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(TemplateClient)}.{nameof(GetSecretValue)}");
            scope.Start();

            try
            {
                RequestContext context = new RequestContext()
                {
                    CancellationToken = cancellationToken,
                };
                Response response = GetSecret(secretName, context);
                SecretBundle value = SecretBundle.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
