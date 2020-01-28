// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework.Internal;

namespace Azure.Core.Testing
{
    public interface ITestAttribute
    {
        void Apply(Test test, TestProperties testProperties);
    }
}
