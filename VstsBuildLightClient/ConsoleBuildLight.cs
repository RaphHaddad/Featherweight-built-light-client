using System;

namespace VstsBuildLightClient
{
    internal class ConsoleBuildLight : BuildLight
    {
        internal override void ChangeColourToGreen()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Build is good");
            Console.ResetColor();
        }

        internal override void ChangeColourToAmber()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Build is partially successful");
            Console.ResetColor();
        }

        internal override void TurnOff()
        {
            Console.Clear();
        }

        internal override void ChangeColourToRed()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Build has failed");
            Console.ResetColor();
        }
    }
}