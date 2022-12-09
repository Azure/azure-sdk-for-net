// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager
{
    /// <summary>
    /// AzureStackProfile represents the information of an Azure Stack profile.
    /// </summary>
    public enum AzureStackProfile
    {
        /// <summary> The 2020-09-01-hybrid profile. </summary>
        Profile20200901Hybrid
    }

#pragma warning disable SA1649 // File name should match first type name
    internal static class AzureStackProfileExtensions
#pragma warning restore SA1649 // File name should match first type name
    {
        internal static string GetFileName(this AzureStackProfile profile)
        {
            return profile switch
            {
                AzureStackProfile.Profile20200901Hybrid => "2020-09-01-hybrid.json",
                _ => throw new ArgumentOutOfRangeException(nameof(profile), profile, null)
            };
        }
    }
}
