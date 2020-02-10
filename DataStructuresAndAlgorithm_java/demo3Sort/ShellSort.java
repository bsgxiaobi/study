package demo3Sort;

import java.util.Arrays;

public class ShellSort {
	/*
	 基本思想：先取一个小于n的整数d1作为第一个增量，把文件的全部记录分组。所有距离
	 	为d1的倍数的记录放在同一个组中。先在各组内进行直接插入排序；然后，取第二个
	 	增量d2<d1重复上述的分组和排序，直至所取的增量 =1( < …<d2<d1)，即所有记录放
	 	在同一组中进行直接插入排序为止。
	 	一般的初次取序列的一半为增量，以后每次减半，直到增量为1。
	 	参考：https://baike.baidu.com/item/%E5%B8%8C%E5%B0%94%E6%8E%92%E5%BA%8F/3229428?fr=aladdin
	 */
	public static void main(String[] args) {
		int arr[] = new int[] {-1,5,1,7,-1,6,9,11,50,-3,14,11,-4,48,2};
		System.out.println(Arrays.toString(arr));
		shellSort(arr);
		
	}
	
	/**
	 * @param arr
	 */
	public static void shellSort(int[] arr) {
		int temp=0;
		//遍历所有的步长，一般的初次取序列的一半为增量，以后每次减半，直到增量为1
		for(int d=arr.length/2;d>0;d/=2) {
			//遍历所有元素
			for(int j=d;j<arr.length;j++) {
				//遍历当前步长对应组的所有元素
				for(int k=j-d;k>=0;k-=d) {
					if(arr[k]>arr[k+d]) {
						temp=arr[k];
						arr[k]=arr[k+d];
						arr[k+d]=temp;
					}
				}
			}
			//输出每个步长后的顺序
			System.out.println(Arrays.toString(arr));
		}
	}
}
