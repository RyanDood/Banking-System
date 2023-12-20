using Banking_System.Assignment_1___6_;

Assignments assignments = new Assignments();
restart:
Console.WriteLine("\nEnter which Assignment you want to view\n\n1. Assignment 1\n2. Assignment 2\n3. Assignment 3\n4. Assignment 4\n5. Assignment 5\n6. Assignment 6\n");
int choice = int.Parse(Console.ReadLine());

switch (choice)
{
    case 1:
        assignments.assignment1();
        break;
    case 2:
        assignments.assignment2();
        break;
    case 3:
        assignments.assignment3();
        break;
    case 4:
        assignments.assignment4();
        break;
    case 5:
        assignments.assignment5();
        break;
    case 6:
        assignments.assignment6();
        break;
    default:
        Console.WriteLine("Invalid Value");
        break;
}
goto restart;