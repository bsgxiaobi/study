package demo3Sort;

import java.lang.reflect.Array;
import java.util.Arrays;

public class QuickSort {
	public static void main(String[] args) {
		int arr[] = new int[] {-1,5,1,7,2,6,9,3,50,-3,14,11,19,48,20};
		quickSort(arr, 0, arr.length-1);
		System.out.println(Arrays.toString(arr));
	}
	/**
	 * 
	 * @param arr 排序数组
	 * @param start 开始位置
	 * @param end 结束位置
	 */
	public static void quickSort(int arr[],int start,int end) {
		if(start>=end) return;
		int stand = arr[start];
		int left  = start;
		int right = end;
		int temp;
		while (left < right) {
			while(right>left && arr[right]>=stand) {
				right--;
			}
			while(right>left && arr[left]<=stand) {
				left++;
			}
			if(right>left) {
				temp = arr[right];
				arr[right] = arr[left];
				arr[left] = temp;
			}
		}
		
		arr[start] = arr[left];
		arr[left] = stand;
		quickSort(arr, start, left-1);
		quickSort(arr, left+1, end);
	}
	
}
