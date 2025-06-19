import "@typespec/http";
import "@typespec/http-client-csharp";
import "./models.tsp";
import "@azure-tools/typespec-client-generator-core";

using Http;
using Azure.ClientGenerator.Core;
@service(#{ title: "Microsoft.ClientModel.TestFramework" })
namespace Microsoft.ClientModel.TestFramework;

@clientName("TestProxyClient")
@access(Access.internal)
namespace TestProxy {
  @doc("Start playback for a test.")
  @route("/playback/start")
  @post
  op StartPlayback(
    @doc("File location of the recording.")
    @body body: StartInformation
    ): {
    @statusCode statusCode: 200;
    @header("x-recording-id") recordingId: string;
    @body response: {};
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
    @body response: {};
  } | TestProxyErrorResponse;

  @doc("Start recording for a test.")
  @route("/record/start")
  @post
  op StartRecord(
    @doc("File location of the recording.")
    @body body: StartInformation
    ): {
    @statusCode statusCode: 200;
    @header("x-recording-id") recordingId: string;
    @body response: {};
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
    recordingSkip: string,
    @doc("Variables for the recording.")
    @body variables: {}
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
@summary("Add a sanitizer.")
op addSanitizer(
  @header("x-abstraction-identifier") 
  @doc("The type of sanitizer.")
  sanitizerType: string,
  
  @header("x-recording-id")
  @doc("The recording ID to apply the sanitizer to.")
  recordingId?: string,
  
  @body sanitizer: unknown
): {
  @statusCode statusCode: 200;
} | TestProxyErrorResponse;

// Body Key Sanitizer overload
@overload(addSanitizer)
@doc("Stop recording for a test.")
op addBodyKeySanitizer(
  sanitizerType: "BodyKeySanitizer",
  recordingId?: string,
  
  @doc("The body for a header regex sanitizer.")
  sanitizer: BodyKeySanitizer
): {
  @statusCode statusCode: 200;
} | TestProxyErrorResponse;

// Header Regex Sanitizer overload
@overload(addSanitizer)
@doc("Add header sanitizer.")
op addHeaderSanitizer(
  sanitizerType: "HeaderRegexSanitizer",
  recordingId?: string,
  
  @doc("The body for a header regex sanitizer.")
  sanitizer: HeaderRegexSanitizer
): {
  @statusCode statusCode: 200;
} | TestProxyErrorResponse;

// URI Regex Sanitizer overload
@overload(addSanitizer)
op addUriSanitizer(
  sanitizerType: "UriRegexSanitizer",
  recordingId?: string,
  
  @doc("The body for a URI regex sanitizer.")
  sanitizer: UriRegexSanitizer
): {
  @statusCode statusCode: 200;
} | TestProxyErrorResponse;

// Body Regex Sanitizer overload
@overload(addSanitizer)
@doc("Add a sanitizer.")
op addBodyRegexSanitizer(
  sanitizerType: "BodyRegexSanitizer",
  recordingId?: string,
  
  @doc("The body for a body regex sanitizer.")
  sanitizer: BodyRegexSanitizer
): {
  @statusCode statusCode: 200;
} | TestProxyErrorResponse;

// Base operation for overloading
@route("/admin/setmatcher")
@summary("Add a matcher.")
op setMatcher(
  @header("x-abstraction-identifier") 
  @doc("The type of matcher.")
  matcherType: string,
  
  @header("x-recording-id")
  @doc("The recording ID to apply the matcher to.")
  recordingId?: string,
  
  @body matcher?: unknown
): {
  @statusCode statusCode: 200;
} | TestProxyErrorResponse;

// Bodiless Matcher overload
@overload(setMatcher)
@summary("Add a bodiless matcher.")
@doc("Add a bodiless matcher.")
op addBodilessMatcher(
  matcherType: "BodilessMatcher",
  recordingId?: string
): {
  @statusCode statusCode: 200;
} | TestProxyErrorResponse;

// Custom Default Matcher overload
@overload(setMatcher)
@summary("Add a custom matcher.")
@doc("Add a custom matcher.")
op addCustomMatcher(
  matcherType: "CustomDefaultMatcher",
  recordingId?: string,
  
  @doc("The body for a custom matcher.")
  matcher: CustomDefaultMatcher
): {
  @statusCode statusCode: 200;
} | TestProxyErrorResponse;

@route("/admin/addtransform")
@summary("Add a transform.")
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
op addHeaderTransform(
  transformType: "HeaderTransform",
  recordingId?: string,
  
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