package demo3Sort;

import java.lang.reflect.Array;
import java.util.Arrays;

public class QuickSort {
	/*
	 ����˼�룺ͨ��һ������Ҫ��������ݷָ�ɶ����������֣�����һ���ֵ�����
	 ���ݶ�������һ���ֵ��������ݶ�ҪС��Ȼ���ٰ��˷����������������ݷֱ����
	 ������������������̿��Եݹ���У��Դ˴ﵽ�������ݱ���������С�
	 (1)�����趨һ���ֽ�ֵ��ͨ���÷ֽ�ֵ������ֳ����������֡�
	 (2)�����ڻ���ڷֽ�ֵ�����ݼ��е������ұߣ�С�ڷֽ�ֵ�����ݼ��е��������ߡ�
		��ʱ����߲����и�Ԫ�ض�С�ڻ���ڷֽ�ֵ�����ұ߲����и�Ԫ�ض����ڻ���ڷֽ�ֵ��
	 (3)Ȼ����ߺ��ұߵ����ݿ��Զ������򡣶��������������ݣ��ֿ���ȡһ���ֽ�ֵ��
		���ò������ݷֳ����������֣�ͬ������߷��ý�Сֵ���ұ߷��ýϴ�ֵ���Ҳ������
		����Ҳ���������ƴ��� 
	 (4)�ظ��������̣����Կ���������һ���ݹ鶨�塣ͨ���ݹ齫��ಿ���ź�����ٵݹ��ź�
		�Ҳಿ�ֵ�˳�򡣵������������ָ�����������ɺ��������������Ҳ�������
	 �ο���https://baike.baidu.com/item/%E5%BF%AB%E9%80%9F%E6%8E%92%E5%BA%8F%E7%AE%97%E6%B3%95/369842?fr=aladdin
	 */
	public static void main(String[] args) {
		int arr[] = new int[] {-1,5,1,7,2,6,9,3,50,-3,14,11,19,48,20};
		quickSort(arr, 0, arr.length-1);
		System.out.println(Arrays.toString(arr));
	}
	
	/**
	 * 
	 * @param arr ��������
	 * @param start ��ʼλ��
	 * @param end ����λ��
	 */
	public static void quickSort(int arr[],int start,int end) {
		if(start>=end) return;
		int stand = arr[start];//�����ڵ�Ϊ��ǰ���еĵ�һ��
		int left  = start;
		int right = end;
		int temp;
		while (left < right) {
			//���������ҵ���һ�����ڵ�С����
			while(right>left && arr[right]>=stand) {
				right--;
			}
			//���������ҵ���һ�����ڵ�����
			while(right>left && arr[left]<=stand) {
				left++;
			}
			//��������±�û�п�Խ�Է�
			if(right>left) {
				temp = arr[right];
				arr[right] = arr[left];
				arr[left] = temp;
			}
		}
		//�ڵ��������±�Ի�
		arr[start] = arr[left];
		arr[left] = stand;
		//�����ڵ��ֳ�ǰ��������
		quickSort(arr, start, left-1);
		quickSort(arr, left+1, end);
	}
	
}
