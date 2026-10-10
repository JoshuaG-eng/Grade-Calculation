using System;

// This class contains the average and grade calculations.
class GradeCalculator
{
    // Calculate and return the average of four marks.
    public decimal CalculateAverage(
        decimal maths,
        decimal physics,
        decimal chemistry,
        decimal computerScience)
    {
        return (maths + physics + chemistry + computerScience) / 4m;
    }

    // Determine the grade by checking thresholds from highest to lowest.
    public string CalculateGrade(decimal average)
    {
        if (average >= 80m)
        {
            return "A";
        }
        else if (average >= 70m)
        {
            return "B";
        }
        else if (average >= 60m)
        {
            return "C";
        }
        else if (average >= 50m)
        {
            return "D";
        }
        else
        {
            return "F";
        }
    }
}

class Program
{
    static void Main()
    {
        // Create an object so we can use the class's methods.
        GradeCalculator calculator = new GradeCalculator();

        try
        {
            // Read the four subject marks.
            Console.Write("Enter Maths mark (0-100): ");
            decimal maths = Convert.ToDecimal(Console.ReadLine() ?? "");

            Console.Write("Enter Physics mark (0-100): ");
            decimal physics = Convert.ToDecimal(Console.ReadLine() ?? "");

            Console.Write("Enter Chemistry mark (0-100): ");
            decimal chemistry = Convert.ToDecimal(Console.ReadLine() ?? "");

            Console.Write("Enter Computer Science mark (0-100): ");
            decimal computerScience =
                Convert.ToDecimal(Console.ReadLine() ?? "");

            // Reject marks outside the permitted range.
            if (maths < 0m || maths > 100m ||
                physics < 0m || physics > 100m ||
                chemistry < 0m || chemistry > 100m ||
                computerScience < 0m || computerScience > 100m)
            {
                throw new ArgumentOutOfRangeException(
                    "marks", "Marks must be between 0 and 100.");
            }

            // Call the two methods through the calculator object.
            decimal average = calculator.CalculateAverage(
                maths, physics, chemistry, computerScience);

            string grade = calculator.CalculateGrade(average);

            Console.WriteLine();
            Console.WriteLine($"Average mark: {average:F2}");

            // Display the required remark for the calculated grade.
            switch (grade)
            {
                case "A":
                    Console.WriteLine("Excellent! Your grade is A");
                    break;

                case "B":
                    Console.WriteLine("Good! Your grade is B");
                    break;

                case "C":
                    Console.WriteLine("Satisfactory. Your grade is C");
                    break;

                case "D":
                    Console.WriteLine("Pass. Your grade is D");
                    break;

                case "F":
                    Console.WriteLine("Fail. Your grade is F");
                    break;
            }
        }
        catch (FormatException)
        {
            // Handle letters, blank input, or invalid number formats.
            Console.WriteLine("Please enter numeric marks only.");
        }
        catch (OverflowException)
        {
            // Handle numbers too large for the decimal datatype.
            Console.WriteLine("The number entered is too large.");
        }
        catch (ArgumentOutOfRangeException)
        {
            // Handle marks below zero or above 100.
            Console.WriteLine("Marks must be between 0 and 100.");
        }
    }
}
