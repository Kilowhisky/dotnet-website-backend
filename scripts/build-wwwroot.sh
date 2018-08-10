#!/bin/sh

# create a temp directory so we have a build location
CURR_DIR=`pwd`
SCRIPTPATH="$( cd "$(dirname "$0")" ; pwd -P )"
WORK_DIR=`mktemp -d`
cd $WORK_DIR

# checkout and clone our repo for building
git clone -b release https://github.com/Kilowhisky/ember-website.git .

# install everything we need
yarn install --non-interactive

# build everything
ember build --prod

# copy out to the build directory
shopt -u dotglob        # disable globbing for dot files
rm -r $SCRIPTPATH/../Api/wwwroot/*
cp -r ./dist/* $SCRIPTPATH/../Api/wwwroot

#cleanup after ourselves
rm -rf $WORK_DIR

# Done!
cd $CURR_DIR
echo "Done 🙌"
