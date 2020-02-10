package demo3Sort;

import java.util.Arrays;

import javax.xml.transform.Templates;

public class MergeSort {
	/*
	 �鲢����MERGE-SORT���ǽ����ڹ鲢�����ϵ�һ����Ч�������㷨,
	 ���㷨�ǲ��÷��η���Divide and Conquer����һ���ǳ����͵�Ӧ�á�
	 ��������������кϲ����õ���ȫ��������У�����ʹÿ������������
	 ��ʹ�����жμ������������������ϲ���һ���������Ϊ��·�鲢��
	 �鲢������һ���ȶ������򷽷���
	 */
	public static void main(String[] args) {
		int arr[] = new int[] {-1,5,1,7,-1,6,9,11,50,-3,14,11,-4,48,2};
		System.out.println(Arrays.toString(arr));
		mergeSort(arr,0,arr.length-1);
	}
	
	/**
	 * @param arr ���� [left,right]
	 * @param left ������±� 
	 * @param right �ҽ����±�
	 */
	public static void mergeSort(int[] arr,int left,int right) {
		if(left>=right) return;
		int middle = (left+right)/2; 
		mergeSort(arr, left, middle);//�������
		mergeSort(arr, middle+1, right);//�����ұ�
		mergeOperation(arr, left, middle, right);//����
		System.out.println(Arrays.toString(arr));
	}
	/**
	 * 
	 * @param arr ����
	 * @param low ��ʼλ���±� [low,middle]
	 * @param middle �м�λ���±�
	 * @param high ����λ���±� [middle+1,high]
	 */
	public static void mergeOperation(int[] arr,int low,int middle,int high) {
		int[] arr_tmp = new int[high-low+1];//������ʱ����
		int i=low;//��һ���������ʼ�±�
		int j=middle+1;//�ڶ����������ʼ�±�
		int index=0;//��ʱ������±�
		//���������������С����������ʱ����
		while(i<=middle && j<=high) {
			if(arr[i]<arr[j]) {
				arr_tmp[index++]=arr[i++];
			}else {
				arr_tmp[index++]=arr[j++];
			}
		}
		//����ʣ�¶��������
		while(i<=middle) {
			//�����ʣ��
			arr_tmp[index++]=arr[i++];
		}
		while(j<=high) {
			//�ұ���ʣ��
			arr_tmp[index++]=arr[j++];
		}
		//����ʱ��������ת��ԭ����
		for(int k=0;k<arr_tmp.length;k++) {
			arr[low+k] = arr_tmp[k];
		}
	}
}
