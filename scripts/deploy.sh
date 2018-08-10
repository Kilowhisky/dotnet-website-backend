#!/bin/sh

# build our www-root which holds our website itself
sh ./build-wwwroot.sh

# Build the API with the wwwroot in it
dotnet publish -c Deploy

# Copy everything to the server
rsync -r --delete-after $TRAVIS_BUILD_DIR/Api/bin/Deploy/netcoreapp2.1/publish/ deploy@wetzelrice.com:/srv/webservices/wetzelrice.com/www
