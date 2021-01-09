using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Helpers
{
    public static class SuccessMessage
    {
        public static void Show(string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = originalColor;
        }
    }
}
