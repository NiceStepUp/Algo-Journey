namespace ByArea.BST.IncreasingOrderSearchTree_897_e;

public class IncreasingOrderSearchTree_897_MostUpvotedSolution
{
    /*
     * 
     * This is the most upvoted solution:
     https://leetcode.com/problems/increasing-order-search-tree/solutions/165885/c-java-python-self-explained-5-line-o-n/
     Java:

    public TreeNode increasingBST(TreeNode root) {
        return increasingBST(root, null);
    }

    public TreeNode increasingBST(TreeNode root, TreeNode tail) {
        if (root == null) return tail;
        TreeNode res = increasingBST(root.left, root);
        root.left = null;
        root.right = increasingBST(root.right, tail);
        return res;
    }

     * 
     */

    public TreeNode IncreasingBST(TreeNode root) =>
        IncreasingBST(root, null);

    public TreeNode IncreasingBST(TreeNode root, TreeNode tail)
    {
        if (root == null)
        {
            return tail;
        }
            
        TreeNode res = IncreasingBST(root.left, root);
        root.left = null;

        root.right = IncreasingBST(root.right, tail);
        return res;
    }
}

public class BootStrapper_IncreasingOrderSearchTree_897_AlternativeSolution
{
    public TreeNode Run()
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

        TreeNode treeNode = new IncreasingOrderSearchTree_897_MostUpvotedSolution().IncreasingBST(tree_5);
        return treeNode;
    }
}