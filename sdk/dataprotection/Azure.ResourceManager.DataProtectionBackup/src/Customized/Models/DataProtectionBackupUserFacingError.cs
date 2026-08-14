// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public partial class DataProtectionBackupUserFacingError
    {
        /// <summary> Converts a <see cref="DataProtectionBackupUserFacingError"/> instance to a <see cref="Azure.ResponseError"/> instance. </summary>
        internal static Azure.ResponseError ToResponseError(DataProtectionBackupUserFacingError error)
        {
            if (error == null)
            {
                return null;
            }

            return new Azure.ResponseError(error.Code, error.Message);
        }

        /// <summary> Converts a <see cref="Azure.ResponseError"/> instance to a <see cref="DataProtectionBackupUserFacingError"/> instance. </summary>
        internal static DataProtectionBackupUserFacingError ToUserFacingError(Azure.ResponseError error)
        {
            if (error == null)
            {
                return null;
            }

            return new DataProtectionBackupUserFacingError
            {
                Code = error.Code,
                Message = error.Message,
            };
        }
    }
}
