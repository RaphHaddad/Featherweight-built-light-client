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
            switch (VstsConfiguration.BuildLight)
            {
                case VstsConfiguration.BuildLights.Console:
                    return new ConsoleBuildLight();
                case VstsConfiguration.BuildLights.Delcom:
                    return new DelcomBuildLight();
                case VstsConfiguration.BuildLights.PhilipsHue:
                    return new PhilipsHueBuildLight();
            }
            return null;
        }

    }
}