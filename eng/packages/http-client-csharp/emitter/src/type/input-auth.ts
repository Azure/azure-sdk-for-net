// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { InputApiKeyAuth } from "./input-api-key-auth.js";
import { InputOAuth2Auth } from "./input-oauth2-auth.js";

export interface InputAuth {
  ApiKey?: InputApiKeyAuth;
  OAuth2?: InputOAuth2Auth;
}
