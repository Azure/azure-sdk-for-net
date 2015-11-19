// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Client
{
    using System;

    /// <summary>
    /// Represents generic information about containers of YARN Applications.
    /// </summary>
    public class ApplicationContainerDetails
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationContainerDetails class.
        /// </summary>
        /// <param name="containerResult">
        /// Result of a REST call, containing details about a container.
        /// </param>
        /// <param name="parentApplicationAttempt">
        /// The parent ApplicationAttemptDetails object to which the container is associated.
        /// </param>
        internal ApplicationContainerDetails(ApplicationContainerGetResult containerResult, ApplicationAttemptDetails parentApplicationAttempt)
        {
            if (containerResult == null)
            {
                throw new ArgumentNullException("containerResult");
            }

            if (parentApplicationAttempt == null)
            {
                throw new ArgumentNullException("parentApplicationAttempt");
            }

            this.ContainerId = containerResult.ContainerId;
            this.NodeId = containerResult.NodeId;
            this.State = containerResult.State;
            this.ExitStatus = containerResult.ExitStatus;
            this.Priority = containerResult.Priority;
            this.DiagnosticInfo = containerResult.DiagnosticInfo;
            this.AllocatedCores = containerResult.AllocatedCores;
            this.AllocatedMemoryInMegabytes = containerResult.AllocatedMemoryInMegabytes;
            this.StartTimeInUtc = Constants.UnixEpoch.AddMilliseconds(containerResult.StartTimeInMillisecondsSinceUnixEpoch);
            this.FinishTimeInUtc = Constants.UnixEpoch.AddMilliseconds(containerResult.FinishTimeInMillisecondsSinceUnixEpoch);

            this.ParentApplicationAttempt = parentApplicationAttempt;
        }

        /// <summary>
        /// Gets the container Id.
        /// </summary>
        public string ContainerId { get; private set; }

        /// <summary>
        /// Gets the node on which this container was assigned.
        /// </summary>
        public string NodeId { get; private set; }

        /// <summary>
        /// Gets the container State.
        /// </summary>
        public string State { get; private set; }

        /// <summary>
        /// Gets the container' exit status.
        /// </summary>
        public string ExitStatus { get; private set; }

        /// <summary>
        /// Gets the container' diagnostic information.
        /// </summary>
        public string DiagnosticInfo { get; private set; }

        /// <summary>
        /// Gets the container' priority.
        /// </summary>
        public int Priority { get; private set; }

        /// <summary>
        /// Gets the number of cores allocated to this container.
        /// </summary>
        public int AllocatedCores { get; private set; }

        /// <summary>
        /// Gets the amount of memory in MB allocated to this container.
        /// </summary>
        public int AllocatedMemoryInMegabytes { get; private set; }

        /// <summary>
        /// Gets the container start time in UTC.
        /// </summary>
        public DateTime StartTimeInUtc { get; private set; }

        /// <summary>
        /// Gets the container finish time in UTC.
        /// </summary>
        public DateTime FinishTimeInUtc { get; private set; }

        /// <summary>
        /// Gets the application attempt to which this container was assigned.
        /// </summary>
        public ApplicationAttemptDetails ParentApplicationAttempt { get; private set; }

        /// <summary>
        /// Gets the container' state as an enum.
        /// </summary>
        /// <returns>
        /// Returns the container' state as an enum.
        /// </returns>
        public ApplicationContainerState GetApplicationContainerStateAsEnum()
        {
            ApplicationContainerState state;
            if (!Enum.TryParse(this.State, true, out state))
            {
                state = ApplicationContainerState.Unknown;
            }

            return state;
        }
    }
}