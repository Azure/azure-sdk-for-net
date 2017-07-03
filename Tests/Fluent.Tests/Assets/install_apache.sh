#!/bin/bash

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.

# gets new package versions information
sudo apt-get update

# install apache
sudo apt-get -y install apache2

# restart Apache
sudo apachectl restart