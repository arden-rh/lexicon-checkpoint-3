/* Input Helper */

/* This static class provides helper methods for input validation and error handling. */

namespace Checkpoint_3
{
    public static class InputHelper
    {
        // Error handling for empty input fields method
        public static bool IsInputFieldEmpty(string Input, string FieldName)
        {
            if (string.IsNullOrWhiteSpace(Input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{FieldName} cannot be empty. Please try again.");
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            return false;
        }

        // Check for quit command method
        public static bool IsQuitCommand(string Input)
        {
            return Input.Trim().Equals("Q", StringComparison.OrdinalIgnoreCase);
        }

        // Try parse decimal method
        public static bool TryParseDecimal(string Input, out decimal Result)
        {
            return Decimal.TryParse(Input, out Result);

        }

        // Get validated string input method
        // This method prompts the user for input, validates it, and checks for quit command,
        // returning the input or indicating if the user chose to quit.
        public static string GetValidatedStringInput(string FieldName, out bool IsQuit)
        {
            IsQuit = false;
            string Input = string.Empty;

            do
            {
                Console.Write($"Enter a {FieldName}: ");
                Input = Console.ReadLine().Trim();

                // Check for quit command
                if (IsQuitCommand(Input))
                {
                    IsQuit = true;
                    return null;
                }

                // Error handling for empty input
                if (IsInputFieldEmpty(Input, FieldName))
                {
                    continue;
                }

                return Input;

            } while (true);
        }
    }
}

