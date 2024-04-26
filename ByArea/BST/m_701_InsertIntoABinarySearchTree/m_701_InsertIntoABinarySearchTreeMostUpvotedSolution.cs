using ByArea.BST.RangeSumOfBst_938_e;

namespace ByArea.BST.m_701_InsertIntoABinarySearchTree;

/*
                                                            Task
https://leetcode.com/problems/insert-into-a-binary-search-tree/description/

You are given the root node of a binary search tree (BST) and a value to insert into the tree. Return the root node of the BST after the insertion. It is guaranteed that the new value does not exist in the original BST.

Notice that there may exist multiple valid ways for the insertion, as long as the tree remains a BST after insertion. You can return any of them.

 

Example 1:


Input: root = [4,2,7,1,3], val = 5
Output: [4,2,7,1,3,5]
Explanation: Another accepted tree is:

                        4
                      /   \
                    2      7
                   / \       
                  1   3      


                        4
                      /   \
                    2      7
                   / \    /     
                  1   3  5    


Example 2:

Input: root = [40,20,60,10,30,50,70], val = 25
Output: [40,20,60,10,30,50,70,null,null,25]
Example 3:

Input: root = [4,2,7,1,3,null,null,null,null,null,null], val = 5
Output: [4,2,7,1,3,5]
 

Constraints:

The number of nodes in the tree will be in the range [0, 104].
-108 <= Node.val <= 108
All the values Node.val are unique.
-108 <= val <= 108
It's guaranteed that val does not exist in the original BST.
 */


/*
There are 3 facts to BST :

1) Inorder Traversal of BST is a sorted sequence.
2) In a BST,
    - all the values smaller then root, exists in the left subtree.
    - all the values greater then root, exists in the right subtree.
and this is recursively true for every node.
3) A new key is always inserted at the leaf.
In order to find the position to insert a value, we need to check the condition-2 at every node while traversing : ( and update the links while inserting )

TC : O(n) -> Typical dfs
SC : O(n) -> Stack Space ( in the worst case, the tree could be pathological tree )

class Solution {
    public TreeNode insertIntoBST(TreeNode node, int val) {
        if(node == null) return new TreeNode(val);
        
        if(val < node.val) {
            node.left = insertIntoBST(node.left, val);
        }
        else if(val > node.val) {
            node.right = insertIntoBST(node.right, val);
        }
        return node;
    }
}

 */


internal class m_701_InsertIntoABinarySearchTreeMostUpvotedSolution
{
    /*
        https://leetcode.com/problems/insert-into-a-binary-search-tree/solutions/1683942/well-detailed-explaination-java-c-python-easy-for-mind-to-accept-it/
Guy's if you find this solution helpful 😊, PLEASE do UPVOTE. By doing that it motivate's me to create more better post like this ✍️

So Ladies n Gentlemen without any further due let's start,
In this problem given a root node of binary search tree and the value & that value we need to add in Binary Search Tree & also saying all the nodes in BST have unique value & the value we need to add is not present in tree.

                    Approach Explain :

                    Summary :
If the root is empty, the new tree node can be returned as the root node.

Otherwise compare root. val is related to the size of the target value:

If root.val is greater than the target value, indicating that the target value should be inserted into the left subtree of the root, and the problem becomes root. Insert the target value in the left and recursively call the current function;
If root.val is less than the target value, indicating that the target value should be inserted into the right subtree of the root, and the problem becomes root. Insert the target value in right and recursively call the current function.
Explanation:
In Binary search tree follow the property, all the nodes on right subtree, value is greater then the root value & all the nodes on left subtree, value is less then the root value.

    So, now let's say we need to add 5. We will first compare with the root node. If it is less then we go on to the left subtree, if it is greater then we go to the right subtree. So, in this example right subtree exist and we will compare with 7. Then it will go to the left & left subtree doesn't exist over here, then we will add the new node over here.
Now let's say we need to add 8, then we will go again the right step and here we will add 8

                        4
                      /   \
                    2      7
                   / \       
                  1   3      

Adding 5:
                        4
                      /   \
                    2      7
                   / \    /     
                  1   3  5    

Adding 8:
                        4
                      /   \
                     2     7
                   / \    / \    
                  1   3  5   8 

    */
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        if (root == null) return new TreeNode(val);
        if (root.val > val) 
            root.left = InsertIntoBST(root.left, val);
        else 
            root.right = InsertIntoBST(root.right, val);
        return root;
    }
}

/*
Iterative Code line explain's : Similar for C++, Java {Only Syntax Difference} approach same

    if(root == null) return new TreeNode(val);
        
    TreeNode curr = root;
        
    while(true){ // running an infinity loop, look for the place for new node to add
        if(curr.val < val){
            if(curr.right != null) curr = curr.right; // update current on right
            else {
                curr.right = new TreeNode(val); // otherwise add current of right to new value TreeNode
                break; // breaking this infinity loop
            }
        }
        else{
            if(curr.left != null) curr = curr.left; // update current on left
            else{
                curr.left = new TreeNode(val); // otherwise add current of left to new value TreeNode
                break; // breaking this infinity loop
            }
        }
    }
    return root;

 */
internal class m_701_InsertIntoABinarySearchTreeMostUpvotedSolutionIterative
{
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        if (root == null) return new TreeNode(val);

        TreeNode curr = root;

        while (true)
        {
            if (curr.val < val)
            {
                if (curr.right != null) 
                    curr = curr.right;
                else
                {
                    curr.right = new TreeNode(val);
                    break;
                }
            }
            else
            {
                if (curr.left != null) 
                    curr = curr.left;
                else
                {
                    curr.left = new TreeNode(val);
                    break;
                }
            }
        }
        return root;
    }

    /*
     C++:
    
     class Solution {
        public:
            TreeNode* insertIntoBST(TreeNode* root, int val) { 
                if(!root) return new TreeNode(val);
        
                auto curr = root;
        
                while(true){
                    if(curr->val < val){
                        if(curr->right) curr = curr->right;
                        else {
                            curr->right = new TreeNode(val);
                            break;
                        }
                    }
                    else{
                        if(curr->left) curr = curr->left;
                        else{
                            curr->left = new TreeNode(val);
                            break;
                        }
                    }
                }
                return root;
            }
        };

    ANALYSIS :-

    Time Complexity :- BigO(N), where N is height of binary search tree

    Space Complexity :- BigO(1)

    If you have some 🤔 doubts feel free to bug me anytime or If you understood than don't forget to upvote 👍
     */
}

public class m_701_InsertIntoABinarySearchTreeMostUpvotedSolution_BootStrapper
{
    public void Run()
    {
        TreeNode tree_1 = new TreeNode { val = 1 };
        TreeNode tree_3 = new TreeNode { val = 3 };
        TreeNode tree_2 = new TreeNode { val = 2, left = tree_1, right = tree_3 };

        TreeNode tree_7 = new TreeNode { val = 7 };
        TreeNode tree_4 = new TreeNode { val = 4, left = tree_2, right = tree_7 };

        TreeNode treeNode = new m_701_InsertIntoABinarySearchTreeMostUpvotedSolution().InsertIntoBST(tree_4, 5);
    }
}