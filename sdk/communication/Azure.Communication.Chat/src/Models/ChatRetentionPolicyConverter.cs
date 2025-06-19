// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Chat
{
    internal static class ChatRetentionPolicyConverter
    {
        public static ChatRetentionPolicy Convert(ChatRetentionPolicyInternal internalModel)
        {
            if (internalModel == null)
                return null;

            if (internalModel.Kind.Equals(RetentionPolicyKind.ThreadCreationDate))
            {
                return new ThreadCreationDateRetentionPolicy(
                    ((ThreadCreationDateRetentionPolicyInternal)internalModel).DeleteThreadAfterDays);
            }

            if (internalModel.Kind.Equals(RetentionPolicyKind.None))
            {
                return new NoneRetentionPolicy();
            }

            throw new NotSupportedException($"Unsupported kind: {internalModel.Kind}");
        }

        public static ChatRetentionPolicyInternal ConvertBack(ChatRetentionPolicy model)
        {
            if (model == null)
                return null;

            return model switch
            {
                ThreadCreationDateRetentionPolicy policy => new ThreadCreationDateRetentionPolicyInternal(policy.DeleteThreadAfterDays),
                NoneRetentionPolicy => new NoneRetentionPolicyInternal(),
                _ => throw new NotSupportedException($"Unsupported retention policy model type: {model.GetType()}")
            };
        }
    }
}
