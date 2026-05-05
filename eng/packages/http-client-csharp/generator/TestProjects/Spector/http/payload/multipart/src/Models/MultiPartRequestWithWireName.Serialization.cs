// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel;

using Payload.MultiPart;

namespace Payload.MultiPart.Models
{
    public partial class MultiPartRequestWithWireName
    {
        internal virtual MultiPartFormContent ToMultipartContent()
        {
            MultiPartFormContent content = new();
            content.Add("id", Identifier, "text/plain");
            content.Add("profileImage", Image);

            return content;
        }
    }
}
