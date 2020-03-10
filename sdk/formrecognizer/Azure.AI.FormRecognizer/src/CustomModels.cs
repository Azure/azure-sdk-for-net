// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Custom
{
    internal class CustomModels
    {
        internal CustomModels(Models_internal models)
        {
            SubscriptionProperties = new SubscriptionProperties(models.Summary);
            ModelList = ConvertModelList(models.ModelList);
            NextLink = models.NextLink;
        }

        /// <summary> Summary of all trained custom models. </summary>
        public SubscriptionProperties SubscriptionProperties { get; }
        /// <summary> Collection of trained custom models. </summary>
        public IReadOnlyList<ModelInfo> ModelList { get; }
        /// <summary> Link to the next page of custom models. </summary>
        internal string NextLink { get; }

        private static IReadOnlyList<ModelInfo> ConvertModelList(ICollection<ModelInfo_internal> modelInfos)
        {
            return modelInfos.Select(mi => new ModelInfo(mi)).ToList();
        }
    }
}
