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
	 * 斐波拉契数列F(1)=1，F(2)=1, F(n)=F(n-1)+F(n-2)（n>=3，n∈N*）
	 * @param num 数列
	 * @return
	 */
	public static long Fibonacci(int num) {
		if(num ==1 || num==2) return fib[1];
		if(fib[num] != 0) return fib[num];
		fib[num] = Fibonacci(num-1)+Fibonacci(num-2);
		return fib[num];
	}
	
	/**
	 * 汉诺塔问题
	 * @param n 数量
	 * @param from 开始柱子
	 * @param in 中间柱子
	 * @param to 目标柱子
	 */
	public static void Hanoi(int n,char from,char in,char to) {
		count++;
		if(n == 1) {
			//System.out.println("1 "+from+"-->"+to);
		}else {
			//移动上面所有盘子到中间柱子
			Hanoi(n-1, from, to, in);
			//移动下面的盘子
			//System.out.println(n+" "+from+"-->"+to);
			//把上面所有的盘子移动到目标柱子
			Hanoi(n-1, in, from, to);
		}
	}
}
