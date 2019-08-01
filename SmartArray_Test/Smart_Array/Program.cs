using System;
using System.Collections.Generic;
using System.Text;

namespace SmartArray_Test
{

    class SmartArray
    {
        private int[] rgNums;
        public SmartArray()
        {
            rgNums = new int[5];
        }

        public bool SetAtIndex(int idx, int val)
        {
            if (idx < rgNums.Length && idx >= 0)
            { rgNums[idx] = val; return true; }
            else return false;
        }
        public int GetAtIndex(int idx)
        {
            if (idx < rgNums.Length && idx >= 0)
                return rgNums[idx];
            else return Int32.MinValue;
        }
        public void PrintAllElements()
        {
            for (int i = 0; i < rgNums.Length; i++) { Console.WriteLine(rgNums[i]); }
        }
        public bool Find(int val)
        {
            for (int i = 0; i < rgNums.Length; i++)
            {
                if (rgNums[i] == val) { return true; }
            }
            return false;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            SmartArray sa = new SmartArray();
            const int SMART_ARRAY_SIZE = 5;
            bool testPassed = false;

            Console.WriteLine("CHECK THIS: SmartArray starts with all zeros");
            sa.PrintAllElements();
            Console.WriteLine("\n*******************\n");


            Console.WriteLine("================= SetAtIndex =================");
            Console.WriteLine("AutoChecked: Can add at slot 0?");
            if (!sa.SetAtIndex(0, 10))
                Console.WriteLine("TEST FAILED: UNABLE TO SET ELEMENT 0!");
            else
                Console.WriteLine("Test Passed: Able to set element 0!");
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Can add at slots 0-4?");
            testPassed = true;
            for (int i = 0; i < SMART_ARRAY_SIZE; i++)
            {
                if (!sa.SetAtIndex(i, 10 * i))
                {
                    Console.WriteLine("TEST FAILED: UNABLE TO SET ELEMENT {0}!", i);
                    testPassed = false;
                    break; // out of the loop
                }
            }
            if (testPassed)
                Console.WriteLine("Test Passed: Able to set all elements!");
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Should NOT be able to add at slot {0}?", SMART_ARRAY_SIZE);
            if (sa.SetAtIndex(SMART_ARRAY_SIZE, 10))
                Console.WriteLine("TEST FAILED: ABLE TO SET ELEMENT {0}?", SMART_ARRAY_SIZE);
            else
                Console.WriteLine("Test Passed: Unable to set element {0}!", SMART_ARRAY_SIZE);
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Should NOT be able to add at slot {0}?", SMART_ARRAY_SIZE + 10);
            if (sa.SetAtIndex(SMART_ARRAY_SIZE + 10, 10))
                Console.WriteLine("TEST FAILED: ABLE TO SET ELEMENT {0}?", SMART_ARRAY_SIZE + 10);
            else
                Console.WriteLine("Test Passed: Unable to set element {0}!", SMART_ARRAY_SIZE + 10);
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Should NOT be able to add at slot -1?");
            if (sa.SetAtIndex(-1, 10))
                Console.WriteLine("TEST FAILED: ABLE TO SET ELEMENT -1!");
            else
                Console.WriteLine("Test Passed: UNable to set element -1!");
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Should NOT be able to add at slot -10?");
            if (sa.SetAtIndex(-10, 10))
                Console.WriteLine("TEST FAILED: ABLE TO SET ELEMENT -10!");
            else
                Console.WriteLine("Test Passed: UNable to set element -10!");
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("CHECK THIS: Should see 0, 10, 20, 30, 40");
            sa.PrintAllElements();
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("================= GetAtIndex =================");
            int valueGotten;
            Console.WriteLine("AutoChecked: Can get from slot 0?");
            valueGotten = sa.GetAtIndex(0);
            if (valueGotten != 0)
            {
                Console.WriteLine("TEST FAILED: UNABLE TO GET ELEMENT 0, OR UNEXPECTED VALUE!");
                Console.WriteLine("             (EXPECTED 0, GOT {0})", valueGotten);
            }
            else
                Console.WriteLine("Test Passed: Able to get expected value from slot 0!");
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Can get from slots 0-4?");
            testPassed = true;
            for (int i = 0; i < SMART_ARRAY_SIZE; i++)
            {
                valueGotten = sa.GetAtIndex(i);
                if (valueGotten != 10 * i)
                {
                    Console.WriteLine("TEST FAILED: UNABLE TO GET ELEMENT {0}, OR UNEXPECTED VALUE!", i);
                    Console.WriteLine("             (EXPECTED {0}, GOT {1})", i * 10, valueGotten);
                    testPassed = false;
                    break; // out of the loop
                }
            }
            if (testPassed)
                Console.WriteLine("Test Passed: Able to get expected values!");
            Console.WriteLine("\n*******************\n");


            Console.WriteLine("AutoChecked: Should NOT be able to get from slot {0}?", SMART_ARRAY_SIZE);
            if (sa.GetAtIndex(SMART_ARRAY_SIZE) != Int32.MinValue)
                Console.WriteLine("TEST FAILED: ABLE TO GET FROM ELEMENT {0}?", SMART_ARRAY_SIZE);
            else
                Console.WriteLine("Test Passed: Unable to get from slot {0}!", SMART_ARRAY_SIZE);
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Should NOT be able to get from slot {0}?", SMART_ARRAY_SIZE + 10);
            if (sa.GetAtIndex(SMART_ARRAY_SIZE + 10) != Int32.MinValue)
                Console.WriteLine("TEST FAILED: ABLE TO GET FROM ELEMENT {0}?", SMART_ARRAY_SIZE + 10);
            else
                Console.WriteLine("Test Passed: Unable to get from slot {0}!", SMART_ARRAY_SIZE + 10);
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Should NOT be able to get from slot -1?");
            if (sa.GetAtIndex(-1) != Int32.MinValue)
                Console.WriteLine("TEST FAILED: ABLE TO GET FROM SLOT -1!");
            else
                Console.WriteLine("Test Passed: Unable to get from slot -1!");
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Should NOT be able to get from slot -10?");
            if (sa.GetAtIndex(-10) != Int32.MinValue)
                Console.WriteLine("TEST FAILED: ABLE TO GET FROM SLOT -10!");
            else
                Console.WriteLine("Test Passed: Unable to get from slot -10!");
            Console.WriteLine("\n*******************\n");


            Console.WriteLine("================= Find =================");
            Console.WriteLine("AutoChecked: Can find 0?");
            if (!sa.Find(0))
                Console.WriteLine("TEST FAILED: UNABLE TO FIND VALUE 0!");
            else
                Console.WriteLine("Test Passed: Able to find value 0!");
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Can find the values in slots 0-4?");
            testPassed = true;
            for (int i = 0; i < SMART_ARRAY_SIZE; i++)
            {
                valueGotten = sa.GetAtIndex(i);
                if (!sa.Find(valueGotten)) // test by getting from array
                {
                    Console.WriteLine("TEST FAILED: UNABLE TO FIND {0}!", valueGotten);
                    testPassed = false;
                    break; // out of the loop
                }
            }
            if (testPassed)
                Console.WriteLine("Test Passed: Able to find values that are already in the array!");
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Can find the values calculated to be in slots 0-4?");
            testPassed = true;
            for (int i = 0; i < SMART_ARRAY_SIZE; i++)
            {
                if (!sa.Find(i * 10)) // test by re-calculating the result
                {
                    Console.WriteLine("TEST FAILED: UNABLE TO FIND {0}!", i * 10);
                    testPassed = false;
                    break; // out of the loop
                }
            }
            if (testPassed)
                Console.WriteLine("Test Passed: Able to find values calculated to be in the array!");
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Should NOT be able to find -1?");
            if (sa.Find(-1))
                Console.WriteLine("TEST FAILED: ABLE TO FIND -1, WHICH SHOULD NOT BE PRESENT");
            else
                Console.WriteLine("Test Passed: Unable to find nonexistent value -1!");
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Should NOT be able to find -10?");
            if (sa.Find(-10))
                Console.WriteLine("TEST FAILED: ABLE TO FIND -10, WHICH SHOULD NOT BE PRESENT");
            else
                Console.WriteLine("Test Passed: Unable to find nonexistent value -10!");
            Console.WriteLine("\n*******************\n");

            Console.WriteLine("AutoChecked: Should NOT be able to find 11?");
            if (sa.Find(11))
                Console.WriteLine("TEST FAILED: ABLE TO FIND 11, WHICH SHOULD NOT BE PRESENT");
            else
                Console.WriteLine("Test Passed: Unable to find nonexistent value 11!");
            Console.WriteLine("\n*******************\n");
        }
    }
}
