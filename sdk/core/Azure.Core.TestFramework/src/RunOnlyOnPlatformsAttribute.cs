// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OSPlatform = System.Runtime.InteropServices.OSPlatform;

namespace Azure.Core.TestFramework
{
    [AttributeUsage(AttributeTargets.Method|AttributeTargets.Class|AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public class RunOnlyOnPlatformsAttribute : NUnitAttribute, IApplyToTest
    {
        public bool Linux { get; set; }
        public bool OSX { get; set; }
        public bool Windows { get; set; }
        public bool SelfHostedAgent { get; set; }
        public string[] ContainerNames { get; set; }
        public string Reason { get; set; }

        public void ApplyToTest(Test test)
        {
            if (test.RunState != RunState.NotRunnable && !CanRunOnPlatform())
            {
                test.RunState = RunState.Ignored;
                test.Properties.Set(PropertyNames.SkipReason, $"This test can't' run on {RuntimeInformation.OSDescription}. {Reason}");
            }
        }

        private bool CanRunOnPlatform() =>
            Linux && RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
            OSX && RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ||
            Windows && RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ||
            SelfHostedAgent && Environment.GetEnvironmentVariable("SYSTEM_TEAMPROJECTID") == null ||
            ContainerNames != default && ContainerNames.Contains(Environment.GetEnvironmentVariable("DOCKER_CONTAINER_NAME"));
    }
}
