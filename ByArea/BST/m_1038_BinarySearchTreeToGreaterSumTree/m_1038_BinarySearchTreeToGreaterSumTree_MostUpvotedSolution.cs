namespace ByArea.BST.m_1038_BinarySearchTreeToGreaterSumTree;

/*
 https://leetcode.com/problems/binary-search-tree-to-greater-sum-tree/solutions/286725/java-c-python-revered-inorder-traversal/

Given the root of a Binary Search Tree (BST), convert it to a Greater Tree such 
that every key of the original BST is changed to the original key plus the 
sum of all keys greater than the original key in BST.

As a reminder, a binary search tree is a tree that satisfies these constraints:

The left subtree of a node contains only nodes with keys less than the node's key.
The right subtree of a node contains only nodes with keys greater than the node's key.
Both the left and right subtrees must also be binary search trees.
 

Example 1:

                                        4(30)
                                       /     \  
                                    1(36)   6 (21) 
                                    / \       /   \   
                               0(36)  2(35) 5(26)  7(15)
                                        \            \
                                        3(33)         8(8)

Input: root = [4,1,6,0,2,5,7,null,null,null,3,null,null,null,8]
Output: [30,36,21,36,35,26,15,null,null,null,33,null,null,null,8]



Example 2:

Input: root = [0,null,1]
Output: [1,null,1]
 

Constraints:

The number of nodes in the tree is in the range [1, 100].
0 <= Node.val <= 100
All the values in the tree are unique.

 */
public class m_1038_BinarySearchTreeToGreaterSumTree_MostUpvotedSolution
{
    /*
                            Explanation
We need to do the work from biggest to smallest, right to left.
`pre` will record the previous value the we get, which the total sum of bigger values.
For each node, we update root.val with root.val + pre.


Complexity
Time O(n)
Space O(height)
     */

    int _pre = 0;

    public TreeNode BstToGst(TreeNode root)
    {
        if (root.right != null) 
            BstToGst(root.right);

        _pre = root.val = _pre + root.val;

        if (root.left != null) 
            BstToGst(root.left);

        return root;
    }

    /*
     
                        C++:

    int pre = 0;
    TreeNode* bstToGst(TreeNode* root) {
        if (root->right) 
            bstToGst(root->right);

        pre = root->val = pre + root->val;

        if (root->left) 
            bstToGst(root->left);

        return root;
    }

                        Python:

    val = 0
    def bstToGst(self, root):
        if root.right: self.bstToGst(root.right)

        root.val = self.val = self.val + root.val

        if root.left: self.bstToGst(root.left)

        return root
     
     */
}

public class m_1038_BinarySearchTreeToGreaterSumTree_MostUpvotedSolution_BootStrapper
{
    public void Run() 
    {
        TreeNode tree_3 = new TreeNode() { val = 3 };
        TreeNode tree_2 = new TreeNode() { val = 2, right = tree_3 };
        TreeNode tree_0 = new TreeNode() { val = 0 };
        TreeNode tree_1 = new TreeNode() { val = 1, left = tree_0, right = tree_2 };

        TreeNode tree_8 = new TreeNode() { val = 8 };
        TreeNode tree_7 = new TreeNode() { val = 7, right = tree_8 };

        TreeNode tree_5 = new TreeNode() { val = 5 };
        TreeNode tree_6 = new TreeNode() { val = 6, left = tree_5, right = tree_7 };

        TreeNode tree_4 = new TreeNode()
        {
            val = 4,
            left = tree_1,
            right = tree_6
        };

        new m_1038_BinarySearchTreeToGreaterSumTree_MostUpvotedSolution().BstToGst(tree_4);
    }
}
