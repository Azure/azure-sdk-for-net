// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Tests
{
    internal class FakeTypeLocator
    {
        private Type type;

        public FakeTypeLocator(Type type)
        {
            this.type = type;
        }
    }
}