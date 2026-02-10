import "../dist/src/tsp-index.js";
import "./decorators.tsp";
import "./private.decorators.tsp";
import "./auth.tsp";

namespace TypeSpec.Http;

using Private;

/**
 * Describes an HTTP response.
 *
 * @template Status The status code of the response.
 */
@doc("")
model Response<Status> {
  @doc("The status code.")
  @statusCode
  statusCode: Status;
}

/**
 * Defines a model with a single property of the given type, marked with `@body`.
 *
 * This can be useful in situations where you cannot use a bare type as the body
 * and it is awkward to add a property.
 *
 * @template Type The type of the model's `body` property.
 */
@doc("")
model Body<Type> {
  @body
  @doc("The body type of the operation request or response.")
  body: Type;
}

/**
 * The Location header contains the URL where the status of the long running operation can be checked.
 */
model LocationHeader {
  @doc("The Location header contains the URL where the status of the long running operation can be checked.")
  @header
  location: string;
}

// Don't put @doc on these, change `getStatusCodeDescription` implementation
// to update the default descriptions for these status codes. This ensures
// that we get consistent emit between different ways to spell the same
// responses in TypeSpec.

/**
 * The request has succeeded.
 */
model OkResponse is Response<200>;
/**
 * The request has succeeded and a new resource has been created as a result.
 */
model CreatedResponse is Response<201>;
/**
 * The request has been accepted for processing, but processing has not yet completed.
 */
model AcceptedResponse is Response<202>;
/**
 * There is no content to send for this request, but the headers may be useful.
 */
model NoContentResponse is Response<204>;
/**
 * The URL of the requested resource has been changed permanently. The new URL is given in the response.
 */
model MovedResponse is Response<301> {
  ...LocationHeader;
}
/**
 * The client has made a conditional request and the resource has not been modified.
 */
model NotModifiedResponse is Response<304>;
/**
 * The server could not understand the request due to invalid syntax.
 */
model BadRequestResponse is Response<400>;
/**
 * Access is unauthorized.
 */
model UnauthorizedResponse is Response<401>;
/**
 * Access is forbidden.
 */
model ForbiddenResponse is Response<403>;
/**
 * The server cannot find the requested resource.
 */
model NotFoundResponse is Response<404>;
/**
 * The request conflicts with the current state of the server.
 */
model ConflictResponse is Response<409>;

/**
 * Produces a new model with the same properties as T, but with `@query`,
 * `@header`, `@body`, and `@path` decorators removed from all properties.
 *
 * @template Data The model to spread as the plain data.
 */
@plainData
model PlainData<Data> {
  ...Data;
}

/**
 * A file in an HTTP request, response, or multipart payload.
 *
 * Files have a special meaning that the HTTP library understands. When the body of an HTTP request, response,
 * or multipart payload is _effectively_ an instance of `TypeSpec.Http.File` or any type that extends it, the
 * operation is treated as a file upload or download.
 *
 * When using file bodies, the fields of the file model are defined to come from particular locations by default:
 *
 * - `contentType`: The `Content-Type` header of the request, response, or multipart payload (CANNOT be overridden or changed).
 * - `contents`: The body of the request, response, or multipart payload (CANNOT be overridden or changed).
 * - `filename`: The `filename` parameter value of the `Content-Disposition` header of the response or multipart payload
 *   (MAY be overridden or changed).
 *
 * A File may be used as a normal structured JSON object in a request or response, if the request specifies an explicit
 * `Content-Type` header. In this case, the entire File model is serialized as if it were any other model. In a JSON payload,
 * it will have a structure like:
 *
 * ```
 * {
 *   "contentType": <string?>,
 *   "filename": <string?>,
 *   "contents": <string, base64>
 * }
 * ```
 *
 * The `contentType` _within_ the file defines what media types the data inside the file can be, but if the specification
 * defines a `Content-Type` for the payload as HTTP metadata, that `Content-Type` metadata defines _how the file is
 * serialized_. See the examples below for more information.
 *
 * NOTE: The `filename` and `contentType` fields are optional. Furthermore, the default location of `filename`
 * (`Content-Disposition: <disposition>; filename=<filename>`) is only valid in HTTP responses and multipart payloads. If
 * you wish to send the `filename` in a request, you must use HTTP metadata decorators to describe the location of the
 * `filename` field. You can combine the metadata decorators with `@visibility` to control when the `filename` location
 * is overridden, as shown in the examples below.
 *
 * @template ContentType The allowed media (MIME) types of the file contents.
 * @template Contents The type of the file contents. This can be `string`, `bytes`, or any scalar that extends them.
 *
 * @example
 * ```tsp
 * // Download a file
 * @get op download(): File;
 *
 * // Upload a file
 * @post op upload(@bodyRoot file: File): void;
 * ```
 *
 * @example
 * ```tsp
 * // Upload and download files in a multipart payload
 * op multipartFormDataUpload(
 *   @multipartBody fields: {
 *     files: HttpPart<File>[];
 *   },
 * ): void;
 *
 * op multipartFormDataDownload(): {
 *   @multipartBody formFields: {
 *     files: HttpPart<File>[];
 *   }
 * };
 * ```
 *
 * @example
 * ```tsp
 * // Declare a custom type of text file, where the filename goes in the path
 * // in requests.
 * model SpecFile extends File<"application/json" | "application/yaml", string> {
 *   // Provide a header that contains the name of the file when created or updated
 *   @header("x-filename")
 *   @path filename: string;
 * }
 *
 * @get op downloadSpec(@path name: string): SpecFile;
 *
 * @post op uploadSpec(@bodyRoot spec: SpecFile): void;
 * ```
 *
 * @example
 * ```tsp
 * // Declare a custom type of binary file
 * model ImageFile extends File {
 *   contentType: "image/png" | "image/jpeg";
 *   @path filename: string;
 * }
 *
 * @get op downloadImage(@path name: string): ImageFile;
 *
 * @post op uploadImage(@bodyRoot image: ImageFile): void;
 * ```
 *
 * @example
 * ```tsp
 * // Use a File as a structured JSON object. The HTTP library will warn you that the File will be serialized as JSON,
 * // so you should suppress the warning if it's really what you want instead of a binary file upload/download.
 *
 * // The response body is a JSON object like `{"contentType":<string?>,"filename":<string?>,"contents":<string>}`
 * @get op downloadTextFileJson(): {
 *   @header contentType: "application/json",
 *   @body file: File<"text/plain", string>,
 * };
 *
 * // The request body is a JSON object like `{"contentType":<string?>,"filename":<string?>,"contents":<base64>}`
 * @post op uploadBinaryFileJson(
 *   @header contentType: "application/json",
 *   @body file: File<"image/png", bytes>,
 * ): void;
 *
 */
@summary("A file in an HTTP request, response, or multipart payload.")
@Private.httpFile
model File<ContentType extends string = string, Contents extends bytes | string = bytes> {
  /**
   * The allowed media (MIME) types of the file contents.
   *
   * In file bodies, this value comes from the `Content-Type` header of the request or response. In JSON bodies,
   * this value is serialized as a field in the response.
   *
   * NOTE: this is not _necessarily_ the same as the `Content-Type` header of the request or response, but
   * it will be for file bodies. It may be different if the file is serialized as a JSON object. It always refers to the
   * _contents_ of the file, and not necessarily the way the file itself is transmitted or serialized.
   */
  @summary("The allowed media (MIME) types of the file contents.")
  contentType?: ContentType;

  /**
   * The name of the file, if any.
   *
   * In file bodies, this value comes from the `filename` parameter of the `Content-Disposition` header of the response
   * or multipart payload. In JSON bodies, this value is serialized as a field in the response.
   *
   * NOTE: By default, `filename` cannot be sent in request payloads and can only be sent in responses and multipart
   * payloads, as the `Content-Disposition` header is not valid in requests. If you want to send the `filename` in a request,
   * you must extend the `File` model and override the `filename` property with a different location defined by HTTP metadata
   * decorators.
   */
  @summary("The name of the file, if any.")
  filename?: string;

  /**
   * The contents of the file.
   *
   * In file bodies, this value comes from the body of the request, response, or multipart payload. In JSON bodies,
   * this value is serialized as a field in the response.
   */
  @summary("The contents of the file.")
  contents: Contents;
}

model HttpPartOptions {
  /** Name of the part when using the array form. */
  name?: string;
}

@Private.httpPart(Type, Options)
model HttpPart<Type, Options extends valueof HttpPartOptions = #{}> {}

model Link {
  target: url;
  rel: string;
  attributes?: Record<unknown>;
}

scalar LinkHeader<T extends Record<url> | Link[]> extends string;

/**
 * Create a MergePatch Request body for updating the given resource Model.
 * The MergePatch request created by this template provides a TypeSpec description of a
 * JSON MergePatch request that can successfully update the given resource.
 * The transformation follows the definition of JSON MergePatch requests in
 * rfc 7396: https://www.rfc-editor.org/rfc/rfc7396,
 * applying the merge-patch transform recursively to keyed types in the resource Model.
 *
 * Using this template in a PATCH request body overrides the `implicitOptionality`
 * setting for PATCH operations and sets `application/merge-patch+json` as the request
 * content-type.
 *
 * @template T The type of the resource to create a MergePatch update request body for.
 * @template NameTemplate A StringTemplate used to name any models created by applying
 * the merge-patch transform to the resource. The default name template is `{name}MergePatchUpdate`,
 * for example, the merge patch transform of model `Widget` is named `WidgetMergePatchUpdate`.
 *
 * @example
 * ```tsp
 * // An operation updating a 'Widget' using merge-patch
 * @patch op update(@body request: MergePatchUpdate<Widget>): Widget;
 * ```
 *
 * @example
 * ```tsp
 * // An operation updating a 'Widget' using merge-patch
 * @patch op update(@bodyRoot request: MergePatchUpdate<Widget>): Widget;
 * ```
 *
 * @example
 * ```tsp
 * // An operation updating a 'Widget' using merge-patch
 * @patch op update(...MergePatchUpdate<Widget>): Widget;
 * ```
 */
@doc("")
@friendlyName(NameTemplate, T)
@mediaTypeHint("application/merge-patch+json")
@applyMergePatch(T, NameTemplate, #{ visibilityMode: Private.MergePatchVisibilityMode.Update })
model MergePatchUpdate<
  T extends Reflection.Model,
  NameTemplate extends valueof string = "{name}MergePatchUpdate"
> {}

/**
 * Create a MergePatch Request body for creating or updating the given resource Model.
 * The MergePatch request created by this template provides a TypeSpec description of a
 * JSON MergePatch request that can successfully create or update the given resource.
 * The transformation follows the definition of JSON MergePatch requests in
 * rfc 7396: https://www.rfc-editor.org/rfc/rfc7396,
 * applying the merge-patch transform recursively to keyed types in the resource Model.
 *
 * Using this template in a PATCH request body overrides the `implicitOptionality`
 * setting for PATCH operations and sets `application/merge-patch+json` as the request
 * content-type.
 *
 * @template T The type of the resource to create a MergePatch update request body for.
 * @template NameTemplate A StringTemplate used to name any models created by applying
 * the merge-patch transform to the resource. The default name template is `{name}MergePatchCreateOrUpdate`,
 * for example, the merge patch transform of model `Widget` is named `WidgetMergePatchCreateOrUpdate`.
 *
 * @example
 * ```tsp
 * // An operation updating a 'Widget' using merge-patch
 * @patch op update(@body request: MergePatchCreateOrUpdate<Widget>): Widget;
 * ```
 *
 * @example
 * ```tsp
 * // An operation updating a 'Widget' using merge-patch
 * @patch op update(@bodyRoot request: MergePatchCreateOrUpdate<Widget>): Widget;
 * ```
 *
 * @example
 * ```tsp
 * // An operation updating a 'Widget' using merge-patch
 * @patch op update(...MergePatchCreateOrUpdate<Widget>): Widget;
 * ```
 */
@doc("")
@friendlyName(NameTemplate, T)
@mediaTypeHint("application/merge-patch+json")
@applyMergePatch(
  T,
  NameTemplate,
  #{ visibilityMode: Private.MergePatchVisibilityMode.CreateOrUpdate }
)
model MergePatchCreateOrUpdate<
  T extends Reflection.Model,
  NameTemplate extends valueof string = "{name}MergePatchCreateOrUpdate"
> {}
