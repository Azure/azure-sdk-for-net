// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace SqlVirtualMachine.Tests
{
    public class DeploymentParameters
    {
        public Parameter VirtualNetworkName { get; set; }
        public Parameter VirtualNetworkAddressRange  { get; set; }
        public Parameter SubnetName { get; set; }
        public Parameter SubnetRange { get; set; }
        public ParameterList DNSServerAddress { get; set; }
        public Parameter NetworkSecurityGroupName { get; set; }
        public Parameter Location { get; set; }
    }

    public class Parameter
    {
        public Parameter(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }

    public class ParameterList
    {
        public ParameterList(string[] value)
        {
            Value = new List<string>();
            foreach (string s in value)
            {
                Value.Add(s);
            }
        }

        public List<string> Value;
    }
}