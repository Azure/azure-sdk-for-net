# Setup Instructions

This is a quick guide to running the tests of Svi. 

## SSH Keys

Create a private-public key pair to be used for authentication of your VMs.
In the file SshKeyPrivate, supply the private key value, and in the SshKeyPublic, supply the public key value.

## SVI and RG Names

For the  Start/Stop test and PatchCall test, we need existing SVIs. In both the tests,
update the variables of sviName and rgName with updated existing and running SVIs for the tests to execute succesfully.