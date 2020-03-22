using System;
using data_structures_linkedlist;

namespace data_structures.basics {
    public class FindLoop {
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

        static void Main (string[] args) {
            LinkedList linkedList = new LinkedList ();
            linkedList.CreateLoopedLinkedList ();
            FindLoop loop = new FindLoop ();
            bool hasLoop = loop.HasLoop (linkedList.head);
            Console.WriteLine ("Does LinkedList has loop: " + hasLoop);
            Node loopStart = loop.FindLoopStart (linkedList.head);
            Console.WriteLine ("first node of loop is: " + loopStart.data);
            Node loopEnd = loop.FindLoopEnd (linkedList.head);
            Console.WriteLine ("Last node of loop is: " + loopEnd.data);
            int length = loop.LoopLength(linkedList.head);
            Console.WriteLine ("Length of loop is: " + length);
            loop.RemoveLoop(linkedList.head);
            linkedList.Traverse(linkedList.head);
        }
    }

}