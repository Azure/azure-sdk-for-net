// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    internal static class BlobJobPlanExtensions
    {
        public static string AsString(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public static JobPlanAccessTier ToJobPlanAccessTier(this AccessTier? accessTier)
        {
            if (accessTier == default)
            {
                return JobPlanAccessTier.None;
            }

            if (Enum.TryParse<JobPlanAccessTier>(accessTier.ToString(), out var jobPlanAccessTier))
            {
                return jobPlanAccessTier;
            }

            throw new ArgumentException($"Access tier not currently supported by checkpointer: {accessTier}");
        }
    }
}
