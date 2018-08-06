::@echo off

:: create a temp directory so we have a build location
SET CURR_DIR=%~dp0

:: Create a temporary directory we will use for building
SET WORK_DIR=%CURR_DIR%\__build
mkdir %WORK_DIR%
cd /d %WORK_DIR%

:: checkout and clone our repo for building
git clone -b release https://github.com/Kilowhisky/ember-website.git .

:: install everything we need
npm install

:: build everything
::node %WORK_DIR%\node_modules\ember-cli\bin\
ember build --prod

:: copy out to the build directory
git clean -dfX "%CURR_DIR%\..\Api\wwwroot\"
xcopy /s .\dist "%CURR_DIR%\..\Api\wwwroot\"

:: cleanup after ourselves
cd /d %CURR_DIR%
rmdir /S /Q %WORK_DIR%

:: Done!
echo "Done 🙌"
