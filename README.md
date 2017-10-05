# Featherweight build light client
This is a featherweight buildlight client, it shouldn't take more than a few minutes to setup
1. Generate a person acess token from here: https://{{instance-name}}.visualstudio.com/_details/security/tokens
2. rename `appsettings.example.jso`n to `appsettings.json`.
3. put the personal access token in the appsettings.json.
4. specify what build light you want on the appsettings.json file. Currently support
   1. "kuando" supports the kuando omega light
   2. "console"
   3. "delcom" (coming soon - already implemented but not tested as I didn't have a light)
   4. "hue" (coming soon, you will need to modify the value for device_name here, still untested as I didn't have a light)
5. specify your build definitions as an array of integers on the field `builds_definitions`. Your build definition Id can be found from the build definition url. 