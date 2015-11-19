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

using Microsoft.Azure.Management.DataFactories.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace Microsoft.Azure.Management.DataFactories.Runtime
{
    internal static class ActivityExecutor
    {
        public static IDictionary<string, string> Execute(object job, string configuration, Action<string> logAction)
        {
            ActivityConfiguration activityConfiguration = Utils.GetActivityConfiguration(configuration);

            IDotNetActivity activityImplementation = job as IDotNetActivity;
            Ensure.IsNotNull(job, "job",
                string.Format(
                    CultureInfo.InvariantCulture,
                    "The type {0} in does not implement IDotNetActivity. Check the configuration and try again.",
                    job == null ? "<null>" : job.GetType().FullName));

            ActivityLogger logger = new ActivityLogger(logAction);

            Collection<LinkedService> linkedServices = new Collection<LinkedService>();
            Collection<Dataset> datasets = new Collection<Dataset>();

            PopulateCollections(activityConfiguration.Inputs, linkedServices, datasets);
            PopulateCollections(activityConfiguration.Outputs, linkedServices, datasets);

            Activity activity = null;
            
            if(activityConfiguration.Pipeline != null &&
               activityConfiguration.Pipeline.Properties != null &&
               activityConfiguration.Pipeline.Properties.Activities != null)
            {
                activity = activityConfiguration.Pipeline.Properties.Activities.FirstOrDefault();
            }

            return activityImplementation.Execute(
                linkedServices,
                datasets,
                activity,
                logger);
        }

        private static void PopulateCollections(IEnumerable<ResolvedTable> resolvedTables, ICollection<LinkedService> linkedServices, ICollection<Dataset> datasets)
        {
            if (resolvedTables == null)
            {
                return;
            }

            foreach (ResolvedTable resolvedTable in resolvedTables)
            {
                if (resolvedTable.LinkedService != null)
                {
                    linkedServices.Add(resolvedTable.LinkedService);
                }

                if (resolvedTable.Dataset != null)
                {
                    datasets.Add(resolvedTable.Dataset);
                }
            }
        }
    }
}
