// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("Components15X8E9LSchemasTasksstatePropertiesTasksPropertiesEntityrecognitionpiitasksItemsAllof1")]
    internal partial class EntityRecognitionPiiTasksItemProperties
    {
        /// <summary> Initializes a new instance of EntityRecognitionPiiTasksItemProperties. </summary>
        internal EntityRecognitionPiiTasksItemProperties()
        {
        }

        /// <summary> Initializes a new instance of EntityRecognitionPiiTasksItemProperties. </summary>
        /// <param name="results"> . </param>
        internal EntityRecognitionPiiTasksItemProperties(PiiEntitiesResult results)
        {
            Results = results;
        }
        public PiiEntitiesResult Results { get; }
    }
}
