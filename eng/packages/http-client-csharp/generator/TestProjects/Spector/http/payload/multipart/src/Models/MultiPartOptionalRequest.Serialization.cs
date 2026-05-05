// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel;

using Payload.MultiPart;

namespace Payload.MultiPart.Models
{
    public partial class MultiPartOptionalRequest
    {
        internal virtual MultiPartFormContent ToMultipartContent()
        {
            MultiPartFormContent content = new();
            if (Id != null)
            {
                content.Add("id", Id, "text/plain");
            }
            if (ProfileImage != null)
            {
                content.Add("profileImage", ProfileImage);
            }

            return content;
        }
    }
}
