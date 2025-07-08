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

            if (internalModel.Kind == RetentionPolicyKind.None)
            {
                return ChatRetentionPolicy.None();
            }

            if (internalModel.Kind == RetentionPolicyKind.ThreadCreationDate &&
                internalModel is ThreadCreationDateRetentionPolicyInternal tcd)
            {
                return ChatRetentionPolicy.ThreadCreationDate(tcd.DeleteThreadAfterDays);
            }

            throw new NotSupportedException($"Unsupported kind: {internalModel.Kind}");
        }

        public static ChatRetentionPolicyInternal ConvertBack(ChatRetentionPolicy model)
        {
            if (model == null)
                return null;

            if (model.Kind == RetentionPolicyKind.None)
            {
                return new NoneRetentionPolicyInternal();
            }

            if (model.Kind == RetentionPolicyKind.ThreadCreationDate &&
                 model is ThreadCreationDateRetentionPolicy typedModel)
            {
                return new ThreadCreationDateRetentionPolicyInternal(typedModel.DeleteThreadAfterDays);
            }

            throw new NotSupportedException($"Unsupported retention policy model kind: {model.Kind}");
        }
    }
}
