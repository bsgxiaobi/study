package demo1ListNode;

//双向循环链表
public class DoubleNode {
	//上一个节点
	DoubleNode pre = this;
	//下一个节点
	DoubleNode next = this;
	//节点数据
	int data;
	//构造函数
	public DoubleNode(int data) {
		// TODO Auto-generated constructor stub
		this.data = data;
	}
	//插入一个节点（后置）
	public void afterNode(DoubleNode node) {
		//保存原节点的下一个节点 
		DoubleNode oldnext = this.next;
		//把新节点与原节点建立关系
		this.next = node;
		node.pre = this;
		//把oldnext与新节点建立关系
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
