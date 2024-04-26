namespace ByArea.BST.m_1008_ConstructBinarySearchTreeFromPreorderTraversal;

/*
 Given an array of integers preorder, which represents the preorder traversal of a BST (i.e., binary 
search tree), construct the tree and return its root.

It is guaranteed that there is always possible to find a binary search tree with the given 
requirements for the given test cases.

A binary search tree is a binary tree where for every node, any descendant of Node.left has a value 
strictly less than Node.val, and any descendant of Node.right has a value strictly 
greater than Node.val.

A preorder traversal of a binary tree displays the value of the node first, then 
traverses Node.left, then traverses Node.right. 

Example 1:

                        8
                      /   \
                    5      10
                   / \       \
                  1   7       12        

Input: preorder = [8,5,1,7,10,12]
Output: [8,5,10,1,7,null,12]
Example 2:

Input: preorder = [1,3]
Output: [1,null,3]

 */

/*
https://leetcode.com/problems/construct-binary-search-tree-from-preorder-traversal/solutions/252232/java-c-python-o-n-solution/
 */
public class m_1008_ConstructBinarySearchTreeFromPreorderTraversal_Solution_2
{
    /*
     Give the function a bound the maximum number it will handle.
    The left recursion will take the elements smaller than node.val
    The right recursion will take the remaining elements smaller than bound

    Complexity
    bstFromPreorder is called exactly N times.
    It's same as a preorder traversal.
    Time O(N)
    Space O(H)
     */
    int i = 0;
    public TreeNode BstFromPreorder(int[] array)
    {
        return BstFromPreorder(array, int.MaxValue);
    }

    public TreeNode BstFromPreorder(int[] array, int bound)
    {
        if (i == array.Length || array[i] > bound)
        {
            return null;
        }
        TreeNode root = new () { val = array[i++] };
        root.left = BstFromPreorder(array, root.val);
        root.right = BstFromPreorder(array, bound);
        return root;
    }

    /*
     C++

    int i = 0;
    TreeNode* bstFromPreorder(vector<int>& A, int bound = INT_MAX) {
        if (i == A.size() || A[i] > bound) return NULL;
        TreeNode* root = new TreeNode(A[i++]);
        root->left = bstFromPreorder(A, root->val);
        root->right = bstFromPreorder(A, bound);
        return root;
    }

    Python
    i = 0
    def bstFromPreorder(self, A, bound=float('inf')):
        if self.i == len(A) or A[self.i] > bound:
            return None
        root = TreeNode(A[self.i])
        self.i += 1
        root.left = self.bstFromPreorder(A, root.val)
        root.right = self.bstFromPreorder(A, bound)
        return root
     */
}


/*
https://leetcode.com/problems/construct-binary-search-tree-from-preorder-traversal/solutions/252232/java-c-python-o-n-solution/
 */
public class m_1008_ConstructBinarySearchTreeFromPreorderTraversal_Solution_2dot1
{
    /*
    Solution 2.1
    Some may don't like the global variable i.
    Well, I first reused the function in python,
    so I had to use it, making it a "stateful" function.

    I didn't realize there would be people who care about it.
    If it's really matters,
    We can discard the usage of global function.
     */
    public TreeNode BstFromPreorder(int[] array)
    {
        return BstFromPreorder(array, int.MaxValue, new int[] { 0 });
    }

    public TreeNode BstFromPreorder(int[] array, int bound, int[] indexes)
    {
        if (indexes[0] == array.Length || array[indexes[0]] > bound)
        {
            return null;
        }
            
        TreeNode root = new () { val = array[indexes[0]++] };
        root.left = BstFromPreorder(array, root.val, indexes);
        root.right = BstFromPreorder(array, bound, indexes);
        return root;
    }

    /*
    C++

    TreeNode* bstFromPreorder(vector<int>& A) {
        int i = 0;
        return build(A, i, INT_MAX);
    }

    TreeNode* build(vector<int>& A, int& i, int bound) {
        if (i == A.size() || A[i] > bound) return NULL;
        TreeNode* root = new TreeNode(A[i++]);
        root->left = build(A, i, root->val);
        root->right = build(A, i, bound);
        return root;
    }
     */
}

public class m_1008_ConstructBinarySearchTreeFromPreorderTraversal_Solution_2dot1_Bootstrapper
{
    public TreeNode Run() 
    {
        int[] numbers = [8, 5, 1, 7, 10, 12];
        TreeNode tree = new m_1008_ConstructBinarySearchTreeFromPreorderTraversal_Solution_2
            ().BstFromPreorder(numbers);
        return tree;
    }
}
