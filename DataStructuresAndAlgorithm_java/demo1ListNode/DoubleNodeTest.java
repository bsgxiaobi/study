package demo1ListNode;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.Test;

class DoubleNodeTest {

	
	public static void main(String[] args) {
		DoubleNode dn1 = new DoubleNode(1);
		DoubleNode dn2 = new DoubleNode(2);
		DoubleNode dn3 = new DoubleNode(3);
		dn1.afterNode(dn2);
		dn2.afterNode(dn3);
		System.out.println(dn2.Pre().getData());
		System.out.println(dn2.getData());
		System.out.println(dn2.Next().getData());
	}
}
