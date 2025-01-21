// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;
using Microsoft.Generator.CSharp;
using System;
using System.Threading.Tasks;

namespace Azure.Generator
{
    internal class MgmtPostProcessor : PostProcessor
    {
        public MgmtPostProcessor(string? aspExtensionClassName = null) : base(aspExtensionClassName)
        {
        }

        protected override async Task<bool> IsRootDocument(Document document)
        {
            return IsResourceDocuemtn(document) || await base.IsRootDocument(document);
        }

        private bool IsResourceDocuemtn(Document document)
        {
            return document.Name.EndsWith("Resource.cs", StringComparison.Ordinal);
        }
    }
}
