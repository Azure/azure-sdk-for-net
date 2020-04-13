// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.FormRecognizer.Training
{
    internal class CustomFormModels
    {
        internal CustomFormModels(Models_internal models)
        {
            AccountProperties = new AccountProperties(models.Summary);
            ModelInfos = ConvertModelList(models.ModelList);
            NextLink = models.NextLink;
        }

        /// <summary> Summary of all trained custom models. </summary>
        public AccountProperties AccountProperties { get; }

        /// <summary> Collection of trained custom models. </summary>
        public IReadOnlyList<CustomFormModelInfo> ModelInfos { get; }

        /// <summary> Link to the next page of custom models. </summary>
        internal string NextLink { get; }

        private static IReadOnlyList<CustomFormModelInfo> ConvertModelList(IReadOnlyList<ModelInfo_internal> modelInfos)
        {
            return modelInfos.Select(mi => new CustomFormModelInfo(mi)).ToList();
        }
    }
}
