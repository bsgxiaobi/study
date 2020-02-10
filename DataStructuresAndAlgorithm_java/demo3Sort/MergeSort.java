package demo3Sort;

import java.util.Arrays;

import javax.xml.transform.Templates;

public class MergeSort {
	/*
	 归并排序（MERGE-SORT）是建立在归并操作上的一种有效的排序算法,
	 该算法是采用分治法（Divide and Conquer）的一个非常典型的应用。
	 将已有序的子序列合并，得到完全有序的序列；即先使每个子序列有序，
	 再使子序列段间有序。若将两个有序表合并成一个有序表，称为二路归并。
	 归并排序是一种稳定的排序方法。
	 */
	public static void main(String[] args) {
		int arr[] = new int[] {-1,5,1,7,-1,6,9,11,50,-3,14,11,-4,48,2};
		System.out.println(Arrays.toString(arr));
		mergeSort(arr,0,arr.length-1);
	}
	
	/**
	 * @param arr 数组 [left,right]
	 * @param left 左起点下标 
	 * @param right 右结束下标
	 */
	public static void mergeSort(int[] arr,int left,int right) {
		if(left>=right) return;
		int middle = (left+right)/2; 
		mergeSort(arr, left, middle);//分治左边
		mergeSort(arr, middle+1, right);//分治右边
		mergeOperation(arr, left, middle, right);//并归
		System.out.println(Arrays.toString(arr));
	}
	/**
	 * 
	 * @param arr 数组
	 * @param low 起始位置下标 [low,middle]
	 * @param middle 中间位置下标
	 * @param high 结束位置下标 [middle+1,high]
	 */
	public static void mergeOperation(int[] arr,int low,int middle,int high) {
		int[] arr_tmp = new int[high-low+1];//定义临时数组
		int i=low;//第一个数组的起始下标
		int j=middle+1;//第二个数组的起始下标
		int index=0;//临时数组的下标
		//遍历两个数组的最小数并放入临时数组
		while(i<=middle && j<=high) {
			if(arr[i]<arr[j]) {
				arr_tmp[index++]=arr[i++];
			}else {
				arr_tmp[index++]=arr[j++];
			}
		}
		//处理剩下多余的数据
		while(i<=middle) {
			//左边有剩余
			arr_tmp[index++]=arr[i++];
		}
		while(j<=high) {
			//右边有剩余
			arr_tmp[index++]=arr[j++];
		}
		//把临时数组重新转给原数组
		for(int k=0;k<arr_tmp.length;k++) {
			arr[low+k] = arr_tmp[k];
		}
	}
}
