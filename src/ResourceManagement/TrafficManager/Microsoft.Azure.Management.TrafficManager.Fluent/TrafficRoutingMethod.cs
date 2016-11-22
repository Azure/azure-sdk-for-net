// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    /// <summary>
    /// Possible routing methods supported by Traffic manager profile.
    /// </summary>
    public enum TrafficRoutingMethod 
    {
        public TrafficRoutingMethod PERFORMANCE;
        public TrafficRoutingMethod WEIGHTED;
        public TrafficRoutingMethod PRIORITY;
        private TrafficRoutingMethod value;
    }
}