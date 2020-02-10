package demo3Sort;

import java.util.Arrays;

public class BinaryInsertionSort {
	/*
	 ����˼���ǣ�ÿ����һ��������ļ�¼������ؼ���ֵ�Ĵ�С����ǰ���Ѿ�����
	 	���ļ����ʵ�λ���ϣ�ֱ��ȫ��������Ϊֹ����Ϊֱ�Ӳ�����۰���Ҳ��롣
	 �ο���https://baike.baidu.com/item/%E6%8A%98%E5%8D%8A%E6%8F%92%E5%85%A5%E6%8E%92%E5%BA%8F/8208853#1
	 */
	public static void main(String[] args) {
		//int arr[] = new int[] {-1,5,1,7,2,6,9,3,50,-3,14,11,19,48,20};
		int arr[] = new int[] {-1,5,1,7,-1,6,9,11,50,-3,14,11,-4,48,2};
		System.out.println(Arrays.toString(arr));
		binaryInsertionSort(arr);
	}
	
	/**
	 * 
	 * @param arr ��Ҫ���������
	 * @param �۰����
	 */
	public static void binaryInsertionSort(int[] arr) {
		int temp=0,index=0;
		int left,right;
		for(int i=1;i<arr.length;i++) {
			temp = arr[i];//���Ƴ���Ҫ�����ֵ
			//�۰����
			left=0;
			right=i-1;
			while(right>=left) {
				int middle = (left+right)/2;//�����ҵ��м��±�
				if(arr[i]==arr[middle]) {
					//˵������ͬԪ�أ�Ϊ���ȶ�����ں�һλ
					index = middle+1;
					right --;
					continue;
				}else if(arr[i]>arr[middle]) {
					//�����������ں�һλ
					left=middle+1;
					index = middle+1;
				}else {
					//���С������ڵ�ǰλ��
					right = middle-1;
					index = middle;
				}
			}
			//Ԫ�����Ųλ��
			for(int k=i;k>index;k--) {
				arr[k] = arr[k-1];
			}
			arr[index] = temp;
			System.out.println(Arrays.toString(arr));
		}
	}
}
