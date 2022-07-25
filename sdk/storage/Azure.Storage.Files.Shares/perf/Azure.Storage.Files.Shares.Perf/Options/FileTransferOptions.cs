// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.Storage.Files.Shares.Perf.Options
{
    public class FileTransferOptions : SizeOptions, IShareClientOptionsProvider
    {
        [Option("transfer-validation")]
        public ValidationAlgorithm? TransferValidationAlgorithm { get; set; }

        ShareClientOptions IShareClientOptionsProvider.ClientOptions
        {
            get
            {
                return new ShareClientOptions
                {
                    UploadTransferValidationOptions = TransferValidationAlgorithm.HasValue
                        ? new UploadTransferValidationOptions
                        {
                            Algorithm = TransferValidationAlgorithm.Value
                        }
                        : default,
                    DownloadTransferValidationOptions = TransferValidationAlgorithm.HasValue
                        ? new DownloadTransferValidationOptions
                        {
                            Algorithm = TransferValidationAlgorithm.Value
                        }
                        : default,
                };
            }
        }
    }
}