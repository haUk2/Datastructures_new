using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using Trees.BinarySearchTree;

namespace TreesTests
{
    
    public class BinaryTreeTests
    {
        [SetUp]
        public void Setup()
        {
        }
        private BinarySearchTree<int> testTree;

        [Test]
        public void BinarySearchTree_InitWithValue_HasRoot()
        {
            testTree = new BinarySearchTree<int>(0);
            Assert.AreEqual(0, testTree.Root.Value);
        }

        [Test]
        public void BinarySearchTree_InitWithValues_IsInOrder()
        {
            testTree = new BinarySearchTree<int>(new[] { 50, 60, 40 });
            Assert.AreEqual(50, testTree.Root.Value);
            Assert.AreEqual(40, testTree.Root.LeftChild.Value);
            Assert.AreEqual(60, testTree.Root.RightChild.Value);
        }

        

        [Test]
        public void Insert_EmptyTree_AddsRootNode()
        {
            testTree = new BinarySearchTree<int>(new[] {1});
            Assert.IsNotNull(testTree.Root);
            Assert.IsNull(testTree.Root.LeftChild);
            Assert.IsNull(testTree.Root.RightChild);
        }

        [Test]
        public void Insert_NodeLessThanRoot_AddsToLeftSubtree()
        {
            testTree = new BinarySearchTree<int>(new[] { 10, 5 });
            Assert.IsNotNull(testTree.Root.LeftChild);
            Assert.IsNull(testTree.Root.RightChild);
        }

        [Test]
        public void Insert_NodeGreaterThanRoot_AddsToRightSubtree()
        {
            testTree = new BinarySearchTree<int>(new[] { 10, 15 });

            Assert.IsNull(testTree.Root.LeftChild);
            Assert.IsNotNull(testTree.Root.RightChild);
        }

        [Test]
        public void Insert_NodeLessThanNestedNode_AddsToLeftSubtree()
        {
            testTree = new BinarySearchTree<int>(new[] { 10, 5, 15 });
            const int NEW_NODE_VAL = 12;
            testTree.Insert(NEW_NODE_VAL);
            var newNode = testTree.Root.RightChild.LeftChild;
            Assert.IsNotNull(newNode);
            Assert.AreEqual(newNode.Value, NEW_NODE_VAL);
        }

        [Test]
        public void Insert_NodeGreaterThanNestedNode_AddsToRightSubtree()
        {
            testTree = new BinarySearchTree<int>(new[] { 10, 5, 15 });
            const int NEW_NODE_VAL = 7;
           

            testTree.Insert(NEW_NODE_VAL);

            var newNode = testTree.Root.LeftChild.RightChild;
            Assert.IsNotNull(newNode);
            Assert.AreEqual(newNode.Value, NEW_NODE_VAL);
        }

       

        [Test]
        public void Search_NodeExistsOnRightSubtree_ReturnsTrue()
        {
            testTree = new BinarySearchTree<int>(new[] { 1, 10 });
          

            Assert.IsTrue(testTree.Search(10));
        }

        [Test]
        public void Search_NodeExistsOnLeftSubtree_ReturnsTrue()
        {

            testTree = new BinarySearchTree<int>(new[] { 1, 10 });

            Assert.IsTrue(testTree.Search(1));
        }

        [Test]
        public void Search_NodeDoesNotExist_ReturnsFalse()
        {
            testTree = new BinarySearchTree<int>(new[] { 10, 5, 15 });
       
            Assert.IsFalse(testTree.Search(100));
        }

        [Test]
        public void Search_EmptyTree_ReturnsFalse()
        {
            testTree = new BinarySearchTree<int>();
         
            Assert.IsNull(testTree.Root);
            Assert.IsFalse(testTree.Search(1));
        }

        [Test]
        public void Delete_OnlyOneNode_DeletesRoot()
        {
            testTree = new BinarySearchTree<int>(new[] {10});
            

            Assert.IsTrue(testTree.Search(10));
            testTree.Delete(10);
            Assert.IsFalse(testTree.Search(10));
            Assert.IsTrue(testTree.Root == null);
        }

        [Test]
        public void Delete_NodeHasNoChildren_IsDeleted()
        {
            testTree = new BinarySearchTree<int>(new[] { 10, 5, 15 });
            
            Assert.IsTrue(testTree.Search(15));
            testTree.Delete(15);
            Assert.IsFalse(testTree.Search(15));
        }

        [Test]
        public void Delete_NodeHasLeftChild_IsDeleted()
        {
            testTree = new BinarySearchTree<int>(new[] { 10, 5, 15, 1 });
            
            Assert.IsTrue(testTree.Search(5));
            testTree.Delete(5);
            Assert.IsFalse(testTree.Search(5));
        }

        [Test]
        public void Delete_NodeHasRightChild_IsDeleted()
        {
            testTree = new BinarySearchTree<int>(new[] { 10, 5, 15, 20 });
           

            Assert.IsTrue(testTree.Search(15));
            testTree.Delete(15);
            Assert.IsFalse(testTree.Search(15));
        }

        [Test]
        public void Delete_NodeHasTwoChildren_IsDeleted()
        {
            testTree = new BinarySearchTree<int>(new[] { 5, 3, 2, 4, 7, 6, 8 });

            Assert.IsTrue(testTree.Search(5));
            testTree.Delete(5);
            Assert.IsFalse(testTree.Search(5));
        }

        [Test]
        public void Delete_NodeIsRootAndHasTwoChildren_HasCorrectOrder()
        {
            testTree = new BinarySearchTree<int>(new[] { 5, 3, 2, 4, 7, 6, 8 });

            testTree.Delete(5);
            Assert.IsTrue(IsCorrectOrder(testTree.PreOrder(), "632478"));
        }

        [Test]
        public void Delete_NodeIsNotRootAndHasTwoChildren_HasCorrectOrder()
        {
            testTree = new BinarySearchTree<int>(new[] { 5, 3, 2, 4, 7, 6, 8 });

            testTree.Delete(7);
            Debug.WriteLine(testTree.PreOrder());
            Assert.IsTrue(IsCorrectOrder(testTree.PreOrder(), "532486"));
        }
       

        [Test]
        public void PreOrder_IsPreOrder()
        {
            CreateOrderedTree();

            string order = testTree.PreOrder();

            Debug.WriteLine("PreOrder Test: " + order);
            Assert.IsTrue(IsCorrectOrder(order, "621435798"));
        }

        [Test]
        public void InOrder_IsInOrder()
        {
            CreateOrderedTree();

            string order = testTree.InOrder();

            Debug.WriteLine("InOrder Test: " + order);
            Assert.IsTrue(IsCorrectOrder(order, "123456789"));
        }

        [Test]
        public void PostOrder_IsPostOrder()
        {
            CreateOrderedTree();
            string order = testTree.PostOrder();

            Debug.WriteLine("PostOrder Test: " + order);
            Assert.IsTrue(IsCorrectOrder(order, "135428976"));
        }

        private static bool IsCorrectOrder(string order, string expectedOrder)
        {
            return new string(order.Where(char.IsDigit).ToArray()).Equals(expectedOrder);
        }

        private void CreateOrderedTree()
        {
            testTree = new BinarySearchTree<int>(new[] { 6, 2, 1, 4, 3, 5, 7, 9, 8 });
        }
        
    }
}