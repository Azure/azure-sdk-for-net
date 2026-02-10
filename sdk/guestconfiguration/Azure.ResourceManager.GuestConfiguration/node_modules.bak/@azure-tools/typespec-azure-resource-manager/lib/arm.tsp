import "../dist/src/tsp-index.js";
import "@typespec/http";
import "@typespec/rest";
import "@typespec/versioning";
import "@azure-tools/typespec-azure-core";

// Kept for legacy reasons remove when specs are migrated
import "@typespec/openapi";

import "./foundations/arm.foundations.tsp";
import "./legacy-types/arm.legacy.tsp";
import "./common-types/common-types.tsp";
import "./extension/extension.tsp";
import "./backcompat.tsp";
import "./private.decorators.tsp";
import "./models.tsp";
import "./operations.tsp";
import "./decorators.tsp";
import "./interfaces.tsp";
import "./responses.tsp";
import "./parameters.tsp";
import "./private-endpoints.tsp";
import "./private-links.tsp";
import "./network-security-perimeter.tsp";

namespace Azure.ResourceManager;
