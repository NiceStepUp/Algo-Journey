namespace ByArea.BST.TwoSumIVInputIsABST_653_e;

/*
https://leetcode.com/problems/two-sum-iv-input-is-a-bst/description/ 

Description:
Given the root of a binary search tree and an integer k, return true if there
exist two elements in the BST such that their sum is equal to k, or false otherwise.

 

Example 1:


Input: root = [5,3,6,2,4,null,7], k = 9
Output: true
Example 2:


Input: root = [5,3,6,2,4,null,7], k = 28
Output: false
 */


/*
 Runtime 156 ms Beats 5.26% of users with C#
Memory 53.12 MB Beats 90.23% of users with C#
 */
internal class TwoSumIVInputIsABST_653_e_BySorting
{
    public bool FindTarget(TreeNode root, int k)
    {
        List<int> numbers = new List<int>();

        bool hasTwoSum = GetNumbers(root, numbers, k);
        return hasTwoSum;
    }

    private bool GetNumbers(TreeNode root, List<int> numbers, int target)
    {
        if (root != null)
        {

            if (root.left != null)
            {
                if (GetNumbers(root.left, numbers, target))
                {
                    return true;
                }
            }

            numbers.Add(root.val);

            bool hasTwoSum = HasTwoSum(numbers, target);
            if (hasTwoSum)
            {
                return true;
            }

            if (root.right != null)
            {
                if (GetNumbers(root.right, numbers, target))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool HasTwoSum(List<int> numbers, int target)
    {
        bool hasTwoSum = false;
        int left = 0;
        int right = numbers.Count - 1;

        while (left < right)
        {
            int sum = numbers[left] + numbers[right];
            if (target == sum)
            {  
                hasTwoSum = true; 
                break; 
            }

            if (target < sum)
            {
                right--;
            }
            else
            {
                left++;
            }
        }

        return hasTwoSum;
    }
}

/*
Result:
Accepted!
Runtime 151 ms Beats 5.22% of users with C#

Memory 52.83 MB Beats 97.01% of users with C#

 */
internal class TwoSumIVInputIsABST_653_e
{
    public bool FindTarget(TreeNode root, int k)
    {
        List<int> numbers = new List<int>();

        bool hasTwoSum = GetNumbers(root, numbers, k);
        return hasTwoSum;
    }

    private bool GetNumbers(TreeNode root, List<int> numbers, int target)
    {
        if (root != null)
        {
            numbers.Add(root.val);
            
            bool hasTwoSum = HasTwoSum(numbers, target);
            if (hasTwoSum) 
            {
                return true;
            }

            if (root.left != null)
            {
                if (GetNumbers(root.left, numbers, target))
                {
                    return true;
                }
            }

            if (root.right != null)
            {
                if (GetNumbers(root.right, numbers, target))
                {
                    return true;
                }
            }
        }

        return false;        
    }

    private bool HasTwoSum(List<int> numbers, int target)
    {
        bool hasTwoSum = false;
        int left = 0;
        int right = numbers.Count - 1;

        for (int i = right; i >= 0; i--)
        {
            while (left < right)
            {
                if ((numbers[left] + numbers[right]) == target)
                {
                    hasTwoSum = true;
                    break;
                }
                left++;
            }

            if (hasTwoSum)
            {
                break;
            }
        }

        return hasTwoSum;
    }
}

public class BootStrapper_TwoSumIVInputIsABST_653_e
{
    public bool Run()
    {
        TreeNode tree_2 = new TreeNode() { val = 2 };
        TreeNode tree_4 = new TreeNode() { val = 4 };
        TreeNode tree_3 = new TreeNode() { val = 3, left = tree_2, right = tree_4 };
        
        
        TreeNode tree_7 = new TreeNode() { val = 7 };
        TreeNode tree_6 = new TreeNode() { val = 6, right = tree_7 };

        TreeNode tree_5 = new TreeNode()
        {
            val = 5,
            left = tree_3,
            right = tree_6
        };
        

        /*TreeNode tree_2 = new TreeNode() { val = 2 };
        TreeNode tree_3 = new TreeNode() { val = 3 };

        TreeNode tree_1 = new TreeNode()
        {
            val = 1,
            left = tree_2,
            right = tree_3
        };*/

        bool hasTarget = new TwoSumIVInputIsABST_653_e_BySorting().FindTarget(tree_5, 9);
        return hasTarget;
    }
}
