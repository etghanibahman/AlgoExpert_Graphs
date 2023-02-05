using System;
using System.Collections.Generic;

namespace SingleCycleCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 2, 3, 1, -4, -4, 2 };
            array = new int[] { 1, 2, 3, 4, -2, 3, 7, 8, -26 }; //Test case 13
            Console.WriteLine($"Array :{ String.Join<int>(',', array)}");
            Console.WriteLine($"does this array has single cycle? {HasSingleCycle(array)}");
        }

        // but this one only checks if by beginning from 0 it has a cycle, but still it works for this question in website!
        #region Solution O(n) Time, O(1) Space
        public static bool HasSingleCycle(int[] array)
        {
            var visited = 0;
            var i = 0;
            while (array[i] != int.MinValue)
            {
                var jumps = array[i];
                array[i] = int.MinValue;
                i = ((i + jumps % array.Length) + array.Length) % array.Length;
                visited += 1;
            }
            return visited == array.Length && i == 0;
        }
        #endregion


        #region My_Solution__ O(n) Time, O(n) space
        //public static bool HasSingleCycle(int[] array)
        //{
        //    Dictionary<int, bool> valueCheckDic = new Dictionary<int, bool>();
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        valueCheckDic.Add(i, false);
        //    }

        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        makeDicRefereshed(valueCheckDic, array.Length);
        //        var beggining = array[i];
        //        valueCheckDic[i] = true;
        //        int counter = 1;
        //        int nextIndex = CalculateNextIndex(i, array[i], array.Length);
        //        while (counter < array.Length)
        //        {
        //            if (valueCheckDic[nextIndex] == true)
        //            {
        //                break;
        //            }
        //            valueCheckDic[nextIndex] = true;
        //            nextIndex = CalculateNextIndex(nextIndex, array[nextIndex], array.Length);
        //            counter++;
        //        }
        //        if (nextIndex == i && counter == array.Length)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        //public static void makeDicRefereshed(Dictionary<int, bool> valueCheckDic, int len)
        //{
        //    for (int i = 0; i < len; i++)
        //    {
        //        valueCheckDic[i] = false;
        //    }
        //}
        //public static int CalculateNextIndex(int currentIndex, int jump, int len)
        //{
        //    int res = currentIndex + jump;
        //    res = res % len;
        //    if (res >= len)
        //    {
        //        res = res - len;
        //    }
        //    else if (res < 0)
        //    {
        //        res = len + res;
        //    }
        //    return res;
        //}
        #endregion
    }
}
