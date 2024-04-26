namespace ByArea.BST.RangeSumOfBst_938_e;

/*
 [Java/Python 3] 3 similar recursive and 1 iterative methods w/ comment & analysis.
https://leetcode.com/problems/range-sum-of-bst/solutions/192019/java-python-3-3-similar-recursive-and-1-iterative-methods-w-comment-analysis/

this is the most upvoted solution:
 */



/*
 Analysis:

All 4 methods will DFS traverse all nodes in worst case, and if we count in the recursion trace space cost, the complexities are as follows:

Time: O(n), space: O(h), where n is the number of total nodes, h is the height of the tree..
 
 */


/*
    Method 4: Iterative version
*/
public class RangeSumOfBst_938_MostUpvotedSolution_Method4
{
    public int rangeSumBST(TreeNode root, int L, int R)
    {
        Stack<TreeNode> stack = new();
        stack.Push(root);
        int sum = 0;
        // original code in Java is: while (!stack.IsEmpty)
        while (stack.Count > 0)
        {
            TreeNode n = stack.Pop();
            if (n == null) { continue; }
            if (n.val > L) { stack.Push(n.left); } // left child is a possible candidate.
            if (n.val < R) { stack.Push(n.right); } // right child is a possible candidate.
            if (L <= n.val && n.val <= R) { sum += n.val; }
        }
        return sum;
    }

    /* Python
     
     def rangeSumBST(self, root: TreeNode, L: int, R: int) -> int:
        stk, sum = [root], 0
        while stk:
            node = stk.pop()
            //if node:
                if node.val > L:
                    stk.append(node.left)    
                if node.val < R:
                    stk.append(node.right)
                if L <= node.val <= R:
                    sum += node.val    
        return sum
     */
}


public class RangeSumOfBst_938_MostUpvotedSolution_Method_1
{
    /*Three similar recursive and one iterative methods, choose one you like.

    Method 1:*/


    public int rangeSumBST(TreeNode root, int L, int R)
    {
        if (root == null) return 0; // base case.
        if (root.val < L) return rangeSumBST(root.right, L, R); // left branch excluded.
        if (root.val > R) return rangeSumBST(root.left, L, R); // right branch excluded.
        return root.val + rangeSumBST(root.right, L, R) + rangeSumBST(root.left, L, R); // count in both children.
    }

    /*
     * Python3: 
    def rangeSumBST(self, root: TreeNode, L: int, R: int) -> int:
        if not root:
            return 0
        elif root.val < L:
            return self.rangeSumBST(root.right, L, R)
        elif root.val > R:
            return self.rangeSumBST(root.left, L, R)
        return root.val + self.rangeSumBST(root.left, L, R) + self.rangeSumBST(root.right, L, R)
     */
}


/*
    The following are two more similar recursive codes.
    Method 2:
*/
public class RangeSumOfBst_938_MostUpvotedSolution_Method2
{


    public int rangeSumBST(TreeNode root, int L, int R)
    {
        if (root == null) return 0; // base case.
        return (L <= root.val && root.val <= R ? root.val : 0) + rangeSumBST(root.right, L, R) + rangeSumBST(root.left, L, R);
    }

    /* Python
     
      def rangeSumBST(self, root: TreeNode, L: int, R: int) -> int:
        if not root:
            return 0
        return self.rangeSumBST(root.left, L, R) + \
                self.rangeSumBST(root.right, L, R) + \
                (root.val if L <= root.val <= R else 0)
     */
}


/*
    The following are two more similar recursive codes.
    Method 3:
*/
public class RangeSumOfBst_938_MostUpvotedSolution_Method3
{
    public int rangeSumBST(TreeNode root, int L, int R)
    {
        if (root == null) { return 0; }
        int sum = 0;
        if (root.val > L) { sum += rangeSumBST(root.left, L, R); } // left child is a possible candidate.
        if (root.val < R) { sum += rangeSumBST(root.right, L, R); } // right child is a possible candidate.
        if (root.val >= L && root.val <= R) { sum += root.val; } // count root in.
        return sum;
    }

    /* Python
     
      def rangeSumBST(self, root: TreeNode, L: int, R: int) -> int:
        if not root:
            return 0
        sum = 0
        if root.val > L:
            sum += self.rangeSumBST(root.left, L, R)
        if root.val < R:
            sum += self.rangeSumBST(root.right, L, R)
        if L <= root.val <= R:
            sum += root.val     
        return sum
     */
}



