// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Azure.Core.Testing
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ServiceVersionAttribute : Attribute, ITestAttribute
    {
        public object Min { get; set; }
        public object Max { get; set; }

        public void Apply(Test test, TestProperties testProperties)
        {
            if (testProperties.ServiceVersion == null)
            {
                return;
            }

            var serviceVersionNumber = Convert.ToInt32(testProperties.ServiceVersion);
            if (Min != null && Convert.ToInt32(Min) > serviceVersionNumber)
            {
                test.RunState = RunState.Ignored;
                test.Properties.Set("_SKIPREASON", $"Test ignored because it's minimum service version is set to {Min}");
            }

            if (Max != null && Convert.ToInt32(Max) < serviceVersionNumber)
            {
                test.RunState = RunState.Ignored;
                test.Properties.Set("_SKIPREASON", $"Test ignored because it's maximum service version is set to {Max}");
            }
        }
    }
}
