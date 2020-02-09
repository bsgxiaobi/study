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
	 ����˼���ǣ�ÿ����һ��������ļ�¼������ؼ���ֵ�Ĵ�С����ǰ���Ѿ�����
	 	���ļ����ʵ�λ���ϣ�ֱ��ȫ��������Ϊֹ����Ϊֱ�Ӳ�����۰���Ҳ��롣
	 */
	/**
	 * 
	 * @param arr ��Ҫ���������
	 * @param �۰����
	 */
	public static void insertionSort(int arr[]) {
		int temp=0,index=0;
		int left,right;
		for(int i=1;i<arr.length;i++) {
			temp = arr[i];
			//�۰����
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
