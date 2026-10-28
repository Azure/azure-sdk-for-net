// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support
{
    /// <summary>
    /// Tracks the options each pass-through test passed in so the test models can assert, from inside the
    /// serialization callbacks, that the options they received are the expected (possibly core-owned) copy.
    /// </summary>
    internal static class PassThroughOptionsTracker
    {
        [ThreadStatic]
        private static ModelReaderWriterOptions? s_defaultOptions;

        internal static Dictionary<object, ModelReaderWriterOptions> OptionsMap { get; } = [];

        internal static ModelReaderWriterOptions? DefaultOptions
        {
            get => s_defaultOptions;
            set => s_defaultOptions = value;
        }

        internal static void AssertOptions(object model, ModelReaderWriterOptions options)
        {
            OptionsMap.TryGetValue(model, out var passedInOptions);
            passedInOptions ??= DefaultOptions;

            if (passedInOptions!.HasProxies && passedInOptions?.IsCoreOwned == false)
            {
                Assert.IsFalse(ReferenceEquals(passedInOptions, options));
                Assert.IsTrue(options.IsCoreOwned);
                Assert.AreEqual(passedInOptions.Format, options.Format);
                var passedInProxies = ProxyOptionsInspector.GetProxies(passedInOptions);
                var optionProxies = ProxyOptionsInspector.GetProxies(options);
                Assert.IsNotNull(passedInProxies);
                Assert.IsNotNull(optionProxies);
                // Proxies dictionary is shared by reference between original and copy
                Assert.AreSame(passedInProxies, optionProxies);
            }
            else
            {
                Assert.IsTrue(ReferenceEquals(passedInOptions, options));
            }
        }
    }
}
