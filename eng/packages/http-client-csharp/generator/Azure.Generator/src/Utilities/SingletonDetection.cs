// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Mgmt.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Azure.Generator.Utilities
{
    internal class SingletonDetection
    {
        private static HashSet<string> SingletonKeywords = new(){ "default", "latest", "current" };

        private ConcurrentDictionary<OperationSet, SingletonResourceSuffix?> _singletonResourceCache;

        public SingletonDetection()
        {
            _singletonResourceCache = new ConcurrentDictionary<OperationSet, SingletonResourceSuffix?>();
        }

        public bool IsSingletonResource(OperationSet operationSet)
        {
            return TryGetSingletonResourceSuffix(operationSet, out _);
        }

        private bool TryGetSingletonResourceSuffix(OperationSet operationSet, [MaybeNullWhen(false)] out SingletonResourceSuffix suffix)
        {
            suffix = null;
            if (_singletonResourceCache.TryGetValue(operationSet, out suffix))
                return suffix != null;

            bool result = IsSingleton(operationSet, out var singletonIdSuffix);
            suffix = ParseSingletonIdSuffix(operationSet, singletonIdSuffix);
            _singletonResourceCache.TryAdd(operationSet, suffix);
            return result;
        }

        private static SingletonResourceSuffix? ParseSingletonIdSuffix(OperationSet operationSet, string? singletonIdSuffix)
        {
            if (singletonIdSuffix == null)
                return null;

            var segments = new RequestPath(singletonIdSuffix);

            // check if even segments
            if (segments.Count % 2 != 0)
            {
                throw new InvalidOperationException($"the singleton suffix set for operation set {operationSet.RequestPath} must have even segments, but got {singletonIdSuffix}");
            }

            return SingletonResourceSuffix.Parse(segments);
        }

        private static bool IsSingleton(OperationSet operationSet, [MaybeNullWhen(false)] out string singletonIdSuffix)
        {
            singletonIdSuffix = null;

            //// we should first check the configuration for the singleton settings
            //if (Configuration.MgmtConfiguration.RequestPathToSingletonResource.TryGetValue(operationSet.RequestPath, out singletonIdSuffix))
            //{
            //    // ensure the singletonIdSuffix does not have a slash at the beginning
            //    singletonIdSuffix = singletonIdSuffix.TrimStart('/');
            //    return true;
            //}

            // we cannot find the corresponding request path in the configuration, trying to deduce from the path
            // return false if this is not a resource
            if (!AzureClientPlugin.Instance.ResourceDetection.IsResource(operationSet))
                return false;

            // get the request path
            var currentRequestPath = operationSet.RequestPath;
            // if we are a singleton resource,
            // we need to find the suffix which should be the difference between our path and our parent resource
            var parentRequestPath = AzureClientPlugin.Instance.ParentDetection.GetParentRequestPath(currentRequestPath);
            var diff = parentRequestPath.TrimAncestorFrom(currentRequestPath);
            // if not all of the segment in difference are constant, we cannot be a singleton resource
            if (!diff.Any() || !diff.All(s => RequestPath.IsSegmentConstant(s)))
                return false;

            //// see if the configuration says that we need to honor the dictionary for singletons
            //if (!Configuration.MgmtConfiguration.DoesSingletonRequiresKeyword)
            //{
            //    singletonIdSuffix = string.Join('/', diff.Select(s => s.ConstantValue));
            //    return true;
            //}

            // now we can ensure the last segment of the path is a constant
            var lastSegment = currentRequestPath.Last();
            if (RequestPath.IsSegmentConstant(lastSegment) && SingletonKeywords.Contains(lastSegment))
            {
                singletonIdSuffix = string.Join('/', (IReadOnlyList<string>)diff);
                return true;
            }

            return false;
        }
    }
}
