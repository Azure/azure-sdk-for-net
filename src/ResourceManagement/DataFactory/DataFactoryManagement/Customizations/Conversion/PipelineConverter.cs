//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.DataFactories.Models;
using Core = Microsoft.Azure.Management.DataFactories.Core.Models;

namespace Microsoft.Azure.Management.DataFactories.Conversion
{
    internal class PipelineConverter :
        CoreTypeConverter<Core.Models.Pipeline, Pipeline, ActivityTypeProperties, GenericActivity>
    {
        /// <summary> 
        /// Convert <paramref name="pipeline"/> to a <see cref="Microsoft.Azure.Management.DataFactories.Core.Models.Pipeline"/> instance.
        /// This method should be called only after type is validated, otherwise type-specific logic will break.
        /// </summary>
        /// <param name="pipeline">
        /// The <see cref="Microsoft.Azure.Management.DataFactories.Core.Models.Pipeline"/> 
        /// instance to convert.
        /// </param>
        /// <returns>A <see cref="Microsoft.Azure.Management.DataFactories.Core.Models.Pipeline"/> 
        /// instance equivalent to <paramref name="pipeline"/>.</returns>
        public override Core.Models.Pipeline ToCoreType(Pipeline pipeline)
        {
            Ensure.IsNotNull(pipeline, "pipeline");
            Ensure.IsNotNull(pipeline.Properties, "pipeline.Properties");
            Ensure.IsNotNull(pipeline.Properties.Activities, "pipeline.Properties.Activities");

            PipelineProperties properties = pipeline.Properties;
            IList<Core.Models.Activity> internalActivities =
                this.ConvertActivitiesToCoreActivities(pipeline.Properties.Activities);

            Core.Models.Pipeline internalPipeline = new Core.Models.Pipeline()
            {
                Name = pipeline.Name,
                Properties = new Core.Models.PipelineProperties()
                {
                    Activities = internalActivities, 
                    Description = properties.Description, 
                    End = properties.End,
                    HubName = properties.HubName, 
                    IsPaused = properties.IsPaused, 
                    ProvisioningState = properties.ProvisioningState,
                    RuntimeInfo = properties.RuntimeInfo, 
                    Start = properties.Start
                }
            };

            return internalPipeline;
        }
        
        /// <summary> 
        /// Convert <paramref name="internalPipeline"/> to a 
        /// <see cref="Microsoft.Azure.Management.DataFactories.Models.Pipeline"/> instance.
        /// </summary>
        /// <param name="internalPipeline">
        /// The <see cref="Microsoft.Azure.Management.DataFactories.Core.Models.Pipeline"/> instance to convert.
        /// </param>
        /// <returns>A <see cref="Pipeline"/> instance equivalent to <paramref name="internalPipeline"/>.</returns>
        public override Pipeline ToWrapperType(Core.Models.Pipeline internalPipeline)
        {
            Ensure.IsNotNull(internalPipeline, "internalPipeline");
            Ensure.IsNotNull(internalPipeline.Properties, "internalPipeline.Properties");
            Ensure.IsNotNull(internalPipeline.Properties.Activities, "internalPipeline.Properties.Activities");

            Core.Models.PipelineProperties properties = internalPipeline.Properties;
            IList<Activity> activities =
                this.ConvertCoreActivitiesToWrapperActivities(internalPipeline.Properties.Activities);

            Pipeline pipeline = new Pipeline()
            {
                Name = internalPipeline.Name,
                Properties = new PipelineProperties()
                {
                    Activities = activities,
                    Description = properties.Description,
                    End = properties.End,
                    HubName = properties.HubName,
                    IsPaused = properties.IsPaused,
                    ProvisioningState = properties.ProvisioningState,
                    RuntimeInfo = properties.RuntimeInfo,
                    Start = properties.Start
                }
            };

            return pipeline;
        }

        /// <summary>
        /// Validate a <see cref="Pipeline"/> instance, specifically its type properties.
        /// </summary>
        /// <param name="pipeline">The <see cref="Pipeline"/> instance to validate.</param>
        public override void ValidateWrappedObject(Pipeline pipeline)
        {
            Ensure.IsNotNull(pipeline, "pipeline");
            Ensure.IsNotNull(pipeline.Properties, "pipeline.Properties");
            Ensure.IsNotNull(pipeline.Properties.Activities, "pipeline.Properties.Activities");

            foreach (Activity activity in pipeline.Properties.Activities)
            {
                this.ValidateActivity(activity);
            }
        }

        private IList<Core.Models.Activity> ConvertActivitiesToCoreActivities(IList<Activity> activities)
        {
            Ensure.IsNotNull(activities, "activities");
            return activities.Select(this.ConvertActivityToCoreType).ToList();
        }

        private IList<Activity> ConvertCoreActivitiesToWrapperActivities(IList<Core.Models.Activity> internalActivities)
        {
            Ensure.IsNotNull(internalActivities, "internalActivities");
            return internalActivities.Select(this.ConvertCoreActivityToWrapperType).ToList();
        }

        private Core.Models.Activity ConvertActivityToCoreType(Activity activity)
        {
            Ensure.IsNotNull(activity, "activity");
            Ensure.IsNotNull(activity.Type, "activity.Type");
            Ensure.IsNotNull(activity.TypeProperties, "activity.TypeProperties");

            string typeProperties = activity.TypeProperties.SerializeObject();

            return new Core.Models.Activity()
                       {
                           Name = activity.Name,
                           Type = activity.Type,
                           TypeProperties = typeProperties,
                           Description = activity.Description,
                           Inputs = activity.Inputs,
                           Outputs = activity.Outputs,
                           LinkedServiceName = activity.LinkedServiceName,
                           Policy = activity.Policy
                       };
        }

        private Activity ConvertCoreActivityToWrapperType(Core.Models.Activity internalActivity)
        {
            Ensure.IsNotNull(internalActivity, "internalActivity");
            Ensure.IsNotNull(internalActivity.Type, "internalActivity.Type");

            Type type;
            ActivityTypeProperties typeProperties = this.DeserializeTypeProperties(
                internalActivity.Type,
                internalActivity.TypeProperties, 
                out type);

            string typeName = GetTypeName(type, internalActivity.Type);
            return new Activity(typeProperties, typeName)
                       {
                           Name = internalActivity.Name,
                           Description = internalActivity.Description,
                           Inputs = internalActivity.Inputs,
                           Outputs = internalActivity.Outputs,
                           LinkedServiceName = internalActivity.LinkedServiceName,
                           Policy = internalActivity.Policy
                       };
        }

        private void ValidateActivity(Activity activity)
        {
            Ensure.IsNotNull(activity, "activity");
            Ensure.IsNotNull(activity.Type, "activity.Type");
            Ensure.IsNotNull(activity.TypeProperties, "activity.TypeProperties");

            Type type;
            if (this.TryGetRegisteredType(activity.Type, out type))
            {
                // We can do validation if a class has been registered for the type
                this.ValidateTypeProperties(activity.TypeProperties, type);
            }
        }
    }
}
