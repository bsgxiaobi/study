package demo2Recursive;

public class TestRecursive {
	public static long count = 0;
	public static long fib[] = new long[101];
	public static void main(String[] args) {
		fib[1]=1;
		fib[2]=1;
//		long num = Fibonacci(100);
//		for (int i = 0; i < fib.length; i++) {
//			System.out.println(fib[i]);
//		}
		Hanoi(30, 'A', 'B', 'C');
		System.out.println(count);
	}
	/**
	 * 쳲���������F(1)=1��F(2)=1, F(n)=F(n-1)+F(n-2)��n>=3��n��N*��
	 * @param num ����
	 * @return
	 */
	public static long Fibonacci(int num) {
		if(num ==1 || num==2) return fib[1];
		if(fib[num] != 0) return fib[num];
		fib[num] = Fibonacci(num-1)+Fibonacci(num-2);
		return fib[num];
	}
	
	/**
	 * ��ŵ������
	 * @param n ����
	 * @param from ��ʼ����
	 * @param in �м�����
	 * @param to Ŀ������
	 */
	public static void Hanoi(int n,char from,char in,char to) {
		count++;
		if(n == 1) {
			//System.out.println("1 "+from+"-->"+to);
		}else {
			//�ƶ������������ӵ��м�����
			Hanoi(n-1, from, to, in);
			//�ƶ����������
			//System.out.println(n+" "+from+"-->"+to);
			//���������е������ƶ���Ŀ������
			Hanoi(n-1, in, from, to);
		}
	}
}
