// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class ManagedInstanceServerTrustCertificateCollection : ServerTrustCertificateCollection, IEnumerable<ManagedInstanceServerTrustCertificateResource>, IAsyncEnumerable<ManagedInstanceServerTrustCertificateResource>
    {
        protected ManagedInstanceServerTrustCertificateCollection()
        {
        }

        IEnumerator<ManagedInstanceServerTrustCertificateResource> IEnumerable<ManagedInstanceServerTrustCertificateResource>.GetEnumerator()
        {
            foreach (ServerTrustCertificateResource item in GetAll())
            {
                yield return new ManagedInstanceServerTrustCertificateResource(Client, item.Data);
            }
        }

        async IAsyncEnumerator<ManagedInstanceServerTrustCertificateResource> IAsyncEnumerable<ManagedInstanceServerTrustCertificateResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            await foreach (Page<ServerTrustCertificateResource> page in GetAllAsync(cancellationToken: cancellationToken).AsPages().ConfigureAwait(false))
            {
                foreach (ServerTrustCertificateResource item in page.Values)
                {
                    yield return new ManagedInstanceServerTrustCertificateResource(Client, item.Data);
                }
            }
        }
    }
}
