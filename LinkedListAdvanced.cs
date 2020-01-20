using System;
using data_structures_linkedlist_basic;
namespace data_structures_linkedlist_advanced {

    class LinkedListAdvanced {
        bool searchRecursively (int data, Node head) {
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

        public int getSizeRecursively (Node head) {
            return _recursiveSize (head);
        }

        int _recursiveSize (Node node) {

            if (node == null) {
                return 0;
            }

            return 1 + _recursiveSize (node.next);
        }

        int middleElementIterative (Node head) {
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

        int middleElementUsingPointers (Node head) {
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
        int findNthNode (int n, Node head) {
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

        int findNthNodeFromEnd (int n, Node head) {
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

        public bool hasLoop (Node head) {
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

        public int loopLength (Node head) {
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
                if (fastPtr == slowPtr) { //return true if both meets

                    Node temp = slowPtr;
                    resultCount++;

                    while (slowPtr.next != temp) {
                        slowPtr = slowPtr.next;
                        resultCount++;
                    }

                    return resultCount;

                }
            }
            return resultCount; // otherwise return false
        }

        public void createLoop (int n, Node head) {
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
                    Console.WriteLine (temp.data);
                }
            }
            ptr.next = temp;
            Console.WriteLine (ptr.data);
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

        static void Main (string[] args) {

            LinkedList linkedList = new LinkedList ();
            Node head = linkedList.createLinkedListOfTenNodes ();
            linkedList.Traverse (head);

            LinkedListAdvanced linkedListAdvanced = new LinkedListAdvanced ();

            int size = linkedList.Size (head);
            Console.WriteLine ("Size of linked list recursively is: " + size);

            int sizeRecursive = linkedListAdvanced.getSizeRecursively (head);
            Console.WriteLine ("Size of linked list is: " + sizeRecursive);

            bool ifFound1 = linkedList.Search (20, head);
            Console.WriteLine ("Element found: " + ifFound1);

            bool ifFound2 = linkedList.Search (110, head);
            Console.WriteLine ("Element found: " + ifFound2);

            bool keyFound1 = linkedListAdvanced.searchRecursively (20, head);
            Console.WriteLine ("Element found: " + keyFound1);

            bool keyFound2 = linkedListAdvanced.searchRecursively (110, head);
            Console.WriteLine ("Element found: " + keyFound2);

            int middleElement1 = linkedListAdvanced.middleElementIterative (head);
            if (middleElement1 == 0) {
                Console.WriteLine ("Linked List is Empty");
            } else {
                Console.WriteLine ("Middle Element is:" + middleElement1);
            }

            int middleElement2 = linkedListAdvanced.middleElementUsingPointers (head);
            if (middleElement2 == 0) {
                Console.WriteLine ("Linked List is Empty");
            } else {
                Console.WriteLine ("Middle Element is:" + middleElement2);
            }

            int n = 6;
            int nthNode = linkedListAdvanced.findNthNode (n, head);
            if (nthNode > 0) {
                Console.WriteLine (String.Format ("Node at {0} position is {1}", n, nthNode));
            }

            n = 4;
            int nthNodeFromEnd = linkedListAdvanced.findNthNodeFromEnd (n, head);
            if (nthNodeFromEnd > 0) {
                Console.WriteLine (String.Format ("Node at {0} position is {1}", n, nthNodeFromEnd));
            }
            Node head2 = linkedListAdvanced.Reverse (head);
            linkedList.Traverse (head2);
            linkedListAdvanced.createLoop (4, head2);
            bool hasloop = linkedListAdvanced.hasLoop (head2);
            if (hasloop) {
                Console.WriteLine ("LinkedList has loop.");
            } else {
                Console.WriteLine ("LinkedList doesn't have loop.");
            }

            Console.WriteLine ("Length of loop is : " + linkedListAdvanced.loopLength (head2));
        }
    }
}