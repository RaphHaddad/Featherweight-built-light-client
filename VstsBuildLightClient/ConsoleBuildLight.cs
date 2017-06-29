using System;

namespace VstsBuildLightClient
{
    internal class ConsoleBuildLight : BuildLight
    {
        private static void ChangeColour(ConsoleColor color)
        {
            Console.BackgroundColor = color;
            Console.Clear();
            Console.WriteLine();
        }
        internal override void ChangeColourToGreen()
        {
            ChangeColour(ConsoleColor.Green);
        }

        internal override void ChangeColourToAmber()
        {
            ChangeColour(ConsoleColor.Yellow);
        }

        internal override void TurnOff()
        {
            Console.ResetColor();
            Console.Clear();
        }

        internal override void ChangeColourToRed()
        {
            ChangeColour(ConsoleColor.Red);
        }
    }
}