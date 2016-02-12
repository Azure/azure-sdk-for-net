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
using Microsoft.Azure.Management.DataFactories.Common.Models;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// Pipeline properties
    /// </summary>
    public class PipelineProperties
    {
        /// <summary>
        /// Pipeline description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Activities that belong to the pipeline.
        /// </summary>
        [AdfRequired]
        public IList<Activity> Activities { get; set; }

        /// <summary>                                                         
        /// The start time of the pipeline. The start and end time  
        /// can both be empty to create a pipeline; they must both have values
        /// to set an active period for the pipeline and one cannot have a    
        /// value if the other does not.                                      
        /// </summary>                                                        
        public DateTime? Start { get; set; }

        /// <summary>
        /// The end time of the pipeline. The start and end time can
        /// both be empty to create a pipeline; they must both have values to
        /// set an active period for the pipeline and one cannot have a value
        /// if the other does not.
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>
        /// The status of the pipeline. Pipeline is paused when boolean is set to true.
        /// </summary>
        public bool? IsPaused { get; set; }

        /// <summary>
        /// Pipeline runtime information.
        /// </summary>
#if ADF_SCHEMA_GEN
        [AdfReadonly]
#endif
        public PipelineRuntimeInfo RuntimeInfo { get; set; }

        /// <summary>
        /// The provisioning state of the pipeline.
        /// </summary>
#if ADF_SCHEMA_GEN
        [AdfReadonly]
#endif
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Error in processing pipeline request.
        /// </summary>
#if ADF_SCHEMA_GEN
        [AdfReadonly]
#endif
        public string ErrorMessage { get; set; }
        
        /// <summary>
        /// The name of the Hub that this pipeline belongs to.
        /// </summary>
        public string HubName { get; set; }
        
        /// <summary>
        /// Optional. Duration of time after creation for which the pipeline is valid
        /// and should remain provisioned. The pipeline will be deleted automatically
        /// once it reaches the expiration time if it does not have any active or pending runs        
        /// </summary>
        public TimeSpan? ExpirationTime { get; set; }

        /// <summary>
        /// Optional. The method of scheduling runs for the pipeline. Must be
        /// one of <see cref="PipelineMode"/>.
        /// </summary>
        public string PipelineMode { get; set; }

        /// <summary>
        /// Optional. List of datasets to be used by activities defined in the
        /// pipeline. This can be used to define datasets that are specific to
        /// this pipeline and not defined within the datafactory. Datasets
        /// defined within this pipeline can only be used by this pipeline and
        /// cannot be shared.
        /// </summary>
        public IList<Dataset> Datasets { get; set; }
        

        public PipelineProperties()
        {
        }

        public PipelineProperties(IList<Activity> activities)
            : this()
        {
            Ensure.IsNotNull(activities, "activities");
            this.Activities = activities;
        }
    }
}
