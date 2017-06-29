namespace VstsBuildLightClient
{
    internal abstract class BuildLight
    {
        internal abstract void ChangeColourToRed();
        internal abstract void ChangeColourToGreen();
        internal abstract void ChangeColourToAmber();
        internal abstract void TurnOff();

        internal static BuildLight Initialise(VstsConfiguration.BuildLights buildLight)
        {
            if (buildLight == VstsConfiguration.BuildLights.Console)
            {
                return new ConsoleBuildLight();
            }
            return null;
        }

    }
}