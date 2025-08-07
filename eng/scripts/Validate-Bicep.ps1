# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

param(
[string] $path
)
az bicep build --file $path