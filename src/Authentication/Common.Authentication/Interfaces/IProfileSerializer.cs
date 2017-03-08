// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Common.Authentication.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Common.Authentication
{
    public interface IProfileSerializer
    {
        string Serialize(AzureSMProfile profile);

        bool Deserialize(string contents, AzureSMProfile profile);

        IList<string> DeserializeErrors { get; }
    }
}
