// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.DataMovement.Tests
{
    public class MockStorageResource : StorageResource
    {
        public override Uri Uri => new Uri("https://microsoft.com");

        protected internal override bool IsContainer => false;
    }
}
