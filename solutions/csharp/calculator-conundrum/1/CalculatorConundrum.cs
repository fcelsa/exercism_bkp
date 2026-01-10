public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        return operation switch
            {
                null => throw new ArgumentNullException(),
                "" => throw new ArgumentException(),
                "+" => $"{operand1} {operation} {operand2} = {(operand1 + operand2).ToString()}",
                "-" => $"{operand1} {operation} {operand2} = {(operand1 - operand2).ToString()}",
                "*" => $"{operand1} {operation} {operand2} = {(operand1 * operand2).ToString()}",
                "/" => operand2 != 0 ? $"{operand1} {operation} {operand2} = {(operand1 / operand2).ToString()}" : "Division by zero is not allowed.",
                _ => throw new ArgumentOutOfRangeException(),
            }; 
    }
}
