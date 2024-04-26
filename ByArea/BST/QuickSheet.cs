namespace ByArea.BST;

internal class QuickSheet
{
    // https://leetcode.com/problems/validate-binary-search-tree/solutions/32112/learn-one-iterative-inorder-traversal-apply-it-to-multiple-tree-questions-java-solution/
    /*
     * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Inorder traversal  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
    Learn one iterative inorder traversal, apply it to multiple tree questions(Java Solution)

    I will show you all how to tackle various tree questions using iterative inorder traversal.First one is the standard 
    iterative inorder traversal using stack. Hope everyone agrees with this solution.

    Question : Binary Tree Inorder Traversal
    */

    public List<int> InorderTraversal(TreeNode root)
    {
        List<int> list = new();
        if (root == null)
            return list;
        Stack<TreeNode> stack = new();
        while (root != null || stack.Count > 0)
        {
            while (root != null)
            {
                stack.Push(root);
                root = root.left;
            }
            root = stack.Pop();
            list.Add(root.val);
            root = root.right;

        }
        return list;
    }
    /*
    * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Find the kthSmallest  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
    Now, we can use this structure to find the Kth smallest element in BST.

    Question : Kth Smallest Element in a BST

    */

    public int kthSmallest(TreeNode root, int k)
    {
        Stack<TreeNode> stack = new();
        while (root != null || stack.Count > 0)
        {
            while (root != null)
            {
                stack.Push(root);
                root = root.left;
            }
            root = stack.Pop();
            if (--k == 0) break;
            root = root.right;
        }
        return root.val;
    }

    /*
    * * * * * * * * * * * * * * * * * * * * * * * * * * * * * Validate the Binary Search Tree  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
    We can also use this structure to solve BST validation question.

    Question : Validate Binary Search Tree
    */

    public bool isValidBST(TreeNode root)
    {
        if (root == null) return true;
        Stack<TreeNode> stack = new();
        TreeNode pre = null;

        while (root != null || stack.Count > 0)
        {
            while (root != null)
            {
                stack.Push(root);
                root = root.left;
            }
            root = stack.Pop();
            if (pre != null && root.val <= pre.val) return false;
            pre = root;
            root = root.right;
        }
        return true;
    }

    /*
     * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  compare a previous value with a current value  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
     * This is a recursive approach for BST where it can be seen how to compare 
     * previous value with current value
     */
    int prev = int.MinValue;

    public bool IsValidBSTByRecursion(TreeNode root)
    {
        if (root == null) return true;

        if (!IsValidBSTByRecursion(root.left))
        {
            return false;
        }

        if (prev >= root.val)
            return false;

        Console.WriteLine(@$"prev: {prev}");
        Console.WriteLine($"root.val: {root.val}");
        Console.WriteLine("");

        prev = root.val;

        if (!IsValidBSTByRecursion(root.right))
        {
            return false;
        }

        return true;
    }


    /*
    * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  Sum a subtree(which is BST) in a simple tree  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
    */

    private int _maxSum = 0;

    public int MaxSumBST(TreeNode root)
    {
        PostOrderTraverse(root);
        return _maxSum;
    }

    private int[] PostOrderTraverse(TreeNode root)
    {
        if (root == null) 
            return new int[] { int.MaxValue, int.MinValue, 0 }; // {min, max, sum}, initialize min=MAX_VALUE, max=MIN_VALUE

        int[] left = PostOrderTraverse(root.left);
        int[] right = PostOrderTraverse(root.right);

        // The BST is the tree:
        if (!(left != null             // the left subtree must be BST
                && right != null            // the right subtree must be BST
                && root.val > left[1]       // the root's key must greater than maximum keys of the left subtree
                && root.val < right[0]))    // the root's key must lower than minimum keys of the right subtree
            return null;

        int sum = root.val + left[2] + right[2]; // now it's a BST make `root` as root
        _maxSum = Math.Max(_maxSum, sum);
        int min = Math.Min(root.val, left[0]);
        int max = Math.Max(root.val, right[1]);
        return new int[] { min, max, sum };
    }
}
