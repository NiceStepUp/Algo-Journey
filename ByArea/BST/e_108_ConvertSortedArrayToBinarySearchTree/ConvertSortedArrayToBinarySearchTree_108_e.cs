namespace ByArea.BST.ConvertSortedArrayToBinarySearchTree_108_e;

/*
 108. Convert Sorted Array to Binary Search Tree

Given an integer array nums where the elements are sorted in ascending order, convert it to a 
height-balanced binary search tree. 

Example 1:

                0
               / \
             -3   9
             /\
           -10 5


Input: nums = [-10,-3,0,5,9]
Output: [0,-3,9,-10,null,5]
Explanation: [0,-10,5,null,-3,null,9] is also accepted:


                0
               / \
             -10  5
                \  \
                -3  9  

Example 2:

    3      1
   /        \
  1          3
                
Input: nums = [1,3]
Output: [3,1]
Explanation: [1,null,3] and [3,1] are both height-balanced BSTs.
 

Constraints:

1 <= nums.length <= 104
-104 <= nums[i] <= 104
nums is sorted in a strictly increasing order.
 */


// Challenge:
// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/description/

// Solution:
// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/solutions/35220/my-accepted-java-solution/
internal class ConvertSortedArrayToBinarySearchTree_108_e
{
    public TreeNode SortedArrayToBST(int[] nums)
    {
        TreeNode root = ToBST(nums, 0, nums.Length - 1);
        return root;
    }

    private TreeNode ToBST(int[] nums, int left, int right)
    {   
        if (left > right)
        {
            return null;
        }

        int middle = (left + right) / 2;

        TreeNode root = new() { val = nums[middle] };
        root.left = ToBST(nums, left, middle - 1);
        root.right = ToBST(nums, middle + 1, right);

        return root;
    }
}

public class ConvertSortedArrayToBinarySearchTree_108_e_Bootsrapper
{
    public TreeNode Run() 
    {
        int[] nums = { -10, -3, 0, 5, 9 };
        TreeNode treeNode = new ConvertSortedArrayToBinarySearchTree_108_e().SortedArrayToBST(nums);
        return treeNode;
    }
}

/*
 Explanation:
    The idea of this solution is:
1. We search the middle element of an array
2. What we do is we say that this is our left tree and this is our right tree
    Given the following array:
    
    [ -4,  -3,  -2,   -1, 0, 1,  2,  3,     4 ]
     |__leftArray__|            |_rightArray_|

3. We repeat the process
  
So the balanced tree would like this:

                                            0
                                           / \
                                          /   \
                                        -3      2
                                        / \     /\
                                      -4  -2   1  3
                                            \      \
                                            -1      4
 */