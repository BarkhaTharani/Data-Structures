using data_structures_linkedlist;

namespace data_structures.basics {
    public class ReverseLinkedList {
        public void ReverseList (Node head) {
            Node prev = null, current = head, next = null;
            while (current != null) {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }

    }

}