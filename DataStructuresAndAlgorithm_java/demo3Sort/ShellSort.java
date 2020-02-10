package demo3Sort;

import java.util.Arrays;

public class ShellSort {
	/*
	 ����˼�룺��ȡһ��С��n������d1��Ϊ��һ�����������ļ���ȫ����¼���顣���о���
	 	Ϊd1�ı����ļ�¼����ͬһ�����С����ڸ����ڽ���ֱ�Ӳ�������Ȼ��ȡ�ڶ���
	 	����d2<d1�ظ������ķ��������ֱ����ȡ������ =1( < ��<d2<d1)�������м�¼��
	 	��ͬһ���н���ֱ�Ӳ�������Ϊֹ��
	 	һ��ĳ���ȡ���е�һ��Ϊ�������Ժ�ÿ�μ��룬ֱ������Ϊ1��
	 	�ο���https://baike.baidu.com/item/%E5%B8%8C%E5%B0%94%E6%8E%92%E5%BA%8F/3229428?fr=aladdin
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
		//�������еĲ�����һ��ĳ���ȡ���е�һ��Ϊ�������Ժ�ÿ�μ��룬ֱ������Ϊ1
		for(int d=arr.length/2;d>0;d/=2) {
			//��������Ԫ��
			for(int j=d;j<arr.length;j++) {
				//������ǰ������Ӧ�������Ԫ��
				for(int k=j-d;k>=0;k-=d) {
					if(arr[k]>arr[k+d]) {
						temp=arr[k];
						arr[k]=arr[k+d];
						arr[k+d]=temp;
					}
				}
			}
			//���ÿ���������˳��
			System.out.println(Arrays.toString(arr));
		}
	}
}
