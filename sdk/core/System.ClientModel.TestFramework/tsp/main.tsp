import "@typespec/http";
import "@typespec/http-client-csharp";
import "./models.tsp";

using Http;
@service(#{ title: "System.ClientModel.TestFramework" })
namespace System.ClientModel.TestFramework;

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
} | { 
  @statusCode statusCode: 400 | 500;
  @header("x-ms-error-code") errorCode: string;
  @body error: string;
};

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
} | { 
  @statusCode statusCode: 400 | 500;
  @header("x-ms-error-code") errorCode: string;
  @body error: string;
};

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
} | { 
  @statusCode statusCode: 400 | 500;
  @header("x-ms-error-code") errorCode: string;
  @body error: string;
};

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
} | { 
  @statusCode statusCode: 400 | 500;
  @header("x-ms-error-code") errorCode: string;
  @body error: string;
};