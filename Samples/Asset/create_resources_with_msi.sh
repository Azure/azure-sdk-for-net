#!/bin/bash

/usr/bin/yes | sudo apt-get update
/usr/bin/yes | sudo apt install python-pip
/usr/bin/yes | sudo pip install --upgrade pip
sudo pip install azure-cli
az login -u $1@$2
az storage account create -n $3 -g $4 -l $5 --sku Premium_LRS