// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Abstract class of operation to invoke service.
    /// </summary>
    public abstract class WebPubSubAction
    {
        internal string ActionName
        {
            get
            {
                return GetType().Name.Replace("Action", "");
            }
        }
    }
}
