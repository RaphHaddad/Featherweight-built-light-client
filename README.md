# Featherweight build light client
This is a featherweight buildlight client, it shouldn't take more than a few minutes to setup
1. Generate a person acess token from here: https://{{instance-name}}.visualstudio.com/_details/security/tokens
2. rename appsettings.exmample.json to appsettings.json.
3. put the personal access token in the appsettings.json.
4. specify what build light you want on the appsettings.json file. Currently support
   1. "console"
   2. "delcom" (coming soon)