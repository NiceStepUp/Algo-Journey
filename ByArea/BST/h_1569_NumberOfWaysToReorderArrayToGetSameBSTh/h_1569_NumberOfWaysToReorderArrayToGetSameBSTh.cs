namespace ByArea.BST.h_1569_NumberOfWaysToReorderArrayToGetSameBSTh;

/*
https://leetcode.com/problems/number-of-ways-to-reorder-array-to-get-same-bst/description/

Given an array nums that represents a permutation of integers from 1 to n. We are going to construct a binary search tree (BST) by inserting the elements of nums in order into an initially empty BST. Find the number of different ways to reorder nums so that the constructed BST is identical to that formed from the original array nums.

For example, given nums = [2,1,3], we will have 2 as the root, 1 as a left child, and 3 as a right child. The array [2,3,1] also yields the same BST but [3,2,1] yields a different BST.
Return the number of ways to reorder nums such that the BST formed is identical to the original BST formed from nums.

Since the answer may be very large, return it modulo 109 + 7.

 

Example 1:

        2
       / \
      1   3

Input: nums = [2,1,3]
Output: 1
Explanation: We can reorder nums to be [2,3,1] which will yield the same BST. There are no other ways to reorder nums which will yield the same BST.

Example 2:

                3
              /   \
             1     4
              \     \
               2     5

Input: nums = [3,4,5,1,2]
Output: 5
Explanation: The following 5 arrays will yield the same BST: 
[3,1,2,4,5]
[3,1,4,2,5]
[3,1,4,5,2]
[3,4,1,2,5]
[3,4,1,5,2]


Example 3:

    1
     \
      2
       \
        3


Input: nums = [1,2,3]
Output: 0
Explanation: There are no other orderings of nums that will yield the same BST.
 

Constraints:

1 <= nums.length <= 1000
1 <= nums[i] <= nums.length
All integers in nums are distinct.

 */

internal class h_1569_NumberOfWaysToReorderArrayToGetSameBSTh
{

    /*
    https://leetcode.com/problems/number-of-ways-to-reorder-array-to-get-same-bst/solutions/819369/c-just-using-recursion-very-clean-and-easy-to-understand-o-n-2/

    So, we can know that for a fixed root, the left subtree elements and the right subtree elements are also fixed.

    We can find the left subtree elements which are all the elements that is smaller than root value, and right subtree elements which are greater than root value.

    And in order to make it identical with original BST, we should keep the relative order in left subtree elements and in right subtree elements.

    Assume the lenght of left subtree elements is left_len and right is right_len, they can change their absolute position but need to keep their relative position in either left subtree or right right subtree.

    So as the subtree, so we use recursion.
    */

    /*
     Example:

[3, 4, 5, 1, 2] // original array with root value is 3

[1, 2] // left sub-sequence, left_len = 2
[4, 5] // right sub-sequence, right_len = 2

// the left sub-sequence and right sub-sequence take 4 position, because left_len + right_len = 4

// keep relative order  in left sub-sequence and in right-sequence, but can change absolute position.
[1, 2, 4, 5]
[1, 4, 2, 5]
[1, 4, 5, 2]
[4, 1, 2, 5]
[4, 1, 5, 2]
[4, 5, 1, 2]
// number of permutation: 6

// in code, we use Pascal triangle to keep a table of permutations, so we can look up the table and get permutation result in O(1)
// Pascal trianle and Binomial coefficient are explained greatly here https://www.youtube.com/watch?v=lbl9nxwFWDw

*/


    /*
     https://www.youtube.com/watch?v=wDROrQwyZjQ&t=2s

     My explanation for this array:
    [3, 4, 5, 1, 2]

    1) the first option is:
        3 4 5 _ _

    2) the first option is:
        3 4 _ 5 _

    3) the first option is:
        3 4 _ _ 5        

    4) the first option is:
        3 _ 4  5 _

    5) the first option is:
        3 _ 4 _ 5

    6) the first option is:
        3 _ _ 4 5 

    То есть количество комбинаций на 4 квадратиках для 2 квадратиках можно вычислить по формуле:

    "количество элементов в массиве - 1" и комбинация длины массива элементов левого массива
    или её решение:
    (4!) / (2! * (4 - 2)!) = 24/4 = 6 
    Answer: 6 - 1 = 5
     */
    List<List<long>> table = new List<List<long>>();

    public int NumOfWays(int[] nums)
    {
        long mod = (int)1e9 + 7;
        int length = nums.Length;

        if (nums.Length == 3)
            return 1;

        // Filling the Pascal triangle by Binomial coefficients. The table looks like this:
        // 1 
        // 1  1
        // 1  2   1
        // 1  3   3   1
        // 1  4   6   4   1
        // 1  5   10  10  5  1
        for (int i = 0; i < length + 1; ++i)
        {
            table.Add(new List<long>());
            for (int j = 0; j < i + 1; ++j)
            {
                table[i].Add(1);
            }
            for (int j = 1; j < i; ++j)
            {
                table[i][j] = (table[i - 1][j - 1] + table[i - 1][j]) % mod;
            }
        }
        
        long ans = Dfs(nums, mod);
        return (int)((ans % mod) - 1);
    }

    private long Dfs(int[] nums, long mod)
    {
        int numsLength = nums.Length;
        if (numsLength <= 2) return 1;

        // find left sub-sequence elements and right sub-sequence elements
        List<int> lefts = new ();
        List<int> rights = new ();
        for (int i = 1; i < nums.Length; ++i)
        {
            if (nums[i] < nums[0]) 
                lefts.Add(nums[i]);
            else 
                rights.Add(nums[i]);
        }

        // recursion with left subtree and right subtree
        long leftAnswer = Dfs(lefts.ToArray(), mod) % mod;
        long rightAnswer = Dfs(rights.ToArray(), mod) % mod;

        // look up table and multiply them together
        int leftLength = lefts.Count;
        return (((table[numsLength - 1][leftLength] * leftAnswer) % mod) * rightAnswer) % mod; // Formula
    }
}

/*
Original solution in C++:

class Solution {
public:
    int numOfWays(vector<int>& nums) {
        long long mod = 1e9 + 7;
		int n = nums.size();
        
		// Pascal triangle
        table.resize(n + 1);
        for(int i = 0; i < n + 1; ++i){
            table[i] = vector<long long>(i + 1, 1);
            for(int j = 1; j < i; ++j){
                table[i][j] = (table[i-1][j-1] + table[i-1][j]) % mod;
            }
        }
        
        long long ans = dfs(nums, mod);
        return ans % mod - 1;
    }
    
private:
    vector<vector<long long>> table;
    long long dfs(vector<int> &nums, long long mod){
        int n = nums.size();
        if(n <= 2) return 1;
        
		// find left sub-sequence elements and right sub-sequence elements
        vector<int> left, right;
        for(int i = 1; i < nums.size(); ++i){
            if(nums[i] < nums[0]) left.push_back(nums[i]);
            else right.push_back(nums[i]);
        }
		
		// recursion with left subtree and right subtree
        long long left_res = dfs(left, mod) % mod;
        long long right_res = dfs(right, mod) % mod;
		
		// look up table and multiple them together
		int left_len = left.size(), right_len = right.size();
        return (((table[n - 1][left_len] * left_res) % mod) * right_res) % mod;
    }
};
 
 */


public class h_1569_NumberOfWaysToReorderArrayToGetSameBSThBootstrap
{
    public void Run() 
    {
        // [3, 4, 5, 1, 2]
        // int[] numbers = [3, 4, 5, 1, 2];
        int[] numbers = [5, 6, 7, 8, 9, 10, 0, 1, 2, 3, 4];
        h_1569_NumberOfWaysToReorderArrayToGetSameBSTh numberOfWaysToReorderArrayToGetSameBSTh = new();
        int result = numberOfWaysToReorderArrayToGetSameBSTh.NumOfWays(numbers);
        Console.WriteLine(result);
    }
}