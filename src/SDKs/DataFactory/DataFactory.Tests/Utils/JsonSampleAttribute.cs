// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace DataFactory.Tests.Utils
{
    /// <summary>
    /// Contains JSON sample metadata used by test automation
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class JsonSampleAttribute : Attribute
    {
        public string Version { get; private set; }

        public JsonSampleAttribute()
        {
        }

        public JsonSampleAttribute(string version) 
            : this()
        {
            if (!string.IsNullOrEmpty(version))
            {
                this.Version = version;
            }
        }
    }
}
