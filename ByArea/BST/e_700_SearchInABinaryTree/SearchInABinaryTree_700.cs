namespace ByArea.BST.SearchInABinaryTree_700_e;

/// <summary>
/// https://leetcode.com/problems/search-in-a-binary-search-tree/description/
/// You are given the root of a binary search tree (BST) and an integer val.
/// Find the node in the BST that the node's value equals val and return the subtree rooted with that node. If such a node does not exist, return null.
/// </summary>
public class SearchInABinaryTree_700
{
    /*
     * This is my solution and I have solved it from the first attempt!
     * 95 ms Beats 93.73% of users with C#
     * 50.00 MB Beats 96.40% of users with C#
     */
    public TreeNode SearchBST(TreeNode root, int val)
    {
        if (root != null)
        {
            if (root.val == val)
            {
                return root;
            }

            if (root.left != null)
            {
                TreeNode tree = SearchBST(root.left, val);
                if (tree != null)
                {
                    return tree;
                }
            }

            if (root.right != null)
            {
                TreeNode tree = SearchBST(root.right, val);
                if (tree != null)
                {
                    return tree;
                }
            }
        }

        return null;
    }
}

public class BootStrapper_RangeSumOfBst_700
{
    public void RunFirst()
    {
        TreeNode tree_1 = new TreeNode() { val = 1 };
        TreeNode tree_3 = new TreeNode() { val = 3 };
        TreeNode tree_2 = new TreeNode() { val = 2, left = tree_1, right = tree_3 };

        TreeNode tree_7 = new TreeNode() { val = 7 };
        TreeNode tree_4 = new TreeNode() { val = 4, left = tree_2, right = tree_7 };


        TreeNode result = new SearchInABinaryTree_700().SearchBST(tree_4, 5);
    }
}
