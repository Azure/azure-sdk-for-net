// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("ComponentsIfu7BjSchemasTasksstatePropertiesTasksPropertiesEntitylinkingtasksItemsAllof1")]
    internal partial class EntityLinkingTasksItemsProperties
    {
        /// <summary> Initializes a new instance of EntityRecognitionPiiTasksItemProperties. </summary>
        internal EntityLinkingTasksItemsProperties()
        {
        }

        /// <summary> Initializes a new instance of EntityLinkingTasksItemsProperties. </summary>
        /// <param name="results"> . </param>
        internal EntityLinkingTasksItemsProperties(EntityLinkingResult results)
        {
            Results = results;
        }
        public EntityLinkingResult Results { get; }
    }
}
