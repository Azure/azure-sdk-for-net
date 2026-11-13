// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Tests
{
    public class KnowledgeBaseModelComparer : IEqualityComparer<KnowledgeBaseModel>
    {
        public static KnowledgeBaseModelComparer Instance { get; } = new KnowledgeBaseModelComparer();

        private KnowledgeBaseModelComparer()
        {
        }

        public bool Equals(KnowledgeBaseModel x, KnowledgeBaseModel y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            else if (x is null || y is null)
            {
                return false;
            }

            if (x is KnowledgeBaseAzureOpenAIModel xModel &&
                y is KnowledgeBaseAzureOpenAIModel yModel)
            {
                var xParams = xModel.AzureOpenAIParameters;
                var yParams = yModel.AzureOpenAIParameters;

                return xParams.DeploymentName == yParams.DeploymentName &&
                       xParams.ModelName == yParams.ModelName;
            }

            return false;
        }

        public int GetHashCode(KnowledgeBaseModel obj)
        {
            if (obj is null)
            {
                return 0;
            }

            if (obj is KnowledgeBaseAzureOpenAIModel model)
            {
                var parameters = model.AzureOpenAIParameters;
                var builder = new HashCodeBuilder();

                builder.Add(parameters.DeploymentName);
                builder.Add(parameters.ModelName);

                return builder.ToHashCode();
            }

            return 0;
        }
    }
}
