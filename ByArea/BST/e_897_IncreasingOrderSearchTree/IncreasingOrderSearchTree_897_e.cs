namespace ByArea.BST.IncreasingOrderSearchTree_897_e;

/// <summary>
/// https://leetcode.com/problems/increasing-order-search-tree/submissions/1209872225/
///  Runtime 61 ms Beats 48.91% of users with C#
///  Memory 39.72 MB Beats 96.74% of users with C#
///  
/// Given the root of a binary search tree, rearrange the tree in in-order so that the leftmost node in the tree is now the root of the tree, and every node has no left child and only one right child.
/// 
/// </summary>
public class IncreasingOrderSearchTree_897_e
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="root">root</param>
    /// <returns>Increasing binary search tree</returns>
    public TreeNode IncreasingBST(TreeNode root)
    {
        TreeNode treeInOrdered = new TreeNode()
        {
            val = int.MinValue
        };
        IncreasingBST(root, treeInOrdered);
        return treeInOrdered;
    }

    public TreeNode IncreasingBST(TreeNode root, TreeNode treeInOrdered)
    {
        if (root != null)
        {
            TreeNode current = treeInOrdered;
            TreeNode first = current;
            if (root.left != null)
            {
                IncreasingBST(root.left, first);
            }

            if (current != null && current.val == int.MinValue)
            {
                current.val = root.val;
            }
            else
            {
                
                while (current.right != null)
                {  
                    current = current.right;
                }
                current.right = new TreeNode() 
                { 
                    val = root.val 
                };
            }

            if (root.right != null)
            {
                IncreasingBST(root.right, first);
            }
        }

        return null;
    }

    public class BootStrapper_IncreasingOrderSearchTree_897_e
    {
        public int Run()
        {
            TreeNode tree_1 = new TreeNode() { val = 1 };
            TreeNode tree_2 = new TreeNode() { val = 2, left = tree_1 };
            TreeNode tree_4 = new TreeNode() { val = 4 };
            TreeNode tree_3 = new TreeNode() { val = 3, left = tree_2, right = tree_4 };


            TreeNode tree_7 = new TreeNode() { val = 7 };
            TreeNode tree_9 = new TreeNode() { val = 9 };
            TreeNode tree_8 = new TreeNode() { val = 8, left = tree_7, right = tree_9 };
            TreeNode tree_6 = new TreeNode() { val = 6, right = tree_8 };

            TreeNode tree_5 = new TreeNode()
            {
                val = 5,
                left = tree_3,
                right = tree_6
            };

            new IncreasingOrderSearchTree_897_e().IncreasingBST(tree_5);
            return 1;
        }
    }
}