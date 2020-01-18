using System;

namespace data_structures {
    class Node {
        public int data;
        public Node next;
        public Node (int data) {
            this.data = data;
            this.next = null;
        }
    }
    class LinkedList {
        Node head;
        void AddToEnd (int data) {
            Node newNode = new Node (data);
            if (head == null) {
                head = newNode;
                return;
            }
            Node ptr = head;
            while (ptr.next != null) { //traverse till second last node
                ptr = ptr.next;
            }
            ptr.next = newNode; //now ptr points to last node,point last node to new node
        }
        void AddToStart (int data) {
            Node newNode = new Node (data);
            if (head == null) {
                head = newNode;
                return;
            }
            Node ptr = head; //store head node pointing to first node in temp ptr
            head = newNode; //point head to new node
            newNode.next = ptr; //point new node to next node
        }

        void Traverse () {
            if (head == null) {
                return; //return if ll is empty
            }
            Node ptr = head;
            while (ptr != null) { //ptr becomes null after last node; traverse till last node
                Console.WriteLine (ptr.data);
                ptr = ptr.next;
            }
        }

        bool search (int data) {
            if (head == null) {
                return false; //return false if ll is empty
            }
            Node ptr = head;
            while (ptr != null) { //traverse till last node
                if (ptr.data == data) { //compare provide value with current node in traversal
                    return true; //return true if found
                }
                ptr = ptr.next; //otherwise move pointer ahead
            }
            return false; //return false if not matched ie not found
        }

        int Size () {
            if (head == null) {
                return 0;
            }
            int counter = 0;
            Node ptr = head;
            while (ptr != null) {
                counter++;
                ptr = ptr.next;

            }
            return counter;
        }

        int middleElementIterative () {
            if (head == null) {
                return 0;
            }
            int mid = Size () / 2;
            int counter = 1;
            Node ptr = head;
            while (counter < mid) {
                ptr = ptr.next;
                counter++;
            }
            return ptr.data;
        }

        int middleElementUsingPointers () {
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
        int findNthNode (int n) {
            if (head == null) {
                Console.WriteLine ("Linked List is empty.");
                return 0;
            }
            if (n <= 0 || n > Size ()) { //check if n is within range of linkedlist length
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

        int findNthNodeFromEnd (int n) {
            if (head == null) {
                Console.WriteLine ("Linked List is empty.");
                return 0;
            }
            if (n <= 0 || n > Size ()) { //check if n is withing range
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

        bool hasLoop () {
            if (head == null) {
                Console.WriteLine ("LinkedList is empty.");
                return false;
            }
            Node fastPtr = head;
            Node slowPtr = head;
            while (fastPtr.next != null && fastPtr.next.next != null) {
                fastPtr = fastPtr.next.next; //move fast ptr twice fast as slow ptr
                slowPtr = slowPtr.next;
                if (fastPtr == slowPtr) { //return true if both meets
                    return true; //meeting of both ptrs mean ,ll has loop
                }
            }
            return false; // otherwise return false
        }

        void createLoop (int n) {
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

        static void Main (string[] args) {
            LinkedList linkedList = new LinkedList ();
            linkedList.AddToEnd (20);
            linkedList.AddToEnd (30);
            linkedList.AddToEnd (40);
            linkedList.AddToEnd (50);
            linkedList.AddToEnd (60);
            linkedList.AddToStart (10);

            linkedList.Traverse ();
            int size = linkedList.Size ();
            Console.WriteLine ("Size of linked list is: " + size);
            bool ifFound = linkedList.search (20);
            Console.WriteLine ("Element found: " + ifFound);
            bool elemFound = linkedList.search (80);
            Console.WriteLine ("Element found: " + elemFound);
            int middleElement1 = linkedList.middleElementIterative ();
            if (middleElement1 == 0) {
                Console.WriteLine ("Linked List is Empty");
            } else {
                Console.WriteLine ("Middle Element is:" + middleElement1);
            }

            int middleElement2 = linkedList.middleElementUsingPointers ();
            if (middleElement2 == 0) {
                Console.WriteLine ("Linked List is Empty");
            } else {
                Console.WriteLine ("Middle Element is:" + middleElement2);
            }
            int n = 6;
            int nthNode = linkedList.findNthNode (n);
            if (nthNode > 0) {
                Console.WriteLine (String.Format ("Node at {0} position is {1}", n, nthNode));
            }
            n = 4;
            int nthNodeFromEnd = linkedList.findNthNodeFromEnd (n);
            if (nthNodeFromEnd > 0) {
                Console.WriteLine (String.Format ("Node at {0} position is {1}", n, nthNodeFromEnd));
            }

            linkedList.createLoop (4);
            bool hasloop = linkedList.hasLoop ();
            if (hasloop) {
                Console.WriteLine ("LinkedList has loop.");
            } else {
                Console.WriteLine ("LinkedList doesn't have loop.");
            }
        }
    }
}