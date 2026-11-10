// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Developer.LoadTesting
{
    public partial class TestAppComponents
    {
        /// <summary> Initializes a new instance of <see cref="TestAppComponents"/>. </summary>
        /// <param name="components"> The application components for the test. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="components"/> is null. </exception>
        public TestAppComponents(IDictionary<string, LoadTestingAppComponent> components) : this()
        {
            if (components is null)
            {
                throw new ArgumentNullException(nameof(components));
            }

            Components = components;
        }
    }
}
