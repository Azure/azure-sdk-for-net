# Release History

## 12.0.0-beta.2 (Unreleased)
- [BREAKING CHANGE] Combined `SingleTransferOptions` and `ContainerTransferOptions` into `TransferOptions`.
- Fix to prevent thread starvation on the DataTransfer.AwaitCompletion
- Fix to prevent unnecessary OperationCancelledException's showing up in the TransferOptions.TransferFailed when cancelling a job.

## 12.0.0-beta.1 (2022-12-15)
- This preview is the first release of a ground-up rewrite of our client data movement
libraries to ensure consistency, idiomatic design, productivity, and an
excellent developer experience.  It was created following the Azure SDK Design
Guidelines for .NET at https://azuresdkspecs.z5.web.core.windows.net/DotNetSpec.html.

For more information, please visit: https://aka.ms/azure-sdk-preview1-net.
