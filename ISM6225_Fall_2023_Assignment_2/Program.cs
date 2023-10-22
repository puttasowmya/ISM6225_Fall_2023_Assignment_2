/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                // Define a list to store the missing ranges
                List<IList<int>> result = new List<IList<int>>();

                // Variables to track the start and end of a missing range
                int start;
                int end;


                // Check and add a range before the first element if needed

                if (nums[0] > lower)
                {

                    start = lower;
                    end = nums[0] - 1;

                    // Ensure the range is valid (start should be less than or equal to end)

                    if (start <= end)
                    {
                        result.Add(new List<int> { start, end });
                       
                    }
                }

                // Iterate through the elements in nums to find missing ranges


                for (int i = 0; i < nums.Length - 1; i++)
                {
                    if (nums[i] >= lower && nums[i] <= upper)
                    {
                        start = nums[i];
                        end = nums[i + 1];

                        // Calculate the range between the current and next element
                        start++; // Increment by 1 to exclude the current element
                        end--;   // Decrement by 1 to exclude the next element

                        // Ensure the range is valid (start should be less than or equal to end)
                        if (start <= end)
                        {
                            result.Add(new List<int> { start, end });
                            

                        }

                    }

                }
                // Check and add a range after the last element if needed
                if (nums[nums.Length - 1] < upper)
                {

                    start = nums[nums.Length - 1] + 1;
                    end = upper;

                    // Ensure the range is valid (start should be less than or equal to end)
                    if (start <= end)
                    {
                        result.Add(new List<int> { start, end });
                    }
                }

                return result;
            }

            
            catch (Exception)
            {
                throw;
            }

        }

        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
            // Initialize a stack to keep track of open brackets
            Stack<char> stack = new Stack<char>();
             // Define a dictionary to map closing brackets to their corresponding open brackets
             Dictionary<char, char> dd = new Dictionary<char, char>
        {
            {')', '('},
            {'}', '{'},
            {']', '['}
        };
                // Iterate through each character in the input string

                foreach (char c in s)
            {
                // If the current character is an open bracket, push it to stack
                if (dd.ContainsValue(c))
                {
                    stack.Push(c);
                }
                // If the current character is a closing bracket
                else if (dd.ContainsKey(c))
                {
                    // Check if the stack is empty or the top of the stack does not match the expected open bracket
                    if (stack.Count == 0 || stack.Pop() != dd[c])
                    {
                        return false; // Mismatched brackets, the string is invalid
                        }
                }
                else
                {
                    return false; // Invalid character, not a bracket
                    }
            }
            
            // If the stack is empty, all brackets were properly matched and closed
            return stack.Count == 0;
            }
            catch (Exception)
                {
                     throw;
                }
}

        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Initialize variables for the maximum profit and minimum price
                int maxProfit = 0;
                int minPrice = int.MaxValue;

                for (int i = 0; i < prices.Length; i++)
                {
                    // Update the minimum price if a lower price is found
                    if (prices[i] < minPrice)
                    {
                        minPrice = prices[i];
                    }
                    // Calculate the profit if sold on the current day
                    int Profit = prices[i] - minPrice;

                    // Update the maximum profit if a higher profit is found
                    if (Profit > maxProfit)
                    {
                        maxProfit = Profit;
                    }
                }

                return maxProfit;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {
                // Define a dictionary to represent valid strobogrammatic pairs
                Dictionary<char, char> Pairs = new Dictionary<char, char>
        {
            {'0', '0'},
            {'1', '1'},
            {'6', '9'},
            {'8', '8'},
            {'9', '6'}
        };

                // Initialize two pointers to the left and right ends of the string
                int left = 0;
                int right = s.Length - 1;

                // Continue checking pairs until the left pointer crosses or meets the right pointer
                while (left <= right)
                {
                    char leftChar = s[left];
                    char rightChar = s[right];

                    // If either character in the pair is not in the dictionary, it's not strobogrammatic
                    if (!Pairs.ContainsKey(leftChar) || !Pairs.ContainsKey(rightChar))
                    {
                        return false;
                    }

                    // If the pair does not form a valid strobogrammatic pair, return false
                    if (Pairs[leftChar] != rightChar)
                    {
                        return false;
                    }

                    // Move the pointers inward to check the next pair
                    left++;
                    right--;
                }

                // If the loop completes, the number is strobogrammatic
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                // Create a dictionary to store the frequency of each number
                Dictionary<int, int> count = new Dictionary<int, int>();
                int result = 0;

                // Iterate through the array to count the frequency of each number
                foreach (int i in nums)
                {
                    if (count.ContainsKey(i))
                    {
                        // Increment the count if the number is already in the dictionary
                        result += count[i];
                        count[i]++;
                    }
                    else
                    {
                        // Add the number to the dictionary with a frequency of 1
                        count[i] = 1;
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                // Create a HashSet to store distinct numbers
                HashSet<int> hash = new HashSet<int>();

                // Iterate through the array to find the third distinct maximum
                foreach (int number in nums)
                {
                    // Add the current number to the HashSet
                    hash.Add(number);

                    // If there are more than three numbers in the HashSet, remove the minimum number
                    if (hash.Count > 3)
                    {
                        hash.Remove(hash.Min());
                    }
                }

                // Check if there are at least three distinct maximums
                if (hash.Count >= 3)
                {
                    return hash.Min(); // Return the third distinct maximum
                }
                else
                {
                    return hash.Max(); // Return the maximum number if the third distinct maximum does not exist
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                // Initialize a list to store possible next moves
                List<string> list = new List<string>();
                int n = currentState.Length; // length of the input string

                // Iterate through the input string
                for (int i = 0; i < n - 1; i++)
                {
                    // Check if the current character and the next character form a "++" sequence
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        // Create a new state by replacing "++" with "--"
                        string nextState = currentState.Substring(0, i) + "--" + currentState.Substring(i + 2);

                        // Add the new state to the list of possible moves
                        list.Add(nextState);
                    }
                }

                // Return the list of valid moves
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
            // Initialize a StringBuilder to efficiently build the result string
            StringBuilder result = new StringBuilder();

            // Iterate through each character in the input string
            foreach (char c in s)
            {
                // Check if the current character is not a vowel
                if (c != 'a' && c != 'e' && c != 'i' && c != 'o' && c != 'u')
                {
                    // add the character to the result
                    result.Append(c);
                }
            }

            // Convert the result StringBuilder to a string and return it
            return result.ToString();
        }



        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
