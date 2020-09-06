using System;
using Data_Structures_Linkedlist;

namespace Data_Structures_Linkedlist_Advanced {

    class LinkedListAdvanced {
        bool SearchRecursively (int data, Node head) {
            return _searchKeyRecursively (data, head);
        }

        bool _searchKeyRecursively (int data, Node node) {
            if (node == null) {
                return false;
            }
            if (node.data == data) {
                return true;
            }
            return _searchKeyRecursively (data, node.next);
        }

        public int GetSizeRecursively (Node head) {
            return _recursiveSize (head);
        }

        int _recursiveSize (Node node) {

            if (node == null) {
                return 0;
            }

            return 1 + _recursiveSize (node.next);
        }

        int MiddleElementIterative (Node head) {
            if (head == null) {
                return 0;
            }
            LinkedList linkedList = new LinkedList ();
            int mid = linkedList.Size (head) / 2;
            int counter = 1;
            Node ptr = head;
            while (counter < mid) {
                ptr = ptr.next;
                counter++;
            }
            return ptr.data;
        }

        int MiddleElementUsingPointers (Node head) {
            if (head == null) {
                return 0;
            }
            Node slowPtr = head; //take two pointers
            Node fastPtr = head;
            while (fastPtr != null && fastPtr.next != null && fastPtr.next.next != null) {
                fastPtr = fastPtr.next.next; // move faster pointer twice fast as slow one.
                slowPtr = slowPtr.next;
            }
            return slowPtr.data; //slow ptr now points to mid node
        }
        int FindNthNode (int n, Node head) {
            if (head == null) {
                Console.WriteLine ("Linked List is empty.");
                return 0;
            }
            LinkedList linkedList = new LinkedList ();
            if (n <= 0 || n > linkedList.Size ()) { //check if n is within range of linkedlist length
                Console.WriteLine ("Provided location is out of range.");
                return 0;
            }
            Node ptr = head;
            int counter = 1;
            while (counter < n) { // traverse ptr until n
                ptr = ptr.next;
                counter++;
            }
            return ptr.data; //return Nth node
        }

        int FindNthNodeFromEnd (int n, Node head) {
            if (head == null) {
                Console.WriteLine ("Linked List is empty.");
                return 0;
            }
            LinkedList linkedList = new LinkedList ();
            if (n <= 0 || n > linkedList.Size ()) { //check if n is withing range
                Console.WriteLine ("Provided location is out of range.");
                return 0;
            }
            Node fastPtr = head;
            int counter = 1;
            while (counter < n) { //move fast ptr until nth node
                fastPtr = fastPtr.next;
                counter++;
            }
            Node slowPtr = head; //now point slow ptr to first node while fast ptr points to nth node
            while (fastPtr.next != null) { //move both pointers until fastptr.next is not null
                fastPtr = fastPtr.next;
                slowPtr = slowPtr.next;
            }
            return slowPtr.data; //slowptr now pointing to Nth node from end
        }

        public bool HasLoop (Node head) {
            if (head == null) {
                Console.WriteLine ("LinkedList is empty.");
                return false;
            }
            Node fastPtr = head;
            Node slowPtr = head;
            while (fastPtr != null && fastPtr.next != null) {
                fastPtr = fastPtr.next.next; //move fast ptr twice fast as slow ptr
                slowPtr = slowPtr.next;
                if (fastPtr == slowPtr) { //return true if both meets
                    return true; //meeting of both ptrs mean ,ll has loop
                }
            }
            return false; // otherwise return false
        }

        public int LoopLength (Node head) {
            if (head == null) {
                Console.WriteLine ("LinkedList is empty.");
                return 0;
            }

            int resultCount = 0;
            Node fastPtr = head;
            Node slowPtr = head;
            while (fastPtr != null && fastPtr.next != null) {
                fastPtr = fastPtr.next.next; //move fast ptr twice fast as slow ptr
                slowPtr = slowPtr.next;
                if (fastPtr == slowPtr) {

                    Node temp = slowPtr;
                    resultCount++;

                    while (slowPtr.next != temp) {
                        slowPtr = slowPtr.next;
                        resultCount++;
                    }

                    return resultCount;

                }
            }
            return resultCount;
        }

        public Node FindLoopStart (Node head) {
            if (head == null && head.next == null) {
                return null;
            }
            Node slowPtr = head;
            Node fastPtr = head;
            while (fastPtr != null && fastPtr.next != null) {
                fastPtr = fastPtr.next.next;
                slowPtr = slowPtr.next;
                if (fastPtr == slowPtr) {
                    break;
                }
            }
            slowPtr = head;
            while (fastPtr != slowPtr) {
                fastPtr = fastPtr.next;
                slowPtr = slowPtr.next;
            }

            return slowPtr;
        }

        public Node FindLoopEnd (Node head) {
            if (head == null && head.next == null) {
                return null;
            }
            Node slowPtr = head;
            Node fastPtr = head;
            while (fastPtr != null && fastPtr.next != null) {
                fastPtr = fastPtr.next.next;
                slowPtr = slowPtr.next;
                if (fastPtr == slowPtr) {
                    break;
                }
            }
            slowPtr = head;
            LinkedListAdvanced linkedList = new LinkedListAdvanced ();
            while (fastPtr.next != slowPtr.next) {
                fastPtr = fastPtr.next;
                slowPtr = slowPtr.next;
            }

            return fastPtr;
        }
        public void RemoveLoop (Node head) {
            if (head == null && head.next == null) {
                return;
            }
            Node slowPtr = head;
            Node fastPtr = head;
            while (fastPtr != null && fastPtr.next != null) {
                fastPtr = fastPtr.next.next;
                slowPtr = slowPtr.next;
                if (fastPtr == slowPtr) {
                    break;
                }
            }
            slowPtr = head;
            while (fastPtr.next != slowPtr.next) {
                fastPtr = fastPtr.next;
                slowPtr = slowPtr.next;
            }
            fastPtr.next = null;
        }

        public void CreateLoop (int n, Node head) {
            if (head == null) {
                Console.WriteLine ("LinkedList is empty.");
                return;
            }
            Node ptr = head;
            Node temp = head;
            int counter = 1;
            while (ptr.next != null) {
                ptr = ptr.next;
                counter++;
                if (counter == n) {
                    temp = ptr;
                }
            }
            ptr.next = temp;
        }
        public Node Reverse (Node head) {
            if (head == null) {
                return null;
            }
            Node current = head;
            Node prev = null;
            Node next = null;

            while (current != null) {
                next = current.next; //store next node of current node
                current.next = prev;
                prev = current;
                current = next;
            }
            head = prev;
            return head;
        }

        public Node RotatebyKNode (int k, Node head) {
            if (head == null) {
                return null;
            }
            Node ptr = head;
            //Node fastPtr = head;
            int counter = 1;
            while (counter < 4 && ptr != null) {
                ptr = ptr.next;
                counter++;
            }

            Node KthNode = ptr;

            while (ptr.next != null) {
                ptr = ptr.next;
            }

            ptr.next = head;
            head = KthNode.next;
            KthNode.next = null;
            return head;
        }

        public void RemoveDuplicatesFromSortedLL (Node head) {
            if (head == null) {
                return;
            }

            Node ptr = head;
            Node nextNode = null;

            while (ptr.next != null) {
                if (ptr.data == ptr.next.data) {
                    nextNode = ptr.next.next;
                    ptr.next = null;
                    ptr.next = nextNode;
                } else {
                    ptr = ptr.next;
                }
            }
        }

        static void Main (string[] args) {

            LinkedList linkedList = new LinkedList ();
            Node head = linkedList.CreateLinkedListOfTenNodes ();
            linkedList.Traverse (head);
            Console.WriteLine ();

            LinkedListAdvanced linkedListAdvanced = new LinkedListAdvanced ();

            int size = linkedList.Size (head);
            Console.WriteLine ("Size of linked list recursively is: " + size);

            int sizeRecursive = linkedListAdvanced.GetSizeRecursively (head);
            Console.WriteLine ("Size of linked list is: " + sizeRecursive);

            bool ifFound1 = linkedList.Search (20, head);
            Console.WriteLine ("Element found: " + ifFound1);

            bool ifFound2 = linkedList.Search (110, head);
            Console.WriteLine ("Element found: " + ifFound2);

            bool keyFound1 = linkedListAdvanced.SearchRecursively (20, head);
            Console.WriteLine ("Element found: " + keyFound1);

            bool keyFound2 = linkedListAdvanced.SearchRecursively (110, head);
            Console.WriteLine ("Element found: " + keyFound2);

            int middleElement1 = linkedListAdvanced.MiddleElementIterative (head);
            if (middleElement1 == 0) {
                Console.WriteLine ("Linked List is Empty");
            } else {
                Console.WriteLine ("Middle Element is:" + middleElement1);
            }

            int middleElement2 = linkedListAdvanced.MiddleElementUsingPointers (head);
            if (middleElement2 == 0) {
                Console.WriteLine ("Linked List is Empty");
            } else {
                Console.WriteLine ("Middle Element is:" + middleElement2);
            }

            int n = 6;
            int nthNode = linkedListAdvanced.FindNthNode (n, head);
            if (nthNode > 0) {
                Console.WriteLine (String.Format ("Node at {0} position is {1}", n, nthNode));
            }

            n = 4;
            int nthNodeFromEnd = linkedListAdvanced.FindNthNodeFromEnd (n, head);
            if (nthNodeFromEnd > 0) {
                Console.WriteLine (String.Format ("Node at {0} position is {1}", n, nthNodeFromEnd));
            }
            //Node head2 = linkedListAdvanced.Reverse (head);
            linkedList.Traverse (head);
            linkedListAdvanced.CreateLoop (4, head);
            bool hasloop = linkedListAdvanced.HasLoop (head);
            if (hasloop) {
                Console.WriteLine ("LinkedList has loop.");
            } else {
                Console.WriteLine ("LinkedList doesn't have loop.");
            }

            Console.WriteLine ("Length of loop is : " + linkedListAdvanced.LoopLength (head));
            Console.WriteLine ("___");

            Node loopStartNode = linkedListAdvanced.FindLoopStart (head);
            Console.WriteLine ("First Node of loop is : " + loopStartNode.data);
            Node loopEndNode = linkedListAdvanced.FindLoopEnd (head);
            Console.WriteLine ("Last Node of loop is : " + loopEndNode.data);

            linkedListAdvanced.RemoveLoop (head);
            linkedList.Traverse (head);
            Console.WriteLine ();
            // Node newHead =linkedListAdvanced.RotatebyKNode(4, head);
            //  linkedList.Traverse(newHead);
            linkedListAdvanced.RemoveDuplicatesFromSortedLL (head);
            linkedList.Traverse (head);
        }
    }
}