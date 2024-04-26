namespace ByArea.BST.SearchInABinaryTree_700_e;

/*
 https://leetcode.com/problems/search-in-a-binary-search-tree/solutions/149274/java-beats-100-concise-method-using-recursion-and-iteration/

191 upvotes
 */
public class SearchInABinaryTree_700_MostUpvotedSolution
{
    /*
        Java beats 100% concise method using recursion and iteration
    */

    // recursion:
    public TreeNode searchBSTRecursive(TreeNode root, int val)
    {
        if (root == null)
        {
            return root;
        }   

        if (root.val == val)
        {
            return root;
        }
        else
        {
            return val < root.val ? searchBSTRecursive(root.left, val) : searchBSTRecursive(root.right, val);
        }
    }

    // iteration:
    public TreeNode searchBSTIteration(TreeNode root, int val)
    {
        while (root != null && root.val != val)
        {
            root = val < root.val ? root.left : root.right;
        }

        return root;
    }
}