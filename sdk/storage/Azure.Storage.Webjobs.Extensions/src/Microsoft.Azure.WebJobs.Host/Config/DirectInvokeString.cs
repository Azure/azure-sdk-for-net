// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Host.Config
{
    // A short string serialization used to rehydrate the trigger. Sometimes this is the contents, and sometimes it's a moniker.  For example:
    // For Blob, the DirectInvokeString is the blob path; whereas the String is the blob contents. (because blobs can be MB large) 
    // For queue, both the DirectInvokeString and String are the queue contents. (because queue messages are generally small)
    public class DirectInvokeString
    {
        public string Value { get; set; }

        public DirectInvokeString(string value)
        {
            this.Value = value;
        }

        public static DirectInvokeString None = new DirectInvokeString("???");
    }
}
