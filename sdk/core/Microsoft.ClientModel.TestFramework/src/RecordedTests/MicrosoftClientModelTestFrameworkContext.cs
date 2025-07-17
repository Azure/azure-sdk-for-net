// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework.TestProxy;
using System.ClientModel.Primitives;

namespace Microsoft.ClientModel.TestFramework;

[ModelReaderWriterBuildable(typeof(AddBodilessMatcherRequest))]
[ModelReaderWriterBuildable(typeof(AddBodyKeySanitizerRequest))]
[ModelReaderWriterBuildable(typeof(AddBodyRegexSanitizerRequest))]
[ModelReaderWriterBuildable(typeof(AddCustomMatcherRequest))]
[ModelReaderWriterBuildable(typeof(AddHeaderSanitizerRequest))]
[ModelReaderWriterBuildable(typeof(AddHeaderTransformRequest))]
[ModelReaderWriterBuildable(typeof(AddUriSanitizerRequest))]
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
[ModelReaderWriterBuildable(typeof(StartInformation))]
[ModelReaderWriterBuildable(typeof(StartPlaybackResponse))]
[ModelReaderWriterBuildable(typeof(StartRecordResponse))]
[ModelReaderWriterBuildable(typeof(StopPlaybackResponse))]
[ModelReaderWriterBuildable(typeof(StopRecordRequest))]
[ModelReaderWriterBuildable(typeof(UriRegexSanitizer))]
public partial class MicrosoftClientModelTestFrameworkContext
{
}
