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

        // Get validated DateTime input method
        public static DateTime GetValidatedDateTimeInput(string FieldName, out bool IsQuit)
        {
            IsQuit = false;
            DateTime InputDate;

            do
            {
                Console.Write($"Enter a {FieldName} (YYYY-MM-DD): ");
                string Input = Console.ReadLine().Trim();

                // Check for quit command
                if (IsQuitCommand(Input))
                {
                    IsQuit = true;
                    return default;
                }
                // Error handling for empty input
                if (IsInputFieldEmpty(Input, FieldName))
                {
                    continue;
                }
                // Try to parse the date
                if (!DateTime.TryParse(Input, out InputDate))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid {FieldName}. Please enter a valid date.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                // Check if the date is in the future
                if (InputDate > DateTime.Now)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{FieldName} cannot be in the future. Please enter a valid date.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                return InputDate;

            } while (true);
        }

        // Get validated string input method
        // This method prompts the user for input, validates it, and checks for quit command,
        // returning the input or indicating if the user chose to quit.
        public static string GetValidatedStringInputForField(string FieldName, out bool IsQuit)
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

        // Get validated string input with specific valid inputs
        public static string GetValidatedStringInputForField(string FieldName, List<string> ValidInputs, out bool IsQuit)
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

                foreach (string validInput in ValidInputs)
                {
                    if (Input.Equals(validInput, StringComparison.OrdinalIgnoreCase))
                    {
                        Input = validInput; // Normalize to the valid input casing
                        return Input;
                    }
                }

                // Validate against the list of valid inputs
                if (!ValidInputs.Contains(Input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid {FieldName}. Please enter one of the following: {string.Join(" | ", ValidInputs)}");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                return Input;

            } while (true);
        }
    }
}

