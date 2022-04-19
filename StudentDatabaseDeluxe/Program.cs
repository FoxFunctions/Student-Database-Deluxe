namespace StudentDatabaseLab
{
    public class Program
    {
        static List<string> studentName = new List<string>() { "Aaron", "Clyde", "Kelly", "Meryl", "Simon", "Rose", "Jack", "David", "Popeye" };
        static List<string> homeTown = new List<string>() { "Los Angeles, California", "Juneao, Alaska", "Duluth, Minnesota", "Akron, Ohio", "Talladega, Alabama", "Marfa, Texas", "Tombstone, Arizona", "Toronto, Ontario", "Victoria, Texas" };
        static List<string> favoriteFood = new List<string>() { "pizza", "cornbread", "plain white rice", "lasanga", "anything from Jimmy Johns", "salmon", "fish sticks", "ramen noodle soup", "canned spinach" };
        static List<string> favoriteColor = new List<string>() { "blue", "red", "orange", "pink", "cyan", "green", "yellow", "teal", "grey" };
        static int userStudentChoice;
        static string topicChoice;
        static bool runAgain = true;

        public static void Main(string[] args)
        {
            while (runAgain)
            {

                Console.WriteLine("Welcome to the Student Database. Would you like to begin by viewing a directory of all students or proceed to viewing the database? Please type directory to view the directory or type database to view the database.");
                string databaseOrDirectory = Console.ReadLine().ToLower().Trim();

                if (databaseOrDirectory.Contains("dir"))
                {
                    PrintDirectory();

                    userStudentChoice = WhichStudent() - 1;
                }
                else if (databaseOrDirectory.Contains("data"))
                {
                    userStudentChoice = WhichStudent() - 1;
                }

                WhichTopicAndPrintTopic();

                while (true)
                {
                    Console.WriteLine("Would you like to Learn about another student? Please enter y/n");
                    string anotherStudent = Console.ReadLine().ToLower().Trim();
                    if (anotherStudent == "y")
                    {
                        userStudentChoice = WhichStudent() - 1;
                        WhichTopicAndPrintTopic();
                        continue;
                    }
                    else if (anotherStudent == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("I didn't understand. Please enter y/n");
                        continue;
                    }
                }

                while (true)
                {
                    Console.WriteLine("Would you like to add a new student to the database? Please enter y/n");
                    string newStudent = Console.ReadLine().ToLower().Trim();

                    if (newStudent == "y")
                    {
                        AddStudent();
                        Console.WriteLine("Would you like to add another student? Please enter y/n");
                        string anotherStudent = Console.ReadLine().ToLower().Trim();
                        if (anotherStudent == "y")
                        {
                            AddStudent();
                            continue;
                        }
                        else if(anotherStudent == "n")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("I did not understand. Please enter y/n");
                            continue;
                        }
                    
                    }
                    else if (newStudent == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("I did not understand. Please enter y/n");
                        continue;
                    }
                }

                while (true)
                {

                    Console.WriteLine("Would you like another opportunity to review our students?");
                    string viewAgain = Console.ReadLine().ToLower().Trim();

                    if (viewAgain == "y")
                    {
                        userStudentChoice = WhichStudent() - 1;
                        WhichTopicAndPrintTopic();
                        continue;
                    }
                    else if (viewAgain == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("I didn't understand. Please enter y/n");
                        continue;
                    }
                }



                runAgain = RunAgain();
            }
        }

        public static bool RunAgain()
        {
            Console.WriteLine("Would you like to run this program again?");
            string s = Console.ReadLine().ToLower().Trim();

            if (s == "y")
            {
                return true;
            }
            else if (s == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Sorry, I didn't quite understand. Please enter y/n");
                return RunAgain();
            }
        }


        private static string GetInput(string Prompt)
        {
            string result;
            do
            {
                Console.Write(Prompt);
                result = Console.ReadLine();
                if (string.IsNullOrEmpty(result))
                {
                    Console.WriteLine("Empty input, please try again");
                }
            } while (string.IsNullOrEmpty(result));
            return result;
        }

        public static void AddStudent()
        {
            Console.WriteLine("We will need to gather some information on the new student to add them to the database.");
            studentName.Add(GetInput("First, What is the students first name?"));
            homeTown.Add(GetInput("Next, what is the new student's hometown. Kindly enter in the City, State format."));
            favoriteColor.Add(GetInput("Last, what is the new student's favorite color."));            
        }

        public static void PrintDirectory()
        {
            for (int i = 0; i < studentName.Count; i++)
            {
                Console.WriteLine($"Student {i + 1}: {studentName[i]}");
            }
        }

        public static int WhichStudent()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Which student would you like to learn about. Please enter a number 1-" + studentName.Count);
                    int i = int.Parse(Console.ReadLine());

                    if (i <= 0 || i > studentName.Count)
                    {
                        Console.WriteLine("That is not a valid response. Please enter a number 1-" + studentName.Count);
                        continue;
                    }
                    else
                    {
                        return i;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("That is not a valid response. Please enter a number 1-" + studentName.Count);
                    continue;
                }
            }
        }

        public static void WhichTopicAndPrintTopic()
        {
            while (true)
            {

                Console.WriteLine($"You have selected {studentName[userStudentChoice]}. Which of the following topics would you like to view regarding {studentName[userStudentChoice]}.");
                Console.WriteLine($"To know {studentName[userStudentChoice]}'s hometown, please type: hometown");
                Console.WriteLine($"To know {studentName[userStudentChoice]}'s favorite food, please type: favorite food");
                Console.WriteLine($"To know {studentName[userStudentChoice]}'s favorite color, please type: favorite color");
                string s = Console.ReadLine().ToLower().Trim();

                if (s.Contains("town"))
                {
                    Console.WriteLine($"{studentName[userStudentChoice]} was born in {homeTown[userStudentChoice]}.");

                    Console.WriteLine($"Would you like to know anything else about {studentName[userStudentChoice]}. Please enter y/n");
                    string r = Console.ReadLine().ToLower().Trim();
                    if (r == "y")
                    {
                        continue;
                    }
                    else if (r == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("I didn't quite get that. Please enter y/n");
                        continue;
                    }


                }
                else if (s.Contains("food"))
                {
                    Console.WriteLine($"{studentName[userStudentChoice]}'s favorite food is {favoriteFood[userStudentChoice]}.");

                    Console.WriteLine($"Would you like to know anything else about {studentName[userStudentChoice]}. Please enter y/n");
                    string r = Console.ReadLine().ToLower().Trim();
                    if (r == "y")
                    {
                        continue;
                    }
                    else if (r == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("I didn't quite get that. Please enter y/n");
                        continue;
                    }


                }
                else if (s.Contains("color"))
                {
                    Console.WriteLine($"{studentName[userStudentChoice]}'s favorite color is {favoriteColor[userStudentChoice]}.");

                    Console.WriteLine($"Would you like to know anything else about {studentName[userStudentChoice]}. Please enter y/n");
                    string r = Console.ReadLine().ToLower().Trim();
                    if (r == "y")
                    {
                        continue;
                    }
                    else if (r == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("I didn't quite get that. Please enter y/n");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("I didn't quite get that. Try entering one of the following.");
                    Console.WriteLine("Hometown");
                    Console.WriteLine("Favorite Food");
                    Console.WriteLine("Favorite Color");
                    continue;
                }
            }
        }
    }
}



/*STUDENT DATABASE DELUXE
Objective: Generic Collections, Processing Data

Task: Improve your student information system from the previous lab by using a collection.

Build Specifications:
Refactor your code to use Lists rather than arrays.
Add another list to store another piece of information (so perhaps favorite color or favorite number) about each student.  Update your validation to allow the user to select that third piece of information.
Each iteration of the loop, ask first if they’d like to find out info about a student or add another student.  If they choose to add another student, get the name and each piece of info and add them to the end of the list.  Validate input--don’t accept blanks for any of the questions.


Extra Challenges:
Create the original lists in alphabetical order by student name.  When a user adds a new student, insert them at the correct location alphabetically.  Remember to put the information about a particular student at the same index in each list!
If you already know about creating classes, go back and rewrite this:
Make a StudentInfo class with name and other info (hometown, food, whatever you chose) as data members.
Use a single List of StudentInfo instances to store the information. */