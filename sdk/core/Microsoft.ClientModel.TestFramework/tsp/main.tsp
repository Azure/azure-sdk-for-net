import "@typespec/http";
import "@typespec/http-client-csharp";
import "./models.tsp";
import "@azure-tools/typespec-client-generator-core";

using Http;
using Azure.ClientGenerator.Core;
@service(#{ title: "Microsoft.ClientModel.TestFramework" })
namespace Microsoft.ClientModel.TestFramework;

@clientName("TestProxyClient")
namespace TestProxy {
  @doc("Start playback for a test.")
  @route("/playback/start")
  @post
  op StartPlayback(
    @doc("File location of the recording.")
    @body body: TestProxyStartInformation
    ): {
    @statusCode statusCode: 200;
    @header("x-recording-id") recordingId: string;
    @body response: Record<string>;
  } | TestProxyErrorResponse;

  @doc("Stop playback for a test.")
  @route("/playback/stop")
  @post
  op StopPlayback(
    @header("x-recording-id")
    @doc("The recording ID to stop playback for.")
    recordingId: string;
  ): {
    @statusCode statusCode: 200;
  } | TestProxyErrorResponse;

  @doc("Start recording for a test.")
  @route("/record/start")
  @post
  op StartRecord(
    @doc("File location of the recording.")
    @body body: TestProxyStartInformation
    ): {
    @statusCode statusCode: 200;
    @header("x-recording-id") recordingId: string;
  } | TestProxyErrorResponse;

  @doc("Stop recording a test.")
  @route("/record/stop")
  @post
  op StopRecord(
    @doc("The recording ID.")
    @header("x-recording-id")
    recordingId: string,
    @doc("Set to request-response to skip recording this session.")
    @header("x-recording-skip")
    recordingSkip?: string,
    @doc("Variables for the recording.")
    @body variables: Record<string>
    ): {
    @statusCode statusCode: 200;
  } | TestProxyErrorResponse;

  @doc("Set the proxy recording options.")
  @route("/admin/setrecordingoptions")
  @post
  op SetRecordingTransportOptions(
    @doc("The recording ID.")
    @header("x-recording-id")
    recordingId: string,
    @doc("File location of the recording.")
    @body proxyOptions: ProxyOptions
  ) : {
    @statusCode statusCode: 200;
  } | TestProxyErrorResponse;

  @doc("Removes Sanitizers")
  @route("/admin/removesanitizers")
  @post
  op RemoveSanitizers(
    @doc("The recording ID to apply the transform to.")
    @header("x-recording-id")
    recordingId: string,
    @doc("Sanitizers to remove.")
    @body sanitizers: SanitizersToRemove
  ) : {
    @statusCode statusCode: 200;
  } | TestProxyErrorResponse;

  // Base operation for overloading
@route("/admin/addsanitizer")
@access(Access.internal)
@summary("Add a sanitizer.")
@post
op addSanitizer(
  @header("x-abstraction-identifier") 
  @doc("The type of sanitizer.")
  sanitizerType: SanitizerType,
  
  @header("x-recording-id")
  @doc("The recording ID to apply the sanitizer to.")
  recordingId?: string,
  
  @body sanitizer: unknown
): {
  @statusCode statusCode: 200;
} | TestProxyErrorResponse;

// Body Key Sanitizer overload
@overload(addSanitizer)
@access(Access.internal)
@doc("Stop recording for a test.")
@post
op addBodyKeySanitizer(
  @header("x-abstraction-identifier")
  sanitizerType: SanitizerType,

  @header("x-recording-id")
  @doc("The recording ID to apply the sanitizer to.")
  recordingId?: string,

  @body
  @doc("The body for a header regex sanitizer.")
  sanitizer: BodyKeySanitizer
): {
  @statusCode statusCode: 200;
} | TestProxyErrorResponse;

// Header Regex Sanitizer overload
@overload(addSanitizer)
@doc("Add header sanitizer.")
@access(Access.internal)
@post
op addHeaderSanitizer(
  @header("x-abstraction-identifier")
  sanitizerType: SanitizerType,

  @header("x-recording-id")
  @doc("The recording ID to apply the sanitizer to.")
  recordingId?: string,
  
  @body
  @doc("The body for a header regex sanitizer.")
  sanitizer: HeaderRegexSanitizer
): {
  @statusCode statusCode: 200;
} | TestProxyErrorResponse;

// URI Regex Sanitizer overload
@overload(addSanitizer)
@access(Access.internal)
@post
op addUriSanitizer(
  @header("x-abstraction-identifier")
  sanitizerType: SanitizerType,

  @header("x-recording-id")
  @doc("The recording ID to apply the sanitizer to.")
  recordingId?: string,
  
  @body
  @doc("The URI regex sanitizer configuration.")
  sanitizer: UriRegexSanitizer
): {
  @statusCode statusCode: 200;
} | TestProxyErrorResponse;

// Body Regex Sanitizer overload
@overload(addSanitizer)
@doc("Add a sanitizer.")
@access(Access.internal)
@post
op addBodyRegexSanitizer(
  @header("x-abstraction-identifier")
  sanitizerType: SanitizerType,

  @header("x-recording-id")
  @doc("The recording ID to apply the sanitizer to.")
  recordingId?: string,
  
  @body
  @doc("The body for a body regex sanitizer.")
  sanitizer: BodyRegexSanitizer
): {
  @statusCode statusCode: 200;
} | TestProxyErrorResponse;

@access(Access.internal)
@route("/admin/setmatcher")
@post
@summary("Add a matcher.")
@doc("Add a matcher.")
op setMatcher(
  @header("x-abstraction-identifier")
  @doc("The type of matcher to add.")
  matcherType: MatcherType,
  
  @header("x-recording-id")
  @doc("The recording ID to apply the matcher to.")
  recordingId?: string,
  
  @body 
  @doc("The matcher configuration (only required for CustomDefaultMatcher).")
  matcher?: CustomDefaultMatcher
): {
  @statusCode statusCode: 200;
} | TestProxyErrorResponse;

@route("/admin/addtransform")
@summary("Add a transform.")
@post
op addTransform(
  @header("x-abstraction-identifier") 
  @doc("The type of transform.")
  transformType: string,
  
  @header("x-recording-id")
  @doc("The recording ID to apply the transform to.")
  recordingId?: string,
  
  @body transform: unknown
): {
  @statusCode statusCode: 200;
} | TestProxyErrorResponse;

// Header Transform overload
@overload(addTransform)
@summary("Add a header transform.")
@doc("Add a header transform.")
@access(Access.internal)
@post
op addHeaderTransform(
  @header("x-abstraction-identifier")
  @doc("The type of transform.")
  transformType: string,

  @header("x-recording-id")
  @doc("The recording ID to apply the transform to.")
  recordingId?: string,
  
  @body
  @doc("The body for a header transform.")
  transform: HeaderTransform
): {
  @statusCode statusCode: 200;
} | TestProxyErrorResponse;

@doc("An error response received from the Test Proxy.")
model TestProxyErrorResponse {
  @statusCode statusCode: 400 | 500;
  
  @header("x-ms-error-code")
  @doc("Error code for specific error that occurred.")
  errorCode?: string;
}
};