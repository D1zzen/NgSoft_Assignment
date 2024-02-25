using System;

class SequenceClassifier
{
    public static int ClassifySequence(int[] sequence)
    {
        // First assumption is that all types are possible
        bool isStrictlyIncreasing = true;
        bool isNotDecreasing = true; // This one includes strictly increasing sequences
        bool isStrictlyDecreasing = true;
        bool isNotIncreasing = true; // This one includes strictly decreasing sequences
        bool isConstant = true;

        for (int i = 1; i < sequence.Length; i++)
        {
            if (sequence[i] > sequence[i - 1])
            {
                // If any number is greater than the previous, the sequence cannot be: strictly decreasing; not increasing; constant
                isStrictlyDecreasing = false;
                isNotIncreasing = false;
                isConstant = false;
            }
            else if (sequence[i] < sequence[i - 1])
            {
                // If any number is less than the previous, the sequence cannot be: strictly increasing; not decreasing; constant
                isStrictlyIncreasing = false;
                isNotDecreasing = false;
                isConstant = false;
            }
            else
            {
                // If any number is equal to the previous, the sequence cannot be: strictly increasing; strictly decreasing
                isStrictlyIncreasing = false;
                isStrictlyDecreasing = false;
            }
        }

        // Return the type of sequence based on the booleans
        if (isConstant)
        {
            return 5; // All values are the same
        }
        else if (isStrictlyIncreasing)
        {
            return 1; // Strictly increase
        }
        else if (isNotDecreasing && !isStrictlyIncreasing) // includes sequences with equal consecutive numbers
        {
            return 2; // Not decrease
        }
        else if (isStrictlyDecreasing)
        {
            return 3; // Strictly decrease
        }
        else if (isNotIncreasing && !isStrictlyDecreasing) // includes sequences with equal consecutive numbers
        {
            return 4; // Not increase
        }
        else
        {
            return 0; // Unordered
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine(ClassifySequence([10, 8, 11, 12, 9, 8])); // Unordered
        Console.WriteLine(ClassifySequence([1, 5, 8, 12, 88, 900])); // Strictly increasing
        Console.WriteLine(ClassifySequence([5050, 6080, 6089, 6089, 8409, 8409])); // Not decreasing
        Console.WriteLine(ClassifySequence([1477, 1209, 809, 458, 250, 1])); // Strictly decreasing
        Console.WriteLine(ClassifySequence([155, 155, 67, 65, 50, 3])); // Not increasing
        Console.WriteLine(ClassifySequence([192, 192, 192, 192, 192, 192])); // Constant
    }
}
