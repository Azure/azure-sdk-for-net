﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;

namespace Azure.WebJobs.Extensions.Storage.Common.Tests
{
    public class FakeNameResolver : INameResolver
    {
        private IDictionary<string, string> _dict = new Dictionary<string, string>();

        public string Resolve(string name)
        {
            // some name resolvers can't handle null values
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            string value;
            if (_dict.TryGetValue(name, out value))
            {
                return value;
            }

            return null;
        }

        // Fluid method for adding entries.
        public FakeNameResolver Add(string key, string value)
        {
            _dict[key] = value;
            return this;
        }
    }
}
