using System;




#region
namespace PCE_StarterProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // This code is used by the first exercise
            // It is left here, uncommented, so that it's easy for you to run
            // Once you complete it, feel free to comment these lines out
            // That way, you won't have every single exercise being run, each and
            // every time :)


            IO_Operators ioo = new IO_Operators();
            ioo.RunExercise();

            Fibonnaci_With_Array fwa = new Fibonnaci_With_Array();
            fwa.RunExercise();

            Scope_Of_Variables sov = new Scope_Of_Variables();
            sov.RunExercise();

            Array_Of_Ints aoi = new Array_Of_Ints();
            aoi.RunExercise();

            Object_Composition_Circle occ = new Object_Composition_Circle();
            occ.RunExercise();

        }
    }

    class IO_Operators
    {
        public void RunExercise()
        {
            int numX, numY;

            Int32.TryParse(Console.ReadLine(), out numX);
            Int32.TryParse(Console.ReadLine(), out numY);

            if (numY - numX > 5 || numX - numY > 5)
                Console.WriteLine("{0} and {1} are NOT within 5 integers of each other.", numX, numY);
            else
                Console.WriteLine("{0} and {1} are  within 5 integers of each other.", numX, numY);
        }
    }

    class Fibonnaci_With_Array
    {
        public void RunExercise()
        {
            int[] fib = new int[20];

            fib[0] = 0;
            fib[1] = 1;

            for (int i = 2; i < fib.Length; i++)
            { fib[i] = fib[i - 1] + fib[i - 2]; }
            for (int i = 0; i < fib.Length; i++)
            { Console.WriteLine(fib[i]); }
        }
    }
    #region SOV
    class Scope_Of_Variables
    {
        // Instance variables are created in the beginning of the class
        //they exsist only within the class (and any subclasses)
        //Local Variables are created in methods and constructors, 
        //they die after the given method/constructor(s)
        //Parameters allow methods to pass values under given conditions 

        public void RunExercise()
        {
            NumberPrinter np = new NumberPrinter();
            np.SetLowest(3.14159);
            np.SetHighest(12);
            np.Print(true);
            np.SetHighest(17.1);
            np.Print(false);

        }
    }
    class NumberPrinter
    {
        private double lowest, highest;
        public NumberPrinter()
        {

            lowest = 0;
            highest = 0;
        }
        public void SetLowest(double x) { lowest = x; }
        public void SetHighest(double y) { highest = y; }
        public void Print(bool checkNum)
        {
            int lower = (int)Math.Ceiling(lowest);
            int higher = (int)highest;

            for(int i=lower;i<= higher;i++)
            {
                if(i%2==0 && checkNum == true)
                { Console.WriteLine(i); i++; }
                if(checkNum==false)
                { Console.WriteLine(i); }
            }

        }
    }
    #endregion SOV
    class Object_Composition_Circle
    {
        public void RunExercise()
        {
            //// Quick test for your Point class:
            Point pt1 = new Point(10, 20);
            // Pt1 is located at (10,20)
            Point pt2 = new Point(0, 0);
            // Pt2 is at the origin

            pt1.Print(); // Prints out something like (10, 20)
            pt2.Print(); // Prints out something like (0, 0)
            pt1.setX(-10);
            pt1.Print(); // Now prints out (-10, 20)
            pt2.setY(10);
            pt2.Print(); // Prints out something like (0, 10)
            Console.WriteLine("pt1 is at {0} and {1}", pt1.getX(), pt1.getY());
            // prints out: pt1 is at -10 and 20

            //// Note that even though c1 & c2 are using Point
            //// objects to store the location, we're still passing
            //// in the x & y values separately 
            Circle c1 = new Circle(10, 20, 3);
            //// c1 is located at (10,20), with radius = 3
            Circle c2 = new Circle(0, 0, 4);
            //// c2 is at the origin, radius is 4

            c1.Print(); // Prints out something like (10, 20) radius=3
            c2.Print(); // Prints out something like (0, 0) radius=4
            c1.setX(-10);
            c1.Print(); // Now prints out (-10, 20) radius=3
            c2.setY(10);
            c2.setRadius(10);
            c2.Print(); // Prints out something like (0, 10) radius=10
            Console.WriteLine("c1 is at {0} and {1}, with radius of {2}",
               c1.getX(), c1.getY(), c1.getRadius());
            //// prints out c1 is at -10 and 20, with radius of 3
        }
    }
    // this is a good place to put your Point and Circle classes
    class Point
    {
        private int xCore, yCore;

        public Point() { }

        public Point(int x, int y)
        { xCore = x; yCore = y; }
        public int getX()
        { return xCore; }
        public int getY()
        { return yCore; }
        public void setX(int x)
        { xCore = x; }
        public void setY(int y)
        { yCore = y; }
        public virtual void Print()
        { Console.WriteLine("({0} , {1})", xCore, yCore); }


    }
    class Circle : Point
    {
        private double radius;

        public Circle(int x, int y, double rad) : base(x, y)
        { radius = rad; }
        public void setRadius(double r)
        { radius = r; }
        public double getRadius()
        { return radius; }
        public override void Print()
        {
            Console.WriteLine("({0} , {1}) radius = {2}",
            getX(),
            getY(),
            getRadius());
        }
    }

    class Array_Of_Ints
    {
        public void RunExercise()
        {

            int input, arraySize;
            Console.WriteLine("Welcome to Number Picker!\n");
            Console.WriteLine("Please,\n\n1)Choose a size of the array");
            Console.WriteLine("2)Choose a slot to examine its value\n");
            Console.WriteLine("Pick Array Size");
            Int32.TryParse(Console.ReadLine(), out arraySize);
            Console.WriteLine("Number to print? (type in 1000 to quit)");
            Int32.TryParse(Console.ReadLine(), out input);

            do
            {
                int[] nums = new int[arraySize + 1];
                int x = 1;

                if (input == 1000) break;
                if (input < 0 || input >= nums.Length)
                {
                    Console.WriteLine("There is no slot {0}", input);
                    Console.WriteLine("Number to print? (type in 1000 to quit)");
                    Int32.TryParse(Console.ReadLine(), out input);
                }
                else
                {

                    for (int i = 0; i < nums.Length; i++) { nums[i] = x; x += 2; }
                    Console.WriteLine("Number at location {0} is {1}",
                                                 input, nums[input]);
                    Console.WriteLine("Number to print? (type in 1000 to quit)");
                    Int32.TryParse(Console.ReadLine(), out input);
                }
            } while (input != 1000);

            Console.WriteLine("Fine, leave! But, have a good ONE!");

        }
        
    }
   
}
#endregion