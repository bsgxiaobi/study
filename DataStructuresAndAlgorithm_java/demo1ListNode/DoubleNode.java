package demo1ListNode;

//˫��ѭ������
public class DoubleNode {
	//��һ���ڵ�
	DoubleNode pre = this;
	//��һ���ڵ�
	DoubleNode next = this;
	//�ڵ�����
	int data;
	//���캯��
	public DoubleNode(int data) {
		// TODO Auto-generated constructor stub
		this.data = data;
	}
	//����һ���ڵ㣨���ã�
	public void afterNode(DoubleNode node) {
		//����ԭ�ڵ����һ���ڵ� 
		DoubleNode oldnext = this.next;
		//���½ڵ���ԭ�ڵ㽨����ϵ
		this.next = node;
		node.pre = this;
		//��oldnext���½ڵ㽨����ϵ
		node.next = oldnext;
		oldnext.pre = node;
	}
	public int getData() {
		return this.data;
	}
	public DoubleNode Pre() {
		return this.pre;
	}
	public DoubleNode Next() {
		return this.next;
	}
	
}
