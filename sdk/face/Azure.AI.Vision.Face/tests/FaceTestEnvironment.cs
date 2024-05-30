// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.AI.Vision.Face.Tests{
    public class FaceTestEnvironment : TestEnvironment
    {
        public Uri GetUrlVariable(string variableName) => new(GetRecordedVariable(variableName));
    }
}
