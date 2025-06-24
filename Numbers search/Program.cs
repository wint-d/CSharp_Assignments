// dataset
List<int> numbers = [17, 166, 288, 324, 531, 792, 946, 157, 276, 441, 533, 355, 228, 879, 100, 421, 23, 490, 259, 227, 216, 317, 161, 4, 352, 463, 420, 513, 194, 299, 25, 32, 11, 943, 748, 336, 973, 483, 897, 396, 10, 42, 334, 744, 945, 97, 47, 835, 269, 480, 651, 725, 953, 677, 112, 265, 28, 358, 119, 784, 220, 62, 216, 364, 256, 117, 867, 968, 749, 586, 371, 221, 437, 374, 575, 669, 354, 678, 314, 450, 808, 182, 138, 360, 585, 970, 787, 3, 889, 418, 191, 36, 193, 629, 295, 840, 339, 181, 230, 150];
bool isValid = true;
string? userInput;


Console.WriteLine("Welcome to the Search Program");
do
{
    Console.Write("\nChoose an operation (1 = Basic Search, 2 = Range Search, 3 = Exit): ");
    userInput = Console.ReadLine();
    
    if (!string.IsNullOrEmpty(userInput))
    {
        if (userInput == "1" || userInput == "2" || userInput == "3")
        {
            switch (userInput)
            {
                case "1":
                    // Basic search for matched integer.
                    Console.WriteLine("\n## Basic Search ##");
                    Console.Write("Enter an integer to search: ");
                    string userInput1 = Console.ReadLine();
                    if (int.TryParse(userInput1, out int numSearch))
                    {
                        if (numbers.Contains(numSearch))
                        {
                            Console.WriteLine($"The integer {numSearch} is found at index {numbers.IndexOf(numSearch)}.");
                        }
                        else
                        {
                            Console.WriteLine($"The integer {numSearch} is not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter an integer to search.");
                    }

                    break;

                case "2":
                    // Create list for storing integers that found in range
                    List<int> numFound = new List<int>();
                    
                    // user inputs lower bound number
                    Console.WriteLine("\n## Range Search ##\n");
                    int numLower;
                    bool lowerValid = false;
                    do
                    {
                        Console.Write("\nEnter the lower bound: ");
                        string? userLower = Console.ReadLine();
                        if (string.IsNullOrEmpty(userLower))
                        {
                            numLower = 0;
                            lowerValid = true;
                        }
                        else if (int.TryParse(userLower, out numLower))
                        {
                            lowerValid = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter an integer to search.");
                        }
                    } while (!lowerValid);
                    
                    // user inputs upper bound number
                    int numUpper;
                    bool upperValid = false;
                    do
                    {
                        Console.Write("\nEnter the upper bound: ");
                        string? userUpper = Console.ReadLine();
                        if (string.IsNullOrEmpty(userUpper))
                        {
                            numUpper = 0;
                            upperValid = true;
                        }
                        else if (int.TryParse(userUpper, out numUpper))
                        {
                            upperValid = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter an integer to search.");
                        }
                    } while (!upperValid);
                    
                    // Sort found integers in the range as ascending order
                    numFound = numbers.Where(x => (x >= numLower && x<= numUpper)).ToList();
                    numFound.Sort();
                    if (numFound.Count == 0)
                    {
                        Console.WriteLine($"\nThe search found {numFound.Count} integers greater than {numLower} and less than {numUpper}.");
                    }
                    else
                    {
                        Console.WriteLine($"\nThe search found {numFound.Count} integers greater than {numLower} and less than {numUpper}. They are: {string.Join(", ", numFound)}");
                    }
                    break; 
                
                case "3":
                    isValid = false;
                    break;
            }
        }
        else
        {
            Console.WriteLine("\nInvalid input. please try again.");
        }    
    }
    else
    {
        Console.WriteLine("Please choose the operation.");
    }
} while (isValid);