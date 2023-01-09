using System.Diagnostics;

namespace Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random rnd = new Random();
            int arrSize = 0;

            Console.WriteLine("\nWelcome to Algos\n");

            bool ok = false;
            while(!ok) {
                Console.WriteLine("Enter array size: ");
                if(!int.TryParse(Console.ReadLine(), out arrSize)) {
                    Console.WriteLine("Invalid input.  Array size must be an integer between 1 and " + int.MaxValue);
                }
                else {
                    ok = true;
                }
            }


            Console.WriteLine($"\nGenerating array consisting of random integers between 1 and {arrSize}.");

            var arr = new List<int>();
            for(int i = 0; i < arrSize; i++) {
                arr.Add(rnd.Next(arrSize + 1));
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey(true);
            Console.WriteLine("Unsorted array:\n");
            foreach(var v in arr) Console.Write(" " + v);

            /****   Bubble Sort:   ****/
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nPress any key to perform bubble sort.");
            Console.ReadKey(true);

            Stopwatch s = new Stopwatch();
            s.Start();
            var sorted = BubbleSort(arr);
            s.Stop();

            Console.WriteLine("\nSorted array: ");
            foreach(var v in sorted) Console.Write(" " + v);
            Console.WriteLine("\nElapsed time: " + s.Elapsed);
            Console.ReadKey(true);

            /****    Selection Sort:    ****/
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\nPress any key to perform selection sort.");
            Console.ReadKey(true);

            Stopwatch s1 = new Stopwatch();
            s1.Start();
            var selSorted = SelectionSort(arr);
            s1.Stop();

            Console.WriteLine("\nSorted array: ");
            foreach(var v in selSorted) Console.Write(" " + v);
            Console.WriteLine($"\nElapsed time: {s1.Elapsed}.");
            Console.ReadKey(true);

            /****    Insertion Sort:    ****/
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\nReady for insertion sort.");
            Console.ReadKey(true);

            Stopwatch s2 = new Stopwatch();
            s2.Start();
            var insSorted = InsertionSort(arr);
            s2.Stop();
            Console.WriteLine("\nSorted array: ");
            foreach(var v in insSorted) Console.Write(" " + v);
            Console.WriteLine($"\nElapsed time: {s2.Elapsed}.");
            Console.ReadKey(true);


            /***   Merge Sort:   ***/
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\nReady for merge sort.");
            Console.ReadKey(true);

            Stopwatch s3 = new Stopwatch();
            s3.Start();
            var mergeSorted = MergeSort(arr, 0, arr.Count - 1);
            s3.Stop();
            Console.WriteLine("\nSorted: ");
            foreach(var v in mergeSorted) Console.Write(" " + v);
            Console.WriteLine($"\nElapsed time: {s3.Elapsed}");


            Console.ReadKey(true);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n\nComparison of sorting times for {arrSize} numbers: \n\tBubble sort: {s.Elapsed}\n\tSelection sort: {s1.Elapsed}\n\tInsertion sort: {s2.Elapsed}\n\tMerge sort: {s3.Elapsed}");
            Console.ReadKey(true);



            Console.WriteLine("\n\nGoodbye!");
            Console.ReadKey(true);
        }

        static List<int> BubbleSort(List<int> arr)
        {
            bool done = false;
            List<int> lst = new List<int>();
            foreach(var v in arr) lst.Add(v);
            int arrSize = lst.Count;

            while(!done) {
                done = true;
                for(int i = 0; i < arrSize - 1; i++) {
                    if(lst[i + 1] < lst[i]) {
                        done = false;
                        int tmp = lst[i];
                        lst[i] = lst[i + 1];
                        lst[i + 1] = tmp;
                    }
                }
            }
            return lst;
        }

        static List<int> SelectionSort(List<int> arr)
        {
            var selArr = new List<int>();
            foreach(var v in arr) selArr.Add(v);
            var done = false;
            var idx = 0;
            var minIdx = 0;

            while(!done) {
                done = true;
                var minVal = selArr[idx];
                for(int i = idx + 1; i < selArr.Count; i++) {
                    if(selArr[i] < minVal) {
                        minVal = selArr[i];
                        minIdx = i;
                        done = false;
                    }
                }
                if(!done) {
                    var tmp = selArr[idx];
                    selArr[idx] = minVal;
                    selArr[minIdx] = tmp;
                    idx++;
                }
            }
            return selArr;
        }

        static List<int> InsertionSort(List<int> arr)
        {
            var insArr = new List<int>();
            foreach(var v in arr) insArr.Add(v);
            var idx = 0;
            var insIdx = 0;
            var insVal = 0;
            var arrSize = insArr.Count;

            while(idx < arrSize - 1) {
                if(insArr[idx + 1] < insArr[idx]) {
                    insVal = insArr[idx + 1];
                    for(int i = 0; i <= idx; i++) {
                        if(insVal < insArr[i]) {
                            insIdx = i;
                            break;
                        }
                    }
                    for(int j = idx; j >= insIdx; j--) {
                        insArr[j] = j == insIdx ? insVal : insArr[j - 1];
                    }
                }
                idx++;
            }
            return insArr;
        }


        /*  TODO: Fix MergeSort.  */
        static List<int> MergeSort(List<int> arr, int leftIdx, int rightIdx)
        {
            //Sort(arr, leftIdx, rightIdx);
            Console.WriteLine("Testing Merge:");
            var test = new List<int> { 8, 4, 6, 1, 2, 5, 3, 7, 9 };
            Console.WriteLine("Before merge:\n");
            foreach(var v in test) Console.Write(v + " ");
            Merge(test, 0, 8);
            Console.WriteLine("\nAfter merge:\n");
            foreach(var v in test) Console.Write(v + " ");
            Console.ReadKey(true);

            return new List<int> { };
        }

        static void Sort(List<int> arr, int leftIdx, int rightIdx)
        {
            if(leftIdx < rightIdx) {
                int middleIdx = leftIdx + rightIdx / 2;
                Sort(arr, leftIdx, middleIdx);
                Sort(arr, middleIdx + 1, rightIdx);
                Merge(arr, leftIdx, rightIdx);
            }
        }
        static void Merge(List<int> arr, int leftIdx, int rightIdx)
        {
            List<int> tmp = new List<int>();

            for(int i=leftIdx; i<=rightIdx; i++) tmp.Add(arr[i]);

            //arr:  1 3 5 2 7 5 7 0 9
            //tmp:        2 7 5 7
            //i:    0 1 2 3 4 5 6 7 8
            //leftidx: 3
            //rightidx: 6

            //tmp should end up: 2 5 7 7
            //then copy tmp into arr[3..6]


            for(int i=0;i<tmp.Count;i++) {
                for(int j=0;j<tmp.Count;j++) {
                    if(tmp[i] < tmp[j]) {
                        int temp = tmp[i];
                        tmp[i]= tmp[j];
                        tmp[j] = temp;
                        break;
                    }
                }
            }

            for(int i=0;i<tmp.Count;i++) {
                arr[leftIdx+i] = tmp[i];
            }
           
        }

    }
}