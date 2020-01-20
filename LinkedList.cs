using System;

namespace data_structures_linkedlist_basic {
    public class Node {
        public int data;
        public Node next;
        public Node (int data) {
            this.data = data;
            this.next = null;
        }
    }
    class LinkedList {
        public Node head;
        public void Add (int data) {
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
        public void AddFirst (int data) {
            Node newNode = new Node (data);
            if (head == null) {
                head = newNode;
                return;
            }
            Node ptr = head; //store head node pointing to first node in temp ptr
            head = newNode; //point head to new node
            newNode.next = ptr; //point new node to next node
        }

        public void AddAfterNthNode (int n, int data) {
            if (head == null) {
                return;
            }
            if (n <= 0 || n > Size ()) { //check if n is within range of linkedlist length
                Console.WriteLine ("Provided location is out of range.");
                return;
            }
            Node ptr = head;
            Node newNode = new Node (data);
            int counter = 1;
            while (counter < n) {
                ptr = ptr.next;
                counter++;
            }
            newNode.next = ptr.next;
            ptr.next = newNode;
        }
        public void AddAfterPrevNode (Node prevNode, int data) {
            if (prevNode == null) {
                return;
            }

            Node newNode = new Node (data);
            newNode.next = prevNode.next;
            prevNode.next = newNode;
        }

        public void Traverse (Node head) {
            if (head == null) {
                return; //return if ll is empty
            }
            Node ptr = head;
            while (ptr != null) { //ptr becomes null after last node; traverse till last node
                Console.WriteLine (ptr.data);
                ptr = ptr.next;
            }
        }
        public void Traverse () {
            if (head == null) {
                return; //return if ll is empty
            }
            Node ptr = head;
            while (ptr != null) { //ptr becomes null after last node; traverse till last node
                Console.WriteLine (ptr.data);
                ptr = ptr.next;
            }
        }

        public bool Search (int data) {
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
        public bool Search (int data, Node head) {
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

        void DeleteFirstNode () {
            if (head == null) {
                return;
            }
            Node ptr = head;
            head = ptr.next;
        }

        void DeleteLastNode () {
            if (head == null) {
                return;
            }
            Node ptr = head;
            Node prevNode = null;
            while (ptr.next != null) {
                prevNode = ptr;
                ptr = ptr.next;
            }
            prevNode.next = null;
        }

        void DeleteNode (int data) {
            Node ptr = head;
            Node prevNode = null;
            if (ptr != null && ptr.data == data) { //if key is present at first node.
                head = ptr.next; // make head point to 2nd node.
                return;
            }
            while (ptr != null && ptr.data != data) { //move ptr ahead until key not found
                prevNode = ptr; //keep track of prev node.
                ptr = ptr.next;
            }
            if (ptr == null)
                return; //end of linkedlist ,key not found.

            prevNode.next = ptr.next; //link prev node of key to next node of key.

        }

        void DeleteNthNode (int n) {
            if (head == null) {
                return;
            }
            if (n <= 0 || n > Size ()) { //check if n is within range of linkedlist length
                Console.WriteLine ("Provided location is out of range.");
                return;
            }

            Node ptr = head;
            Node prevNode = null;
            int counter = 1;
            if (counter == n) {
                head = ptr.next;
                return;
            }

            while (counter < n) {
                prevNode = ptr;
                ptr = ptr.next;
                counter++;
            }
            prevNode.next = ptr.next;

        }

        //utility method
        public int Size () {
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
        public int Size (Node head) {
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
        public Node createLinkedListOfTenNodes () {
            Add (10);
            Add (20);
            Add (30);
            Add (40);
            Add (50);
            Add (60);
            Add (70);
            Add (80);
            Add (90);
            Add (100);

            return head;
        }

        public Node CreateLoopedLinkedList (Node head) {
            Node ptr = new Node (10);
            head = ptr;
            ptr.next.next = new Node (20);
            ptr.next.next.next = new Node (30);

            return head;
        }

        static void Main (string[] args) {
            LinkedList linkedList = new LinkedList ();
            linkedList.Add (20);
            linkedList.Add (30);
            linkedList.Add (40);
            linkedList.Add (50);
            linkedList.Add (60);
            linkedList.Add (10);
            linkedList.AddFirst (9);
            linkedList.AddAfterNthNode (3, 35);
            linkedList.AddAfterPrevNode (linkedList.head.next.next.next, 38);
            linkedList.Traverse ();
            Console.WriteLine ("_______________");
            //linkedList.DeleteNode (38);
            //linkedList.DeleteNthNode (2);
            linkedList.DeleteFirstNode ();
            linkedList.DeleteLastNode ();

            linkedList.Traverse ();
            int size = linkedList.Size ();
            Console.WriteLine ("Size of linked list is: " + size);
            bool ifFound = linkedList.Search (20);
            Console.WriteLine ("Element found: " + ifFound);
            bool elemFound = linkedList.Search (80);
            Console.WriteLine ("Element found: " + elemFound);

        }

    }
}