// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Chaos.Tests.TestDependencies
{
    internal static class TestConstants
    {
        internal const string ComputeNamespace = "Microsoft.Compute";
        internal const string VmssResourceName = "virtualMachineScaleSets";
        internal const string VmssTargetName = "Microsoft-VirtualMachineScaleSet";
        internal const string VmssShutdownCapabilityName = "Shutdown-2.0";

        internal const string ExperimentNamePrefix = "sdktest-chaos-";
        internal const string VmssNameFormat = "chaossdk-vmss-{0}-{1}";
        internal const string ExperimentForExecutionNameFormat = "{0}execution-{1}";
        internal const string DotNetFrameworkName = ".NET Framework";
        internal const string DotNetCoreName = ".NET Core";
    }
}
