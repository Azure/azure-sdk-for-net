// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Communication.Email
{
    [CodeGenModel("EmailSendStatus")]
    [CodeGenSuppress("EmailSendStatus", typeof(string), typeof(string), typeof(string))]
    public partial struct EmailSendStatus
    {
        public static class Values
        {
            /// <summary> Canceled </summary>
            public const string Canceled = "Canceled";
            /// <summary> Failed </summary>
            public const string Failed = "Failed";
            /// <summary> NotStarted </summary>
            public const string NotStarted = "NotStarted";
            /// <summary> Running </summary>
            public const string Running = "Running";
            /// <summary> Succeeded </summary>
            public const string Succeeded = "Succeeded";
        }
    }
}
