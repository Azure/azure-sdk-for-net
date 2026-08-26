// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Samples.Models
{
    public readonly partial struct ExtensibleTestKind
    {
        private const string ExistingUrlValue = "ExistingUrl";

        public static ExtensibleTestKind ExistingUrl { get; }
    }

    public enum FixedTestKind
    {
        ExistingUrl
    }
}
