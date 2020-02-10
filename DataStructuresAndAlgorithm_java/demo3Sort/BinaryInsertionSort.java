package demo3Sort;

import java.util.Arrays;

public class InsertionSort {
	public static void main(String[] args) {
		//int arr[] = new int[] {-1,5,1,7,2,6,9,3,50,-3,14,11,19,48,20};
		int arr[] = new int[] {-1,5,1,7,-1,6,9,11,50,-3,14,11,-4,48,2};
		System.out.println(Arrays.toString(arr));
		insertionSort(arr);
		System.out.println(Arrays.toString(arr));
	}
	/*
	 基本思想是：每步将一个待排序的记录，按其关键码值的大小插入前面已经排序
	 	的文件中适当位置上，直到全部插入完为止。分为直接插入和折半查找插入。
	 */
	/**
	 * 
	 * @param arr 需要排序的数组
	 * @param 折半插入
	 */
	public static void insertionSort(int arr[]) {
		int temp=0,index=0;
		int left,right;
		for(int i=1;i<arr.length;i++) {
			temp = arr[i];
			//折半查找
			left=0;
			right=i-1;
			while(right>=left) {
				int middle = (left+right)/2;
				if(arr[i]==arr[middle]) {
					index = middle+1;
					right --;
					continue;
				}else if(arr[i]>arr[middle]) {
					left=middle+1;
					index = middle+1;
				}else {
					right = middle-1;
					index = middle;
				}
				
			}
			for(int k=i;k>index;k--) {
				arr[k] = arr[k-1];
			}
			arr[index] = temp;
			System.out.println(Arrays.toString(arr));
		}
	}
}
