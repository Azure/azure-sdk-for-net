#!/bin/bash
TMP_PATH=$CERT_FOLDER
PFXFILE=$CERT_FOLDER/dotnet-devcert.pfx
CRTFILE=$CERT_FOLDER/dotnet-devcert.crt

NSSDB_PATHS=(
    "$HOME/.pki/nssdb"
    "$HOME/snap/chromium/current/.pki/nssdb"
    "$HOME/snap/postman/current/.pki/nssdb"
)

function configure_nssdb() {
    echo "Configuring nssdb for $1"
    certutil -d sql:$1 -D -n dotnet-devcert
    certutil -d sql:$1 -A -t "CP,," -n dotnet-devcert -i $CRTFILE
}

for NSSDB in ${NSSDB_PATHS[@]}; do
    if [ -d "$NSSDB" ]; then
        configure_nssdb $NSSDB
    fi
done

if [ $(id -u) -ne 0 ]; then
    SUDO='sudo'
fi

$SUDO cp $CRTFILE "/usr/local/share/ca-certificates"
$SUDO update-ca-certificates

dotnet dev-certs https --clean --import $PFXFILE -p "password"
