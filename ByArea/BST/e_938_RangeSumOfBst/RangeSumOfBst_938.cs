namespace ByArea.BST.RangeSumOfBst_938_e;

/*
 This is my first task! I solved it without seeing any hints and other solutions! 2024 - 03 - 19. Time is 23:31 
 
 https://leetcode.com/problems/range-sum-of-bst/description/

Given the root node of a binary search tree and two integers low and high, 
return the sum of values of all nodes with a value in the inclusive range [low, high].
It takes 200 ms
 */
public class RangeSumOfBst_938
{
    public void Traverse(TreeNode<int> tree)
    {
        if (tree != null)
        {
            Console.WriteLine("Value: " + tree.val);

            if (tree.left != null)
            {
                Traverse(tree.left);
            }

            if (tree.right != null)
            {
                Traverse(tree.right);
            }
        }

        return;
    }

    public int RangeSumBST(TreeNode<int> root, int low, int high)
    {
        int left = 0;
        int right = 0;

        if (root != null)
        {
            if (root.left != null)
            {
                left = RangeSumBST(root.left, low, high);
            }

            if (root.right != null)
            {
                right = RangeSumBST(root.right, low, high);
            }
        }

        return GetValue(root.val, low, high) + left + right;
    }

    private int GetValue(int value, int low, int high)
    {
        if (value >= low
            && value <= high)
        {
            return value;
        }

        return 0;
    }
}


public class BootStrapper_RangeSumOfBst_938
{
    public int Run()
    {
        TreeNode<int> tree_1 = new TreeNode<int>() { val = 1 };
        TreeNode<int> tree_3 = new TreeNode<int>() { val = 3, left = tree_1 };

        TreeNode<int> tree_6 = new TreeNode<int>() { val = 6 };
        TreeNode<int> tree_7 = new TreeNode<int>() { val = 7, left = tree_6 };
        TreeNode<int> tree_5 = new TreeNode<int>() { val = 5, left = tree_3, right = tree_7 };


        TreeNode<int> tree_13 = new TreeNode<int>() { val = 13 };
        TreeNode<int> tree_18 = new TreeNode<int>() { val = 18 };
        TreeNode<int> tree_15 = new TreeNode<int>() { val = 15, left = tree_13, right = tree_18 };

        TreeNode<int> tree_10 = new TreeNode<int>()
        {
            val = 10,
            left = tree_5,
            right = tree_15
        };

        return new RangeSumOfBst_938().RangeSumBST(tree_10, 6, 10);
    }

    public int RunSecond()
    {
        TreeNode<int> tree_3 = new TreeNode<int>() { val = 3 };
        TreeNode<int> tree_7 = new TreeNode<int>() { val = 7 };
        TreeNode<int> tree_5 = new TreeNode<int>()
        {
            val = 5,
            left = tree_3,
            right = tree_7
        };

        TreeNode<int> tree_18 = new TreeNode<int>() { val = 18 };
        TreeNode<int> tree_15 = new TreeNode<int>()
        {
            val = 15,
            right = tree_18
        };

        TreeNode<int> tree_10 = new TreeNode<int>()
        {
            val = 10,
            left = tree_5,
            right = tree_15
        };

        return new RangeSumOfBst_938().RangeSumBST(tree_10, 7, 15);
    }
}