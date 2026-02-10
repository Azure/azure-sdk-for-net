namespace TypeSpec.Http;

using TypeSpec.Reflection;

/**
 * Header options.
 */
model HeaderOptions {
  /**
   * Name of the header when sent over HTTP.
   */
  name?: string;

  /**
   * Equivalent of adding `*` in the path parameter as per [RFC-6570](https://datatracker.ietf.org/doc/html/rfc6570#section-3.2.3)
   *
   *  | Style  | Explode | Primitive value = 5 | Array = [3, 4, 5] | Object = {"role": "admin", "firstName": "Alex"} |
   *  | ------ | ------- | ------------------- | ----------------- | ----------------------------------------------- |
   *  | simple | false   | `5   `              | `3,4,5`           | `role,admin,firstName,Alex`                     |
   *  | simple | true    | `5`                 | `3,4,5`           | `role=admin,firstName=Alex`                     |
   *
   */
  explode?: boolean;
}

/**
 * Specify this property is to be sent or received as an HTTP header.
 *
 * @param headerNameOrOptions Optional name of the header when sent over HTTP or header options.
 *  By default the header name will be the property name converted from camelCase to kebab-case. (e.g. `contentType` -> `content-type`)
 *
 * @example
 *
 * ```typespec
 * op read(@header accept: string): {@header("ETag") eTag: string};
 * op create(@header({name: "X-Color", format: "csv"}) colors: string[]): void;
 * ```
 *
 * @example Implicit header name
 *
 * ```typespec
 * op read(): {@header contentType: string}; // headerName: content-type
 * op update(@header ifMatch: string): void; // headerName: if-match
 * ```
 */
extern dec header(target: ModelProperty, headerNameOrOptions?: valueof string | HeaderOptions);

/**
 * Cookie Options.
 */
model CookieOptions {
  /**
   * Name in the cookie.
   */
  name?: string;
}

/**
 * Specify this property is to be sent or received in the cookie.
 *
 * @param cookieNameOrOptions Optional name of the cookie in the cookie or cookie options.
 *  By default the cookie name will be the property name converted from camelCase to snake_case. (e.g. `authToken` -> `auth_token`)
 *
 * @example
 *
 * ```typespec
 * op read(@cookie token: string): {data: string[]};
 * op create(@cookie({name: "auth_token"}) data: string[]): void;
 * ```
 *
 * @example Implicit header name
 *
 * ```typespec
 * op read(): {@cookie authToken: string}; // headerName: auth_token
 * op update(@cookie AuthToken: string): void; // headerName: auth_token
 * ```
 */
extern dec cookie(target: ModelProperty, cookieNameOrOptions?: valueof string | CookieOptions);

/**
 * Query parameter options.
 */
model QueryOptions {
  /**
   * Name of the query when included in the url.
   */
  name?: string;

  /**
   * If true send each value in the array/object as a separate query parameter.
   * Equivalent of adding `*` in the path parameter as per [RFC-6570](https://datatracker.ietf.org/doc/html/rfc6570#section-3.2.3)
   *
   *  | Style  | Explode | Uri Template   | Primitive value id = 5 | Array id = [3, 4, 5]    | Object id = {"role": "admin", "firstName": "Alex"} |
   *  | ------ | ------- | -------------- | ---------------------- | ----------------------- | -------------------------------------------------- |
   *  | simple | false   | `/users{?id}`  | `/users?id=5`          | `/users?id=3,4,5`       | `/users?id=role,admin,firstName,Alex`              |
   *  | simple | true    | `/users{?id*}` | `/users?id=5`          | `/users?id=3&id=4&id=5` | `/users?role=admin&firstName=Alex`                 |
   *
   */
  explode?: boolean;
}

/**
 * Specify this property is to be sent as a query parameter.
 *
 * @param queryNameOrOptions Optional name of the query when included in the url or query parameter options.
 *
 * @example
 *
 * ```typespec
 * op read(@query select: string, @query("order-by") orderBy: string): void;
 * op list(@query(#{name: "id", explode: true}) ids: string[]): void;
 * ```
 */
extern dec query(target: ModelProperty, queryNameOrOptions?: valueof string | QueryOptions);

model PathOptions {
  /** Name of the parameter in the uri template. */
  name?: string;

  /**
   * When interpolating this parameter in the case of array or object expand each value using the given style.
   * Equivalent of adding `*` in the path parameter as per [RFC-6570](https://datatracker.ietf.org/doc/html/rfc6570#section-3.2.3)
   */
  explode?: boolean;

  /**
   * Different interpolating styles for the path parameter.
   * - `simple`: No special encoding.
   * - `label`: Using `.` separator.
   * - `matrix`: `;` as separator.
   * - `fragment`: `#` as separator.
   * - `path`: `/` as separator.
   */
  style?: "simple" | "label" | "matrix" | "fragment" | "path";

  /**
   * When interpolating this parameter do not encode reserved characters.
   * Equivalent of adding `+` in the path parameter as per [RFC-6570](https://datatracker.ietf.org/doc/html/rfc6570#section-3.2.3)
   */
  allowReserved?: boolean;
}

/**
 * Explicitly specify that this property is to be interpolated as a path parameter.
 *
 * @param paramNameOrOptions Optional name of the parameter in the uri template or options.
 *
 * @example
 *
 * ```typespec
 * @route("/read/{explicit}/things/{implicit}")
 * op read(@path explicit: string, implicit: string): void;
 * ```
 */
extern dec path(target: ModelProperty, paramNameOrOptions?: valueof string | PathOptions);

/**
 * Explicitly specify that this property type will be exactly the HTTP body.
 *
 * This means that any properties under `@body` cannot be marked as headers, query parameters, or path parameters.
 * If wanting to change the resolution of the body but still mix parameters, use `@bodyRoot`.
 *
 * @example
 *
 * ```typespec
 * op upload(@body image: bytes): void;
 * op download(): {@body image: bytes};
 * ```
 */
extern dec body(target: ModelProperty);

/**
 * Specify that the body resolution should be resolved from that property.
 * By default the body is resolved by including all properties in the operation request/response that are not metadata.
 * This allows to nest the body in a property while still allowing to use headers, query parameters, and path parameters in the same model.
 *
 * @example
 *
 * ```typespec
 * op upload(@bodyRoot user: {name: string, @header id: string}): void;
 * op download(): {@bodyRoot user: {name: string, @header id: string}};
 * ```
 */
extern dec bodyRoot(target: ModelProperty);
/**
 * Specify that this property shouldn't be included in the HTTP body.
 * This can be useful when bundling metadata together that would result in an empty property to be included in the body.
 *
 * @example
 *
 * ```typespec
 * op upload(name: string, @bodyIgnore headers: {@header id: string}): void;
 * ```
 */
extern dec bodyIgnore(target: ModelProperty);

/**
 * @example
 *
 * ```tsp
 * op upload(
 *   @header `content-type`: "multipart/form-data",
 *   @multipartBody body: {
 *     fullName: HttpPart<string>,
 *     headShots: HttpPart<Image>[]
 *   }
 * ): void;
 * ```
 */
extern dec multipartBody(target: ModelProperty);

/**
 * Specify the status code for this response. Property type must be a status code integer or a union of status code integer.
 *
 * @example
 *
 * ```typespec
 * op read(): {
 *   @statusCode _: 200;
 *   @body pet: Pet;
 * };
 * op create(): {
 *   @statusCode _: 201 | 202;
 * };
 * ```
 */
extern dec statusCode(target: ModelProperty);

/**
 * Specify the HTTP verb for the target operation to be `GET`.
 *
 * @example
 *
 * ```typespec
 * @get op read(): string
 * ```
 */
extern dec get(target: Operation);

/**
 * Specify the HTTP verb for the target operation to be `PUT`.
 *
 * @example
 *
 * ```typespec
 * @put op set(pet: Pet): void
 * ```
 */
extern dec put(target: Operation);

/**
 * Specify the HTTP verb for the target operation to be `POST`.
 *
 * @example
 *
 * ```typespec
 * @post op create(pet: Pet): void
 * ```
 */
extern dec post(target: Operation);

/**
 * Options for PATCH operations.
 */
model PatchOptions {
  /**
   * If set to `false`, disables the implicit transform that makes the body of a
   * PATCH operation deeply optional.
   */
  implicitOptionality?: boolean;
}

/**
 * Specify the HTTP verb for the target operation to be `PATCH`.
 *
 * @param options Options for the PATCH operation.
 *
 * @example
 *
 * ```typespec
 * @patch op update(pet: Pet): void;
 * ```
 *
 * @example
 * ```typespec
 * // Disable implicit optionality, making the body of the PATCH operation use the
 * // optionality as defined in the `Pet` model.
 * @patch(#{ implicitOptionality: false })
 * op update(pet: Pet): void;
 * ```
 */
extern dec patch(target: Operation, options?: valueof PatchOptions);

/**
 * Specify the HTTP verb for the target operation to be `DELETE`.
 *
 * @example
 *
 * ```typespec
 * @delete op set(petId: string): void
 * ```
 */
extern dec delete(target: Operation);

/**
 * Specify the HTTP verb for the target operation to be `HEAD`.
 * @example
 *
 * ```typespec
 * @head op ping(petId: string): void
 * ```
 */
extern dec head(target: Operation);

/**
 * Specify an endpoint for this service. Multiple `@server` decorators can be used to specify multiple endpoints.
 *
 *  @param url Server endpoint
 *  @param description Description of the endpoint
 *  @param parameters Optional set of parameters used to interpolate the url.
 *
 * @example
 *
 * ```typespec
 * @service
 * @server("https://example.com")
 * namespace PetStore;
 * ```
 *
 * @example With a description
 *
 * ```typespec
 * @service
 * @server("https://example.com", "Single server endpoint")
 * namespace PetStore;
 * ```
 *
 * @example Parameterized
 *
 * ```typespec
 * @server("https://{region}.foo.com", "Regional endpoint", {
 *   @doc("Region name")
 *   region?: string = "westus",
 * })
 * ```
 *
 * @example Multiple
 * ```typespec
 * @service
 * @server("https://example.com", "Standard endpoint")
 * @server("https://{project}.private.example.com", "Private project endpoint", {
 *   project: string;
 * })
 * namespace PetStore;
 * ```
 *
 */
extern dec server(
  target: Namespace,
  url: valueof string,
  description?: valueof string,
  parameters?: Record<unknown>
);

/**
 * Specify authentication for a whole service or specific methods. See the [documentation in the Http library](https://typespec.io/docs/libraries/http/authentication) for full details.
 *
 * @param auth Authentication configuration. Can be a single security scheme, a union(either option is valid authentication) or a tuple (must use all authentication together)
 * @example
 *
 * ```typespec
 * @service
 * @useAuth(BasicAuth)
 * namespace PetStore;
 * ```
 */
extern dec useAuth(target: Namespace | Interface | Operation, auth: {} | Union | {}[]);

/**
 * Defines the relative route URI template for the target operation as defined by [RFC 6570](https://datatracker.ietf.org/doc/html/rfc6570#section-3.2.3)
 *
 * `@route` can only be applied to operations, namespaces, and interfaces.
 *
 * @param uriTemplate Uri template for this operation.
 *
 * @example Simple path parameter
 *
 * ```typespec
 * @route("/widgets/{id}") op getWidget(@path id: string): Widget;
 * ```
 *
 * @example Reserved characters
 * ```typespec
 * @route("/files{+path}") op getFile(@path path: string): bytes;
 * ```
 *
 * @example Query parameter
 * ```typespec
 * @route("/files") op list(select?: string, filter?: string): Files[];
 * @route("/files{?select,filter}") op listFullUriTemplate(select?: string, filter?: string): Files[];
 * ```
 */
extern dec route(target: Namespace | Interface | Operation, path: valueof string);

/**
 * `@sharedRoute` marks the operation as sharing a route path with other operations.
 *
 * When an operation is marked with `@sharedRoute`, it enables other operations to share the same
 * route path as long as those operations are also marked with `@sharedRoute`.
 *
 * `@sharedRoute` can only be applied directly to operations.
 *
 * ```typespec
 * @sharedRoute
 * @route("/widgets")
 * op getWidget(@path id: string): Widget;
 * ```
 */
extern dec sharedRoute(target: Operation);
