// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework.TestProxy;
using System.ClientModel.Primitives;

namespace Microsoft.ClientModel.TestFramework;

[ModelReaderWriterBuildable(typeof(BodyKeySanitizer))]
[ModelReaderWriterBuildable(typeof(BodyRegexSanitizer))]
[ModelReaderWriterBuildable(typeof(CustomDefaultMatcher))]
[ModelReaderWriterBuildable(typeof(HeaderCondition))]
[ModelReaderWriterBuildable(typeof(HeaderRegexSanitizer))]
[ModelReaderWriterBuildable(typeof(HeaderTransform))]
[ModelReaderWriterBuildable(typeof(ProxyOptions))]
[ModelReaderWriterBuildable(typeof(ProxyOptionsTransport))]
[ModelReaderWriterBuildable(typeof(ProxyOptionsTransportCertificationsItem))]
[ModelReaderWriterBuildable(typeof(SanitizerCondition))]
[ModelReaderWriterBuildable(typeof(SanitizersToRemove))]
[ModelReaderWriterBuildable(typeof(TestProxyStartInformation))]
[ModelReaderWriterBuildable(typeof(UriRegexSanitizer))]
public partial class MicrosoftClientModelTestFrameworkContext
{
}
