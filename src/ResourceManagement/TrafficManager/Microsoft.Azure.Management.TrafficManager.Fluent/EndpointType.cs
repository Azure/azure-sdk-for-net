// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    /// <summary>
    /// Possible endpoint types supported in a Traffic manager profile.
    /// </summary>
    public enum EndpointType 
    {
        public EndpointType AZURE;
        public EndpointType EXTERNAL;
        public EndpointType NESTED_PROFILE;
        private EndpointType value;
    }
}