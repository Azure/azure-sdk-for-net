// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.Containers.ContainerRegistry.Models
{
    public class GetTagOptions
    {
        public GetTagOptions(IEnumerable<string> orderBy)
        {
            OrderBy = orderBy.ToList();
        }

        public GetTagOptions(string digest)
        {
            // TODO: preferred naming here?  ForDigest?  Write a sample to see what flows
            Digest = digest;
        }

        // TODO: What OrderBy syntax is supported by the service?  Does it support sending multiple fields?
        // Is it basically OData? ... looks like it's not OData.
        // Reference: https://github.com/Azure/acr-cli/pull/72
        // https://docs.microsoft.com/en-us/rest/api/azure/devops/serviceendpoint/types/list?view=azure-devops-rest-6.0
        public IList<string> OrderBy { get; }

        public string Digest { get; }
    }
}
