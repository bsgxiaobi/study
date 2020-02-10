package demo3Sort;

import java.util.Arrays;

public class BinaryInsertionSort {
	/*
	 基本思想是：每步将一个待排序的记录，按其关键码值的大小插入前面已经排序
	 	的文件中适当位置上，直到全部插入完为止。分为直接插入和折半查找插入。
	 参考：https://baike.baidu.com/item/%E6%8A%98%E5%8D%8A%E6%8F%92%E5%85%A5%E6%8E%92%E5%BA%8F/8208853#1
	 */
	public static void main(String[] args) {
		//int arr[] = new int[] {-1,5,1,7,2,6,9,3,50,-3,14,11,19,48,20};
		int arr[] = new int[] {-1,5,1,7,-1,6,9,11,50,-3,14,11,-4,48,2};
		System.out.println(Arrays.toString(arr));
		binaryInsertionSort(arr);
	}
	
	/**
	 * 
	 * @param arr 需要排序的数组
	 * @param 折半插入
	 */
	public static void binaryInsertionSort(int[] arr) {
		int temp=0,index=0;
		int left,right;
		for(int i=1;i<arr.length;i++) {
			temp = arr[i];//复制出需要排序的值
			//折半查找
			left=0;
			right=i-1;
			while(right>=left) {
				int middle = (left+right)/2;//二分找到中间下标
				if(arr[i]==arr[middle]) {
					//说明有相同元素，为了稳定则放在后一位
					index = middle+1;
					right --;
					continue;
				}else if(arr[i]>arr[middle]) {
					//如果大于则放在后一位
					left=middle+1;
					index = middle+1;
				}else {
					//如果小于则放在当前位置
					right = middle-1;
					index = middle;
				}
			}
			//元素向后挪位置
			for(int k=i;k>index;k--) {
				arr[k] = arr[k-1];
			}
			arr[index] = temp;
			System.out.println(Arrays.toString(arr));
		}
	}
}
