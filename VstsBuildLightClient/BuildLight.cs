namespace VstsBuildLightClient
{
    internal abstract class BuildLight
    {
        internal virtual void ChangeColourToRed()
        {
            
        }

        internal virtual void ChangeColourToGreen()
        {

        }

        internal virtual void ChangeColourToAmber()
        {

        }

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