namespace ByArea.BST.m_1382_BalanceABinarySearchTree;

/*
https://leetcode.com/problems/balance-a-binary-search-tree/description/

Runtime 148 ms Beats 12.16% of users with C#
Memory 58.78 MB Beats 33.78% of users with C# 

Having read the article  https://www.geeksforgeeks.org/convert-normal-bst-balanced-bst/ ,
I solved this task by myself

Complexity

Time & Space: O(n)
 */
internal class m_1382_BalanceABinarySearchTree
{
    public TreeNode BalanceBST(TreeNode root)
    {
        List<int> values = new();
        GetValuesByInOrderTraverse(root, values);
        var node = MakeBst(values, 0, values.Count - 1);
        return node;
    }

    private void GetValuesByInOrderTraverse(TreeNode root, List<int> values)
    {
        if (root == null)
        {
            return;
        }

        if (root.left != null)
        {
            GetValuesByInOrderTraverse(root.left, values);
        }

        values.Add(root.val);

        if (root.right != null)
        {
            GetValuesByInOrderTraverse(root.right, values);
        }
    }

    private TreeNode MakeBst(List<int> values, int left, int right)
    {
        if (left > right)
        {
            return null;
        }

        int middle = (left + right) / 2;

        TreeNode node = new TreeNode() { val = values[middle] };
        node.left = MakeBst(values, left, middle - 1);
        node.right = MakeBst(values, middle + 1, right);
        return node;
    }
}

public class m_1382_BalanceABinarySearchTree_Bootstrapper
{
    public void Run()
    {
        TreeNode tree_4 = new TreeNode() { val = 4 };
        TreeNode tree_3 = new TreeNode() { val = 3, right = tree_4 };
        TreeNode tree_2 = new TreeNode() { val = 2, right = tree_3 };
        TreeNode tree_1 = new TreeNode() { val = 1, right = tree_2 };

        new m_1382_BalanceABinarySearchTree().BalanceBST(tree_1);
    }
}
