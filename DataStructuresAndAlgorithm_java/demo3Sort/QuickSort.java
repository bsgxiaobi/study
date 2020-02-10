package demo3Sort;

import java.lang.reflect.Array;
import java.util.Arrays;

public class QuickSort {
	public static void main(String[] args) {
		int arr[] = new int[] {-1,5,1,7,2,6,9,3,50,-3,14,11,19,48,20};
		quickSort(arr, 0, arr.length-1);
		System.out.println(Arrays.toString(arr));
	}
	/*
	 基本思想：通过一趟排序将要排序的数据分割成独立的两部分，其中一部分的所有
	 数据都比另外一部分的所有数据都要小，然后再按此方法对这两部分数据分别进行
	 快速排序，整个排序过程可以递归进行，以此达到整个数据变成有序序列。
	 (1)首先设定一个分界值，通过该分界值将数组分成左右两部分。
	 (2)将大于或等于分界值的数据集中到数组右边，小于分界值的数据集中到数组的左边。
		此时，左边部分中各元素都小于或等于分界值，而右边部分中各元素都大于或等于分界值。
	 (3)然后，左边和右边的数据可以独立排序。对于左侧的数组数据，又可以取一个分界值，
		将该部分数据分成左右两部分，同样在左边放置较小值，右边放置较大值。右侧的数组
		数据也可以做类似处理。 
	 (4)重复上述过程，可以看出，这是一个递归定义。通过递归将左侧部分排好序后，再递归排好
		右侧部分的顺序。当左、右两个部分各数据排序完成后，整个数组的排序也就完成了
	 */
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
