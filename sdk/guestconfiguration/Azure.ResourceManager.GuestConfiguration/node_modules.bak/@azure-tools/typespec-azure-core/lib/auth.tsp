import "@typespec/http";
import "@typespec/rest";
import "@typespec/versioning";
import "./traits.tsp";

using Http;
using Rest;
using Versioning;
using Azure.Core.Traits;
using Azure.Core.Traits.Private;

namespace Azure.Core;

/**
 * Azure Active Directory (AAD) Token Authentication Flow
 * @template AuthUrl The authorization URL.
 * @template TokenUrl The token URL.
 * @template Scopes A list of scopes the token applies to.
 */
model AadTokenAuthFlow<Scopes extends string[], AuthUrl extends string, TokenUrl extends string>
  extends TypeSpec.Http.AuthorizationCodeFlow {
  type: OAuth2FlowType.authorizationCode;
  authorizationUrl: AuthUrl;
  tokenUrl: TokenUrl;
  scopes: Scopes;
}

/**
 * Azure Active Directory OAuth2 Flow
 * @template AuthUrl The authorization URL.
 * @template TokenUrl The token URL.
 * @template Scopes A list of scopes the token applies to.
 */
@doc("The Azure Active Directory OAuth2 Flow")
model AadOauth2Auth<
  Scopes extends string[],
  AuthUrl extends string = "https://login.microsoftonline.com/common/oauth2/authorize",
  TokenUrl extends string = "https://login.microsoftonline.com/common/oauth2/token"
> is OAuth2Auth<[AadTokenAuthFlow<Scopes, AuthUrl, TokenUrl>]>;

/**
 * Azure API Key Authentication using the "Ocp-Apim-Subscription-Key" hea
 */
@doc("Azure API Key Authentication")
model AzureApiKeyAuthentication
  is TypeSpec.Http.ApiKeyAuth<ApiKeyLocation.header, "Ocp-Apim-Subscription-Key">;
