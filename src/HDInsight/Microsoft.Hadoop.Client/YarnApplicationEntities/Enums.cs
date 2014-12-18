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
    /// <summary>
    /// Enum for the possible application states. This is tied to the state returned by Resource Manager.
    /// DO NOT UPDATE/CHANGE unless the values returned from Resource Manager change. 
    /// </summary>
    public enum ApplicationState
    {
        /// <summary>
        /// Indicates that application state is not known.
        /// </summary>
        Unknown,

        /// <summary>
        /// Indicates that the application has finished.
        /// </summary>
        Finished,

        /// <summary>
        /// Indicates that the application has failed.
        /// </summary>
        Failed,

        /// <summary>
        /// Indicates that the application was killed.
        /// </summary>
        Killed
    }

    /// <summary>
    /// Enum for the the final status of application if finished, as returned by the application itself. 
    /// </summary>
    public enum ApplicationFinalStatus
    {
        /// <summary>
        /// Indicates that application' final status is not known.
        /// </summary>
        Unknown,

        /// <summary>
        /// Indicates that the application has not yet reported its final status. The application may still be running.
        /// </summary>
        Undefined,

        /// <summary>
        /// Indicates that the application has succeeded.
        /// </summary>
        Succeeded,

        /// <summary>
        /// Indicates that the application has failed.
        /// </summary>
        Failed,

        /// <summary>
        /// Indicates that the application was killed.
        /// </summary>
        Killed
    }

    /// <summary>
    /// Enum for the possible application attempt states.
    /// </summary>
    public enum ApplicationAttemptState
    {
        /// <summary>
        /// Indicates that application attempt state is not known.
        /// </summary>
        Unknown,

        /// <summary>
        /// Indicates that the application attempt has finished.
        /// </summary>
        Finished,

        /// <summary>
        /// Indicates that the application has failed.
        /// </summary>
        Failed,

        /// <summary>
        /// Indicates that the application was killed.
        /// </summary>
        Killed
    }

    /// <summary>
    /// Enum for the possible container states.
    /// </summary>
    public enum ApplicationContainerState
    {
        /// <summary>
        /// Indicates that container state is not known.
        /// </summary>
        Unknown,

        /// <summary>
        /// Indicates that the container has completed.
        /// </summary>
        Complete
    }
}