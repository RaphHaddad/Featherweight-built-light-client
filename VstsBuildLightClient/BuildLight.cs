namespace VstsBuildLightClient
{
    internal abstract class BuildLight
    {
        internal abstract void ChangeColourToRed();
        internal abstract void ChangeColourToGreen();
        internal abstract void ChangeColourToAmber();
        internal abstract void TurnOff();

        internal static BuildLight Initialise()
        {
            switch (AppConfiguration.BuildLight)
            {
                case AppConfiguration.BuildLights.Console:
                    return new ConsoleBuildLight();
                case AppConfiguration.BuildLights.Delcom:
                    return new DelcomBuildLight();
                case AppConfiguration.BuildLights.PhilipsHue:
                    return new PhilipsHueBuildLight();
                case AppConfiguration.BuildLights.Kuando:
                    return new KuandoBuildLight();
            }
            return null;
        }

    }
}