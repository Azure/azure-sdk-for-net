// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.ClientModel.Tests;

public class RequestOptionsTests
{
    // Test for default constructor

    // Test for copy constructor

    // Tests for RequestOptions.Apply
    //   1. Things are applied to message
    //   2. Of the various MessageClassifier precedence rules
    //   3. If PipelineOptions.NetworkTimeout is set/not set
    //   4. For relevant Azure.Core subtypes

    // Tests for AddPolicy
    //   1. For the different valid positions
    //   2. For invalid positions
    //   3. When invalid args are passed
    //   4. When option property (PerCallPolicies/PerTryPolicies) is null
    //   5. When option property (PerCallPolicies/PerTryPolicies) is non-null (array expands correctly)

    // Tests that inner pipeline is frozen as expected
    // Tests that inner pipeline can't be modified after frozen
}
