import "../../dist/src/lib/tsp-index.js";

using TypeSpec.Reflection;

namespace TypeSpec;

/**
 * Typically a short, single-line description.
 * @param summary Summary string.
 *
 * @example
 * ```typespec
 * @summary("This is a pet")
 * model Pet {}
 * ```
 */
extern dec summary(target: unknown, summary: valueof string);

/**
 * Attach a documentation string. Content support CommonMark markdown formatting.
 * @param doc Documentation string
 * @param formatArgs Record with key value pair that can be interpolated in the doc.
 *
 * @example
 * ```typespec
 * @doc("Represent a Pet available in the PetStore")
 * model Pet {}
 * ```
 */
extern dec doc(target: unknown, doc: valueof string, formatArgs?: {});

/**
 * Attach a documentation string to describe the successful return types of an operation.
 * If an operation returns a union of success and errors it only describes the success. See `@errorsDoc` for error documentation.
 * @param doc Documentation string
 *
 * @example
 * ```typespec
 * @returnsDoc("Returns doc")
 * op get(): Pet | NotFound;
 * ```
 */
extern dec returnsDoc(target: Operation, doc: valueof string);

/**
 * Attach a documentation string to describe the error return types of an operation.
 * If an operation returns a union of success and errors it only describes the errors. See `@returnsDoc` for success documentation.
 * @param doc Documentation string
 *
 * @example
 * ```typespec
 * @errorsDoc("Errors doc")
 * op get(): Pet | NotFound;
 * ```
 */
extern dec errorsDoc(target: Operation, doc: valueof string);

/**
 * Service options.
 */
model ServiceOptions {
  /**
   * Title of the service.
   */
  title?: string;
}

/**
 * Mark this namespace as describing a service and configure service properties.
 * @param options Optional configuration for the service.
 *
 * @example
 * ```typespec
 * @service
 * namespace PetStore;
 * ```
 *
 * @example Setting service title
 * ```typespec
 * @service(#{title: "Pet store"})
 * namespace PetStore;
 * ```
 */
extern dec service(target: Namespace, options?: valueof ServiceOptions);

/**
 * Specify that this model is an error type. Operations return error types when the operation has failed.
 *
 * @example
 * ```typespec
 * @error
 * model PetStoreError {
 *   code: string;
 *   message: string;
 * }
 * ```
 */
extern dec error(target: Model);

/**
 * Applies a media type hint to a TypeSpec type. Emitters and libraries may choose to use this hint to determine how a
 * type should be serialized. For example, the `@typespec/http` library will use the media type hint of the response
 * body type as a default `Content-Type` if one is not explicitly specified in the operation.
 *
 * Media types (also known as MIME types) are defined by RFC 6838. The media type hint should be a valid media type
 * string as defined by the RFC, but the decorator does not enforce or validate this constraint.
 *
 * Notes: the applied media type is _only_ a hint. It may be overridden or not used at all. Media type hints are
 * inherited by subtypes. If a media type hint is applied to a model, it will be inherited by all other models that
 * `extend` it unless they delcare their own media type hint.
 *
 * @param mediaType The media type hint to apply to the target type.
 *
 * @example create a model that serializes as XML by default
 *
 * ```tsp
 * @mediaTypeHint("application/xml")
 * model Example {
 *   @visibility(Lifecycle.Read)
 *   id: string;
 *
 *   name: string;
 * }
 * ```
 */
extern dec mediaTypeHint(target: Model | Scalar | Enum | Union, mediaType: valueof string);

// Cannot apply this to the scalar itself. Needs to be applied here so that we don't crash nostdlib scenarios
@@mediaTypeHint(TypeSpec.bytes, "application/octet-stream");

// @@mediaTypeHint(TypeSpec.string "text/plain") -- This is hardcoded in the compiler to avoid circularity
// between the initialization of the string scalar and the `valueof string` required to call the
// `mediaTypeHint` decorator.

/**
 * Specify a known data format hint for this string type. For example `uuid`, `uri`, etc.
 * This differs from the `@pattern` decorator which is meant to specify a regular expression while `@format` accepts a known format name.
 * The format names are open ended and are left to emitter to interpret.
 *
 * @param format format name.
 *
 * @example
 * ```typespec
 * @format("uuid")
 * scalar uuid extends string;
 * ```
 */
extern dec format(target: string | ModelProperty, format: valueof string);

/**
 * Specify the the pattern this string should respect using simple regular expression syntax.
 * The following syntax is allowed: alternations (`|`), quantifiers (`?`, `*`, `+`, and `{ }`), wildcard (`.`), and grouping parentheses.
 * Advanced features like look-around, capture groups, and references are not supported.
 *
 * This decorator may optionally provide a custom validation _message_. Emitters may choose to use the message to provide
 * context when pattern validation fails. For the sake of consistency, the message should be a phrase that describes in
 * plain language what sort of content the pattern attempts to validate. For example, a complex regular expression that
 * validates a GUID string might have a message like "Must be a valid GUID."
 *
 * @param pattern Regular expression.
 * @param validationMessage Optional validation message that may provide context when validation fails.
 *
 * @example
 * ```typespec
 * @pattern("[a-z]+", "Must be a string consisting of only lower case letters and of at least one character.")
 * scalar LowerAlpha extends string;
 * ```
 */
extern dec pattern(
  target: string | bytes | ModelProperty,
  pattern: valueof string,
  validationMessage?: valueof string
);

/**
 * Specify the minimum length this string type should be.
 * @param value Minimum length
 *
 * @example
 * ```typespec
 * @minLength(2)
 * scalar Username extends string;
 * ```
 */
extern dec minLength(target: string | ModelProperty, value: valueof integer);

/**
 * Specify the maximum length this string type should be.
 * @param value Maximum length
 *
 * @example
 * ```typespec
 * @maxLength(20)
 * scalar Username extends string;
 * ```
 */
extern dec maxLength(target: string | ModelProperty, value: valueof integer);

/** Types that can have range limits */
alias RangeLimitableTypes =
  | numeric
  | utcDateTime
  | offsetDateTime
  | plainDate
  | plainTime
  | duration;

/**
 * Specify the minimum number of items this array should have.
 * @param value Minimum number
 *
 * @example
 * ```typespec
 * @minItems(1)
 * model Endpoints is string[];
 * ```
 */
extern dec minItems(target: unknown[] | ModelProperty, value: valueof integer);

/**
 * Specify the maximum number of items this array should have.
 * @param value Maximum number
 *
 * @example
 * ```typespec
 * @maxItems(5)
 * model Endpoints is string[];
 * ```
 */
extern dec maxItems(target: unknown[] | ModelProperty, value: valueof integer);

/**
 * Specify the minimum value this numeric type should be.
 * @param value Minimum value
 *
 * @example
 * ```typespec
 * @minValue(18)
 * scalar Age is int32;
 * ```
 */
extern dec minValue(
  target: RangeLimitableTypes | ModelProperty,
  value: valueof RangeLimitableTypes
);

/**
 * Specify the maximum value this numeric type should be.
 * @param value Maximum value
 *
 * @example
 * ```typespec
 * @maxValue(200)
 * scalar Age is int32;
 * ```
 */
extern dec maxValue(
  target: RangeLimitableTypes | ModelProperty,
  value: valueof RangeLimitableTypes
);

/**
 * Specify the minimum value this numeric type should be, exclusive of the given
 * value.
 * @param value Minimum value
 *
 * @example
 * ```typespec
 * @minValueExclusive(0)
 * scalar distance is float64;
 * ```
 */
extern dec minValueExclusive(
  target: RangeLimitableTypes | ModelProperty,
  value: valueof RangeLimitableTypes
);

/**
 * Specify the maximum value this numeric type should be, exclusive of the given
 * value.
 * @param value Maximum value
 *
 * @example
 * ```typespec
 * @maxValueExclusive(50)
 * scalar distance is float64;
 * ```
 */
extern dec maxValueExclusive(
  target: RangeLimitableTypes | ModelProperty,
  value: valueof RangeLimitableTypes
);

/**
 * Mark this value as a secret value that should be treated carefully to avoid exposure
 *
 * @example
 * ```typespec
 * @secret
 * scalar Password is string;
 * ```
 */
extern dec secret(target: Scalar | ModelProperty | Model | Union | Enum);

/**
 * Attaches a tag to an operation, interface, or namespace. Multiple `@tag` decorators can be specified to attach multiple tags to a TypeSpec element.
 * @param tag Tag value
 */
extern dec tag(target: Namespace | Interface | Operation, tag: valueof string);

/**
 * Specifies how a templated type should name their instances.
 * @param name name the template instance should take
 * @param formatArgs Model with key value used to interpolate the name
 *
 * @example
 * ```typespec
 * @friendlyName("{name}List", T)
 * model List<Item> {
 *   value: Item[];
 *   nextLink: string;
 * }
 * ```
 */
extern dec friendlyName(target: unknown, name: valueof string, formatArgs?: unknown);

/**
 * Mark a model property as the key to identify instances of that type
 * @param altName Name of the property. If not specified, the decorated property name is used.
 *
 * @example
 * ```typespec
 * model Pet {
 *   @key id: string;
 * }
 * ```
 */
extern dec key(target: ModelProperty, altName?: valueof string);

/**
 * Specify this operation is an overload of the given operation.
 * @param overloadbase Base operation that should be a union of all overloads
 *
 * @example
 * ```typespec
 * op upload(data: string | bytes, @header contentType: "text/plain" | "application/octet-stream"): void;
 * @overload(upload)
 * op uploadString(data: string, @header contentType: "text/plain" ): void;
 * @overload(upload)
 * op uploadBytes(data: bytes, @header contentType: "application/octet-stream"): void;
 * ```
 */
extern dec overload(target: Operation, overloadbase: Operation);

/**
 * Provide an alternative name for this type when serialized to the given mime type.
 * @param mimeType Mime type this should apply to. The mime type should be a known mime type as described here https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types/Common_types without any suffix (e.g. `+json`)
 * @param name Alternative name
 *
 * @example
 *
 * ```typespec
 * model Certificate {
 *   @encodedName("application/json", "exp")
 *   @encodedName("application/xml", "expiry")
 *   expireAt: int32;
 * }
 * ```
 *
 * @example Invalid values
 *
 * ```typespec
 * @encodedName("application/merge-patch+json", "exp")
 *              ^ error cannot use subtype
 * ```
 */
extern dec encodedName(target: unknown, mimeType: valueof string, name: valueof string);

/**
 * Options for `@discriminated` decorator.
 */
model DiscriminatedOptions {
  /**
   * How is the discriminated union serialized.
   * @default object
   */
  envelope?: "object" | "none";

  /** Name of the discriminator property */
  discriminatorPropertyName?: string;

  /** Name of the property envelopping the data */
  envelopePropertyName?: string;
}

/**
 * Specify that this union is discriminated.
 * @param options Options to configure the serialization of the discriminated union.
 *
 * @example
 *
 * ```typespec
 * @discriminated
 * union Pet{ cat: Cat, dog: Dog }
 *
 * model Cat { name: string, meow: boolean }
 * model Dog { name: string, bark: boolean }
 * ```
 * Serialized as:
 * ```json
 * {
 *   "kind": "cat",
 *   "value": {
 *     "name": "Whiskers",
 *     "meow": true
 *   }
 * },
 * {
 *   "kind": "dog",
 *   "value": {
 *     "name": "Rex",
 *     "bark": false
 *   }
 * }
 * ```
 *
 * @example Custom property names
 *
 * ```typespec
 * @discriminated(#{discriminatorPropertyName: "dataKind", envelopePropertyName: "data"})
 * union Pet{ cat: Cat, dog: Dog }
 *
 * model Cat { name: string, meow: boolean }
 * model Dog { name: string, bark: boolean }
 * ```
 * Serialized as:
 * ```json
 * {
 *   "dataKind": "cat",
 *   "data": {
 *     "name": "Whiskers",
 *     "meow": true
 *   }
 * },
 * {
 *   "dataKind": "dog",
 *   "data": {
 *     "name": "Rex",
 *     "bark": false
 *   }
 * }
 * ```
 */
extern dec discriminated(target: Union, options?: valueof DiscriminatedOptions);

/**
 * Specify the property to be used to discriminate this type.
 * @param propertyName The property name to use for discrimination
 *
 * @example
 *
 * ```typespec
 * @discriminator("kind")
 * model Pet{ kind: string }
 *
 * model Cat extends Pet {kind: "cat", meow: boolean}
 * model Dog extends Pet  {kind: "dog", bark: boolean}
 * ```
 */
extern dec discriminator(target: Model, propertyName: valueof string);

/**
 * Known encoding to use on utcDateTime or offsetDateTime
 */
enum DateTimeKnownEncoding {
  /**
   * RFC 3339 standard. https://www.ietf.org/rfc/rfc3339.txt
   * Encode to string.
   */
  rfc3339: "rfc3339",

  /**
   * RFC 7231 standard. https://www.ietf.org/rfc/rfc7231.txt
   * Encode to string.
   */
  rfc7231: "rfc7231",

  /**
   * Encode a datetime to a unix timestamp.
   * Unix timestamps are represented as an integer number of seconds since the Unix epoch and usually encoded as an int32.
   */
  unixTimestamp: "unixTimestamp",
}

/**
 * Known encoding to use on duration
 */
enum DurationKnownEncoding {
  /**
   * ISO8601 duration
   */
  ISO8601: "ISO8601",

  /**
   * Encode to integer or float as seconds
   */
  seconds: "seconds",

  /**
   * Encode to integer or float as milliseconds
   */
  milliseconds: "milliseconds",
}

/**
 * Known encoding to use on bytes
 */
enum BytesKnownEncoding {
  /**
   * Encode to Base64
   */
  base64: "base64",

  /**
   * Encode to Base64 Url
   */
  base64url: "base64url",
}

/**
 * Encoding for serializing arrays
 */
enum ArrayEncoding {
  /**
   * Each value of the array is separated by a pipe character (|).
   * Values can only contain | if the underlying protocol supports encoding them.
   * - json -> error
   * - http -> %7C
   */
  pipeDelimited,

  /**
   * Each value of the array is separated by a space character.
   * Values can only contain spaces if the underlying protocol supports encoding them.
   * - json -> error
   * - http -> %20
   */
  spaceDelimited,

  /**
   * Each value of the array is separated by a comma (,).
   * Values can only contain commas if the underlying protocol supports encoding them.
   * - json -> error
   * - http -> %2C
   */
  commaDelimited,

  /**
   * Each value of the array is separated by a newline character (\n).
   * Values can only contain newlines if the underlying protocol supports encoding them.
   * - json -> error
   * - http -> %0A
   */
  newlineDelimited,
}

/**
 * Specify how to encode the target type.
 * @param encodingOrEncodeAs Known name of an encoding or a scalar type to encode as(Only for numeric types to encode as string).
 * @param encodedAs What target type is this being encoded as. Default to string.
 *
 * @example offsetDateTime encoded with rfc7231
 *
 * ```tsp
 * @encode("rfc7231")
 * scalar myDateTime extends offsetDateTime;
 * ```
 *
 * @example utcDateTime encoded with unixTimestamp
 *
 * ```tsp
 * @encode("unixTimestamp", int32)
 * scalar myDateTime extends unixTimestamp;
 * ```
 *
 * @example encode numeric type to string
 *
 * ```tsp
 * model Pet {
 *   @encode(string) id: int64;
 * }
 * ```
 */
extern dec encode(
  target: Scalar | ModelProperty,
  encodingOrEncodeAs: (valueof string | EnumMember) | Scalar,
  encodedAs?: Scalar
);

/** Options for example decorators */
model ExampleOptions {
  /** The title of the example */
  title?: string;

  /** Description of the example */
  description?: string;
}

/**
 * Provide an example value for a data type.
 *
 * @param example Example value.
 * @param options Optional metadata for the example.
 *
 * @example
 *
 * ```tsp
 * @example(#{name: "Fluffy", age: 2})
 * model Pet {
 *  name: string;
 *  age: int32;
 * }
 * ```
 */
extern dec example(
  target: Model | Enum | Scalar | Union | ModelProperty | UnionVariant,
  example: valueof unknown,
  options?: valueof ExampleOptions
);

/**
 * Operation example configuration.
 */
model OperationExample {
  /** Example request body. */
  parameters?: unknown;

  /** Example response body. */
  returnType?: unknown;
}

/**
 * Provide example values for an operation's parameters and corresponding return type.
 *
 * @param example Example value.
 * @param options Optional metadata for the example.
 *
 * @example
 *
 * ```tsp
 * @opExample(#{parameters: #{name: "Fluffy", age: 2}, returnType: #{name: "Fluffy", age: 2, id: "abc"})
 * op createPet(pet: Pet): Pet;
 * ```
 */
extern dec opExample(
  target: Operation,
  example: valueof OperationExample,
  options?: valueof ExampleOptions
);

/**
 * Returns the model with required properties removed.
 */
extern dec withOptionalProperties(target: Model);

/**
 * Returns the model with any default values removed.
 */
extern dec withoutDefaultValues(target: Model);

/**
 * Returns the model with the given properties omitted.
 * @param omit List of properties to omit
 */
extern dec withoutOmittedProperties(target: Model, omit: string | Union);

/**
 * Returns the model with only the given properties included.
 * @param pick List of properties to include
 */
extern dec withPickedProperties(target: Model, pick: string | Union);

//---------------------------------------------------------------------------
// Paging
//---------------------------------------------------------------------------

/**
 * Mark this operation as a `list` operation that returns a paginated list of items.
 */
extern dec list(target: Operation);

/**
 * Pagination property defining the number of items to skip.
 * @example
 * ```tsp
 * model Page<T> {
 *   @pageItems items: T[];
 * }
 * @list op listPets(@offset skip: int32, @pageSize pageSize: int8): Page<Pet>;
 * ```
 */
extern dec offset(target: ModelProperty);

/**
 * Pagination property defining the page index.
 *
 * @example
 * ```tsp
 * model Page<T> {
 *   @pageItems items: T[];
 * }
 * @list op listPets(@pageIndex page: int32, @pageSize pageSize: int8): Page<Pet>;
 * ```
 */
extern dec pageIndex(target: ModelProperty);

/**
 * Specify the pagination parameter that controls the maximum number of items to include in a page.
 *
 * @example
 * ```tsp
 * model Page<T> {
 *   @pageItems items: T[];
 * }
 * @list op listPets(@pageIndex page: int32, @pageSize pageSize: int8): Page<Pet>;
 * ```
 */
extern dec pageSize(target: ModelProperty);

/**
 * Specify the the property that contains the array of page items.
 *
 * @example
 * ```tsp
 * model Page<T> {
 *   @pageItems items: T[];
 * }
 * @list op listPets(@pageIndex page: int32, @pageSize pageSize: int8): Page<Pet>;
 * ```
 */
extern dec pageItems(target: ModelProperty);

/**
 * Pagination property defining the token to get to the next page.
 * It MUST be specified both on the request parameter and the response.
 *
 * @example
 * ```tsp
 * model Page<T> {
 *   @pageItems items: T[];
 *   @continuationToken continuationToken: string;
 * }
 * @list op listPets(@continuationToken continuationToken: string): Page<Pet>;
 * ```
 */
extern dec continuationToken(target: ModelProperty);

/**
 * Pagination property defining a link to the next page.
 *
 * It is expected that navigating to the link will return the same set of responses as the operation that returned the current page.
 *
 * @example
 * ```tsp
 * model Page<T> {
 *   @pageItems items: T[];
 *   @nextLink next: url;
 *   @prevLink prev: url;
 *   @firstLink first: url;
 *   @lastLink last: url;
 * }
 * @list op listPets(): Page<Pet>;
 * ```
 */
extern dec nextLink(target: ModelProperty);

/**
 * Pagination property defining a link to the previous page.
 *
 * It is expected that navigating to the link will return the same set of responses as the operation that returned the current page.
 *
 * @example
 * ```tsp
 * model Page<T> {
 *   @pageItems items: T[];
 *   @nextLink next: url;
 *   @prevLink prev: url;
 *   @firstLink first: url;
 *   @lastLink last: url;
 * }
 * @list op listPets(): Page<Pet>;
 * ```
 */
extern dec prevLink(target: ModelProperty);

/**
 * Pagination property defining a link to the first page.
 *
 * It is expected that navigating to the link will return the same set of responses as the operation that returned the current page.
 *
 * @example
 * ```tsp
 * model Page<T> {
 *   @pageItems items: T[];
 *   @nextLink next: url;
 *   @prevLink prev: url;
 *   @firstLink first: url;
 *   @lastLink last: url;
 * }
 * @list op listPets(): Page<Pet>;
 * ```
 */
extern dec firstLink(target: ModelProperty);

/**
 * Pagination property defining a link to the last page.
 *
 * It is expected that navigating to the link will return the same set of responses as the operation that returned the current page.
 *
 * @example
 * ```tsp
 * model Page<T> {
 *   @pageItems items: T[];
 *   @nextLink next: url;
 *   @prevLink prev: url;
 *   @firstLink first: url;
 *   @lastLink last: url;
 * }
 * @list op listPets(): Page<Pet>;
 * ```
 */
extern dec lastLink(target: ModelProperty);

//---------------------------------------------------------------------------
// Debugging
//---------------------------------------------------------------------------

/**
 * A debugging decorator used to inspect a type.
 * @param text Custom text to log
 */
extern dec inspectType(target: unknown, text: valueof string);

/**
 * A debugging decorator used to inspect a type name.
 * @param text Custom text to log
 */
extern dec inspectTypeName(target: unknown, text: valueof string);
