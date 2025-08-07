// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    internal class FriendAttribute : Attribute
    {
        public FriendAttribute(string friendAssembly)
        {
            FriendAssembly = friendAssembly;
        }

        public string FriendAssembly { get; }
    }
}
