// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.Query.Models
{
    internal partial class LocalizableString
    {
        public override string ToString() => LocalizedValue;
        public static implicit operator string(LocalizableString localizableString) => localizableString?.LocalizedValue;
    }
}