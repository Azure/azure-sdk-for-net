declare type CollectionFormat = "none" | "csv" | "ssv" | "tsv" | "pipes" | "multi";

declare type Constraint =
  | "None"
  | "InclusiveMaximum"
  | "ExclusiveMaximum"
  | "InclusiveMinimum"
  | "ExclusiveMinimum"
  | "MaxLength"
  | "MinLength"
  | "Pattern"
  | "MaxItems"
  | "MinItems"
  | "UniqueItems"
  | "MultipleOf";

declare type HttpMethod = "get" | "post" | "put" | "patch" | "delete" | "head" | "options";

declare type HttpStatusCode =
  | "Continue"
  | "SwitchingProtocols"
  | "OK"
  | "Created"
  | "Accepted"
  | "NonAuthoritativeInformation"
  | "NoContent"
  | "ResetContent"
  | "PartialContent"
  | "Ambiguous"
  | "MultipleChoices"
  | "Moved"
  | "MovedPermanently"
  | "Found"
  | "Redirect"
  | "RedirectMethod"
  | "SeeOther"
  | "NotModified"
  | "UseProxy"
  | "Unused"
  | "RedirectKeepVerb"
  | "TemporaryRedirect"
  | "BadRequest"
  | "Unauthorized"
  | "PaymentRequired"
  | "Forbidden"
  | "NotFound"
  | "MethodNotAllowed"
  | "NotAcceptable"
  | "ProxyAuthenticationRequired"
  | "RequestTimeout"
  | "Conflict"
  | "Gone"
  | "LengthRequired"
  | "PreconditionFailed"
  | "RequestEntityTooLarge"
  | "RequestUriTooLong"
  | "UnsupportedMediaType"
  | "RequestedRangeNotSatisfiable"
  | "ExpectationFailed"
  | "UpgradeRequired"
  | "InternalServerError"
  | "NotImplemented"
  | "BadGateway"
  | "ServiceUnavailable"
  | "GatewayTimeout"
  | "HttpVersionNotSupported";

declare type KnownPrimaryType =
  | "none"
  | "object"
  | "int"
  | "long"
  | "double"
  | "decimal"
  | "string"
  | "stream"
  | "byteArray"
  | "date"
  | "dateTime"
  | "dateTimeRfc1123"
  | "timeSpan"
  | "boolean"
  | "credentials"
  | "uuid"
  | "base64Url"
  | "unixTime";

declare type ParameterLocation = "none" | "path" | "query" | "header" | "body" | "formData";

declare interface WithExtensions {
  extensions: { [key: string]: any };
}

declare interface CodeModel extends WithExtensions {
  hostParametersFront?: Array<Parameter>;
  hostParametersBack?: Array<Parameter>;
  name: string;
  namespace: string;
  modelsName: string;
  apiVersion: string;
  baseUrl: string;
  documentation?: string;

  properties?: Array<Property>;
  operations?: Array<MethodGroup>;
  enumTypes?: Array<EnumType>;
  modelTypes?: Array<CompositeType>;
  errorTypes?: Array<CompositeType>;
  headerTypes?: Array<CompositeType>;
}

declare interface FixableString {
  raw?: string;
  fixed: boolean;
}

declare interface XmlProperties {
  name?: string;
  namespace?: string;
  prefix?: string;
  attribute: boolean;
  wrapped: boolean;
}

declare interface MethodGroup {
  name: FixableString;
  typeName: FixableString;
  nameForProperty: string;

  methods?: Array<Method>;
}

declare interface Method extends WithExtensions {
  name: FixableString;
  group: FixableString;
  serializedName: string;
  url: string;
  isAbsoluteUrl: boolean;
  httpMethod: HttpMethod;
  inputParameterTransformation?: Array<ParameterTransformation>;
  responses: { [statusCode in HttpStatusCode]: Response };
  defaultResponse: Response;
  returnType: Response;
  description?: string;
  summary?: string;
  externalDocsUrl?: string;
  requestContentType?: string;
  responseContentTypes?: Array<string>;
  deprecated: boolean;
  hidden: boolean;

  parameters?: Array<Parameter>;
}

declare interface ParameterTransformation {
  outputParameter: Parameter;
  parameterMappings?: Array<ParameterMapping>;
}

declare interface ParameterMapping {
  inputParameter: Parameter;
  inputParameterProperty?: string;
  outputParameterProperty?: string;
}

declare interface IVariable extends WithExtensions {
  collectionFormat: CollectionFormat;
  constraints?: { [constraint in Constraint]: string };
  defaultValue: FixableString;
  documentation?: string;
  isRequired: boolean;
  isConstant: boolean;
  name: FixableString;
  serializedName: FixableString;
  modelType: ModelType;
}

declare interface Property extends IVariable {
  isReadOnly: boolean;
  summary?: string;
  realPath: Array<string>;
  xmlProperties?: XmlProperties;
}

declare interface Parameter extends IVariable {
  clientProperty?: Property;
  location: ParameterLocation;
}

//
// Types
//

declare interface IModelType {
  name: FixableString;
  xmlProperties?: XmlProperties;
}

declare interface EnumType extends IModelType {
  $type: "EnumType";
  values: EnumValue;
  modelAsExtensible: boolean;
  modelAsString: boolean;
  underlyingType: PrimaryType;
}
declare interface EnumValue {
  description?: string;
  name: string;
  serializedName: string;
  allowedValues?: Array<string>;
}

declare interface PrimaryType extends IModelType {
  $type: "PrimaryType";
  format?: string;
  knownPrimaryType: KnownPrimaryType;
}

declare interface CompositeType extends IModelType {
  $type: "CompositeType";
  serializedName: string;
  baseModelType?: CompositeType;
  polymorphicDiscriminator?: string;
  summary?: string;
  documentation?: string;
  externalDocsUrl?: string;
  containsConstantProperties: boolean;

  properties?: Array<Property>;
}

declare interface DictionaryType extends IModelType {
  $type: "DictionaryType";
  valueType: ModelType;
  supportsAdditionalProperties: boolean;
}

declare interface SequenceType extends IModelType {
  $type: "SequenceType";
  elementType: ModelType;
  elementXmlProperties?: XmlProperties;
}

type ModelType = CompositeType | DictionaryType | EnumType | PrimaryType | SequenceType;
