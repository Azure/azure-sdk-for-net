// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Resolve ambiguity between Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation
// and Azure.ResourceManager.Resources.Models.ExtendedLocation in generated files.
// The NetworkCloud.Models.ExtendedLocation type is a backward-compat shim inheriting
// from the ARM common type. This alias ensures the shim type is used consistently.
global using ExtendedLocation = Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation;
