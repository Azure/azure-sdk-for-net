// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using Microsoft.Azure.Search.Models;
    using Xunit;

    public sealed class SoftDeleteColumnDeletionDetectionPolicyTests
    {
        [Fact]
        public void CtorThrowsForMarkerValueOfIncompatibleType()
        {
            ArgumentException error = Assert.Throws<ArgumentException>(
                () => new SoftDeleteColumnDeletionDetectionPolicy("col", DateTime.UtcNow));

            Assert.Contains("Soft-delete marker value must be an integer, string, or bool value.", error.Message);
        }
    }
}
